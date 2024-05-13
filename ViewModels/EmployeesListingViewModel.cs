using EmployeeManager.Commands;
using EmployeeManager.DTOs;
using EmployeeManager.Models;
using EmployeeManager.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EmployeeManager.ViewModels
{
    public class EmployeesListingViewModel : ViewModelBase
    {
        private readonly EmployeeModel _manager = new EmployeeModel();

        private readonly ObservableCollection<Employee> _employees = new ObservableCollection<Employee>();
        private readonly NavigationService _navigation;

        public IEnumerable<Employee> Employees => _employees;

        public ICommand GoToAddEmployeeCommand { get; }

        public EmployeesListingViewModel(NavigationService navigation)
        {
            UpdateEmployees();
            _navigation = navigation;
            GoToAddEmployeeCommand = new GoToAddEmployeeCommand(_navigation);
        }

        private void UpdateEmployees()
        {
            _employees.Clear();

            foreach (Employee employee in _manager.GetAllEmployees())
            {
                _employees.Add(employee);
            }
        }
    }
}
