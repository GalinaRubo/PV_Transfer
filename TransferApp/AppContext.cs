using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TransferApp
{
    internal class AppContext :DbContext
    {
        public DbSet<Distributor> Distributors { get; set; }
        public AppContext() : base("DefaultConnection") { }

    }
}
