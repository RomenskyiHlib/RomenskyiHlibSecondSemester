using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLabThree.model
{
    public class Manager : Employer
    {
        public Manager(string firstName, string lastName, int age, decimal baseSalary, decimal award, double workExperience, bool higherEducation, string professionalFocus, DateOnly dateOfBirth)
        : base("Manager", firstName, lastName, age, baseSalary, award, workExperience, higherEducation, professionalFocus, dateOfBirth)
        {
        }
        public override decimal totalSalary => BaseSalary + Award + 1 + ((decimal)WorkExperience * 0.05m);

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
