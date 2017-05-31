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
    public partial class admin : Form
    {
        my cm = new my();
        public admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            erp gg = new erp();
            gg.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Show();
            panel4.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {



            if(textBox7.Text=="active"){
                MessageBox.Show("Customer Are Approve");
            
            }
            cm.conn.Open();

            OleDbCommand cmd = new OleDbCommand("update Customer set Cname='" + textBox1.Text +
                "' ,CAddress='" + textBox2.Text +
                "' ,City='" + textBox3.Text +
                "' ,PH1='" + textBox4.Text +
                "' ,ContectPerson='" + textBox5.Text +
                "' ,CPPH='" + textBox6.Text +
                "' ,CStatus='" + textBox7.Text + "' where CID='" + comboBox1.Text + "'", cm.conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            cm.conn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cm.conn.Open();

            OleDbCommand cmd = new OleDbCommand("select * from Customer where CID='" + comboBox1.Text + "'", cm.conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {


                textBox1.Text = (dr["Cname"]).ToString();
                textBox2.Text = (dr["CAddress"]).ToString();
                textBox3.Text = (dr["City"]).ToString();
                textBox4.Text = (dr["PH1"]).ToString();
                textBox5.Text = (dr["ContectPerson"]).ToString();
                textBox6.Text = (dr["CPPH"]).ToString();
                textBox7.Text = (dr["CStatus"]).ToString();


            }
            cm.conn.Close();
        }

        private void admin_Load(object sender, EventArgs e)
        {
            cm.conn.Open();

            OleDbCommand comdg = new OleDbCommand("select VID from Vendor where VStatus='" + "Inactive" + "';", cm.conn);
            OleDbDataReader v = comdg.ExecuteReader();
            while (v.Read())
            {
                comboBox2.Items.Add(v["VID"]);
            }


            cm.conn.Close();



            panel4.Hide();
            panel3.Hide();
            cm.conn.Open();

            OleDbCommand comdggi = new OleDbCommand("select CID from Customer where CStatus='" + "Inactive" + "';", cm.conn);
            OleDbDataReader vv = comdggi.ExecuteReader();
            while (vv.Read())
            {
                comboBox1.Items.Add(vv["CID"]);
            }


            cm.conn.Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Hide();
            panel4.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cm.conn.Open();

            OleDbCommand cmd = new OleDbCommand("select * from Vendor where VID='" + comboBox2.Text + "'", cm.conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {


                textBox10.Text = (dr["VName"]).ToString();
                textBox11.Text = (dr["VCode"]).ToString();
                textBox12.Text = (dr["VCity"]).ToString();
                textBox13.Text = (dr["PH1"]).ToString();
                textBox15.Text = (dr["VAddress"]).ToString();
                textBox16.Text = (dr["CPName"]).ToString();

                textBox14.Text = (dr["CPPH"]).ToString();
                textBox8.Text = (dr["VFax"]).ToString();
                textBox9.Text = (dr["VStatus"]).ToString();


            }
            cm.conn.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            


             cm.conn.Open();
            

            OleDbCommand cmd = new OleDbCommand("update Vendor set VName='" + textBox10.Text +
                "' ,VCode='" + textBox11.Text +
                "' ,VCity='" + textBox12.Text +
             
                "' ,PH1='" + textBox13.Text +
                "' ,VAddress='" + textBox15.Text +
                "' ,CPName='" + textBox16.Text +
                "' ,CPPH='" + textBox14.Text +
                "' ,VFax='" + textBox8.Text +
                "' ,VStatus='" + textBox9.Text + "' where VID='" + comboBox2.Text + "'", cm.conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            cm.conn.Close();

            if (textBox9.Text == "active")
            {
                MessageBox.Show("Customer Are Approve");
            }
            
        }

        
    }
}
