using EmployeeManager.ViewModels;
using System.ComponentModel;

namespace EmployeeManager.Services
{
    public class NavigationService
    { 
        public event Action CurrectViewModelChanged;

        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                OnCurrectViewModelChanged();
            }
        }

        public NavigationService()
        {
            CurrentViewModel = new EmployeesListingViewModel(this);
        }

        private void OnCurrectViewModelChanged()
        {
            CurrectViewModelChanged?.Invoke();
        }

        public void GoTo(ViewModelBase viewModel)
        {
            CurrentViewModel = viewModel;
        }
    }
}