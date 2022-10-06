using System;
using System.Collections.Generic;
using System.Windows;
using TransferApp.TransferCommand;

namespace TransferApp.WindowsTransfer
{
    public class TableWindowViewModel
    {

        public Dictionary<string, string> id_ball = new Dictionary<string, string>();
        public Dictionary<string, string> id_fio = new Dictionary<string, string>();
        public string strRep { get; set; }
        public string fio { get; set; }
        public string itogo_dir { get; set; }
        public string itogo { get; set; }
        static string _id;
        public TableWindowViewModel() { }
       
        public void GetFIO(string id)
        {
            int number;
            bool success = int.TryParse(id, out number);
            if (success)
            {
                _id = id;
                GetDistributor Distributor = new GetDistributor(Convert.ToInt32(id));
                if (Distributor.distributor != null)
                {
                    string value;
                    fio = Distributor.distributor.Name;
                    if (id_ball.TryGetValue(id, out value))
                    {
                        itogo_dir = value;
                    }
                    else itogo_dir = "";
                }
                else
                {
                    fio = "";
                    MessageBox.Show("ID нет в БД");
                }
            }
            else MessageBox.Show("Ошибка ввода");
        }
        public void GetItogo(string _ball, string _itogo, bool _key)
        {
            int number;
            bool success = int.TryParse(_ball, out number);
            if (success)
            {
                itogo_dir = _itogo;
                if (itogo_dir == "") itogo_dir = "0";

                if (_key)
                {
                    itogo_dir = ((Convert.ToInt32(itogo_dir) + Convert.ToInt32(_ball)).ToString());
                }
                else
                {
                    itogo_dir = _ball;
                }
                if (id_ball.ContainsKey(_id))
                {
                    id_ball.Remove(_id);
                    id_fio.Remove(_id);
                };
                id_ball.Add(_id, itogo_dir);
                id_fio.Add(_id, fio);


                int it = 0;
                foreach (var ds in id_ball)
                {
                    it += Convert.ToInt32(ds.Value);
                }
                itogo = it.ToString();
                Report();
            }
            else MessageBox.Show("Ошибка ввода");
        }
        public void Report()
        {
            strRep = string.Empty;
            foreach (var b in id_ball)
            {
                foreach (var f in id_fio)
                {
                    if (b.Key == f.Key)
                    {
                        strRep = strRep + f.Key + ";  " + f.Value + ";  " + b.Value + "\n";
                    }
                }
            }          
        }
    }
}
