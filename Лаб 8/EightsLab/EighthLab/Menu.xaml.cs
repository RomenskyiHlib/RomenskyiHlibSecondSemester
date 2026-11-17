using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace EighthLab
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        private ObservableCollection<Candidate> candidates = new ObservableCollection<Candidate>();
        private List<Candidate> CopyCandidatesList = new List<Candidate>();
        private bool IfFiltered; 
        public Menu()
        {
           
            InitializeComponent();
            CandidatesTable.ItemsSource = candidates;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            IEditableCollectionView editableCollectionView = (IEditableCollectionView)CandidatesTable.Items;

            if (IfFiltered) {

                MessageBox.Show("Для того, щоб додати нового кандидата, вам потрібно прибрати фільтр!");
                return; 
            }
            if (!editableCollectionView.CanAddNew)
            {
                MessageBox.Show("Ви не можете додати кандидата у список!");
                return;
            }
            
            MainWindow window = new MainWindow { DataContext = editableCollectionView.AddNew() };
            if (window.ShowDialog() == true)
                editableCollectionView.CommitNew();
            else editableCollectionView.CancelNew();

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Candidate candidate = (Candidate)CandidatesTable.SelectedItem;
            IEditableCollectionView editableCollectionView = (IEditableCollectionView)CandidatesTable.Items;
            if (candidate == null)
            {
                MessageBox.Show("Немає вибраних кандидатів!");
                return;
            }
            if (!editableCollectionView.CanRemove)
            {
                MessageBox.Show("Ви не можете видалити кандидата з списоку!");
                return;
            }

            if (MessageBox.Show("Ви точно хочете видалити " + candidate.FullName,
                "Видалення кандидата", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                editableCollectionView.Remove(CandidatesTable.SelectedItem);
                CopyCandidatesList.Remove(candidate);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (CandidatesTable.SelectedItem == null) {
                MessageBox.Show("Немає вибраних кандидатів!");
                return;
            }

            IEditableCollectionView editableCollectionView = (IEditableCollectionView)CandidatesTable.Items;

            MainWindow window = new MainWindow();
            editableCollectionView.EditItem(CandidatesTable.SelectedItem);
            window.DataContext = CandidatesTable.SelectedItem;

            if(window.ShowDialog() == true)
            {
                editableCollectionView.CommitEdit();

            } else
            {
                editableCollectionView.CancelEdit();
            }
        }

        private void UpdateReserveList(List<Candidate> currentData)
        {
            CopyCandidatesList.Clear();
            CopyCandidatesList.AddRange(currentData);
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            IfFiltered = true;
            if (CandidatesTable == null) return;
            if (sender is RadioButton radioButton && radioButton.IsChecked == true)
            {
                if (radioButton.Content == null) return;
                string selectedEducation = radioButton.Content.ToString();

                if (selectedEducation == "Усі")
                {
                    if (CopyCandidatesList.Count == 0 && candidates.Count > 0)
                    {
                        UpdateReserveList(candidates.ToList());
                    }

                    candidates.Clear();
                    foreach (var candidate in CopyCandidatesList)
                    {
                        candidates.Add(candidate);
                    }
                    IfFiltered = false;
                }
                else { 
                    if (CopyCandidatesList.Count == 0)
                        UpdateReserveList(candidates.ToList());
                    candidates.Clear();
                    var filtered = from candidate in CopyCandidatesList
                                   where candidate.Education == selectedEducation
                                   select candidate;

                    foreach (var candidate in filtered) {
                        candidates.Add(candidate);
                    }
                }
            }
        }
    }
}
