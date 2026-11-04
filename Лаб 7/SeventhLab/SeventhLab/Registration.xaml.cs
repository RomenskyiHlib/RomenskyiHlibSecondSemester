using SeventhLab.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SeventhLab
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void logInButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();

            this.Close();
            window.Show();
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameBoxReg.Text;
            string email = EmailBoxReg.Text;
            string password = PasswordBox.Password;
            string confirmPassword = PasswordConfimBox.Password;
            ValidationCheckMethods.ValidCheck(username,email,password,confirmPassword);
        }
    }
}
