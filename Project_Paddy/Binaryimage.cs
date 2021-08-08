﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Imaging.Filters;
using PaddyCropDetection;
using System.Drawing.Imaging;


namespace PaddyCropDetection
{
    public partial class Binaryimage : Form
    {

        Otsu ot = new Otsu();
        public Binaryimage()
        {
            InitializeComponent();
        }

        public string name, ff, original;
        public Bitmap bmp;


        string binimg;

        private void button1_Click(object sender, EventArgs e)
        {
            //Bitmap temp1 = (Bitmap)pictureBox1.Image.Clone();
            //ot.Convert2GrayScaleFast(temp1);
            //int otsuThreshold = ot.getOtsuThreshold((Bitmap)temp1);
            //ot.threshold(temp1, otsuThreshold);
            //pictureBox1.Image = temp1;


            //string Binary1 = System.IO.Path.GetDirectoryName(Application.ExecutablePath.ToString()) + "\\Binary\\";



            //Random rr = new Random();
            //int i = rr.Next(11, 9999);

            //binimg = i + ".jpg";


            //binimg = Binary1 + binimg;


            //pictureBox1.Image.Save(binimg, System.Drawing.Imaging.ImageFormat.Jpeg);

        }

        private void Binaryimage_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(original);
        }


        public Bitmap OriginalImage { get; set; }
        public Bitmap TransformedImage { get; set; }

        private const double w0 = 0.5;
        private const double w1 = -0.5;
        private const double s0 = 0.5;
        private const double s1 = 0.5;

        /// <summary>
        ///   Discrete Haar Wavelet Transform
        /// </summary>
        /// 
        public void FWT(double[] data)
        {
            double[] temp = new double[data.Length];

            int h = data.Length >> 1;
            for (int i = 0; i < h; i++)
            {
                int k = (i << 1);
                temp[i] = data[k] * s0 + data[k + 1] * s1;
                temp[i + h] = data[k] * w0 + data[k + 1] * w1;
            }

            for (int i = 0; i < data.Length; i++)
                data[i] = temp[i];
        }

        /// <summary>
        ///   Discrete Haar Wavelet 2D Transform
        /// </summary>
        /// 
        public void FWT(double[,] data, int iterations)
        {
            int rows = data.GetLength(0);
            int cols = data.GetLength(1);

            double[] row = new double[cols];
            double[] col = new double[rows];

            for (int k = 0; k < iterations; k++)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < row.Length; j++)
                        row[j] = data[i, j];

                    FWT(row);

                    for (int j = 0; j < row.Length; j++)
                        data[i, j] = row[j];
                }

                for (int j = 0; j < cols; j++)
                {
                    for (int i = 0; i < col.Length; i++)
                        col[i] = data[i, j];

                    FWT(col);

                    for (int i = 0; i < col.Length; i++)
                        data[i, j] = col[i];
                }
            }
        }

        /// <summary>
        ///   Inverse Haar Wavelet Transform
        /// </summary>
        /// 
        public void IWT(double[] data)
        {
            double[] temp = new double[data.Length];

            int h = data.Length >> 1;
            for (int i = 0; i < h; i++)
            {
                int k = (i << 1);
                temp[k] = (data[i] * s0 + data[i + h] * w0) / w0;
                temp[k + 1] = (data[i] * s1 + data[i + h] * w1) / s0;
            }

            for (int i = 0; i < data.Length; i++)
                data[i] = temp[i];
        }

        /// <summary>
        ///   Inverse Haar Wavelet 2D Transform
        /// </summary>
        /// 
        public void IWT(double[,] data, int iterations)
        {
            int rows = data.GetLength(0);
            int cols = data.GetLength(1);

            double[] col = new double[rows];
            double[] row = new double[cols];

            for (int l = 0; l < iterations; l++)
            {
                for (int j = 0; j < cols; j++)
                {
                    for (int i = 0; i < row.Length; i++)
                        col[i] = data[i, j];

                    IWT(col);

                    for (int i = 0; i < col.Length; i++)
                        data[i, j] = col[i];
                }

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < row.Length; j++)
                        row[j] = data[i, j];

                    IWT(row);

                    for (int j = 0; j < row.Length; j++)
                        data[i, j] = row[j];
                }
            }
        }

        public double Scale(double fromMin, double fromMax, double toMin, double toMax, double x)
        {
            if (fromMax - fromMin == 0) return 0;
            double value = (toMax - toMin) * (x - fromMin) / (fromMax - fromMin) + toMin;
            if (value > toMax)
            {
                value = toMax;
            }
            if (value < toMin)
            {
                value = toMin;
            }
            return value;
        }
     
        public void ApplyHaarTransform(bool Forward, bool Safe, string sIterations)
        {
            Bitmap bmp = Forward ? new Bitmap(OriginalImage) : new Bitmap(TransformedImage);

            int Iterations = 0;
            int.TryParse(sIterations, out Iterations);

            int maxScale = (int)(Math.Log(bmp.Width < bmp.Height ? bmp.Width : bmp.Height) / Math.Log(2));
            if (Iterations < 1 || Iterations > maxScale)
            {
                MessageBox.Show("Iteration must be Integer from 1 to " + maxScale);
                return;
            }

            int time = Environment.TickCount;

            double[,] Red = new double[bmp.Width, bmp.Height];
            double[,] Green = new double[bmp.Width, bmp.Height];
            double[,] Blue = new double[bmp.Width, bmp.Height];

            int PixelSize = 3;
            BitmapData bmData = null;

            if (Safe)
            {
                Color c;

                for (int j = 0; j < bmp.Height; j++)
                {
                    for (int i = 0; i < bmp.Width; i++)
                    {
                        c = bmp.GetPixel(i, j);
                        Red[i, j] = (double)Scale(0, 255, -1, 1, c.R);
                        Green[i, j] = (double)Scale(0, 255, -1, 1, c.G);
                        Blue[i, j] = (double)Scale(0, 255, -1, 1, c.B);
                    }
                }
            }
            else
            {
                bmData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                unsafe
                {
                    for (int j = 0; j < bmData.Height; j++)
                    {
                        byte* row = (byte*)bmData.Scan0 + (j * bmData.Stride);
                        for (int i = 0; i < bmData.Width; i++)
                        {
                            Red[i, j] = (double)Scale(0, 255, -1, 1, row[i * PixelSize + 2]);
                            Green[i, j] = (double)Scale(0, 255, -1, 1, row[i * PixelSize + 1]);
                            Blue[i, j] = (double)Scale(0, 255, -1, 1, row[i * PixelSize]);
                        }
                    }
                }
            }

            if (Forward)
            {
                FWT(Red, Iterations);
                FWT(Green, Iterations);
                FWT(Blue, Iterations);
            }
            else
            {
                IWT(Red, Iterations);
                IWT(Green, Iterations);
                IWT(Blue, Iterations);
            }

            if (Safe)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    for (int i = 0; i < bmp.Width; i++)
                    {
                        bmp.SetPixel(i, j, Color.FromArgb((int)Scale(-1, 1, 0, 255, Red[i, j]), (int)Scale(-1, 1, 0, 255, Green[i, j]), (int)Scale(-1, 1, 0, 255, Blue[i, j])));
                    }
                }
            }
            else
            {
                unsafe
                {
                    for (int j = 0; j < bmData.Height; j++)
                    {
                        byte* row = (byte*)bmData.Scan0 + (j * bmData.Stride);
                        for (int i = 0; i < bmData.Width; i++)
                        {
                            row[i * PixelSize + 2] = (byte)Scale(-1, 1, 0, 255, Red[i, j]);
                            row[i * PixelSize + 1] = (byte)Scale(-1, 1, 0, 255, Green[i, j]);
                            row[i * PixelSize] = (byte)Scale(-1, 1, 0, 255, Blue[i, j]);
                        }
                    }
                }

                bmp.UnlockBits(bmData);
            }

            if (Forward)
            {
                TransformedImage = new Bitmap(bmp);
            }
           // keys = @"myKey123";
            pictureBox1.Image = bmp;
            lblDirection.Text = Forward ? "Forward" : "Inverse";
          //  lblTransformTime.Text = ((int)(Environment.TickCount - time)).ToString() + " milis.";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap tempbitmap = new Bitmap(original);
            if (((tempbitmap.Width & (tempbitmap.Width - 1)) != 0) ||
                ((tempbitmap.Height & (tempbitmap.Height - 1)) != 0))
            {
                MessageBox.Show("Image width and height must be power of 2!");
                return;
            }
            OriginalImage = tempbitmap;

            ApplyHaarTransform(true, true, "1");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Bitmap input = new Bitmap(original);

            Bitmap output = new Bitmap(input.Width, input.Height);


            for (int y = 0; y < output.Height; y++)
            {

                for (int x = 0; x < output.Width; x++)
                {

                    Color camColor = input.GetPixel(x, y);


                    byte max = Math.Max(Math.Max(camColor.R, camColor.G), camColor.B);
                    byte min = Math.Min(Math.Min(camColor.R, camColor.G), camColor.B);


                    bool replace =
                        camColor.G != min
                        && (camColor.G == max
                        || max - camColor.G < 8)
                        && (max - min) > 10;

                    if (replace)
                        camColor = Color.Blue;


                    output.SetPixel(x, y, camColor);
                }
            }


             string Binary1 = System.IO.Path.GetDirectoryName(Application.ExecutablePath.ToString()) + "\\Binary\\";



            Random rr = new Random();
            int i = rr.Next(11, 9999);

            binimg = i + ".jpg";


            binimg = Binary1 + binimg;


            output.Save(binimg, System.Drawing.Imaging.ImageFormat.Jpeg);

           
           // output.Save ()
         


            //pictureBox1.Image = output;


            Morphology mm = new Morphology();
            mm.name = name;
            mm.ff = ff;
            mm.original = original;
            mm.mor = binimg;

            mm.Show();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Bitmap temp1 = (Bitmap)pictureBox1.Image.Clone();
            ot.Convert2GrayScaleFast(temp1);
            int otsuThreshold = ot.getOtsuThreshold((Bitmap)temp1);
            ot.threshold(temp1, otsuThreshold);
            pictureBox1.Image = temp1;


            //string Binary1 = System.IO.Path.GetDirectoryName(Application.ExecutablePath.ToString()) + "\\Binary\\";



            //Random rr = new Random();
            //int i = rr.Next(11, 9999);

            //binimg = i + ".jpg";


            //binimg = Binary1 + binimg;


            //pictureBox1.Image.Save(binimg, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

    }
}
