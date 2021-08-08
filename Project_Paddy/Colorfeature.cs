using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PaddyCropDetection
{
    public partial class Colorfeature : Form
    {
        public Colorfeature()
        {
            InitializeComponent();
        }
        public Bitmap bmp;
        public Bitmap bmp1;
        public string klm;
        public Bitmap bmmp;
        public string imagename;

        private void Colorfeature_Load(object sender, EventArgs e)
        {

            bmp = new Bitmap(imagename);
            bmp1 = new Bitmap(imagename);

            klm = "Histogram";

            pictureBox1.Image = bmp;

            AForge.Math.Histogram activeHistogram = null;
            AForge.Imaging.ImageStatistics stat =
           new AForge.Imaging.ImageStatistics(bmp);
            if (stat != null)
            {
                //Do if the pic is gray
                if (stat.IsGrayscale)
                {
                    activeHistogram = stat.Red;
                }
                //Do if the pic is colourful
                if (!stat.IsGrayscale)
                {
                    activeHistogram = stat.Red;
                }
            }

            kk();
            kk1();
            kk2();
        }

        public void kk()
        {
            AForge.Math.Histogram activeHistogram = null;
            AForge.Imaging.ImageStatistics stat =
           new AForge.Imaging.ImageStatistics(bmp1);
            if (stat != null)
            {
                //Do if the pic is gray
                if (stat.IsGrayscale)
                {
                    activeHistogram = stat.Red;
                }
                //Do if the pic is colourful
                if (!stat.IsGrayscale)
                {
                    activeHistogram = stat.Red;
                }


            }
            histogram2.Values = activeHistogram.Values;
            histogram2.Color = System.Drawing.Color.Red;
            //oo.Dispose();
            histogram2.Refresh();
        }

        public void kk1()
        {
            AForge.Math.Histogram activeHistogram = null;
            AForge.Imaging.ImageStatistics stat =
           new AForge.Imaging.ImageStatistics(bmp1);
            if (stat != null)
            {
                //Do if the pic is gray
                if (stat.IsGrayscale)
                {
                    activeHistogram = stat.Green;
                }
                //Do if the pic is colourful
                if (!stat.IsGrayscale)
                {
                    activeHistogram = stat.Green;
                }


            }
            histogram1.Values = activeHistogram.Values;
            histogram1.Color = System.Drawing.Color.Green;
            //oo.Dispose();
            histogram1.Refresh();
        }

        public void kk2()
        {
            AForge.Math.Histogram activeHistogram = null;
            AForge.Imaging.ImageStatistics stat =
           new AForge.Imaging.ImageStatistics(bmp1);
            if (stat != null)
            {
                //Do if the pic is gray
                if (stat.IsGrayscale)
                {
                    activeHistogram = stat.Blue;
                }
                //Do if the pic is colourful
                if (!stat.IsGrayscale)
                {
                    activeHistogram = stat.Blue;
                }


            }
            histogram3.Values = activeHistogram.Values;
            histogram3.Color = System.Drawing.Color.Blue;
            //oo.Dispose();
            histogram3.Refresh();
        }
    }
}
