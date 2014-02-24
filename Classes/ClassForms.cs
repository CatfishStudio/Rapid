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
		public static FormClient Rapid_Client; 				// главная форма клиента
		public static FormClientConst Rapid_ClientConst; 	// форма "константы"
		public static FormClientFirms Rapid_ClientFirms; 	// форма "фирмы"
		public static FormClientTmc Rapid_ClientTmc; 		// форма "ТМЦ"
		public static FormClientStore Rapid_ClientStore; 	// форма "склады"
		public static FormClientUnits Rapid_ClientUnits;	// форма "ед. измерения"
		public static FormClientTypeTax Rapid_ClientTypeTax;// форма "вид налога"
		public static FormClientStaff Rapid_ClientStaff;	// форма "сотрудники"
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
		public static bool OpenCloseFormStore;	// флаг открытия форма "Склады"
		public static bool OpenCloseFormUnits;	// флаг открытия форма "Ед. изм"
		public static bool OpenCloseFormTypeTax;// флаг открытия форма "Вид НДС"
		public static bool OpenCloseFormStaff;	// флаг открытия форма "Сотрудники"
		public static bool OpenCloseFormJournal;// флаг открытия форма "Журнал документов"
		public static bool OpenCloseFormOperations;		// флаг открытия форма "Операции"
		public static bool OpenCloseFormPlanAccounts;	// флаг открытия форма "План счетов"
		//------------------------------------------------------------
	}
}
