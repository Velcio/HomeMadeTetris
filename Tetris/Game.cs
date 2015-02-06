using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.VisualStyles;
using Tetris.Pieces;

namespace Tetris
{
    class Game : Subject
    {
        #region fields
        private int[][] field = new int[22][]; //[rows][columns]
        private List<Observer> observers = new List<Observer>();
        private Tetriminos currentTetriminos, ghostTetriminos;
        private Random random = new Random();
        public Type bankTetriminos;
        private Queue<Type> previewTetriminos = new Queue<Type>();
        private TetriminoRandomizer randomizer = new TetriminoRandomizer();
        #endregion

        #region properties
        public int[][] Field { get { return MergeTetrimino(); } }
        public bool JustSwitched { get; set; }

        public int Score { get; private set; }
        public int Level { get; private set; }
        public int LinesToClear { get; private set; }

        public int[][] GetBankedTetrimino
        {
            get
            {
                int[][] positions = new int[4][];
                for (int i = 0; i < 4; i++)
                {
                    positions[i] = new int[4];
                    for (int j = 0; j < 4; j++)
                        positions[i][j] = 0;
                }

                PutMiniature(bankTetriminos, positions);

                return positions;
            }
        }

        public int[][][] GetPreviewTetriminos
        {
            get
            {
                int[][][] preview = new int[5][][];

                for (int i = 0; i < 5; i++)
                {
                    preview[i] = new int[4][];
                    for (int j = 0; j < 4; j++)
                    {
                        preview[i][j] = new[] { 0, 0, 0, 0 };
                    }
                }

                for (int i = 0; i < 5; i++)
                {
                    Type type = previewTetriminos.Dequeue();
                    PutMiniature(type, preview[i]);
                    previewTetriminos.Enqueue(type);
                }

                return preview;
            }
        }

        #endregion

        #region constructor
        public Game()
        {
            LinesToClear = 10;
            for (int row = 0; row < field.Length; row++)
            {
                field[row] = new int[10];

                for (int column = 0; column < field[row].Length; column++)
                {
                    field[row][column] = 0;
                }
            }
            InitializePreviewQueue();
            SpawnTetrimino();
        }
        #endregion

        #region methods
        public void addObserver(Observer observer)
        {
            observers.Add(observer);
        }

        public void removeObserver(Observer observer)
        {
            observers.Remove(observer);
        }

        public void notifyObservers()
        {
            observers.ForEach(o => o.update());
        }

        public void MoveLeft()
        {
            if (!CollidesLeftSide())
            {
                currentTetriminos.MoveLeft();
                MoveGhostTetrimonos();
                notifyObservers();
            }
        }

        public void MoveRight()
        {
            if (!CollidesRightSide())
            {
                currentTetriminos.MoveRight();
                MoveGhostTetrimonos();
                notifyObservers();
            }
        }

        public void MoveDown()
        {
            if (Collides(currentTetriminos))
            {
                field = MergeTetrimino();
                RemoveLines();
                CheckGameOver();
                SpawnTetrimino();
                return;
            }

            currentTetriminos.MoveDown(1);
            notifyObservers();
        }

        public void SwitchBank()
        {
            if (!JustSwitched)
            {
                JustSwitched = true;
                Type temp = currentTetriminos.GetType();
                if (bankTetriminos != null)
                {
                    currentTetriminos = (Tetriminos)Activator.CreateInstance(bankTetriminos);
                }
                else
                {
                    SpawnTetrimino();
                }
                bankTetriminos = temp;

                MoveGhostTetrimonos();
                notifyObservers();
            }
        }

        public void Rotate()
        {
            if (!(currentTetriminos.GetType() == typeof(OPiece)))
            {
                int currentRotation;
                for (int state = 0; state < 4; state++)
                {
                    currentRotation = 0;
                    currentTetriminos.Rotate();
                    foreach (var position in currentTetriminos.Positions)
                    {
                        if (position.X >= 0 && position.X <= 9 && field[position.Y][position.X] == 0)
                        {
                            currentRotation++;
                        }
                    }
                    if (currentRotation == 4) break;
                }

                MoveGhostTetrimonos();
                notifyObservers();
            }
        }

        public void PlaceDown()
        {
            while (!Collides(currentTetriminos))
            {
                currentTetriminos.MoveDown(1);
            }

            field = MergeTetrimino();
            RemoveLines();
            CheckGameOver();
            SpawnTetrimino();
            notifyObservers();
        }

        private void PutMiniature(Type tetriminos, int[][] positions)
        {
            if (tetriminos == typeof(IPiece))
            {
                IPiece.MiniaturePiece(positions);
                return;
            }
            if (tetriminos == typeof(JPiece))
            {
                JPiece.MiniaturePiece(positions);
                return;
            }
            if (tetriminos == typeof(LPiece))
            {
                LPiece.MiniaturePiece(positions);
                return;
            }
            if (tetriminos == typeof(OPiece))
            {
                OPiece.MiniaturePiece(positions);
                return;
            }
            if (tetriminos == typeof(SPiece))
            {
                SPiece.MiniaturePiece(positions);
                return;
            }
            if (tetriminos == typeof(TPiece))
            {
                TPiece.MiniaturePiece(positions);
                return;
            }
            if (tetriminos == typeof(ZPiece))
            {
                ZPiece.MiniaturePiece(positions);
            }
        }

        private bool CollidesLeftSide()
        {
            foreach (var position in currentTetriminos.Positions)
            {
                if (position.X == 0)
                    return true;

                if (field[position.Y][position.X - 1] != 0)
                    return true;
            }

            return false;
        }

        private bool CollidesRightSide()
        {
            foreach (var position in currentTetriminos.Positions)
            {
                if (position.X == 9)
                    return true;

                if (field[position.Y][position.X + 1] != 0)
                    return true;
            }

            return false;
        }

        private bool Collides(Tetriminos tetriminos)
        {
            foreach (var position in tetriminos.Positions)
            {
                if (position.Y == 0)
                    return true;

                try
                {
                    if (field[position.Y - 1][position.X] != 0)
                        return true;
                }
                catch (Exception)
                {
                }
            }

            return false;
        }

        private void CheckGameOver()
        {
            for (int i = 0; i < 10; i++)
            {
                if (field[20][i] != 0)
                {
                    observers.ForEach(o => o.gameOver());
                    break;
                }
            }
        }

        private void InitializePreviewQueue()
        {
            for (int i = 0; i < 5; i++)
            {
                AddToQueue();
            }
        }

        private void AddToQueue()
        {
            previewTetriminos.Enqueue(randomizer.RandomTetriminos());
        }

        private void SpawnTetrimino()
        {
            currentTetriminos = (Tetriminos)Activator.CreateInstance(previewTetriminos.Peek());
            ghostTetriminos = (Tetriminos)Activator.CreateInstance(previewTetriminos.Dequeue());
            AddToQueue();

            currentTetriminos.MoveDown(1);
            ghostTetriminos.IsGhostTetrimino = true;
            MoveGhostTetrimonos();
            JustSwitched = false;
        }

        private void MoveGhostTetrimonos()
        {
            ghostTetriminos.Positions = (Point[])currentTetriminos.Positions.Clone();

            while (!Collides(ghostTetriminos))
            {
                ghostTetriminos.MoveDown(1);
            }
        }

        private void RemoveLines()
        {
            int amount = 0;
            bool[] line = new bool[21];
            for (int row = 0; row < 20; row++)
            {
                line[row] = true;
                for (int column = 0; column < 10; column++)
                {
                    if (field[row][column] == 0)
                    {
                        line[row] = false;
                        break;
                    }
                }
            }
            for (int row = 0; row < 20; row++)
            {
                if (line[row])
                {
                    amount++;
                    for (int remove = row; remove < 20; remove++)
                    {
                        field[remove] = field[remove + 1];
                        line[remove] = line[remove + 1];
                    }
                    row--;
                }
            }
            AddScore(amount);
        }

        private void AddScore(int amount)
        {
            switch (amount)
            {
                case 1:
                    Score += 40 * (Level + 1);
                    break;
                case 2:
                    Score += 100 * (Level + 1);
                    break;
                case 3:
                    Score += 300 * (Level + 1);
                    break;
                case 4:
                    Score += 1200 * (Level + 1);
                    break;
            }

            if (LinesToClear - amount <= 0)
            {
                LinesToClear = 10 - (amount - LinesToClear);
                Level++;
                LinesToClear += Level;
            }
            else
            {
                LinesToClear -= amount;
            }
        }

        private int[][] MergeTetrimino()
        {
            int[][] newField = new int[22][];

            //makes a new array
            for (int i = 0; i < newField.Length; i++)
            {
                newField[i] = new int[10];
                for (int j = 0; j < newField[i].Length; j++)
                {
                    newField[i][j] = field[i][j];
                }
            }

            //places the tetrimino on the field
            if (currentTetriminos != null)
            {
                foreach (var position in ghostTetriminos.Positions)
                {
                    newField[position.Y][position.X] = -1;
                }

                foreach (var position in currentTetriminos.Positions)
                {
                    newField[position.Y][position.X] = currentTetriminos.Color;
                }
            }

            return newField;
        }
        #endregion
    }
}
