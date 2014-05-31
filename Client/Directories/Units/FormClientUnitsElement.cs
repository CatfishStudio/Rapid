/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 21.02.2014
 * Время: 15:18
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
	/// Description of FormClientUnitsElement.
	/// </summary>
	public partial class FormClientUnitsElement : Form
	{
		/* Глобальные переменные */
		public String ActionID;
		public FormClientUnits Rapid_ClientUnits;
		private ClassMySQL_Full _unitsMySQL = new ClassMySQL_Full();
		private DataSet _unitsDataSet = new DataSet();
		
		public FormClientUnitsElement()
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
				ClassForms.Rapid_Client.MessageConsole("Ед.изм.: Создание новой записи.", false);
			}
			// При изменении записи
			if(this.Text == "Изменить запись."){
				_unitsDataSet.Clear();
				_unitsDataSet.DataSetName = "units";
				_unitsMySQL.SelectSqlCommand = "SELECT * FROM units WHERE (id_units = " + ActionID + ")";
				if(_unitsMySQL.ExecuteFill(_unitsDataSet, "units")){
					DataTable table = _unitsDataSet.Tables["units"];
					textBox1.Text = table.Rows[0]["units_name"].ToString();
					textBox2.Text = table.Rows[0]["units_additionally"].ToString();
					ClassForms.Rapid_Client.MessageConsole("Ед.изм.: запись №" + ActionID + " успешно открыта для редактирования.", false);
				}else ClassForms.Rapid_Client.MessageConsole("Ед.изм.: Ошибка выполнения запроса к таблице 'Ед.изм.' обращение к записи с идентификатором " + ActionID + " тип записи 'Запись'.", true);
			}
		}
		
		void FormClientUnitsElementLoad(object sender, EventArgs e)
		{
			WindowLoad(); // Загрузка окна	
		}
		/*----------------------------------------------------------------*/
		
		/* Закрываем окно */
		void Button2Click(object sender, EventArgs e)
		{
			Close();
		}
		
		void FormClientUnitsElementClosed(object sender, EventArgs e)
		{
			ClassForms.Rapid_Client.MessageConsole("Ед.изм.: закрыто окно обработки записи.", false);
		}
		/*----------------------------------------------------------------*/
		
		/* СОХРАНЕНИЕ: сохранение данных в таблицу */
		void SaveData() // сохранение данных
		{
			ClassMySQL_Short SQlCommand = new ClassMySQL_Short();
			
			// При сохранении новой записи
			if(this.Text == "Новая запись."){
				SQlCommand.SqlCommand = "INSERT INTO units (units_name, units_additionally) VALUE ('" + textBox1.Text + "', '" + textBox2.Text + "')";
				if(SQlCommand.ExecuteNonQuery()){
					// ИСТОРИЯ: Запись в журнал истории обновлений
					ClassServer.SaveUpdateInBase(6, DateTime.Now.ToString(), "", "Создание новой записи.", "");
					ClassForms.Rapid_Client.MessageConsole("Ед.изм.: успешное создание новой записи.", false);
					Close();
				} else ClassForms.Rapid_Client.MessageConsole("Ед.изм.: Ошибка выполнения запроса к таблице 'Ед.изм.' при создании новой записи.", true);
			}
			// При сохранении измененной записи
			if(this.Text == "Изменить запись."){
				if(ClassConfig.Rapid_Client_UserRight == "admin"){
					SQlCommand.SqlCommand = "UPDATE units SET units_name = '" + textBox1.Text + "', units_additionally = '" + textBox2.Text + "' WHERE (id_units = " + ActionID + ") ";
					if(SQlCommand.ExecuteNonQuery()){
						// ИСТОРИЯ: Запись в журнал истории обновлений
						ClassServer.SaveUpdateInBase(6, DateTime.Now.ToString(), "", "Изменение записи.", "");
						ClassForms.Rapid_Client.MessageConsole("Ед.изм.: успешное изменение записи.", false);
						Close();
					} else ClassForms.Rapid_Client.MessageConsole("Ед.изм.: Ошибка выполнения запроса к таблице 'Ед.изм.' при изменении записи.", true);
				}else{
					MessageBox.Show("Извините но вы '" + ClassConfig.Rapid_Client_UserName + "' не обладаете достаточными правами для ввода изменений.","Сообщение");
					ClassForms.Rapid_Client.MessageConsole("Ед.изм.: у вас недостаточно прав для ввода изменений.", false);
				}
			}
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			if(textBox1.Text != "") SaveData(); // созранение данных	
			else MessageBox.Show("Вы не ввели значение наименование!","Сообщение",MessageBoxButtons.OK);			
		}
		/*----------------------------------------------------------------*/
	}
}
