using System.Windows;
using TransferApp.TransferCommand;

namespace TransferApp.SQLite
{
    /// <summary>
    /// Логика взаимодействия для DistributorWindow.xaml
    /// </summary>
    public partial class DistributorWindow : Window
    {
        public Distributor _Distributor { get; private set; }
        public DistributorWindow(Distributor distributor)
        {
            InitializeComponent();
            _Distributor = distributor;
             DataContext = distributor;
        }

        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Cansel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
