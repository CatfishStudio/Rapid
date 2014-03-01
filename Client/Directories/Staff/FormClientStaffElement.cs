/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 24.02.2014
 * Время: 9:49
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Rapid.Service;

namespace Rapid
{
	/// <summary>
	/// Description of FormClientStaffElement.
	/// </summary>
	public partial class FormClientStaffElement : Form
	{
		/* Глобальные переменные */
		public String ActionID;
		public FormClientStaff Rapid_ClientStaff;
		private ClassMySQL_Full _staffMySQL = new ClassMySQL_Full();
		private DataSet _staffDataSet = new DataSet();
		
		public FormClientStaffElement()
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
			_staffDataSet.Clear();
			_staffDataSet.DataSetName = "staff";
			_staffMySQL.SelectSqlCommand = "SELECT * FROM staff WHERE (staff_type = 1 AND staff_delete = 0) ORDER BY staff_name ASC";
			if(_staffMySQL.ExecuteFill(_staffDataSet, "staff")){
				DataTable table = _staffDataSet.Tables["staff"];
				foreach(DataRow row in table.Rows)
        		{
					comboBox1.Items.Add(row["staff_name"].ToString());
				}
			} else ClassForms.Rapid_Client.MessageConsole("Сотрудники: Ошибка при выгрузке перечня доступных папок.", true);
			// При создании новой записи
			if(this.Text == "Новая запись."){
				// Установка актуальной даты
				dateTimePicker1.Value = DateTime.Now;
				dateTimePicker2.Value = DateTime.Now;
				ClassForms.Rapid_Client.MessageConsole("ТМЦ: Создание новой записи.", false);
			}
			// При изменении записи
			if(this.Text == "Изменить запись."){
				_staffDataSet.Clear();
				_staffDataSet.DataSetName = "staff";
				_staffMySQL.SelectSqlCommand = "SELECT * FROM staff WHERE (id_staff = " + ActionID + ")";
				if(_staffMySQL.ExecuteFill(_staffDataSet, "staff")){
					DataTable table = _staffDataSet.Tables["staff"];
					textBox1.Text = table.Rows[0]["staff_name"].ToString();
					textBox2.Text = table.Rows[0]["staff_details"].ToString();
					textBox3.Text = table.Rows[0]["staff_address_phone"].ToString();
					textBox4.Text = ClassConversion.StringToMoney(table.Rows[0]["staff_salary"].ToString());
					textBox5.Text = table.Rows[0]["staff_additionally"].ToString();
					dateTimePicker1.Text = table.Rows[0]["staff_date_hired"].ToString();
					dateTimePicker2.Text = table.Rows[0]["staff_date_fired"].ToString();
					if(table.Rows[0]["staff_fired"].ToString() == "1"){
						checkBox1.Checked = true;
						dateTimePicker2.Enabled = true;
					}else{
						checkBox1.Checked = false;
						dateTimePicker2.Enabled = false;
					}
					comboBox1.Text = table.Rows[0]["staff_folder"].ToString();
					ClassForms.Rapid_Client.MessageConsole("ТМЦ: запись №" + ActionID + " успешно открыта для редактирования.", false);
				}else ClassForms.Rapid_Client.MessageConsole("ТМЦ: Ошибка выполнения запроса к таблице 'ТМЦ' обращение к записи с идентификатором " + ActionID + " тип записи 'Запись'.", true);
				
			}
		}
				
		void FormClientStaffElementLoad(object sender, EventArgs e)
		{
			WindowLoad(); // Загрузка окна			
		}
		/*----------------------------------------------------------------*/
		
		/* Закрываем окно */
		void Button2Click(object sender, EventArgs e)
		{
			Close();
		}
		
		void FormClientStaffElementClosed(object sender, EventArgs e)
		{
			ClassForms.Rapid_Client.MessageConsole("Сотрудники: закрыто окно обработки записи.", false);
		}
		/*----------------------------------------------------------------*/
		
		/* СОХРАНЕНИЕ: сохранение данных в таблицу */
		void SaveData() // созранение данных
		{
			ClassMySQL_Short SQlCommand = new ClassMySQL_Short();
			
			// При сохранении новой записи
			if(this.Text == "Новая запись."){
				String flagFired = (checkBox1.Checked) ? "1" : "0";
				SQlCommand.SqlCommand = "INSERT INTO staff (staff_name, staff_details, staff_address_phone, staff_date_hired, staff_date_fired, staff_fired, staff_salary, staff_additionally, staff_type, staff_folder, staff_delete) VALUE ('"+textBox1.Text+"', '"+textBox2.Text+"', '"+textBox3.Text+"', '"+dateTimePicker1.Text+"', '"+dateTimePicker2.Text+"', "+flagFired+", "+textBox4.Text+", '"+textBox5.Text+"', 0, '"+comboBox1.Text+"', 0)";
				if(SQlCommand.ExecuteNonQuery()){
					// ИСТОРИЯ: Запись в журнал истории обновлений
					ClassServer.SaveUpdateInBase(8, DateTime.Now.ToString(), "", "Создание новой записи.", "");
					ClassForms.Rapid_Client.MessageConsole("Сотрудники: успешное создание новой записи.", false);
					Close();
				} else ClassForms.Rapid_Client.MessageConsole("Сотрудники: Ошибка выполнения запроса к таблице 'ТМЦ' при создании новой записи.", true);
			}
			// При сохранении измененной записи
			if(this.Text == "Изменить запись."){
				if(ClassConfig.Rapid_Client_UserRight == "admin"){
					String flagFired = (checkBox1.Checked) ? "1" : "0";
					SQlCommand.SqlCommand = "UPDATE staff SET staff_name = '"+textBox1.Text+"', staff_details = '"+textBox2.Text+"', staff_address_phone = '"+textBox3.Text+"', staff_date_hired = '"+dateTimePicker1.Text+"', staff_date_fired = '"+dateTimePicker2.Text+"', staff_fired = "+flagFired+", staff_salary = "+textBox4.Text+", staff_additionally = '"+textBox5.Text+"', staff_folder = '"+comboBox1.Text+"' WHERE (id_staff = " + ActionID + ") ";
					if(SQlCommand.ExecuteNonQuery()){
						// ИСТОРИЯ: Запись в журнал истории обновлений
						ClassServer.SaveUpdateInBase(8, DateTime.Now.ToString(), "", "Изменение записи.", "");
						ClassForms.Rapid_Client.MessageConsole("Сотрудники: успешное изменение записи.", false);
						Close();
					} else ClassForms.Rapid_Client.MessageConsole("Сотрудники: Ошибка выполнения запроса к таблице 'Сотрудники' при изменении записи.", true);
				}else{
					MessageBox.Show("Извините но вы '" + ClassConfig.Rapid_Client_UserName + "' не обладаете достаточными правами для ввода изменений.","Сообщение");
					ClassForms.Rapid_Client.MessageConsole("Сотрудники: у вас недостаточно прав для ввода изменений.", false);
				}
			}
		}
				
		void Button1Click(object sender, EventArgs e)
		{
			SaveData(); // созранение данных			
		}
		/*----------------------------------------------------------------*/
		
		/* Зарплата ------------------------------------------------------*/		
		/* При потере фокуса */
		void TextBox4TextLostFocus(object sender, EventArgs e)
		{
			String Money = textBox4.Text;
			textBox4.Clear();
			textBox4.Text = ClassConversion.StringToMoney(Money);
			if(textBox4.Text == "" || ClassConversion.checkString(textBox4.Text) == false) textBox4.Text = "0.00";
		}
		
		/* При вводе значения */
		void TextBox4TextChanged(object sender, EventArgs e)
		{
			if(textBox4.Text == "" || ClassConversion.checkString(textBox4.Text) == false) textBox4.Text = "0.00";
		}
		
		/* При нажатии на Интер*/
		void TextBox4KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab){
				String Value = textBox4.Text;
				textBox4.Clear();
				textBox4.Text = ClassConversion.StringToMoney(Value);
				if(textBox4.Text == "" || ClassConversion.checkString(textBox4.Text) == false) textBox4.Text = "0.00";
			}
		}
				
		/* Калькулятор */
		void Button3Click(object sender, EventArgs e)
		{
			FormServiceCalculator Calc = new FormServiceCalculator(true);
			Calc.TextBoxReturnValue = this.textBox4;
			Calc.MdiParent = ClassForms.Rapid_Client;
			Calc.Show();
		}
		
		/* Очистка */
		void Button4Click(object sender, EventArgs e)
		{
			textBox4.Text = "0.00";			
		}
		/*----------------------------------------------------------------*/
		
		/* Флаг даты увольнения */
		void CheckBox1CheckedChanged(object sender, EventArgs e)
		{
			if(checkBox1.Checked)
				dateTimePicker2.Enabled = true;
			else dateTimePicker2.Enabled = false;
		}
		
		
		
		
	}
}
