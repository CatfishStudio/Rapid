/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 26.02.2014
 * Время: 11:50
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Rapid.Client.Firms;

namespace Rapid
{
	/// <summary>
	/// Description of FormClientDocOrder.
	/// </summary>
	public partial class FormClientDocOrder : Form
	{
		/*Глобальные переменные */
		private String DocID;
		public String ActionID;
		public ClassMySQL_Short OrderMySQL = new ClassMySQL_Short();
		public ClassMySQL_Full OrderTS_MySQL = new ClassMySQL_Full();
		public DataSet OrderTS_DataSet = new DataSet();
		
		public FormClientDocOrder()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		/* Расчет итогов -------------------------------------------------*/
		void CalculationResults()
		{
			double _sum = 0;
			double _nds = 0;
			double _total = 0;
			for(int i = 0; i < OrderTS_DataSet.Tables["tabularsection"].Rows.Count; i++)
			{
				_sum = _sum + ClassConversion.StringToDouble(OrderTS_DataSet.Tables["tabularsection"].Rows[i]["tabularSection_sum"].ToString());
				_nds = _nds + ClassConversion.StringToDouble(OrderTS_DataSet.Tables["tabularsection"].Rows[i]["tabularSection_NDS"].ToString());
				_total = _total + ClassConversion.StringToDouble(OrderTS_DataSet.Tables["tabularsection"].Rows[i]["tabularSection_total"].ToString());
			}
			_sum = Math.Round(_sum, 2);
			_nds = Math.Round(_nds, 2);
			_total = Math.Round(_total, 2);
			
			labelSum.Text = ClassConversion.StringToMoney(_sum.ToString());
			labelNDS.Text = ClassConversion.StringToMoney(_nds.ToString());
			labelTotal.Text = ClassConversion.StringToMoney(_total.ToString());
		}
		/*---------------------------------------------------------*/
		
		/* ЗАГРУЗКА: Загрузка окна */
		void WindowLoad() // Загрузка окна
		{
			// При создании новой записи
			if(this.Text == "Новая документ."){
				// формируем уникальный идентификатор документа
				DocID = "ORDER:" + DateTime.Now.ToString();
				// Загружаем информацию из констант
				textBox6.Text = ClassSelectConst.constantValue("Основной склад");
				label12.Text = ClassConfig.Rapid_Client_UserName;
				// Формируем табличную часть
				OrderTS_DataSet.Clear();
				OrderTS_DataSet.DataSetName = "tabularsection";
				OrderTS_MySQL.SelectSqlCommand = "SELECT id_tabularSection, tabularSection_tmc, tabularSection_units, tabularSection_number, tabularSection_price, tabularSection_NDS, tabularSection_sum, tabularSection_total, tabularSection_id_doc  FROM tabularsection WHERE (tabularSection_id_doc = '" + DocID + "')";
				
				OrderTS_MySQL.InsertSqlCommand = "INSERT INTO tabularsection (tabularSection_tmc, tabularSection_units, tabularSection_number, tabularSection_price, tabularSection_NDS, tabularSection_sum, tabularSection_total, tabularSection_id_doc) " +
														"VALUE (@tabularSection_tmc, @tabularSection_units, @tabularSection_number, @tabularSection_price, @tabularSection_NDS, @tabularSection_sum, @tabularSection_total, @tabularSection_id_doc)";
				OrderTS_MySQL.InsertParametersAdd("@tabularSection_tmc", MySqlDbType.VarChar, 250, "tabularSection_tmc", UpdateRowSource.None);
				OrderTS_MySQL.InsertParametersAdd("@tabularSection_units", MySqlDbType.VarChar, 250, "tabularSection_units", UpdateRowSource.None);
				OrderTS_MySQL.InsertParametersAdd("@tabularSection_number", MySqlDbType.Double, 10, "tabularSection_number", UpdateRowSource.None);
				OrderTS_MySQL.InsertParametersAdd("@tabularSection_price", MySqlDbType.Double, 10, "tabularSection_price", UpdateRowSource.None);
				OrderTS_MySQL.InsertParametersAdd("@tabularSection_NDS", MySqlDbType.Double, 10, "tabularSection_NDS", UpdateRowSource.None);
				OrderTS_MySQL.InsertParametersAdd("@tabularSection_sum", MySqlDbType.Double, 10, "tabularSection_sum", UpdateRowSource.None);
				OrderTS_MySQL.InsertParametersAdd("@tabularSection_total", MySqlDbType.Double, 10, "tabularSection_total", UpdateRowSource.None);
				OrderTS_MySQL.InsertParametersAdd("@tabularSection_id_doc", MySqlDbType.VarChar, 250, "tabularSection_id_doc", UpdateRowSource.None);
						
				/*
				OrderTS_MySQL.UpdateSqlCommand = "UPDATE tabularsection SET tabularSection_tmc = ?, tabularSection_units = ?, tabularSection_number = ?, tabularSection_price = ?, tabularSection_NDS = ?, tabularSection_sum = ?, tabularSection_total = ?, tabularSection_id_doc = ? WHERE (id_tabularSection = ?)" +
												" AND (tabularSection_tmc = ? OR ? IS NULL AND tabularSection_tmc IS NULL)" +
												" AND (tabularSection_units = ? OR ? IS NULL AND tabularSection_units IS NULL)" +
												" AND (tabularSection_number = ? OR ? IS NULL AND tabularSection_number IS NULL)" +
												" AND (tabularSection_price = ? OR ? IS NULL AND tabularSection_price IS NULL)" +
												" AND (tabularSection_NDS = ? OR ? IS NULL AND tabularSection_NDS IS NULL)" +
												" AND (tabularSection_sum = ? OR ? IS NULL AND tabularSection_sum IS NULL)" +
												" AND (tabularSection_total = ? OR ? IS NULL AND tabularSection_total IS NULL)" +
												" AND (tabularSection_id_doc = ? OR ? IS NULL AND tabularSection_id_doc IS NULL)";
				OrderTS_MySQL.DeleteSqlCommand = "DELETE FROM tabularsection WHERE (id_tabularSection = ?)" +
												" AND (tabularSection_tmc = ? OR ? IS NULL AND tabularSection_tmc IS NULL)" +
												" AND (tabularSection_units = ? OR ? IS NULL AND tabularSection_units IS NULL)" +
												" AND (tabularSection_number = ? OR ? IS NULL AND tabularSection_number IS NULL)" +
												" AND (tabularSection_price = ? OR ? IS NULL AND tabularSection_price IS NULL)" +
												" AND (tabularSection_NDS = ? OR ? IS NULL AND tabularSection_NDS IS NULL)" +
												" AND (tabularSection_sum = ? OR ? IS NULL AND tabularSection_sum IS NULL)" +
												" AND (tabularSection_total = ? OR ? IS NULL AND tabularSection_total IS NULL)" +
												" AND (tabularSection_id_doc = ? OR ? IS NULL AND tabularSection_id_doc IS NULL)";
				*/
				if(OrderTS_MySQL.ExecuteFill(OrderTS_DataSet, "tabularsection")){
					// формируем табличную часть
					dataGrid1.DataSource = OrderTS_DataSet;		//.Tables["tabularsection"];
					dataGrid1.DataMember = "tabularsection";
					
				} else ClassForms.Rapid_Client.MessageConsole("Заказ: Ошибка формирования пустой табличной части.", true);
				ClassForms.Rapid_Client.MessageConsole("Заказ: Создание нового документа.", false);
			}
			// При изменении записи
			if(this.Text == "Изменить документ."){
				
			}
		}
		
		void FormClientDocOrderLoad(object sender, EventArgs e)
		{
			WindowLoad(); // Загрузка окна			
		}
		/*---------------------------------------------------------*/
		
		/* Покупатель ---------------------------------------------*/
		/* Обращение к справочнику "Фирмы" */
		void SelectFirmBuyer() // выбрать фирму.
		{
			ClassForms.Rapid_ClientFirms = new FormClientFirms();
			ClassForms.Rapid_ClientFirms.ShowMenuReturnValue();
			ClassForms.Rapid_ClientFirms.MdiParent = ClassForms.Rapid_Client;
			ClassForms.Rapid_ClientFirms.TextBoxReturnValue = textBox2;
			ClassForms.Rapid_ClientFirms.Show();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			SelectFirmBuyer();
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			textBox2.Clear();
			textBox3.Clear();
		}
		
		/* Загрузка данных из таблицы фирмы*/
		void FirmBuyerDataLoad(String firmName)
		{
			ClassMySQL_Full firmMySQL = new ClassMySQL_Full();
			DataSet firmDataSet = new DataSet();
			firmDataSet.Clear();
			firmDataSet.DataSetName = "firms";
			firmMySQL.SelectSqlCommand = "SELECT * FROM firms WHERE (firm_name = '" + firmName + "')";
			if(firmMySQL.ExecuteFill(firmDataSet, "firms")){
				DataTable table = firmDataSet.Tables["firms"];
			   	textBox3.Text = table.Rows[0]["firm_details"].ToString() + System.Environment.NewLine + "Адрес и телефон:" + System.Environment.NewLine + table.Rows[0]["firm_address_phone"].ToString();
			   	
			}else ClassForms.Rapid_Client.MessageConsole("Заказ: Ошибка при загрузке данных о фирме.", true);
		}
		
		void TextBox2TextChanged(object sender, EventArgs e)
		{
			if(textBox2.Text != "") FirmBuyerDataLoad(textBox2.Text); // Загрузка данных
			
		}
		/*---------------------------------------------------------*/
		
		/* Продавец -----------------------------------------------*/
		/* Обращение к справочнику "Фирмы" */
		void SelectFirmSeller() // выбрать фирму.
		{
			ClassForms.Rapid_ClientFirms = new FormClientFirms();
			ClassForms.Rapid_ClientFirms.ShowMenuReturnValue();
			ClassForms.Rapid_ClientFirms.MdiParent = ClassForms.Rapid_Client;
			ClassForms.Rapid_ClientFirms.TextBoxReturnValue = textBox5;
			ClassForms.Rapid_ClientFirms.Show();
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			SelectFirmSeller();
		}
				
		void Button4Click(object sender, EventArgs e)
		{
			textBox4.Clear();
			textBox5.Clear();			
		}
		
		/* Загрузка данных из таблицы фирмы*/
		void FirmSellerDataLoad(String firmName)
		{
			ClassMySQL_Full firmMySQL = new ClassMySQL_Full();
			DataSet firmDataSet = new DataSet();
			firmDataSet.Clear();
			firmDataSet.DataSetName = "firms";
			firmMySQL.SelectSqlCommand = "SELECT * FROM firms WHERE (firm_name = '" + firmName + "')";
			if(firmMySQL.ExecuteFill(firmDataSet, "firms")){
				DataTable table = firmDataSet.Tables["firms"];
			   	textBox4.Text = table.Rows[0]["firm_details"].ToString() + System.Environment.NewLine + "Адрес и телефон:" + System.Environment.NewLine + table.Rows[0]["firm_address_phone"].ToString();
			   	
			}else ClassForms.Rapid_Client.MessageConsole("Заказ: Ошибка при загрузке данных о фирме.", true);
		}
				
		void TextBox5TextChanged(object sender, EventArgs e)
		{
			if(textBox5.Text != "") FirmSellerDataLoad(textBox5.Text); // Загрузка данных			
		}
		/*---------------------------------------------------------*/
		
		/* Обращение к справочнику "Склад" */
		void SelectStore() // выбрать склад.
		{
			ClassForms.Rapid_ClientStore = new FormClientStore();
			ClassForms.Rapid_ClientStore.ShowMenuReturnValue();
			ClassForms.Rapid_ClientStore.MdiParent = ClassForms.Rapid_Client;
			ClassForms.Rapid_ClientStore.TextBoxReturnValue = textBox6;
			ClassForms.Rapid_ClientStore.Show();
		}
		
		void Button5Click(object sender, EventArgs e)
		{
			SelectStore();
		}
		/*---------------------------------------------------------*/
		
		/* Обращение к справочнику "Сотрудник" */
		void SelectStaff() // выбрать сотрудник.
		{
			ClassForms.Rapid_ClientStaff = new FormClientStaff();
			ClassForms.Rapid_ClientStaff.ShowMenuReturnValue();
			ClassForms.Rapid_ClientStaff.MdiParent = ClassForms.Rapid_Client;
			ClassForms.Rapid_ClientStaff.TextBoxReturnValue = textBox7;
			ClassForms.Rapid_ClientStaff.Show();
		}
		
		void Button9Click(object sender, EventArgs e)
		{
			SelectStaff();
		}
		/*---------------------------------------------------------*/
		
		/* УПРАВЛЕНИЕ ТАБЛИЧНОЙ ЧАСТЬЮ ----------------------------*/
		/* ДОБАВИТЬ СТРОКУ */
		void LineAdd() /* добавить новую строку */
		{
			FormClientDocTableElement Rapid_ClientDocOrderElement = new FormClientDocTableElement();
			Rapid_ClientDocOrderElement.Text = "Новая строка";
			Rapid_ClientDocOrderElement.BuyOrSell = false;					// флаг продажа
			Rapid_ClientDocOrderElement.ActualDate = dateTimePicker1.Text;	// актуальная дата остатков
			Rapid_ClientDocOrderElement.ParentDataSet = OrderTS_DataSet;		// родительский DataSet
			Rapid_ClientDocOrderElement.labelSum = labelSum;				// родительская метка "сумма"
			Rapid_ClientDocOrderElement.labelNDS = labelNDS;				// родительская метка "ндс"
			Rapid_ClientDocOrderElement.labelTotal = labelTotal;			// родительская метка "всего"
			Rapid_ClientDocOrderElement.DocID = DocID;						// идентификатор документа
			Rapid_ClientDocOrderElement.MdiParent = ClassForms.Rapid_Client;
			Rapid_ClientDocOrderElement.Show();
		}
		
		void Button6Click(object sender, EventArgs e)
		{
			LineAdd(); // добавить новую строку
		}
		
		void НоваяСтрокаToolStripMenuItemClick(object sender, EventArgs e)
		{
			LineAdd(); // добавить новую строку
		}
		
		/* ИЗМЕНИТЬ СТРОКУ */
		void LineEdit(int indexLineParentDataSet) /* изменить строку */
		{
			if(OrderTS_DataSet.Tables["tabularsection"].Rows.Count > 0){
				FormClientDocTableElement Rapid_ClientDocOrderElement = new FormClientDocTableElement();
				Rapid_ClientDocOrderElement.Text = "Изменить строку";
				Rapid_ClientDocOrderElement.BuyOrSell = false;					// флаг продажа
				Rapid_ClientDocOrderElement.ActualDate = dateTimePicker1.Text;	// актуальная дата остатков
				Rapid_ClientDocOrderElement.ParentDataSet = OrderTS_DataSet;		// родительский DataSet
				Rapid_ClientDocOrderElement.labelSum = labelSum;				// родительская метка "сумма"
				Rapid_ClientDocOrderElement.labelNDS = labelNDS;				// родительская метка "ндс"
				Rapid_ClientDocOrderElement.labelTotal = labelTotal;			// родительская метка "всего"
				Rapid_ClientDocOrderElement.DocID = DocID;						// идентификатор документа
				Rapid_ClientDocOrderElement.indexLineParentDataSet = indexLineParentDataSet; // индекс выбраной строки
				Rapid_ClientDocOrderElement.textBox1.Text = OrderTS_DataSet.Tables["tabularsection"].Rows[indexLineParentDataSet]["tabularSection_tmc"].ToString();
				Rapid_ClientDocOrderElement.textBox2.Text = OrderTS_DataSet.Tables["tabularsection"].Rows[indexLineParentDataSet]["tabularSection_units"].ToString();
				Rapid_ClientDocOrderElement.textBox3.Text = ClassConversion.StringToMoney(OrderTS_DataSet.Tables["tabularsection"].Rows[indexLineParentDataSet]["tabularSection_number"].ToString());
				Rapid_ClientDocOrderElement.textBox4.Text = ClassConversion.StringToMoney(OrderTS_DataSet.Tables["tabularsection"].Rows[indexLineParentDataSet]["tabularSection_price"].ToString());
				Rapid_ClientDocOrderElement.textBox6.Text = ClassConversion.StringToMoney(OrderTS_DataSet.Tables["tabularsection"].Rows[indexLineParentDataSet]["tabularSection_NDS"].ToString());
				Rapid_ClientDocOrderElement.textBox7.Text = ClassConversion.StringToMoney(OrderTS_DataSet.Tables["tabularsection"].Rows[indexLineParentDataSet]["tabularSection_sum"].ToString());
				Rapid_ClientDocOrderElement.textBox8.Text = ClassConversion.StringToMoney(OrderTS_DataSet.Tables["tabularsection"].Rows[indexLineParentDataSet]["tabularSection_total"].ToString());
				Rapid_ClientDocOrderElement.MdiParent = ClassForms.Rapid_Client;
				Rapid_ClientDocOrderElement.Show();
			}
		}
		
		void Button7Click(object sender, EventArgs e)
		{
			LineEdit(dataGrid1.CurrentRowIndex); // Изменить строку
		}
		
		void ИзменитьСтрокуToolStripMenuItemClick(object sender, EventArgs e)
		{
			LineEdit(dataGrid1.CurrentRowIndex); // Изменить строку
		}
		
		/* УДАЛИТЬ СТРОКУ */
		void LineDelete(int indexLineParentDataSet) // удалить строку
		{
			if(OrderTS_DataSet.Tables["tabularsection"].Rows.Count > 0) OrderTS_DataSet.Tables["tabularsection"].Rows[indexLineParentDataSet].Delete();
		}
		
		void Button8Click(object sender, EventArgs e)
		{
			LineDelete(dataGrid1.CurrentRowIndex); // удалить строку.
			CalculationResults(); // Перерасчёт итогов.
		}
				
		void УдалитьСтрокуToolStripMenuItemClick(object sender, EventArgs e)
		{
			LineDelete(dataGrid1.CurrentRowIndex); // удалить строку.
			CalculationResults(); // Перерасчёт итогов.
		}
		/*---------------------------------------------------------*/
		
		/* Закрыть окно */
		void Button10Click(object sender, EventArgs e)
		{
			Close();
		}
		
		void FormClientDocOrderClosed(object sender, EventArgs e)
		{
			ClassForms.Rapid_Client.MessageConsole("Заказ: Закрытие документа.", false);
		}
		/*---------------------------------------------------------*/
		
		/* Печать */
		void Button12Click(object sender, EventArgs e)
		{
			
		}
		/*---------------------------------------------------------*/
		
		/* Созранить документ */
		void SaveDoc()
		{
			// При создании новой записи
			if(this.Text == "Новая документ."){
				OrderMySQL.SqlCommand = "INSERT INTO journal (journal_id_doc, journal_date, journal_number, journal_user_autor, journal_type, journal_store, journal_firm_buyer, journal_firm_buyer_details, journal_firm_seller, journal_firm_seller_details, journal_staff_trade_representative, journal_typeTax, journal_sum, journal_tax, journal_total, journal_delete) " +
					"VALUE ('" + DocID + "', '" + dateTimePicker1.Text + "', '" + textBox1.Text + "', '" + label12.Text + "', 'Заказ', '" + textBox6.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox5.Text + "', '" + textBox4.Text + "', '" + textBox7.Text + "', '', " + labelSum.Text + ", " + labelNDS.Text + ", "+ labelTotal.Text + ", 0)";
				if(OrderMySQL.ExecuteNonQuery()){
					if(OrderTS_MySQL.ExecuteUpdate(OrderTS_DataSet, "tabularsection")){
						
						// Закрыть окно
						//Close();
					} else ClassForms.Rapid_Client.MessageConsole("Заказ: Ошибка сохранения табличной части.", true);
				} else ClassForms.Rapid_Client.MessageConsole("Заказ: Ошибка сохранения данных о документе в журнале документов.", true);
			}
			
			// При изменении записи
			if(this.Text == "Изменить документ."){
				
			}
		}
		
		void Button11Click(object sender, EventArgs e)
		{
			SaveDoc(); //сохранение документа.
		}
		/*---------------------------------------------------------*/
	}
}
