using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ERP
{
    public partial class erp : Form
    {
        my cm =new my();
        public erp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void erp_Load(object sender, EventArgs e)
        {

      


        }

        private void button4_Click(object sender, EventArgs e)
        {
            

        
            cus g = new cus();
            g.Show();
            panel7.Hide();
           

    }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            product g = new product();
            g.Show();

            panel7.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            vender g = new vender();
            g.Show();
            panel7.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            invoice g = new invoice();
            g.Show();
            panel7.Hide();
              
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState=FormWindowState.Minimized;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            vender g = new vender();
            g.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            admin g = new admin();
            g.Show();
            panel7.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel7.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            purchaseorder gg = new purchaseorder();
            gg.Show();
            panel7.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            grn gg = new grn();
            gg.Show();
            panel7.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            pro gg = new pro();
            gg.Show();
            panel7.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            sale gg = new sale();
            gg.Show();
            panel7.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
           saleinv gg = new saleinv();
            gg.Show();
            panel7.Hide();
        }
    }
}
