using NinthLab.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NinthLab.viewModel
{
    public class UserFormViewModel : INotifyPropertyChanged
    {
        private string validationErrors = string.Empty;
        public User CurrentUser { get; }

        public UserFormViewModel(User user)
        {
            CurrentUser = user;
        }
        public string ValidationErrors
        {
            get { return validationErrors; }
            set { validationErrors = value; NotifyPropertyChanged(nameof(validationErrors)); }
        }

        public bool TrySave()
        {
            string errors = CurrentUser.ValidationCheck();
            if (errors == string.Empty)
            {
                return true;
            }
            else
            {
                ValidationErrors = errors;
                return false;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(string infoAboutProperty)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(infoAboutProperty));
        }
    }
}
