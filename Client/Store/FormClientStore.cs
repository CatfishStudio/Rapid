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
		
		/* ТАБЛИЦА: Загружаем данные из базы данных в таблицу ----------------*/
		public void TableUpdate()
		{
			//Загрузка данных в таблицу
			try{
				listView1.Items.Clear();
				
				// ОТБОР: "Элементов"
				_storeElementDataSet.Clear();
				_storeElementDataSet.DataSetName = "store";
				_storeMySQL.SelectSqlCommand = "SELECT * FROM store ORDER BY store_name ASC";
				if(_storeMySQL.ExecuteFill(_storeElementDataSet, "store") == false){
					ClassForms.Rapid_Client.MessageConsole("Склады: Ошибка выполнения запроса к таблице 'Склады' при отборе элементов.", true);
					return;
				}
				DataTable _tableElements = _storeElementDataSet.Tables["store"];
			
				// ОТОБРАЖЕНИЕ "Элементов"
				foreach(DataRow rowElement in _tableElements.Rows)
        		{
					ListViewItem ListViewItem_add = new ListViewItem();
					ListViewItem_add.SubItems.Add(rowElement["store_name"].ToString());
					if(rowElement["store_delete"].ToString() == "0") //отметка удаления папки
						ListViewItem_add.StateImageIndex = 2; // папка не удалена
					else ListViewItem_add.StateImageIndex = 3; // папка удалена
					ListViewItem_add.SubItems.Add("");
					ListViewItem_add.SubItems.Add(rowElement["id_store"].ToString());
					listView1.Items.Add(ListViewItem_add);
				}
				
				// ВЫБОР: выдиляем ранее выбранный элемент.
				//listView1.SelectedIndices.IndexOf(selectTableLine);
			}catch{
				ClassForms.Rapid_Client.MessageConsole("Склады: Ошибка вывода информации выбранной из таблицы 'Склады'.", true);
			}
		}
		
	}
}
