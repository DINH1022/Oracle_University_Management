using OUM.View;
using OUM.ViewModel;

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

        private void LoginBtn_MouseClick(object sender, MouseEventArgs e)
        {
            bool logined = viewModel.AdminLogin();
            if (logined)
            {
                this.Hide();
                StudentNavPage navPage = new StudentNavPage();
                navPage.Show();
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
