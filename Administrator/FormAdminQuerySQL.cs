/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 15.03.2014
 * Время: 10:23
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
	/// Description of FormAdminQuerySQL.
	/// </summary>
	public partial class FormAdminQuerySQL : Form
	{
		private ClassMySQL_Full _mySQL = new ClassMySQL_Full();
		private DataSet _dataSet = new DataSet();
		
		public FormAdminQuerySQL()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			_dataSet.Clear();
			dataGrid1.DataSource = _dataSet;
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			
			try{
				// Запрос Select
				if(checkBox1.Checked){
					_mySQL.SelectSqlCommand = textBox1.Text;
					if(_mySQL.ExecuteFill(_dataSet, comboBox1.Text)){
						dataGrid1.DataSource = _dataSet;
					}else { 
						MessageBox.Show("Ошибка выполнения запроса.");
						_dataSet.Clear();
						dataGrid1.DataSource = _dataSet;
					}
				}
				// Запрос Insert
				if(checkBox2.Checked){
					_mySQL.InsertSqlCommand = textBox1.Text;
					if(_mySQL.ExecuteUpdate(_dataSet, comboBox1.Text)){
						dataGrid1.DataSource = _dataSet;
					}else { 
						MessageBox.Show("Ошибка выполнения запроса.");
						_dataSet.Clear();
						dataGrid1.DataSource = _dataSet;
					}
				}
				// Запрос Update
				if(checkBox3.Checked){
					_mySQL.UpdateSqlCommand = textBox1.Text;
					if(_mySQL.ExecuteUpdate(_dataSet, comboBox1.Text)){
						dataGrid1.DataSource = _dataSet;
					}else { 
						MessageBox.Show("Ошибка выполнения запроса.");
						_dataSet.Clear();
						dataGrid1.DataSource = _dataSet;
					}
				}
				// Запрос Delete
				if(checkBox4.Checked){
					_mySQL.DeleteSqlCommand = textBox1.Text;
					if(_mySQL.ExecuteUpdate(_dataSet, comboBox1.Text)){
						dataGrid1.DataSource = _dataSet;
					}else { 
						MessageBox.Show("Ошибка выполнения запроса.");
						_dataSet.Clear();
						dataGrid1.DataSource = _dataSet;
					}
				}
			}catch(Exception ex){
				MessageBox.Show(ex.ToString());
				_dataSet.Clear();
				dataGrid1.DataSource = _dataSet;
			}
		}
	}
}
