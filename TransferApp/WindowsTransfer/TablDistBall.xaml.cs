using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TransferApp.ViewModels;
using Key = System.Windows.Input.Key;

namespace TransferApp.WindowsTransfer
{
    /// <summary>
    /// Логика взаимодействия для TablDistBall.xaml
    /// </summary>
    public partial class TablDistBall : Window
    {
        TableWindowViewModel tableWindowViewModel = new TableWindowViewModel();
        public string StrRep;
        public string Itog;

        public TablDistBall()
        {
           
            InitializeComponent();
            _ИД_участника.Focus();
        }


        private void _ID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void _ID_OnKeyDownHandler(object sender, KeyEventArgs e)
        {
			_Итого.Text = _Баллы_участника.Text = string.Empty;

			if (e.Key == Key.Return)
            {
             tableWindowViewModel.GetFIO(_ИД_участника.Text);
             _ФИО_участника.Text = tableWindowViewModel.fio;
             _Итого.Text = tableWindowViewModel.itogo_dir;
            }
        }

        private void _Ball_TextChanged(object sender, TextChangedEventArgs e)
        {
 
        }
        private void _Ball_OnKeyDownHandler(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Return)
            {
                tableWindowViewModel.GetItogo(_Баллы_участника.Text, _Итого.Text, true);
            }
            if ((e.Key == Key.RightShift))
            {
                tableWindowViewModel.GetItogo(_Баллы_участника.Text, _Итого.Text, false);
            }
            Itog = tableWindowViewModel.itogo;
			_Итого.Text = tableWindowViewModel.itogo_dir;
            StrRep = tableWindowViewModel.strRep;
        }

        private void Роспись_Click(object sender, RoutedEventArgs e)
        {
			MessageBox.Show(StrRep);
		}

        private void _ИД_участника_TextChanged(object sender, TextChangedEventArgs e)
        {
			
        }
    }
}
