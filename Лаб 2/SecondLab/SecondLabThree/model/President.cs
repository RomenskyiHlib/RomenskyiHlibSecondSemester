using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLabThree.model
{
    public class President : Employer
    {
        public President(string firstName, string lastName, int age, decimal baseSalary, decimal award, double workExperience, bool higherEducation, string professionalFocus, DateOnly dateOfBirth)
        : base("President", firstName, lastName, age, baseSalary, award, workExperience, higherEducation, professionalFocus, dateOfBirth)
        {
        }
        public override decimal totalSalary => BaseSalary + Award * (decimal) (WorkExperience > 0 ? WorkExperience : 1);

        public override string ToString()
        {
            return base.ToString();
        }
    }

}