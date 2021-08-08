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
    public partial class Regsister : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|Datadirectory|\paddydb.mdf;Integrated Security=True;User Instance=True");
        SqlCommand cmd;

        public Regsister()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || maskedTextBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Fill All Values!");

            }
            else
            {

                if (maskedTextBox1.MaskFull)
                {
                    string gender;
                    if (radioButton1.Checked == true)
                    {
                        gender = radioButton1.Text;

                    }
                    else
                    {
                        gender = radioButton2.Text;

                    }


                    cmd = new SqlCommand("insert into regtb values('" + textBox1.Text + "','" + gender + "','" + maskedTextBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Record Saved!");
                }
                else
                {
                    MessageBox.Show("Enter Mobile Number 10digit!");
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
