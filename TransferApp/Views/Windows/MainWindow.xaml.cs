using System.Windows;
using System.Windows.Controls;
using TransferApp.ViewModels;
using TransferApp.TransferCommand;
using TransferApp.SQLite;
using System.IO;

namespace TransferApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
	{
       AppContext db = new AppContext();

		public MainWindow()
		{
			InitializeComponent();
            DataContext = new ApplicationViewModel();
        }

        private void Month_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
            DataContext = new MainWindowViewModel();
        }

		private void Region_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
            DataContext = new MainWindowViewModel();
        }

        private void ButtonRed_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Remainder_TextChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Ид_Text_Text(object sender, RoutedEventArgs e)
        {
      

        }

        private void Ид_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GetDistributor Distributor = new GetDistributor();
                if (Distributor.distributor != null)
            {
                var dateTime = File.GetCreationTime("distributors.db");
                UpdateBD.Text = dateTime.ToString();
                ID.Content = Distributor.distributor.Number;
                FIO.Text = Distributor.distributor.Name;
                Contact.Text = Distributor.distributor.Email;
            };
        }

        private void Contact_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}
