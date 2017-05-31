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
    public partial class saleinv : Form
    {

        string[] prds = new string[50];
        int[] qty = new int[50];
      

        my cm = new my();

        public saleinv()
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

        private void saleinv_Load(object sender, EventArgs e)
        {
            int c = 0;
            cm.conn.Open();
            OleDbCommand cmd = new OleDbCommand("select count(SIID) from SInvoice;", cm.conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]); c++;
            }
            if (textBox3.Text == "")
            {
                textBox3.Text = "00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }


            cm.conn.Close();


            cm.conn.Open();

            OleDbCommand comdgg = new OleDbCommand("select SID from sale where status='" + "Open" + "'", cm.conn);
            OleDbDataReader v = comdgg.ExecuteReader();
            while (v.Read())
            {
                comboBox2.Items.Add(v["SID"]);
            }


            cm.conn.Close();








        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cm.conn.Open();

            OleDbCommand cmd = new OleDbCommand("select * from sale where sid='" + comboBox2.Text + "'", cm.conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {


                textBox5.Text = (dr["pqty"]).ToString();
                textBox2.Text = (dr["totalamount"]).ToString();
                textBox6.Text = (dr["PID"]).ToString();
                textBox1.Text = (dr["CID"]).ToString();
                







            }
            cm.conn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            cm.conn.Open();


            OleDbCommand cmd = new OleDbCommand("update sale set status='" +"close" +
               
               "' where sid='" + comboBox2.Text + "'", cm.conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            cm.conn.Close();
            





            cm.conn.Open();
            OleDbCommand cmdd = new OleDbCommand("insert into sale(SIID,sid,Pid,Cid,pqty,Amount total)values(@SIID,@sid,@Pid,@Cid,@pqty,@Amount total)", cm.conn);
            cmdd.Parameters.AddWithValue("SIID", textBox3.Text);
            cmdd.Parameters.AddWithValue("sid", comboBox2.Text);
            
            cmdd.Parameters.AddWithValue("Pid", textBox6.Text);
            cmdd.Parameters.AddWithValue("Cid", textBox1.Text);


            

            cmdd.Parameters.AddWithValue("pqty", textBox5.Text);
            cmdd.Parameters.AddWithValue("Amount total", textBox2.Text);

            




            cmdd.ExecuteNonQuery();
            MessageBox.Show("Invoice Ganerate");
            cm.conn.Close();
        }
    }
}
