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
    public partial class Form8 : Form
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
        public Form8(string name, string role, string id)
        {
            InitializeComponent();
            Name = name;
            Role = role;
            this.id = id;
            ConnectDB();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "select * from menu order by item_no";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "Menu");
            OracleCommandBuilder builder = new OracleCommandBuilder(da);
            dataGridView1.DataSource = ds.Tables["Menu"];
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand insertEditorCmd = new OracleCommand("INSERT INTO current_editor (staff_id) VALUES (:id)", conn);
                insertEditorCmd.Parameters.Add(":id", OracleDbType.Varchar2).Value = id;
                insertEditorCmd.ExecuteNonQuery();
                da.Update(ds, "Menu");
                MessageBox.Show("Changes saved to the database successfully.");
                OracleCommand clearEditorCmd = new OracleCommand("DELETE FROM current_editor", conn);
                clearEditorCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving changes: " + ex.Message);
            }
            Form6 frm = new Form6(Name, Role, id);
            frm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form13 frm2 = new Form13(Name, Role, id);
            frm2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 frm3 = new Form6(Name, Role, id);
            frm3.Show();
            this.Hide();
        }
    }
}
