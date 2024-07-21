// AddTransactionWindow.xaml.cs
using System;
using System.Windows;
using FinanceManager.Models;

namespace FinanceManager
{
    public partial class AddTransactionWindow : Window
    {
        public Transaction Transaction { get; private set; }

        public AddTransactionWindow(int id)
        {
            InitializeComponent();  // This should be correctly generated by the designer
            Transaction = new Transaction { Id = id, Date = DateTime.Now };
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(textBoxAmount.Text, out decimal amount))
            {
                Transaction.Description = textBoxDescription.Text;
                Transaction.Amount = amount;
                Transaction.Category = textBoxCategory.Text;

                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Please enter a valid amount.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
