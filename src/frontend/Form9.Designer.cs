namespace Login_form
{
    partial class Form9
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form9));
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            comboBox1 = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label4 = new Label();
            label1 = new Label();
            label3 = new Label();
            label2 = new Label();
            button4 = new Button();
            numericUpDown1 = new NumericUpDown();
            label5 = new Label();
            label6 = new Label();
            button5 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(28, 277);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(477, 337);
            dataGridView1.TabIndex = 4;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(565, 277);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(481, 337);
            dataGridView2.TabIndex = 5;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "All", "Starters", "Soup", "Salad", "North Ind", "Breads", "Rice", "South Ind", "Beverages", "Sweets", "Ice Cream" });
            comboBox1.Location = new Point(48, 227);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(183, 28);
            comboBox1.TabIndex = 6;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(170, 120, 74);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ImageAlign = ContentAlignment.BottomCenter;
            button1.Location = new Point(226, 620);
            button1.Name = "button1";
            button1.Size = new Size(99, 39);
            button1.TabIndex = 7;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(170, 120, 74);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ImageAlign = ContentAlignment.BottomCenter;
            button2.Location = new Point(637, 620);
            button2.Name = "button2";
            button2.Size = new Size(99, 39);
            button2.TabIndex = 8;
            button2.Text = "Remove";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Red;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ImageAlign = ContentAlignment.BottomCenter;
            button3.Location = new Point(865, 620);
            button3.Name = "button3";
            button3.Size = new Size(99, 39);
            button3.TabIndex = 9;
            button3.Text = "Done";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(797, 227);
            label4.Name = "label4";
            label4.Size = new Size(65, 28);
            label4.TabIndex = 10;
            label4.Text = "label4";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Vivaldi", 28.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Image = (Image)resources.GetObject("label1.Image");
            label1.Location = new Point(439, 25);
            label1.Name = "label1";
            label1.Size = new Size(261, 55);
            label1.TabIndex = 11;
            label1.Text = "Digital Dine";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Vivaldi", 28.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Image = (Image)resources.GetObject("label3.Image");
            label3.Location = new Point(194, 129);
            label3.Name = "label3";
            label3.Size = new Size(141, 55);
            label3.TabIndex = 12;
            label3.Text = "Menu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Vivaldi", 28.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Image = (Image)resources.GetObject("label2.Image");
            label2.Location = new Point(703, 129);
            label2.Name = "label2";
            label2.Size = new Size(250, 55);
            label2.TabIndex = 13;
            label2.Text = "Your Order";
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(170, 120, 74);
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ImageAlign = ContentAlignment.BottomCenter;
            button4.Location = new Point(12, 83);
            button4.Name = "button4";
            button4.Size = new Size(99, 39);
            button4.TabIndex = 14;
            button4.Text = "<Back";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(355, 225);
            numericUpDown1.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(150, 27);
            numericUpDown1.TabIndex = 15;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Vivaldi", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.Image = (Image)resources.GetObject("label5.Image");
            label5.Location = new Point(93, 191);
            label5.Name = "label5";
            label5.Size = new Size(107, 33);
            label5.TabIndex = 16;
            label5.Text = "Category";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Vivaldi", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label6.Image = (Image)resources.GetObject("label6.Image");
            label6.Location = new Point(355, 189);
            label6.Name = "label6";
            label6.Size = new Size(150, 33);
            label6.TabIndex = 17;
            label6.Text = "Price Filter";
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(192, 64, 0);
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.ImageAlign = ContentAlignment.BottomCenter;
            button5.Location = new Point(511, 225);
            button5.Name = "button5";
            button5.Size = new Size(50, 27);
            button5.TabIndex = 18;
            button5.Text = "Go";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // Form9
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1078, 668);
            Controls.Add(button5);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(numericUpDown1);
            Controls.Add(button4);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Name = "Form9";
            Text = "Form9";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private ComboBox comboBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label4;
        private Label label1;
        private Label label3;
        private Label label2;
        private Button button4;
        private NumericUpDown numericUpDown1;
        private Label label5;
        private Label label6;
        private Button button5;
    }
}