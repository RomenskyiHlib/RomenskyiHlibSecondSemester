using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NinthLab.Model
{
    public class User : INotifyPropertyChanged
    {
        private string firstName = string.Empty;
        private string lastName  = string.Empty;
        private string gender = string.Empty;
        private int age;

        public User()
        {
            firstName = "Ім'я";
            lastName = "Прізвище";
            gender = "Не хочу вказувати";
            age = 18;
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; NotifyPropertyChanged(nameof(FirstName)); }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; NotifyPropertyChanged(nameof(LastName)); }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; NotifyPropertyChanged(nameof(Gender)); }
        }

        public int Age
        {
            get { return age; }
            set { age = value; NotifyPropertyChanged(nameof(Age)); }
        }

        public string ValidationCheck()
        {
            if (string.IsNullOrWhiteSpace(FirstName))
                return "Ім'я має бути обов'язково вказане!";
            if (string.IsNullOrWhiteSpace(LastName))
                return "Прізвище має бути обов'язково вказане!";
            if (string.IsNullOrWhiteSpace(Gender))
                return "Стать має бути обов'язково вказана!";
            if (Age > 100 || Age < 16)
                return "Вік має бути вказаний у діапазоні від 16 до 100!";
            return "";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string infoAboutProperty)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(infoAboutProperty));
        }

        public override string ToString()
        {
            return $"{firstName},{lastName},{gender} - {age}";
        }
    }
}
