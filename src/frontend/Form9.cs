using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Login_form
{
    public partial class Form9 : Form
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
        private void UpdateTotalLabel()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells["Total"].Value != null)
                {
                    decimal rowTotal;
                    if (decimal.TryParse(row.Cells["Total"].Value.ToString(), out rowTotal))
                    {
                        total += rowTotal;
                    }
                }
            }

            label4.Text = $"Total: ₹{total}";
        }
        public Form9(string name, string role, string id)
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
            if (dataGridView2.Columns.Count == 0)
            {
                dataGridView2.Columns.Add("Item_Name", "Item Name");
                dataGridView2.Columns.Add("Quantity", "Quantity");
                dataGridView2.Columns.Add("Price", "Price");
                dataGridView2.Columns.Add("Total", "Total");
            }
            UpdateTotalLabel();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = comboBox1.SelectedItem.ToString();
            OracleCommand cmd;
            if (selectedCategory == "All")
            {
                cmd = new OracleCommand("SELECT * FROM menu order by item_no", conn);
            }
            else
            {
                cmd = new OracleCommand("SELECT * FROM menu WHERE category = :cat order by item_no", conn);
                cmd.Parameters.Add("cat", selectedCategory);
            }

            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            DataTable filteredTable = new DataTable();
            adapter.Fill(filteredTable);

            dataGridView1.DataSource = filteredTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string itemName = dataGridView1.CurrentRow.Cells["Item_Name"].Value.ToString();
                decimal price = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Price"].Value);

                bool itemFound = false;

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Cells["Item_Name"].Value != null && row.Cells["Item_Name"].Value.ToString() == itemName)
                    {
                        int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                        quantity++;
                        row.Cells["Quantity"].Value = quantity;
                        row.Cells["Total"].Value = quantity * price;
                        itemFound = true;
                        break;
                    }
                }

                if (!itemFound)
                {
                    dataGridView2.Rows.Add(itemName, 1, price, price);
                }
            }
            UpdateTotalLabel();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView2.CurrentRow;

            if (selectedRow != null && !selectedRow.IsNewRow)
            {
                int quantity = Convert.ToInt32(selectedRow.Cells["Quantity"].Value);

                if (quantity > 1)
                {
                    quantity--;
                    selectedRow.Cells["Quantity"].Value = quantity;

                    decimal price = Convert.ToDecimal(selectedRow.Cells["Price"].Value);
                    selectedRow.Cells["Total"].Value = quantity * price;
                }
                else
                {
                    dataGridView2.Rows.Remove(selectedRow);
                }
            }
            else
            {
                MessageBox.Show("Please select an item from your order to remove.");
            }
            UpdateTotalLabel();
        }
        private int GetNextOrderId()
        {
            int nextId = 1;

            using (OracleCommand cmd = new OracleCommand("SELECT NVL(MAX(order_id), 0) + 1 FROM order_items", conn))
            {
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    nextId = Convert.ToInt32(result);
                }
            }

            return nextId;
        }
        private int GetNextBillId()
        {
            int nextBillId = 1;

            using (OracleCommand cmd = new OracleCommand("SELECT NVL(MAX(bill_id), 0) + 1 FROM orders", conn))
            {
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    nextBillId = Convert.ToInt32(result);
                }
            }

            return nextBillId;
        }
        private string GetItemNumberByName(string itemName)
        {
            foreach (DataRow row in ds.Tables["Menu"].Rows)
            {
                if (row["item_name"].ToString() == itemName)
                {
                    return row["item_no"].ToString();
                }
            }
            throw new Exception("Item number not found for: " + itemName);
        }

        private void SaveOrderToDatabase()
        {
            int orderId = GetNextOrderId();
            int billId = GetNextBillId();
            DateTime orderDate = DateTime.Now;

            using (OracleTransaction transaction = conn.BeginTransaction())
            {
                try
                {
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string itemNo = GetItemNumberByName(row.Cells["Item_Name"].Value.ToString());
                        int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                        decimal total = Convert.ToDecimal(row.Cells["Total"].Value);

                        string query = "INSERT INTO order_items (order_id, item_no, quantity, total_price) " +
                                       "VALUES (:order_id, :item_no, :quantity, :total_price)";

                        using (OracleCommand cmd = new OracleCommand(query, conn))
                        {
                            cmd.Transaction = transaction;
                            cmd.Parameters.Add("order_id", OracleDbType.Int32).Value = orderId;
                            cmd.Parameters.Add("item_no", OracleDbType.Varchar2).Value = itemNo;
                            cmd.Parameters.Add("quantity", OracleDbType.Int32).Value = quantity;
                            cmd.Parameters.Add("total_price", OracleDbType.Decimal).Value = total;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    string orderInsert = "INSERT INTO orders (order_id, bill_id, order_date) " +
                                         "VALUES (:order_id, :bill_id, :order_date)";

                    using (OracleCommand cmd = new OracleCommand(orderInsert, conn))
                    {
                        cmd.Transaction = transaction;
                        cmd.Parameters.Add("order_id", OracleDbType.Int32).Value = orderId;
                        cmd.Parameters.Add("bill_id", OracleDbType.Int32).Value = billId;
                        cmd.Parameters.Add("order_date", OracleDbType.Date).Value = orderDate;
                        cmd.ExecuteNonQuery();
                    }
                    if (Role == "None")
                    {
                        string placesInsert = "INSERT INTO places VALUES (:cust_id, :order_id)";
                        using (OracleCommand cmd = new OracleCommand(placesInsert, conn))
                        {
                            cmd.Transaction = transaction;
                            cmd.Parameters.Add("cust_id", OracleDbType.Varchar2).Value = id;
                            cmd.Parameters.Add("order_id", OracleDbType.Int32).Value = orderId;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string managesInsert = "INSERT INTO manages VALUES (:staff_id, :order_id)";
                        using (OracleCommand cmd = new OracleCommand(managesInsert, conn))
                        {
                            cmd.Transaction = transaction;
                            cmd.Parameters.Add("staff_id", OracleDbType.Varchar2).Value = id;
                            cmd.Parameters.Add("order_id", OracleDbType.Int32).Value = orderId;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                    decimal orderTotal = 0;
                    using (OracleCommand totalCmd = new OracleCommand("BEGIN :total := get_order_total(:order_id); END;", conn))
                    {
                        totalCmd.Parameters.Add("total", OracleDbType.Decimal).Direction = ParameterDirection.Output;
                        totalCmd.Parameters.Add("order_id", OracleDbType.Int32).Value = orderId;
                        totalCmd.ExecuteNonQuery();

                        orderTotal = ((Oracle.ManagedDataAccess.Types.OracleDecimal)totalCmd.Parameters["total"].Value).Value;
                    }
                    MessageBox.Show($"Order #{orderId} placed successfully!\nTotal Amount: ₹{orderTotal}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView2.Rows.Clear();
                    UpdateTotalLabel();

                    Form10 frm4 = new Form10(orderId, billId, Name, Role, id);
                    frm4.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    try
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            transaction.Rollback();
                        }
                    }
                    catch (Exception rollbackEx)
                    {
                        MessageBox.Show("Rollback failed: " + rollbackEx.Message);
                    }
                    MessageBox.Show("Failed to save order: " + ex.Message);
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 1)
            {
                SaveOrderToDatabase();
            }
            else
            {
                MessageBox.Show("No items in the order!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Role == "None")
            {
                Form4 frm2 = new Form4(Name, id);
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

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            decimal cap = numericUpDown1.Value;
            string cat = comboBox1.SelectedItem?.ToString() ?? "All";
            string query = "SELECT * FROM (SELECT * FROM menu WHERE :cat = 'All' OR category = :cat) WHERE price <= :cap ORDER BY item_no";
            using (OracleCommand cmd = new OracleCommand(query, conn))
            {
                cmd.BindByName = true;
                cmd.Parameters.Add("cat", OracleDbType.Varchar2).Value = cat;
                cmd.Parameters.Add("cap", OracleDbType.Decimal).Value = cap;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable filteredTable = new DataTable();
                adapter.Fill(filteredTable);

                dataGridView1.DataSource = filteredTable;
            }
        }

    }
}

