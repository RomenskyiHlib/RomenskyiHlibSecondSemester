using SeventhLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SeventhLab.Service
{
    internal class RegisterServiceMethods
    {
        static public void addNewUser(string username,string email,string password, List<User> users)
        {
            User newUser = new User(username, email, password);

            users.Add(newUser);
            SerializationServiceMethods.SaveUsers(users);
            MessageBox.Show("Registration was successful!");
        }
    }
}
