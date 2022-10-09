using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferApp.TransferCommand
{
    internal class GetMainWindowItem
    {

        public static List<int> MVII { get; set; }
        public string fullball { get; set; }
        public string fullDistributed { get; set; }
        public string remainderNext { get; set; }



        public GetMainWindowItem()
        {
         MVII = new List<int>(8) { 0, 0, 0, 0, 0, 0, 0, 0 };
            fullball = fullDistributed = remainderNext = "";
        }
        public void WindowTextChange(int index, string item)
        {
            MVII[Convert.ToInt32(index) - 1] = Convert.ToInt32(item);
            fullball = (MVII[0] + MVII[1] + MVII[2] - MVII[3] + MVII[4] - MVII[5]).ToString();
            fullDistributed = (MVII[6] + MVII[7]).ToString();
            remainderNext = (Convert.ToInt32(fullball) - Convert.ToInt32(fullDistributed)).ToString();
        }

    }
}
