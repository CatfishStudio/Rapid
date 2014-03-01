/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 01.03.2014
 * Время: 10:36
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Data;

namespace Rapid
{
	/// <summary>
	/// Description of ClassCalculation.
	/// </summary>
	public static class ClassCalculation
	{
		/*public ClassCalculation()
		{
			
		}*/
		
		/* Вычисление НДС */
		public static String NDS(String _ndsName, String _sum)
		{
			double _nds;
			ClassMySQL_Full typetaxMySQL = new ClassMySQL_Full();
			DataSet typetaxDataSet = new DataSet();
			typetaxDataSet.Clear();
			typetaxDataSet.DataSetName = " typetax";
			typetaxMySQL.SelectSqlCommand = "SELECT * FROM typetax WHERE (typeTax_name = '" + _ndsName + "')";
			if(typetaxMySQL.ExecuteFill(typetaxDataSet, "typetax")){
				DataTable table = typetaxDataSet.Tables["typetax"];
				// НДС (в %) = Сумма без НДС * Ставка НДС / 100
				_nds = ClassConversion.StringToDouble(_sum) * ClassConversion.StringToDouble(table.Rows[0]["typeTax_rating"].ToString()) / 100.00;
				_nds = Math.Round(_nds, 2);
				return ClassConversion.StringToMoney(_nds.ToString());
				
			}else ClassForms.Rapid_Client.MessageConsole("Заказ: Ошибка получения ставки НДС при вычислении.", true);
			return "0.00";
		}
		
		/* Вычисление Суммы без НДС */
		public static String Sum(String _price, String _number)
		{
			double _sum;
			// Сумма без НДС = Цена * Количество
			_sum = ClassConversion.StringToDouble(_price) * ClassConversion.StringToDouble(_number);
			_sum = Math.Round(_sum, 2);
			return ClassConversion.StringToMoney(_sum.ToString());
		}
		
		/* Вычислить Всего с НДС */
		public static String Total(String _sum, String _nds)
		{
			double _total;
			// Всего с НДС = Сумма без НДС + НДС
			_total = ClassConversion.StringToDouble(_sum) + ClassConversion.StringToDouble(_nds);
			_total = Math.Round(_total, 2);
			return ClassConversion.StringToMoney(_total.ToString());
		}
		
		/* Изменение НДС вычисляем сумму*/
		public static String ChangeNDS_ReturnPrice(String _number, String _nds)
		{
			double _sum;
			double _price;
			// Сумма без НДС = НДС * 5
			_sum = ClassConversion.StringToDouble(_nds) * 5;
			_sum = Math.Round(_sum, 2);
			// Цена =  Сумма без НДС / количество
			_price = _sum / ClassConversion.StringToDouble(_number);
			_price = Math.Round(_price, 2);
			return ClassConversion.StringToMoney(_price.ToString());
		}
		
		/* Изменение Суммы без НДС */
		public static String ChangeSum_ReturnPrice(String _sum, String _number)
		{
			double _price;
			//Цена = Сумма без НДС / Количество
			_price = ClassConversion.StringToDouble(_sum) / ClassConversion.StringToDouble(_number);
			_price = Math.Round(_price, 2);
			return ClassConversion.StringToMoney(_price.ToString());
		}
		
		/* Изменение Всего с НДС */
		public static String ChangeTotal_ReturnNDS(String _total, String _ndsName)
		{
			
			ClassMySQL_Full typetaxMySQL = new ClassMySQL_Full();
			DataSet typetaxDataSet = new DataSet();
			typetaxDataSet.Clear();
			typetaxDataSet.DataSetName = " typetax";
			typetaxMySQL.SelectSqlCommand = "SELECT * FROM typetax WHERE (typeTax_name = '" + _ndsName + "')";
			if(typetaxMySQL.ExecuteFill(typetaxDataSet, "typetax")){
				DataTable table = typetaxDataSet.Tables["typetax"];
				if(ClassConversion.StringToDouble(table.Rows[0]["typeTax_rating"].ToString()) > 0)
				{
					double _nds;
					// НДС = Всего с НДС / 6
					_nds = ClassConversion.StringToDouble(_total) / 6;
					_nds = Math.Round(_nds, 2);
					return ClassConversion.StringToMoney(_nds.ToString());
				} else return "0.00";
				
			}else ClassForms.Rapid_Client.MessageConsole("Заказ: Ошибка получения ставки НДС при вычислении.", true);
			return "0.00";
		}
	}
}
