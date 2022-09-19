using System.Windows;
using TransferMVVM;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;

namespace TransferApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
//        AppContext bd;
		public MainWindow()
		{
			InitializeComponent();
 //           bd = new AppContext();
 //           List<Distributor> distr = bd.Distributors.ToList();
			DataContext = new ApplicationViewModelTransfer();
		}

		private void Month_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void Region_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}
	}
}
