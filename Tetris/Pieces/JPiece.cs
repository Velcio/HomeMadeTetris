using System.Drawing;

namespace Tetris.Pieces
{
    class JPiece : Tetriminos
    {
        public override int Color { get; protected set; }

        public JPiece()
        {
            Color = 0x0000ff;
            Positions[0] = new Point(3, 21);
            Positions[1] = new Point(3, 20);
            Positions[2] = new Point(4, 20);
            Positions[3] = new Point(5, 20);
        }

        public static void MiniaturePiece(int[][] positions)
        {
            positions[0][1] = 0x0000ff;
            positions[0][2] = 0x0000ff;
            positions[1][2] = 0x0000ff;
            positions[2][2] = 0x0000ff;
        }

        public override void Rotate()
        {
            if (state == 0)
            {
                Positions[0] = new Point(Positions[2].X + 1, Positions[2].Y + 1);
                Positions[1] = new Point(Positions[2].X, Positions[2].Y + 1);
                Positions[3] = new Point(Positions[2].X, Positions[2].Y - 1);
                RaiseState();
                return;
            }
            if (state == 1)
            {
                if (Positions[0].X > 1)
                {
                    Positions[0] = new Point(Positions[2].X + 1, Positions[2].Y - 1);
                    Positions[1] = new Point(Positions[2].X + 1, Positions[2].Y);
                    Positions[3] = new Point(Positions[2].X - 1, Positions[2].Y);
                    RaiseState();
                }
                return;
            }
            if (state == 2)
            {
                Positions[0] = new Point(Positions[2].X - 1, Positions[2].Y - 1);
                Positions[1] = new Point(Positions[2].X, Positions[2].Y - 1);
                Positions[3] = new Point(Positions[2].X, Positions[2].Y + 1);
                RaiseState();
                return;
            }
            if (state == 3)
            {
                if (Positions[0].X < 8)
                {
                    Positions[0] = new Point(Positions[2].X - 1, Positions[2].Y + 1);
                    Positions[1] = new Point(Positions[2].X - 1, Positions[2].Y);
                    Positions[3] = new Point(Positions[2].X + 1, Positions[2].Y);
                    RaiseState();
                }
            }
        }
    }
}
