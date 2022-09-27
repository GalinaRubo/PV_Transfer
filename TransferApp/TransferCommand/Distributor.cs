using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace TransferApp.TransferCommand
{
    public class Distributor : INotifyPropertyChanged
    {
        int id;
        int num;
        string? name;
        string? email;

        public int Id { get; set; }

        public int Number
        {
            get { return num!; }
            set
            {
                num = value;
                OnPropertyChanged("ID");
            }
        }
        public string? Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Имя");
            }
        }

        public string? Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("E-mail");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
