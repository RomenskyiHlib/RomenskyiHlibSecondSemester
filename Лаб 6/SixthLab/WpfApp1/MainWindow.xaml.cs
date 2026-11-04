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
using WpfApp1.Service;
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp1
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

        private void CE_Click(object sender, RoutedEventArgs e)
        {
            Operations.Content = string.Empty;
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            Operations.Content = string.Empty;
            LastOperations.Content = string.Empty;
        }

        private void lt_Click(object sender, RoutedEventArgs e)
        {
            string currentText = (string)Operations.Content;

            if (!string.IsNullOrEmpty(currentText))
            {
                Operations.Content = currentText.Substring(0, currentText.Length - 1);
            }
        }

        private void Slash_Click(object sender, RoutedEventArgs e)
        {
            AppendOperator("/");
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            AppendOperator("*");
        }

        private void Subtrack_Click(object sender, RoutedEventArgs e)
        {
            AppendOperator("-");
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AppendOperator("+");
        }

        private void Dot_Click(object sender, RoutedEventArgs e)
        {
            AppendOperator(".");
        }

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            Operations.Content += "9";
        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            Operations.Content += "8";
        }

        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            Operations.Content += "7";
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            Operations.Content += "6";
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            Operations.Content += "5";
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            Operations.Content += "4";
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            Operations.Content += "3";
        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            Operations.Content += "2";
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            Operations.Content += "1";
        }

        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            Operations.Content += "0";
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            string currentText = (string)Operations.Content;

            if (!string.IsNullOrEmpty(currentText))
            {
                char lastChar = currentText[currentText.Length - 1];
                if (!"+-*/.".Contains(lastChar))
                {
                    LastOperations.Content = currentText + " =";

                    string result = CalculationServiceMethods.Calculate(currentText);
                    Operations.Content = result;
                }
            }
        }
        private void AppendOperator(string op)
        {
            string text = (string)Operations.Content;
            if (string.IsNullOrEmpty(text) && op == "-")
            {
                Operations.Content += op;
                return;
            }

            char lastChar = text[text.Length - 1];

            if ((op == "*" || op == "/" || op == "+") && !"+-*/.".Contains(lastChar))
            {
                Operations.Content += op;
                return;
            }
            if (op == "-" && !"+-.".Contains(lastChar))
            {
                Operations.Content += op;
                return;
            }
            
            if (op == "." && char.IsDigit(lastChar))
            {
                int lastOpIndex = -1;
                for (int i = text.Length - 1; i >= 0; i--)
                {
                    if ("+-*/".Contains(text[i]))
                    {
                        lastOpIndex = i;
                        break;
                    }
                }
                string currentNumber = lastOpIndex == -1 ? text : text.Substring(lastOpIndex + 1);
                if (currentNumber.Contains(".")) return;
                Operations.Content += op;
                return;

            }
        }
    }
}