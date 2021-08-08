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
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PaddyCropDetection.Loadimage ll = new PaddyCropDetection.Loadimage();
            ll.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
