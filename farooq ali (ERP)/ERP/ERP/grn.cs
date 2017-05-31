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
    public partial class grn : Form
    {
        my cm = new my();
        public grn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            erp gg = new erp();
            gg.ShowDialog();
        }

        private void grnproduct_Load(object sender, EventArgs e)
        {
            cm.conn.Open();

            OleDbCommand comdg = new OleDbCommand("select VName from GRN;", cm.conn);
            OleDbDataReader v = comdg.ExecuteReader();
            while (v.Read())
            {
                comboBox2.Items.Add(v["VName"]);
            }


            cm.conn.Close();



            cm.conn.Open();

            OleDbCommand comdgg = new OleDbCommand("select POID from PO where Approve ='" + "Approved" + "';", cm.conn);
            OleDbDataReader vv = comdgg.ExecuteReader();
            
            while (vv.Read())
            {
                comboBox1.Items.Add(vv["POID"]);
            }


            cm.conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cm.conn.Open();

            OleDbCommand cmd = new OleDbCommand("select * from POProducts where POID='" + comboBox1.Text + "'", cm.conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {


                textBox1.Text = (dr["PModel"]).ToString();

                textBox2.Text = (dr["PQty"]).ToString();

               


            }
            cm.conn.Close();


            cm.conn.Open();

            OleDbCommand cmdd = new OleDbCommand("select * from PO where POID='" + comboBox1.Text + "'", cm.conn);
            OleDbDataReader drd = cmdd.ExecuteReader();
            while (drd.Read())
            {


                textBox4.Text = (drd["DDate"]).ToString();

                textBox3.Text = (drd["VID"]).ToString();




            }
            cm.conn.Close();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
         int c=0;
 cm.conn.Open();
 OleDbCommand cmd = new OleDbCommand("select count(GRNID) from GRN where VName='" + comboBox2.Text + "'", cm.conn);
 OleDbDataReader dr = cmd.ExecuteReader();
 if (dr.Read())
 {
 c = Convert.ToInt32(dr[0]); c++;
 }
 if (comboBox2.Text == "Lifo sales")
 {
 textBox5.Text = "Lif-00" + c.ToString()+"-"+ System. DateTime.Today.Year;
 }
 if (comboBox2.Text == "RAD enterprise")
 {
     textBox5.Text = "RAD-00" + c.ToString() + "-" + System.DateTime.Today.Year;
 }
 if (comboBox2.Text == "ROC HR")
 {
     textBox5.Text = "Roc-00" + c.ToString() + "-" + System.DateTime.Today.Year;
 }

 cm.conn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cm.conn.Open();
            OleDbCommand cmd = new OleDbCommand("insert into GRN(GRNID,VName,DDate)values(@GRNID,@VName,@DDate)", cm.conn);
            cmd.Parameters.AddWithValue("GRNID", textBox5.Text);
            cmd.Parameters.AddWithValue("VName", comboBox2.Text);
            cmd.Parameters.AddWithValue("DDate", textBox4.Text);


            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Save");
            cm.conn.Close();

            cm.conn.Open();

            OleDbCommand cmdd = new OleDbCommand("update GRN set Status='" +"open" +
                
                "' where VName='" + comboBox2.Text + "'", cm.conn);
            OleDbDataReader dr = cmdd.ExecuteReader();
            cm.conn.Close();


            cm.conn.Open();

            OleDbCommand cmddd = new OleDbCommand("update PO set Status='" + "close" +

                "' where POID='" + comboBox1.Text + "'", cm.conn);
            OleDbDataReader drd = cmddd.ExecuteReader();
            cm.conn.Close();

        }
    }
}
