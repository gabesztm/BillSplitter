using ClassLibrary;
using ClassLibrary.Models;
using Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf_ui
{

    public partial class MainWindow : Window
    {
        List<FamilyModel> families = new List<FamilyModel>();
        List<DinnerModel> dinners = new List<DinnerModel>();
        List<TransactionModel> transactions = new List<TransactionModel>();
        List<FamilyModel> toFamilies = new List<FamilyModel>();
        string currency = "";
        public MainWindow()
        {
            InitializeComponent();
            grpDinners.IsEnabled = false;
            grpTransactions.IsEnabled = false;
        }

        private void btnAddFamily_Click(object sender, RoutedEventArgs e)
        {
            string familyNameInput = txtFamilyName.Text;
            if (!String.IsNullOrWhiteSpace(familyNameInput))
            {
                families.Add(new FamilyModel { balance = 0, familyName = familyNameInput });
                txtFamilyName.Clear();
                UiUtils.RefreshListBox<FamilyModel>(boxFamilies, families);
            }

        }

        private void btnDeleteFamily_Click(object sender, RoutedEventArgs e)
        {
            FamilyModel familyToDelete = (FamilyModel)boxFamilies.SelectedItem;
            families.Remove(familyToDelete);
            UiUtils.RefreshListBox<FamilyModel>(boxFamilies, families);
        }

        private void btnAddDinner_Click(object sender, RoutedEventArgs e)
        {
            string dinnerNameInput = txtDinner.Text;
            toFamilies.Clear();
            try
            {
                double price = double.Parse(txtDinnerPrice.Text);
                FamilyModel purchaser = (FamilyModel)cmbPurchaser.SelectedItem;
                if (!String.IsNullOrWhiteSpace(dinnerNameInput))
                {
                    dinners.Add(new DinnerModel { Location = dinnerNameInput, Price = price, Purchaser = purchaser });
                    txtDinner.Clear();
                    txtDinnerPrice.Clear();
                    UiUtils.RefreshListBox<DinnerModel>(boxDinners, dinners);
                    stckTransactions.Children.Clear();
                    UiUtils.GetDebitForFamilies(families, purchaser, toFamilies, stckTransactions);
                }
                grpTransactions.IsEnabled = true;
                grpDinners.IsEnabled = false;
            }
            catch
            {
                MessageBox.Show("Select the family, that purchased! Enter numbers as sum!");
            }


        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (families.Count > 1)
            {
                cmbPurchaser.ItemsSource = families;
                cmbPurchaser.Items.Refresh();
                grpFamilies.IsEnabled = false;
                grpDinners.IsEnabled = true;
                currency = txtCurrency.Text;
                txtCurrency.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Add families!");
            }

        }

        private void btnSaveTransactions_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int numberOfTransactions = stckTransactions.Children.Count;
                List<StackPanel> stackPanels = stckTransactions.Children.OfType<StackPanel>().ToList();
                for (int i = 0; i < numberOfTransactions; i++)
                {

                    transactions.Add(new TransactionModel
                    {
                        FromFamily = (FamilyModel)cmbPurchaser.SelectedItem,
                        ToFamily = toFamilies[i],
                        amountOfMoney = double.Parse(stackPanels[i].Children.OfType<TextBox>().First().Text)
                    });
                }
                stckTransactions.Children.Clear();
                grpTransactions.IsEnabled = false;
                grpDinners.IsEnabled = true;
            }
            catch
            {
                MessageBox.Show("Wrong format used for amount!");
            }
        }

        

        

        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            if (transactions.Count > 0)
            {
                Calculate.CalculateTransactions(transactions, families);
                UiUtils.ShowResult(families, currency);
            }
            else
            {
                MessageBox.Show("Fill with values!");
            }
        }
    }
}
