namespace OUM.View.GrantAuthView
{
    partial class GrantRoleControl
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
            panel6 = new Panel();
            grantPrivilegeBtn = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label5 = new Label();
            listObjectDGV = new DataGridView();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label3 = new Label();
            privilegeCombox = new ComboBox();
            panel5 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            label2 = new Label();
            objectsCombox = new ComboBox();
            listRoleDataGridView = new DataGridView();
            textBox1 = new TextBox();
            FindBtn = new Button();
            panel4 = new Panel();
            panel1 = new Panel();
            label1 = new Label();
            panel3 = new Panel();
            ((System.ComponentModel.ISupportInitialize)listObjectDGV).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel5.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)listRoleDataGridView).BeginInit();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel6
            // 
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 607);
            panel6.Name = "panel6";
            panel6.Size = new Size(1058, 223);
            panel6.TabIndex = 15;
            // 
            // grantPrivilegeBtn
            // 
            grantPrivilegeBtn.Dock = DockStyle.Left;
            grantPrivilegeBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grantPrivilegeBtn.Location = new Point(3, 176);
            grantPrivilegeBtn.Name = "grantPrivilegeBtn";
            grantPrivilegeBtn.Size = new Size(177, 46);
            grantPrivilegeBtn.TabIndex = 0;
            grantPrivilegeBtn.Text = "Cấp quyền";
            grantPrivilegeBtn.UseVisualStyleBackColor = true;
            grantPrivilegeBtn.Click += grantPrivilegeBtn_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(3, 48);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(517, 122);
            flowLayoutPanel1.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Bottom;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(3, 12);
            label5.Margin = new Padding(3, 0, 3, 5);
            label5.Name = "label5";
            label5.Size = new Size(517, 28);
            label5.TabIndex = 7;
            label5.Text = "Cột";
            // 
            // listObjectDGV
            // 
            listObjectDGV.BackgroundColor = Color.White;
            listObjectDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            listObjectDGV.Dock = DockStyle.Fill;
            listObjectDGV.Location = new Point(3, 3);
            listObjectDGV.Name = "listObjectDGV";
            listObjectDGV.RowHeadersWidth = 51;
            listObjectDGV.Size = new Size(523, 225);
            listObjectDGV.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(grantPrivilegeBtn, 0, 2);
            tableLayoutPanel3.Controls.Add(flowLayoutPanel1, 0, 1);
            tableLayoutPanel3.Controls.Add(label5, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(532, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 26.01156F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 73.98844F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
            tableLayoutPanel3.Size = new Size(523, 225);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(listObjectDGV, 0, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Top;
            tableLayoutPanel2.Location = new Point(0, 376);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(1058, 231);
            tableLayoutPanel2.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Bottom;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(0, 28);
            label3.Margin = new Padding(3, 0, 3, 5);
            label3.Name = "label3";
            label3.Size = new Size(69, 28);
            label3.TabIndex = 6;
            label3.Text = "Quyền";
            // 
            // privilegeCombox
            // 
            privilegeCombox.Dock = DockStyle.Bottom;
            privilegeCombox.FormattingEnabled = true;
            privilegeCombox.Location = new Point(0, 56);
            privilegeCombox.Name = "privilegeCombox";
            privilegeCombox.Size = new Size(523, 28);
            privilegeCombox.TabIndex = 5;
            // 
            // panel5
            // 
            panel5.Controls.Add(label3);
            panel5.Controls.Add(privilegeCombox);
            panel5.Location = new Point(532, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(523, 84);
            panel5.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel5, 1, 0);
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 286);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1058, 90);
            tableLayoutPanel1.TabIndex = 13;
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Controls.Add(objectsCombox);
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(522, 84);
            panel2.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Bottom;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(0, 28);
            label2.Margin = new Padding(3, 0, 3, 5);
            label2.Name = "label2";
            label2.Size = new Size(102, 28);
            label2.TabIndex = 6;
            label2.Text = "Đối tượng";
            // 
            // objectsCombox
            // 
            objectsCombox.Dock = DockStyle.Bottom;
            objectsCombox.FormattingEnabled = true;
            objectsCombox.Location = new Point(0, 56);
            objectsCombox.Name = "objectsCombox";
            objectsCombox.Size = new Size(522, 28);
            objectsCombox.TabIndex = 5;
            // 
            // listRoleDataGridView
            // 
            listRoleDataGridView.BackgroundColor = Color.White;
            listRoleDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            listRoleDataGridView.Dock = DockStyle.Top;
            listRoleDataGridView.EnableHeadersVisualStyles = false;
            listRoleDataGridView.Location = new Point(0, 112);
            listRoleDataGridView.Name = "listRoleDataGridView";
            listRoleDataGridView.RowHeadersWidth = 51;
            listRoleDataGridView.Size = new Size(1058, 174);
            listRoleDataGridView.TabIndex = 12;
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
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(panel4);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 56);
            panel1.Name = "panel1";
            panel1.Size = new Size(1058, 56);
            panel1.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(18, 12);
            label1.Name = "label1";
            label1.Size = new Size(258, 31);
            label1.TabIndex = 0;
            label1.Text = "Cấp quyền người dùng";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1058, 56);
            panel3.TabIndex = 10;
            // 
            // GrantRoleControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel6);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(listRoleDataGridView);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Name = "GrantRoleControl";
            Size = new Size(1058, 750);
            ((System.ComponentModel.ISupportInitialize)listObjectDGV).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)listRoleDataGridView).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel6;
        private Button grantPrivilegeBtn;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label5;
        private DataGridView listObjectDGV;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label3;
        private ComboBox privilegeCombox;
        private Panel panel5;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private Label label2;
        private ComboBox objectsCombox;
        private DataGridView listRoleDataGridView;
        private TextBox textBox1;
        private Button FindBtn;
        private Panel panel4;
        private Panel panel1;
        private Label label1;
        private Panel panel3;
    }
}
