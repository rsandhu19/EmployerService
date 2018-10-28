using EmployerServiceDemo.Domain.Models;
using EmployerServiceDemo.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployerServiceDemo.Data
{
    public class EmployerDataRepository : IEmployerDataRepository
    {
        public List<Employer> GetAllEmployers()
        {
            var employersList = new List<Employer>();

            try
            {                
                employersList.Add(new Employer
                {
                    EmployerName = "Client1",
                    EmployerId = 10001,
                    Street1 = "Grand Avenue",
                    City = "St Louis",
                    State = "MO",
                    ZipCode = "63146",
                    Phone = "314-214-0000"
                });

                employersList.Add(new Employer
                {
                    EmployerName = "Client2",
                    EmployerId = 10002,
                    Street1 = "Silver Avenue",
                    City = "Houston",
                    State = "TX",
                    ZipCode = "86009"
                });

                employersList.Add(new Employer
                {
                    EmployerName = "Client3",
                    EmployerId = 10001,
                    Street1 = "Jersy",
                    City = "Washington",
                    State = "NJ",
                    ZipCode = "09989"
                });

            }
            catch (Exception ex)
            {
                // Ideally it will be written at some log files on server using logger in the app
                Console.WriteLine($"Failed retreiving info from source(Db etc) with exception {ex}");
            }
        

            return employersList;
        }
    }
}
