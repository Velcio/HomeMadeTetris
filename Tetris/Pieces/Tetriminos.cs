using System.Drawing;

namespace Tetris.Pieces
{
    public abstract class Tetriminos
    {
        public abstract int Color { get; protected set; }
        public Point[] Positions { get; set; }
        public bool IsGhostTetrimino { get; set; }
        public int state;

        public Tetriminos()
        {
            Positions = new Point[4];
        }

        public void MoveDown(int amount)
        {
            Move(0, -amount);
        }

        public void MoveLeft()
        {
            Move(-1, 0);
        }

        public void MoveRight()
        {
            Move(1, 0);
        }
        
        public void PlaceDown(int height)
        {
            //find lowest point
            int low = int.MaxValue;
            foreach (var position in Positions)
            {
                if (position.Y < low)
                {
                    low = position.Y;
                }
            }
            MoveDown(low - height);
        }

        public abstract void Rotate();

        protected void Move(int x, int y)
        {
            for (int i = 0; i < 4; i++)
            {
                Positions[i] = new Point(Positions[i].X + x, Positions[i].Y + y);
            }
        }

        protected void RaiseState()
        {
            state = (state + 1) % 4;
        }
    }
}
