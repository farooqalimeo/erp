using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ERP
{
    public partial class product : Form
    {
        my cm =new my();
        public product()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            erp gg = new erp();
            gg.ShowDialog();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void product_Load(object sender, EventArgs e)
        {
           
        }

        private void product_Load_1(object sender, EventArgs e)
        {
            cm.conn.Open();

            OleDbCommand comdg = new OleDbCommand("select POID from POproducts;", cm.conn);
            OleDbDataReader v = comdg.ExecuteReader();
            while (v.Read())
            {
                comboBox1.Items.Add(v["POID"]);
            }


            cm.conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cm.conn.Open();
            OleDbCommand cmd = new OleDbCommand("delete * from POproducts where POID ='" + comboBox1.Text + "'", cm.conn);
            OleDbDataReader gg = cmd.ExecuteReader();
            cm.conn.Close();
            MessageBox.Show("Record Has Been Deletr");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cm.conn.Open();

            OleDbCommand cmd = new OleDbCommand("select * from POproducts where POID='" + comboBox1.Text + "'", cm.conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {


                textBox1.Text = (dr["PModel"]).ToString();
                textBox2.Text = (dr["PQty"]).ToString();
               

            }
            cm.conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cm.conn.Open();

            OleDbCommand cmd = new OleDbCommand("update POproducts set PModel='" + textBox1.Text +
                "' ,PQty='" + textBox2.Text +
                "' where POID='" + comboBox1.Text + "'", cm.conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            cm.conn.Close();
            MessageBox.Show("Record Has Been Uodated");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cm.conn.Open();
            OleDbCommand cmd = new OleDbCommand("insert into POproducts(POID,PModel,PQty)values(@POID,@PModel,@PQty)", cm.conn);
            cmd.Parameters.AddWithValue("POID", comboBox1.Text);
            cmd.Parameters.AddWithValue("PModel", textBox1.Text);
            cmd.Parameters.AddWithValue("PQty", textBox2.Text);
         

            cmd.ExecuteNonQuery();
            MessageBox.Show("Insert record");
            cm.conn.Close();
        }
    }
}
