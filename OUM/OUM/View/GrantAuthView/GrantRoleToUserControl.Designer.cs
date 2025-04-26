namespace OUM.View.GrantAuthView
{
    partial class GrantRoleToUserControl
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
            listUserDataGridView = new DataGridView();
            panel1 = new Panel();
            label1 = new Label();
            panel3 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel5 = new Panel();
            roleSearchInput = new TextBox();
            button2 = new Button();
            panel2 = new Panel();
            userSearchInput = new TextBox();
            button1 = new Button();
            listRoleDataGridView = new DataGridView();
            panel4 = new Panel();
            withAdminOptionCB = new CheckBox();
            panel6 = new Panel();
            grantPrivilegeBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)listUserDataGridView).BeginInit();
            panel3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel5.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)listRoleDataGridView).BeginInit();
            panel4.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // listUserDataGridView
            // 
            listUserDataGridView.BackgroundColor = Color.White;
            listUserDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            listUserDataGridView.Dock = DockStyle.Fill;
            listUserDataGridView.EnableHeadersVisualStyles = false;
            listUserDataGridView.Location = new Point(3, 46);
            listUserDataGridView.Name = "listUserDataGridView";
            listUserDataGridView.RowHeadersWidth = 51;
            listUserDataGridView.Size = new Size(523, 167);
            listUserDataGridView.TabIndex = 12;
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.BorderStyle = BorderStyle.FixedSingle;
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
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel5, 1, 0);
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Controls.Add(listUserDataGridView, 0, 1);
            tableLayoutPanel1.Controls.Add(listRoleDataGridView, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 112);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 173F));
            tableLayoutPanel1.Size = new Size(1058, 216);
            tableLayoutPanel1.TabIndex = 13;
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(roleSearchInput);
            panel5.Controls.Add(button2);
            panel5.Location = new Point(532, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(441, 37);
            panel5.TabIndex = 15;
            // 
            // roleSearchInput
            // 
            roleSearchInput.Dock = DockStyle.Fill;
            roleSearchInput.Location = new Point(88, 0);
            roleSearchInput.Multiline = true;
            roleSearchInput.Name = "roleSearchInput";
            roleSearchInput.Size = new Size(351, 35);
            roleSearchInput.TabIndex = 2;
            // 
            // button2
            // 
            button2.BackColor = Color.PaleGoldenrod;
            button2.Dock = DockStyle.Left;
            button2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(0, 0);
            button2.Name = "button2";
            button2.Size = new Size(88, 35);
            button2.TabIndex = 0;
            button2.Text = "Tìm kiếm";
            button2.UseVisualStyleBackColor = false;
            button2.Click += roleSearchBtn;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(userSearchInput);
            panel2.Controls.Add(button1);
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(441, 37);
            panel2.TabIndex = 14;
            // 
            // userSearchInput
            // 
            userSearchInput.Dock = DockStyle.Fill;
            userSearchInput.Location = new Point(88, 0);
            userSearchInput.Multiline = true;
            userSearchInput.Name = "userSearchInput";
            userSearchInput.Size = new Size(351, 35);
            userSearchInput.TabIndex = 2;
            // 
            // button1
            // 
            button1.BackColor = Color.PaleGoldenrod;
            button1.Dock = DockStyle.Left;
            button1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(0, 0);
            button1.Name = "button1";
            button1.Size = new Size(88, 35);
            button1.TabIndex = 0;
            button1.Text = "Tìm kiếm";
            button1.UseVisualStyleBackColor = false;
            button1.Click += userSearchBtn;
            // 
            // listRoleDataGridView
            // 
            listRoleDataGridView.BackgroundColor = Color.White;
            listRoleDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            listRoleDataGridView.Dock = DockStyle.Fill;
            listRoleDataGridView.EnableHeadersVisualStyles = false;
            listRoleDataGridView.Location = new Point(532, 46);
            listRoleDataGridView.Name = "listRoleDataGridView";
            listRoleDataGridView.RowHeadersWidth = 51;
            listRoleDataGridView.Size = new Size(523, 167);
            listRoleDataGridView.TabIndex = 13;
            // 
            // panel4
            // 
            panel4.Controls.Add(withAdminOptionCB);
            panel4.Controls.Add(panel6);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 328);
            panel4.Name = "panel4";
            panel4.Size = new Size(1058, 115);
            panel4.TabIndex = 14;
            // 
            // withAdminOptionCB
            // 
            withAdminOptionCB.AutoSize = true;
            withAdminOptionCB.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            withAdminOptionCB.Location = new Point(19, 21);
            withAdminOptionCB.Name = "withAdminOptionCB";
            withAdminOptionCB.Size = new Size(206, 32);
            withAdminOptionCB.TabIndex = 10;
            withAdminOptionCB.Text = "With Admin Option";
            withAdminOptionCB.UseVisualStyleBackColor = true;
            withAdminOptionCB.CheckedChanged += withAdminOptionCB_CheckedChanged;
            // 
            // panel6
            // 
            panel6.Controls.Add(grantPrivilegeBtn);
            panel6.Dock = DockStyle.Bottom;
            panel6.Location = new Point(0, 71);
            panel6.Name = "panel6";
            panel6.Size = new Size(1058, 44);
            panel6.TabIndex = 2;
            // 
            // grantPrivilegeBtn
            // 
            grantPrivilegeBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grantPrivilegeBtn.Location = new Point(19, 3);
            grantPrivilegeBtn.Name = "grantPrivilegeBtn";
            grantPrivilegeBtn.Size = new Size(177, 44);
            grantPrivilegeBtn.TabIndex = 1;
            grantPrivilegeBtn.Text = "Cấp quyền";
            grantPrivilegeBtn.UseVisualStyleBackColor = true;
            grantPrivilegeBtn.Click += grantPrivilegeBtn_Click;
            // 
            // GrantRoleToUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel4);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Name = "GrantRoleToUserControl";
            Size = new Size(1058, 750);
            ((System.ComponentModel.ISupportInitialize)listUserDataGridView).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)listRoleDataGridView).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel6.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView listUserDataGridView;
        private Panel panel1;
        private Label label1;
        private Panel panel3;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel5;
        private TextBox roleSearchInput;
        private Button button2;
        private Panel panel2;
        private TextBox userSearchInput;
        private Button button1;
        private DataGridView listRoleDataGridView;
        private Panel panel4;
        private Button grantPrivilegeBtn;
        private Panel panel6;
        private CheckBox withAdminOptionCB;
    }
}
