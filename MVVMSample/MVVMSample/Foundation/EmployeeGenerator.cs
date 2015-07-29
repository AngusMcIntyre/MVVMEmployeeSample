using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMSample.Foundation
{
    class EmployeeGenerator
    {
        Random rand = new Random();

        string[] firstNames = new[] { "Angus", "Anil", "Michael", "Jim", "Andrew", "Roger", "Ian" };

        public Employee GenerateRandom()
        {
            return new Employee
            {
                Name = this.firstNames[this.rand.Next(0, firstNames.Length - 1)],
                Number = this.rand.Next(0, 2000)
            };
        }
    }
}
