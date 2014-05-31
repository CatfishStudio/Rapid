/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 08.02.2014
 * Время: 14:02
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Rapid.Client.Firms
{
	/// <summary>
	/// Description of FormClientFirmsElement.
	/// </summary>
	public partial class FormClientFirmsElement : Form
	{
		/* Глобальные переменные */
		public String ActionID;
		public FormClientFirms Rapid_ClientFirms;
		private ClassMySQL_Full _firmsMySQL = new ClassMySQL_Full();
		private DataSet _firmsDataSet = new DataSet();
		
		public FormClientFirmsElement()
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
			// Загрузка списка доступных папок
			_firmsDataSet.Clear();
			_firmsDataSet.DataSetName = "firms";
			_firmsMySQL.SelectSqlCommand = "SELECT * FROM firms WHERE (firm_type = 1 AND firm_delete = 0) ORDER BY firm_name ASC";
			if(_firmsMySQL.ExecuteFill(_firmsDataSet, "firms")){
				DataTable table = _firmsDataSet.Tables["firms"];
				foreach(DataRow row in table.Rows)
        		{
					comboBox1.Items.Add(row["firm_name"].ToString());
				}
			} else ClassForms.Rapid_Client.MessageConsole("Фирмы: Ошибка при выгрузке перечня доступных папок.", true);
			// При создании новой записи
			if(this.Text == "Новая запись."){
				ClassForms.Rapid_Client.MessageConsole("Фирмы: Создание новой записи.", false);
			}
			// При изменении записи
			if(this.Text == "Изменить запись."){
				_firmsDataSet.Clear();
				_firmsDataSet.DataSetName = "firms";
				_firmsMySQL.SelectSqlCommand = "SELECT * FROM firms WHERE (id_firm = " + ActionID + ")";
				if(_firmsMySQL.ExecuteFill(_firmsDataSet, "firms")){
					DataTable table = _firmsDataSet.Tables["firms"];
					textBox1.Text = table.Rows[0]["firm_name"].ToString();
					textBox3.Text = table.Rows[0]["firm_details"].ToString();
					textBox4.Text = table.Rows[0]["firm_address_phone"].ToString();
					textBox5.Text = table.Rows[0]["firm_additionally"].ToString();
					textBox2.Text = table.Rows[0]["firm_trade_representative"].ToString();
					comboBox1.Text = table.Rows[0]["firm_folder"].ToString();
					ClassForms.Rapid_Client.MessageConsole("Фирмы: запись №" + ActionID + " успешно открыта для редактирования.", false);
				}else ClassForms.Rapid_Client.MessageConsole("Фирмы: Ошибка выполнения запроса к таблице 'Фирмы' обращение к записи с идентификатором " + ActionID + " тип записи 'Запись'.", true);
				
			}
		}
		void FormClientFirmsElementLoad(object sender, EventArgs e)
		{
			WindowLoad(); // Загрузка окна
		}
		/*----------------------------------------------------------------*/
		
		/* Закрываем окно */
		void Button2Click(object sender, EventArgs e)
		{
			Close();
		}
		void FormClientFirmsElementClosed(object sender, EventArgs e)
		{
			ClassForms.Rapid_Client.MessageConsole("Фирмы: закрыто окно обработки записи.", false);
		}
		/*----------------------------------------------------------------*/
		
		/* СОХРАНЕНИЕ: сохранение данных в таблицу */
		void SaveData() // созранение данных
		{
			ClassMySQL_Short SQlCommand = new ClassMySQL_Short();
			
			// При сохранении новой записи
			if(this.Text == "Новая запись."){
				SQlCommand.SqlCommand = "INSERT INTO firms (firm_name, firm_details, firm_address_phone, firm_trade_representative, firm_additionally, firm_type, firm_folder, firm_delete) VALUE ('" + textBox1.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox2.Text + "', '" + textBox5.Text + "', 0, '" + comboBox1.Text + "', 0)";
				if(SQlCommand.ExecuteNonQuery()){
					// ИСТОРИЯ: Запись в журнал истории обновлений
					ClassServer.SaveUpdateInBase(3, DateTime.Now.ToString(), "", "Создание новой записи.", "");
					ClassForms.Rapid_Client.MessageConsole("Фирмы: успешное создание новой записи.", false);
					Close();
				} else ClassForms.Rapid_Client.MessageConsole("Фирмы: Ошибка выполнения запроса к таблице 'Фирмы' при создании новой записи.", true);
			}
			// При сохранении измененной записи
			if(this.Text == "Изменить запись."){
				if(ClassConfig.Rapid_Client_UserRight == "admin"){
					SQlCommand.SqlCommand = "UPDATE firms SET firm_name = '" + textBox1.Text + "', firm_details ='" + textBox3.Text + "', firm_address_phone = '" + textBox4.Text + "', firm_trade_representative = '" + textBox2.Text + "', firm_additionally = '" + textBox5.Text + "', firm_folder = '" + comboBox1.Text + "'  WHERE (id_firm = " + ActionID + ") ";
					if(SQlCommand.ExecuteNonQuery()){
						// ИСТОРИЯ: Запись в журнал истории обновлений
						ClassServer.SaveUpdateInBase(3, DateTime.Now.ToString(), "", "Изменение записи.", "");
						ClassForms.Rapid_Client.MessageConsole("Фирмы: успешное изменение записи.", false);
						Close();
					} else ClassForms.Rapid_Client.MessageConsole("Фирмы: Ошибка выполнения запроса к таблице 'Фирмы' при изменении записи.", true);
				}else{
					MessageBox.Show("Извините но вы '" + ClassConfig.Rapid_Client_UserName + "' не обладаете достаточными правами для ввода изменений.","Сообщение");
					ClassForms.Rapid_Client.MessageConsole("Фирмы: у вас недостаточно прав для ввода изменений.", false);
				}
			}
		}
		void Button1Click(object sender, EventArgs e)
		{
			if(textBox1.Text != "") SaveData(); // созранение данных
			else MessageBox.Show("Вы не ввели значение наименование!","Сообщение",MessageBoxButtons.OK);
		}
		/*----------------------------------------------------------------*/
		
		/* Обращение к справочнику "Сотрудники" */
		void SelectStaff() // выбрать сотрудника
		{
			ClassForms.Rapid_ClientStaff = new FormClientStaff();
			ClassForms.Rapid_ClientStaff.ShowMenuReturnValue();
			ClassForms.Rapid_ClientStaff.MdiParent = ClassForms.Rapid_Client;
			ClassForms.Rapid_ClientStaff.TextBoxReturnValue = textBox2;
			ClassForms.Rapid_ClientStaff.Show();
		}
		void Button3Click(object sender, EventArgs e)
		{
			SelectStaff(); // выбрать сотрудника
		}
	}
}
