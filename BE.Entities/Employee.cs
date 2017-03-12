using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Entities
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeePhoneNumber { get; set; }
        public DateTime EmployeeDOB { get; set; }
        public double EmployeeSalary { get; set; }
        public string EmployeeStatus { get; set; }
        public Branch BranchDetails { get; set; }
        public string LoginPassword { get; set; }

        public Employee()
        {
            BranchDetails = new Branch();
        }
    }
}
