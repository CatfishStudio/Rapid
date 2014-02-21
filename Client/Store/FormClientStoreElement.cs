/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 18.02.2014
 * Время: 10:28
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
	/// Description of FormClientStoreElement.
	/// </summary>
	public partial class FormClientStoreElement : Form
	{
		/* Глобальные переменные */
		public String ActionID;
		public FormClientStore Rapid_ClientStore;
		private ClassMySQL_Full _storeMySQL = new ClassMySQL_Full();
		private DataSet _storeDataSet = new DataSet();
		
		public FormClientStoreElement()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		/* ЗАГРУЗКА: Загрузка окна */
		void WindowLoad() // Загрузка окна
		{
			// При создании новой записи
			if(this.Text == "Новая запись."){
				// Загружаем информацию из констант
				ClassForms.Rapid_Client.MessageConsole("Склады: Создание новой записи.", false);
			}
			// При изменении записи
			if(this.Text == "Изменить запись."){
				_storeDataSet.Clear();
				_storeDataSet.DataSetName = "store";
				_storeMySQL.SelectSqlCommand = "SELECT * FROM store WHERE (id_store = " + ActionID + ")";
				if(_storeMySQL.ExecuteFill(_storeDataSet, "store")){
					DataTable table = _storeDataSet.Tables["store"];
					textBox1.Text = table.Rows[0]["store_name"].ToString();
					textBox2.Text = table.Rows[0]["store_additionally"].ToString();
					ClassForms.Rapid_Client.MessageConsole("Склады: запись №" + ActionID + " успешно открыта для редактирования.", false);
				}else ClassForms.Rapid_Client.MessageConsole("Склады: Ошибка выполнения запроса к таблице 'Склады' обращение к записи с идентификатором " + ActionID + " тип записи 'Запись'.", true);
			}
		}
		void FormClientStoreElementLoad(object sender, EventArgs e)
		{
			WindowLoad(); // Загрузка окна			
		}
		/*----------------------------------------------------------------*/
		
		/* Закрываем окно */
		void Button2Click(object sender, EventArgs e)
		{
			Close();
		}
		void FormClientStoreElementClosed(object sender, EventArgs e)
		{
			ClassForms.Rapid_Client.MessageConsole("Склады: закрыто окно обработки записи.", false);
		}
		/*----------------------------------------------------------------*/
		
		/* СОХРАНЕНИЕ: сохранение данных в таблицу */
		void SaveData() // сохранение данных
		{
			ClassMySQL_Short SQlCommand = new ClassMySQL_Short();
			
			// При сохранении новой записи
			if(this.Text == "Новая запись."){
				SQlCommand.SqlCommand = "INSERT INTO store (store_name, store_additionally) VALUE ('" + textBox1.Text + "', '" + textBox2.Text + "')";
				if(SQlCommand.ExecuteNonQuery()){
					// ИСТОРИЯ: Запись в журнал истории обновлений
					ClassServer.SaveUpdateInBase(5, DateTime.Now.ToString(), "", "Создание новой записи.", "");
					ClassForms.Rapid_Client.MessageConsole("Склады: успешное создание новой записи.", false);
					Close();
				} else ClassForms.Rapid_Client.MessageConsole("Склады: Ошибка выполнения запроса к таблице 'Склады' при создании новой записи.", true);
			}
			// При сохранении измененной записи
			if(this.Text == "Изменить запись."){
				if(ClassConfig.Rapid_Client_UserRight == "admin"){
					SQlCommand.SqlCommand = "UPDATE store SET store_name = '" + textBox1.Text + "', store_additionally = '" + textBox2.Text + "' WHERE (id_store = " + ActionID + ") ";
					if(SQlCommand.ExecuteNonQuery()){
						// ИСТОРИЯ: Запись в журнал истории обновлений
						ClassServer.SaveUpdateInBase(5, DateTime.Now.ToString(), "", "Изменение записи.", "");
						ClassForms.Rapid_Client.MessageConsole("Склады: успешное изменение записи.", false);
						Close();
					} else ClassForms.Rapid_Client.MessageConsole("Склады: Ошибка выполнения запроса к таблице 'Склады' при изменении записи.", true);
				}else{
					MessageBox.Show("Извините но вы '" + ClassConfig.Rapid_Client_UserName + "' не обладаете достаточными правами для ввода изменений.","Сообщение");
					ClassForms.Rapid_Client.MessageConsole("Склады: у вас недостаточно прав для ввода изменений.", false);
				}
			}
		}
		void Button1Click(object sender, EventArgs e)
		{
			SaveData(); // созранение данных			
		}
		/*----------------------------------------------------------------*/
		
		
	}
}
