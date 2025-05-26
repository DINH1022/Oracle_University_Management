using OUM.Model;
using OUM.Service.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUM.ViewModel
{
    public class NotificationViewModel:INotifyPropertyChanged
    {
        private List<Notification> _notifications;
        public event PropertyChangedEventHandler? PropertyChanged;
        public List<Notification> Notifications
        {
            get => _notifications;
            set
            {
                _notifications = value;
            }
        }



        public NotificationViewModel()
        {
            _notifications = new List<Notification>();
        }

        public void LoadData()
        {
            NotificationDao dao = new NotificationDao();
            Notifications = dao.GetNotifications();
        }
    }
}
