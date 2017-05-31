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
    public partial class purchaseorder : Form
    {


        string[] prds = new string[50];
        int[] qty = new int[50];
        int counter = 0;

        my cm = new my();
        public purchaseorder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            erp gg = new erp();
            gg.ShowDialog();
        }

        private void purchaseorder_Load(object sender, EventArgs e)
        {



            cm.conn.Open();

            OleDbCommand comdg = new OleDbCommand("select vdept from PO;", cm.conn);
            OleDbDataReader v = comdg.ExecuteReader();
            while (v.Read())
            {
                comboBox1.Items.Add(v["vdept"]);
            }


            cm.conn.Close();


            cm.conn.Open();

            OleDbCommand comdgg = new OleDbCommand("select VID from Vendor;", cm.conn);
            OleDbDataReader vv = comdgg.ExecuteReader();
            while (vv.Read())
            {
                comboBox2.Items.Add(vv["VID"]);
            }


            cm.conn.Close();


            cm.conn.Open();

            OleDbCommand comdggg = new OleDbCommand("select PModel from Products;", cm.conn);
            OleDbDataReader vi = comdggg.ExecuteReader();
            while (vi.Read())
            {
                comboBox3.Items.Add(vi["PModel"]);
            }


            cm.conn.Close();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cm.conn.Open();

            OleDbCommand cmd = new OleDbCommand("select * from Vendor where VID='" + comboBox2.Text + "'", cm.conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {


                textBox1.Text = (dr["VName"]).ToString();
            
                textBox2.Text = (dr["PH1"]).ToString();
                
                textBox3.Text = (dr["CPName"]).ToString();

                textBox4.Text = (dr["CPPH"]).ToString();
               

            }
            cm.conn.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cm.conn.Open();

            OleDbCommand cmd = new OleDbCommand("select * from Products where PModel='" + comboBox3.Text + "'", cm.conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {


                textBox5.Text = (dr["PName"]).ToString();

                textBox6.Text = (dr["BasePrice"]).ToString();

                

               


            }
            cm.conn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox8.Text += comboBox3.Text + Environment.NewLine;
            textBox9.Text += textBox7.Text + Environment.NewLine;
            
           // textBox6.Text += textBox3.Text + Environment.NewLine;
            prds[counter] = comboBox3.Text;
            qty[counter] = Convert.ToInt32(textBox7.Text);
            counter++;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cm.conn.Open();
            for (int i = 0; i < counter; i++)
            {
                OleDbCommand cmd = new OleDbCommand("insert into POproducts(POID,PModel,PQty,TotalAmount)values(@POID,@PModel,@PQty,@TotalAmount)", cm.conn);
                cmd.Parameters.AddWithValue("POID", textBox10.Text);
                cmd.Parameters.AddWithValue("PModel", comboBox2.Text);
                cmd.Parameters.AddWithValue("PQty", textBox7.Text);
                cmd.Parameters.AddWithValue("TotalAmount", textBox11.Text);



                cmd.ExecuteNonQuery();
            }
            cm.conn.Close();


            cm.conn.Open();

            OleDbCommand cmdd = new OleDbCommand("update PO set Status='" + "open" +

                "' where POID='" + comboBox1.Text + "'", cm.conn);
            OleDbDataReader dr = cmdd.ExecuteReader();
            cm.conn.Close();
            MessageBox.Show("Insert record");






        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int c=0;
 cm.conn.Open();
 OleDbCommand cmd = new OleDbCommand("select count(POID) from PO where vdept='" + comboBox1.Text + "'", cm.conn);
 OleDbDataReader dr = cmd.ExecuteReader();
 if (dr.Read())
 {
 c = Convert.ToInt32(dr[0]); c++;
 }
 if (comboBox1.Text == "Consumer")
 {
 textBox10.Text = "Con-00" + c.ToString()+"-"+ System. DateTime.Today.Year;
 }
 if (comboBox1.Text == "HR")
 {
     textBox10.Text = "HR-00" + c.ToString() + "-" + System.DateTime.Today.Year;
 }
 if (comboBox1.Text == "Sales")
 {
     textBox10.Text = "Sales-00" + c.ToString() + "-" + System.DateTime.Today.Year;
 }
 cm.conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textBox6.Text);
            int aa = Convert.ToInt32(textBox7.Text);
            int ff = Convert.ToInt32(a * aa);
            textBox11.Text = ff.ToString();
        }
    }
}
