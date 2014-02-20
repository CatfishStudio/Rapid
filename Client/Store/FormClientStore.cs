/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 18.02.2014
 * Время: 10:27
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Rapid
{
	/// <summary>
	/// Description of FormClientStore.
	/// </summary>
	public partial class FormClientStore : Form
	{
		/* Глобальные переменные */
		private ClassMySQL_Full _storeMySQL = new ClassMySQL_Full();
		private DataSet _storeElementDataSet = new DataSet(); // элементы
		private bool _folderExplore = true; // флаг отображения элементов в папках
		private int selectTableLine = 0;	// выбранная строка в таблице
		public TextBox TextBoxReturnValue;	// РОДИТЕЛЬ: объект принимаемый значение
		
		public FormClientStore()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		/* ОТКРЫТИЕ ФОРМЫ --------------------------------------------------- */
		void FormClientStoreLoad(object sender, EventArgs e)
		{
			ClassForms.OpenCloseFormStore = true; // форма открыта
			ClassForms.Rapid_Client.MessageConsole("Склады: открыты.", false);
			TableUpdate(); // Загрузка данных из базы данных
		}
		
	}
}
