using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.ViewModel;

namespace MVVMSample.ViewModels
{
    class EmployeeViewModel : BindableBase, System.ComponentModel.INotifyDataErrorInfo
    {
        ErrorsContainer<string> validationErrors;

        /// <summary>
        /// Backing field for the <see cref="Name"/> property
        /// </summary>
        private string name = default(string);

        /// <summary>
        /// Backing field for the <see cref="Number"/> property
        /// </summary>
        private int number = default(int);

        public EmployeeViewModel ()
	    {
            this.validationErrors = new ErrorsContainer<string>(property =>
            {
                var handler = this.ErrorsChanged;
                if (handler != null)
                {
                    handler(this, new System.ComponentModel.DataErrorsChangedEventArgs(property));
                }
            });
	    }

        /// <summary>
        /// Get or sets a value that specifies an employee's name.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;

                List<string> errors = new List<string>();

                if (string.IsNullOrEmpty(this.name))
                {
                    errors.Add("Employee name cannot be empty.");
                }

                this.validationErrors.SetErrors(() => this.Name, errors);

                this.OnPropertyChanged(() => this.Name);
            }
        }

        /// <summary>
        /// Get or sets a value that indicates the employee number.
        /// </summary>
        public int Number
        {
            get
            {
                return this.number;
            }

            set
            {
                this.number = value;
                this.OnPropertyChanged(() => this.Number);
            }
        }

        public event EventHandler<System.ComponentModel.DataErrorsChangedEventArgs> ErrorsChanged;

        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            return this.validationErrors.GetErrors(propertyName);
        }

        public bool HasErrors
        {
            get { return this.validationErrors.HasErrors; }
        }
    }
}
