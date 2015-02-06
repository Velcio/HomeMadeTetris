namespace Tetris
{
    partial class frmTetris
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTetris));
            this.picBlocks = new System.Windows.Forms.PictureBox();
            this.tmrMove = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.picBankedPiece = new System.Windows.Forms.PictureBox();
            this.lblPreview = new System.Windows.Forms.Label();
            this.picPreview0 = new System.Windows.Forms.PictureBox();
            this.picPreview1 = new System.Windows.Forms.PictureBox();
            this.picPreview2 = new System.Windows.Forms.PictureBox();
            this.picPreview3 = new System.Windows.Forms.PictureBox();
            this.picPreview4 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblLines = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBlocks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBankedPiece)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview4)).BeginInit();
            this.SuspendLayout();
            // 
            // picBlocks
            // 
            this.picBlocks.BackColor = System.Drawing.Color.Black;
            this.picBlocks.Location = new System.Drawing.Point(93, 0);
            this.picBlocks.Name = "picBlocks";
            this.picBlocks.Size = new System.Drawing.Size(230, 450);
            this.picBlocks.TabIndex = 0;
            this.picBlocks.TabStop = false;
            this.picBlocks.Paint += new System.Windows.Forms.PaintEventHandler(this.picBlocks_Paint);
            // 
            // tmrMove
            // 
            this.tmrMove.Enabled = true;
            this.tmrMove.Interval = 1000;
            this.tmrMove.Tick += new System.EventHandler(this.tmrMove_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Banked piece:";
            // 
            // picBankedPiece
            // 
            this.picBankedPiece.BackgroundImage = global::Tetris.Properties.Resources.border;
            this.picBankedPiece.Location = new System.Drawing.Point(12, 25);
            this.picBankedPiece.Name = "picBankedPiece";
            this.picBankedPiece.Size = new System.Drawing.Size(76, 76);
            this.picBankedPiece.TabIndex = 2;
            this.picBankedPiece.TabStop = false;
            this.picBankedPiece.Paint += new System.Windows.Forms.PaintEventHandler(this.picBankedPiece_Paint);
            // 
            // lblPreview
            // 
            this.lblPreview.AutoSize = true;
            this.lblPreview.Location = new System.Drawing.Point(329, 9);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(48, 13);
            this.lblPreview.TabIndex = 3;
            this.lblPreview.Text = "Preview:";
            // 
            // picPreview0
            // 
            this.picPreview0.BackgroundImage = global::Tetris.Properties.Resources.border;
            this.picPreview0.Location = new System.Drawing.Point(332, 25);
            this.picPreview0.Name = "picPreview0";
            this.picPreview0.Size = new System.Drawing.Size(76, 76);
            this.picPreview0.TabIndex = 4;
            this.picPreview0.TabStop = false;
            this.picPreview0.Paint += new System.Windows.Forms.PaintEventHandler(this.picPreview_Paint);
            // 
            // picPreview1
            // 
            this.picPreview1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picPreview1.BackgroundImage")));
            this.picPreview1.Location = new System.Drawing.Point(345, 107);
            this.picPreview1.Name = "picPreview1";
            this.picPreview1.Size = new System.Drawing.Size(50, 50);
            this.picPreview1.TabIndex = 5;
            this.picPreview1.TabStop = false;
            this.picPreview1.Paint += new System.Windows.Forms.PaintEventHandler(this.picPreview_Paint);
            // 
            // picPreview2
            // 
            this.picPreview2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picPreview2.BackgroundImage")));
            this.picPreview2.Location = new System.Drawing.Point(345, 163);
            this.picPreview2.Name = "picPreview2";
            this.picPreview2.Size = new System.Drawing.Size(50, 50);
            this.picPreview2.TabIndex = 6;
            this.picPreview2.TabStop = false;
            this.picPreview2.Paint += new System.Windows.Forms.PaintEventHandler(this.picPreview_Paint);
            // 
            // picPreview3
            // 
            this.picPreview3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picPreview3.BackgroundImage")));
            this.picPreview3.Location = new System.Drawing.Point(345, 219);
            this.picPreview3.Name = "picPreview3";
            this.picPreview3.Size = new System.Drawing.Size(50, 50);
            this.picPreview3.TabIndex = 7;
            this.picPreview3.TabStop = false;
            this.picPreview3.Paint += new System.Windows.Forms.PaintEventHandler(this.picPreview_Paint);
            // 
            // picPreview4
            // 
            this.picPreview4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picPreview4.BackgroundImage")));
            this.picPreview4.Location = new System.Drawing.Point(345, 275);
            this.picPreview4.Name = "picPreview4";
            this.picPreview4.Size = new System.Drawing.Size(50, 50);
            this.picPreview4.TabIndex = 8;
            this.picPreview4.TabStop = false;
            this.picPreview4.Paint += new System.Windows.Forms.PaintEventHandler(this.picPreview_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(329, 338);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Score:";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(377, 338);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(0, 13);
            this.lblScore.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(329, 360);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Level:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(329, 382);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Lines:";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(377, 360);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(0, 13);
            this.lblLevel.TabIndex = 13;
            // 
            // lblLines
            // 
            this.lblLines.AutoSize = true;
            this.lblLines.Location = new System.Drawing.Point(377, 382);
            this.lblLines.Name = "lblLines";
            this.lblLines.Size = new System.Drawing.Size(0, 13);
            this.lblLines.TabIndex = 14;
            // 
            // frmTetris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(424, 450);
            this.Controls.Add(this.lblLines);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picPreview4);
            this.Controls.Add(this.picPreview3);
            this.Controls.Add(this.picPreview2);
            this.Controls.Add(this.picPreview1);
            this.Controls.Add(this.picPreview0);
            this.Controls.Add(this.lblPreview);
            this.Controls.Add(this.picBankedPiece);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picBlocks);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTetris";
            this.Text = "Tetris";
            this.Load += new System.EventHandler(this.frmTetris_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmTetris_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.picBlocks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBankedPiece)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBlocks;
        private System.Windows.Forms.Timer tmrMove;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picBankedPiece;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.PictureBox picPreview0;
        private System.Windows.Forms.PictureBox picPreview1;
        private System.Windows.Forms.PictureBox picPreview2;
        private System.Windows.Forms.PictureBox picPreview3;
        private System.Windows.Forms.PictureBox picPreview4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblLines;
    }
}

