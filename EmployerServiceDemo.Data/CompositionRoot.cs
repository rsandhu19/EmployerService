using EmployerServiceDemo.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployerServiceDemo.Data
{
    public static class CompositionRoot
    {
        public static void AddEmployerServiceDemoData(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IEmployerDataRepository, EmployerDataRepository>();

            serviceCollection.AddTransient<IEmployeeDataRepository, EmployeeDataRepository>();
        }
    }
}
