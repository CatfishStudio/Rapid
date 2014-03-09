/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 26.02.2014
 * Время: 11:46
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
	/// Description of FormClientJournalDoc.
	/// </summary>
	public partial class FormClientJournalDoc : Form
	{
		/* Глобальные переменные */
		private ClassMySQL_Full _jurnalMySQL = new ClassMySQL_Full();
		private DataSet _jurnalDataSet = new DataSet(); // элементы
		private int selectTableLine = 0;	// выбранная строка в таблице
		
		
		public FormClientJournalDoc()
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
		void FormClientJournalDocLoad(object sender, EventArgs e)
		{
			ClassForms.OpenCloseFormJournalDoc = true;
			ClassForms.Rapid_Client.MessageConsole("Полный журнал: открыт.", false);
			TableUpdate(); // Загрузка данных из базы данных
		}
		
		/* ТАБЛИЦА: Загружаем данные из базы данных в таблицу ----------------*/
		public void TableUpdate()
		{
			//Загрузка данных в таблицу
			try{
				listView1.Items.Clear();
				
				_jurnalDataSet.Clear();
				_jurnalDataSet.DataSetName = "journal";
				
				if(comboBox1.Text == "Все") _jurnalMySQL.SelectSqlCommand = "SELECT * FROM journal WHERE (journal_date BETWEEN '" + dateTimePicker1.Text + "' AND '" + dateTimePicker2.Text + "' AND (journal_number LIKE '%" + textBox1.Text + "%' OR journal_total LIKE '%" + textBox1.Text + "%' OR journal_user_autor LIKE '%" + textBox1.Text + "%')) ORDER BY journal_date ASC";
				else _jurnalMySQL.SelectSqlCommand = "SELECT * FROM journal WHERE (journal_date BETWEEN '" + dateTimePicker1.Text + "' AND '" + dateTimePicker2.Text + "' AND journal_type = '" + comboBox1.Text + "' AND (journal_number LIKE '%" + textBox1.Text + "%' OR journal_total LIKE '%" + textBox1.Text + "%' OR journal_user_autor LIKE '%" + textBox1.Text + "%')) ORDER BY journal_date ASC";
				
				if(_jurnalMySQL.ExecuteFill(_jurnalDataSet, "journal") == false){
					ClassForms.Rapid_Client.MessageConsole("Полный журнал: Ошибка выполнения запроса к таблице 'Журнал' при отборе документов.", true);
					return;
				}
				DataTable _table = _jurnalDataSet.Tables["journal"];
			
				// ОТОБРАЖЕНИЕ "Элементов"
				foreach(DataRow rowElement in _table.Rows)
        		{
					ListViewItem ListViewItem_add = new ListViewItem();
					ListViewItem_add.SubItems.Add(rowElement["journal_date"].ToString());
					if(rowElement["journal_delete"].ToString() == "0") //отметка удаления папки
						ListViewItem_add.StateImageIndex = 2; // папка не удалена
					else ListViewItem_add.StateImageIndex = 3; // папка удалена
					ListViewItem_add.SubItems.Add(rowElement["journal_number"].ToString());
					ListViewItem_add.SubItems.Add(rowElement["journal_type"].ToString());
					ListViewItem_add.SubItems.Add(ClassConversion.StringToMoney(rowElement["journal_total"].ToString()));
					ListViewItem_add.SubItems.Add(rowElement["journal_user_autor"].ToString());
					ListViewItem_add.SubItems.Add(rowElement["id_journal"].ToString());
					listView1.Items.Add(ListViewItem_add);
				}
				
				// ВЫБОР: выдиляем ранее выбранный элемент.
				listView1.SelectedIndices.IndexOf(selectTableLine);
			}catch{
				ClassForms.Rapid_Client.MessageConsole("Полный журнал: Ошибка вывода информации выбранной из таблицы 'Журнал'.", true);
			}
		}
		
		/* ЗАКРЫТИЕ ОКНА ---------------------------------------------------- */
		void FormClientJournalDocClosed(object sender, EventArgs e)
		{
			ClassForms.Rapid_Client.MessageConsole("Полный журнал: закрыт.", false);
			ClassForms.OpenCloseFormJournalDoc = false; // форма закрыта
		}
		
		void Button8Click(object sender, EventArgs e)
		{
			Close();
		}
		/*--------------------------------------------------------------------*/
		
		/* Применение фильтров ---------------------------------------------- */
		/* Фильтр: период по дате */
		void Button5Click(object sender, EventArgs e)
		{
			TableUpdate();
		}
		
		/* Фильтр: по типу документа*/
		void Button6Click(object sender, EventArgs e)
		{
			TableUpdate();
		}
		
		/* Поиск */
		void Button7Click(object sender, EventArgs e)
		{
			TableUpdate();
		}
		/*--------------------------------------------------------------------*/
		
	}
}
