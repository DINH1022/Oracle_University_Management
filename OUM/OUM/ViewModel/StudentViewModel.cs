using OUM.Service.DataAccess;
using OUM.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OUM.Model;

namespace OUM.ViewModel
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        private List<Student> _students;

        public event PropertyChangedEventHandler? PropertyChanged;
        public List<Student> Students
        {
            get => _students;
            set
            {
                _students = value;
            }
        }

        public void LoadData()
        {
            OracleDAO dao = new OracleDAO();
            Students = dao.GetListStudents();
        }
       
    }
}
