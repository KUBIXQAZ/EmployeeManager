using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using EmployeeManager.Services;
using EmployeeManager.ViewModels;
using Microsoft.Data.SqlClient;

namespace EmployeeManager.Commands
{
    public class AddEmployeeCommand : CommandBase
    {
        private readonly NavigationService _navigation;
        private readonly AddEmployeeViewModel _addEmployeeViewModel;

        public AddEmployeeCommand(NavigationService navigation, AddEmployeeViewModel addEmployeeViewModel)
        {
            _navigation = navigation;
            _addEmployeeViewModel = addEmployeeViewModel;

            _addEmployeeViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AddEmployeeViewModel.Name) ||
                e.PropertyName == nameof(AddEmployeeViewModel.Surname) ||
                e.PropertyName == nameof(AddEmployeeViewModel.Email) ||
                e.PropertyName == nameof(AddEmployeeViewModel.Phone) ||
                e.PropertyName == nameof(AddEmployeeViewModel.Pesel))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_addEmployeeViewModel.Name) &&
                !string.IsNullOrEmpty(_addEmployeeViewModel.Surname) &&
                !string.IsNullOrEmpty(_addEmployeeViewModel.Email) &&
                !string.IsNullOrEmpty(_addEmployeeViewModel.Phone) &&
                !string.IsNullOrEmpty(_addEmployeeViewModel.Pesel);
        }

        public override void Execute(object? parameter)
        {
            using(SqlConnection sqlConnection = new SqlConnection(App.ConnectionString))
            {
                sqlConnection.Open();

                string query = "INSERT INTO Employees (Name,Surname,Email,Phone,Pesel) VALUES(@name,@surname,@email,@phone,@pesel);";
                
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@name", _addEmployeeViewModel.Name);
                sqlCommand.Parameters.AddWithValue("@surname", _addEmployeeViewModel.Surname);
                sqlCommand.Parameters.AddWithValue("@email", _addEmployeeViewModel.Email);
                sqlCommand.Parameters.AddWithValue("@phone", _addEmployeeViewModel.Phone);
                sqlCommand.Parameters.AddWithValue("@pesel", _addEmployeeViewModel.Pesel);

                try
                {
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                } catch(Exception ex)
                {
                    MessageBox.Show($"Error: {ex}","Error",MessageBoxButton.OK,MessageBoxImage.Error);
                    sqlConnection.Close();
                    return;
                }

                

                MessageBox.Show("An employee addition was successfull.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                _navigation.GoTo(new EmployeesListingViewModel(_navigation));
            }
        }
    }
}