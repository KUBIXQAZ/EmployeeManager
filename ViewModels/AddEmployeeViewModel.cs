using EmployeeManager.Commands;
using EmployeeManager.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EmployeeManager.ViewModels
{
    public class AddEmployeeViewModel : ViewModelBase
    {
        public ICommand CancelCommand { get; }
        public ICommand SubmitCommand { get; }

        public AddEmployeeViewModel(NavigationService navigation)
        {
            CancelCommand = new CancelAddEmployeeCommand(navigation);
            SubmitCommand = new AddEmployeeCommand(navigation, this);
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _surname;
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            { 
                _surname = value;
                OnPropertyChanged("Surname");
            }
        }

        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            { 
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        private string _phone;
        public string Phone
        {
            get
            {
                return _phone;
            }
            set 
            { 
                _phone = value;
                OnPropertyChanged("Phone");
            }
        }

        private string _pesel;
        public string Pesel
        {
            get
            {
                return _pesel;
            }
            set
            {
                _pesel = value;
                OnPropertyChanged("Pesel");
            }
        }
    }
}
