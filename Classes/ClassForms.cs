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
using Rapid.Service;

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
		public static FormClientPlanAccounts Rapid_ClientPlanAccounts;	// форма "план счетов"
		public static FormClientJournalDoc Rapid_ClientJournalDoc;		// форма "Полного журнала"
		public static FormClientJournalOrder Rapid_ClientJournalOrder;	// форма "Журнал Заказов"
		public static FormClientJournalComing Rapid_ClientJournalComing;// форма "Журнал Приходных накладных"
		public static FormClientJournalExpense Rapid_ClientJournalExpense;	// форма "Журнал Расходных накладных"
		public static FormClientJournalOperations Rapid_ClientJournalOperations; // форма "Журнал бухгалтерских операций"
		//------------------------------------------------------------
		//формы Администратора ---------------------------------------
		public static FormAdministrator Rapid_Administrator;
		public static FormAdminCreateConfig Rapid_CreateConfig;
		public static FormAdminUsers Rapid_Users;
		public static FormAdminUserEdit Rapid_UserEdit;
		//------------------------------------------------------------
		//Формы Сервиса ----------------------------------------------
		public static FormNotePad NotePad;
		//------------------------------------------------------------
		//Флаги открытых форм ----------------------------------------
		public static bool LoadAdministrator = false; // флаг загрузки администратора
		public static bool OpenCloseFormUser;  	// флаг открытия формы "Пользователи"
		public static bool OpenCloseFormConst; 	// флаг открытия формы "Константы"
		public static bool OpenCloseFormFirms; 	// флаг открытия формы "Фирмы"
		public static bool OpenCloseFormTmc;	// флаг открытия формы "ТМЦ"
		public static bool OpenCloseFormStore;	// флаг открытия формы "Склады"
		public static bool OpenCloseFormUnits;	// флаг открытия формы "Ед. изм"
		public static bool OpenCloseFormTypeTax;// флаг открытия формы "Вид НДС"
		public static bool OpenCloseFormStaff;	// флаг открытия формы "Сотрудники"
		public static bool OpenCloseFormOperations;		// флаг открытия формы "Операции"
		public static bool OpenCloseFormPlanAccounts;	// флаг открытия формы "План счетов"
		public static bool OpenCloseFormJournalDoc;		// флаг открытия формы "Полный журнал"
		public static bool OpenCloseFormJournalOrder;	// флаг открытия формы "Журнал заказов"
		public static bool OpenCloseFormJournalComing;	// флаг открытия формы "Журнал приходных накладных"
		public static bool OpenCloseFormJournalExpense;	// флаг открытия формы "Журнал расходных накладных"
		public static bool OpenCloseFormJournalOperations; // флаг открытия формы "Журнал бухг. операций"
		//------------------------------------------------------------
	}
}
