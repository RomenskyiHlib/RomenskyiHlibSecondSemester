using SeventhLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SeventhLab.Service
{
    internal class LoginServiceMethods
    {
        static public void Login(string username, string password)
        {
            List<User> users = SerializationServiceMethods.LoadUsers();

            (bool success, string message) = ValidationCheckMethods.ValidUserForLogin(username, password, users);
            if (success == false)
            {
                MessageBox.Show(message);
                return;
            }
            MessageBox.Show("You have successfully logged in to your account!");
        }

        static public void LoginSignUpUsing(User user)
        {
            bool userExists = false;
            List<User> users = SerializationServiceMethods.LoadUsers();
            foreach (User us in users)
            {
                if(us.Equals(user))
                    userExists = true;
            }
            if (!userExists) {
                users.Add(user);
                SerializationServiceMethods.SaveUsers(users);
            }
            MessageBox.Show("You have successfully logged in to your account!");
        }

    }
}
