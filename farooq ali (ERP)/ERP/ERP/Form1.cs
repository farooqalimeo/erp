using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(30,Color.Wheat);
            panel2.BackColor = Color.FromArgb(110, Color.Pink);
            button2.BackColor = Color.FromArgb(170, Color.Pink);
            textBox1.MaxLength = 13;
            textBox2.MaxLength = 13;
       
     
         

            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            erp ff = new erp();
            Form1 f = new Form1();
            if (textBox1.Text == "farooq ali" && textBox2.Text == "farooq ali")
            {

                ff.Show();
                f.Hide();

            }
            else {
                MessageBox.Show("Password and email Incorrect");
            }
        }
    }
}
