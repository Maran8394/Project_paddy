using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Farmer_Friend_Application
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|Datadirectory|\paddydb.mdf;Integrated Security=True;User Instance=True");
        SqlCommand cmd;

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Farmer_Friend_Application.Regsister rr = new Regsister();
            rr.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            con.Open();
            cmd = new SqlCommand("select * from regtb where username='" + textBox1.Text + "' and PAssword='" + textBox2.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {


                con.Close(); PaddyCropDetection.Loadimage ll = new PaddyCropDetection.Loadimage();
                ll.Show();
            }
            else
            {

                MessageBox.Show("Username or Password Incorrect");
            }


            con.Close();

          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";


        }
    }
}
