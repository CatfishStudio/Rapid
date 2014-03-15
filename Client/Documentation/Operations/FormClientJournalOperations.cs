/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 15.03.2014
 * Время: 15:13
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
	/// Description of FormClientJournalOperations.
	/// </summary>
	public partial class FormClientJournalOperations : Form
	{
		/* Глобальные переменные */
		private ClassMySQL_Full _MySQL = new ClassMySQL_Full();
		private DataSet _DataSet = new DataSet(); // элементы
		private int selectTableLine = 0;	// выбранная строка в таблице
		
		public FormClientJournalOperations()
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
		void FormClientJournalOperationsLoad(object sender, EventArgs e)
		{
			ClassForms.OpenCloseFormJournalOperations = true;
			ClassForms.Rapid_Client.MessageConsole("Журнал бухгалтерских операций: открыт.", false);
			TableUpdate(); // Загрузка данных из базы данных
		}
		
		/* ТАБЛИЦА: Загружаем данные из базы данных в таблицу ----------------*/
		public void TableUpdate()
		{
			//Загрузка данных в таблицу
			try{
				listView1.Items.Clear();
				
				_DataSet.Clear();
				_DataSet.DataSetName = "operations";
				
				_MySQL.SelectSqlCommand = "SELECT * FROM operations WHERE (operations_date BETWEEN '" + dateTimePicker1.Text + "' AND '" + dateTimePicker2.Text + "' AND (operations_id_doc LIKE '%" + textBox1.Text + "%' OR operations_sum LIKE '%" + textBox1.Text + "%')) ORDER BY operations_date ASC";
				
				if(_MySQL.ExecuteFill(_DataSet, "operations") == false){
					ClassForms.Rapid_Client.MessageConsole("Журнал Бухгалтерских операций: Ошибка выполнения запроса к таблице 'Операции' при отборе операций.", true);
					return;
				}
				DataTable _table = _DataSet.Tables["operations"];
			
				// ОТОБРАЖЕНИЕ "Элементов"
				foreach(DataRow rowElement in _table.Rows)
        		{
					ListViewItem ListViewItem_add = new ListViewItem();
					ListViewItem_add.SubItems.Add(rowElement["operations_date"].ToString());
					ListViewItem_add.StateImageIndex = 2; // картинка
					ListViewItem_add.SubItems.Add(rowElement["operations_DT"].ToString());
					ListViewItem_add.SubItems.Add(rowElement["operations_KT"].ToString());
					ListViewItem_add.SubItems.Add(ClassConversion.StringToMoney(rowElement["operations_sum"].ToString()));
					ListViewItem_add.SubItems.Add(rowElement["operations_id_doc"].ToString());
					ListViewItem_add.SubItems.Add(rowElement["id_operations"].ToString());
					listView1.Items.Add(ListViewItem_add);
				}
				
				// ВЫБОР: выдиляем ранее выбранный элемент.
				listView1.SelectedIndices.IndexOf(selectTableLine);
			}catch{
				ClassForms.Rapid_Client.MessageConsole("Журнал Бухгалтерских операций: Ошибка вывода информации выбранной из таблицы 'Операции'.", true);
			}
		}
		
		/* ЗАКРЫТИЕ ОКНА ---------------------------------------------------- */
		void FormClientJournalOperationsClosed(object sender, EventArgs e)
		{
			ClassForms.Rapid_Client.MessageConsole("Журнал Бухгалтерских операций: закрыт.", false);
			ClassForms.OpenCloseFormJournalOperations = false; // форма закрыта
		}
		
		void Button8Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
