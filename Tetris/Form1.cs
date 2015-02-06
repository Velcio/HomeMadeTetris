using System;
using System.Drawing;
using System.Windows.Forms;
using Tetris.Pieces;

namespace Tetris
{
    public partial class frmTetris : Form, Observer
    {
        private Game game;
        private Pen border = new Pen(Color.DimGray, 6);
        private Pen grid = new Pen(Color.DimGray, 2);
        private Pen ghost = new Pen(Color.LightGray, 2);
        private bool gameIsOver;
        private bool pause;
        private int color;
        private SolidBrush brush = new SolidBrush(Color.White);


        public frmTetris()
        {
            InitializeComponent();
        }

        private void frmTetris_Load(object sender, EventArgs e)
        {
            game = new Game();
            game.addObserver(this);
            update();
        }

        public void update()
        {
            RefreshPictureBoxes();
            lblScore.Text = game.Score.ToString();
            lblLevel.Text = game.Level.ToString();
            lblLines.Text = game.LinesToClear.ToString();
            tmrMove.Interval = game.Level < 20 ? 1000 - 40*game.Level : 200;
        }

        public void gameOver()
        {
            tmrMove.Enabled = false;
            gameIsOver = true;
            MessageBox.Show("Game Over");
            //code for the menu
        }

        private void picBlocks_Paint(object sender, PaintEventArgs e)
        {
            RenderGrid(e.Graphics);
            RenderBlocks(e.Graphics, game.Field);
        }

        private void RenderGrid(Graphics graphics)
        {
            //draw the border which is 6 px thick
            graphics.DrawLine(border, 0, 3, 230, 3);
            graphics.DrawLine(border, 0, 447, 230, 447);
            graphics.DrawLine(border, 3, 0, 3, 447);
            graphics.DrawLine(border, 227, 0, 227, 447);

            //draws the grid which is 2 px thick
            for (int row = 1; row < 20; row++)
            {
                graphics.DrawLine(grid, 0, 5 + row * 22, 230, 5 + row * 22);
            }
            for (int column = 1; column < 10; column++)
            {
                graphics.DrawLine(grid, 5 + column * 22, 0, 5 + column * 22, 447);
            }
        }

        private void RenderBlocks(Graphics graphics, int[][] field)
        {
            int color;
            SolidBrush brush = new SolidBrush(Color.White);
            for (int row = 0; row < 20; row++)
            {
                for (int column = 0; column < field[0].Length; column++)
                {
                    if (field[row][column] > 0)
                    {
                        color = field[row][column];
                        brush.Color = Color.FromArgb((color >> 16) & 0xff, (color >> 8) & 0xff, (color) & 0xff);
                        graphics.FillRectangle(brush, new Rectangle(5 + column * 22, picBlocks.Height - (27 + row * 22), 22, 22));
                    }
                    else if (field[row][column] == -1)
                    {
                        graphics.DrawRectangle(ghost, new Rectangle(5 + column * 22, picBlocks.Height - (27 + row * 22), 22, 22));
                    }
                }
            }
        }

        private void RenderBankedPiece(Graphics graphics)
        {
            RenderMiniature(graphics, game.GetBankedTetrimino, 6, 10, picBankedPiece.Width);
        }

        private void RenderPreviewPieces(Graphics graphics, int pictureBox)
        {
            int[][][] preview = game.GetPreviewTetriminos;
            if (pictureBox == 0)
            {
                RenderMiniature(graphics, preview[pictureBox], 6, 10, picPreview0.Width);
            }
            else
            {
                RenderMiniature(graphics, preview[pictureBox], 4, 10, picPreview1.Width);
            }
        }

        private bool IsIOrOPiece(int[][] tetriminos)
        {
            if (tetriminos[0][2] != 0 && tetriminos[1][2] != 0 && tetriminos[2][2] != 0 && tetriminos[3][2] != 0)
            {
                return true;
            }
            if (tetriminos[1][1] != 0 && tetriminos[2][1] != 0 && tetriminos[1][2] != 0 && tetriminos[2][2] != 0)
            {
                return true;
            }

            return false;
        }

        private void RenderMiniature(Graphics graphics, int[][] positions, int border, int size, int surfaceSize)
        {
            int distance = (surfaceSize - (size * 4)) / 2;
            for (int row = 0; row < 4; row++)
            {
                for (int column = 0; column < 4; column++)
                {
                    if (positions[row][column] > 0)
                    {
                        color = positions[row][column];
                        brush.Color = Color.FromArgb((color >> 16) & 0xff, (color >> 8) & 0xff, (color) & 0xff);
                        if (IsIOrOPiece(positions))
                        {
                            graphics.FillRectangle(brush, new Rectangle(distance + row * size, distance + column * size, size, size));
                        }
                        else
                        {
                            graphics.FillRectangle(brush, new Rectangle(distance + size / 2 + row * size, distance + size / 2 + column * size, size, size));
                        }
                    }
                }
            }
        }

        private void frmTetris_KeyUp(object sender, KeyEventArgs e)
        {
            if (!pause)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        game.Rotate();
                        break;
                    case Keys.Down:
                        game.MoveDown();
                        break;
                    case Keys.Left:
                        game.MoveLeft();
                        break;
                    case Keys.Right:
                        game.MoveRight();
                        break;
                    case Keys.Space:
                        game.PlaceDown();
                        break;
                    case Keys.R:
                        if (gameIsOver)
                        {
                            game = new Game();
                            game.addObserver(this);
                            gameIsOver = false;
                            RefreshPictureBoxes();
                            tmrMove.Enabled = true;
                        }
                        break;
                    case Keys.C:
                        game.SwitchBank();
                        break;
                }
            }
            if (e.KeyCode == Keys.P)
            {
                pause = !pause;
                tmrMove.Enabled = !pause;
                //code for a menu
            }
        }

        private void tmrMove_Tick(object sender, EventArgs e)
        {
            game.MoveDown();
        }

        private void picBankedPiece_Paint(object sender, PaintEventArgs e)
        {
            RenderBankedPiece(e.Graphics);
        }

        private void picPreview_Paint(object sender, PaintEventArgs e)
        {
            String name = ((PictureBox)sender).Name;
            int nummer = int.Parse(name.Substring(name.Length - 1));

            RenderPreviewPieces(e.Graphics, nummer);
        }

        private void RefreshPictureBoxes()
        {
            picBlocks.Refresh();
            picBankedPiece.Refresh();
            picPreview0.Refresh();
            picPreview1.Refresh();
            picPreview2.Refresh();
            picPreview3.Refresh();
            picPreview4.Refresh();
        }
    }
}
