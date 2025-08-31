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

namespace Login_form
{
    public partial class Form3 : Form
    {
        OracleConnection conn;
        public Form3()
        {
            InitializeComponent();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectDB();
            string Name = "";
            string Role = "";
            string staffID = "";
            OracleCommand command1 = conn.CreateCommand();
            command1.CommandText = "SELECT staff_id, pwd, name, role FROM staff";
            command1.CommandType = CommandType.Text;

            OracleDataReader dr = command1.ExecuteReader();
            int found = 0;
            while (dr.Read())
            {
                string db_staff_id = dr.GetString(0);
                string db_pwd = dr.GetString(1);
                string db_name = dr.GetString(2);
                string db_role = dr.GetString(3);
                if (db_staff_id == textBox1.Text && db_pwd == textBox2.Text)
                {
                    found = 1;
                    Name = db_name;
                    Role = db_role;
                    staffID = db_staff_id;
                    break;
                }
                else if (db_staff_id == textBox1.Text)
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
                Form6 frm = new Form6(Name, Role, staffID);
                frm.Show();
                this.Hide();
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
    }
}
