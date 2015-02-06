using System.Drawing;

namespace Tetris.Pieces
{
    class IPiece : Tetriminos
    {
        public override int Color { get; protected set; }

        public IPiece()
        {
            Color = 0x00ffff;
            Positions[0] = new Point(3, 20);
            Positions[1] = new Point(4, 20);
            Positions[2] = new Point(5, 20);
            Positions[3] = new Point(6, 20);
        }

        public static void MiniaturePiece(int[][] positions)
        {
            positions[0][2] = 0x00ffff;
            positions[1][2] = 0x00ffff;
            positions[2][2] = 0x00ffff;
            positions[3][2] = 0x00ffff;
        }

        public override void Rotate()
        {
            if (state == 0)
            {
                Positions[1] = new Point(Positions[1].X + 1, Positions[1].Y);
                Positions[0] = new Point(Positions[1].X, Positions[1].Y + 1);
                Positions[2] = new Point(Positions[1].X, Positions[1].Y - 1);
                Positions[3] = new Point(Positions[1].X, Positions[1].Y - 2);
                RaiseState();
                return;
            }
            if (state == 1)
            {
                if (Positions[0].X > 0)
                {
                    Positions[1] = new Point(Positions[1].X, Positions[1].Y - 1);
                    Positions[0] = new Point(Positions[1].X + 1, Positions[1].Y);
                    Positions[2] = new Point(Positions[1].X - 1, Positions[1].Y);
                    Positions[3] = new Point(Positions[1].X - 2, Positions[1].Y);
                    RaiseState();
                }
                return;
            }
            if (state == 2)
            {
                Positions[1] = new Point(Positions[1].X - 1, Positions[1].Y);
                Positions[0] = new Point(Positions[1].X, Positions[1].Y - 1);
                Positions[2] = new Point(Positions[1].X, Positions[1].Y + 1);
                Positions[3] = new Point(Positions[1].X, Positions[1].Y + 2);
                RaiseState();
                return;
            }
            if (state == 3)
            {
                if (Positions[0].X < 9)
                {
                    Positions[1] = new Point(Positions[1].X, Positions[1].Y + 1);
                    Positions[0] = new Point(Positions[1].X - 1, Positions[1].Y);
                    Positions[2] = new Point(Positions[1].X + 1, Positions[1].Y);
                    Positions[3] = new Point(Positions[1].X + 2, Positions[1].Y);
                    RaiseState();
                }
            }
        }
    }
}
