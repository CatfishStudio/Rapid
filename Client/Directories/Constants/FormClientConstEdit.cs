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
using Rapid.Client.Firms;

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
		
		/* Обращение к справочникам */
		void InsertValue()
		{
			if(textBox1.Text == "Наша фирма" || textBox1.Text == "Поставщик" || textBox1.Text == "Покупатель"){
				ClassForms.Rapid_ClientFirms = new FormClientFirms();
				ClassForms.Rapid_ClientFirms.MdiParent = ClassForms.Rapid_Client;
				ClassForms.Rapid_ClientFirms.ShowMenuReturnValue();
				ClassForms.Rapid_ClientFirms.TextBoxReturnValue = textBox2;
				ClassForms.Rapid_ClientFirms.Show();
			}
			
			if(textBox1.Text == "Вид НДС") {
				ClassForms.Rapid_ClientTypeTax = new FormClientTypeTax();
				ClassForms.Rapid_ClientTypeTax.MdiParent = ClassForms.Rapid_Client;
				ClassForms.Rapid_ClientTypeTax.ShowMenuReturnValue();
				ClassForms.Rapid_ClientTypeTax.TextBoxReturnValue = textBox2;
				ClassForms.Rapid_ClientTypeTax.Show();
			}
			if(textBox1.Text == "Основной склад"){
				ClassForms.Rapid_ClientStore = new FormClientStore();
				ClassForms.Rapid_ClientStore.MdiParent = ClassForms.Rapid_Client;
				ClassForms.Rapid_ClientStore.ShowMenuReturnValue();
				ClassForms.Rapid_ClientStore.TextBoxReturnValue = textBox2;
				ClassForms.Rapid_ClientStore.Show();
			}
			if(textBox1.Text == "Ед. измерения"){
				ClassForms.Rapid_ClientUnits = new FormClientUnits();
				ClassForms.Rapid_ClientUnits.MdiParent = ClassForms.Rapid_Client;
				ClassForms.Rapid_ClientUnits.ShowMenuReturnValue();
				ClassForms.Rapid_ClientUnits.TextBoxReturnValue = textBox2;
				ClassForms.Rapid_ClientUnits.Show();
			}
			if(textBox1.Text == "Директор" || textBox1.Text == "Главный бухгалтер"){
				ClassForms.Rapid_ClientStaff = new FormClientStaff();
				ClassForms.Rapid_ClientStaff.MdiParent = ClassForms.Rapid_Client;
				ClassForms.Rapid_ClientStaff.ShowMenuReturnValue();
				ClassForms.Rapid_ClientStaff.TextBoxReturnValue = textBox2;
				ClassForms.Rapid_ClientStaff.Show();
			}
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			InsertValue();
		}
	}
}
