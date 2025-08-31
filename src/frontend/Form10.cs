using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_form
{
    public partial class Form10 : Form
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
        int orderID, billID;
        string Name, Role, id;
        private void UpdateTotalLabel()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["total_price"].Value != null)
                {
                    decimal rowTotal;
                    if (decimal.TryParse(row.Cells["total_price"].Value.ToString(), out rowTotal))
                    {
                        total += rowTotal;
                    }
                }
            }
            decimal tax = 0.18m * total;
            label3.Text = $"Tax: ₹{tax}";
            decimal FTotal = total + tax;
            label4.Text = $"Total: ₹{FTotal}";
        }
        public Form10(int orderID, int billID, string Name, string Role, string id)
        {
            InitializeComponent();
            this.orderID = orderID;
            this.billID = billID;
            this.Name = Name;
            this.Role = Role;
            this.id = id;
            ConnectDB();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "SELECT item_name, quantity, price, total_price FROM order_items NATURAL JOIN menu WHERE order_id = :orderID";
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add("orderID", orderID);
            ds = new DataSet();
            da = new OracleDataAdapter(comm);
            da.Fill(ds, "Order");
            OracleCommandBuilder builder = new OracleCommandBuilder(da);
            dataGridView1.DataSource = ds.Tables["Order"];
            UpdateTotalLabel();
        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal totalAmount = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["total_price"].Value != null)
                {
                    decimal rowTotal;
                    if (decimal.TryParse(row.Cells["total_price"].Value.ToString(), out rowTotal))
                    {
                        totalAmount += rowTotal;
                    }
                }
            }

            decimal tax = Math.Round(totalAmount * 0.18m); 
            decimal finalTotal = totalAmount + tax;

            try
            {
                string insertQuery = "INSERT INTO bill (bill_id, total_amount, tax) VALUES (:bill_id, :total_amount, :tax)";

                using (OracleCommand insertCmd = new OracleCommand(insertQuery, conn))
                {
                    insertCmd.Parameters.Add("bill_id", OracleDbType.Int32).Value = billID;
                    insertCmd.Parameters.Add("total_amount", OracleDbType.Decimal).Value = finalTotal;
                    insertCmd.Parameters.Add("tax", OracleDbType.Decimal).Value = tax;

                    int rowsAffected = insertCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Bill saved successfully!, Thank you", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if(Role == "None") 
                        {
                            Form4 frm2= new Form4(Name, id);
                            frm2.Show();
                            this.Hide();
                        }
                        else 
                        {
                            Form6 frm = new Form6(Name, Role, id);
                            frm.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bill was not saved. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving bill: " + ex.Message);
            }
        }
    }
}
