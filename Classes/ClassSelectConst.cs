/*
 * Сделано в SharpDevelop.
 * Пользователь: ADMIN
 * Дата: 16.02.2014
 * Время: 11:48
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Data;

namespace Rapid
{
	/// <summary>
	/// Description of ClassSelectConst.
	/// </summary>
	public static class ClassSelectConst
	{
		
		/*Возвращает значение выбранной константы */
		public static String constantValue(String constName)
		{
			ClassMySQL_Full _constMySQL = new ClassMySQL_Full();
			DataSet _constDataSet = new DataSet();
			_constDataSet.Clear();
			_constDataSet.DataSetName = "constants";
			_constMySQL.SelectSqlCommand = "SElECT * FROM constants WHERE (const_name = '" + constName + "')";
			if(_constMySQL.ExecuteFill(_constDataSet, "constants")){
				DataTable table = _constDataSet.Tables["constants"];
				return table.Rows[0]["const_value"].ToString();
			}else return "";
		}
	}
}
