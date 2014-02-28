﻿/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 24.02.2014
 * Время: 9:49
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
	/// Description of FormClientStaff.
	/// </summary>
	public partial class FormClientStaff : Form
	{
		/* Глобальные переменные */
		private ClassMySQL_Full _staffMySQL = new ClassMySQL_Full();
		private DataSet _staffFolderDataSet = new DataSet();  // папки
		private DataSet _staffElementDataSet = new DataSet(); // элементы
		private bool _folderExplore = true; // флаг отображения элементов в папках
		public String openFolder = ""; 		// открытая папка
		private int selectTableLine = 0;	// выбранная строка в таблице
		public TextBox TextBoxReturnValue;	// РОДИТЕЛЬ: объект принимаемый значение
		
		public FormClientStaff()
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
		void FormClientStaffLoad(object sender, EventArgs e)
		{
			ClassForms.OpenCloseFormStaff = true; // форма открыта
			ClassForms.Rapid_Client.MessageConsole("Сотрудники: открыты.", false);
			TableUpdate(""); // Загрузка данных из базы данных
		}
		
		/* ТАБЛИЦА: Загружаем данные из базы данных в таблицу ----------------*/
		public void TableUpdate(String actionFolder)
		{
			//Загрузка данных в таблицу
			try{
				listView1.Items.Clear();
				
				// ОТБОР: "Папок"
				_staffFolderDataSet.Clear();
				_staffFolderDataSet.DataSetName = "staff";
				if(actionFolder == "") _staffMySQL.SelectSqlCommand = "SELECT * FROM staff WHERE (staff_type = 1) ORDER BY staff_name ASC";
					else _staffMySQL.SelectSqlCommand = "SELECT * FROM staff WHERE (staff_type = 1 AND staff_name = '" + actionFolder + "') ORDER BY staff_name ASC";
				if(_staffMySQL.ExecuteFill(_staffFolderDataSet, "staff") == false){
					ClassForms.Rapid_Client.MessageConsole("Сотрудники: Ошибка выполнения запроса к таблице 'Сотрудники' при отборе папок.", true);
					return;
				}
				DataTable _tableFolders = _staffFolderDataSet.Tables["staff"];
				
				// ОТБОР: "Элементов"
				_staffElementDataSet.Clear();
				_staffElementDataSet.DataSetName = "staff";
				if(actionFolder == "" && _folderExplore) {
					_staffMySQL.SelectSqlCommand = "SELECT * FROM staff WHERE (staff_type = 0 AND staff_folder = '') ORDER BY staff_name ASC";
				}else{
					if(_folderExplore == false) _staffMySQL.SelectSqlCommand = "SELECT * FROM staff WHERE (staff_type = 0) ORDER BY staff_name ASC";
					else _staffMySQL.SelectSqlCommand = "SELECT * FROM staff WHERE (staff_type = 0 AND staff_folder = '" + actionFolder + "') ORDER BY staff_name ASC";
				}
				if(_staffMySQL.ExecuteFill(_staffElementDataSet, "staff") == false){
					ClassForms.Rapid_Client.MessageConsole("Сотрудники: Ошибка выполнения запроса к таблице 'Сотрудники' при отборе элементов.", true);
					return;
				}
				DataTable _tableElements = _staffElementDataSet.Tables["staff"];
			
				// ОТОБРАЖЕНИЕ: "Папок"
				foreach(DataRow rowFolder in _tableFolders.Rows)
        		{
					ListViewItem ListViewItem_add = new ListViewItem();
					if(actionFolder == "") ListViewItem_add.SubItems.Add(rowFolder["staff_name"].ToString());
						else ListViewItem_add.SubItems.Add("..");
					if(rowFolder["staff_delete"].ToString() == "0") //отметка удаления папки
						ListViewItem_add.StateImageIndex = 0; // папка не удалена
					else ListViewItem_add.StateImageIndex = 1; // папка удалена
					ListViewItem_add.SubItems.Add("Папка");
					ListViewItem_add.SubItems.Add(rowFolder["id_staff"].ToString());
					listView1.Items.Add(ListViewItem_add);
				}
				// ОТОБРАЖЕНИЕ "Элементов"
				foreach(DataRow rowElement in _tableElements.Rows)
        		{
					ListViewItem ListViewItem_add = new ListViewItem();
					ListViewItem_add.SubItems.Add(rowElement["staff_name"].ToString());
					if(rowElement["staff_delete"].ToString() == "0") //отметка удаления папки
						ListViewItem_add.StateImageIndex = 2; // папка не удалена
					else ListViewItem_add.StateImageIndex = 3; // папка удалена
					ListViewItem_add.SubItems.Add("");
					ListViewItem_add.SubItems.Add(rowElement["id_staff"].ToString());
					listView1.Items.Add(ListViewItem_add);
				}
				
				// ВЫБОР: выдиляем ранее выбранный элемент.
				listView1.SelectedIndices.IndexOf(selectTableLine);
			}catch{
				ClassForms.Rapid_Client.MessageConsole("Сотрудники: Ошибка вывода информации выбранной из таблицы 'Сотрудники'.", true);
			}
		}
		
		/* ЗАКРЫТИЕ ОКНА ---------------------------------------------------- */
		void FormClientStaffClosed(object sender, EventArgs e)
		{
			ClassForms.Rapid_Client.MessageConsole("Сотрудники: закрыты.", false);
			ClassForms.OpenCloseFormStaff = false; // форма закрыта
		}
				
		void Button8Click(object sender, EventArgs e)
		{
			Close();
		}
		
		/* ОТОБРАЖЕНИЕ: иерархическое отображение папок и элементов -----------*/
		void Hierarchy() // иерархическое отображение
		{
			if(_folderExplore){
				_folderExplore = false;
				ClassForms.Rapid_Client.MessageConsole("Сотрудники: группирование отключено.", false);
				TableUpdate(""); // отображается всё содержимое
			}else{
				_folderExplore = true;
				ClassForms.Rapid_Client.MessageConsole("Сотрудники: группирование включено.", false);
				TableUpdate(openFolder); //возвращаемся в последнюю активную папку.
			}
		}
				
		void Button9Click(object sender, EventArgs e)
		{
			Hierarchy();  // иерархическое отображение			
		}
		
		/* ОТКРЫТИЕ ПАПКИ С ЭЛЕМЕНТАМИ ---------------------------------------*/
		void ShowOpenCloseFolder() // показать открытую папку
		{
			if(listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text.ToString() == "Папка" && _folderExplore){
				if(listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString() != ".."){
					openFolder = listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString();
					TableUpdate(openFolder);
				}else {
					openFolder = "";
					TableUpdate(openFolder);
				}
			}	
		}
		
		void ListView1DoubleClick(object sender, EventArgs e)
		{
			ShowOpenCloseFolder(); // показать открытую папку
		}
		/*--------------------------------------------------------------------*/
		
		/* ВЫБОР: при выдоре строки в таблице */
		void ListView1SelectedIndexChanged(object sender, EventArgs e)
		{
			// выбранная строка таблицы
			if(listView1.SelectedItems.Count > 0)
				selectTableLine = listView1.SelectedItems[0].Index; // индекс выбраной строки
			// удалить или восстановить
			if(listView1.SelectedIndices.Count > 0){ // проверка выбранного элемента
				// Папка
				if(listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text.ToString() == "Папка" && listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString() != ".."){
					if(listView1.SelectedItems[0].StateImageIndex == 1)
						удалитьПапкуToolStripMenuItem.Text = "Восстановить папку.";
					else удалитьПапкуToolStripMenuItem.Text = "Удалить папку.";
				}
				// Элемент
				if(listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text.ToString() != "Папка" && listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString() != ".."){
					if(listView1.SelectedItems[0].StateImageIndex == 3)
						удалитьЗаписьToolStripMenuItem.Text = "Восстановить запись.";
					else удалитьЗаписьToolStripMenuItem.Text = "Удалить запись.";
				}
			}
		}
		
		/* ПОИСК: Выполнение поиска по всем данным из таблицы ----------------*/
		void Search() // выполнить поиск в таблице
		{
			listView1.Items.Clear();
			
			DataSet _findDataSet = new DataSet();
			_findDataSet.Clear();
			_findDataSet.DataSetName = "staff";
			_staffMySQL.SelectSqlCommand = "SELECT * FROM staff WHERE (staff_name LIKE '%" + textBox1.Text + "%') ORDER BY staff_name ASC";
			
			if(_staffMySQL.ExecuteFill(_findDataSet, "staff") == false){
				ClassForms.Rapid_Client.MessageConsole("Сотрудники: Ошибка выполнения запроса к таблице 'Сотрудники' при поиске указанного значения.", true);
				return;
			}
			DataTable _table = _findDataSet.Tables["staff"];
			foreach(DataRow row in _table.Rows)
        	{
				ListViewItem ListViewItem_add = new ListViewItem();
				ListViewItem_add.SubItems.Add(row["staff_name"].ToString());
				
				if(row["staff_delete"].ToString() == "0"){ //отметка удаления
					if(row["staff_type"].ToString() == "0"){ //элемент
						ListViewItem_add.StateImageIndex = 2; // элемент не удалён
					}else{ //папка
						ListViewItem_add.StateImageIndex = 0; // папка не удалена
					}
				} else {
					if(row["staff_type"].ToString() == "0"){ //элемент
						ListViewItem_add.StateImageIndex = 3; // элемент удалён
					}else{ //папка
						ListViewItem_add.StateImageIndex = 1; // папка удалена
					}
				}
				
				if(row["staff_type"].ToString() == "1") ListViewItem_add.SubItems.Add("Папка");
					else ListViewItem_add.SubItems.Add("");
				ListViewItem_add.SubItems.Add(row["id_staff"].ToString());
				listView1.Items.Add(ListViewItem_add);
			}
			ClassForms.Rapid_Client.MessageConsole("Сотрудники: выполнен поиск значения '" + textBox1.Text + "'.", false);
		}
		
		void Button7Click(object sender, EventArgs e)
		{
			Search(); // поиск			
		}
		/*--------------------------------------------------------------------*/
		
		/* СОЗДАТЬ ПАПКУ -----------------------------------------------------*/
		void CreateFolder() // создать папку
		{
			if(openFolder == ""){
				FormClientStaffFolder Rapid_ClientFolderCreate = new FormClientStaffFolder();
				Rapid_ClientFolderCreate.MdiParent = ClassForms.Rapid_Client;
				Rapid_ClientFolderCreate.Text = "Создать папку.";
				Rapid_ClientFolderCreate.Show();
			}
		}
				
		void Button1Click(object sender, EventArgs e)
		{
			CreateFolder(); // Создать папку			
		}
		
		void СоздатьПапкуToolStripMenuItemClick(object sender, EventArgs e)
		{
			CreateFolder(); // Создать папку			
		}
		/*--------------------------------------------------------------------*/
		
		/* РЕДАКТИРОВАТЬ ПАПКУ -----------------------------------------------*/
		void EditFolder() // изменить папку
		{
			if(ClassConfig.Rapid_Client_UserRight == "admin"){
				if(listView1.SelectedIndices.Count > 0){ // проверка выбранного элемента
					if(listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text.ToString() == "Папка" && listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString() != ".." && listView1.SelectedItems[0].StateImageIndex == 0){
						FormClientStaffFolder Rapid_ClientFolderEdit = new FormClientStaffFolder();
						Rapid_ClientFolderEdit.MdiParent = ClassForms.Rapid_Client;
						Rapid_ClientFolderEdit.ActionID = listView1.Items[listView1.SelectedIndices[0]].SubItems[3].Text.ToString();
						Rapid_ClientFolderEdit.textBox1.Text = listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString();
						Rapid_ClientFolderEdit.Text = "Изменить папку.";
						Rapid_ClientFolderEdit.Show();
					}
				}
			}else{
				MessageBox.Show("Извините но вы '" + ClassConfig.Rapid_Client_UserName + "' не обладаете достаточными правами для ввода изменений.","Сообщение");
				ClassForms.Rapid_Client.MessageConsole("Сотрудники: у вас недостаточно прав для ввода изменений.", false);
			}
		}
				
		void Button2Click(object sender, EventArgs e)
		{
			EditFolder(); // Изменить папку			
		}
		
		void ИзменитьПапкуToolStripMenuItemClick(object sender, EventArgs e)
		{
			EditFolder(); // Изменить папку			
		}
		/*--------------------------------------------------------------------*/
		
		/* УДАЛИТЬ ПАПКУ -----------------------------------------------------*/
		void DeleteFolder() // удалить папку
		{
			if(ClassConfig.Rapid_Client_UserRight == "admin"){
				if(listView1.SelectedIndices.Count > 0){ // проверка выбранного элемента
					if(listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text.ToString() == "Папка" && listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString() != ".."){
						if(listView1.SelectedItems[0].StateImageIndex == 0){
							// Установка отметки удаления
							String _folder = listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString();
							if(MessageBox.Show("Пометить папку '" + _folder + "' и все её элементы на удаление?", "Вопрос:", MessageBoxButtons.YesNo) == DialogResult.Yes){
								ClassMySQL_Short SQLCommand = new ClassMySQL_Short();
								SQLCommand.SqlCommand = "UPDATE staff SET staff_delete = 1 WHERE (staff_name = '" + _folder + "' OR staff_folder = '" + _folder + "')";
								if(SQLCommand.ExecuteNonQuery()){
									ClassForms.Rapid_Client.MessageConsole("Сотрудники: Успешное удаление папки '" + _folder + "' и её содержимое.", false);
									// ИСТОРИЯ: Запись в журнал истории обновлений
									ClassServer.SaveUpdateInBase(8, DateTime.Now.ToString(), "", "Удаление папки", "");
								}else{
									ClassForms.Rapid_Client.MessageConsole("Сотрудники: Ошибка удаления папки '" + _folder + "'.", true);
								}
							}
						}else{
							// Восстановление папки и всех элементов
							String _folder = listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString();
							if(MessageBox.Show("Восстановить папку '" + _folder + "' и все её элементы?", "Вопрос:", MessageBoxButtons.YesNo) == DialogResult.Yes){
								ClassMySQL_Short SQLCommand = new ClassMySQL_Short();
								SQLCommand.SqlCommand = "UPDATE staff SET staff_delete = 0 WHERE (staff_name = '" + _folder + "' OR staff_folder = '" + _folder + "')";
								if(SQLCommand.ExecuteNonQuery()){
									ClassForms.Rapid_Client.MessageConsole("Сотрудники: Успешное восстановление папки '" + _folder + "' и её содержимое.", false);
									// ИСТОРИЯ: Запись в журнал истории обновлений
									ClassServer.SaveUpdateInBase(8, DateTime.Now.ToString(), "", "Восстановление папки", "");
								}else{
									ClassForms.Rapid_Client.MessageConsole("Сотрудники: Ошибка восстановление папки '" + _folder + "'.", true);
								}
							}
						}
						
					}
				}
			}else{
				MessageBox.Show("Извините но вы '" + ClassConfig.Rapid_Client_UserName + "' не обладаете достаточными правами для удаления.","Сообщение");
				ClassForms.Rapid_Client.MessageConsole("Сотрудники: у вас недостаточно прав для удаления.", false);
			}
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			DeleteFolder(); // Удаление папки			
		}
		
		void УдалитьПапкуToolStripMenuItemClick(object sender, EventArgs e)
		{
			DeleteFolder(); // Удаление папки			
		}
		/*--------------------------------------------------------------------*/
		
		/* НОВАЯ ЗАПИСЬ ------------------------------------------------------*/
		void CreateElement() // Создать запись
		{
			FormClientStaffElement Rapid_ClientElementCreate = new FormClientStaffElement();
			Rapid_ClientElementCreate.MdiParent = ClassForms.Rapid_Client;
			Rapid_ClientElementCreate.Text = "Новая запись.";
			Rapid_ClientElementCreate.comboBox1.Text = openFolder; // родительская папка
			Rapid_ClientElementCreate.Show();
		}
		
		void Button4Click(object sender, EventArgs e)
		{
			CreateElement(); // Создать запись			
		}
				
		void СоздатьЗаписьToolStripMenuItemClick(object sender, EventArgs e)
		{
			CreateElement(); // Создать запись			
		}
		/*--------------------------------------------------------------------*/
		
		/* РЕДАКТИРОВАТЬ ЗАПИСЬ ----------------------------------------------*/
		void EditElement() // Изменить запись
		{
			if(listView1.SelectedIndices.Count > 0){ // проверка выбранного элемента
				if(listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text.ToString() != "Папка" && listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString() != ".." && listView1.SelectedItems[0].StateImageIndex == 2){
					FormClientStaffElement Rapid_ClientElementEdit = new FormClientStaffElement();
					Rapid_ClientElementEdit.MdiParent = ClassForms.Rapid_Client;
					Rapid_ClientElementEdit.Text = "Изменить запись.";
					Rapid_ClientElementEdit.ActionID = listView1.Items[listView1.SelectedIndices[0]].SubItems[3].Text.ToString();
					Rapid_ClientElementEdit.Show();
				}
			}
		}
		
		void Button5Click(object sender, EventArgs e)
		{
			EditElement(); // Изменить запись			
		}
		
		void ИзменитьЗаписьToolStripMenuItemClick(object sender, EventArgs e)
		{
			EditElement(); // Изменить запись			
		}
		/*--------------------------------------------------------------------*/
		
		/* УДАЛИТЬ ЗАПИСЬ ----------------------------------------------------*/
		void DeleteElement() // Удалить запись
		{
			if(ClassConfig.Rapid_Client_UserRight == "admin"){
				if(listView1.SelectedIndices.Count > 0){ // проверка выбранного элемента
					if(listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text.ToString() != "Папка" && listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString() != ".."){
											
						if(listView1.SelectedItems[0].StateImageIndex == 2){ // не удалён
							// Установка отметки удаления
							if(MessageBox.Show("Пометить запись на удаление?", "Вопрос:", MessageBoxButtons.YesNo) == DialogResult.Yes){
								ClassMySQL_Short SQLCommand = new ClassMySQL_Short();
								SQLCommand.SqlCommand = "UPDATE staff SET staff_delete = 1 WHERE (id_staff = " + listView1.Items[listView1.SelectedIndices[0]].SubItems[3].Text.ToString() + ")";
								if(SQLCommand.ExecuteNonQuery()){
									// ИСТОРИЯ: Запись в журнал истории обновлений
									ClassServer.SaveUpdateInBase(8, DateTime.Now.ToString(), "", "Удаление записи.", "");
									ClassForms.Rapid_Client.MessageConsole("Сотрудники: успешное удаление записи.", false);
								} else ClassForms.Rapid_Client.MessageConsole("Сотрудники: Ошибка выполнения запроса к таблице 'Сотрудники' при удалении записи.", true);
							}
						}else{ // уже уданён
							// Восстановление записи
							if(MessageBox.Show("Восстановить запись?", "Вопрос:", MessageBoxButtons.YesNo) == DialogResult.Yes){
								ClassMySQL_Short SQLCommand = new ClassMySQL_Short();
								SQLCommand.SqlCommand = "UPDATE staff SET staff_delete = 0 WHERE (id_staff = " + listView1.Items[listView1.SelectedIndices[0]].SubItems[3].Text.ToString() + ")";
								if(SQLCommand.ExecuteNonQuery()){
									// ИСТОРИЯ: Запись в журнал истории обновлений
									ClassServer.SaveUpdateInBase(8, DateTime.Now.ToString(), "", "Восстановление записи.", "");
									ClassForms.Rapid_Client.MessageConsole("Сотрудники: успешное восстановление записи.", false);
								} else ClassForms.Rapid_Client.MessageConsole("Сотрудники: Ошибка выполнения запроса к таблице 'Сотрудники' при восстановлении записи.", true);
							}
						}
					}
				}
			}
		}
		
		void Button6Click(object sender, EventArgs e)
		{
			DeleteElement(); // Удалить запись			
		}
		
		void УдалитьЗаписьToolStripMenuItemClick(object sender, EventArgs e)
		{
			DeleteElement(); // Удалить запись			
		}
		/*--------------------------------------------------------------------*/
		
		/*  ВЫБРАТЬ ЗАПИСЬ ---------------------------------------------------*/
		public void ShowMenuReturnValue()
		{
			toolStripMenuItem2.Visible = true;
			выбратьЗаписьToolStripMenuItem.Visible = true;
		}
		
		public void ReturnValue()
		{
			if(listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text.ToString() != "Папка" && listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString() != ".."){
				TextBoxReturnValue.Text = listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString();
				this.Close();
			}
		}
		
		void ВыбратьЗаписьToolStripMenuItemClick(object sender, EventArgs e)
		{
			ReturnValue();			
		}
		/*--------------------------------------------------------------------*/
	}
}