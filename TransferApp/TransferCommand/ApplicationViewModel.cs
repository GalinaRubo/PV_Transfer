using System;
using System.Collections.ObjectModel;
using TransferApp.ViewModels;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using TransferApp.SQLite;
using Microsoft.VisualBasic;

namespace TransferApp.TransferCommand
{
    public class ApplicationViewModel
    {
        AppContext db = new AppContext();
        TransferCommand? addCommand;
        TransferCommand? editCommand; 
        TransferCommand? deleteCommand;
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
                      GetDistributor _distributor = new GetDistributor();
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
                      GetDistributor _distributor = new GetDistributor();
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
    }
}
