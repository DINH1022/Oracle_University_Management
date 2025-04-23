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
    internal class EmployeeViewModel: INotifyPropertyChanged
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

        public void LoadData()
        {
            OracleDAO dao = new OracleDAO();
            Employees = dao.GetListEmployees();
        }

    }
}
