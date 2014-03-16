/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 15.03.2014
 * Время: 15:41
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
	/// Description of FormClientOperation.
	/// </summary>
	public partial class FormClientOperation : Form
	{
		/*Глобальные переменные */
		public String DocID;
		public String ActionID;
		private ClassMySQL_Full _mySQL = new ClassMySQL_Full();
		private DataSet _dataSet = new DataSet();
		
		public FormClientOperation()
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
			// При создании новой операции
			if(this.Text == "Новая операция."){
				//...
			}
			
			// При изменении операции
			if(this.Text == "Изменить операцию."){
				_dataSet.Clear();
				_dataSet.DataSetName = "operations";
				if(ActionID != "") _mySQL.SelectSqlCommand = "SELECT * FROM operations WHERE (id_operations = " + ActionID + ")";
				if(DocID != "") _mySQL.SelectSqlCommand = "SELECT * FROM operations WHERE (operations_id_doc = " + DocID + ")";
				if(_mySQL.ExecuteFill(_dataSet, "operations"))
				{
					// Загрузка полученной информации
					DataTable _table = _dataSet.Tables["operations"];
					textBox1.Text = _table.Rows[0]["id_operations"].ToString();
					dateTimePicker1.Text = _table.Rows[0]["operations_date"].ToString();
					textBox2.Text = _table.Rows[0]["operations_id_doc"].ToString();
					textBox3.Text = _table.Rows[0]["operations_DT"].ToString();
					textBox4.Text = _table.Rows[0]["operations_KT"].ToString();
					textBox5.Text = ClassConversion.StringToMoney(_table.Rows[0]["operations_sum"].ToString());
					textBox6.Text = _table.Rows[0]["operations_specification"].ToString();
				}else{
					ClassForms.Rapid_Client.MessageConsole("Операция: Ошибка загрузки данных.", true);
					Close();
				}
			}
		}
		
		void FormClientOperationLoad(object sender, EventArgs e)
		{
			WindowLoad();
		}
		
		/* Обращение к справочнику "План счетов" */
		void SelectDT()
		{
			ClassForms.Rapid_ClientPlanAccounts = new FormClientPlanAccounts();
			ClassForms.Rapid_ClientPlanAccounts.ShowMenuReturnValue();
			ClassForms.Rapid_ClientPlanAccounts.MdiParent = ClassForms.Rapid_Client;
			ClassForms.Rapid_ClientPlanAccounts.TextBoxReturnValue = textBox3;
			ClassForms.Rapid_ClientPlanAccounts.Show();
		}
		
		void SelectKT()
		{
			ClassForms.Rapid_ClientPlanAccounts = new FormClientPlanAccounts();
			ClassForms.Rapid_ClientPlanAccounts.ShowMenuReturnValue();
			ClassForms.Rapid_ClientPlanAccounts.MdiParent = ClassForms.Rapid_Client;
			ClassForms.Rapid_ClientPlanAccounts.TextBoxReturnValue = textBox4;
			ClassForms.Rapid_ClientPlanAccounts.Show();
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			SelectDT();
		}
		
		void Button4Click(object sender, EventArgs e)
		{
			textBox3.Clear();
		}
		
		void Button6Click(object sender, EventArgs e)
		{
			SelectKT();
		}
		
		void Button5Click(object sender, EventArgs e)
		{
			textBox4.Clear();
		}
		/*-----------------------------------------------------*/
		
		/* Сумма --------------------------------------------- */
		/* При потере фокуса */
		void TextBox5TextLostFocus(object sender, EventArgs e)
		{
			String Money = textBox5.Text;
			textBox5.Clear();
			textBox5.Text = ClassConversion.StringToMoney(Money);
			if(textBox5.Text == "" || ClassConversion.checkString(textBox5.Text) == false) textBox5.Text = "0.00";
		}
		
		/* При вводе значения */
		void TextBox5TextChanged(object sender, EventArgs e)
		{
			if(textBox5.Text == "" || ClassConversion.checkString(textBox5.Text) == false) textBox5.Text = "0.00";
		}
		
		/* При нажатии на Интер*/
		void TextBox5KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab){
				String Value = textBox5.Text;
				textBox5.Clear();
				textBox5.Text = ClassConversion.StringToMoney(Value);
				if(textBox5.Text == "" || ClassConversion.checkString(textBox5.Text) == false) textBox5.Text = "0.00";
			}
		}
		
		/* Калькулятор */
		void Button8Click(object sender, EventArgs e)
		{
			FormServiceCalculator Calc = new FormServiceCalculator(true);
			Calc.TextBoxReturnValue = this.textBox5;
			Calc.MdiParent = ClassForms.Rapid_Client;
			Calc.Show();		
		}
				
		void Button7Click(object sender, EventArgs e)
		{
			textBox5.Text = "0.00";			
		}
		/*----------------------------------------------------------------*/
		
		/* Закрыть окно ------------------------------------------------- */
		void Button1Click(object sender, EventArgs e)
		{
			Close();
		}
		
		void FormClientOperationClosed(object sender, EventArgs e)
		{
			ClassForms.Rapid_Client.MessageConsole("Операция: Закрытие операции.", false);
		}
		/*---------------------------------------------------------------*/
		
		/* Сохранение операции ----------------------------------------- */
		void SaveOperation()
		{
			// При создании новой операции
			if(this.Text == "Новая операция."){
				if(ClassOperations.OperationAdd(dateTimePicker1.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox2.Text))
				{
					Close();
				} else MessageBox.Show("Ошибка сохранения данных.","Ошибка:");
			}
			
			// При изменении операции
			if(this.Text == "Изменить операцию."){
				if(ClassOperations.OperationEdit(dateTimePicker1.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox2.Text, textBox1.Text))
				{
					Close();
				} else MessageBox.Show("Ошибка сохранения данных.","Ошибка:");
			}
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			SaveOperation();
		}
	}
}
