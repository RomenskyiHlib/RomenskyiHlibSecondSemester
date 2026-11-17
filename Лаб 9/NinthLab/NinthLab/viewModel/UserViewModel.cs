using NinthLab.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinthLab.viewModel
{
    public class UserViewModel : INotifyPropertyChanged
    {
        public User Model { get; }
        public UserViewModel(User user) 
        {
            Model = user;
        }
        
        public string FullName {

            get { return $"{Model.LastName} {Model.FirstName}"; }
        }

        public string FormattedAge
        {
            get { return $"{Model.Age} р."; }
        }
        public void Refresh()
        {
            NotifyPropertyChanged(nameof(FullName));
            NotifyPropertyChanged(nameof(FormattedAge));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string infoAboutProperty)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(infoAboutProperty));
        }
    }
}
