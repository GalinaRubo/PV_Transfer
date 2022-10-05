using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace TransferApp.TransferCommand
{
    internal static class TransferFile
    {
        public static void TransferToFile(string str_data)
        {
            string str_sample =
"PV Transfer                                                                \n" +
"────────────────────────────────────────────────────────────────          *\n" +
"РЕКВИЗИТЫ                                                                 *\n" +
                "  1. ID участника:                                         \n" +
                "  2. Месяц:                                                \n" +
                "  3. Условное обозначение региона:                         \n" +
                "  4. Последнее обновление БД:                              \n" +
                "  5. E-mail:                                               \n" +
                "ПРОИСХОЖДЕНИЕ ОЧКОВ                                       *\n" +
                "  6. Перенос баллов с прошлого месяца:                     \n" +
                "  7. Проблемные баллы прошлого месяца:                     \n" +
                "  8. Баллы заказов на складах центральных офисов:          \n" +
                "  9. Баллы возвратов на складах центральных офисов:        \n" +
                " 10. Получено баллов из других отчетов:                    \n" +
                " 11. Передано баллов в другие отчеты:                      \n" +
                " 12. Итого баллов:                                         \n" +
                "РОСПИСЬ ОЧКОВ                                             *\n" +               
                " 14. Итого расписано очков:                                \n" +
                " 15. Перенос очков на следующий месяц:                     \n";

            string[] data = str_data.Split(new char[] { '\n' });
            string[] sample = str_sample.Split(new char[] { '\n' });
            int[] str_ends = new int[20];
            DateTime dt = DateTime.Today;
            int i = 0;
            foreach (var s in sample)
            {
                if (i == 0) str_ends[0] = s.Length;
                else str_ends[i] = s.Length + str_ends[i - 1] + 1;
                i++;
            }
            i = 0;
            str_sample = Insert_str(str_sample, str_ends[0], dt.ToString("dd-MM-yyyy"));
            for (int j = 1; j < 19; j++)
            {
                    if (sample[j].IndexOf("*") != -1) str_sample = Insert_str(str_sample, str_ends[j], "*");
                    else
                    {
                        if (j == 3 || j == 4)
                        {
                            str_sample = Insert_str(str_sample, str_ends[j], data[i] + "     " + data[i + 1]);
                            i++;
                        }
                        else str_sample = Insert_str(str_sample, str_ends[j], data[i]);
                        i++;
                    }
            }
            int index = str_ends[16];
            while (i < data.Length)
            {
                str_sample = str_sample.Insert(index, "\n" + data[i]);
                index = index + data[i].Length + 1;
                i++;
            }
            File.WriteAllText(data[2] + data[0] + ".txt", str_sample, Encoding.Default);

            MessageBox.Show(str_sample);

        }
        public static string Insert_str(string _str, int index, string sub_str)
        {
            _str = _str.Remove(index - sub_str.Length, sub_str.Length);
            if (sub_str == "*") sub_str = " ";
            _str = _str.Insert(index - sub_str.Length, sub_str);
            return _str;
        }
    }
}
