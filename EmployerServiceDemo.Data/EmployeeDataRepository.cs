using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployerServiceDemo.Domain.Models;
using EmployerServiceDemo.Service.Interfaces;

namespace EmployerServiceDemo.Data
{
    public class EmployeeDataRepository : IEmployeeDataRepository
    {
        public List<Employee> GetEmployeesForEmployer(int employerId)
        {
            var employeesList = new List<Employee>();
         
            try
            {
                employeesList.Add(new Employee
                {
                    FirstName = "Steve",
                    LastName = "Clark",
                    JobTitle = "VP",
                    WorkPhone = "314-214-0987"
                });

                employeesList.Add(new Employee
                {
                    FirstName = "Marry",
                    LastName = "Carti",
                    JobTitle = "Manager",
                    WorkPhone = "314-214-0465"
                });

            }
            catch (Exception ex)
            {
                // Ideally will be written at some log files using common logger in project
                Console.WriteLine($"Failed retreiving employee info for employer: {employerId} with exception {ex}");
            }

            return employeesList;
        }
    }
}
