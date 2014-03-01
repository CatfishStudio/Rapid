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

namespace Rapid
{
	/// <summary>
	/// Description of FormClientDocOrderElement.
	/// </summary>
	public partial class FormClientDocOrderElement : Form
	{
		/* Глобальные переменные */
		public DataSet ParentDataSet;			// родительский объект DataSet
		public int indexLineParentDataSet;		// индекс строки родительского объекта DataSet
		
		public FormClientDocOrderElement()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		/* ВЫЧИСЛЕНИЕ */
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
			textBox5.Text = ClassSelectConst.constantValue("Вид НДС");
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
			   	textBox2.Text = table.Rows[0]["tmc_units"].ToString();
			   	textBox3.Text = "1.00";
			   	textBox4.Text = ClassConversion.StringToMoney(table.Rows[0]["tmc_sale"].ToString());
			   	textBox5.Text = table.Rows[0]["tmc_type_tax"].ToString();
			   	//Вычисление
			   	Calculation();
			}else ClassForms.Rapid_Client.MessageConsole("Заказ: Ошибка при загрузке данных о тмц.", true);
		}
		
		void TextBox1TextChanged(object sender, EventArgs e)
		{
			if(textBox1.Text != "") TmcDataLoad(textBox1.Text); // Загрузка данных
		}
		/*----------------------------------------------------------------*/
	}
}
