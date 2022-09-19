using System.Collections.ObjectModel;
using System.ComponentModel;
using TransferMVVM;

namespace TransferMVVM
{
	internal class ApplicationViewModelTransfer : INotifyPropertyChanged
	{

		public ObservableCollection<string> monthes { get; set; }
		public ObservableCollection<string> regions { get; set; }


		public ApplicationViewModelTransfer()
		{
			monthes = new ObservableCollection<string>();
			foreach (var mnt in ItemsTransfer.ExportMonthes())
			{
				monthes.Add(mnt);
			}
			regions = new ObservableCollection<string>();
			foreach (var rg in ItemsTransfer.ExportRegions())
			{
				regions.Add(rg);
			}

		}



		public event PropertyChangedEventHandler? PropertyChanged;
		protected virtual void OnPropertyChanged(string? propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}


