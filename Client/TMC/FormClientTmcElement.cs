/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 15.02.2014
 * Время: 11:11
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
	/// Description of FormClientTmcElement.
	/// </summary>
	public partial class FormClientTmcElement : Form
	{
		/* Глобальные переменные */
		public String ActionID;
		public FormClientTmc Rapid_ClientTmc;
		private ClassMySQL_Full _tmcMySQL = new ClassMySQL_Full();
		private DataSet _tmcDataSet = new DataSet();
		
		
		public FormClientTmcElement()
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
			_tmcDataSet.Clear();
			_tmcDataSet.DataSetName = "tmc";
			_tmcMySQL.SelectSqlCommand = "SELECT * FROM tmc WHERE (tmc_type = 1 AND tmc_delete = 0) ORDER BY tmc_name ASC";
			if(_tmcMySQL.ExecuteFill(_tmcDataSet, "tmc")){
				DataTable table = _tmcDataSet.Tables["tmc"];
				foreach(DataRow row in table.Rows)
        		{
					comboBox1.Items.Add(row["tmc_name"].ToString());
				}
			} else ClassForms.Rapid_Client.MessageConsole("ТМЦ: Ошибка при выгрузке перечня доступных папок.", true);
			// При создании новой записи
			if(this.Text == "Новая запись."){
				// Загружаем информацию из констант
				textBox2.Text = ClassSelectConst.constantValue("Вид НДС");
				textBox3.Text = ClassSelectConst.constantValue("Ед. измерения");
				textBox7.Text = ClassSelectConst.constantValue("Основной склад");
				ClassForms.Rapid_Client.MessageConsole("ТМЦ: Создание новой записи.", false);
			}
			// При изменении записи
			if(this.Text == "Изменить запись."){
				_tmcDataSet.Clear();
				_tmcDataSet.DataSetName = "tmc";
				_tmcMySQL.SelectSqlCommand = "SELECT * FROM tmc WHERE (id_tmc = " + ActionID + ")";
				if(_tmcMySQL.ExecuteFill(_tmcDataSet, "tmc")){
					DataTable table = _tmcDataSet.Tables["tmc"];
					textBox1.Text = table.Rows[0]["tmc_name"].ToString();
					textBox2.Text = table.Rows[0]["tmc_type_tax"].ToString();
					textBox3.Text = table.Rows[0]["tmc_units"].ToString();
					textBox4.Text = ClassConversion.StringToMoney(table.Rows[0]["tmc_buy"].ToString());
					textBox5.Text = ClassConversion.StringToMoney(table.Rows[0]["tmc_sale"].ToString());
					textBox6.Text = table.Rows[0]["tmc_additionally"].ToString();
					textBox7.Text = table.Rows[0]["tmc_store"].ToString();
					comboBox1.Text = table.Rows[0]["tmc_folder"].ToString();
					ClassForms.Rapid_Client.MessageConsole("ТМЦ: запись №" + ActionID + " успешно открыта для редактирования.", false);
				}else ClassForms.Rapid_Client.MessageConsole("ТМЦ: Ошибка выполнения запроса к таблице 'ТМЦ' обращение к записи с идентификатором " + ActionID + " тип записи 'Запись'.", true);
				
			}
		}
		void FormClientTmcElementLoad(object sender, EventArgs e)
		{
			WindowLoad(); // Загрузка окна			
		}
		/*----------------------------------------------------------------*/
		
		/* Закрываем окно */
		void Button2Click(object sender, EventArgs e)
		{
			Close();
		}
		void FormClientTmcElementClosed(object sender, EventArgs e)
		{
			ClassForms.Rapid_Client.MessageConsole("ТМЦ: закрыто окно обработки записи.", false);
		}
		/*----------------------------------------------------------------*/
		
		/* СОХРАНЕНИЕ: сохранение данных в таблицу */
		void SaveData() // созранение данных
		{
			ClassMySQL_Short SQlCommand = new ClassMySQL_Short();
			
			// При сохранении новой записи
			if(this.Text == "Новая запись."){
				SQlCommand.SqlCommand = "INSERT INTO tmc (tmc_name, tmc_type_tax, tmc_units, tmc_buy, tmc_sale, tmc_store, tmc_additionally, tmc_type, tmc_folder, tmc_delete) VALUE ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', " + textBox4.Text + ", " + textBox5.Text + ", '" + textBox7.Text + "', '" + textBox6.Text + "', 0, '" + comboBox1.Text + "', 0)";
				if(SQlCommand.ExecuteNonQuery()){
					ClassMySQL_Short SqlCommandBalance = new ClassMySQL_Short();
					String DateInsert = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
					SqlCommandBalance.SqlCommand = "INSERT INTO balance (balance_tmc, balance_date, balance_number) VALUE ('" + textBox1.Text + "', '" + DateInsert + "', 0)";
					if(!SqlCommandBalance.ExecuteNonQuery()) ClassForms.Rapid_Client.MessageConsole("ТМЦ: Ошибка ввода новой записи в таблицу 'Остатки'", true);
					// ИСТОРИЯ: Запись в журнал истории обновлений
					ClassServer.SaveUpdateInBase(4, DateTime.Now.ToString(), "", "Создание новой записи.", "");
					ClassForms.Rapid_Client.MessageConsole("ТМЦ: успешное создание новой записи.", false);
					Close();
				} else ClassForms.Rapid_Client.MessageConsole("ТМЦ: Ошибка выполнения запроса к таблице 'ТМЦ' при создании новой записи.", true);
			}
			// При сохранении измененной записи
			if(this.Text == "Изменить запись."){
				if(ClassConfig.Rapid_Client_UserRight == "admin"){
					SQlCommand.SqlCommand = "UPDATE tmc SET tmc_name = '" + textBox1.Text + "', tmc_type_tax = '" + textBox2.Text + "', tmc_units = '" + textBox3.Text + "', tmc_buy = " + textBox4.Text + ", tmc_sale = " + textBox5.Text + ", tmc_store = '" + textBox7.Text + "', tmc_additionally = '" + textBox6.Text + "', tmc_folder = '" + comboBox1.Text + "' WHERE (id_tmc = " + ActionID + ") ";
					if(SQlCommand.ExecuteNonQuery()){
						// ИСТОРИЯ: Запись в журнал истории обновлений
						ClassServer.SaveUpdateInBase(4, DateTime.Now.ToString(), "", "Изменение записи.", "");
						ClassForms.Rapid_Client.MessageConsole("ТМЦ: успешное изменение записи.", false);
						Close();
					} else ClassForms.Rapid_Client.MessageConsole("ТМЦ: Ошибка выполнения запроса к таблице 'ТМЦ' при изменении записи.", true);
				}else{
					MessageBox.Show("Извините но вы '" + ClassConfig.Rapid_Client_UserName + "' не обладаете достаточными правами для ввода изменений.","Сообщение");
					ClassForms.Rapid_Client.MessageConsole("Фирмы: у вас недостаточно прав для ввода изменений.", false);
				}
			}
		}
		void Button1Click(object sender, EventArgs e)
		{
			SaveData(); // созранение данных			
		}
		/*----------------------------------------------------------------*/
		
		
		/* Коррекция дробных чисел */
		void TextBox4TextLostFocus(object sender, EventArgs e)
		{
			String Money = textBox4.Text;
			textBox4.Clear();
			textBox4.Text = ClassConversion.StringToMoney(Money);
		}
		
		/* Коррекция дробных чисел */
		void TextBox5TextLostFocus(object sender, EventArgs e)
		{
			String Money = textBox5.Text;
			textBox5.Clear();
			textBox5.Text = ClassConversion.StringToMoney(Money);
		}
		
		/* Калькулятор */
		void Button5Click(object sender, EventArgs e)
		{
			FormServiceCalculator Calc = new FormServiceCalculator(true);
			Calc.TextBoxReturnValue = this.textBox4;
			Calc.MdiParent = ClassForms.Rapid_Client;
			Calc.Show();
		}
		
		/* Калькулятор */
		void Button6Click(object sender, EventArgs e)
		{
			FormServiceCalculator Calc = new FormServiceCalculator(true);
			Calc.TextBoxReturnValue = this.textBox5;
			Calc.MdiParent = ClassForms.Rapid_Client;
			Calc.Show();
		}
		
		void Button8Click(object sender, EventArgs e)
		{
			textBox4.Text = "0.00";			
		}
		
		void Button9Click(object sender, EventArgs e)
		{
			textBox5.Text = "0.00";				
		}
	}
}
