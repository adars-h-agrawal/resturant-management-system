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
    public partial class Form6 : Form
    {
        string Name;
        string Role;
        string id;
        public Form6(string name, string role, string id)
        {
            InitializeComponent();
            Name = name;
            Role = role;
            this.id = id;
            label1.Text = "Welcome, " + Name + "!";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Role == "Manager")
            {
                Form8 frm1 = new Form8(Name, Role, id);
                frm1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Not authorized!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form12 frm12 = new Form12(Name, Role, id);
            frm12.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Role == "Manager")
            {
                Form7 frm = new Form7(Name, Role, id);
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Not authorized!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form9 frm3 = new Form9(Name, Role, id);
            frm3.Show();
            this.Hide();
        }
    }
}
