/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 01.02.2014
 * Время: 13:43
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
	/// Description of FormClientConstEdit.
	/// </summary>
	public partial class FormClientConstEdit : Form
	{
		/* Глобальные переменные */
		public String ActionID;
		public FormClientConst Rapid_ClientConst;
		private ClassMySQL_Full _constMySQL = new ClassMySQL_Full();
		private DataSet _constDataSet = new DataSet();
		
		public FormClientConstEdit()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		/* Загрузка окна */
		void FormClientConstEditLoad(object sender, EventArgs e)
		{
			//Выгрузка выбранных данных из базы данных
			_constDataSet.Clear();
			_constDataSet.DataSetName = "constants";
			_constMySQL.SelectSqlCommand = "SELECT * FROM constants WHERE (id_const = " + ActionID + ")";
			if(_constMySQL.ExecuteFill(_constDataSet, "constants")){
				DataTable table = _constDataSet.Tables["constants"];
				textBox1.Text = table.Rows[0]["const_name"].ToString();
				textBox2.Text = table.Rows[0]["const_value"].ToString();
				richTextBox1.Text = table.Rows[0]["const_additionally"].ToString();
				ClassForms.Rapid_Client.MessageConsole("Константы: запись №" + ActionID + " успешно открыта для редактирования.", false);
			} else ClassForms.Rapid_Client.MessageConsole("Константы: Ошибка выполнения запроса к таблице 'Константы' обращение к записи с идентификатором " + ActionID, true);
			
		}
		
		/* Закрываем окно */
		void FormClientConstEditClosed(object sender, EventArgs e)
		{
			ClassForms.Rapid_Client.MessageConsole("Константы: закрыта запись №" + ActionID, false);
		}
		
		/* Закрываем окно */
		void Button3Click(object sender, EventArgs e)
		{
			Close();
		}
		
		/* Сохраняем изменения */
		void Button2Click(object sender, EventArgs e)
		{
			ClassMySQL_Short SQlCommand = new ClassMySQL_Short();
			SQlCommand.SqlCommand = "UPDATE constants SET const_name = '" + textBox1.Text + "', const_value = '" + textBox2.Text + "', const_additionally = '" + richTextBox1.Text + "' WHERE (id_const = " + ActionID + ")";
			if(SQlCommand.ExecuteNonQuery()){
				// ИСТОРИЯ: Запись в журнал истории обновлений
				ClassServer.SaveUpdateInBase(2, DateTime.Now.ToString(), "", "Изменение значения константы", "");
				ClassForms.Rapid_Client.MessageConsole("Константы: запись №" + ActionID + " успешно обновлена.", false);
				Close();
			} else ClassForms.Rapid_Client.MessageConsole("Константы: Ошибка выполнения запроса к таблице 'Константы' обновление записи с идентификатором " + ActionID, true);
			
		}
	}
}
