namespace Deluxe_Blackjack
{
    partial class mainMenuGUI
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
            this.newGameBtn = new System.Windows.Forms.Button();
            this.highScoresBtn = new System.Windows.Forms.Button();
            this.rulesBtn = new System.Windows.Forms.Button();
            this.quitBtn = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // newGameBtn
            // 
            this.newGameBtn.BackColor = System.Drawing.Color.DarkGreen;
            this.newGameBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.newGameBtn.FlatAppearance.BorderSize = 3;
            this.newGameBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newGameBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newGameBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.newGameBtn.Location = new System.Drawing.Point(316, 196);
            this.newGameBtn.Name = "newGameBtn";
            this.newGameBtn.Size = new System.Drawing.Size(162, 47);
            this.newGameBtn.TabIndex = 0;
            this.newGameBtn.Text = "New Game";
            this.newGameBtn.UseVisualStyleBackColor = false;
            this.newGameBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // highScoresBtn
            // 
            this.highScoresBtn.BackColor = System.Drawing.Color.DarkGreen;
            this.highScoresBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.highScoresBtn.FlatAppearance.BorderSize = 3;
            this.highScoresBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.highScoresBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highScoresBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.highScoresBtn.Location = new System.Drawing.Point(316, 249);
            this.highScoresBtn.Name = "highScoresBtn";
            this.highScoresBtn.Size = new System.Drawing.Size(162, 47);
            this.highScoresBtn.TabIndex = 1;
            this.highScoresBtn.Text = "High Scores";
            this.highScoresBtn.UseVisualStyleBackColor = false;
            this.highScoresBtn.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // rulesBtn
            // 
            this.rulesBtn.BackColor = System.Drawing.Color.DarkGreen;
            this.rulesBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rulesBtn.FlatAppearance.BorderSize = 3;
            this.rulesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rulesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rulesBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rulesBtn.Location = new System.Drawing.Point(316, 302);
            this.rulesBtn.Name = "rulesBtn";
            this.rulesBtn.Size = new System.Drawing.Size(162, 47);
            this.rulesBtn.TabIndex = 2;
            this.rulesBtn.Text = "Rules";
            this.rulesBtn.UseVisualStyleBackColor = false;
            this.rulesBtn.Click += new System.EventHandler(this.rulesBtn_Click);
            // 
            // quitBtn
            // 
            this.quitBtn.BackColor = System.Drawing.Color.DarkGreen;
            this.quitBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.quitBtn.FlatAppearance.BorderSize = 3;
            this.quitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.quitBtn.Location = new System.Drawing.Point(316, 355);
            this.quitBtn.Name = "quitBtn";
            this.quitBtn.Size = new System.Drawing.Size(162, 47);
            this.quitBtn.TabIndex = 3;
            this.quitBtn.Text = "Quit";
            this.quitBtn.UseVisualStyleBackColor = false;
            this.quitBtn.Click += new System.EventHandler(this.quitBtn_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Green;
            this.titleLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titleLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.titleLabel.Font = new System.Drawing.Font("Lucida Calligraphy", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(288, 63);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(240, 54);
            this.titleLabel.TabIndex = 4;
            this.titleLabel.Text = "Blackjack";
            this.titleLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // mainMenuGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Deluxe_Blackjack.Properties.Resources.Felt_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.quitBtn);
            this.Controls.Add(this.rulesBtn);
            this.Controls.Add(this.highScoresBtn);
            this.Controls.Add(this.newGameBtn);
            this.Name = "mainMenuGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deluxe Blackjack - Main Menu";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button newGameBtn;
        private System.Windows.Forms.Button highScoresBtn;
        private System.Windows.Forms.Button rulesBtn;
        private System.Windows.Forms.Button quitBtn;
        private System.Windows.Forms.Label titleLabel;
    }
}

