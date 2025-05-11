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
    public class EmployeeViewModel: INotifyPropertyChanged
    {
        private List<Employee> _employees;

        public event PropertyChangedEventHandler? PropertyChanged;
        public List<Employee> Employees
        {
            get => _employees;
            set
            {
                _employees = value;
            }
        }
        public EmployeeViewModel()
        {
            _employees = new List<Employee>();
        }
        public void LoadData()
        {
            EmpDao dao = new EmpDao();
            Employees = dao.GetListEmployees();
        }
        public bool IsMaNLDExists(string maNLD)
        {
            EmpDao dao = new EmpDao();
            return dao.IsMaNLDExists(maNLD);
        }

        public void AddEmployee(Employee emp)
        {
            EmpDao dao = new EmpDao();
            dao.InsertEmployee(emp); 
            LoadData();
        }

        public void UpdateEmployee(Employee emp)
        {
            EmpDao dao = new EmpDao();
            dao.UpdateEmployee(emp);
            LoadData();
        }

        public void DeleteEmployee(Employee emp)
        {
            EmpDao dao = new EmpDao();
            dao.DeleteEmployee(emp);
            LoadData();
        }

        public bool IsPhoneOnlyUpdateMode(string employeeId)
        {
            EmpDao dao = new EmpDao();
            return dao.IsPhoneOnlyUpdateMode(employeeId);
        }

    }
}
