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
using Rapid.Client.Firms;

namespace Rapid
{
	/// <summary>
	/// Description of FormClientDocOrder.
	/// </summary>
	public partial class FormClientDocOrder : Form
	{
		/*Глобальные переменные */
		private String DocID = "ORDER:TEST";
		public String ActionID;
		public ClassMySQL_Full OrderMySQL = new ClassMySQL_Full();
		public DataSet OrderDataSet = new DataSet();
		
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
		
		/* ЗАГРУЗКА: Загрузка окна */
		void WindowLoad() // Загрузка окна
		{
			// При создании новой записи
			if(this.Text == "Новая документ."){
				// формируем уникальный идентификатор документа
				//DocID = "ORDER:" + DateTime.Now.ToString();
				// Загружаем информацию из констант
				textBox6.Text = ClassSelectConst.constantValue("Основной склад");
				// Формируем табличную часть
				OrderDataSet.Clear();
				OrderDataSet.DataSetName = "tabularsection";
				OrderMySQL.SelectSqlCommand = "SELECT * FROM tabularsection WHERE (tabularSection_id_doc = '" + DocID + "')";
				if(OrderMySQL.ExecuteFill(OrderDataSet, "tabularsection")){
					// формируем табличную часть
					dataGrid1.DataSource = OrderDataSet.Tables["tabularsection"];
					//dataGrid1.DataMember = "tabularsection";
					
									
					
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
			if(textBox5.Text != "") FirmSellerDataLoad(textBox2.Text); // Загрузка данных			
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
	}
}
