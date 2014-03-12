/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 10.03.2014
 * Время: 17:09
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Data;

namespace Rapid
{
	/// <summary>
	/// Description of ClassBalance.
	/// </summary>
	public static class ClassBalance
	{
		/* Ввод нового товара в остатки */
		public static void BalanceNew(String NameTMC)
		{
			ClassMySQL_Short SqlCommandBalance = new ClassMySQL_Short();
			String DateInsert = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
			SqlCommandBalance.SqlCommand = "INSERT INTO balance (balance_tmc, balance_date, balance_number) VALUE ('" + NameTMC + "', '" + DateInsert + "', 0)";
			if(SqlCommandBalance.ExecuteNonQuery()){
				ClassForms.Rapid_Client.MessageConsole("Остатки: Новая запись успешно добавлена.", false);
			} else ClassForms.Rapid_Client.MessageConsole("Остатки: Ошибка ввода новой записи в таблицу 'Остатки'", true);
		}
		
		/* Изменение имени в карточке товара остатков */
		public static void BalanceEdit(String NewNameTMC, String NameTMC)
		{
			ClassMySQL_Short SqlCommandBalance = new ClassMySQL_Short();
			SqlCommandBalance.SqlCommand = "UPDATE balance SET balance_tmc = '" + NewNameTMC + "' WHERE (balance_tmc = '"+NameTMC+"')";
			if(SqlCommandBalance.ExecuteNonQuery()){
				ClassForms.Rapid_Client.MessageConsole("Остатки: успешное изменение имени ТМЦ в остатках.", false);
			}else ClassForms.Rapid_Client.MessageConsole("Остатки: Ошибка изменений в таблице 'Остатки', переименование тмц.", true);
						
		}
		
		/* Показать остаток на складе */
		public static String BalanceShow(String _tmcName, String _actualDate)
		{
			ClassMySQL_Full balanceMySQL = new ClassMySQL_Full();
			DataSet balanceDataSet = new DataSet();
			balanceDataSet.Clear();
			balanceDataSet.DataSetName = "balance";
			balanceMySQL.SelectSqlCommand = "SELECT * FROM balance WHERE (balance_tmc = '" + _tmcName + "' AND balance_date <= '" + _actualDate + "')";
			if(balanceMySQL.ExecuteFill(balanceDataSet, "balance")){
				DataTable table = balanceDataSet.Tables["balance"];
				if(table.Rows.Count > 0){
					return table.Rows[0]["balance_number"].ToString();
				} else return "--";
			} else return "--";
		}
		
		/* Обновление данных в остатках */
		public static void BalancePlus(DataSet ResourceDS)
		{
			
		}
		
		public static void BalanceMinus()
		{
			
		}
		
		public static void BalanceUpdate()
		{
			
		}
	}
}
