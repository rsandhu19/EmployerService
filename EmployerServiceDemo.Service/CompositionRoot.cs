using EmployerServiceDemo.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployerServiceDemo.Service
{
    public static class CompositionRoot
    {
        public static void AddEmployerServiceDemoService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IEmployerService, EmployerService>();
            serviceCollection.AddTransient<IEmployeeService, EmployeeService>();

        }
    }
}
