using Oracle.ManagedDataAccess.Client;
using OUM.Session;
using OUM.View;
using OUM.ViewModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace OUM
{
    public partial class LoginPage : Form
    {

        AdminViewModel viewModel;
        public LoginPage()
        {
            InitializeComponent();
            viewModel = new AdminViewModel();
            userNameTextBox.DataBindings.Add("Text", viewModel, "username", false, DataSourceUpdateMode.OnPropertyChanged);
            passWordTextBox.DataBindings.Add("Text", viewModel, "password", false, DataSourceUpdateMode.OnPropertyChanged);

            this.FormClosing += LoginPage_FormClosing;
        }

        private void LoginPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (e.CloseReason == CloseReason.UserClosing)
            {
               
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn thoát khỏi ứng dụng?",
                    "Xác nhận thoát",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    
                    Application.Exit();
                }
                else
                {
                    
                    e.Cancel = true;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          

        }
        public string GetConnectionString()
        {
            return $"User Id={AdminSession.Username};Password={AdminSession.Password};Data Source=localhost:1521/DKHP;";
        }

        public List<string> GetUserRoles()
        {
            List<string> roles = new List<string>();
            try
            {
                using (OracleConnection conn = new OracleConnection(GetConnectionString()))
                {
                    conn.Open();
                    string query = "SELECT GRANTED_ROLE FROM USER_ROLE_PRIVS";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roles.Add(reader.GetString(0));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Ghi log nếu cần
                MessageBox.Show("Lỗi khi truy vấn vai trò người dùng: " + ex.Message,
                                "Lỗi hệ thống",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            return roles;
        }


        private void LoginBtn_MouseClick(object sender, MouseEventArgs e)
        {
            bool logined = viewModel.AdminLogin();
            if (logined)
            {
                AdminSession.Username = viewModel.username;
                AdminSession.Password = viewModel.password;
                Form navPage = null;

                if (AdminSession.Username.Equals("pdb_admin", StringComparison.OrdinalIgnoreCase))
                {
                    navPage = new AdminNavBar();
                }
                else
                {
                    navPage = new UserNavBar();
                    
                }

                if (navPage != null)
                {
                    this.Hide();
                    navPage.Show();
                }
                else
                {
                    MessageBox.Show("Bạn không có vai trò phù hợp để truy cập hệ thống.",
                        "Không có quyền truy cập",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
                }
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại. Vui lòng kiểm tra lại tên đăng nhập hoặc mật khẩu.",
                    "Lỗi đăng nhập",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }
    }
}
