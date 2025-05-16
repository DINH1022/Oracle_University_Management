using OUM.Model;
using OUM.Service.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OUM.View
{
    public partial class AddCourseForm : Form
    {
        public AddCourseForm()
        {
            InitializeComponent();
        }
        OpenCourseDAO openCourseDAO = new OpenCourseDAO();
        private List<int> termLists = new List<int>() { 1, 2, 3 };
        private List<string> teacherIds = new List<string>();
        private List<string> courseIds = new List<string>();

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
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

        private void AddCourseForm_Load_1(object sender, EventArgs e)
        {
            teacherIds = openCourseDAO.getAllTeacherIDs();
            courseIds = openCourseDAO.getAllCourseIDs();
            comboBox1.DataSource = courseIds;
            comboBox2.DataSource = teacherIds;
            comboBox1.SelectedItem = courseIds[0];
            comboBox2.SelectedItem = teacherIds[0];
            int currentTerm = compute_current_Term();
            textBox3.Text = currentTerm.ToString();
            int currentYear = compute_current_Year();
            textBox2.Text = currentYear.ToString();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
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
            string mahp = comboBox1.SelectedItem.ToString();
            string magv = comboBox2.SelectedItem.ToString();
            string hk = textBox3.Text;
            string year = textBox2.Text;//too lazy to change the name :))
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
                var saved = openCourseDAO.create(newCourse);
                if (saved == null)
                {
                    MessageBox.Show("Thêm thất bại, vui lòng thử lại sau!!!");
                }
                else
                {
                    MessageBox.Show("Thêm thành công");
                    this.DialogResult = DialogResult.OK;

                }
                this.Close();
                return;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
