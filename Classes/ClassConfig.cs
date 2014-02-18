/*
 * Сделано в SharpDevelop.
 * Пользователь: Сомов Евгений Павлович
 * Дата: 14.09.2013
 * Время: 9:06
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.IO;

namespace Rapid
{
	/// <summary>
	/// Description of ClassConfig.
	/// </summary>
	public static class ClassConfig
	{
		//адрес программы
		public static String Rapid_ProgramPath = "";
		//папка ресурсов
		public static String Rapid_Resource = "";
		//файл локальной базы (список конфигураций)
		public static String Rapid_FileListBase = "";
		//OleDb подключение:
		public static String ConnectLineBegin = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
		public static String ConnectLineEnd = ";Jet OLEDB:Database Password=";
		public static String ConnectPass = "12345";
		//Конфигурация запускаемого приложения
		public static String Rapid_Run_Type = "";
		public static String Rapid_Run_Name = "";
		public static String Rapid_Run_Server = "";
		public static String Rapid_Run_DataBase = "";
		public static String Rapid_Run_Uid = "";
		public static String Rapid_Run_Pwd = "";
		public static String Rapid_Run_Admin = "";
		public static String Rapid_Run_Client = "";
		public static String Rapid_Run_UserName = "";
		//Информация о пользователе и его правах
		public static String Rapid_Client_UserName = "";
		public static String Rapid_Client_UserRight = "";
	}
}
