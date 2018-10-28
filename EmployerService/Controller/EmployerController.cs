using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployerServiceDemo.Domain.Models;
using EmployerServiceDemo.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployerService.Controller
{
    [Route("v1/employer")]
    [ApiController]
    [Authorize]
    public class EmployerController : ControllerBase
    {
        private readonly IEmployerService employerService;
        private readonly IEmployeeService employeeService;
        public EmployerController(IEmployerService employerService,IEmployeeService employeeService)
        {
            this.employerService = employerService;
            this.employeeService = employeeService;
        }
        [HttpGet]
        public ActionResult<List<Employer>> GetAllEmployers()
        {
            var employers = employerService.GetAllEmployers();

            if (employers.Count == 0)
                return NotFound();

            return Ok(employers);
        }

        [HttpGet("{employerId}")]
        public ActionResult<List<Employee>> GetEmployeesForEmployer(int employerId)
        {
            if (employerId < 0)
                return BadRequest();

            var employees = employeeService.GetEmployeesForEmployer(employerId);

            if (employees.Count == 0)
                return NotFound();

            return Ok(employees);

        }
    }
}