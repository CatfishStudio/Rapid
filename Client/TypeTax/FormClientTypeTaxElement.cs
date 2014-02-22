/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 22.02.2014
 * Время: 13:27
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
	/// Description of FormClientTypeTaxElement.
	/// </summary>
	public partial class FormClientTypeTaxElement : Form
	{
		/* Глобальные переменные */
		public String ActionID;
		public FormClientTypeTax Rapid_ClientTypeTax;
		private ClassMySQL_Full _typeTaxMySQL = new ClassMySQL_Full();
		private DataSet _typeTaxDataSet = new DataSet();
		
		public FormClientTypeTaxElement()
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
				ClassForms.Rapid_Client.MessageConsole("Вид налога: Создание новой записи.", false);
			}
			// При изменении записи
			if(this.Text == "Изменить запись."){
				_typeTaxDataSet.Clear();
				_typeTaxDataSet.DataSetName = "typetax";
				_typeTaxMySQL.SelectSqlCommand = "SELECT * FROM typetax WHERE (id_typeTax = " + ActionID + ")";
				if(_typeTaxMySQL.ExecuteFill(_typeTaxDataSet, "typetax")){
					DataTable table = _typeTaxDataSet.Tables["typetax"];
					textBox1.Text = table.Rows[0]["typeTax_name"].ToString();
					textBox2.Text = ClassConversion.StringToMoney(table.Rows[0]["typeTax_rating"].ToString());
					textBox3.Text = table.Rows[0]["typeTax_additionally"].ToString();
					ClassForms.Rapid_Client.MessageConsole("Вид налога: запись №" + ActionID + " успешно открыта для редактирования.", false);
				}else ClassForms.Rapid_Client.MessageConsole("Вид налога: Ошибка выполнения запроса к таблице 'Вид налога' обращение к записи с идентификатором " + ActionID + " тип записи 'Запись'.", true);
			}
		}
		
		void FormClientTypeTaxElementLoad(object sender, EventArgs e)
		{
			WindowLoad(); // Загрузка окна			
		}
		/*----------------------------------------------------------------*/
		
		/* Закрываем окно */
		void Button2Click(object sender, EventArgs e)
		{
			Close();
		}
		
		void FormClientTypeTaxElementClosed(object sender, EventArgs e)
		{
			ClassForms.Rapid_Client.MessageConsole("Вид налога: закрыто окно обработки записи.", false);
		}
		/*----------------------------------------------------------------*/
		
		/* СОХРАНЕНИЕ: сохранение данных в таблицу */
		void SaveData() // сохранение данных
		{
			ClassMySQL_Short SQlCommand = new ClassMySQL_Short();
			
			// При сохранении новой записи
			if(this.Text == "Новая запись."){
				SQlCommand.SqlCommand = "INSERT INTO typetax (typeTax_name, typeTax_rating, typeTax_additionally) VALUE ('" + textBox1.Text + "', '" + textBox2.Text + "','" + textBox3.Text + "')";
				if(SQlCommand.ExecuteNonQuery()){
					// ИСТОРИЯ: Запись в журнал истории обновлений
					ClassServer.SaveUpdateInBase(7, DateTime.Now.ToString(), "", "Создание новой записи.", "");
					ClassForms.Rapid_Client.MessageConsole("Вид налога: успешное создание новой записи.", false);
					Close();
				} else ClassForms.Rapid_Client.MessageConsole("Вид налога: Ошибка выполнения запроса к таблице 'Вид налога' при создании новой записи.", true);
			}
			// При сохранении измененной записи
			if(this.Text == "Изменить запись."){
				if(ClassConfig.Rapid_Client_UserRight == "admin"){
					SQlCommand.SqlCommand = "UPDATE typetax SET typeTax_name = '" + textBox1.Text + "', typeTax_rating = '" + textBox2.Text + "', typeTax_additionally = '" + textBox3.Text + "' WHERE (id_typeTax = " + ActionID + ") ";
					if(SQlCommand.ExecuteNonQuery()){
						// ИСТОРИЯ: Запись в журнал истории обновлений
						ClassServer.SaveUpdateInBase(7, DateTime.Now.ToString(), "", "Изменение записи.", "");
						ClassForms.Rapid_Client.MessageConsole("Вид налога: успешное изменение записи.", false);
						Close();
					} else ClassForms.Rapid_Client.MessageConsole("Вид налога: Ошибка выполнения запроса к таблице 'Вид налога' при изменении записи.", true);
				}else{
					MessageBox.Show("Извините но вы '" + ClassConfig.Rapid_Client_UserName + "' не обладаете достаточными правами для ввода изменений.","Сообщение");
					ClassForms.Rapid_Client.MessageConsole("Вид налога: у вас недостаточно прав для ввода изменений.", false);
				}
			}
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			SaveData(); // созранение данных			
		}
		/*----------------------------------------------------------------*/
		
		/* Калькулятор */
		void Button3Click(object sender, EventArgs e)
		{
			FormServiceCalculator Calc = new FormServiceCalculator(true);
			Calc.TextBoxReturnValue = this.textBox2;
			Calc.MdiParent = ClassForms.Rapid_Client;
			Calc.Show();			
		}
		
		/* Очистка */
		void Button4Click(object sender, EventArgs e)
		{
			textBox2.Text = "0.00";
		}
		
		/* Коррекция дробных чисел */
		void TextBox2TextLostFocus(object sender, EventArgs e)
		{
			String Money = textBox2.Text;
			textBox2.Clear();
			textBox2.Text = ClassConversion.StringToMoney(Money);
		}
		
		
	}
}
