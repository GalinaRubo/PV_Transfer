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
using TransferApp.TransferCommand;

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
