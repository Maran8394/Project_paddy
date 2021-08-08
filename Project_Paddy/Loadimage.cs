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
    public partial class Loadimage : Form
    {
        public Loadimage()
        {
            InitializeComponent();
        }


        public string name, ff;

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.ShowDialog();
            if (op.FileName == "")
            {
                MessageBox.Show("Please Choose  Image");
            }
            else
            {
                pictureBox1.Image = new Bitmap(op.FileName);
                name = op.FileName;
                ff = System.IO.Path.GetFileName(op.FileName);

            }
        }


        public Bitmap pubmp;
        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please Choose  Image");
            }
            else
            {
                Preprocessing p = new Preprocessing();
                p.bmp = new Bitmap(pictureBox1.Image);
                p.original = name;
                p.ff = ff;
                p.Show();

                pubmp = new Bitmap(pictureBox1.Image);
            }
        }

        private void Loadimage_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


         //   string Binary1 = System.IO.Path.GetDirectoryName(Application.ExecutablePath.ToString()) + "\\Binary\\";



         //   Random rr = new Random();
         //   int i = rr.Next(11, 9999);

         //string     binimg = i + ".jpg";


         //   binimg = Binary1 + binimg;


         //   output.Save(binimg, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}
