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
    public partial class DetectionImage : Form
    {
        public DetectionImage()
        {
            InitializeComponent();
        }


        public Bitmap bmp;


        public int cou;

        private void DetectionImage_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = bmp;


           


            if (cou > 1500)
            {
                label3.Text = "urea";

                MessageBox.Show("urea");
            }
            else if (cou > 1300)
            {
                label3.Text = "AmmoniumChloride";
                MessageBox.Show("urea");
            }

            if (cou < 100)
            {
                label3.Text = "No Fertilizer Needed! ";

                MessageBox.Show("No Fertilizer Needed!");

            }
           
        }
    }
}
