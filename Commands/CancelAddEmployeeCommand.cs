using EmployeeManager.Services;
using EmployeeManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeManager.Commands
{
    public class CancelAddEmployeeCommand : CommandBase
    {
        private readonly NavigationService _navigation;

        public CancelAddEmployeeCommand(NavigationService navigation)
        {
            _navigation = navigation;
        }

        public override void Execute(object? parameter)
        {
            MessageBox.Show("An employee addition was canceled.","Error",MessageBoxButton.OK, MessageBoxImage.Error);
            _navigation.GoTo(new EmployeesListingViewModel(_navigation));
        }
    }
}
