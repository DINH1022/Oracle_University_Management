using OUM.Model;
using OUM.Model.enums;
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
    public partial class CourseOpenControl : UserControl
    {
        public CourseOpenControl()
        {
            InitializeComponent();
        }

        private List<Course> courses;
        private OpenCourseDAO openCourseDAO = new OpenCourseDAO();
        private const string HEADERTEXT_MAMM = "MAMM";
        private const string HEADERTEXT_MAHP = "MAHP";
        private const string HEADERTEXT_MAGV = "MAGV";
        private const string HEADERTEXT_HK = "HK";
        private const string HEADERTEXT_NAM = "NAM";




        private string user_role;

        private Dictionary<String, String> HEADERTEXT_TO_NAME = new Dictionary<String, String>()
        {
            {HEADERTEXT_MAMM,"MAMM"},
            {HEADERTEXT_MAHP,"MAHP"},
            {HEADERTEXT_MAGV,"MAGV"},
            {HEADERTEXT_HK,"HK" },
            {HEADERTEXT_NAM,"NAM"}
        };
        private Dictionary<String, String> HEADER_TEXT_TO_DATAPROP = new Dictionary<String, String>()
        {
            {HEADERTEXT_MAMM,"MAMM"},
            {HEADERTEXT_MAHP,"MAHP"},
            {HEADERTEXT_MAGV,"MAGV"},
            {HEADERTEXT_HK,"HK" },
            {HEADERTEXT_NAM,"NAM"}
        };


        private DataGridViewButtonColumn createDeleteBtnColumn()
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn
            {
                HeaderText = "Xóa môn",
                Text = "Xóa môn",
                UseColumnTextForButtonValue = true,
                Name = "DeleteButton"
            };
            return btn;
        }

        private DataGridViewButtonColumn createUpdateBtnColumn()
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn
            {
                HeaderText = "Chỉnh sửa",
                Text = "Chỉnh sửa",
                UseColumnTextForButtonValue = true,
                Name = "UpdateButton"
            };
            return btn;
        }

        private void refreshGridView()
        {
            dataGridView2.Columns.Clear();
            DataGridViewTextBoxColumn MAMMCol = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn MAHPCol = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn MAGVCol = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn HKCol = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn NAMCol = new DataGridViewTextBoxColumn();

            MAMMCol.HeaderText = HEADERTEXT_MAMM;
            MAHPCol.HeaderText = HEADERTEXT_MAHP;
            MAGVCol.HeaderText = HEADERTEXT_MAGV;
            HKCol.HeaderText = HEADERTEXT_HK;
            NAMCol.HeaderText = HEADERTEXT_NAM;

            MAMMCol.DataPropertyName = HEADER_TEXT_TO_DATAPROP[HEADERTEXT_MAMM];
            MAHPCol.DataPropertyName = HEADER_TEXT_TO_DATAPROP[HEADERTEXT_MAHP];
            MAGVCol.DataPropertyName = HEADER_TEXT_TO_DATAPROP[HEADERTEXT_MAGV];
            HKCol.DataPropertyName = HEADER_TEXT_TO_DATAPROP[HEADERTEXT_HK];
            NAMCol.DataPropertyName = HEADER_TEXT_TO_DATAPROP[HEADERTEXT_NAM];

            MAMMCol.Name = HEADERTEXT_TO_NAME[HEADERTEXT_MAMM];
            MAHPCol.Name = HEADERTEXT_TO_NAME[HEADERTEXT_MAHP];
            MAGVCol.Name = HEADERTEXT_TO_NAME[HEADERTEXT_MAGV];
            HKCol.Name = HEADERTEXT_TO_NAME[HEADERTEXT_HK];
            NAMCol.Name = HEADERTEXT_TO_NAME[HEADERTEXT_NAM];

            dataGridView2.Columns.Add(MAMMCol);
            dataGridView2.Columns.Add(MAHPCol);
            dataGridView2.Columns.Add(MAGVCol);
            dataGridView2.Columns.Add(HKCol);
            dataGridView2.Columns.Add(NAMCol);
            if(user_role.Equals(RoleEnum.ROLE_NV_PDT, StringComparison.OrdinalIgnoreCase))
            {
                dataGridView2.Columns.Add(createUpdateBtnColumn());
                dataGridView2.Columns.Add(createDeleteBtnColumn());
            }
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void CourseOpenControl_Load(object sender, EventArgs e)
        {
            user_role=openCourseDAO.GetUserRole();
            if (!user_role.Equals(RoleEnum.ROLE_NV_PDT,StringComparison.OrdinalIgnoreCase))
            {
                addBtn.Visible = false;
            }
            refreshGridView();
            courses = openCourseDAO.getAllCourses();
            dataGridView2.DataSource = courses;

        }
        private bool isClickingGivenColumn(DataGridViewCellEventArgs e,string name)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView2.Columns[name].Index)
            {
                return true;
            }
            return false;
        }
        private bool isClickingUpdate(DataGridViewCellEventArgs e)
        {
            string btnName = "UpdateButton";
            if (isClickingGivenColumn(e, btnName))
            {
                return true;
            }
            return false;
        }
        private bool isClickingDelete(DataGridViewCellEventArgs e)
        {
            string btnName = "DeleteButton";
            if (isClickingGivenColumn(e, btnName))
            {
                return true;
            }
            return false;
        }
        private void refreshData()
        {
            courses = openCourseDAO.getAllCourses();
            dataGridView2.DataSource = courses;
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isClickingDelete(e))
            {
                int rowIndex = e.RowIndex;
                string mamm = dataGridView2.Rows[rowIndex].Cells[HEADERTEXT_TO_NAME[HEADERTEXT_MAMM]].Value?.ToString();
                var res = openCourseDAO.deleteCourse(mamm);
                MessageBox.Show(res);
                refreshData();
                return;
            }
            if (isClickingUpdate(e))
            {
                int rowIndex = e.RowIndex;
                string mamm = dataGridView2.Rows[rowIndex].Cells[HEADERTEXT_TO_NAME[HEADERTEXT_MAMM]].Value?.ToString();
                string mahp = dataGridView2.Rows[rowIndex].Cells[HEADERTEXT_TO_NAME[HEADERTEXT_MAHP]].Value?.ToString();
                string magv = dataGridView2.Rows[rowIndex].Cells[HEADERTEXT_TO_NAME[HEADERTEXT_MAGV]].Value?.ToString();
                string hk = dataGridView2.Rows[rowIndex].Cells[HEADERTEXT_TO_NAME[HEADERTEXT_HK]].Value?.ToString();
                string nam = dataGridView2.Rows[rowIndex].Cells[HEADERTEXT_TO_NAME[HEADERTEXT_NAM]].Value?.ToString();

                Course editingCourse = new Course()
                {
                    MAMM = mamm,
                    MAHP = mahp,
                    MAGV = magv,
                    HK = hk,
                    NAM = nam
                };
                UpdateCourseForm updateCourse = new UpdateCourseForm(editingCourse);
                if(updateCourse.ShowDialog()==DialogResult.OK)
                {
                    refreshData();
                }
                return;
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            string theText = searchTextBox.Text;
            if (theText.Length == 0)
            {
                dataGridView2.DataSource = courses;
                return;
            }
            List<Course> filteredCourses = courses
                .Where(course =>
                        course.MAMM.Contains(theText, StringComparison.OrdinalIgnoreCase)
                        || course.MAHP.Contains(theText, StringComparison.OrdinalIgnoreCase)
                        || course.MAGV.Contains(theText, StringComparison.OrdinalIgnoreCase))
                .ToList();
            dataGridView2.DataSource = filteredCourses;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddCourseForm addCourseForm=new AddCourseForm();
            if (addCourseForm.ShowDialog() == DialogResult.OK)
            {
                refreshData();
            }
        }
    }
}
