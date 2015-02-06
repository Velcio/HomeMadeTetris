using System.Drawing;

namespace Tetris.Pieces
{
    class LPiece : Tetriminos
    {
        public override int Color { get; protected set; }

        public LPiece()
        {
            Color = 0xff6600;
            Positions[0] = new Point(4, 20);
            Positions[1] = new Point(5, 20);
            Positions[2] = new Point(6, 20);
            Positions[3] = new Point(6, 21);
        }

        public static void MiniaturePiece(int[][] positions)
        {
            positions[0][2] = 0xff6600;
            positions[1][2] = 0xff6600;
            positions[2][2] = 0xff6600;
            positions[2][1] = 0xff6600;
        }

        public override void Rotate()
        {
            if (state == 0)
            {
                Positions[0] = new Point(Positions[1].X + 1, Positions[1].Y - 1);
                Positions[2] = new Point(Positions[1].X, Positions[1].Y - 1);
                Positions[3] = new Point(Positions[1].X, Positions[1].Y + 1);
                RaiseState();
                return;
            }
            if (state == 1)
            {
                if (Positions[0].X > 1)
                {
                    Positions[0] = new Point(Positions[1].X + 1, Positions[1].Y);
                    Positions[2] = new Point(Positions[1].X - 1, Positions[1].Y);
                    Positions[3] = new Point(Positions[1].X - 1, Positions[1].Y - 1);
                    RaiseState();
                }
                return;
            }
            if (state == 2)
            {
                Positions[0] = new Point(Positions[1].X, Positions[1].Y - 1);
                Positions[2] = new Point(Positions[1].X, Positions[1].Y + 1);
                Positions[3] = new Point(Positions[1].X - 1, Positions[1].Y + 1);
                RaiseState();
                return;
            }
            if (state == 3)
            {
                if (Positions[0].X < 9)
                {
                    Positions[0] = new Point(Positions[1].X - 1, Positions[1].Y);
                    Positions[2] = new Point(Positions[1].X + 1, Positions[1].Y);
                    Positions[3] = new Point(Positions[1].X + 1, Positions[1].Y + 1);
                    RaiseState();
                }
            }
        }
    }
}
