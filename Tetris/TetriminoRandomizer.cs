using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Pieces;

namespace Tetris
{
    class TetriminoRandomizer
    {
        private Random random = new Random();
        private Queue<Type> tetriminos = new Queue<Type>();

        private List<Type> tetriTypes;

        private void GenerateBag()
        {
            tetriTypes = new List<Type>();
            tetriTypes.Add(typeof(IPiece));
            tetriTypes.Add(typeof(JPiece));
            tetriTypes.Add(typeof(LPiece));
            tetriTypes.Add(typeof(OPiece));
            tetriTypes.Add(typeof(SPiece));
            tetriTypes.Add(typeof(TPiece));
            tetriTypes.Add(typeof(ZPiece));
            for (int i = 0; i < 7; i++)
            {
                int rand = random.Next(tetriTypes.Count);
                tetriminos.Enqueue(tetriTypes[rand]);
                tetriTypes.RemoveAt(rand);
            }
        }

        public Type RandomTetriminos()
        {
            if (tetriminos.Count == 0)
                GenerateBag();

            return tetriminos.Dequeue();
        }

    }
}
