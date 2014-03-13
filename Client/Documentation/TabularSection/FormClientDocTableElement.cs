/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 27.02.2014
 * Время: 9:58
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
	/// Description of FormClientDocTableElement.
	/// </summary>
	public partial class FormClientDocTableElement : Form
	{
		/* Глобальные переменные */
		public DataSet ParentDataSet;			// родительский объект DataSet
		public DataGrid ParentDataGrid;			// родительский объект DataGrid
		public Label labelSum;					// родительская метка "сумма"
		public Label labelNDS;					// родительская метка "ндс"
		public Label labelTotal;				// родительская метка "всего"
		public int indexLineParentDataSet;		// индекс строки родительского объекта DataSet
		public bool BuyOrSell;					// флаг: покупка-true; продажа-false;
		public String ActualDate;				// актуальная дата для получения остатка тмц
		public String DocID;					// идентификатор документа
				
		public FormClientDocTableElement()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		/* ВЫЧИСЛЕНИЕ ----------------------------------------------------*/
		void Calculation()
		{
			// Сумма без НДС (Цена, Количество)
			textBox7.Text = ClassCalculation.Sum(textBox4.Text, textBox3.Text);
			// НДС (Сумма без НДС, Ставка НДС)
			textBox6.Text = ClassCalculation.NDS(textBox5.Text, textBox7.Text);
			// Всего (Сумма без НДС, НДС)
			textBox8.Text = ClassCalculation.Total(textBox7.Text, textBox6.Text);
		}
		/*----------------------------------------------------------------*/
		
		/* Расчет итогов -------------------------------------------------*/
		void CalculationResults()
		{
			double _sum = 0;
			double _nds = 0;
			double _total = 0;
			//for(int i = 0; i < ParentDataGrid.VisibleRowCount; i++)
			for(int i = 0; i < ParentDataSet.Tables["tabularsection"].Rows.Count; i++)
			{
				_sum = _sum + ClassConversion.StringToDouble(ParentDataSet.Tables["tabularsection"].Rows[i]["tabularSection_sum"].ToString());
				_nds = _nds + ClassConversion.StringToDouble(ParentDataSet.Tables["tabularsection"].Rows[i]["tabularSection_NDS"].ToString());
				_total = _total + ClassConversion.StringToDouble(ParentDataSet.Tables["tabularsection"].Rows[i]["tabularSection_total"].ToString());
			}
			_sum = Math.Round(_sum, 2);
			_nds = Math.Round(_nds, 2);
			_total = Math.Round(_total, 2);
			
			labelSum.Text = ClassConversion.StringToMoney(_sum.ToString());
			labelNDS.Text = ClassConversion.StringToMoney(_nds.ToString());
			labelTotal.Text = ClassConversion.StringToMoney(_total.ToString());
		}
		
		/* Закрытие окна*/
		void Button14Click(object sender, EventArgs e)
		{
			Close();
		}
		
		void FormClientDocOrderElementClosed(object sender, EventArgs e)
		{
			ClassForms.Rapid_Client.MessageConsole("Строка заказа: закрыто окно обработки строки табличной части документа Заказ.", false);
		}
		/*----------------------------------------------------------------*/
		
		/* Загрузка окна */
		void FormClientDocOrderElementLoad(object sender, EventArgs e)
		{
			// Загружаем информацию из констант
			textBox2.Text = ClassSelectConst.constantValue("Ед. измерения");
			if(this.Text == "Новая строка")	textBox5.Text = ClassSelectConst.constantValue("Вид НДС");
			label9.Text = "Остаток на складе: " + ClassBalance.BalanceShow(textBox1.Text, ActualDate) + " на дату: " + ActualDate;
			ClassForms.Rapid_Client.MessageConsole("Строка заказа: открыто окно обработки строки табличной части документа Заказ.", false);
		}
		/*----------------------------------------------------------------*/
		
		/* Справочник ТМЦ ------------------------------------------------*/
		void SelectTMC() // выбрать ТМЦ.
		{
			ClassForms.Rapid_ClientTmc = new FormClientTmc();
			ClassForms.Rapid_ClientTmc.ShowMenuReturnValue();
			ClassForms.Rapid_ClientTmc.MdiParent = ClassForms.Rapid_Client;
			ClassForms.Rapid_ClientTmc.TextBoxReturnValue = textBox1;
			ClassForms.Rapid_ClientTmc.Show();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			SelectTMC();
		}
		
		/* Загрузка данных из таблицы фирмы*/
		void TmcDataLoad(String tmcName)
		{
			ClassMySQL_Full tmcMySQL = new ClassMySQL_Full();
			DataSet tmcDataSet = new DataSet();
			tmcDataSet.Clear();
			tmcDataSet.DataSetName = "tmc";
			tmcMySQL.SelectSqlCommand = "SELECT * FROM tmc WHERE (tmc_name = '" + tmcName + "')";
			if(tmcMySQL.ExecuteFill(tmcDataSet, "tmc")){
				DataTable table = tmcDataSet.Tables["tmc"];
				if(table.Rows.Count > 0){
					// Наименование ТМЦ
			   		textBox2.Text = table.Rows[0]["tmc_units"].ToString();
			   		// Количество ТМЦ на складе
			   		textBox3.Text = "1.00";
			   		label9.Text = "Остаток на складе: " + ClassBalance.BalanceShow(textBox1.Text, ActualDate) + " на дату: " + ActualDate;
			   		// Цена (покупка или продажа)
			   		if(BuyOrSell)textBox4.Text = ClassConversion.StringToMoney(table.Rows[0]["tmc_buy"].ToString());
			   		else textBox4.Text = ClassConversion.StringToMoney(table.Rows[0]["tmc_sale"].ToString());
			   		// Вид НДС
			   		textBox5.Text = table.Rows[0]["tmc_type_tax"].ToString();
			   		//Вычисление
			   		Calculation();
				}else{
					//ТМЦ не найден
					textBox2.Clear();
					textBox3.Text = "0.00";
					textBox4.Text = "0.00";
					textBox5.Text = ClassSelectConst.constantValue("Вид НДС");
					textBox6.Text = "0.00";
					textBox7.Text = "0.00";
					textBox8.Text = "0.00";
				}
			}else ClassForms.Rapid_Client.MessageConsole("Заказ: Ошибка при загрузке данных о тмц.", true);
		}
		
		/* При вводе значения */
		void TextBox1TextChanged(object sender, EventArgs e)
		{
			if(textBox1.Text != "") TmcDataLoad(textBox1.Text); // Загрузка данных
			label9.Text = "Остаток на складе: " + ClassBalance.BalanceShow(textBox1.Text, ActualDate) + " на дату: " + ActualDate;
		}
		
		/* При потере фокуса */
		void TextBox1LostFocus(object sender, EventArgs e)
		{
			//(Ошибка при открытии на редактирование)// if(textBox1.Text != "") TmcDataLoad(textBox1.Text); // Загрузка данных
			label9.Text = "Остаток на складе: " + ClassBalance.BalanceShow(textBox1.Text, ActualDate) + " на дату: " + ActualDate;
		}
		
		/* При нажатии на Интер*/
		void TextBox1KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab){
				if(textBox1.Text != "") TmcDataLoad(textBox1.Text); // Загрузка данных
				label9.Text = "Остаток на складе: " + ClassBalance.BalanceShow(textBox1.Text, ActualDate) + " на дату: " + ActualDate;
			}
		}
		
		/* Очистка */
		void Button2Click(object sender, EventArgs e)
		{
			textBox1.Clear();
			textBox2.Clear();
			textBox3.Text = "0.00";
			textBox4.Text = "0.00";
			textBox5.Text = ClassSelectConst.constantValue("Вид НДС");
			textBox6.Text = "0.00";
			textBox7.Text = "0.00";
			textBox8.Text = "0.00";
			label9.Text = "Остаток на складе: " + ClassBalance.BalanceShow(textBox1.Text, ActualDate) + " на дату: " + ActualDate;
		}
		/*----------------------------------------------------------------*/
		
		/* Единицы измерения ---------------------------------------------*/
		void SelectUnits() // выбрать фирму.
		{
			ClassForms.Rapid_ClientUnits = new FormClientUnits();
			ClassForms.Rapid_ClientUnits.ShowMenuReturnValue();
			ClassForms.Rapid_ClientUnits.MdiParent = ClassForms.Rapid_Client;
			ClassForms.Rapid_ClientUnits.TextBoxReturnValue = textBox2;
			ClassForms.Rapid_ClientUnits.Show();
		}
				
		void Button4Click(object sender, EventArgs e)
		{
			SelectUnits();
		}
		/*----------------------------------------------------------------*/
		
		/* Количество ----------------------------------------------------*/
		/* Калькулятор */
		void Button6Click(object sender, EventArgs e)
		{
			FormServiceCalculator Calc = new FormServiceCalculator(true);
			Calc.TextBoxReturnValue = this.textBox3;
			Calc.MdiParent = ClassForms.Rapid_Client;
			Calc.Show();			
		}
		
		/* При потере фокуса */
		void TextBox3LostFocus(object sender, EventArgs e)
		{
			String Value = textBox3.Text;
			textBox3.Clear();
			textBox3.Text = ClassConversion.StringToMoney(Value);
			if(textBox3.Text != "" && ClassConversion.checkString(textBox3.Text))Calculation();
			else textBox3.Text = "1.00";
		}
		
		/* При нажатии на Интер*/
		void TextBox3KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab){
				String Value = textBox3.Text;
				textBox3.Clear();
				textBox3.Text = ClassConversion.StringToMoney(Value);
				if(textBox3.Text != "" && ClassConversion.checkString(textBox3.Text))Calculation();
				else textBox3.Text = "1.00";
			}
		}
		
		/* При вводе значения */
		void TextBox3TextChanged(object sender, EventArgs e)
		{
			if(textBox3.Text != "" && ClassConversion.checkString(textBox3.Text))Calculation();
			else textBox3.Text = "1.00";
		}
		
		/* Очистка */
		void Button5Click(object sender, EventArgs e)
		{
			textBox3.Text = "0.00";
			Calculation();
		}
		/*----------------------------------------------------------------*/
		
		/* Цена реализации -----------------------------------------------*/
		/* Калькулятор */
		void Button8Click(object sender, EventArgs e)
		{
			FormServiceCalculator Calc = new FormServiceCalculator(true);
			Calc.TextBoxReturnValue = this.textBox4;
			Calc.MdiParent = ClassForms.Rapid_Client;
			Calc.Show();
		}
		
		/* При потере фокуса */
		void TextBox4LostFocus(object sender, EventArgs e)
		{
			String Value = textBox4.Text;
			textBox4.Clear();
			textBox4.Text = ClassConversion.StringToMoney(Value);
			if(textBox4.Text != "" && ClassConversion.checkString(textBox4.Text))Calculation();
			else textBox4.Text = "0.00";
		}
		
		/* При нажатии на Интер*/
		void TextBox4KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab){
				String Value = textBox4.Text;
				textBox4.Clear();
				textBox4.Text = ClassConversion.StringToMoney(Value);
				if(textBox4.Text != "" && ClassConversion.checkString(textBox4.Text))Calculation();
				else textBox4.Text = "0.00";
			}
		}
		
		/* При вводе значения */
		void TextBox4TextChanged(object sender, EventArgs e)
		{
			if(textBox4.Text != "" && ClassConversion.checkString(textBox4.Text))Calculation();
			else textBox4.Text = "0.00";
		}
		
		/* Очистка */
		void Button7Click(object sender, EventArgs e)
		{
			textBox4.Text = "0.00";
			Calculation();
		}
		/*----------------------------------------------------------------*/
		
		/* Вид НДС -------------------------------------------------------*/
		void SelectTypeTax() // выбрать вида НДС.
		{
			ClassForms.Rapid_ClientTypeTax = new FormClientTypeTax();
			ClassForms.Rapid_ClientTypeTax.ShowMenuReturnValue();
			ClassForms.Rapid_ClientTypeTax.MdiParent = ClassForms.Rapid_Client;
			ClassForms.Rapid_ClientTypeTax.TextBoxReturnValue = textBox5;
			ClassForms.Rapid_ClientTypeTax.Show();
		}
				
		void Button10Click(object sender, EventArgs e)
		{
			SelectTypeTax();
		}
		
		/* При вводе значения */
		void TextBox5TextChanged(object sender, EventArgs e)
		{
			Calculation();
		}
		/*----------------------------------------------------------------*/
		
		/* НДС -----------------------------------------------------------*/
		/* Калькулятор */
		void Button12Click(object sender, EventArgs e)
		{
			FormServiceCalculator Calc = new FormServiceCalculator(true);
			Calc.TextBoxReturnValue = this.textBox6;
			Calc.MdiParent = ClassForms.Rapid_Client;
			Calc.Show();
		}
				
		/* При потере фокуса */
		void TextBox6LostFocus(object sender, EventArgs e)
		{
			String Value = textBox6.Text;
			textBox6.Clear();
			textBox6.Text = ClassConversion.StringToMoney(Value);
			if(textBox6.Text != "" && ClassConversion.checkString(textBox6.Text)){
				if(textBox3.Text != "0.00" && textBox3.Text != "0") textBox4.Text = ClassCalculation.ChangeNDS_ReturnPrice(textBox3.Text, textBox6.Text);
			} else textBox6.Text = "0.00";
		}
		
		/* При нажатии на Интер*/
		void TextBox6KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab){
				String Value = textBox6.Text;
				textBox6.Clear();
				textBox6.Text = ClassConversion.StringToMoney(Value);
				if(textBox6.Text != "" && ClassConversion.checkString(textBox6.Text)){
					if(textBox3.Text != "0.00" && textBox3.Text != "0") textBox4.Text = ClassCalculation.ChangeNDS_ReturnPrice(textBox3.Text, textBox6.Text);
				} else textBox6.Text = "0.00";
			}
		}
		
		/* При вводе значения */
		void TextBox6TextChanged(object sender, EventArgs e)
		{
			if(textBox6.Text != "" && ClassConversion.checkString(textBox6.Text)){
				//(Ошибка перечсёта)// if(textBox3.Text != "0.00" && textBox3.Text != "0") textBox4.Text = ClassCalculation.ChangeNDS_ReturnPrice(textBox3.Text, textBox6.Text);
			} else textBox6.Text = "0.00";
		}
		
		/* Очистка */
		void Button11Click(object sender, EventArgs e)
		{
			textBox6.Text = "0.00";
		}
		/*----------------------------------------------------------------*/
		
		/* Сумма без НДС -------------------------------------------------*/
		/* Калькулятор */
		void Button16Click(object sender, EventArgs e)
		{
			FormServiceCalculator Calc = new FormServiceCalculator(true);
			Calc.TextBoxReturnValue = this.textBox7;
			Calc.MdiParent = ClassForms.Rapid_Client;
			Calc.Show();
		}
		
		/* При потере фокуса */
		void TextBox7LostFocus(object sender, EventArgs e)
		{
			String Value = textBox7.Text;
			textBox7.Clear();
			textBox7.Text = ClassConversion.StringToMoney(Value);
			if(textBox7.Text != "" && ClassConversion.checkString(textBox7.Text)){
				if(textBox3.Text != "0.00" && textBox3.Text != "0") textBox4.Text = ClassCalculation.ChangeSum_ReturnPrice(textBox7.Text, textBox3.Text);
			} else textBox7.Text = "0.00";
		}
		
		/* При нажатии на Интер*/
		void TextBox7KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab){
				String Value = textBox7.Text;
				textBox7.Clear();
				textBox7.Text = ClassConversion.StringToMoney(Value);
				if(textBox7.Text != "" && ClassConversion.checkString(textBox7.Text)){
					if(textBox3.Text != "0.00" && textBox3.Text != "0") textBox4.Text = ClassCalculation.ChangeSum_ReturnPrice(textBox7.Text, textBox3.Text);
				} else textBox7.Text = "0.00";
			}
		}
		
		/* При вводе значения */
		void TextBox7TextChanged(object sender, EventArgs e)
		{
			if(textBox7.Text != "" && ClassConversion.checkString(textBox7.Text)){
				if(textBox3.Text != "0.00" && textBox3.Text != "0") textBox4.Text = ClassCalculation.ChangeSum_ReturnPrice(textBox7.Text, textBox3.Text);
			} else textBox7.Text = "0.00";
		}
		
		/* Очистка */
		void Button15Click(object sender, EventArgs e)
		{
			textBox7.Text = "0.00";
		}
		/*----------------------------------------------------------------*/
		
		/* Всего с НДС ---------------------------------------------------*/
		/* Калькулятор */
		void Button18Click(object sender, EventArgs e)
		{
			FormServiceCalculator Calc = new FormServiceCalculator(true);
			Calc.TextBoxReturnValue = this.textBox8;
			Calc.MdiParent = ClassForms.Rapid_Client;
			Calc.Show();
		}
		
		/* При потере фокуса */
		void TextBox8LostFocus(object sender, EventArgs e)
		{
			String Value = textBox8.Text;
			textBox8.Clear();
			textBox8.Text = ClassConversion.StringToMoney(Value);
			if(textBox8.Text != "" && ClassConversion.checkString(textBox8.Text)){
				textBox6.Text = ClassCalculation.ChangeTotal_ReturnNDS(textBox8.Text, textBox5.Text);
			} else textBox8.Text = "0.00";
		}
		
		/* При нажатии на Интер*/
		void TextBox8KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab){
				String Value = textBox8.Text;
				textBox8.Clear();
				textBox8.Text = ClassConversion.StringToMoney(Value);
				if(textBox8.Text != "" && ClassConversion.checkString(textBox8.Text)){
					textBox6.Text = ClassCalculation.ChangeTotal_ReturnNDS(textBox8.Text, textBox5.Text);
				} else textBox8.Text = "0.00";
			}
		}
				
		/* При вводе значения */
		void TextBox8TextChanged(object sender, EventArgs e)
		{
			if(textBox8.Text != "" && ClassConversion.checkString(textBox8.Text)){
				textBox6.Text = ClassCalculation.ChangeTotal_ReturnNDS(textBox8.Text, textBox5.Text);
			} else textBox8.Text = "0.00";
		}
		
		/* Очистка */
		void Button17Click(object sender, EventArgs e)
		{
			textBox8.Text = "0.00";
		}
		/*----------------------------------------------------------------*/
		
		/* Сохранение данных ---------------------------------------------*/
		void SaveInTable()
		{
			// Сохранение новой строки в таблице документа
			if(this.Text == "Новая строка"){
				// ввод строки в таблицу
				DataRow _row = ParentDataSet.Tables["tabularsection"].NewRow();
				_row["tabularSection_tmc"] = textBox1.Text;
				_row["tabularSection_units"] = textBox2.Text;
				_row["tabularSection_number"] = ClassConversion.StringToDouble(textBox3.Text);
				_row["tabularSection_price"] = ClassConversion.StringToDouble(textBox4.Text);
				_row["tabularSection_NDS"] = ClassConversion.StringToDouble(textBox6.Text);
				_row["tabularSection_sum"] = ClassConversion.StringToDouble(textBox7.Text);
				_row["tabularSection_total"] = ClassConversion.StringToDouble(textBox8.Text);
				_row["tabularSection_id_doc"] = DocID;
				ParentDataSet.Tables["tabularsection"].Rows.Add(_row);
				// подсчет итогов
				CalculationResults();
				// Закрываем окно
				Close();
			}
			
			// Сохранение изменённой строки в таблице документа
			if(this.Text == "Изменить строку"){
				ParentDataSet.Tables["tabularsection"].Rows[indexLineParentDataSet]["tabularSection_tmc"] = textBox1.Text;
				ParentDataSet.Tables["tabularsection"].Rows[indexLineParentDataSet]["tabularSection_units"] = textBox2.Text;
				ParentDataSet.Tables["tabularsection"].Rows[indexLineParentDataSet]["tabularSection_number"] = ClassConversion.StringToDouble(textBox3.Text);
				ParentDataSet.Tables["tabularsection"].Rows[indexLineParentDataSet]["tabularSection_price"] = ClassConversion.StringToDouble(textBox4.Text);
				ParentDataSet.Tables["tabularsection"].Rows[indexLineParentDataSet]["tabularSection_NDS"] = ClassConversion.StringToDouble(textBox6.Text);
				ParentDataSet.Tables["tabularsection"].Rows[indexLineParentDataSet]["tabularSection_sum"] = ClassConversion.StringToDouble(textBox7.Text);
				ParentDataSet.Tables["tabularsection"].Rows[indexLineParentDataSet]["tabularSection_total"] = ClassConversion.StringToDouble(textBox8.Text);
				// подсчет итогов
				CalculationResults();
				// Закрываем окно
				Close();
			}
		}
		
		void Button13Click(object sender, EventArgs e)
		{
			SaveInTable(); // сохранить данные в таблицу.
		}
		/*----------------------------------------------------------------*/
	}
}
