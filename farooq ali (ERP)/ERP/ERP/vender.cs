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
    public partial class vender : Form
    {
        my cm = new my();
        public vender()
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

        private void vender_Load(object sender, EventArgs e)
        {

            cm.conn.Open();

            OleDbCommand comdg = new OleDbCommand("select VID from Vendor;", cm.conn);
            OleDbDataReader v = comdg.ExecuteReader();
            while (v.Read())
            {
                comboBox1.Items.Add(v["VID"]);
            }


            cm.conn.Close();
        
    }

        private void button5_Click(object sender, EventArgs e)
        {
            cm.conn.Open();
            OleDbCommand cmd = new OleDbCommand("delete * from Vendor where VID ='" + comboBox1.Text + "'", cm.conn);
            OleDbDataReader gg = cmd.ExecuteReader();
            cm.conn.Close();
            MessageBox.Show("Record Has Been Deletr");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cm.conn.Open();
            OleDbCommand cmd = new OleDbCommand("insert into Vendor(VID,VName,VCode,VCity,PH1,VAddress,CPName,CPPH,VFax,VStatus)values(@VID,@VName,@VCode,@VCity,@PH1,@VAddress,@CPName,@CPPH,@VFax,@VStatus)", cm.conn);
            cmd.Parameters.AddWithValue("VID", comboBox1.Text);
            cmd.Parameters.AddWithValue("VName", textBox1.Text);
            cmd.Parameters.AddWithValue("VCode", textBox2.Text);
            cmd.Parameters.AddWithValue("VCity", textBox3.Text);
            cmd.Parameters.AddWithValue("PH1", textBox4.Text);
            cmd.Parameters.AddWithValue("VAddress", textBox5.Text);
            cmd.Parameters.AddWithValue("CPName", textBox6.Text);
            cmd.Parameters.AddWithValue("CPPH", textBox7.Text);
            cmd.Parameters.AddWithValue("VFax", textBox8.Text);
            cmd.Parameters.AddWithValue("VStatus", textBox9.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Insert record");
            cm.conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cm.conn.Open();

            OleDbCommand cmd = new OleDbCommand("select * from Vendor where VID='" + comboBox1.Text + "'", cm.conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

              
                textBox1.Text = (dr["VName"]).ToString();
                textBox2.Text = (dr["VCode"]).ToString();
                textBox3.Text = (dr["VCity"]).ToString();
                textBox4.Text = (dr["PH1"]).ToString();
                textBox5.Text = (dr["VAddress"]).ToString();
                textBox6.Text = (dr["CPName"]).ToString();

                textBox7.Text = (dr["CPPH"]).ToString();
                textBox8.Text = (dr["VFax"]).ToString();
                textBox9.Text = (dr["VStatus"]).ToString();
               

            }
            cm.conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cm.conn.Open();
            

            OleDbCommand cmd = new OleDbCommand("update Vendor set VName='" + textBox1.Text +
                "' ,VCode='" + textBox2.Text +
                "' ,VCity='" + textBox3.Text +
             
                "' ,PH1='" + textBox4.Text +
                "' ,VAddress='" + textBox5.Text +
                "' ,CPName='" + textBox6.Text +
                "' ,CPPH='" + textBox7.Text +
                "' ,VFax='" + textBox8.Text +
                "' ,VStatus='" + textBox9.Text + "' where VID='" + comboBox1.Text + "'", cm.conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            cm.conn.Close();
            MessageBox.Show("Record Has Been Uodated");
        }
    }
}
