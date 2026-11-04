using SeventhLab.Model;
using SeventhLab.Service;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SeventhLab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ForgotPasswordButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Згадайте будь ласка!");
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            Registration window = new Registration();

            this.Close();
            window.Show();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text;
            string password = PasswordBox.Password;
            LoginServiceMethods.Login(username, password);
        }

        private void GoogleLogo_Click(object sender, RoutedEventArgs e)
        {
            SignUoUsingGoogle signUoUsingGoogle = new SignUoUsingGoogle();
            signUoUsingGoogle.ShowDialog();
        }

        private void BlueSkyLogo_Click(object sender, RoutedEventArgs e)
        {
            SignUpUsingBlueSky signUpUsingBlueSky = new SignUpUsingBlueSky();
            signUpUsingBlueSky.ShowDialog();
        }
    }
}