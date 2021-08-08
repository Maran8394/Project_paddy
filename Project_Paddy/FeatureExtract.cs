using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PaddyCropDetection;

using AForge;
using AForge.Imaging;
using AForge.Math;
using AForge.Imaging.Filters;
using image = System.Drawing.Image;
using points = System.Drawing.Point;

namespace PaddyCropDetection
{
    public partial class FeatureExtract : Form
    {
        static int[] BallX, BallY;

        List<points> points1 = new List<points>();
        public string orginal, ff;


        public FeatureExtract()
        {
            InitializeComponent();
        }

        private void FeatureExtract_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(orginal);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox1.Image);
            Bitmap grayImage;
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);
            // apply the filter
            grayImage = filter.Apply(bmp);
            ResizeNearestNeighbor rb = new ResizeNearestNeighbor(pictureBox1.Width, pictureBox1.Height);
            // apply the filter
            image = rb.Apply(image);
           // MessageBox.Show(image.Height.ToString());
           // MessageBox.Show(image.Width.ToString());
            Graphics graphics = Graphics.FromImage(image);
            SolidBrush brush = new SolidBrush(Color.LightYellow);
            Pen pen = new Pen(brush);

            // Create corner detector and have it process the image
            MoravecCornersDetector mcd = new MoravecCornersDetector();
            List<IntPoint> corners = mcd.ProcessImage(image);

            BallX = new int[Convert.ToInt32(corners.Count)];
            BallY = new int[Convert.ToInt32(corners.Count)];
            // Visualization: Draw 3x3 boxes around the corners
            int vall = 0;
            foreach (IntPoint corner in corners)
            {
                graphics.DrawRectangle(pen, corner.X - 1, corner.Y - 1, 1, 1);
              //  listBox1.Items.Add("(" + corner.X.ToString() + "," + corner.Y.ToString() + ")");
                BallX[vall] = corner.X;
                BallY[vall] = corner.Y;
                vall += 1;
                //points1.Add(new points(corner.X, corner.Y));
            }

            // Display
            pictureBox1.Image = image;


           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Colorfeature cc = new Colorfeature();
            cc.imagename = orginal;
            cc.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Binaryimage bb = new Binaryimage();
            bb.original = orginal;
            bb.ff = ff;
            bb.Show();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox1.Image);
            Bitmap grayImage;
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);
            // apply the filter
            grayImage = filter.Apply(bmp);
            ResizeNearestNeighbor rb = new ResizeNearestNeighbor(pictureBox1.Width, pictureBox1.Height);
            // apply the filter
            image = rb.Apply(image);
            // MessageBox.Show(image.Height.ToString());
            // MessageBox.Show(image.Width.ToString());
            Graphics graphics = Graphics.FromImage(image);
            SolidBrush brush = new SolidBrush(Color.LightYellow);
            Pen pen = new Pen(brush);

            // Create corner detector and have it process the image
            MoravecCornersDetector mcd = new MoravecCornersDetector();
            List<IntPoint> corners = mcd.ProcessImage(image);

            BallX = new int[Convert.ToInt32(corners.Count)];
            BallY = new int[Convert.ToInt32(corners.Count)];
            // Visualization: Draw 3x3 boxes around the corners
            int vall = 0;
            foreach (IntPoint corner in corners)
            {
                graphics.DrawRectangle(pen, corner.X - 1, corner.Y - 1, 1, 1);
                  listBox1.Items.Add("(" + corner.X.ToString() + "," + corner.Y.ToString() + ")");
                BallX[vall] = corner.X;
                BallY[vall] = corner.Y;
                vall += 1;
                //points1.Add(new points(corner.X, corner.Y));
            }

            // Display
            pictureBox1.Image = image;


        }
    }
}
