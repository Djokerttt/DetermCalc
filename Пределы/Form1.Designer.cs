namespace Пределы
{
    partial class LimCalc
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LimCalc));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.equals_button = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.numeratorInput = new System.Windows.Forms.TextBox();
            this.denominatorInput = new System.Windows.Forms.TextBox();
            this.answerBox = new System.Windows.Forms.TextBox();
            this.solvingStepsBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equals_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(20, 20);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(260, 80);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.WaitOnLoad = true;
            // 
            // equals_button
            // 
            this.equals_button.Image = ((System.Drawing.Image)(resources.GetObject("equals_button.Image")));
            this.equals_button.Location = new System.Drawing.Point(300, 20);
            this.equals_button.Margin = new System.Windows.Forms.Padding(0);
            this.equals_button.Name = "equals_button";
            this.equals_button.Size = new System.Drawing.Size(80, 80);
            this.equals_button.TabIndex = 2;
            this.equals_button.TabStop = false;
            this.equals_button.WaitOnLoad = true;
            this.equals_button.Click += new System.EventHandler(this.equals_button_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Enabled = false;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(20, 120);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(360, 80);
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.WaitOnLoad = true;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Enabled = false;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(20, 220);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(360, 360);
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.WaitOnLoad = true;
            // 
            // numeratorInput
            // 
            this.numeratorInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(76)))), ((int)(((byte)(94)))));
            this.numeratorInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numeratorInput.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numeratorInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(244)))));
            this.numeratorInput.Location = new System.Drawing.Point(115, 29);
            this.numeratorInput.Margin = new System.Windows.Forms.Padding(0);
            this.numeratorInput.MaximumSize = new System.Drawing.Size(155, 20);
            this.numeratorInput.MaxLength = 16;
            this.numeratorInput.MinimumSize = new System.Drawing.Size(155, 20);
            this.numeratorInput.Name = "numeratorInput";
            this.numeratorInput.Size = new System.Drawing.Size(155, 19);
            this.numeratorInput.TabIndex = 5;
            this.numeratorInput.Text = "2x^2-3x-5";
            this.numeratorInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numeratorInput.WordWrap = false;
            // 
            // denominatorInput
            // 
            this.denominatorInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(76)))), ((int)(((byte)(94)))));
            this.denominatorInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.denominatorInput.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.denominatorInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(244)))));
            this.denominatorInput.Location = new System.Drawing.Point(115, 68);
            this.denominatorInput.Margin = new System.Windows.Forms.Padding(0);
            this.denominatorInput.MaximumSize = new System.Drawing.Size(155, 20);
            this.denominatorInput.MaxLength = 16;
            this.denominatorInput.MinimumSize = new System.Drawing.Size(155, 20);
            this.denominatorInput.Name = "denominatorInput";
            this.denominatorInput.Size = new System.Drawing.Size(155, 19);
            this.denominatorInput.TabIndex = 6;
            this.denominatorInput.Text = "1+x+3x^2";
            this.denominatorInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.denominatorInput.WordWrap = false;
            // 
            // answerBox
            // 
            this.answerBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.answerBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.answerBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(244)))));
            this.answerBox.Location = new System.Drawing.Point(25, 125);
            this.answerBox.Multiline = true;
            this.answerBox.Name = "answerBox";
            this.answerBox.ReadOnly = true;
            this.answerBox.Size = new System.Drawing.Size(350, 70);
            this.answerBox.TabIndex = 7;
            this.answerBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // solvingStepsBox
            // 
            this.solvingStepsBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.solvingStepsBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.solvingStepsBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(244)))));
            this.solvingStepsBox.Location = new System.Drawing.Point(25, 225);
            this.solvingStepsBox.Multiline = true;
            this.solvingStepsBox.Name = "solvingStepsBox";
            this.solvingStepsBox.ReadOnly = true;
            this.solvingStepsBox.Size = new System.Drawing.Size(350, 350);
            this.solvingStepsBox.TabIndex = 8;
            // 
            // LimCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(400, 599);
            this.Controls.Add(this.solvingStepsBox);
            this.Controls.Add(this.answerBox);
            this.Controls.Add(this.denominatorInput);
            this.Controls.Add(this.numeratorInput);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.equals_button);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(244)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(416, 638);
            this.MinimumSize = new System.Drawing.Size(416, 638);
            this.Name = "LimCalc";
            this.ShowIcon = false;
            this.Text = "LimCalc";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equals_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox equals_button;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.TextBox numeratorInput;
        private System.Windows.Forms.TextBox denominatorInput;
        private System.Windows.Forms.TextBox answerBox;
        private System.Windows.Forms.TextBox solvingStepsBox;
    }
}

