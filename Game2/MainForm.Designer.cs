namespace Game2
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.GamePbx = new System.Windows.Forms.PictureBox();
            this.DifficultyGbx = new System.Windows.Forms.GroupBox();
            this.VeryFastRbt = new System.Windows.Forms.RadioButton();
            this.FastRbt = new System.Windows.Forms.RadioButton();
            this.SimpleRbt = new System.Windows.Forms.RadioButton();
            this.StyleGbx = new System.Windows.Forms.GroupBox();
            this.ArrRbt = new System.Windows.Forms.RadioButton();
            this.RectRbt = new System.Windows.Forms.RadioButton();
            this.CircleRbt = new System.Windows.Forms.RadioButton();
            this.QuitBtn = new System.Windows.Forms.Button();
            this.StartBtn = new System.Windows.Forms.Button();
            this.BotTimer = new System.Windows.Forms.Timer(this.components);
            this.PlayerTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GamePbx)).BeginInit();
            this.DifficultyGbx.SuspendLayout();
            this.StyleGbx.SuspendLayout();
            this.SuspendLayout();
            // 
            // GamePbx
            // 
            this.GamePbx.Location = new System.Drawing.Point(12, 12);
            this.GamePbx.Name = "GamePbx";
            this.GamePbx.Size = new System.Drawing.Size(252, 252);
            this.GamePbx.TabIndex = 0;
            this.GamePbx.TabStop = false;
            this.GamePbx.Click += new System.EventHandler(this.GamePbx_Click);
            // 
            // DifficultyGbx
            // 
            this.DifficultyGbx.Controls.Add(this.VeryFastRbt);
            this.DifficultyGbx.Controls.Add(this.FastRbt);
            this.DifficultyGbx.Controls.Add(this.SimpleRbt);
            this.DifficultyGbx.Location = new System.Drawing.Point(270, 12);
            this.DifficultyGbx.Name = "DifficultyGbx";
            this.DifficultyGbx.Size = new System.Drawing.Size(99, 100);
            this.DifficultyGbx.TabIndex = 1;
            this.DifficultyGbx.TabStop = false;
            this.DifficultyGbx.Text = "Difficulté";
            // 
            // VeryFastRbt
            // 
            this.VeryFastRbt.AutoSize = true;
            this.VeryFastRbt.Location = new System.Drawing.Point(6, 72);
            this.VeryFastRbt.Name = "VeryFastRbt";
            this.VeryFastRbt.Size = new System.Drawing.Size(84, 19);
            this.VeryFastRbt.TabIndex = 2;
            this.VeryFastRbt.TabStop = true;
            this.VeryFastRbt.Text = "Très Rapide";
            this.VeryFastRbt.UseVisualStyleBackColor = true;
            this.VeryFastRbt.Click += new System.EventHandler(this.Difficulty_Checked);
            // 
            // FastRbt
            // 
            this.FastRbt.AutoSize = true;
            this.FastRbt.Location = new System.Drawing.Point(6, 47);
            this.FastRbt.Name = "FastRbt";
            this.FastRbt.Size = new System.Drawing.Size(61, 19);
            this.FastRbt.TabIndex = 1;
            this.FastRbt.TabStop = true;
            this.FastRbt.Text = "Rapide";
            this.FastRbt.UseVisualStyleBackColor = true;
            this.FastRbt.Click += new System.EventHandler(this.Difficulty_Checked);
            // 
            // SimpleRbt
            // 
            this.SimpleRbt.AutoSize = true;
            this.SimpleRbt.Location = new System.Drawing.Point(6, 22);
            this.SimpleRbt.Name = "SimpleRbt";
            this.SimpleRbt.Size = new System.Drawing.Size(61, 19);
            this.SimpleRbt.TabIndex = 0;
            this.SimpleRbt.TabStop = true;
            this.SimpleRbt.Text = "Simple";
            this.SimpleRbt.UseVisualStyleBackColor = true;
            this.SimpleRbt.Click += new System.EventHandler(this.Difficulty_Checked);
            // 
            // StyleGbx
            // 
            this.StyleGbx.Controls.Add(this.ArrRbt);
            this.StyleGbx.Controls.Add(this.RectRbt);
            this.StyleGbx.Controls.Add(this.CircleRbt);
            this.StyleGbx.Location = new System.Drawing.Point(270, 164);
            this.StyleGbx.Name = "StyleGbx";
            this.StyleGbx.Size = new System.Drawing.Size(99, 100);
            this.StyleGbx.TabIndex = 3;
            this.StyleGbx.TabStop = false;
            this.StyleGbx.Text = "Style";
            // 
            // ArrRbt
            // 
            this.ArrRbt.AutoSize = true;
            this.ArrRbt.Location = new System.Drawing.Point(6, 72);
            this.ArrRbt.Name = "ArrRbt";
            this.ArrRbt.Size = new System.Drawing.Size(65, 19);
            this.ArrRbt.TabIndex = 2;
            this.ArrRbt.TabStop = true;
            this.ArrRbt.Text = "Arrondi";
            this.ArrRbt.UseVisualStyleBackColor = true;
            this.ArrRbt.Click += new System.EventHandler(this.Style_Checked);
            // 
            // RectRbt
            // 
            this.RectRbt.AutoSize = true;
            this.RectRbt.Location = new System.Drawing.Point(6, 47);
            this.RectRbt.Name = "RectRbt";
            this.RectRbt.Size = new System.Drawing.Size(82, 19);
            this.RectRbt.TabIndex = 1;
            this.RectRbt.TabStop = true;
            this.RectRbt.Text = "Rectangles";
            this.RectRbt.UseVisualStyleBackColor = true;
            this.RectRbt.Click += new System.EventHandler(this.Style_Checked);
            // 
            // CircleRbt
            // 
            this.CircleRbt.AutoSize = true;
            this.CircleRbt.Location = new System.Drawing.Point(6, 22);
            this.CircleRbt.Name = "CircleRbt";
            this.CircleRbt.Size = new System.Drawing.Size(58, 19);
            this.CircleRbt.TabIndex = 0;
            this.CircleRbt.TabStop = true;
            this.CircleRbt.Text = "Ronds";
            this.CircleRbt.UseVisualStyleBackColor = true;
            this.CircleRbt.Click += new System.EventHandler(this.Style_Checked);
            // 
            // QuitBtn
            // 
            this.QuitBtn.Location = new System.Drawing.Point(12, 270);
            this.QuitBtn.Name = "QuitBtn";
            this.QuitBtn.Size = new System.Drawing.Size(124, 30);
            this.QuitBtn.TabIndex = 4;
            this.QuitBtn.Text = "Quitter";
            this.QuitBtn.UseVisualStyleBackColor = true;
            this.QuitBtn.Click += new System.EventHandler(this.QuitBtn_Click);
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(140, 270);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(124, 30);
            this.StartBtn.TabIndex = 5;
            this.StartBtn.Text = "Commencer";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // BotTimer
            // 
            this.BotTimer.Tick += new System.EventHandler(this.BotTimer_Tick);
            // 
            // PlayerTimer
            // 
            this.PlayerTimer.Interval = 200;
            this.PlayerTimer.Tick += new System.EventHandler(this.PlayerTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 310);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.QuitBtn);
            this.Controls.Add(this.StyleGbx);
            this.Controls.Add(this.DifficultyGbx);
            this.Controls.Add(this.GamePbx);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Jeu des lumières";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GamePbx)).EndInit();
            this.DifficultyGbx.ResumeLayout(false);
            this.DifficultyGbx.PerformLayout();
            this.StyleGbx.ResumeLayout(false);
            this.StyleGbx.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox GamePbx;
        private GroupBox DifficultyGbx;
        private RadioButton VeryFastRbt;
        private RadioButton FastRbt;
        private RadioButton SimpleRbt;
        private GroupBox StyleGbx;
        private RadioButton ArrRbt;
        private RadioButton RectRbt;
        private RadioButton CircleRbt;
        private Button QuitBtn;
        private Button StartBtn;
        private System.Windows.Forms.Timer BotTimer;
        private System.Windows.Forms.Timer PlayerTimer;
    }
}