using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLabThree.model
{
    internal class Company
    {
        public string Title { get; set; }
        public List<Employer> employees { get; set; }

        public Company(string title) { 
           Title = title;
           employees = new List<Employer>();
        }
        public void AddRangeEmployee(IEnumerable<Employer> newEmployees)
        {
            employees.AddRange(newEmployees);
        }

        public int NumberOfEmployees()
        {
            return employees.Count();
        }
        public decimal TotalSalary()
        {
            return (from employer in employees
                    select employer.totalSalary).Sum();
        }

    }
}
