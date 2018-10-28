using EmployerServiceDemo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployerServiceDemo.Service.Interfaces
{
    public interface IEmployerDataRepository
    {
        List<Employer> GetAllEmployers();
    }
}
