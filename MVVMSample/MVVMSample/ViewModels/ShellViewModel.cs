using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Commands;

namespace MVVMSample.ViewModels
{
    class ShellViewModel : BindableBase
    {
        /// <summary>
        /// Backing field for the <see cref="SelectedEmployee"/> property
        /// </summary>
        private EmployeeViewModel selectedEmployee = default(EmployeeViewModel);

        /// <summary>
        /// Backing field for the <see cref="Employees"/> property
        /// </summary>
        private System.Collections.ObjectModel.ObservableCollection<EmployeeViewModel> employees = default(System.Collections.ObjectModel.ObservableCollection<EmployeeViewModel>);

        /// <summary>
        /// Initializes a new instance of the <see cref="ShellViewModel"/> class.
        /// </summary>
        public ShellViewModel()
        {
            this.Employees = new System.Collections.ObjectModel.ObservableCollection<EmployeeViewModel>();
            this.GenerateRandomEmployeeCommand = new DelegateCommand(this.GenerateRandomEmployee);
        }

        /// <summary>
        /// Get or sets a value that contains the employee record view models.
        /// </summary>
        public System.Collections.ObjectModel.ObservableCollection<EmployeeViewModel> Employees
        {
            get
            {
                return this.employees;
            }

            set
            {
                this.employees = value;
                this.OnPropertyChanged(() => this.Employees);
            }
        }

        /// <summary>
        /// Get or sets a value that indicates something
        /// </summary>
        public EmployeeViewModel SelectedEmployee
        {
            get
            {
                return this.selectedEmployee;
            }

            set
            {
                this.selectedEmployee = value;
                this.OnPropertyChanged(() => this.SelectedEmployee);
            }
        }

        /// <summary>
        /// Gets or sets a command that generates a random employee.
        /// </summary>
        /// <value>
        /// The generate random employee command.
        /// </value>
        public DelegateCommand GenerateRandomEmployeeCommand { get; set; }

        private void GenerateRandomEmployee()
        {
            Foundation.EmployeeGenerator generator = new Foundation.EmployeeGenerator();

            Foundation.Employee employee = generator.GenerateRandom();

            Employees.Add(new EmployeeViewModel { Name = employee.Name, Number = employee.Number });
        }
    }
}
