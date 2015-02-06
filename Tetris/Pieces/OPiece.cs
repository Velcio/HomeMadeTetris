using System.Drawing;

namespace Tetris.Pieces
{
    class OPiece : Tetriminos
    {
        public override int Color { get; protected set; }

        public OPiece()
        {
            Color = 0xffff00;
            Positions[0] = new Point(4, 21);
            Positions[1] = new Point(5, 21);
            Positions[2] = new Point(4, 20);
            Positions[3] = new Point(5, 20);
        }

        public static void MiniaturePiece(int[][] positions)
        {
            positions[1][1] = 0xffff00;
            positions[1][2] = 0xffff00;
            positions[2][1] = 0xffff00;
            positions[2][2] = 0xffff00;
        }

        public override void Rotate()
        {
            //nothing happens when rotating a cube :P
        }
    }
}
