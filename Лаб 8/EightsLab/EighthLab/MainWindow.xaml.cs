using System.Collections.ObjectModel;
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

namespace EighthLab
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

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string pip = PIPbox.Text.ToString();
            string year = Datebox.Text.ToString();
            string expYear = Careerbox.Text.ToString();
            string Valid = ValidationMethods.AllPropertyValidationCheck(pip, year,expYear);
            if (Valid != string.Empty)
            {
                MessageBox.Show(Valid);
            }
            else
            {
                DialogResult = true;
                Close();
            }
        }
    }
}