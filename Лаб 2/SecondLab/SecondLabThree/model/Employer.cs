using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLabThree.model
{
    public abstract class Employer
    {
        public string JobTitle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal Award { get; set; }
        public double WorkExperience { get; set; }
        public bool HigherEducation { get; set; }
        public string ProfessionalFocus { get; set; }
        public DateOnly DateOfBirth { get; set; }

        protected Employer(string jobTitle,string firstName,string lastName,int age, decimal baseSalary,decimal award,double workExperience,bool higherEducation,string professionalFocus,DateOnly dateOfBirth)
        {
            JobTitle = jobTitle;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            BaseSalary = baseSalary;
            Award = award;
            WorkExperience = workExperience;
            HigherEducation = higherEducation;
            ProfessionalFocus = professionalFocus;
            DateOfBirth = dateOfBirth;
        }

        public abstract decimal totalSalary { get; }

        public override string ToString()
        {
            return $"Position: {JobTitle} - {LastName} {FirstName}, {DateOfBirth}, Age: {Age}, Education: {HigherEducation}, Focus: {ProfessionalFocus}, Experience: {WorkExperience} years, Base: {BaseSalary:C}, Award: {Award:C}, Total Salary: {totalSalary} c";
        }
    }
}
