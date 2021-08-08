namespace PaddyCropDetection
{
    partial class Colorfeature
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
            this.label1 = new System.Windows.Forms.Label();
            this.histogram2 = new IPLab.Histogram();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.histogram3 = new IPLab.Histogram();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.histogram1 = new IPLab.Histogram();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(260, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 28);
            this.label1.TabIndex = 20;
            this.label1.Text = "Color Histogram";
            // 
            // histogram2
            // 
            this.histogram2.AllowDrop = true;
            this.histogram2.AllowSelection = true;
            this.histogram2.BackColor = System.Drawing.Color.White;
            this.histogram2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.histogram2.Location = new System.Drawing.Point(7, 30);
            this.histogram2.LogView = true;
            this.histogram2.Name = "histogram2";
            this.histogram2.Size = new System.Drawing.Size(326, 191);
            this.histogram2.TabIndex = 32;
            this.histogram2.Text = "histogram2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(488, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Histogram Of Blue Plane";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(100, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Histogram Of green Plane";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.histogram3);
            this.panel5.Location = new System.Drawing.Point(352, 317);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(334, 233);
            this.panel5.TabIndex = 3;
            // 
            // histogram3
            // 
            this.histogram3.AllowDrop = true;
            this.histogram3.AllowSelection = true;
            this.histogram3.BackColor = System.Drawing.Color.White;
            this.histogram3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.histogram3.Location = new System.Drawing.Point(3, 30);
            this.histogram3.LogView = true;
            this.histogram3.Name = "histogram3";
            this.histogram3.Size = new System.Drawing.Size(326, 191);
            this.histogram3.TabIndex = 32;
            this.histogram3.Text = "histogram3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Original Color Image";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(123, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Histogram Of Red Plane";
            // 
            // histogram1
            // 
            this.histogram1.AllowDrop = true;
            this.histogram1.AllowSelection = true;
            this.histogram1.BackColor = System.Drawing.Color.White;
            this.histogram1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.histogram1.Location = new System.Drawing.Point(3, 30);
            this.histogram1.LogView = true;
            this.histogram1.Name = "histogram1";
            this.histogram1.Size = new System.Drawing.Size(326, 191);
            this.histogram1.TabIndex = 32;
            this.histogram1.Text = "histogram1";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.histogram2);
            this.panel1.Location = new System.Drawing.Point(352, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 271);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(26, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(703, 565);
            this.panel2.TabIndex = 21;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.histogram1);
            this.panel4.Location = new System.Drawing.Point(15, 317);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(334, 233);
            this.panel4.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Location = new System.Drawing.Point(15, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(331, 271);
            this.panel3.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(14, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(291, 214);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Colorfeature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 607);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Name = "Colorfeature";
            this.Text = "Colorfeature";
            this.Load += new System.EventHandler(this.Colorfeature_Load);
            this.panel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private IPLab.Histogram histogram2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private IPLab.Histogram histogram3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private IPLab.Histogram histogram1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}