/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 17.05.2014
 * Время: 7:11
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
	/// Description of FormAdminRemoving.
	/// </summary>
	public partial class FormAdminRemoving : Form
	{
		public FormAdminRemoving()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		ClassMySQL_Short _deleteMySQL = new ClassMySQL_Short();
		ClassMySQL_Full _removeMySQL = new ClassMySQL_Full();
		DataSet _removeDataSet = new DataSet();
		
		/* Выгружаем список всех объектов базы данных помеченных на удаление */
		/* Фирмы */
		void unloadingFirms(){
			_removeDataSet.Clear();
			_removeDataSet.DataSetName = "firms";
			_removeMySQL.SelectSqlCommand = "SELECT * FROM firms WHERE (firm_delete = 1)";
			_removeMySQL.ExecuteFill(_removeDataSet, "firms");
			DataTable table = _removeDataSet.Tables["firms"];
			foreach(DataRow row in table.Rows)
        	{
				checkedListBox1.Items.Add("Фирмы:" + row["firm_name"].ToString(), true);
			}
		}
		/* ТМЦ */
		void unloadingTMC(){
			_removeDataSet.Clear();
			_removeDataSet.DataSetName = "tmc";
			_removeMySQL.SelectSqlCommand = "SELECT * FROM tmc WHERE (tmc_delete = 1)";
			_removeMySQL.ExecuteFill(_removeDataSet, "tmc");
			DataTable table = _removeDataSet.Tables["tmc"];
			foreach(DataRow row in table.Rows)
        	{
				checkedListBox1.Items.Add("ТМЦ:" + row["tmc_name"].ToString(), true);
			}
		}
		/* Склады */
		void unloadingStore(){
			_removeDataSet.Clear();
			_removeDataSet.DataSetName = "store";
			_removeMySQL.SelectSqlCommand = "SELECT * FROM store WHERE (store_delete = 1)";
			_removeMySQL.ExecuteFill(_removeDataSet, "store");
			DataTable table = _removeDataSet.Tables["store"];
			foreach(DataRow row in table.Rows)
        	{
				checkedListBox1.Items.Add("Склады:" + row["store_name"].ToString(), true);
			}
		}
		/* Ед. изм */
		void unloadingUnits(){
			_removeDataSet.Clear();
			_removeDataSet.DataSetName = "units";
			_removeMySQL.SelectSqlCommand = "SELECT * FROM units WHERE (units_delete = 1)";
			_removeMySQL.ExecuteFill(_removeDataSet, "units");
			DataTable table = _removeDataSet.Tables["units"];
			foreach(DataRow row in table.Rows)
        	{
				checkedListBox1.Items.Add("Ед.Изм:" + row["units_name"].ToString(), true);
			}
		}
		/* Вид налога */
		void unloadingTypeTax(){
			_removeDataSet.Clear();
			_removeDataSet.DataSetName = "typeTax";
			_removeMySQL.SelectSqlCommand = "SELECT * FROM typeTax WHERE (typeTax_delete = 1)";
			_removeMySQL.ExecuteFill(_removeDataSet, "typeTax");
			DataTable table = _removeDataSet.Tables["typeTax"];
			foreach(DataRow row in table.Rows)
        	{
				checkedListBox1.Items.Add("Вид налога:" + row["typeTax_name"].ToString(), true);
			}
		}
		/* Сотрудники */
		void unloadingStaff(){
			_removeDataSet.Clear();
			_removeDataSet.DataSetName = "staff";
			_removeMySQL.SelectSqlCommand = "SELECT * FROM staff WHERE (staff_delete = 1)";
			_removeMySQL.ExecuteFill(_removeDataSet, "staff");
			DataTable table = _removeDataSet.Tables["staff"];
			foreach(DataRow row in table.Rows)
        	{
				checkedListBox1.Items.Add("Сотрудники:" + row["staff_name"].ToString(), true);
			}
		}
		/* План счетов */
		void unloadingPlanAccounts(){
			_removeDataSet.Clear();
			_removeDataSet.DataSetName = "planAccounts";
			_removeMySQL.SelectSqlCommand = "SELECT * FROM planAccounts WHERE (planAccounts_delete = 1)";
			_removeMySQL.ExecuteFill(_removeDataSet, "planAccounts");
			DataTable table = _removeDataSet.Tables["planAccounts"];
			foreach(DataRow row in table.Rows)
        	{
				checkedListBox1.Items.Add("План счетов:" + row["planAccounts_name"].ToString(), true);
			}
		}
		/* Журнал документов */
		void unloadingJournal(){
			_removeDataSet.Clear();
			_removeDataSet.DataSetName = "journal";
			_removeMySQL.SelectSqlCommand = "SELECT * FROM journal WHERE (journal_delete = 1)";
			_removeMySQL.ExecuteFill(_removeDataSet, "journal");
			DataTable table = _removeDataSet.Tables["journal"];
			foreach(DataRow row in table.Rows)
        	{
				checkedListBox1.Items.Add("Документ:" + row["journal_number"].ToString(), true);
			}
		}
		
		void ToolStripButton1Click(object sender, EventArgs e)
		{
			checkedListBox1.Items.Clear();
			listBox1.Items.Clear();
			unloadingFirms(); // фирмы
			unloadingTMC(); // ТМЦ
			unloadingStore(); // Склады
			unloadingUnits(); // Ед. изм
			unloadingTypeTax(); // Вид налога
			unloadingStaff(); // Сотрудники
			unloadingPlanAccounts(); // План счетов
			unloadingJournal(); // Полный журнал
		}
		
		/* Выполняем удаление выбранных элементов */
		void removeInTable(String _tableName, String _value)
		{
			if(_tableName == "Фирмы") _deleteMySQL.SqlCommand = "DELETE FROM firms WHERE (firm_name = '" + _value + "' AND firm_delete = 1)";
			if(_tableName == "ТМЦ") _deleteMySQL.SqlCommand = "DELETE FROM tmc WHERE (tmc_name = '" + _value + "' AND tmc_delete = 1)";
			if(_tableName == "Склады") _deleteMySQL.SqlCommand = "DELETE FROM store WHERE (store_name = '" + _value + "' AND store_delete = 1)";
			if(_tableName == "Ед.Изм") _deleteMySQL.SqlCommand = "DELETE FROM units WHERE (units_name = '" + _value + "' AND units_delete = 1)";
			if(_tableName == "Вид налога") _deleteMySQL.SqlCommand = "DELETE FROM typeTax WHERE (typeTax_name = '" + _value + "' AND typeTax_delete = 1)";
			if(_tableName == "Сотрудники") _deleteMySQL.SqlCommand = "DELETE FROM staff WHERE (staff_name = '" + _value + "' AND staff_delete = 1)";
			if(_tableName == "План счетов") _deleteMySQL.SqlCommand = "DELETE FROM planAccounts WHERE (planAccounts_name = '" + _value + "' AND planAccounts_delete = 1)";
			if(_tableName == "Документ") {
				
				
				ClassMySQL_Full _removeDocMySQL = new ClassMySQL_Full();
				DataSet _removeDocDataSet = new DataSet();
				_removeDocMySQL.SelectSqlCommand = "SELECT * FROM journal WHERE (journal_number = '" + _value + "' AND journal_delete = 1)";
				_removeDocDataSet.Clear();
				_removeDocDataSet.DataSetName = "journal";
				if(_removeDocMySQL.ExecuteFill(_removeDocDataSet, "journal")){
					_deleteMySQL.SqlCommand = "DELETE FROM tabularSection WHERE (tabularSection_id_doc = '" + _removeDocDataSet.Tables["journal"].Rows[0]["journal_id_doc"].ToString() + "')";
					if(_deleteMySQL.ExecuteNonQuery())
					{
						_deleteMySQL.SqlCommand = "DELETE FROM journal WHERE (journal_number = '" + _value + "' AND journal_delete = 1)";
						if(_deleteMySQL.ExecuteNonQuery())
						{
							listBox1.Items.Add("[" + _tableName + "]  " + _value + " - - - Запись удалена!");
						}
					}
				}
		
			}else{
				if(_deleteMySQL.ExecuteNonQuery())
				{
					listBox1.Items.Add("[" + _tableName + "]  " + _value + " - - - Запись удалена!");
				}
			}
			
			
			
			
			
		}
		
		void removing(String _value)
		{
			String _tableName = "";
			String _recordName = "";
			bool _point = false;
			for(int i = 0; i < _value.Length; i++){
				if(_point == true) _recordName += _value[i].ToString();
				if(_value[i].ToString() == ":") _point = true;
				if(_point == false) _tableName += _value[i].ToString();
			}
			/* Удаление */
			removeInTable(_tableName, _recordName);
		}
		
		void ToolStripButton2Click(object sender, EventArgs e)
		{
			if(MessageBox.Show("Удалить безвозвратно выбранные записи?", "Вопрос:", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				for(int i = 0; i < checkedListBox1.Items.Count; i++){
					if(checkedListBox1.GetItemChecked(i) == true) removing(checkedListBox1.Items[i].ToString());
				}
			}
		}
		
		/* Закрыть окно */
		void Button4Click(object sender, EventArgs e)
		{
			Close();
		}
		
		/* Выбрать всё */
		void ВыбратьВсёToolStripMenuItemClick(object sender, EventArgs e)
		{
			for(int i = 0; i < checkedListBox1.Items.Count; i++)
				checkedListBox1.SetItemChecked(i, true);
		}
		
		/* Отменить всё */
		void ОтменитьВсёToolStripMenuItemClick(object sender, EventArgs e)
		{
			for(int i = 0; i < checkedListBox1.Items.Count; i++)
				checkedListBox1.SetItemChecked(i, false);
		}
	}
}
