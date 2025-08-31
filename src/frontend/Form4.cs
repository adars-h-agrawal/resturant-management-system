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
    public partial class Form4 : Form
    {
        string Name;
        string Role = "None";
        string custID;
        public Form4(string name, string custID)
        {
            InitializeComponent();
            Name = name;
            this.custID = custID;
            label1.Text = "Welcome, " + Name + "!";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form11 frm3 = new Form11(Name, custID);
            frm3.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form9 frm2 = new Form9(Name, Role, custID);
            frm2.Show();
            this.Hide();
        }
    }
}
