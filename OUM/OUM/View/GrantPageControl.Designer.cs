namespace OUM.View
{
    partial class GrantPageControl
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
            panelGrant = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            userRoleBtn = new Button();
            privilegeRoleBtn = new Button();
            privilegeUserBtn = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelGrant
            // 
            panelGrant.Dock = DockStyle.Fill;
            panelGrant.Location = new Point(0, 0);
            panelGrant.Name = "panelGrant";
            panelGrant.Size = new Size(1073, 588);
            panelGrant.TabIndex = 0;
            panelGrant.Paint += panel1_Paint;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(userRoleBtn, 2, 0);
            tableLayoutPanel1.Controls.Add(privilegeRoleBtn, 1, 0);
            tableLayoutPanel1.Controls.Add(privilegeUserBtn, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1073, 50);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // userRoleBtn
            // 
            userRoleBtn.Dock = DockStyle.Fill;
            userRoleBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            userRoleBtn.Location = new Point(717, 3);
            userRoleBtn.Name = "userRoleBtn";
            userRoleBtn.Size = new Size(353, 44);
            userRoleBtn.TabIndex = 2;
            userRoleBtn.Text = "Vai trò người dùng";
            userRoleBtn.UseVisualStyleBackColor = true;
            // 
            // privilegeRoleBtn
            // 
            privilegeRoleBtn.Dock = DockStyle.Fill;
            privilegeRoleBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            privilegeRoleBtn.Location = new Point(360, 3);
            privilegeRoleBtn.Name = "privilegeRoleBtn";
            privilegeRoleBtn.Size = new Size(351, 44);
            privilegeRoleBtn.TabIndex = 1;
            privilegeRoleBtn.Text = "Quyền vai trò";
            privilegeRoleBtn.UseVisualStyleBackColor = true;
            // 
            // privilegeUserBtn
            // 
            privilegeUserBtn.Dock = DockStyle.Fill;
            privilegeUserBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            privilegeUserBtn.Location = new Point(3, 3);
            privilegeUserBtn.Name = "privilegeUserBtn";
            privilegeUserBtn.Size = new Size(351, 44);
            privilegeUserBtn.TabIndex = 0;
            privilegeUserBtn.Text = "Quyền người dùng";
            privilegeUserBtn.UseVisualStyleBackColor = true;
            privilegeUserBtn.Click += privilegeUserBtn_Click;
            // 
            // GrantPageControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panelGrant);
            Name = "GrantPageControl";
            Size = new Size(1073, 588);
            Load += GrantPageControl_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelGrant;
        private TableLayoutPanel tableLayoutPanel1;
        private Button userRoleBtn;
        private Button privilegeRoleBtn;
        private Button privilegeUserBtn;
    }
}
