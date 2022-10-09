using TransferApp.ViewModels.Base;
using System.Collections.ObjectModel;
using TransferApp.SQLite;
using TransferApp.TransferCommand;
using System;
using System;
using System.Collections.Generic;
using System.Windows;

namespace TransferApp.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {

        public ObservableCollection<string> monthes { get; set; }
        public ObservableCollection<string> regions { get; set; }

        public static List<string> MVIS { get; set; }
        public static List<int> MVII { get; set; }
        public string _id { get; set; }
        public string _fio { get; set; }
        public string _month { get; set; }
        public string _year { get; set; }
        public string _region { get; set; }
        public string _obn { get; set; }
        public string _contact { get; set; }
        public string fullball { get; set; }
        public string listdistrball { get; set; }
        public string remainderNext { get; set; }



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

            MVII = new List<int>(7) {0,0,0,0,0,0,0};
            
            MVIS = new List<string>(17) {"0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", };            
            fullball = remainderNext = listdistrball = _id = _fio = _month = _year = _region = _obn = _contact = "";            
        }
        public void WindowTextChange(int index, string item)

        {
            int number;
            bool success = int.TryParse(item, out number);
            if (success)
            {
                if (item == String.Empty) item = "0";
                MVII[index - 1] = Convert.ToInt32(item);
                fullball = (MVII[0] + MVII[1] + MVII[2] - MVII[3] + MVII[4] - MVII[5]).ToString();
                remainderNext = (Convert.ToInt32(fullball) - MVII[6]).ToString();

                MVIS[0] = _id;
                MVIS[1] = _fio;
                MVIS[2] = _month;
                MVIS[3] = _year;
                MVIS[4] = _region;
                MVIS[5] = _obn;
                MVIS[6] = _contact;
                MVIS[7] = MVII[0].ToString();
                MVIS[8] = MVII[1].ToString();
                MVIS[9] = MVII[2].ToString();
                MVIS[10] = MVII[3].ToString();
                MVIS[11] = MVII[4].ToString();
                MVIS[12] = MVII[5].ToString();
                MVIS[13] = fullball;
                MVIS[14] = MVII[6].ToString();
                MVIS[15] = listdistrball;
                MVIS[16] = remainderNext;
            }
            else MessageBox.Show("Ошибка ввода");

            MVII = new List<int>(7) {0,0,0,0,0,0,0};
            
            MVIS = new List<string>(17) {"0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", };            
            fullball = remainderNext = listdistrball = _id = _fio = _month = _year = _region = _obn = _contact = "";            
        }
        public void WindowTextChange(int index, string item)

        {
            int number;
            bool success = int.TryParse(item, out number);
            if (success)
            {
                if (item == String.Empty) item = "0";
                MVII[index - 1] = Convert.ToInt32(item);
                fullball = (MVII[0] + MVII[1] + MVII[2] - MVII[3] + MVII[4] - MVII[5]).ToString();
                remainderNext = (Convert.ToInt32(fullball) - MVII[6]).ToString();

                MVIS[0] = _id;
                MVIS[1] = _fio;
                MVIS[2] = _month;
                MVIS[3] = _year;
                MVIS[4] = _region;
                MVIS[5] = _obn;
                MVIS[6] = _contact;
                MVIS[7] = MVII[0].ToString();
                MVIS[8] = MVII[1].ToString();
                MVIS[9] = MVII[2].ToString();
                MVIS[10] = MVII[3].ToString();
                MVIS[11] = MVII[4].ToString();
                MVIS[12] = MVII[5].ToString();
                MVIS[13] = fullball;               
                MVIS[14] = MVII[6].ToString();
                MVIS[15] = remainderNext;
                MVIS[16] = listdistrball;
            }
            else MessageBox.Show("Ошибка ввода");
        }
    }
}



