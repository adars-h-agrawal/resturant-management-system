using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_form
{
    public partial class Form7 : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        DataSet ds;
        DataTable dt;
        OracleDataAdapter da;
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
        string Name;
        string Role;
        string id;
        public Form7(string name, string role, string id)
        {
            InitializeComponent();
            Name = name;
            Role = role;
            this.id = id;
            ConnectDB();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "select * from staff order by staff_id";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Staff");
            OracleCommandBuilder builder = new OracleCommandBuilder(da);
            dataGridView1.DataSource = ds.Tables["Staff"];
            this.id = id;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form6 frm = new Form6(Name, Role, id);
            frm.Show();
            this.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                da.Update(ds, "Staff");
                MessageBox.Show("Changes saved to the database successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving changes: " + ex.Message);
            }
            Form6 frm = new Form6(Name, Role, id);
            frm.Show();
            this.Hide();
        }
    }
}
