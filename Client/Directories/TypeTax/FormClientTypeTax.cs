/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 22.02.2014
 * Время: 13:23
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
	/// Description of FormClientTypeTax.
	/// </summary>
	public partial class FormClientTypeTax : Form
	{
		/* Глобальные переменные */
		private ClassMySQL_Full _typeTaxMySQL = new ClassMySQL_Full();
		private DataSet _typeTaxElementDataSet = new DataSet(); // элементы
		private int selectTableLine = 0;	// выбранная строка в таблице
		public TextBox TextBoxReturnValue;	// РОДИТЕЛЬ: объект принимаемый значение
		
		public FormClientTypeTax()
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
		void FormClientTypeTaxLoad(object sender, EventArgs e)
		{
			ClassForms.OpenCloseFormTypeTax = true; // форма открыта
			ClassForms.Rapid_Client.MessageConsole("Вид налога: открыты.", false);
			TableUpdate(); // Загрузка данных из базы данных
		}
		
		/* ТАБЛИЦА: Загружаем данные из базы данных в таблицу ----------------*/
		public void TableUpdate()
		{
			//Загрузка данных в таблицу
			try{
				listView1.Items.Clear();
				
				// ОТБОР: "Элементов"
				_typeTaxElementDataSet.Clear();
				_typeTaxElementDataSet.DataSetName = "typetax";
				_typeTaxMySQL.SelectSqlCommand = "SELECT * FROM typeTax ORDER BY typeTax_name ASC";
				if(_typeTaxMySQL.ExecuteFill(_typeTaxElementDataSet, "typetax") == false){
					ClassForms.Rapid_Client.MessageConsole("Вид налога: Ошибка выполнения запроса к таблице 'Вид налога' при отборе элементов.", true);
					return;
				}
				DataTable _tableElements = _typeTaxElementDataSet.Tables["typetax"];
			
				// ОТОБРАЖЕНИЕ "Элементов"
				foreach(DataRow rowElement in _tableElements.Rows)
        		{
					ListViewItem ListViewItem_add = new ListViewItem();
					ListViewItem_add.SubItems.Add(rowElement["typeTax_name"].ToString());
					if(rowElement["typeTax_delete"].ToString() == "0") //отметка удаления папки
						ListViewItem_add.StateImageIndex = 2; // папка не удалена
					else ListViewItem_add.StateImageIndex = 3; // папка удалена
					ListViewItem_add.SubItems.Add("");
					ListViewItem_add.SubItems.Add(rowElement["id_typeTax"].ToString());
					listView1.Items.Add(ListViewItem_add);
				}
				
				// ВЫБОР: выдиляем ранее выбранный элемент.
				listView1.SelectedIndices.IndexOf(selectTableLine);
			}catch{
				ClassForms.Rapid_Client.MessageConsole("Вид налога: Ошибка вывода информации выбранной из таблицы 'Ед.изм.'.", true);
			}
		}
		
		/* ЗАКРЫТИЕ ОКНА ---------------------------------------------------- */
		void FormClientTypeTaxClosed(object sender, EventArgs e)
		{
			ClassForms.Rapid_Client.MessageConsole("Вид налога: закрыты.", false);
			ClassForms.OpenCloseFormTypeTax = false; // форма закрыта
		}
		
		
		void Button8Click(object sender, EventArgs e)
		{
			Close();
		}
		
		/* ВЫБОР: при выдоре строки в таблице */
		void ListView1SelectedIndexChanged(object sender, EventArgs e)
		{
			// выбранная строка таблицы
			if(listView1.SelectedItems.Count > 0)
				selectTableLine = listView1.SelectedItems[0].Index; // индекс выбраной строки
			// удалить или восстановить
			if(listView1.SelectedIndices.Count > 0){ // проверка выбранного элемента
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
			_findDataSet.DataSetName = "typetax";
			_typeTaxMySQL.SelectSqlCommand = "SELECT * FROM typetax WHERE (typeTax_name LIKE '%" + textBox1.Text + "%') ORDER BY typeTax_name ASC";
			
			if(_typeTaxMySQL.ExecuteFill(_findDataSet, "typetax") == false){
				ClassForms.Rapid_Client.MessageConsole("Вид налога: Ошибка выполнения запроса к таблице 'Вид налога' при поиске указанного значения.", true);
				return;
			}
			DataTable _table = _findDataSet.Tables["typetax"];
			foreach(DataRow row in _table.Rows)
        	{
				ListViewItem ListViewItem_add = new ListViewItem();
				ListViewItem_add.SubItems.Add(row["typeTax_name"].ToString());
				
				if(row["typeTax_delete"].ToString() == "0"){ //отметка удаления
						ListViewItem_add.StateImageIndex = 2; // элемент не удалён
				} else {
						ListViewItem_add.StateImageIndex = 3; // элемент удалён
				}
				
				ListViewItem_add.SubItems.Add("");
				ListViewItem_add.SubItems.Add(row["id_typeTax"].ToString());
				listView1.Items.Add(ListViewItem_add);
			}
			ClassForms.Rapid_Client.MessageConsole("Вид налога: выполнен поиск значения '" + textBox1.Text + "'.", false);
		}
		
		
		void Button7Click(object sender, EventArgs e)
		{
			Search(); // поиск			
		}
		/*--------------------------------------------------------------------*/
		
		/* НОВАЯ ЗАПИСЬ ------------------------------------------------------*/
		void CreateElement() // Создать запись
		{
			FormClientTypeTaxElement Rapid_ClientElementCreate = new FormClientTypeTaxElement();
			Rapid_ClientElementCreate.MdiParent = ClassForms.Rapid_Client;
			Rapid_ClientElementCreate.Text = "Новая запись.";
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
				if(listView1.SelectedItems[0].StateImageIndex == 2){
					FormClientTypeTaxElement Rapid_ClientElementEdit = new FormClientTypeTaxElement();
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
											
						if(listView1.SelectedItems[0].StateImageIndex == 2){ // не удалён
							// Установка отметки удаления
							if(MessageBox.Show("Пометить запись на удаление?", "Вопрос:", MessageBoxButtons.YesNo) == DialogResult.Yes){
								ClassMySQL_Short SQLCommand = new ClassMySQL_Short();
								SQLCommand.SqlCommand = "UPDATE typetax SET typeTax_delete = 1 WHERE (id_typeTax = " + listView1.Items[listView1.SelectedIndices[0]].SubItems[3].Text.ToString() + ")";
								if(SQLCommand.ExecuteNonQuery()){
									// ИСТОРИЯ: Запись в журнал истории обновлений
									ClassServer.SaveUpdateInBase(7, DateTime.Now.ToString(), "", "Удаление записи.", "");
									ClassForms.Rapid_Client.MessageConsole("Вид налога: успешное удаление записи.", false);
								} else ClassForms.Rapid_Client.MessageConsole("Вид налога: Ошибка выполнения запроса к таблице 'Вид налога' при удалении записи.", true);
							}
						}else{ // уже уданён
							// Восстановление записи
							if(MessageBox.Show("Восстановить запись?", "Вопрос:", MessageBoxButtons.YesNo) == DialogResult.Yes){
								ClassMySQL_Short SQLCommand = new ClassMySQL_Short();
								SQLCommand.SqlCommand = "UPDATE typetax SET typeTax_delete = 0 WHERE (id_typeTax = " + listView1.Items[listView1.SelectedIndices[0]].SubItems[3].Text.ToString() + ")";
								if(SQLCommand.ExecuteNonQuery()){
									// ИСТОРИЯ: Запись в журнал истории обновлений
									ClassServer.SaveUpdateInBase(7, DateTime.Now.ToString(), "", "Восстановление записи.", "");
									ClassForms.Rapid_Client.MessageConsole("Вид налога: успешное восстановление записи.", false);
								} else ClassForms.Rapid_Client.MessageConsole("Вид налога: Ошибка выполнения запроса к таблице 'Вид налога' при восстановлении записи.", true);
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
			button10.Visible = true;
		}
		
		public void ReturnValue()
		{
			TextBoxReturnValue.Text = listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString();
			this.Close();
		}
		
		void ВыбратьЗаписьToolStripMenuItemClick(object sender, EventArgs e)
		{
			ReturnValue();			
		}
		
		void Button10Click(object sender, EventArgs e)
		{
			ReturnValue();
		}
		/*--------------------------------------------------------------------*/
	}
}
