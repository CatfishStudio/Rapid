/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 15.03.2014
 * Время: 15:36
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Rapid
{
	/// <summary>
	/// Description of ClassOperations.
	/// </summary>
	public static class ClassOperations
	{
		/* Ввод новой операции */
		public static bool OperationAdd(String _date, String _dt, String _kt, String _sum, String _specification, String _docID)
		{
			ClassMySQL_Short _mySQL = new ClassMySQL_Short();
			_mySQL.SqlCommand = "INSERT INTO operations (operations_date, operations_id_doc, operations_DT, operations_KT, operations_sum, operations_specification) VALUE ('" + _date + "', '" + _docID + "', " + _dt + ", " + _kt + ", " + _sum + ", '" + _specification + "')";
			if (_mySQL.ExecuteNonQuery()){
				// ИСТОРИЯ: Запись в журнал истории обновлений
				ClassServer.SaveUpdateInBase(12, DateTime.Now.ToString(), "", "Создана новая операция.", "");
				ClassForms.Rapid_Client.MessageConsole("Операция: Успешно сохранена новая операция.", false);
				return true;
			} else {
				ClassForms.Rapid_Client.MessageConsole("Операция: Ошибка сохранения новой операции.", true);
				return false;
			}
		}
		
		/* Изменение операции */
		public static bool OperationEdit(String _date, String _dt, String _kt, String _sum, String _specification, String _docID, String _id)
		{
			ClassMySQL_Short _mySQL = new ClassMySQL_Short();
			if(_docID != "") _mySQL.SqlCommand = "UPDATE operations SET operations_date = '" + _date + "', operations_DT = " + _dt + ", operations_KT = " + _kt + ", operations_sum = " + _sum + ", operations_specification = '" + _specification + "' WHERE (operations_id_doc = " + _docID + ")";
			if(_id != "") _mySQL.SqlCommand = "UPDATE operations SET operations_date = '" + _date + "', operations_DT = " + _dt + ", operations_KT = " + _kt + ", operations_sum = " + _sum + ", operations_specification = '" + _specification + "' WHERE (id_operations = " + _id + ")";
			if (_mySQL.ExecuteNonQuery()){
				// ИСТОРИЯ: Запись в журнал истории обновлений
				ClassServer.SaveUpdateInBase(12, DateTime.Now.ToString(), "", "Изменение операции.", "");
				ClassForms.Rapid_Client.MessageConsole("Операция: Успешно сохранена изменённой операции.", false);
				return true;
			} else {
				ClassForms.Rapid_Client.MessageConsole("Операция: Ошибка сохранения изменённой операции.", true);
				return false;
			}
		}
		
		/* Удаление операции */
		public static bool OperationDelete(String _docID, String _id)
		{
			ClassMySQL_Short _mySQL = new ClassMySQL_Short();
			if(_docID != "") _mySQL.SqlCommand = "DELETE FROM operations WHERE (operations_id_doc = '" + _docID + "')";
			if(_id != "") _mySQL.SqlCommand = "DELETE FROM operations WHERE (id_operations = " + _id + ")";
			if (_mySQL.ExecuteNonQuery()){
				// ИСТОРИЯ: Запись в журнал истории обновлений
				ClassServer.SaveUpdateInBase(12, DateTime.Now.ToString(), "", "Удаление операции.", "");
				ClassForms.Rapid_Client.MessageConsole("Операция: Успешное удаление операции.", false);
				return true;
			} else {
				ClassForms.Rapid_Client.MessageConsole("Операция: Ошибка удаления операции.", true);
				return false;
			}
		}
	}
}
