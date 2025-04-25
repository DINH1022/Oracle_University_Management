namespace OUM.View
{
    partial class ManageEmployeeControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            oracleDAOBindingSource = new BindingSource(components);
            panel1 = new Panel();
            addBtn = new Button();
            panel4 = new Panel();
            textBox1 = new TextBox();
            FindBtn = new Button();
            panel3 = new Panel();
            label1 = new Label();
            bindingSource1 = new BindingSource(components);
            saveFileDialog1 = new SaveFileDialog();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)oracleDAOBindingSource).BeginInit();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(dataGridView1);
            panel2.Controls.Add(panel1);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1006, 379);
            panel2.TabIndex = 6;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.DataSource = oracleDAOBindingSource;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(0, 112);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1006, 267);
            dataGridView1.TabIndex = 2;
            // 
            // oracleDAOBindingSource
            // 
            oracleDAOBindingSource.DataSource = typeof(Service.DataAccess.OracleDAO);
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(addBtn);
            panel1.Controls.Add(panel4);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 56);
            panel1.Name = "panel1";
            panel1.Size = new Size(1006, 56);
            panel1.TabIndex = 1;
            // 
            // addBtn
            // 
            addBtn.BackColor = Color.PaleGoldenrod;
            addBtn.Dock = DockStyle.Right;
            addBtn.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addBtn.Location = new Point(856, 0);
            addBtn.Margin = new Padding(3, 10, 3, 10);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(148, 54);
            addBtn.TabIndex = 5;
            addBtn.Text = "Thêm";
            addBtn.UseVisualStyleBackColor = false;
            addBtn.Click += addBtn_Click;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(textBox1);
            panel4.Controls.Add(FindBtn);
            panel4.Location = new Point(18, 8);
            panel4.Name = "panel4";
            panel4.Size = new Size(441, 38);
            panel4.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(88, 0);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(351, 36);
            textBox1.TabIndex = 2;
            // 
            // FindBtn
            // 
            FindBtn.BackColor = Color.PaleGoldenrod;
            FindBtn.Dock = DockStyle.Left;
            FindBtn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FindBtn.Location = new Point(0, 0);
            FindBtn.Name = "FindBtn";
            FindBtn.Size = new Size(88, 36);
            FindBtn.TabIndex = 0;
            FindBtn.Text = "Tìm kiếm";
            FindBtn.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1006, 56);
            panel3.TabIndex = 0;
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(18, 12);
            label1.Name = "label1";
            label1.Size = new Size(245, 31);
            label1.TabIndex = 0;
            label1.Text = "Danh Sách Nhân Viên";
            // 
            // ManageEmployeeControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Name = "ManageEmployeeControl";
            Size = new Size(1006, 379);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)oracleDAOBindingSource).EndInit();
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Panel panel1;
        private Button addBtn;
        private Panel panel4;
        private TextBox textBox1;
        private Button FindBtn;
        private Panel panel3;
        private Label label1;
        private SaveFileDialog saveFileDialog1;
        private BindingSource bindingSource1;
        private DataGridView dataGridView1;
        private BindingSource oracleDAOBindingSource;
    }
}
