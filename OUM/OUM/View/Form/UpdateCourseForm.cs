using OUM.Model;
using OUM.Service.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OUM.View
{
    public partial class UpdateCourseForm : Form
    {
        private Course currentCourse;
        private OpenCourseDAO openCourseDAO = new OpenCourseDAO();
        private List<int> termLists = new List<int>() { 1, 2, 3 };
        private List<string> teacherIds = new List<string>();
        private List<string> courseIds = new List<string>();
        public UpdateCourseForm(Course course)
        {
            InitializeComponent();
            currentCourse = course;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private int compute_current_Term()
        {
            int month = DateTime.Now.Month;
            if (month >= 9 && month <= 12)
            {
                return 1;
            }
            if (month >= 1 && month <= 4)
            {
                return 2;
            }
            return 3;
        }

        private int compute_current_Year()
        {
            return DateTime.Now.Year;
        }
        private void mapDataToDisplaying()
        {
            txtMaMM.Text = currentCourse.MAMM;
            comboBox2.SelectedItem = currentCourse.MAHP;
            comboBox3.SelectedItem = currentCourse.MAGV;
            textBox1.Text = currentCourse.HK;
            txtNam.Text = currentCourse.NAM;
        }

        private void initCombboxRanges()
        {
            teacherIds = openCourseDAO.getAllTeacherIDs();
            courseIds = openCourseDAO.getAllCourseIDs();
            comboBox2.DataSource = courseIds;
            comboBox3.DataSource = teacherIds;
        }

        private void UpdateCourseForm_Load(object sender, EventArgs e)
        {
            initCombboxRanges();
            mapDataToDisplaying();
        }

        private void txtMaMM_TextChanged(object sender, EventArgs e)
        {

        }
        private string getMessageError(string mahp, string magv, string hk, string year)
        {
            bool isYearInputValid = int.TryParse(year, out int result);
            if (!isYearInputValid)
            {
                return "Nhập năm là một số nguyên";
            }
            return "";
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            string mahp = comboBox2.SelectedItem.ToString();
            string magv = comboBox3.SelectedItem.ToString();
            string hk = textBox1.Text;
            string year = txtNam.Text;
            string msg = getMessageError(mahp, magv, hk, year);
            Course newCourse = new Course()
            {
                MAHP = mahp,
                MAGV = magv,
                HK = hk,
                NAM = year
            };
            if (msg.Length != 0)
            {
                MessageBox.Show(msg);
            }
            else
            {
                var saved = openCourseDAO.updateCourse(currentCourse.MAMM, newCourse);
                if (saved == null)
                {
                    MessageBox.Show("Sửa thất bại, vui lòng thử lại sau!!!");
                }
                else
                {
                    MessageBox.Show("Cập nhật thành công thành công");
                    this.DialogResult = DialogResult.OK;

                }
                this.Close();
                return;
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNam_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //hk
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
