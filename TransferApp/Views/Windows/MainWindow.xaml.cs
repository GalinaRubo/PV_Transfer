using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TransferApp.TransferCommand;
using TransferApp.ViewModels;
using TransferApp.ViewModels.Base;
using TransferApp.WindowsTransfer;
using AppContext = TransferApp.TransferCommand.AppContext;

namespace TransferApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppContext db = new AppContext();
        MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
        Dictionary<string, string> id_ball = new Dictionary<string, string>();
        Dictionary<string, string> id_fio = new Dictionary<string, string>();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel();
            Month.ItemsSource = mainWindowViewModel.monthes;
            Region.ItemsSource = mainWindowViewModel.regions;
            
    }

        private void Month_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mainWindowViewModel._month = (string)Month.SelectedItem;
        }
        private void year_OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                mainWindowViewModel._year = "20" + year.Text;
                Remainder.Focus();
            }
        }

        private void Region_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mainWindowViewModel._region = (string)Region.SelectedItem;
            mainWindowViewModel._year = "20" + year.Text;
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
                int number;
                bool success = int.TryParse(ID.Text, out number);
                if (success)
                {
                    GetDistributor Distributor = new GetDistributor(Convert.ToInt32(ID.Text));
                    if (Distributor.distributor != null)
                    {
                        mainWindowViewModel._id = ID.Text;
                        var dateTime = File.GetCreationTime("distributors.db");
                        UpdateBD.Text = mainWindowViewModel._obn = dateTime.ToString("dd-MM-yyyy");
                        FIO.Text = mainWindowViewModel._fio = Distributor.distributor.Name;
                        Contact.Text = mainWindowViewModel._contact = Distributor.distributor.Email;

                    }
                    else
                    {
                        FIO.Text = "";
                        Contact.Text = "";
                        MessageBox.Show("ID нет в БД");
                    }
                }
                else MessageBox.Show("Ошибка ввода");
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

                mainWindowViewModel.WindowTextChange(2, Problem.Text);
                FullBall.Text = mainWindowViewModel.fullball;
                RemainderNext.Text = mainWindowViewModel.remainderNext;
                ListZakaz.Focus();
            }
        }

        private void ListZakaz_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void ListZakaz_OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                mainWindowViewModel.WindowTextChange(3, ListZakaz.Text);
                FullBall.Text = mainWindowViewModel.fullball;
                RemainderNext.Text = mainWindowViewModel.remainderNext;
                ListBack.Focus();
            }
        }
        private void ListBack_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ListBack_OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                mainWindowViewModel.WindowTextChange(4, ListBack.Text);
                FullBall.Text = mainWindowViewModel.fullball;
                RemainderNext.Text = mainWindowViewModel.remainderNext;
                GetBall.Focus();
            }

        }

        private void GetBall_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void GetBall_OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                mainWindowViewModel.WindowTextChange(5, GetBall.Text);
                FullBall.Text = mainWindowViewModel.fullball;
                RemainderNext.Text = mainWindowViewModel.remainderNext;
                SetBall.Focus();
            }

        }

        private void SetBall_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void SetBall_OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                mainWindowViewModel.WindowTextChange(6, SetBall.Text);
                FullBall.Text = mainWindowViewModel.fullball;
                RemainderNext.Text = mainWindowViewModel.remainderNext;
            }

        }

        private void FullBall_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ListDistributed_TextChanged(object sender, TextChangedEventArgs e)
        {

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
                mainWindowViewModel.WindowTextChange(1, Remainder.Text);
                FullBall.Text = mainWindowViewModel.fullball;
                RemainderNext.Text = mainWindowViewModel.remainderNext;
                Problem.Focus();
            }
        }

        private void ID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListDistributed_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TablDistBall tablDistBall = new TablDistBall();
            tablDistBall.ShowDialog();
            mainWindowViewModel.listdistrball = tablDistBall.StrRep;
            ListDistributed.Text = tablDistBall.Itog;
            mainWindowViewModel.WindowTextChange(7, ListDistributed.Text);
            RemainderNext.Text = mainWindowViewModel.remainderNext;
        }


    }
}
