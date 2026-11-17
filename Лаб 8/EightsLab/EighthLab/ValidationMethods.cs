using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EighthLab
{
    class ValidationMethods
    {
        public static string AllPropertyValidationCheck(string fullName, string birth, string expYear)
        {
            if (fullName.Any(Char.IsDigit) || string.IsNullOrWhiteSpace(fullName))
            {
                return "Ім'я введено неправильно!";
            }
            if (!int.TryParse(birth, out int intbirth) || intbirth < 1900 || intbirth > DateTime.Now.Year)
            {
                return "Рік народження введено неправильно";
            }
            if (!int.TryParse(expYear, out int year) || year < 0)
            {
                return "Стаж введено неправильно!";
            }
            return "";
        }
    }
}
