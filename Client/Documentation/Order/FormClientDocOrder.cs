﻿/*
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
using System.Drawing.Printing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Rapid.Client.Firms;
using Rapid.Service;

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
		// для редактирования основной информации
		private ClassMySQL_Full JurnalMySQL = new ClassMySQL_Full();
		private DataSet JurnalDataSet = new DataSet();
		
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
			for(int i = 0; i < dataGrid1.VisibleRowCount; i++)
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
		
		/* Загрузка табличной части */
		void LoadTabularSection()
		{
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
						
				
				OrderTS_MySQL.UpdateSqlCommand = "UPDATE tabularsection SET tabularSection_tmc = @tabularSection_tmc, tabularSection_units = @tabularSection_units, tabularSection_number = @tabularSection_number, tabularSection_price = @tabularSection_price, tabularSection_NDS = @tabularSection_NDS, tabularSection_sum = @tabularSection_sum, tabularSection_total = @tabularSection_total, tabularSection_id_doc = @tabularSection_id_doc WHERE (id_tabularSection = @id_tabularSection)";
				OrderTS_MySQL.UpdateParametersAdd("@tabularSection_tmc", MySqlDbType.VarChar, 250, "tabularSection_tmc", UpdateRowSource.None);
				OrderTS_MySQL.UpdateParametersAdd("@tabularSection_units", MySqlDbType.VarChar, 250, "tabularSection_units", UpdateRowSource.None);
				OrderTS_MySQL.UpdateParametersAdd("@tabularSection_number", MySqlDbType.Double, 10, "tabularSection_number", UpdateRowSource.None);
				OrderTS_MySQL.UpdateParametersAdd("@tabularSection_price", MySqlDbType.Double, 10, "tabularSection_price", UpdateRowSource.None);
				OrderTS_MySQL.UpdateParametersAdd("@tabularSection_NDS", MySqlDbType.Double, 10, "tabularSection_NDS", UpdateRowSource.None);
				OrderTS_MySQL.UpdateParametersAdd("@tabularSection_sum", MySqlDbType.Double, 10, "tabularSection_sum", UpdateRowSource.None);
				OrderTS_MySQL.UpdateParametersAdd("@tabularSection_total", MySqlDbType.Double, 10, "tabularSection_total", UpdateRowSource.None);
				OrderTS_MySQL.UpdateParametersAdd("@tabularSection_id_doc", MySqlDbType.VarChar, 250, "tabularSection_id_doc", UpdateRowSource.None);
				OrderTS_MySQL.UpdateParametersAdd("@id_tabularSection", MySqlDbType.Int16, 11, "id_tabularSection", UpdateRowSource.None);
				
				OrderTS_MySQL.DeleteSqlCommand = "DELETE FROM tabularsection WHERE (id_tabularSection = @id_tabularSection)";
				OrderTS_MySQL.DeleteParametersAdd("@id_tabularSection", MySqlDbType.Int16, 11, "id_tabularSection", UpdateRowSource.None);
				
				if(OrderTS_MySQL.ExecuteFill(OrderTS_DataSet, "tabularsection")){
					// формируем табличную часть
					dataGrid1.DataSource = OrderTS_DataSet;		//.Tables["tabularsection"];
					dataGrid1.DataMember = "tabularsection";
					
				} else ClassForms.Rapid_Client.MessageConsole("Заказ: Ошибка формирования пустой табличной части.", true);
		}
		
		/* ЗАГРУЗКА: Загрузка окна */
		void WindowLoad() // Загрузка окна
		{
			// При создании новой записи
			if(this.Text == "Новая документ."){
				// формируем уникальный идентификатор документа
				DocID = "ORDER:" + DateTime.Now.ToString();
				// Загружаем информацию из констант
				textBox6.Text = ClassSelectConst.constantValue("Основной склад");
				textBox5.Text = ClassSelectConst.constantValue("Наша фирма");
				textBox2.Text = ClassSelectConst.constantValue("Покупатель");
				label12.Text = ClassConfig.Rapid_Client_UserName;
				//формируем табличную часть
				LoadTabularSection();
				ClassForms.Rapid_Client.MessageConsole("Заказ: Создание нового документа.", false);
			}
			// При изменении записи
			if(this.Text == "Изменить документ."){
				// Загружаем основные данные.
				JurnalDataSet.Clear();
				JurnalDataSet.DataSetName = "journal";
				JurnalMySQL.SelectSqlCommand = "SELECT * FROM journal WHERE (id_journal = " + ActionID + ")";
				if(JurnalMySQL.ExecuteFill(JurnalDataSet, "journal")){
					// загрузка полученной информации
					DataTable _table = JurnalDataSet.Tables["journal"];
					DocID = _table.Rows[0]["journal_id_doc"].ToString();
					textBox1.Text = _table.Rows[0]["journal_number"].ToString();
					dateTimePicker1.Text = _table.Rows[0]["journal_date"].ToString();
					label12.Text = _table.Rows[0]["journal_user_autor"].ToString();
					// информация о продавец
					textBox5.Text = _table.Rows[0]["journal_firm_seller"].ToString();
					textBox4.Text = _table.Rows[0]["journal_firm_seller_details"].ToString();
					// информация о покупателе
					textBox2.Text = _table.Rows[0]["journal_firm_buyer"].ToString();
					textBox3.Text = _table.Rows[0]["journal_firm_buyer_details"].ToString();
					// информация: склад и торг. представитель.
					textBox6.Text = _table.Rows[0]["journal_store"].ToString();
					textBox7.Text = _table.Rows[0]["journal_staff_trade_representative"].ToString();
					// Загрузка информации итогов
					labelSum.Text = ClassConversion.StringToMoney(_table.Rows[0]["journal_sum"].ToString());
					labelNDS.Text = ClassConversion.StringToMoney(_table.Rows[0]["journal_tax"].ToString());
					labelTotal.Text = ClassConversion.StringToMoney(_table.Rows[0]["journal_total"].ToString());
					// Загрузка информации табличной части.
					LoadTabularSection();
					
				} else ClassForms.Rapid_Client.MessageConsole("Заказ: Ошибка загрузки основной информации.", true);
				
				ClassForms.Rapid_Client.MessageConsole("Заказ: Открытие документа для ввода изменений.", false);
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
			textBox7.Clear();
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
				if(table.Rows.Count > 0){
					textBox3.Text = table.Rows[0]["firm_details"].ToString() + System.Environment.NewLine + "Адрес и телефон:" + System.Environment.NewLine + table.Rows[0]["firm_address_phone"].ToString();
					textBox7.Text = table.Rows[0]["firm_trade_representative"].ToString();
				}
			   	
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
			   	if(table.Rows.Count > 0) textBox4.Text = table.Rows[0]["firm_details"].ToString() + System.Environment.NewLine + "Адрес и телефон:" + System.Environment.NewLine + table.Rows[0]["firm_address_phone"].ToString();
			   	
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
		
		void Button13Click(object sender, EventArgs e)
		{
			textBox6.Clear();
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
		
		void Button14Click(object sender, EventArgs e)
		{
			textBox7.Clear();
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
		/* построение отчёта для печати */
		void PrintDocument1PrintPage(object sender, PrintPageEventArgs e)
		{
			// ЗАГОЛОВОК ДОКУМЕНТА: Заказ №  Дата
			e.Graphics.DrawString("ЗАКАЗ № " + textBox1.Text + "   дата: " + dateTimePicker1.Text, new Font("Microsoft Sans Serif", 14, FontStyle.Regular), Brushes.Black, 20, 20);
			// ЧАСТЬ ДОКУМЕНТА: Продавец
			e.Graphics.DrawString("Продавец: " + textBox5.Text, new Font("Microsoft Sans Serif", 12, FontStyle.Regular), Brushes.Black, 20, 60);
			e.Graphics.DrawLine(new Pen(Color.Black), 110, 85, 600, 85);
			e.Graphics.DrawString(textBox4.Text, new Font("Microsoft Sans Serif", 12, FontStyle.Regular), Brushes.Black, 20, 95);
			// ЧАСТЬ ДОКУМЕНТА: Прокупатель
			e.Graphics.DrawString("Покупатель: " + textBox2.Text, new Font("Microsoft Sans Serif", 12, FontStyle.Regular), Brushes.Black, 20, 190);
			e.Graphics.DrawLine(new Pen(Color.Black), 110, 215, 600, 215);
			e.Graphics.DrawString(textBox3.Text, new Font("Microsoft Sans Serif", 12, FontStyle.Regular), Brushes.Black, 20, 225);
			// ЧАСТЬ ДОКУМЕНТА: Склад
			e.Graphics.DrawString("Склад: " + textBox6.Text, new Font("Microsoft Sans Serif", 12, FontStyle.Regular), Brushes.Black, 20, 300);
			// ТАБЛИЧНАЯ ЧАСТЬ: Заголовоки столбцов
			//    Наименование
			e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(0, 340, 200, 25));
			e.Graphics.DrawString("Наименование:", new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 5, 340);
			//    Ед. изм.
			e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(205, 340, 65, 25));
			e.Graphics.DrawString("Ед.изм:", new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 210, 340);
			//    Количество.
			e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(275, 340, 65, 25));
			e.Graphics.DrawString("Кол-во:", new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 280, 340);
			//    Цена.
			e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(345, 340, 100, 25));
			e.Graphics.DrawString("Цена:", new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 350, 340);
			//    НДС.
			e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(450, 340, 100, 25));
			e.Graphics.DrawString("НДС:", new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 455, 340);
			//    Сумма.
			e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(555, 340, 100, 25));
			e.Graphics.DrawString("Сумма:", new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 560, 340);
			// ТАБЛИЧНАЯ ЧАСТЬ: Загрузка данных из таблицы
			int PosY = 340;
			foreach(DataRow row in OrderTS_DataSet.Tables["tabularsection"].Rows)
        	{
				PosY += 30;
				//    Наименование
				e.Graphics.FillRectangle(Brushes.White, new Rectangle(0, PosY, 200, 25));
				e.Graphics.DrawString(row["tabularSection_tmc"].ToString(), new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 5, PosY);
				//    Ед. изм.
				e.Graphics.FillRectangle(Brushes.White, new Rectangle(205, PosY, 65, 25));
				e.Graphics.DrawString(row["tabularSection_units"].ToString(), new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 210, PosY);
				//    Количество.
				e.Graphics.FillRectangle(Brushes.White, new Rectangle(275, PosY, 65, 25));
				e.Graphics.DrawString(row["tabularSection_number"].ToString(), new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 280, PosY);
				//    Цена.
				e.Graphics.FillRectangle(Brushes.White, new Rectangle(345, PosY, 100, 25));
				e.Graphics.DrawString(ClassConversion.StringToMoney(row["tabularSection_price"].ToString()), new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 350, PosY);
				//    НДС.
				e.Graphics.FillRectangle(Brushes.White, new Rectangle(450, PosY, 100, 25));
				e.Graphics.DrawString(ClassConversion.StringToMoney(row["tabularSection_NDS"].ToString()), new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 455, PosY);
				//    Сумма.
				e.Graphics.FillRectangle(Brushes.White, new Rectangle(555, PosY, 100, 25));
				e.Graphics.DrawString(ClassConversion.StringToMoney(row["tabularSection_sum"].ToString()), new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 560, PosY);
			}
			PosY += 30;
			e.Graphics.DrawLine(new Pen(Color.Black), 0, PosY, 650, PosY);
			// ТАБЛИЧНАЯ ЧАСТЬ: Подвал
			//    Итого (по сумме)
			PosY += 15;
			e.Graphics.DrawString("Итого:", new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 455, PosY);
			e.Graphics.DrawString(labelSum.Text, new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 560, PosY);
			//    НДС (по ндс)
			PosY += 30;
			e.Graphics.DrawString("НДС:", new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 455, PosY);
			e.Graphics.DrawString(labelNDS.Text, new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 560, PosY);
			//    Всего
			PosY += 30;
			e.Graphics.DrawString("Всего:", new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 455, PosY);
			e.Graphics.DrawString(labelTotal.Text, new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 560, PosY);
			// ПОДВАЛ ДОКУМЕНТА: торг. пред. и подписи.
			//    Подпись продавца / покупателя
			PosY += 70;
			e.Graphics.DrawLine(new Pen(Color.Black), 20, PosY, 150, PosY);
			e.Graphics.DrawLine(new Pen(Color.Black), 450, PosY, 580, PosY);
			PosY += 5;
			e.Graphics.DrawString("Подпись (продавеца)", new Font("Microsoft Sans Serif", 8, FontStyle.Regular), Brushes.Black, 30, PosY);
			e.Graphics.DrawString("Подпись (покупателя)", new Font("Microsoft Sans Serif", 8, FontStyle.Regular), Brushes.Black, 460, PosY);
			// Торговый представитель
			PosY += 30;
			e.Graphics.DrawString("Заказ оформил (торг. пред.): " + textBox7.Text, new Font("Microsoft Sans Serif", 12, FontStyle.Regular), Brushes.Black, 0, PosY);
		}
		
		void Button12Click(object sender, EventArgs e)
		{
			if(printDialog1.ShowDialog() == DialogResult.OK)
			{
				printDocument1.PrinterSettings = printDialog1.PrinterSettings;
				printDocument1.Print();
			}
		}
		
		void Button17Click(object sender, EventArgs e)
		{
			// просмотр бланка отчета
			PrintPreviewDialog ppd = new PrintPreviewDialog();
			ppd.Document = printDocument1;
			ppd.MdiParent = ClassForms.Rapid_Client;
			ppd.Show();			
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
						// ИСТОРИЯ: Запись в журнал истории обновлений
						ClassServer.SaveUpdateInBase(9, DateTime.Now.ToString(), "", "Изменение записи.", "");
						ClassForms.Rapid_Client.MessageConsole("Полный журнал: успешное создание нового документа Заказ.", false);
						// Закрыть окно
						Close();
					} else ClassForms.Rapid_Client.MessageConsole("Заказ: Ошибка сохранения табличной части.", true);
				} else ClassForms.Rapid_Client.MessageConsole("Заказ: Ошибка сохранения данных о документе в журнале документов.", true);
			}
			
			// При изменении записи
			if(this.Text == "Изменить документ."){
				OrderMySQL.SqlCommand = "UPDATE journal SET journal_date = '" + dateTimePicker1.Text + "', journal_number = '" + textBox1.Text + "', journal_user_autor = '" + ClassConfig.Rapid_Client_UserName + "', journal_store = '" + textBox6.Text + "', journal_firm_buyer = '" + textBox2.Text + "', journal_firm_buyer_details = '" + textBox3.Text + "', journal_firm_seller = '" + textBox5.Text + "', journal_firm_seller_details = '" + textBox4.Text + "', journal_staff_trade_representative = '" + textBox7.Text + "', journal_sum = " + labelSum.Text + ", journal_tax = " + labelNDS.Text + ", journal_total = " + labelTotal.Text + " WHERE (id_journal = " + ActionID + ")";
				if(OrderMySQL.ExecuteNonQuery()){
					if(OrderTS_MySQL.ExecuteUpdate(OrderTS_DataSet, "tabularsection")){
						// ИСТОРИЯ: Запись в журнал истории обновлений
						ClassServer.SaveUpdateInBase(9, DateTime.Now.ToString(), "", "Изменение записи.", "");
						ClassForms.Rapid_Client.MessageConsole("Полный журнал: успешное сохранены изменения документа Заказ.", false);
						// Закрыть окно
						Close();
					} else ClassForms.Rapid_Client.MessageConsole("Заказ: Ошибка сохранения табличной части.", true);
				} else ClassForms.Rapid_Client.MessageConsole("Заказ: Ошибка сохранения данных о документе в журнале документов.", true);
			}
		}
		
		void Button11Click(object sender, EventArgs e)
		{
			SaveDoc(); //сохранение документа.
		}
		/*---------------------------------------------------------*/
		
		
		
		
		
		
	}
}
