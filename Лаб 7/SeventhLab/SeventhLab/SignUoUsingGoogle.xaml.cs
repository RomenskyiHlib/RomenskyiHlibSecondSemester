using SeventhLab.Model;
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
    /// Interaction logic for SignUoUsingGoogle.xaml
    /// </summary>
    public partial class SignUoUsingGoogle : Window
    {
        public SignUoUsingGoogle()
        {
            InitializeComponent();
        }

        private void LogoGoogleAc3_Click(object sender, RoutedEventArgs e)
        {
            User user = new User("Elephant220", "elephant20205220@gmail.com", "12bigelephant0");
            LoginServiceMethods.LoginSignUpUsing(user);
        }

        private void LogoGoogleAc1_Click(object sender, RoutedEventArgs e)
        {
            User user = new User("--MicroBig--", "microbig@gmail.com", "010101gsffpg");
            LoginServiceMethods.LoginSignUpUsing(user);
        }

        private void LogoGoogleAc2_Click(object sender, RoutedEventArgs e)
        {
            User user = new User("somecoolname", "Coolname0@gmail.com", "12345678Ha");
            LoginServiceMethods.LoginSignUpUsing(user);
        }
    }
}
