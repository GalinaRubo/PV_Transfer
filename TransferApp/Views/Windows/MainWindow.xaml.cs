using System.Windows;
using System.Windows.Controls;
using TransferApp.ViewModels;
using TransferApp.TransferCommand;
using TransferApp.SQLite;
using System.IO;
using System.Windows.Input;
using System;
using AppContext = TransferApp.TransferCommand.AppContext;

namespace TransferApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
	{
       AppContext db = new AppContext();
       GetMainWindowItem getMainWindowItem = new GetMainWindowItem();

        public MainWindow()
		{
			InitializeComponent();
            DataContext = new ApplicationViewModel();
            GetMainWindowItem getMainWindowItem = new GetMainWindowItem();
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

        private void Ид_Text_Text(object sender, RoutedEventArgs e)
        {
      

        }

        private void Ид_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void ID_OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                GetDistributor Distributor = new GetDistributor(Convert.ToInt32(ID.Text));
                if (Distributor.distributor != null)
                {
                    var dateTime = File.GetCreationTime("distributors.db");
                    UpdateBD.Text = dateTime.ToString();
                    FIO.Text = Distributor.distributor.Name;
                    Contact.Text = Distributor.distributor.Email;
                }
                else
                {
                    FIO.Text = "";
                    Contact.Text = "";
                    MessageBox.Show("ID нет в БД");
                }
            }
        }

        private void Contact_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Problem_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Problem_OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {

                getMainWindowItem.WindowTextChange(2, Problem.Text);
                FullBall.Text = getMainWindowItem.fullball;
                RemainderNext.Text = getMainWindowItem.remainderNext;
            }
        }

        private void ListZakaz_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void ListZakaz_OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                getMainWindowItem.WindowTextChange(3, ListZakaz.Text);
                FullBall.Text = getMainWindowItem.fullball;
                RemainderNext.Text = getMainWindowItem.remainderNext;
            }
        }
        private void ListBack_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ListBack_OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                getMainWindowItem.WindowTextChange(4, ListBack.Text);
                FullBall.Text = getMainWindowItem.fullball;
                RemainderNext.Text = getMainWindowItem.remainderNext;
            }

        }

        private void GetBall_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void GetBall_OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                getMainWindowItem.WindowTextChange(5, GetBall.Text);
                FullBall.Text = getMainWindowItem.fullball;
                RemainderNext.Text = getMainWindowItem.remainderNext;
            }

        }

        private void SetBall_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void SetBall_OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                getMainWindowItem.WindowTextChange(6, SetBall.Text);
                FullBall.Text = getMainWindowItem.fullball;
                RemainderNext.Text = getMainWindowItem.remainderNext;
            }

        }

        private void FullBall_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ListDistributed_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void ListDistributed_OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                getMainWindowItem.WindowTextChange(7, ListDistributed.Text);
                FullDistributed.Text = getMainWindowItem.fullDistributed;
                RemainderNext.Text = getMainWindowItem.remainderNext;
            }

        }

        private void HandDistributed_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void HandDistributed_OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                getMainWindowItem.WindowTextChange(8, HandDistributed.Text);
                FullDistributed.Text = getMainWindowItem.fullDistributed;
                RemainderNext.Text = getMainWindowItem.remainderNext;
            }

        }

        private void FullDistributed_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void RemainderNext_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Remainder_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Remainder_OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                getMainWindowItem.WindowTextChange(1, Remainder.Text);
                FullBall.Text = getMainWindowItem.fullball;
                RemainderNext.Text = getMainWindowItem.remainderNext;
            }
        }

        private void ID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ID_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
