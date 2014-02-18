/*
 * Сделано в SharpDevelop.
 * Пользователь: Сомов Евгений Павлович
 * Дата: 12.09.2013
 * Время: 14:44
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using Rapid.Client.Firms;

namespace Rapid
{
	/// <summary>
	/// Description of ClassForms.
	/// </summary>
	public static class ClassForms
	{
		//форма выбора загружаемой конфигурации
		public static FormSelectLoad Rapid_SelectLoad;
		//форма ввода и редактирования данных о доступных конфигурациях
		public static FormEditListConnect Rapid_EditListConnect;
		//форма выбора пользователя и ввода пароля
		public static FormSelectUser Rapid_SelectUser;
		//формы Клиента ----------------------------------------------
		public static FormClient Rapid_Client; // главная форма клиента
		public static FormClientConst Rapid_ClientConst; // форма "константы"
		public static FormClientFirms Rapid_ClientFirms; // форма "фирмы"
		public static FormClientTmc Rapid_ClientTmc; // форма "ТМЦ"
		//------------------------------------------------------------
		//формы Администратора ---------------------------------------
		public static FormAdministrator Rapid_Administrator;
		public static FormAdminCreateConfig Rapid_CreateConfig;
		public static FormAdminUsers Rapid_Users;
		public static FormAdminUserEdit Rapid_UserEdit;
		//------------------------------------------------------------
		//Флаги открытых форм ----------------------------------------
		public static bool LoadAdministrator = false; // флаг загрузки администратора
		public static bool OpenCloseFormUser;  	// флаг открытия формы "Пользователи"
		public static bool OpenCloseFormConst; 	// флаг открытия формы "Константы"
		public static bool OpenCloseFormFirms; 	// флаг открытия форма "Фирмы"
		public static bool OpenCloseFormTmc;	// флаг открытия форма "ТМЦ"
		//------------------------------------------------------------
	}
}
