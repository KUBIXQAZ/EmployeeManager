using EmployeeManager.Services;

namespace EmployeeManager.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private NavigationService _navigation;
        public ViewModelBase CurrentViewModel => _navigation.CurrentViewModel;

        public MainViewModel(NavigationService navigation)
        {
            _navigation = navigation;
            _navigation.CurrectViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}