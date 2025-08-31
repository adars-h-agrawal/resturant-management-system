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
    public partial class Form5 : Form
    {
        OracleConnection conn;
        public Form5()
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

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectDB();
            try
            {
                OracleCommand command1 = conn.CreateCommand();
                command1.CommandText = "INSERT INTO CUSTOMER VALUES('" + textBox2.Text + "','" + textBox1.Text + "','" + textBox3.Text + "')";
                command1.CommandType = CommandType.Text;
                command1.ExecuteNonQuery();
                command1.Dispose();
                conn.Close();
                MessageBox.Show("New User Created!, Redirecting to login");
                Form2 frm = new Form2();
                frm.Show();
                this.Hide();
            }
            catch (OracleException ex)
            {
                if (ex.Number == 1)
                {
                    MessageBox.Show("Error: User id already exists");
                }
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }
    }
}
