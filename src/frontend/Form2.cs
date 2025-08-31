using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.Intrinsics.X86;

namespace Login_form
{
    public partial class Form2 : Form
    {
        OracleConnection conn;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        public void ConnectDB()
        {
            conn = new OracleConnection("User Id=avi; Password=sql; Data Source=127.0.0.1:1521/xepdb1");
            try
            {
                conn.Open();
            }
            catch (Exception e1)
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectDB();
            string Name = "";
            string custID = "";
            OracleCommand command1 = conn.CreateCommand();
            command1.CommandText = "SELECT cust_id, pwd, name FROM customer";
            command1.CommandType = CommandType.Text;

            OracleDataReader dr = command1.ExecuteReader();
            int found = 0;
            while (dr.Read())
            {
                string db_cust_id = dr.GetString(0);
                string db_pwd = dr.GetString(1);
                string db_name = dr.GetString(2);
                if (db_cust_id == textBox1.Text && db_pwd == textBox2.Text)
                {
                    found = 1;
                    Name = db_name;
                    custID = db_cust_id;
                    break;
                }
                else if (db_cust_id == textBox1.Text)
                {
                    found = 2;
                    break;
                }
            }
            dr.Close();
            command1.Dispose();
            conn.Close();
            if (found == 1)
            {
                Form4 frm1 = new Form4(Name, custID);
                frm1.Show();
                this.Close();
            }
            else if (found == 2)
            {
                MessageBox.Show("Incorrect password!", "Error");
            }
            else
            {
                MessageBox.Show("User does not exist!", "Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 frm2 = new Form5();
            frm2.Show();
            this.Close();
        }
    }
}
