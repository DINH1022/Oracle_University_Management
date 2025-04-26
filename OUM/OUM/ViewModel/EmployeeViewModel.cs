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
            OracleDAO dao = new OracleDAO();
            Employees = dao.GetListEmployees();
        }
        public bool IsMaNLDExists(string maNLD)
        {
            return Employees.Any(e => e.manld.Equals(maNLD, StringComparison.OrdinalIgnoreCase));
        }

        public void AddEmployee(Employee emp)
        {
            OracleDAO dao = new OracleDAO();
            dao.InsertEmployee(emp); 
            LoadData();
        }

        public void UpdateEmployee(Employee emp)
        {
            OracleDAO dao = new OracleDAO();
            dao.UpdateEmployee(emp);
            LoadData();
        }

        public void DeleteEmployee(Employee emp)
        {
            OracleDAO dao = new OracleDAO();
            dao.DropUser(emp.Username);
            dao.DeleteEmployee(emp);
            LoadData();
        }

    }
}
