using TransferApp.ViewModels.Base;
using System.Collections.ObjectModel;
using TransferApp.SQLite;
using TransferApp.TransferCommand;
using System;

namespace TransferApp.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {

        public ObservableCollection<string> monthes { get; set; }
        public ObservableCollection<string> regions { get; set; }

        public string remainder { get; set; }
        public string problem { get; set; }
        public string fullball { get; set; }

        public MainWindowViewModel()
        {
            monthes = new ObservableCollection<string>();
            foreach (var mnt in DataTransfer.ExportMonthes())
            {
                monthes.Add(mnt);
            }
            regions = new ObservableCollection<string>();
            foreach (var rg in DataTransfer.ExportRegions())
            {
                regions.Add(rg);
            }

            remainder = problem = fullball = "";
        }
        public void GetWindowsData(string rem, string pro)
        {
            remainder = rem;
            problem = pro;
            fullball = (Convert.ToInt32(rem) + Convert.ToInt32(pro)).ToString();

        }
    }
}



