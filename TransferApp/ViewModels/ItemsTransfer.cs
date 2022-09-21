using System.Collections.Generic;

namespace TransferApp.ViewModels
{
	internal class ItemsTransfer
	{
		public static List<string> ExportMonthes()
		{
			var monthes = new List<string>() { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
			return monthes;
		}
		public static List<string> ExportRegions()
		{
			var regions = new List<string>() { "Москва", "Новосибирск"};
			return regions;
		}
	}
}

