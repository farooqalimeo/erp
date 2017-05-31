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
    public partial class invoice : Form
    {
        my cm = new my();
        public invoice()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            erp gg = new erp();
            gg.ShowDialog();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void invoice_Load(object sender, EventArgs e)
        {



            int c = 0;
            cm.conn.Open();
            OleDbCommand cmd = new OleDbCommand("select count(InvoiceNo) from INVOICE ;", cm.conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]); c++;
            }
            if (textBox5.Text == "")
            {
                textBox5.Text = "00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }
            

            cm.conn.Close();





           



            cm.conn.Open();

            OleDbCommand comdgg = new OleDbCommand("select POID from PO where status='" + "Open" + "';", cm.conn);
            OleDbDataReader vg = comdgg.ExecuteReader();
            while (vg.Read())
            {
                comboBox2.Items.Add(vg["POID"]);
            }


            cm.conn.Close();

            
            

        }

        private void button4_Click(object sender, EventArgs e){
           
     
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

}

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {



            cm.conn.Open();

            OleDbCommand cmd = new OleDbCommand("select * from PO where POID='" + comboBox2.Text + "'", cm.conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {


                textBox6.Text = (dr["VID"]).ToString();

                textBox1.Text = (dr["VName"]).ToString();

              


                textBox4.Text = (dr["TotalAmount"]).ToString();

                int a = Convert.ToInt32(textBox4.Text);
                int b = Convert.ToInt32(a*17/100);
                textBox4.Text = b.ToString();




            }
            cm.conn.Close();



            cm.conn.Open();

            OleDbCommand cmdd = new OleDbCommand("select * from POProducts where POID='" + comboBox2.Text + "'", cm.conn);
            OleDbDataReader drd = cmdd.ExecuteReader();
            while (drd.Read())
            {


                textBox2.Text = (drd["PQty"]).ToString();

                




            }
            cm.conn.Close();



            cm.conn.Open();

            OleDbCommand cmdh = new OleDbCommand("select * from GRN where VName='" + textBox1.Text + "'", cm.conn);
            OleDbDataReader drh = cmdh.ExecuteReader();
            while (drh.Read())
            {




                textBox7.Text = (drh["GRNID"]).ToString();




            }

            cm.conn.Close();


           



        }

        private void button6_Click(object sender, EventArgs e)
        {
            cm.conn.Open();
            OleDbCommand cmd = new OleDbCommand("insert into Invoice(InvoiceNo,VendorID,VendorName,AmountPayable,GRNID)values(@InvoiceNo,@VendorID,@VendorName,@AmountPayable,@GRNID)", cm.conn);
          
            
            cmd.Parameters.AddWithValue("InvoiceNo", textBox5.Text);
            cmd.Parameters.AddWithValue("VendorID", textBox6.Text);
            cmd.Parameters.AddWithValue("VendorName", textBox1.Text);
            cmd.Parameters.AddWithValue("AmountPayable", textBox4.Text);
            cmd.Parameters.AddWithValue("GRNID", textBox7.Text);


            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Save");
            cm.conn.Close();

            cm.conn.Open();

            OleDbCommand cmdd = new OleDbCommand("update GRN set Status='" + "close" +

                "' where GRNID='" + textBox7.Text + "'", cm.conn);
            OleDbDataReader dr = cmdd.ExecuteReader();
            cm.conn.Close();

            cm.conn.Open();

           

        }
    }
}
