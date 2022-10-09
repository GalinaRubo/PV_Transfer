using System.Collections.ObjectModel;
using TransferApp.ViewModels;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using TransferApp.SQLite;
using TransferApp.ViewModels.Base;

namespace TransferApp.TransferCommand
{
    public class ApplicationViewModel
    {
        AppContext db = new AppContext();
        TransferCommand? addCommand;
        TransferCommand? editCommand;
        TransferCommand? deleteCommand;
        TransferCommand? createCommand;

        public ObservableCollection<Distributor> Distributors { get; set; }

        public ApplicationViewModel()
        {
            db.Database.EnsureCreated();
            db.Distributors.Load();
            Distributors = db.Distributors.Local.ToObservableCollection();
        }


        // команда добавления
        public TransferCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new TransferCommand((o) =>
                  {
                      DistributorWindow distrubutorWindow = new DistributorWindow(new Distributor());
                      if (distrubutorWindow.ShowDialog() == true)
                      {
                          Distributor distributor = distrubutorWindow._Distributor;
                          db.Distributors.Add(distributor);
                          db.SaveChanges();
                      }
                  }));
            }
        }
        // команда редактирования
        public TransferCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new TransferCommand((o) =>
                  {
                      GetDistributor _distributor = new GetDistributor(0);
                      Distributor distributorObn = _distributor.distributor;
                      if (distributorObn != null)
                      {

                          DistributorWindow distrubutorWindow = new DistributorWindow(new Distributor
                          {
                              Id = distributorObn.Id,
                              Number = distributorObn.Number,
                              Name = distributorObn.Name,
                              Email = distributorObn.Email
                          }
                          );

                          if (distrubutorWindow.ShowDialog() == true)
                          {

                              distributorObn = db.Distributors.Find(distrubutorWindow._Distributor.Id);

                              if (distributorObn != null)

                                  distributorObn.Number = distrubutorWindow._Distributor.Number;
                              distributorObn.Name = distrubutorWindow._Distributor.Name;
                              distributorObn.Email = distrubutorWindow._Distributor.Email;

                              db.Entry(distributorObn).State = EntityState.Modified;
                              db.SaveChanges();
                          }
                      }
                  }));
            }
        }
        // команда удаления
        public TransferCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new TransferCommand((o) =>
                  {
                      // получаем выделенный объект
                      GetDistributor _distributor = new GetDistributor(0);
                      Distributor distributorDel = _distributor.distributor;
                      if (distributorDel != null)
                      {
                          DistributorWindow distrubutorWindow = new DistributorWindow(new Distributor
                          {
                              Id = distributorDel.Id,
                              Number = distributorDel.Number,
                              Name = distributorDel.Name,
                              Email = distributorDel.Email
                          }
                         );

                          if (distrubutorWindow.ShowDialog() == true)
                          {

                              distributorDel = db.Distributors.Find(distrubutorWindow._Distributor.Id);

                              if (distributorDel != null)
                                  db.Distributors.Remove(distributorDel);
                              db.SaveChanges();
                          }
                      }
                  }));
            }
        }
        //команда создания отчета
        public TransferCommand CreateCommand
        {
            get
            {
                return createCommand ??
                  (createCommand = new TransferCommand((o) =>
                  {
                      string exportStr = "";

                      foreach (var item in MainWindowViewModel.MVIS)
                      {
                          exportStr = exportStr + item.ToString() + "\n";
                      }
                      //                  MessageBox.Show(exportStr);
                      TransferFile.TransferToFile(exportStr);
                  }));
            }
        }
    }
}
