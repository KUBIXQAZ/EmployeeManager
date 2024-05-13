using EmployeeManager.Services;
using EmployeeManager.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace EmployeeManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string ConnectionString => new DatabaseSetup().ReadConnectionString();
        private NavigationService _navigation = new NavigationService();

        protected override async void OnStartup(StartupEventArgs e)
        {
            MainWindow mainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigation)
            };
            mainWindow.Show();

            base.OnStartup(e);
        }
    }
}
