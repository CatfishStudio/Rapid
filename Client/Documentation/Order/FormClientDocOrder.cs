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
					
					/*DataGridColumnStyle column;
					column = new DataGridBoolColumn();
					column.MappingName = "tabularSection_tmc";
					column.HeaderText = "Наименование";
					dataGridTableStyle1.GridColumnStyles.Add(column);*/
					
					
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
	}
}
