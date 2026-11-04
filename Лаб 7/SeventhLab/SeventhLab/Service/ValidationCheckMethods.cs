using SeventhLab.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace SeventhLab.Service
{
    internal class ValidationCheckMethods
    {
        static public void ValidCheck(string username, string email, string password, string confirmPassword)
        {
            (bool success, string message) = ValidUserName(username);
            if (success == false)
            {
                MessageBox.Show(message);
                return;
            }
            (success, message) = ValidEmail(email);
            if (success == false)
            {
                MessageBox.Show(message);
                return;
            }
            (success, message) = ValidPassword(password, confirmPassword);
            if (success == false)
            {
                MessageBox.Show(message);
                return;
            }
            List<User> users = SerializationServiceMethods.LoadUsers();
            (success, message) = ValidUserForReg(username, email, users);
            if (success == false)
            {
                MessageBox.Show(message);
                return;
            }
            RegisterServiceMethods.addNewUser(username, email, password, users);         
        }
        static public (bool success, string message) ValidUserName(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return (false, "You must enter a Username!");
            return (true, "");
        }
        static public (bool success, string message) ValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return (false, "Invalid email address!");

            int atIndex = email.IndexOf('@');
            int lastAtIndex = email.LastIndexOf('@');

            if (atIndex == -1 || atIndex != lastAtIndex)
                return (false, "Invalid email address!");

            string localPart = email.Substring(0, atIndex);
            string domainPart = email.Substring(atIndex + 1);

            if (string.IsNullOrEmpty(localPart) || !domainPart.Contains(".") || domainPart.StartsWith(".") ||
                domainPart.EndsWith("."))
            {
                return (false, "Invalid email address!");
            }

            return (true, "");
        }
        static public (bool success, string message) ValidPassword(string password, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
                return (false, "The password must be at least 8 characters long!");
            if (!password.Any(char.IsDigit))
                return (false, "Please include digits in your password!");
            if(!password.Equals(confirmPassword))
                return (false, "The password and confirm password do not match!!");
            return (true, "");
        }

        static public (bool success, string message) ValidUserForReg(string username, string email, List<User> users)
        {
            bool usernameExists = false;
            bool emailExists = false;

            foreach (var user in users)
            {
                if (user.Username.Equals(username, StringComparison.OrdinalIgnoreCase))
                {
                    usernameExists = true;
                    break;
                }
                if (user.Email.Equals(email, StringComparison.OrdinalIgnoreCase))
                {
                    emailExists = true;
                    break;
                }
            }
                if (usernameExists)
                    return (false, "A user with that username already exists");
                if (emailExists)
                    return (false, "A user with that email already exists");
            return (true, "");
        }

        static public (bool success, string message) ValidUserForLogin(string username, string password, List<User> users)
        {
            bool usernameExists = false;
            foreach (var user in users)
            {
                if (string.Equals(user.Username, username, StringComparison.OrdinalIgnoreCase))
                {
                    usernameExists = true;
                    if (user.Password != password)
                    {
                        return (false, "The password was entered incorrectly");
                    }
                    break;
                }
            }
            if (!usernameExists)
                return (false, "The username was entered incorrectly");
            return (true, "");
        }
    }
}
