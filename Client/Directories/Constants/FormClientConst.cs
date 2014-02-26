/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 21.01.2014
 * Время: 14:19
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace Rapid
{
	/// <summary>
	/// Description of FormClientConst.
	/// </summary>
	public partial class FormClientConst : Form
	{
		private ClassMySQL_Full _constMySQL = new ClassMySQL_Full();
		private DataSet _constDataSet = new DataSet();
		
		public FormClientConst()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Button4Click(object sender, EventArgs e)
		{
			Close(); //закрыть окно констант
		}
		
		void FormClientConstLoad(object sender, EventArgs e)
		{
			//Открытие формы (загружаем данные из базы данных)
			ClassForms.OpenCloseFormConst = true; // форма открыта
			TableUpdate();
			ClassForms.Rapid_Client.MessageConsole("Константы: открыты.", false);
		}
		
		void FormClientConstClosed(object sender, EventArgs e)
		{
			ClassForms.Rapid_Client.MessageConsole("Константы: закрыты.", false);
			ClassForms.OpenCloseFormConst = false; // форма закрыта
		}
		
		/* Загружаем данные из базы данных в таблицу */
		public void TableUpdate()
		{
			//Загрузка данных в таблицу
			try{
				_constDataSet.Clear();
				_constDataSet.DataSetName = "constants";
				_constMySQL.SelectSqlCommand = "SELECT * FROM constants";
				if(_constMySQL.ExecuteFill(_constDataSet, "constants") == false){
					ClassForms.Rapid_Client.MessageConsole("Контанты: Ошибка выполнения запроса к таблице 'Константы'.", true);
					return;
				}
			
				DataTable table = _constDataSet.Tables["constants"];
				listView1.Items.Clear();
				foreach(DataRow row in table.Rows)
        		{
					ListViewItem ListViewItem_add = new ListViewItem();
					ListViewItem_add.SubItems.Add(row["const_name"].ToString());
					ListViewItem_add.SubItems.Add(row["const_value"].ToString());
					ListViewItem_add.SubItems.Add(row["id_const"].ToString());
					ListViewItem_add.StateImageIndex = 0;
					listView1.Items.Add(ListViewItem_add);
				}
				ClassForms.Rapid_Client.MessageConsole("Константы: успешное обновление.", false);
			}catch{
				ClassForms.Rapid_Client.MessageConsole("Константы: Ошибка вывода информации выбранной из таблицы 'Константы'.", true);
			}
		}
		
		/* Редактировать значение константы */
		void Button2Click(object sender, EventArgs e)
		{
			//Окно редактирования значения константы
			if(ClassConfig.Rapid_Client_UserRight == "admin"){
				if(listView1.SelectedIndices.Count > 0){ // проверка выбранного элемента
					FormClientConstEdit Rapid_ClientConstEdit = new FormClientConstEdit();
					Rapid_ClientConstEdit.MdiParent= ClassForms.Rapid_Client;
					Rapid_ClientConstEdit.ActionID = listView1.Items[listView1.SelectedIndices[0]].SubItems[3].Text.ToString();
					Rapid_ClientConstEdit.Rapid_ClientConst = this;
					Rapid_ClientConstEdit.Show();
				}
			}else{
				MessageBox.Show("Извините но вы '" + ClassConfig.Rapid_Client_UserName + "' не обладаете достаточными правами для ввода изменений.","Сообщение");
				ClassForms.Rapid_Client.MessageConsole("Константы: у вас недостаточно прав для ввода изменений.", false);
			}
		}
		
		/* Удалить значение константы */
		void Button3Click(object sender, EventArgs e)
		{
			if(ClassConfig.Rapid_Client_UserRight == "admin"){
				if(listView1.SelectedIndices.Count > 0){ // проверка выбранного элемента
					ClassMySQL_Short SQlCommand = new ClassMySQL_Short();
					SQlCommand.SqlCommand = "UPDATE constants SET const_value = '', const_additionally = '' WHERE (id_const = " + listView1.Items[listView1.SelectedIndices[0]].SubItems[3].Text.ToString() + ")";
					if(SQlCommand.ExecuteNonQuery()){
						// ИСТОРИЯ: Запись в журнал истории обновлений
						ClassServer.SaveUpdateInBase(2, DateTime.Now.ToString(), "", "Очистка значения константы", "");
						ClassForms.Rapid_Client.MessageConsole("Константы: успешное удаление значений записи.", false);
					} else ClassForms.Rapid_Client.MessageConsole("Константы: Ошибка выполнения запроса к таблице 'Константы' очистка записи с идентификатором " + listView1.Items[listView1.SelectedIndices[0]].SubItems[3].Text.ToString(), true);
				}
			}else{
				MessageBox.Show("Извините но вы '" + ClassConfig.Rapid_Client_UserName + "' не обладаете достаточными правами для выполнения удаления.","Сообщение");
				ClassForms.Rapid_Client.MessageConsole("Константы: у вас недостаточно прав для выполнения удаления.", false);
			}
		}
		
		void ИзменитьКонстантуToolStripMenuItemClick(object sender, EventArgs e)
		{
			//Окно редактирования значения константы
			if(ClassConfig.Rapid_Client_UserRight == "admin"){
				if(listView1.SelectedIndices.Count > 0){ // проверка выбранного элемента
					FormClientConstEdit Rapid_ClientConstEdit = new FormClientConstEdit();
					Rapid_ClientConstEdit.MdiParent= ClassForms.Rapid_Client;
					Rapid_ClientConstEdit.ActionID = listView1.Items[listView1.SelectedIndices[0]].SubItems[3].Text.ToString();
					Rapid_ClientConstEdit.Rapid_ClientConst = this;
					Rapid_ClientConstEdit.Show();
				}
			}else{
				MessageBox.Show("Извините но вы '" + ClassConfig.Rapid_Client_UserName + "' не обладаете достаточными правами для ввода изменений.","Сообщение");
				ClassForms.Rapid_Client.MessageConsole("Константы: у вас недостаточно прав для ввода изменений.", false);
			}
		}
		
		void УдалитьКонстантуToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(ClassConfig.Rapid_Client_UserRight == "admin"){
				if(listView1.SelectedIndices.Count > 0){ // проверка выбранного элемента
					ClassMySQL_Short SQlCommand = new ClassMySQL_Short();
					SQlCommand.SqlCommand = "UPDATE constants SET const_value = '', const_additionally = '' WHERE (id_const = " + listView1.Items[listView1.SelectedIndices[0]].SubItems[3].Text.ToString() + ")";
					if(SQlCommand.ExecuteNonQuery()){
						ClassForms.Rapid_Client.MessageConsole("Константы: успешное удаление значений записи.", false);
						TableUpdate(); // Обновление таблицы констант в окне констант
					} else ClassForms.Rapid_Client.MessageConsole("Константы: Ошибка выполнения запроса к таблице 'Константы' очистка записи с идентификатором " + listView1.Items[listView1.SelectedIndices[0]].SubItems[3].Text.ToString(), true);
				}
			}else{
				MessageBox.Show("Извините но вы '" + ClassConfig.Rapid_Client_UserName + "' не обладаете достаточными правами для выполнения удаления.","Сообщение");
				ClassForms.Rapid_Client.MessageConsole("Константы: у вас недостаточно прав для выполнения удаления.", false);
			}
		}
	}
}
