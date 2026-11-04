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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private double totalSalesForToday=0;
        public Window1()
        {
            InitializeComponent();
        }

        private void OilList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OilList == null) return;

            ComboBoxItem selectedItem = (ComboBoxItem)OilList.SelectedItem;

            if (selectedItem != null)
            {
                string selectedText = (string)selectedItem.Content;
                if (selectedText == "Хороший бензин")
                {
                    PriceShow.Content = "20,10";
                }
                else if (selectedText == "Непоганий бензин")
                {
                    PriceShow.Content = "154.00";
                }
                else if (selectedText == "Вище середнього бензин")
                {
                    PriceShow.Content = "128.50";
                }
                else if (selectedText == "Класний бензин")
                {
                    PriceShow.Content = "1.50";
                }
            }
        }

        private void Rb1_Click(object sender, RoutedEventArgs e)
        {
            NumberBox.IsEnabled = true;
            SumBox.Text = string.Empty;
            SumBox.IsEnabled = false;
            ProceedToPayment.Text = "До оплати";
            Hrn2.Text = "грн.";
            ProceedToPaymentBox.Content = string.Empty;
        }

        private void Rb2_Click(object sender, RoutedEventArgs e)
        {
            SumBox.IsEnabled = true;
            NumberBox.Text = string.Empty;
            NumberBox.IsEnabled = false;
            ProceedToPayment.Text = "До видачі";
            Hrn2.Text = "л.";
            ProceedToPaymentBox.Content = string.Empty;
        }

        private void PanelOneCost()
        {
            if (string.IsNullOrWhiteSpace(PriceShow.Content?.ToString()) || !double.TryParse(PriceShow.Content?.ToString().Replace('.', ','), out double parsedPrice))
                return;

            if (Hrn2.Text == "л.")
            {
                if (double.TryParse(SumBox.Text.Replace('.', ','), out double money) && money > 0)
                {
                    double litresToDeliver = money / parsedPrice;
                    ProceedToPaymentBox.Content = litresToDeliver.ToString("0.00");
                }
            }
            else if (Hrn2.Text == "грн.")
            {
                if (double.TryParse(NumberBox.Text.Replace('.', ','), out double litres) && litres > 0)
                {
                    double totalCost = parsedPrice * litres;
                    ProceedToPaymentBox.Content = totalCost.ToString("0.00");
                }
            }
        }

        private void NumberBoxAndSumBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            PanelOneCost();
        }

        private void Food_TextChanged(object sender, TextChangedEventArgs e)
        {
            PanelTwoCost();
        }

        private void Food1_Checked(object sender, RoutedEventArgs e)
        {
            NumberBox1.IsEnabled = (bool)(Food1.IsChecked != null ? Food1.IsChecked : false);
        }

        private void Food2_Checked(object sender, RoutedEventArgs e)
        {
            NumberBox2.IsEnabled = (bool)(Food2.IsChecked != null ? Food2.IsChecked : false);
        }

        private void Food3_Checked(object sender, RoutedEventArgs e)
        {
            NumberBox3.IsEnabled = (bool)(Food3.IsChecked != null ? Food3.IsChecked : false);
        }

        private void Food4_Checked(object sender, RoutedEventArgs e)
        {
            NumberBox4.IsEnabled = (bool)(Food4.IsChecked != null ? Food4.IsChecked : false);
        }

        private void PanelTwoCost()
        {
            double sum = 0;
            if (Food1.IsChecked == true)
                sum += CalcSum(PriceShow1, NumberBox1);
            if (Food2.IsChecked == true)
                sum += CalcSum(PriceShow2, NumberBox2);
            if (Food3.IsChecked == true)
                sum += CalcSum(PriceShow3, NumberBox3);
            if (Food4.IsChecked == true)
                sum += CalcSum(PriceShow4, NumberBox4);

            ProceedToPaymentBox2.Content = sum.ToString("0.00");
        }

        private double CalcSum(Label PriceShowBox, TextBox TextField)
        {

            if (!double.TryParse(PriceShowBox.Content?.ToString().Replace('.', ','), out double price))
                return 0;

            if (double.TryParse(TextField.Text, out double number) && number > 0)
                return number * price;
            return 0;

        }
        private void Calculator_Click(object sender, RoutedEventArgs e)
        {
            if (Hrn2.Text == "л.")
            {
                if (double.TryParse(SumBox.Text.Replace('.', ','), out double firstSum) &&
                    double.TryParse(ProceedToPaymentBox2.Content?.ToString().Replace('.', ','), out double secondSum))
                {
                    double totalSum = firstSum + secondSum;
                    ProceedToPaymentBox3.Content = totalSum.ToString();
                    totalSalesForToday += totalSum;
                }

            }
            else if (Hrn2.Text == "грн.")
            {
                if (double.TryParse(ProceedToPaymentBox.Content?.ToString().Replace('.', ','), out double firstSum) &&
                    double.TryParse(ProceedToPaymentBox2.Content?.ToString().Replace('.', ','), out double secondSum))
                {
                    double totalSum = firstSum + secondSum;
                    ProceedToPaymentBox3.Content = totalSum.ToString();
                    totalSalesForToday += totalSum;
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show($"Ваша сумарна виручка за день: {totalSalesForToday}");
        }
    }
}
