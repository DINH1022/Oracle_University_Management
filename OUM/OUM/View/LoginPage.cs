using OUM.View;

namespace OUM
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
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
            this.Hide();
            NavPage navPage = new NavPage();
            navPage.Show();
            
        }
    }
}
