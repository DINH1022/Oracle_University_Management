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

        public StudentViewModel()
        {
            _students = new List<Student>(); 
        }

        public void LoadData()
        {
            StudentDao dao = new StudentDao();
            Students = dao.GetListStudents();
        }
        public bool IsMaSVExists(string masv)
        {
            StudentDao dao = new StudentDao();
            return dao.IsMaSVExists(masv);
        }
        public bool AddStudent(Student st)
        {
            StudentDao dao = new StudentDao();
            bool success  = dao.InsertStudent(st);
            if (success)
            {
                LoadData();
            }
            return success;
        }
        public bool UpdateStudent(Student st)
        {
            StudentDao dao = new StudentDao();
            bool success = dao.UpdateStudent(st);
            if (success)
            {
                LoadData();
            }
            return success;
        }

        public void DeleteStudent(Student st)
        {
            StudentDao dao = new StudentDao();           
            dao.DeleteStudent(st);
            LoadData();
        }

        public bool isOnlyEditContact(string id)
        {
            StudentDao dao = new StudentDao();
            return dao.IsOnlyEditContact(id);
        }

        public bool isOnlyEditStatus()
        {
            StudentDao dao=new StudentDao();
            return dao.IsOnlyEditStatus();
        }

    }
}
