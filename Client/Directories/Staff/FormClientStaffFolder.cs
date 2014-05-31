/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 24.02.2014
 * Время: 9:50
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
	/// Description of FormClientStaffFolder.
	/// </summary>
	public partial class FormClientStaffFolder : Form
	{
		public String ActionID;
		private String FolderName;
		public FormClientStaff Rapid_ClientStaff;
		private ClassMySQL_Full _staffMySQL = new ClassMySQL_Full();
		private DataSet _staffDataSet = new DataSet();
		
		public FormClientStaffFolder()
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
				ClassForms.Rapid_Client.MessageConsole("Сотрудники: Создание новой папки.", false);
			}
			if(this.Text == "Изменить папку."){
				//Выгрузка выбранных данных из базы данных
				_staffDataSet.Clear();
				_staffDataSet.DataSetName = "staff";
				_staffMySQL.SelectSqlCommand = "SELECT * FROM staff WHERE (id_staff = " + ActionID + ")";
				if(_staffMySQL.ExecuteFill(_staffDataSet, "staff")){
					DataTable table = _staffDataSet.Tables["staff"];
					FolderName = table.Rows[0]["staff_name"].ToString();
					textBox1.Text = FolderName;
					ClassForms.Rapid_Client.MessageConsole("Сотрудники: папка №" + ActionID + " успешно открыта для редактирования.", false);
				} else ClassForms.Rapid_Client.MessageConsole("Сотрудники: Ошибка выполнения запроса к таблице 'Сотрудники' обращение к записи с идентификатором " + ActionID + " тип записи 'Папка'.", true);
			}
		}
		
		void FormClientStaffFolderLoad(object sender, EventArgs e)
		{
			WindowLoad(); // Загрузка окна			
		}
		
		/* Закрываем окно */
		void FormClientStaffFolderClosed(object sender, EventArgs e)
		{
			ClassForms.Rapid_Client.MessageConsole("Сотрудники: закрыто окно обработки папок.", false);
		}
		
		/* СОХРАНЕНИЕ: сохранение данных в таблицу */
		void SaveData() // созранение данных
		{
			ClassMySQL_Short SQlCommand = new ClassMySQL_Short();
			
			if(this.Text == "Создать папку."){
				SQlCommand.SqlCommand = "INSERT INTO staff (staff_name, staff_type) VALUE ('" + textBox1.Text + "', 1)";
				if(SQlCommand.ExecuteNonQuery()){
					// ИСТОРИЯ: Запись в журнал истории обновлений
					ClassServer.SaveUpdateInBase(8, DateTime.Now.ToString(), "", "Создание новой папки.", "");
					ClassForms.Rapid_Client.MessageConsole("Сотрудники: создание новой папки.", false);
					Close();
				} else ClassForms.Rapid_Client.MessageConsole("Сотрудники: Ошибка выполнения запроса к таблице 'Сотрудники' при создании новой папки.", true);
			}
			
			if(this.Text == "Изменить папку."){
				SQlCommand.SqlCommand = "UPDATE staff SET staff_name = '" + textBox1.Text + "' WHERE (id_staff = " + ActionID + ")";
				if(SQlCommand.ExecuteNonQuery()){
					// ОБНОВИТЬ ВЛОЖЕННЫЕ ЭЛЕМЕНТЫ В ДАННОЙ ПАПКЕ
					ClassMySQL_Short SQLCommandAllUpdate = new ClassMySQL_Short();
					SQLCommandAllUpdate.SqlCommand = "UPDATE staff SET staff_folder = '" + textBox1.Text + "' WHERE (staff_folder = '" + FolderName + "')";
					if(SQLCommandAllUpdate.ExecuteNonQuery()){
						ClassForms.Rapid_Client.MessageConsole("Сотрудники: записи папки успешно перенесены.", false);	
					}else{
						ClassForms.Rapid_Client.MessageConsole("Сотрудники: Ошибка выполнения переноса элементов в изменённую папки.", true);
						ClassMySQL_Short SQLCommandBack = new ClassMySQL_Short();
						SQLCommandBack.SqlCommand = "UPDATE staff SET staff_name = '" + FolderName + "' WHERE (id_staff = " + ActionID + ")";
						if(!SQLCommandBack.ExecuteNonQuery()) ClassForms.Rapid_Client.MessageConsole("Сотрудники: КРИТИЧНАЯ ОШИБКА: Папка восстановлению не подлежит.", true);
					}
					// ОБНОВЛЕНИЕ ЗАВЕРШЕНО ---------------------
					// ИСТОРИЯ: Запись в журнал истории обновлений
					ClassServer.SaveUpdateInBase(8, DateTime.Now.ToString(), "", "Изменение имени папки", "");
					ClassForms.Rapid_Client.MessageConsole("Сотрудники: папка №" + ActionID + " успешно изменена.", false);
					Close();
				} else ClassForms.Rapid_Client.MessageConsole("Сотрудники: Ошибка выполнения изменения имени папки." + ActionID, true);
			}
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			if(textBox1.Text != "") SaveData(); // созранение данных	
			else MessageBox.Show("Вы не ввели значение наименование!","Сообщение",MessageBoxButtons.OK);			
		}
	}
}
