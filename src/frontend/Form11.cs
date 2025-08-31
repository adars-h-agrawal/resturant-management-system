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
    public partial class Form11 : Form
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
        string name, id;
        public Form11(string name, string id)
        {
            InitializeComponent();
            this.name = name;
            this.id = id;
            ConnectDB();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "select order_id, order_date from orders natural join places where id = :cust_id order by order_id";
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add("cust_id", OracleDbType.Varchar2).Value = id;
            ds = new DataSet();
            da = new OracleDataAdapter(comm);
            da.Fill(ds, "Orders");
            OracleCommandBuilder builder = new OracleCommandBuilder(da);
            dataGridView1.DataSource = ds.Tables["Orders"];
        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4(name, id);
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
