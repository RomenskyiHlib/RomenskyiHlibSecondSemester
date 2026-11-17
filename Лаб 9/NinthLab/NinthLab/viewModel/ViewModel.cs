using NinthLab.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace NinthLab.viewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        private UserViewModel? selectedUser;
        public ObservableCollection<UserViewModel> Users { get; } = new();

        public bool HasUsers => Users.Count > 0;
        public UserViewModel? SelectedUser
        {
            get { return selectedUser; }
            set { selectedUser = value;
               NotifyPropertyChanged(nameof(selectedUser));
            }
        }   
        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand LoadCommand { get; }

        public ViewModel()
        {
            AddCommand = new RelayCommand(AddUser);
            EditCommand = new RelayCommand(EditUser, CanEditOrDelete);
            DeleteCommand = new RelayCommand(DeleteUser, CanEditOrDelete);
            SaveCommand = new RelayCommand(SaveUsers, CanSave);
            LoadCommand = new RelayCommand(LoadUsers);
        }
        private bool CanEditOrDelete(object? obj)
        {
            return SelectedUser != null && HasUsers;
        }

        private bool CanSave(object? obj)
        {
            return HasUsers;
        }
        private void AddUser(object? obj)
        {
            var newUser = new User();
            var form = new UserFormViewModel(newUser);
            var window = new MainWindow { DataContext = form };

            if (window.ShowDialog() == true)
            {
                Users.Add(new UserViewModel(newUser));
                RefreshState();
            }
        }

        private void EditUser(object? obj)
        {
            if (SelectedUser == null) return;
            var form = new UserFormViewModel(SelectedUser.Model);
            var window = new MainWindow { DataContext = form };

            if (window.ShowDialog() == true)
            {
                SelectedUser.Refresh();
                RefreshState();
            }
        }

        private void DeleteUser(object? obj)
        {
            if (SelectedUser == null) return;

            var result = MessageBox.Show($"Видалити користувача {SelectedUser.FullName}?",
                "Видалення",MessageBoxButton.YesNo,MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Users.Remove(SelectedUser);
                RefreshState();
            }
        }
        private void SaveUsers(object? obj)
        {
            var rawUsers = (from user in Users
                            select user.Model).ToList();
                XmlSerializer serializer = new XmlSerializer(typeof(List<User>));

                using (FileStream fileStream = new FileStream("Students.xml", FileMode.Create))
                {
                    serializer.Serialize(fileStream, rawUsers);
                }
                MessageBox.Show("Дані збережено у файл Students.xml!", 
                    "Збереження", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void LoadUsers(object? obj)
        {
             if (!File.Exists("Students.xml"))
             {  
                 MessageBox.Show("Файл не знайдено!", 
                 "Завантаження", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
             }

             XmlSerializer serializer = new XmlSerializer(typeof(List<User>));

             using (FileStream fileStream = new FileStream("Students.xml", FileMode.Open))
             {
                 var rawUsers = (List<User>?)serializer.Deserialize(fileStream);

                 if (rawUsers != null)
                 {
                     Users.Clear();
                     foreach (var user in rawUsers)
                     {
                         Users.Add(new UserViewModel(user));
                     }
                     RefreshState();
                     MessageBox.Show("Дані завантажено з файлу Students.xml!", 
                         "Завантаження", MessageBoxButton.OK, MessageBoxImage.Information);
                 }
             }
        }
        private void RefreshState()
        {
            NotifyPropertyChanged(nameof(HasUsers));
            CommandManager.InvalidateRequerySuggested();
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string infoAboutProperty)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(infoAboutProperty));
        }
    }
}
