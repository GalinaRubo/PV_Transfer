using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferApp.SQLite
{
    internal class Distributor
    {
        public int Serial_number { get; set; }
        private string Name, ID, Phone;
        public string Dname
        {
            get { return Name; }
            set { Name = value; }
        }
        public string Did
        {
            get { return ID; }
            set { ID = value; }
        }
        public string Dphone
        {
            get { return Phone; }
            set { Phone = value; }
        }
        public Distributor() { }
        public Distributor(string name, string id, string phone)
        {
            Name = name;
            ID = id;
            Phone = phone;
        }
    }
}
