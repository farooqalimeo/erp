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
    public partial class sale : Form
    {
        string[] prds = new string[50];
        int[] qty = new int[50];
        int counter = 0;

        my cm = new my();


        public sale()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            erp gg = new erp();
            gg.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox8.Text += comboBox2.Text + Environment.NewLine;
            textBox9.Text += textBox3.Text + Environment.NewLine;

            // textBox6.Text += textBox3.Text + Environment.NewLine;
            prds[counter] = comboBox2.Text;
            qty[counter] = Convert.ToInt32(textBox3.Text);
            counter++;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            cm.conn.Open();
            OleDbCommand cmd = new OleDbCommand("insert into sale(SID,PID,Pqty,totalamount,CID,Cname,CPPH,status)values(@SID,@PID,@Pqty,@totalamount,@CID,@Cname,@CPPH,@status)", cm.conn);
            //DDate
            cmd.Parameters.AddWithValue("SID", textBox10.Text);
            cmd.Parameters.AddWithValue("PID", textBox8.Text);
            cmd.Parameters.AddWithValue("Pqty", textBox9.Text);

           


            cmd.Parameters.AddWithValue("totalamount", textBox7.Text);
            cmd.Parameters.AddWithValue("CID", comboBox3.Text);
            cmd.Parameters.AddWithValue("Cname", textBox4.Text);

            cmd.Parameters.AddWithValue("CPPH", textBox6.Text);
            cmd.Parameters.AddWithValue("status", "Open");


           // cmd.Parameters.AddWithValue("DDate",dateTimePicker1);




            cmd.ExecuteNonQuery();
            MessageBox.Show("Order Create");
            cm.conn.Close();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sale_Load(object sender, EventArgs e)
        {
            int c = 0;
            cm.conn.Open();
            OleDbCommand cmd = new OleDbCommand("select count(SID) from Sale ;", cm.conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]); c++;
            }
            if (textBox10.Text == "")
            {
                textBox10.Text = "00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }


            cm.conn.Close();








            cm.conn.Open();

            OleDbCommand comdggg = new OleDbCommand("select PModel from Products;", cm.conn);
            OleDbDataReader vi = comdggg.ExecuteReader();
            while (vi.Read())
            {
                comboBox2.Items.Add(vi["PModel"]);
            }


            cm.conn.Close();



            cm.conn.Open();

            OleDbCommand comdgg = new OleDbCommand("select CID from customer where CStatus='"+"Active"+"'", cm.conn);
            OleDbDataReader v = comdgg.ExecuteReader();
            while (v.Read())
            {
                comboBox3.Items.Add(v["CID"]);
            }


            cm.conn.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cm.conn.Open();

            OleDbCommand cmd = new OleDbCommand("select * from Products where PModel='" + comboBox2.Text + "'", cm.conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {


                textBox1.Text = (dr["PName"]).ToString();
                textBox2.Text = (dr["BasePrice"]).ToString();
               






            }
            cm.conn.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textBox2.Text);
            int aa = Convert.ToInt32(textBox3.Text);
            int ff = Convert.ToInt32(a * aa);
            textBox7.Text = ff.ToString();
            
            
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cm.conn.Open();

            OleDbCommand cmd = new OleDbCommand("select * from customer where CID='" + comboBox3.Text + "'", cm.conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {


                textBox4.Text = (dr["Cname"]).ToString();
                textBox5.Text = (dr["PH1"]).ToString();
                textBox6.Text = (dr["CPPH"]).ToString();







            }
            cm.conn.Close();


        }
    }
}
