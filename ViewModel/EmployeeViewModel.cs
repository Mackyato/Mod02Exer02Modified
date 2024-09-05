using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Mod02Exer02Modified.Model;

namespace Mod02Exer02Modified.ViewModel
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        private Employee _employee;
        private string _fullname;

        public EmployeeViewModel()
        {
            _employee = new Employee
            {
                FirstName = "Mark Anthony",
                LastName = "Soberano",
                Position = "Manager",
                Department = "CCS",
                IsActive = true
            };

            LoadEmployeeDataCommand = new Command(async () => await LoadEmployeeDataAsync());

            Employees = new ObservableCollection<Employee>
            {
                new Employee { FirstName = "Jane", LastName = "Smith", Position = "Dean", Department = "CCS" },
                new Employee { FirstName = "James", LastName = "Bond", Position = "Program Chari", Department = "BMMA"},
                new Employee {FirstName = "Alice", LastName = "Guo", Position = "Vice Deam", Department = "BSCS"}
            };
        }

        public ObservableCollection<Employee> Employees { get; set; }

        public string FullName
        {
            get => _fullname;
            set
            {
                if (_fullname != value)
                {
                    _fullname = value;
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        public ICommand LoadEmployeeDataCommand { get; }

        private async Task LoadEmployeeDataAsync()
        {
            await Task.Delay(1000);

            FullName = $"{_employee.FirstName} {_employee.LastName} {_employee.Position} {_employee.Department}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
