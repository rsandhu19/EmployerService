using EmployerServiceDemo.Domain.Models;
using EmployerServiceDemo.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployerServiceDemo.Service
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeDataRepository employeeDataRepository;

        public EmployeeService(IEmployeeDataRepository employeeDataRepository)
        {
            this.employeeDataRepository = employeeDataRepository;
            
        }
        public List<Employee> GetEmployeesForEmployer(int employerId)
        {
            return employeeDataRepository.GetEmployeesForEmployer(employerId);
        }

    }
}
