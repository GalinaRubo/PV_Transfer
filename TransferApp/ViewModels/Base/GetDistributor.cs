using System.Windows;
using TransferApp.SQLite;
using TransferApp.TransferCommand;

namespace TransferApp.ViewModels.Base
{
    internal class GetDistributor
    {

        public Distributor distributor { get; set; }

        public GetDistributor(int number)
        {
            distributor = new Distributor() { };
            distributor = null;
            if (number > 0) distributor = NewDistributer(number);
            else
            {
                IdWindow idWindow = new IdWindow();
                if (idWindow.ShowDialog() == true)
                    distributor = NewDistributer(idWindow.DistributorNumber);
                if (distributor == null)
                    MessageBox.Show("ID нет в БД");
            }
        }
        public Distributor NewDistributer(int _number)
        {
            ApplicationViewModel ob = new ApplicationViewModel();
            foreach (var ds in ob.Distributors)
            {
                if (ds.Number == _number)
                {
                    return ds;
                }
            }
            return null;
        }
    }

}
