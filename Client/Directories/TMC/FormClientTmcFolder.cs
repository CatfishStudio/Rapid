/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 15.02.2014
 * Время: 11:12
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
	/// Description of FormClientTmcFolder.
	/// </summary>
	public partial class FormClientTmcFolder : Form
	{
		public String ActionID;
		private String FolderName;
		public FormClientTmc Rapid_ClientTmc;
		private ClassMySQL_Full _tmcMySQL = new ClassMySQL_Full();
		private DataSet _tmcDataSet = new DataSet();
		
		public FormClientTmcFolder()
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
				ClassForms.Rapid_Client.MessageConsole("ТМЦ: Создание новой папки.", false);
			}
			if(this.Text == "Изменить папку."){
				//Выгрузка выбранных данных из базы данных
				_tmcDataSet.Clear();
				_tmcDataSet.DataSetName = "tmc";
				_tmcMySQL.SelectSqlCommand = "SELECT * FROM tmc WHERE (id_tmc = " + ActionID + ")";
				if(_tmcMySQL.ExecuteFill(_tmcDataSet, "tmc")){
					DataTable table = _tmcDataSet.Tables["tmc"];
					FolderName = table.Rows[0]["tmc_name"].ToString();
					textBox1.Text = FolderName;
					ClassForms.Rapid_Client.MessageConsole("ТМЦ: папка №" + ActionID + " успешно открыта для редактирования.", false);
				} else ClassForms.Rapid_Client.MessageConsole("ТМЦ: Ошибка выполнения запроса к таблице 'ТМЦ' обращение к записи с идентификатором " + ActionID + " тип записи 'Папка'.", true);
			}
		}
		
		void FormClientTmcFolderLoad(object sender, EventArgs e)
		{
			WindowLoad(); // Загрузка окна
		}
		
		/* Закрываем окно */
		void FormClientTmcFolderClosed(object sender, EventArgs e)
		{
			ClassForms.Rapid_Client.MessageConsole("ТМЦ: закрыто окно обработки папок.", false);
		}
		
		/* СОХРАНЕНИЕ: сохранение данных в таблицу */
		void SaveData() // созранение данных
		{
			ClassMySQL_Short SQlCommand = new ClassMySQL_Short();
			
			if(this.Text == "Создать папку."){
				SQlCommand.SqlCommand = "INSERT INTO tmc (tmc_name, tmc_type) VALUE ('" + textBox1.Text + "', 1)";
				if(SQlCommand.ExecuteNonQuery()){
					// ИСТОРИЯ: Запись в журнал истории обновлений
					ClassServer.SaveUpdateInBase(4, DateTime.Now.ToString(), "", "Создание новой папки.", "");
					ClassForms.Rapid_Client.MessageConsole("ТМЦ: создание новой папки.", false);
					Close();
				} else ClassForms.Rapid_Client.MessageConsole("ТМЦ: Ошибка выполнения запроса к таблице 'ТМЦ' при создании новой папки.", true);
			}
			
			if(this.Text == "Изменить папку."){
				SQlCommand.SqlCommand = "UPDATE tmc SET tmc_name = '" + textBox1.Text + "' WHERE (id_tmc = " + ActionID + ")";
				if(SQlCommand.ExecuteNonQuery()){
					// ОБНОВИТЬ ВЛОЖЕННЫЕ ЭЛЕМЕНТЫ В ДАННОЙ ПАПКЕ
					ClassMySQL_Short SQLCommandAllUpdate = new ClassMySQL_Short();
					SQLCommandAllUpdate.SqlCommand = "UPDATE tmc SET tmc_folder = '" + textBox1.Text + "' WHERE (tmc_folder = '" + FolderName + "')";
					if(SQLCommandAllUpdate.ExecuteNonQuery()){
						ClassForms.Rapid_Client.MessageConsole("ТМЦ: записи папки успешно перенесены.", false);	
					}else{
						ClassForms.Rapid_Client.MessageConsole("ТМЦ: Ошибка выполнения переноса элементов в изменённую папки.", true);
						ClassMySQL_Short SQLCommandBack = new ClassMySQL_Short();
						SQLCommandBack.SqlCommand = "UPDATE tmc SET tmc_name = '" + FolderName + "' WHERE (id_tmc = " + ActionID + ")";
						if(!SQLCommandBack.ExecuteNonQuery()) ClassForms.Rapid_Client.MessageConsole("Фирмы: КРИТИЧНАЯ ОШИБКА: Папка восстановлению не подлежит.", true);
					}
					// ОБНОВЛЕНИЕ ЗАВЕРШЕНО ---------------------
					// ИСТОРИЯ: Запись в журнал истории обновлений
					ClassServer.SaveUpdateInBase(4, DateTime.Now.ToString(), "", "Изменение имени папки", "");
					ClassForms.Rapid_Client.MessageConsole("ТМЦ: папка №" + ActionID + " успешно изменена.", false);
					Close();
				} else ClassForms.Rapid_Client.MessageConsole("ТМЦ: Ошибка выполнения изменения имени папки." + ActionID, true);
			}
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			SaveData(); // созранение данных			
		}
	}
}
