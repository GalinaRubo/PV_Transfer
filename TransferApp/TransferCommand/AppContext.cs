using Microsoft.EntityFrameworkCore;
using TransferApp.ViewModels.Base;

namespace TransferApp.TransferCommand
{
    public class AppContext : DbContext
    {

        public DbSet<Distributor> Distributors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=distributors.db");
        }

    }
}
