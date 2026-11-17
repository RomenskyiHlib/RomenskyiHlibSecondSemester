using NinthLab.viewModel;
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

namespace NinthLab
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
            if (DataContext is UserFormViewModel vm)
            {
                if (vm.TrySave())
                {
                    DialogResult = true;
                }
                else
                {
                    MessageBox.Show(vm.ValidationErrors,
                        "Помилка введення даних",MessageBoxButton.OK,MessageBoxImage.Warning);
                }
            }
        }
    }
}