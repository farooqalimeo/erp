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
    public partial class cus : Form
    {
        my cm = new my();
        public cus()
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

        private void button4_Click(object sender, EventArgs e)
        {
            cm.conn.Open();
            OleDbCommand cmd = new OleDbCommand("insert into Customer(CID,Cname,CAddress,City,PH1,ContectPerson,CPPH,CStatus)values(@CID,@Cname,@CAddress,@City,@PH1,@ContectPerson,@CPPH,@CStatus)", cm.conn);
            cmd.Parameters.AddWithValue("CID", comboBox1.Text);
            cmd.Parameters.AddWithValue("Cname",textBox1.Text);
            cmd.Parameters.AddWithValue("CAddress",textBox2.Text);
            cmd.Parameters.AddWithValue("City", textBox3.Text);
            cmd.Parameters.AddWithValue("PH1",textBox4.Text);
            cmd.Parameters.AddWithValue("ContectPerson",textBox5.Text);
            cmd.Parameters.AddWithValue("CPPH",textBox6.Text);
            cmd.Parameters.AddWithValue("CStatus",textBox7.Text);
            
            cmd.ExecuteNonQuery();
            MessageBox.Show("Insert record");
            cm.conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

           
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            cm.conn.Open();
            OleDbCommand cmd = new OleDbCommand("delete * from Customer where CID ='"+comboBox1.Text+"'",cm.conn);
            OleDbDataReader gg = cmd.ExecuteReader();
            cm.conn.Close();
            MessageBox.Show("Record Has Been Deletr");
        }

        private void cus_Load_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cus_Load(object sender, EventArgs e)
        {
            cm.conn.Open();

            OleDbCommand comdg = new OleDbCommand("select CID from Customer;", cm.conn);
            OleDbDataReader v = comdg.ExecuteReader();
            while (v.Read())
            {
                comboBox1.Items.Add(v["CID"]);
            }


            cm.conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cm.conn.Open();

            OleDbCommand cmd = new OleDbCommand("select * from Customer where CID='"+comboBox1.Text+"'",cm.conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            while(dr.Read()){
            

            textBox1.Text=(dr["Cname"]).ToString();
            textBox2.Text=(dr["CAddress"]).ToString();
            textBox3.Text = (dr["City"]).ToString();
                textBox4.Text=(dr["PH1"]).ToString();
                textBox5.Text=(dr["ContectPerson"]).ToString();
                textBox6.Text=(dr["CPPH"]).ToString();
                textBox7.Text=(dr["CStatus"]).ToString();
                

            }
            cm.conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cm.conn.Open();

            OleDbCommand cmd = new OleDbCommand("update Customer set Cname='"+textBox1.Text+
                "' ,CAddress='" + textBox2.Text +
                "' ,City='" + textBox3.Text +
                "' ,PH1='" + textBox4.Text +
                "' ,ContectPerson='" + textBox5.Text +
                "' ,CPPH='" + textBox6.Text +
                "' ,CStatus='" + textBox7.Text + "' where CID='" + comboBox1.Text + "'", cm.conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            cm.conn.Close();
        }
    }
}
