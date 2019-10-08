namespace Deluxe_Blackjack
{
    partial class betScreenGUI
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bankTotal = new System.Windows.Forms.Label();
            this.dealBtn = new System.Windows.Forms.Button();
            this.walkAwayBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.PaleGreen;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(427, 248);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(159, 33);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(258, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bet amount:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Deluxe_Blackjack.Properties.Resources.Chip_Stack;
            this.pictureBox1.Location = new System.Drawing.Point(348, 388);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // bankTotal
            // 
            this.bankTotal.AutoSize = true;
            this.bankTotal.BackColor = System.Drawing.Color.Transparent;
            this.bankTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bankTotal.Location = new System.Drawing.Point(414, 406);
            this.bankTotal.Name = "bankTotal";
            this.bankTotal.Size = new System.Drawing.Size(95, 20);
            this.bankTotal.TabIndex = 3;
            this.bankTotal.Text = "Bank - $100";
            this.bankTotal.Click += new System.EventHandler(this.label2_Click);
            // 
            // dealBtn
            // 
            this.dealBtn.BackColor = System.Drawing.Color.DarkGreen;
            this.dealBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.dealBtn.FlatAppearance.BorderSize = 3;
            this.dealBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dealBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dealBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.dealBtn.Location = new System.Drawing.Point(550, 350);
            this.dealBtn.Name = "dealBtn";
            this.dealBtn.Size = new System.Drawing.Size(113, 36);
            this.dealBtn.TabIndex = 4;
            this.dealBtn.Text = "Deal";
            this.dealBtn.UseVisualStyleBackColor = false;
            this.dealBtn.Click += new System.EventHandler(this.newGameBtn_Click);
            // 
            // walkAwayBtn
            // 
            this.walkAwayBtn.BackColor = System.Drawing.Color.DarkGreen;
            this.walkAwayBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.walkAwayBtn.FlatAppearance.BorderSize = 3;
            this.walkAwayBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.walkAwayBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.walkAwayBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.walkAwayBtn.Location = new System.Drawing.Point(675, 350);
            this.walkAwayBtn.Name = "walkAwayBtn";
            this.walkAwayBtn.Size = new System.Drawing.Size(113, 36);
            this.walkAwayBtn.TabIndex = 5;
            this.walkAwayBtn.Text = "Walk Away";
            this.walkAwayBtn.UseVisualStyleBackColor = false;
            this.walkAwayBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // betScreenGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Deluxe_Blackjack.Properties.Resources.Felt_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.walkAwayBtn);
            this.Controls.Add(this.dealBtn);
            this.Controls.Add(this.bankTotal);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "betScreenGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deluxe Blackjack";
            this.Load += new System.EventHandler(this.betScreenGUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button dealBtn;
        private System.Windows.Forms.Button walkAwayBtn;
        public System.Windows.Forms.Label bankTotal;
    }
}