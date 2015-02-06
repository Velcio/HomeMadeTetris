using System.Drawing;

namespace Tetris.Pieces
{
    class SPiece : Tetriminos
    {
        public override int Color { get; protected set; }

        public SPiece()
        {
            Color = 0x00ff00;
            Positions[0] = new Point(3, 20);
            Positions[1] = new Point(4, 20);
            Positions[2] = new Point(4, 21);
            Positions[3] = new Point(5, 21);
        }

        public static void MiniaturePiece(int[][] positions)
        {
            positions[0][2] = 0x00ff00;
            positions[1][2] = 0x00ff00;
            positions[1][1] = 0x00ff00;
            positions[2][1] = 0x00ff00;
        }

        public override void Rotate()
        {
            if (state == 0)
            {
                Positions[0] = new Point(Positions[1].X, Positions[1].Y + 1);
                Positions[2] = new Point(Positions[1].X + 1, Positions[1].Y);
                Positions[3] = new Point(Positions[1].X + 1, Positions[1].Y - 1);
                RaiseState();
                return;
            }
            if (state == 1)
            {
                if (Positions[0].X > 1)
                {
                    Positions[0] = new Point(Positions[1].X + 1, Positions[1].Y);
                    Positions[2] = new Point(Positions[1].X, Positions[1].Y - 1);
                    Positions[3] = new Point(Positions[1].X - 1, Positions[1].Y - 1);
                    RaiseState();
                }
                return;
            }
            if (state == 2)
            {
                Positions[0] = new Point(Positions[1].X, Positions[1].Y - 1);
                Positions[2] = new Point(Positions[1].X - 1, Positions[1].Y);
                Positions[3] = new Point(Positions[1].X - 1, Positions[1].Y + 1);
                RaiseState();
                return;
            }
            if (state == 3)
            {
                if (Positions[0].X < 8)
                {
                    Positions[0] = new Point(Positions[1].X - 1, Positions[1].Y);
                    Positions[2] = new Point(Positions[1].X, Positions[1].Y + 1);
                    Positions[3] = new Point(Positions[1].X + 1, Positions[1].Y + 1);
                    RaiseState();
                }
            }
        }
    }
}
