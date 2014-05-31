/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 25.02.2014
 * Время: 9:53
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
	/// Description of FormClientPlanAccountsElement.
	/// </summary>
	public partial class FormClientPlanAccountsElement : Form
	{
		/* Глобальные переменные */
		public String ActionID;
		private ClassMySQL_Full _planaccountsMySQL = new ClassMySQL_Full();
		private DataSet _planaccountsDataSet = new DataSet();
		
		public FormClientPlanAccountsElement()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		/* ЗАГРУЗКА: Загрузка окна */
		void WindowLoad() // Загрузка окна
		{
			// При создании новой записи
			if(this.Text == "Новая запись."){
				// Загружаем информацию из констант
				ClassForms.Rapid_Client.MessageConsole("План счетов: Создание новой записи.", false);
			}
			// При изменении записи
			if(this.Text == "Изменить запись."){
				_planaccountsDataSet.Clear();
				_planaccountsDataSet.DataSetName = "planaccounts";
				_planaccountsMySQL.SelectSqlCommand = "SELECT * FROM planaccounts WHERE (id_planAccounts = " + ActionID + ")";
				if(_planaccountsMySQL.ExecuteFill(_planaccountsDataSet, "planaccounts")){
					DataTable table = _planaccountsDataSet.Tables["planaccounts"];
					textBox1.Text = table.Rows[0]["planAccounts_name"].ToString();
					textBox2.Text = table.Rows[0]["planAccounts_account"].ToString();
					comboBox1.Text = table.Rows[0]["planAccounts_type"].ToString();
					ClassForms.Rapid_Client.MessageConsole("План счетов: запись №" + ActionID + " успешно открыта для редактирования.", false);
				}else ClassForms.Rapid_Client.MessageConsole("План счетов: Ошибка выполнения запроса к таблице 'План счетов' обращение к записи с идентификатором " + ActionID + " тип записи 'Запись'.", true);
			}
		}
		
		void FormClientPlanAccountsElementLoad(object sender, EventArgs e)
		{
			WindowLoad(); // Загрузка окна			
		}
		/*----------------------------------------------------------------*/
		
		/* Закрываем окно */
		void Button2Click(object sender, EventArgs e)
		{
			Close();
		}
		
		void FormClientPlanAccountsElementClosed(object sender, EventArgs e)
		{
			ClassForms.Rapid_Client.MessageConsole("План счетов: закрыто окно обработки записи.", false);
		}
		/*----------------------------------------------------------------*/
		
		/* СОХРАНЕНИЕ: сохранение данных в таблицу */
		void SaveData() // сохранение данных
		{
			ClassMySQL_Short SQlCommand = new ClassMySQL_Short();
			
			// При сохранении новой записи
			if(this.Text == "Новая запись."){
				SQlCommand.SqlCommand = "INSERT INTO planaccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUE ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + comboBox1.Text + "', 0)";
				if(SQlCommand.ExecuteNonQuery()){
					// ИСТОРИЯ: Запись в журнал истории обновлений
					ClassServer.SaveUpdateInBase(13, DateTime.Now.ToString(), "", "Создание новой записи.", "");
					ClassForms.Rapid_Client.MessageConsole("План счетов: успешное создание новой записи.", false);
					Close();
				} else ClassForms.Rapid_Client.MessageConsole("План счетов: Ошибка выполнения запроса к таблице 'План счетов' при создании новой записи.", true);
			}
			// При сохранении измененной записи
			if(this.Text == "Изменить запись."){
				if(ClassConfig.Rapid_Client_UserRight == "admin"){
					SQlCommand.SqlCommand = "UPDATE planaccounts SET planAccounts_name = '" + textBox1.Text + "', planAccounts_account = '" + textBox2.Text + "', planAccounts_type = '" + comboBox1.Text + "' WHERE (id_planAccounts = " + ActionID + ") ";
					if(SQlCommand.ExecuteNonQuery()){
						// ИСТОРИЯ: Запись в журнал истории обновлений
						ClassServer.SaveUpdateInBase(13, DateTime.Now.ToString(), "", "Изменение записи.", "");
						ClassForms.Rapid_Client.MessageConsole("План счетов: успешное изменение записи.", false);
						Close();
					} else ClassForms.Rapid_Client.MessageConsole("План счетов: Ошибка выполнения запроса к таблице 'План счетов' при изменении записи.", true);
				}else{
					MessageBox.Show("Извините но вы '" + ClassConfig.Rapid_Client_UserName + "' не обладаете достаточными правами для ввода изменений.","Сообщение");
					ClassForms.Rapid_Client.MessageConsole("План счетов: у вас недостаточно прав для ввода изменений.", false);
				}
			}
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			if(textBox1.Text != "" && textBox2.Text != "") SaveData(); // созранение данных
			else MessageBox.Show("Вы не ввели значение наименование и счёт!","Сообщение",MessageBoxButtons.OK);			
		}
		/*----------------------------------------------------------------*/
	}
}
