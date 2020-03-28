using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace wpf_ui
{
    internal static class AddUiElements
    {
        internal static StackPanel AddHorizontalStackPanel()
        {
            StackPanel stckIndividualTransaction = new StackPanel();
            stckIndividualTransaction.Orientation = Orientation.Horizontal;
            return stckIndividualTransaction;
        }

        internal static TextBlock AddFamilyConsumptionTextBlock(string familyName)
        {
            TextBlock label = new TextBlock();
            label.Width = 250;
            label.Text = $"Consumption of {familyName} family: ";
            return label;
        }

        internal static TextBox AddConsumptionValueTextBox()
        {
            TextBox priceLabel = new TextBox();
            priceLabel.Width = 80;
            return priceLabel;
        }

        internal static void AddChildrenElement(Panel parent, UIElement child)
        {
            parent.Children.Add(child);
        }
    }
}
