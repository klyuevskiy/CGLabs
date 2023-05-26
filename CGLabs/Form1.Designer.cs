namespace Lab1
{
    partial class Form1
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
            this.contrastTrackBar = new System.Windows.Forms.TrackBar();
            this.BrightTrackBar = new System.Windows.Forms.TrackBar();
            this.satuTrackBar = new System.Windows.Forms.TrackBar();
            this.changeBrightButton = new System.Windows.Forms.Button();
            this.changeContButton = new System.Windows.Forms.Button();
            this.changeSatuButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.contrastTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrightTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.satuTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // contrastTrackBar
            // 
            this.contrastTrackBar.Location = new System.Drawing.Point(616, 12);
            this.contrastTrackBar.Maximum = 100;
            this.contrastTrackBar.Minimum = -100;
            this.contrastTrackBar.Name = "contrastTrackBar";
            this.contrastTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.contrastTrackBar.Size = new System.Drawing.Size(45, 318);
            this.contrastTrackBar.TabIndex = 1;
            // 
            // BrightTrackBar
            // 
            this.BrightTrackBar.Location = new System.Drawing.Point(713, 12);
            this.BrightTrackBar.Maximum = 255;
            this.BrightTrackBar.Minimum = -255;
            this.BrightTrackBar.Name = "BrightTrackBar";
            this.BrightTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.BrightTrackBar.Size = new System.Drawing.Size(45, 318);
            this.BrightTrackBar.TabIndex = 2;
            // 
            // satuTrackBar
            // 
            this.satuTrackBar.Location = new System.Drawing.Point(820, 12);
            this.satuTrackBar.Maximum = 100;
            this.satuTrackBar.Minimum = -100;
            this.satuTrackBar.Name = "satuTrackBar";
            this.satuTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.satuTrackBar.Size = new System.Drawing.Size(45, 318);
            this.satuTrackBar.TabIndex = 3;
            // 
            // changeBrightButton
            // 
            this.changeBrightButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.changeBrightButton.Location = new System.Drawing.Point(601, 404);
            this.changeBrightButton.Name = "changeBrightButton";
            this.changeBrightButton.Size = new System.Drawing.Size(121, 48);
            this.changeBrightButton.TabIndex = 4;
            this.changeBrightButton.Text = "Поменять яркость";
            this.changeBrightButton.UseVisualStyleBackColor = true;
            this.changeBrightButton.Click += new System.EventHandler(this.changeBrightButton_Click);
            // 
            // changeContButton
            // 
            this.changeContButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.changeContButton.Location = new System.Drawing.Point(728, 404);
            this.changeContButton.Name = "changeContButton";
            this.changeContButton.Size = new System.Drawing.Size(137, 48);
            this.changeContButton.TabIndex = 5;
            this.changeContButton.Text = "Поменять контрастность";
            this.changeContButton.UseVisualStyleBackColor = true;
            this.changeContButton.Click += new System.EventHandler(this.changeContButton_Click);
            // 
            // changeSatuButton
            // 
            this.changeSatuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.changeSatuButton.Location = new System.Drawing.Point(871, 404);
            this.changeSatuButton.Name = "changeSatuButton";
            this.changeSatuButton.Size = new System.Drawing.Size(137, 48);
            this.changeSatuButton.TabIndex = 6;
            this.changeSatuButton.Text = "Поменять насыщенность";
            this.changeSatuButton.UseVisualStyleBackColor = true;
            this.changeSatuButton.Click += new System.EventHandler(this.changeSatuButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(612, 343);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Контраст";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(709, 343);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Яркость";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(801, 343);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Насыщенность";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(467, 454);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button1.Location = new System.Drawing.Point(601, 458);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 48);
            this.button1.TabIndex = 11;
            this.button1.Text = "Сбросить изображение";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 515);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.changeSatuButton);
            this.Controls.Add(this.changeContButton);
            this.Controls.Add(this.changeBrightButton);
            this.Controls.Add(this.satuTrackBar);
            this.Controls.Add(this.BrightTrackBar);
            this.Controls.Add(this.contrastTrackBar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.contrastTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrightTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.satuTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TrackBar contrastTrackBar;
        private System.Windows.Forms.TrackBar BrightTrackBar;
        private System.Windows.Forms.TrackBar satuTrackBar;
        private System.Windows.Forms.Button changeBrightButton;
        private System.Windows.Forms.Button changeContButton;
        private System.Windows.Forms.Button changeSatuButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
    }
}

