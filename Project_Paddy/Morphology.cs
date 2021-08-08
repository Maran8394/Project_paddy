using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Imaging.Filters;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using AForge.Imaging.Filters;
using System.Resources;
using System.Reflection;
using AForge.Imaging;
using AForge;
using AForge.Math;
using AForge.Math.Geometry;

namespace PaddyCropDetection
{
    public partial class Morphology : Form
    {
        public string name, ff, original,mor;
        Otsu ot = new Otsu();


        private LogicalOperator processing;
        public Morphology()
        {
            processing = new LogicalOperator();
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            cra();

            this.pictureBox1.Image = new Bitmap(new Bitmap(binimg1), 250, 250);

            //this.Invalidate();

            processing.setImage(new Bitmap(binimg1));

        }
        string binimg1;

        private void cra()
        {
            Bitmap image = new Bitmap(pictureBox2.Image);
           //  create filter
            BlobsFiltering filter = new BlobsFiltering();
            // configure filter
            filter.CoupledSizeFiltering = true;
            filter.MinWidth = 10;
            filter.MinHeight = 30;
            //filter.MinWidth = 100;
            //filter.MinHeight = 100;
            // apply the filter
            filter.ApplyInPlace(image);
            pictureBox1.Image = image;


            string Binary1 = System.IO.Path.GetDirectoryName(Application.ExecutablePath.ToString()) + "\\Binary\\";



            Random rr = new Random();
            int i = rr.Next(11, 9999);

            binimg1 = i + ".jpg";


            binimg1 = Binary1 + binimg1;


            pictureBox1.Image.Save(binimg1, System.Drawing.Imaging.ImageFormat.Jpeg);


          

           


        }

        private void Morphology_Load(object sender, EventArgs e)
        {
           

            pictureBox2.Image = new Bitmap(mor);



            Bitmap temp1 = (Bitmap)pictureBox2.Image.Clone();
            ot.Convert2GrayScaleFast(temp1);
            int otsuThreshold = ot.getOtsuThreshold((Bitmap)temp1);
            ot.threshold(temp1, otsuThreshold);
            pictureBox2.Image = temp1;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

           
               // this.processing.setImage(new Bitmap(pictureBox1.Image));

                byte[,] sele = new byte[3, 3];

                try
                {

                    sele[0, 0] = (byte)Int32.Parse("1");
                    sele[0, 1] = (byte)Int32.Parse("1");
                    sele[0, 2] = (byte)Int32.Parse("1");
                    sele[1, 0] = (byte)Int32.Parse("1");
                    sele[1, 1] = (byte)Int32.Parse("1");
                    sele[1, 2] = (byte)Int32.Parse("1");
                    sele[2, 0] = (byte)Int32.Parse("1");
                    sele[2, 1] = (byte)Int32.Parse("1");
                    sele[2, 2] = (byte)Int32.Parse("1");

                }
                catch (Exception ee)
                {
                    MessageBox.Show(this, "Unimpliable Mask");
                }

                //if( this.radioButton1.Checked )
                this.processing.binary_Dilation(sele);
                //else			    
                //this.processing.gray_Dilation( sele );
                this.pictureBox3.Image = this.processing.getImage();

                this.Invalidate();

                button1.Enabled = false;

            
		}

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           // Assembly assembly = this.GetType().Assembly;
            Bitmap image = new Bitmap((pictureBox3.Image));
            ProcessImage(image);

           // Assembly assembly1 = this.GetType().Assembly;
            Bitmap image1 = new Bitmap((pictureBox3.Image));
            ProcessImage(image1);
        }
        private void ProcessImage(Bitmap image1)
        {
          //  circle1 = 1;

            //int foundBlobsCount = blobsBrowser1.SetImage(image);
            //blobsCountLabel.Text = string.Format("Found blobs' count: {0}", foundBlobsCount);
            //propertyGrid.SelectedObject = null;
            BlobCounter blobCounter = new BlobCounter();
            blobCounter.FilterBlobs = true;
            blobCounter.MinWidth = 3;
            blobCounter.MinHeight = 3;

            blobCounter.CoupledSizeFiltering = true;
            //blobCounter.ProcessImage(grayImage);
            blobCounter.ProcessImage(image1);
            Blob[] blobs = blobCounter.GetObjectsInformation();

            //manipulations to draw borders around founded objects

            // create convex hull searching algorithm
            GrahamConvexHull hullFinder = new GrahamConvexHull();
            Bitmap image = (Bitmap)pictureBox1.Image;
            Bitmap clonimage = (Bitmap)pictureBox1.Image.Clone();
            BitmapData data = clonimage.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, image.PixelFormat);


            // process each blob
            foreach (Blob blob in blobs)
            {
                List<IntPoint> leftPoints, rightPoints, edgePoints;
                edgePoints = new List<IntPoint>();

                // get blob's edge points
                blobCounter.GetBlobsLeftAndRightEdges(blob,
                    out leftPoints, out rightPoints);

                edgePoints.AddRange(leftPoints);
                edgePoints.AddRange(rightPoints);

                // blob's convex hull
                List<IntPoint> hull = hullFinder.FindHull(edgePoints);

                Drawing.Polygon(data, hull, Color.GreenYellow);

               // circle1 = Convert.ToInt32(rightPoints.Count.ToString());
            }
            //circle1 = circleradio(circle1, 2);
            clonimage.UnlockBits(data);
            pictureBox3.Image = clonimage;
            pictureBox3.Refresh();

            // MessageBox.Show(circle1.ToString());


        }
        Bitmap org;


        int count=0;

        private void button3_Click(object sender, EventArgs e)
        {
            Loadimage ll = new Loadimage();
            org = new Bitmap(original);

            Bitmap input = new Bitmap(org);

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
                    {
                       
                    }
                    else
                    {
                        camColor = Color.Red;
                        count++;
                    }

                    output.SetPixel(x, y, camColor);
                }
            }


           // pictureBox1.Image = output;


            DetectionImage dd = new DetectionImage();
            dd.bmp = output;
            dd.cou = count;
            dd.Show();

          //  ColorFeature1 cc = new ColorFeature1();
           // cc.bmp = output;
            //cc.Show();
           
        }
        
    }
}
