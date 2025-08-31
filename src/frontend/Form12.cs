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
    public partial class Form12 : Form
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
        string name, role, id;
        public Form12(string name, string role, string id)
        {
            InitializeComponent();
            this.name = name;
            this.role = role;
            this.id = id;
            ConnectDB();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "(select order_id, order_date, id from orders natural join places) union (select order_id, order_date, id from orders natural join manages) order by order_id";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm);
            da.Fill(ds, "Orders");
            OracleCommandBuilder builder = new OracleCommandBuilder(da);
            dataGridView1.DataSource = ds.Tables["Orders"];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 frm = new Form6(name, role, id);
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int selectedOrderId = Convert.ToInt32(selectedRow.Cells["ORDER_ID"].Value);
                string query = "SELECT item_name, quantity, total_price from order_items natural join menu where order_id = :orderID";
                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add("orderID", OracleDbType.Int32).Value = selectedOrderId;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable orderDetails = new DataTable();
                adapter.Fill(orderDetails);
                dataGridView2.DataSource = orderDetails;
            }
            else
            {
                MessageBox.Show("Please select an order from the list on the right.");
            }
        }
    }
}
