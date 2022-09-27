using System.Windows;
using TransferApp.SQLite;

namespace TransferApp.TransferCommand
{
    internal class GetDistributor
    {

        public Distributor distributor { get; set; }

        public GetDistributor()
        {
            distributor = new Distributor() {};
            distributor = null;

            IdWindow idWindow = new IdWindow();
            if (idWindow.ShowDialog() == true)
            {
                ApplicationViewModel ob = new ApplicationViewModel();
                foreach (var ds in ob.Distributors)
                {
                    if (ds.Number == idWindow.DistributorNumber)
                    {
                        distributor = ds;
                        break;
                    }                      
                }
                if (distributor == null)
                MessageBox.Show("ID нет в БД");              
            }
        }
    }
 
}
