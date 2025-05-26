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

namespace OUM.View
{
    public partial class NoticeControl : UserControl
    {
        private NotificationViewModel ViewModel;

        public NoticeControl()
        {
            InitializeComponent();
            ViewModel = new NotificationViewModel();
            this.Load += Data_Load;
        }


        private void CustomizeHeaders()
        {
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["id"].HeaderText = "Mã thông báo";
                dataGridView1.Columns["content"].HeaderText = "Nội dung";
                dataGridView1.Columns["created_date"].HeaderText = "Ngày tạo";
                dataGridView1.Columns["label"].HeaderText = "Nhãn";

                dataGridView1.Columns["content"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
        }

        private void Data_Load(object sender, EventArgs e)
        {

            ViewModel.LoadData();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = ViewModel.Notifications;
            CustomizeHeaders();

        }
    }
}
