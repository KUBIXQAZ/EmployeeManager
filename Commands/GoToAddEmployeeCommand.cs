using EmployeeManager.Services;
using EmployeeManager.ViewModels;

namespace EmployeeManager.Commands
{
    public class GoToAddEmployeeCommand : CommandBase
    {
        private readonly NavigationService _navigation;

        public GoToAddEmployeeCommand(NavigationService navigation)
        {
            _navigation = navigation;
        }

        public override void Execute(object? parameter)
        {
            _navigation.GoTo(new AddEmployeeViewModel(_navigation));
        }
    }
}