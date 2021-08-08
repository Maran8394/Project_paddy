using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Imaging.Filters;
using PaddyCropDetection;

namespace PaddyCropDetection
{
    public partial class Preprocessing : Form
    {
        public string name, ff,original;
        public Bitmap bmp;

        private System.Drawing.Bitmap m_Bitmap;
        private System.Drawing.Bitmap m_Bitmap1;
        private System.Drawing.Bitmap m_Bitmap2;
        private System.Drawing.Bitmap m_Bitmap3;
        private System.Drawing.Bitmap m_Undo;
        

        public Preprocessing()
        {
            InitializeComponent();
        }

        private void Preprocessing_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Bitmap.FromFile(original);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            m_Bitmap = (Bitmap)Bitmap.FromFile(original, false);
            m_Bitmap1 = (Bitmap)Bitmap.FromFile(original, false);
            m_Bitmap2 = (Bitmap)Bitmap.FromFile(original, false);
            m_Bitmap3 = (Bitmap)Bitmap.FromFile(original, false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_Undo = (Bitmap)m_Bitmap.Clone();
            if (BitmapFilter.GrayScale(m_Bitmap))
                pictureBox1.Image = m_Bitmap;
        }

        private void button3_Click(object sender, EventArgs e)
        {
           Bitmap grayImage;
           Bitmap bmp = new Bitmap(pictureBox1.Image);

          

        


            AForge.Imaging.Filters.Median filter = new Median();
            Bitmap newImage = filter.Apply(bmp);
          //  pbChoose.SizeMode = PictureBoxSizeMode.CenterImage;
          //  pBNew.Image = newImage;

            pictureBox1.Image = bmp;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FeatureExtract fe = new FeatureExtract();
            fe.orginal = original;
            fe.ff = ff;
            fe.Show();

            
        }
    }
}
