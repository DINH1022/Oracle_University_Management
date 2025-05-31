using OUM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OUM.View.RegistrationCourseView;
using Oracle.ManagedDataAccess.Client;
using OUM.Service.DataAccess;
namespace OUM.View
{
    public partial class UserNavBar : Form
    {
        private OracleDAO dao;
        private List<string> roles;
        private Dictionary<string, (Button button, Action clickAction)> allButtons;
        public UserNavBar()
        {
            InitializeComponent();
            dao = new OracleDAO();
            roles = dao.GetUserRoles();
            InitializeButtons();
            SetupUIBasedOnRole();

        }

        private void InitializeButtons()
        {
            allButtons = new Dictionary<string, (Button, Action)>
            {
                ["ManageStudent"] = (CreateButton("Quản lý Sinh viên", StudentBtn_Click), () => LoadControl(new ManageStudentControl())),
                ["ManageEmployee"] = (CreateButton("Quản lý Nhân viên", EmpBtn_Click), () => LoadControl(new ManageEmployeeControl())),
                ["Notice"] = (CreateButton("Thông báo", NoticeBtn_Click), () => LoadControl(new NoticeControl())),
                ["StudentRegister"] = (CreateButton("Đăng ký học phần", Regiterbutton_Click), () => LoadControl(new RegistrationCoursePageControl())),
                ["Course"] = (CreateButton("Quản lý mở môn", Coursebutton_Click), () => LoadControl(new CourseOpenControl())),
                ["ManagerCourse"] = (CreateButton("Quản lý học phần", ManagerCourse), () => LoadControl(new PDTManagementRegistrationCourse())),
                ["UpdateGrade"] = (CreateButton("Cập nhật điểm SV", UpdateGrade), () => LoadControl(new UpdateStudentGrade())),
                ["CourseGrade"] = (CreateButton("Danh sách lớp", CourseGrade), () => LoadControl(new TeacherRegistrationCourse())),
                ["Info"] = (CreateButton("Thông tin cá nhân", InfoBtn_Click), () => LoadControl(new Account())),
                //["Logout"] = (CreateButton("Đăng xuất", LogoutBtn_Click), () => { this.Close(); new LoginPage().Show(); })
            };
        }
        private Button CreateButton(string text, EventHandler clickHandler)
        {
            Button btn = new Button
            {
                Text = text,
                Size = new Size(208, 40),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.LightBlue,
                ForeColor = Color.Black,
                Font = new Font("Arial", 10, FontStyle.Regular),
                Margin = new Padding(0,15,0,15),
                UseVisualStyleBackColor = false
            };

            btn.Click += clickHandler;
            return btn;
        }
        private void SetupUIBasedOnRole()
        {
            flowLayoutPanel2.Controls.Clear();
            List<string> buttonKeysToShow = GetButtonKeysForRole();
            foreach (string key in buttonKeysToShow)
            {
                if (allButtons.ContainsKey(key))
                {
                    flowLayoutPanel2.Controls.Add(allButtons[key].button);
                }
            }
        }

        private List<string> GetButtonKeysForRole()
        {
            if (roles.Contains("ROLE_SV"))
            {
                return new List<string> { "Info", "Course", "StudentRegister", "Notice" };
            }
            else if(roles.Contains("ROLE_GV"))
            {
                return new List<string> { "Info", "Course", "ManageStudent", "CourseGrade", "Notice" };
            }
            else if (roles.Contains("ROLE_NVCB"))
            {
                return new List<string> { "Info", "Notice" };
            }
            else if (roles.Contains("ROLE_NV_PĐT"))
            {
                return new List<string> { "Info", "Course", "ManageStudent", "ManagerCourse", "Notice" };

            }
            else if (roles.Contains("ROLE_NV_PKT"))
            {
                return new List<string> { "Info", "UpdateGrade", "Notice" };
            }
            else if (roles.Contains("ROLE_NV_TCHC"))
            {
                return new List<string> { "Info", "ManageEmployee", "Notice" };

            }
            else if (roles.Contains("ROLE_NV_CTSV"))
            {
                return new List<string> { "Info", "ManageStudent", "Notice" };
            }
            else if (roles.Contains("ROLE_TRGDV"))
            {
                return new List<string> { "Info", "ManageEmployee", "Course", "Notice" };

            }
            else
            {
                return new List<string> { "Info", "ManageEmployee", "ManageStudent", "Notice" };

            }
        }
        private void LoadControl(UserControl control)
        {
            panelMain.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelMain.Controls.Add(control);
        }

        private void InfoBtn_Click(object sender, EventArgs e)
        {
            LoadControl(new Account());
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
        }

        private void StudentBtn_Click(object sender, EventArgs e)
        {
            LoadControl(new ManageStudentControl());
        }

        private void EmpBtn_Click(object sender, EventArgs e)
        {
            LoadControl(new ManageEmployeeControl());
        }

        private void Coursebutton_Click(object sender, EventArgs e)
        {
            LoadControl(new CourseOpenControl());
        }

        private void Regiterbutton_Click(object sender, EventArgs e)
        {
            LoadControl(new RegistrationCoursePageControl());
        }

        private void NoticeBtn_Click(object sender, EventArgs e)
        {
            LoadControl(new NoticeControl());
        }

        private void ManagerCourse(object sender, EventArgs e)
        {
            LoadControl(new PDTManagementRegistrationCourse());
        }

        private void UpdateGrade(object sender, EventArgs e)
        {
            LoadControl(new UpdateStudentGrade());
        }

        private void CourseGrade(object sender, EventArgs e)
        {
            LoadControl(new TeacherRegistrationCourse());
        }
    }
}
