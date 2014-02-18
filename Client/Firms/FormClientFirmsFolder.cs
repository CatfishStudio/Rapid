/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 02.02.2014
 * Время: 15:53
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Rapid.Client.Firms
{
	/// <summary>
	/// Description of FormClientFirmsFolder.
	/// </summary>
	public partial class FormClientFirmsFolder : Form
	{
		public String ActionID;
		private String FolderName;
		public FormClientFirms Rapid_ClientFirms;
		private ClassMySQL_Full _firmsMySQL = new ClassMySQL_Full();
		private DataSet _firmsDataSet = new DataSet();
				
		public FormClientFirmsFolder()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		/* Закрываем окно */
		void Button2Click(object sender, EventArgs e)
		{
			Close();
		}
		
		/* ЗАГРУЗКА: Загрузка окна */
		void WindowLoad() // Загрузка окна
		{
			if(this.Text == "Создать папку."){
				ClassForms.Rapid_Client.MessageConsole("Фирмы: Создание новой папки.", false);
			}
			if(this.Text == "Изменить папку."){
				//Выгрузка выбранных данных из базы данных
				_firmsDataSet.Clear();
				_firmsDataSet.DataSetName = "firms";
				_firmsMySQL.SelectSqlCommand = "SELECT * FROM firms WHERE (id_firm = " + ActionID + ")";
				if(_firmsMySQL.ExecuteFill(_firmsDataSet, "firms")){
					DataTable table = _firmsDataSet.Tables["firms"];
					FolderName = table.Rows[0]["firm_name"].ToString();
					textBox1.Text = FolderName;
					ClassForms.Rapid_Client.MessageConsole("Фирмы: папка №" + ActionID + " успешно открыта для редактирования.", false);
				} else ClassForms.Rapid_Client.MessageConsole("Фирмы: Ошибка выполнения запроса к таблице 'Фирмы' обращение к записи с идентификатором " + ActionID + " тип записи 'Папка'.", true);
			
			}
		}
		void FormClientFirmsFolderLoad(object sender, EventArgs e)
		{
			WindowLoad(); // Загрузка окна
		}
		
		/* Закрываем окно */
		void FormClientFirmsFolderClosed(object sender, EventArgs e)
		{
			ClassForms.Rapid_Client.MessageConsole("Фирмы: закрыто окно обработки папок.", false);
		}
		
		/* СОХРАНЕНИЕ: сохранение данных в таблицу */
		void SaveData() // созранение данных
		{
			ClassMySQL_Short SQlCommand = new ClassMySQL_Short();
			
			if(this.Text == "Создать папку."){
				SQlCommand.SqlCommand = "INSERT INTO firms (firm_name, firm_details, firm_address_phone, firm_trade_representative, firm_additionally, firm_type, firm_folder, firm_delete) VALUE ('" + textBox1.Text + "', '', '', '', '', 1, '', 0)";
				if(SQlCommand.ExecuteNonQuery()){
					// ИСТОРИЯ: Запись в журнал истории обновлений
					ClassServer.SaveUpdateInBase(3, DateTime.Now.ToString(), "", "Создание новой папки.", "");
					ClassForms.Rapid_Client.MessageConsole("Фирмы: создание новой папки.", false);
					Close();
				} else ClassForms.Rapid_Client.MessageConsole("Фирмы: Ошибка выполнения запроса к таблице 'Фирмы' при создании новой папки.", true);
			}
			
			if(this.Text == "Изменить папку."){
				SQlCommand.SqlCommand = "UPDATE firms SET firm_name = '" + textBox1.Text + "' WHERE (id_firm = " + ActionID + ")";
				if(SQlCommand.ExecuteNonQuery()){
					// ОБНОВИТЬ ВЛОЖЕННЫЕ ЭЛЕМЕНТЫ В ДАННОЙ ПАПКЕ
					ClassMySQL_Short SQLCommandAllUpdate = new ClassMySQL_Short();
					SQLCommandAllUpdate.SqlCommand = "UPDATE firms SET firm_folder = '" + textBox1.Text + "' WHERE (firm_folder = '" + FolderName + "')";
					if(SQLCommandAllUpdate.ExecuteNonQuery()){
						ClassForms.Rapid_Client.MessageConsole("Фирма: записи папки успешно перенесены.", false);	
					}else{
						ClassForms.Rapid_Client.MessageConsole("Фирмы: Ошибка выполнения переноса элементов в изменённую папки.", true);
						ClassMySQL_Short SQLCommandBack = new ClassMySQL_Short();
						SQLCommandBack.SqlCommand = "UPDATE firms SET firm_name = '" + FolderName + "' WHERE (id_firm = " + ActionID + ")";
						if(!SQLCommandBack.ExecuteNonQuery()) ClassForms.Rapid_Client.MessageConsole("Фирмы: КРИТИЧНАЯ ОШИБКА: Папка восстановлению не подлежит.", true);
					}
					// ОБНОВЛЕНИЕ ЗАВЕРШЕНО ---------------------
					// ИСТОРИЯ: Запись в журнал истории обновлений
					ClassServer.SaveUpdateInBase(3, DateTime.Now.ToString(), "", "Изменение имени папки", "");
					ClassForms.Rapid_Client.MessageConsole("Фирма: папка №" + ActionID + " успешно изменена.", false);
					Close();
				} else ClassForms.Rapid_Client.MessageConsole("Фирмы: Ошибка выполнения изменения имени папки." + ActionID, true);
			}
		}
		void Button1Click(object sender, EventArgs e)
		{
			SaveData(); // созранение данных
		}
	}
}
