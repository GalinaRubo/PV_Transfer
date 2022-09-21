using TransferApp.ViewModels.Base;
using System.Collections.ObjectModel;

namespace TransferApp.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {

        public ObservableCollection<string> monthes { get; set; }
        public ObservableCollection<string> regions { get; set; }


        public MainWindowViewModel()
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
    }
}
