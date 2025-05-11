using Microsoft.VisualBasic.ApplicationServices;
using Oracle.ManagedDataAccess.Client;
using OUM.Model;
using OUM.Service.DataAccess;
using OUM.Session;
using OUM.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace OUM.View
{

    public partial class Account : UserControl
    {
        private AdminViewModel viewModel;
        // private OracleDAO dao;
        private AccountDAO dao;

        public string
            GetConnectionString()
        {
            return $"User Id={AdminSession.Username};Password={AdminSession.Password};Data Source=localhost:1521/DKHP;";
        }


        public Account()
        {
            InitializeComponent();
            viewModel = new AdminViewModel();
            dao = new AccountDAO();
            this.Load += Account_Load;

        }

        private void Account_Load(object sender, EventArgs e)
        {
            string userId = AdminSession.Username;

            if (userId.StartsWith("SV"))
            {
                var student = dao.GetStudentById(userId);
                DisplayStudentInfo(student);
                lbSalary.Visible = false;
                lbPC.Visible = false;

            }
            else if (userId.StartsWith("NV"))
            {
                var employee = dao.GetEmployeeById(userId);
                DisplayEmployeeInfo(employee);
                txtSalary.Visible = true;
                txtPC.Visible = true;
                txtDC.Visible = false;
                lbDC.Visible = false;
                txtDC.Visible = false;
                lbSalary.Visible = true;
                lbPC.Visible = true;
                txtStatus.Visible = false;
                lbStatus.Visible = false;
                lbSalary.Visible = true;
                lbPC.Visible = true;

                lbKhoa.Location = new Point(465, 202);
                txtKhoa.Location = new Point(588, 203);
            }
            else
            {
                MessageBox.Show("Không tìm thấy người dùng.");
            }

        }

        private void DisplayStudentInfo(Student student)
        {
            if (student != null)
            {
                textBoxUserType.Text = student.id + " - " + student.name;
                txtMa.Text = student.id;
                txtName.Text = student.name;
                txt_gen.Text = student.gender;
                txtPhone.Text = student.phone;
                txtKhoa.Text = student.department;
                txtStatus.Text = student.status;
                txtDC.Text = student.address;
                dateTimePickerdob.Text = student.dob.ToString("yyyy-MM-dd");
            }
        }


        private void DisplayEmployeeInfo(Employee employee)
        {
            if (employee != null)
            {
                textBoxUserType.Text = employee.manld + " - " + employee.name;
                txtMa.Text = employee.manld;
                txtName.Text = employee.name;
                txt_gen.Text = employee.gender;
                txtPhone.Text = employee.phone;
                txtKhoa.Text = employee.madv;
                txtSalary.Text = employee.salary.ToString();
                txtPC.Text = employee.allowance.ToString();
            }
        }







        private void button2_Click(object sender, EventArgs e)
        {
            
            string newPhone = txtNewP.Text; 
            string newAddress = txtNewAd.Text;
            string username = AdminSession.Username;

            bool updateSuccessPhone = false;
            bool updateSuccessAddress = false;

            if (username.StartsWith("NV"))
            {
                bool updateSuccess = dao.UpdateEmployeePhone(username, newPhone);
                if (updateSuccess)
                {
                    txtPhone.Text = newPhone;
                    lbNewPhone.Visible = false;
                    txtNewP.Visible = false;
                    MessageBox.Show("Cập nhật số điện thoại thành công!");
                }
            }
            else if (username.StartsWith("SV"))
            {
                if (!string.IsNullOrEmpty(newPhone))
                {
                    updateSuccessPhone = dao.UpdateStudentPhone(username, newPhone);
                    if (updateSuccessPhone)
                    {
                        txtPhone.Text = newPhone;  
                        lbNewPhone.Visible = false; 
                        txtNewP.Visible = false;
                    }
                }

                if (!string.IsNullOrEmpty(newAddress))
                {
                    updateSuccessAddress = dao.UpdateStudentAddress(username, newAddress);
                    if (updateSuccessAddress)
                    {
                        txtDC.Text = newAddress;  
                        lbNAddress.Visible = false;
                        txtNewAd.Visible = false;
                    }
                }
            }

            if (updateSuccessPhone || updateSuccessAddress)
            {
                MessageBox.Show("Cập nhật thông tin thành công!");
            }
            else
            {
                MessageBox.Show("Không có thay đổi nào được cập nhật.");
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string username = AdminSession.Username;

            if (username.StartsWith("NV"))
            {
                lbNewPhone.Visible = true;
                txtNewP.Visible = true;
            }
            else
            {
                lbNewPhone.Visible = true;
                txtNewP.Visible = true;
                lbNAddress.Visible = true;
                txtNewAd.Visible = true;
            }
            //txtNewP.Clear();

        }
    }
}
