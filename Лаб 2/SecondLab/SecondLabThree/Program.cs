
using SecondLabThree.model;
using System;
using System.Collections.Generic;

List<Employer> employees = new List<Employer>
{
                new President("Volodymyr", "Volodymyr", 48, 120000m, 0m, 22.5, true, "Executive Management", new DateOnly(1978, 1, 25)),
                new President("Arthur", "Pendleton", 55, 110000m, 0m, 30.0, true, "Strategic Planning", new DateOnly(1971, 10, 14)), 

                new Manager( "Volodymyr", "Kovalenko", 32, 55000m, 0m, 8.0, true, "Software Engineering", new DateOnly(1994, 6, 12)),
                new Manager("Sarah", "Connor", 42, 62000m, 7000m, 18.0, true, "Cybersecurity", new DateOnly(1984, 10, 3)), 
                new Manager("Michael", "Scott", 45, 50000m, 0m, 15.0, false, "Project Management", new DateOnly(1981, 3, 15)),
                new Manager("Elena", "Rostovych", 29, 48000m, 0m, 6.0, true, "Data Analytics", new DateOnly(1997, 10, 28)), 
                new Manager("James", "Wilson", 50, 68000m, 8000m, 24.0, true, "Project Management", new DateOnly(1976, 8, 19)),

                new Worker("Volodymyr", "Bondarenko", 24, 30000m, 0m, 2.5, false, "Software Engineering", new DateOnly(2002, 11, 5)),
                new Worker("Yevheniy", "Hnatiuk", 5, 32000m, 1500m, 14.0, false, "Mechanical Assembly", new DateOnly(1988, 5, 20)),
                new Worker("Robert", "Cubera", 60, 40000m, 0m, 38.0, true, "Mechanical Assembly", new DateOnly(1966, 12, 10)),
                new Worker("Alice", "Smith", 31, 35000m, 0m, 9.0, true, "Quality Assurance", new DateOnly(1995, 10, 18)),
                new Worker( "David", "Brown", 52, 38000m, 0m, 29.0, true, "DevOps", new DateOnly(1974, 4, 30)),
                new Worker("Hlib", "Watson", 27, 31000m, 0m, 5.0, false, "Quality Assurance", new DateOnly(1999, 9, 22)),
                new Worker("Daniel", "Taylor", 45, 36000m, 0m, 21.0, false, "DevOps", new DateOnly(1981, 2, 14)),
                new Worker("Oliver", "Harris", 23, 28000m, 1000m, 1.5, false, "Software Engineering", new DateOnly(2003, 7, 8))
};

Company company = new Company("SpongeBob Company");
company.AddRangeEmployee(employees);
Console.WriteLine($"Number Of Employees- {company.NumberOfEmployees()}");
Console.WriteLine($"The total amount of wages that the company is required to pay its workers- {company.TotalSalary()}");

company.NumberOfEmployees();

Employer yoPersonWithHighEdu = TheYoungesPersonWithHigherEdu(company);
Console.WriteLine("A group of 10 workers with the longest length of service, from whom to select the youngest who holds a higher education qualification:");
Console.WriteLine($"- {yoPersonWithHighEdu}");


List<Employer> managers = TheYoungestAndOldestManager(company);
Console.WriteLine("The youngest and oldest managers in the company:");
foreach (var employer in managers)
{
    Console.WriteLine($"- {employer}");
}

TheEmployeesWereBornInOctober(company);
Console.WriteLine("The youngest, Volodymyr:");
YoungestVolodymyr(company);



//////////////////////////////////////////////////////////////////
static Employer TheYoungesPersonWithHigherEdu(Company company)
{
    var tenEmpWithHighWorkEx = (from employer in company.employees
                               orderby employer.WorkExperience descending
                               select employer).Take(10);

    var yoPersonWithHighEdu = (from person in tenEmpWithHighWorkEx
                              where person.HigherEducation
                              orderby person.Age
                              select person).FirstOrDefault();

    return yoPersonWithHighEdu;
}

static List<Employer> TheYoungestAndOldestManager(Company company)
{
    
    var yManager = (from employer in company.employees
                    where employer.JobTitle == "Manager"
                  orderby employer.Age
                  select employer).FirstOrDefault();
    var oManager = (from employer in company.employees
                    where employer.JobTitle == "Manager"
                    orderby employer.Age descending
                   select employer).FirstOrDefault();
    List <Employer> managers = new List<Employer>() { yManager, oManager };
    return managers;
}

static void TheEmployeesWereBornInOctober(Company company)
{
    var octoberEmloyees = from employer in company.employees
                          where employer.DateOfBirth.Month == 10
                          group employer by employer.ProfessionalFocus;

    foreach (var group in octoberEmloyees)
    {
        Console.WriteLine($"\nProfessional Focus: {group.Key}");
        foreach (var employer in group)
        {
            Console.WriteLine($"- {employer}");
        }
    }

}

static void YoungestVolodymyr(Company company)
{
    var volodymyry = from employer in company.employees
                     where employer.FirstName == "Volodymyr"
                     select employer;

    foreach (var volodymyr in volodymyry)
    {
        Console.WriteLine($"- {volodymyr}");
    }

    var yVolodymyr = (from volodymyr in volodymyry
                    orderby volodymyr.Age
                    select volodymyr).FirstOrDefault();

    decimal Award = yVolodymyr.BaseSalary/3m;
    for (int i = 0; i < company.employees.Count; i++)
    {
        if (company.employees[i] == yVolodymyr)
        {
            company.employees[i].Award = Award;
        }
    }
}