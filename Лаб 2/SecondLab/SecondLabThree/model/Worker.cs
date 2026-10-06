using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLabThree.model
{
    public class Worker: Employer 
    {
        public Worker( string firstName, string lastName, int age, decimal baseSalary, decimal award,double workExperience, bool higherEducation, string professionalFocus, DateOnly dateOfBirth)
        : base("Worker", firstName, lastName, age, baseSalary, award, workExperience, higherEducation, professionalFocus, dateOfBirth)
        {
        }
        public override decimal totalSalary => BaseSalary + Award + (decimal)WorkExperience * 500m;


        public override string ToString()
        {
            return base.ToString();
        }
    }
}


