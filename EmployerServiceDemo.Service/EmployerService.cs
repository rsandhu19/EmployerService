using System;
using System.Collections.Generic;
using EmployerServiceDemo.Domain.Models;
using EmployerServiceDemo.Service.Interfaces;

namespace EmployerServiceDemo.Service
{
    public class EmployerService : IEmployerService
    {
       
        private readonly IEmployerDataRepository employerDataRepository;

        public EmployerService(IEmployerDataRepository employerDataRepository)
        {           
            this.employerDataRepository = employerDataRepository;
        }
        public List<Employer> GetAllEmployers()
        {
            return employerDataRepository.GetAllEmployers();
        }       
   
    }
}
