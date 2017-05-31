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
    public partial class pro : Form
    {
        my cm = new my();
        public pro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            erp gg = new erp();
            gg.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void pro_Load(object sender, EventArgs e)
        {
            cm.conn.Open();

            OleDbCommand comdg = new OleDbCommand("select PModel from Products;", cm.conn);
            OleDbDataReader v = comdg.ExecuteReader();
            while (v.Read())
            {
                comboBox1.Items.Add(v["PModel"]);
            }


            cm.conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cm.conn.Open();
            OleDbCommand cmd = new OleDbCommand("insert into Products(PModel,PName,BasePrice,WeightInPounds,AllowPerOrder,WarrentyPeriod,ProductType)values(@PModel,@PName,@BasePrice,@WeightInPounds,@AllowPerOrder,@WarrentyPeriod,@ProductType)", cm.conn);

            cmd.Parameters.AddWithValue("PModel", textBox1.Text);
            cmd.Parameters.AddWithValue("PName", textBox2.Text);
            cmd.Parameters.AddWithValue("BasePrice", textBox3.Text);
            cmd.Parameters.AddWithValue("WeightInPounds", textBox4.Text);
            cmd.Parameters.AddWithValue("AllowPerOrder", textBox5.Text);
            cmd.Parameters.AddWithValue("WarrentyPeriod", textBox6.Text);
            cmd.Parameters.AddWithValue("ProductType", textBox7.Text);
           

            cmd.ExecuteNonQuery();
            MessageBox.Show("Insert record");
            cm.conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cm.conn.Open();
            OleDbCommand cmd = new OleDbCommand("delete * from Products where PModel ='" + comboBox1.Text + "'", cm.conn);
            OleDbDataReader gg = cmd.ExecuteReader();
            cm.conn.Close();
            MessageBox.Show("Record Has Been Deletr");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cm.conn.Open();

            OleDbCommand cmd = new OleDbCommand("select * from Products where PModel='" + comboBox1.Text + "'", cm.conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

               
                textBox1.Text = (dr["PModel"]).ToString();
                textBox2.Text = (dr["PName"]).ToString();
                textBox3.Text = (dr["BasePrice"]).ToString();
                textBox4.Text = (dr["WeightInPounds"]).ToString();
                textBox5.Text = (dr["AllowPerOrder"]).ToString();
                textBox6.Text = (dr["WarrentyPeriod"]).ToString();

                textBox7.Text = (dr["ProductType"]).ToString();
              


            }
            cm.conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cm.conn.Open();

          
            OleDbCommand cmd = new OleDbCommand("update Products set PModel='" + textBox1.Text +
                "' ,PName='" + textBox2.Text +
                "' ,BasePrice='" + textBox3.Text +

                "' ,WeightInPounds='" + textBox4.Text +
                "' ,AllowPerOrder='" + textBox5.Text +
                "' ,WarrentyPeriod='" + textBox6.Text +
                "' ,ProductType='" + textBox7.Text + "' where PModel='" + comboBox1.Text + "'", cm.conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            cm.conn.Close();
            MessageBox.Show("Record Has Been Uodated");
        }
    }
}
