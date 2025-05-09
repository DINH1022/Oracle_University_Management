namespace OUM.View.RegistrationCourseView
{
    partial class RegisteredCoursePage
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
            listRegisteredCourses = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)listRegisteredCourses).BeginInit();
            SuspendLayout();
            // 
            // listRegisteredCourses
            // 
            listRegisteredCourses.BackgroundColor = Color.White;
            listRegisteredCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            listRegisteredCourses.Dock = DockStyle.Fill;
            listRegisteredCourses.Location = new Point(0, 0);
            listRegisteredCourses.Name = "listRegisteredCourses";
            listRegisteredCourses.RowHeadersWidth = 51;
            listRegisteredCourses.Size = new Size(1058, 750);
            listRegisteredCourses.TabIndex = 0;
            // 
            // RegisteredCoursePage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(listRegisteredCourses);
            Name = "RegisteredCoursePage";
            Size = new Size(1058, 750);
            ((System.ComponentModel.ISupportInitialize)listRegisteredCourses).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView listRegisteredCourses;
    }
}
