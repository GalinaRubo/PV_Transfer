using System;
using System.Windows;
using System.Windows.Controls;

namespace TransferApp.SQLite
{
    /// <summary>
    /// Логика взаимодействия для IdWindow.xaml
    /// </summary>
    public partial class IdWindow : Window
    {
        public int DistributorNumber { get; private set; }

        public IdWindow()
        {          
         InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
         DistributorNumber = Convert.ToInt32(_Number.Text); 
        }
        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
