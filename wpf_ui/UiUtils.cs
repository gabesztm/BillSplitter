using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace wpf_ui
{
    internal static class UiUtils
    {
        internal static void RefreshListBox<T>(ListBox listBox, List<T> itemSource)
        {
            listBox.ItemsSource = itemSource;
            listBox.Items.Refresh();
        }

        internal static void GetDebitForFamilies(List<FamilyModel> families, FamilyModel purchaser, List<FamilyModel> toFamilies, StackPanel stckTransactions)
        {
            for (int i = 0; i < families.Count; i++)
            {
                FamilyModel fam = families[i];
                if (fam != purchaser)
                {
                    toFamilies.Add(fam);
                    UpdateUiForFamilyDebit(fam.familyName, stckTransactions);
                }
            }
        }

        internal static void UpdateUiForFamilyDebit(string familyName, StackPanel stckTransactions)
        {
            StackPanel stckIndividualTransaction = AddUiElements.AddHorizontalStackPanel();
            TextBlock familyConsumptionLabel = AddUiElements.AddFamilyConsumptionTextBlock(familyName);
            TextBox priceLabel = AddUiElements.AddConsumptionValueTextBox();
            AddUiElements.AddChildrenElement(stckIndividualTransaction, familyConsumptionLabel);
            AddUiElements.AddChildrenElement(stckIndividualTransaction, priceLabel);
            AddUiElements.AddChildrenElement(stckTransactions, stckIndividualTransaction);
        }


        internal static void ShowResult(List<FamilyModel> families, string currency)
        {
            string output = "";
            foreach (FamilyModel fam in families)
            {
                output += $"Balance of {fam.familyName} family: {fam.balance}{currency}\n";

            }
            MessageBox.Show(output);
        }
    }
}
