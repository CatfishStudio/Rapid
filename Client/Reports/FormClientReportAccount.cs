/*
 * Сделано в SharpDevelop.
 * Пользователь: SOMOV
 * Дата: 16.03.2014
 * Время: 21:20
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
	/// Description of FormClientReportAccount.
	/// </summary>
	public partial class FormClientReportAccount : Form
	{
		private ClassMySQL_Full _mySQL = new ClassMySQL_Full();
		private DataSet _dataSet = new DataSet();
		
		public FormClientReportAccount()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void FormClientReportAccountLoad(object sender, EventArgs e)
		{
			//..			
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			Close();
		}
		
		void SelectAccount()
		{
			ClassForms.Rapid_ClientPlanAccounts = new FormClientPlanAccounts();
			ClassForms.Rapid_ClientPlanAccounts.ShowMenuReturnValue();
			ClassForms.Rapid_ClientPlanAccounts.MdiParent = ClassForms.Rapid_Client;
			ClassForms.Rapid_ClientPlanAccounts.TextBoxReturnValue = textBox3;
			ClassForms.Rapid_ClientPlanAccounts.Show();
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			SelectAccount();
		}
		
		void Button4Click(object sender, EventArgs e)
		{
			textBox3.Clear();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			_dataSet.Clear();
			_dataSet.DataSetName = "operations";
			_mySQL.SelectSqlCommand = "SELECT operations.*, journal.* FROM operations, journal WHERE (operations_date BETWEEN '" + dateTimePicker1.Text + "' AND '" + dateTimePicker2.Text + "' AND (operations_DT = " + textBox3.Text + " OR operations_KT = " + textBox3.Text + ") AND (journal.journal_id_doc = operations.operations_id_doc)) ORDER BY operations_date ASC";
			if(_mySQL.ExecuteFill(_dataSet, "operations")){
				// ФОРМИРУЕМ ОТЧЁТ
				PrintPreviewDialog ppd = new PrintPreviewDialog();
				ppd.Document = printDocument1;
				ppd.MdiParent = ClassForms.Rapid_Client;
				ppd.Show();	
			}else ClassForms.Rapid_Client.MessageConsole("Отчёт Оборотная ведомость по счёту: Ошибка вывода информации.", true);
		}
		
		void PrintDocument1PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			double totalDT = 0;
			double totalKT = 0;
			// ЗАГОЛОВОК ОТЧЁТА:
			e.Graphics.DrawString("Оборотная ведомость по счёту №" + textBox3.Text + "    с " + dateTimePicker1.Text + " по " + dateTimePicker2.Text, new Font("Microsoft Sans Serif", 14, FontStyle.Regular), Brushes.Black, 20, 20);
			// ТАБЛИЦА
			//    Дата
			e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(0, 60, 150, 25));
			e.Graphics.DrawString("Дата:", new Font("Microsoft Sans Serif", 12, FontStyle.Regular), Brushes.Black, 5, 60);
			//    Документ
			e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(155, 60, 150, 25));
			e.Graphics.DrawString("Документ:", new Font("Microsoft Sans Serif", 12, FontStyle.Regular), Brushes.Black, 160, 60);
			//    Дебет счёта
			e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(310, 60, 150, 25));
			e.Graphics.DrawString("Дебет:", new Font("Microsoft Sans Serif", 12, FontStyle.Regular), Brushes.Black, 315, 60);
			//    Кредит счёта
			e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(465, 60, 150, 25));
			e.Graphics.DrawString("Кредит:", new Font("Microsoft Sans Serif", 12, FontStyle.Regular), Brushes.Black, 470, 60);
			
			int PosY = 60;
			foreach(DataRow row in _dataSet.Tables["operations"].Rows)
        	{
				PosY += 30;
				//    Дата
				e.Graphics.FillRectangle(Brushes.White, new Rectangle(0, PosY, 150, 25));
				e.Graphics.DrawString(row["operations_date"].ToString(), new Font("Microsoft Sans Serif", 12, FontStyle.Regular), Brushes.Black, 5, PosY);
				//    Документ
				e.Graphics.FillRectangle(Brushes.White, new Rectangle(155, PosY, 150, 25));
				e.Graphics.DrawString(row["journal_number"].ToString(), new Font("Microsoft Sans Serif", 12, FontStyle.Regular), Brushes.Black, 160, PosY);
				//    Дебет счёта
				if(row["operations_DT"].ToString() == textBox3.Text){
					totalDT = totalDT + ClassConversion.StringToDouble(row["operations_sum"].ToString());
					e.Graphics.FillRectangle(Brushes.White, new Rectangle(310, PosY, 150, 25));
					e.Graphics.DrawString(ClassConversion.StringToMoney(row["operations_sum"].ToString()), new Font("Microsoft Sans Serif", 12, FontStyle.Regular), Brushes.Black, 315, PosY);
				}
				//    Кредит счёта
				if(row["operations_KT"].ToString() == textBox3.Text){
					totalKT = totalKT + ClassConversion.StringToDouble(row["operations_sum"].ToString());
					e.Graphics.FillRectangle(Brushes.White, new Rectangle(465, PosY, 150, 25));
					e.Graphics.DrawString(ClassConversion.StringToMoney(row["operations_sum"].ToString()), new Font("Microsoft Sans Serif", 12, FontStyle.Regular), Brushes.Black, 470, PosY);
				}
				
			}
			PosY += 30;
			e.Graphics.DrawLine(new Pen(Color.Black), 0, PosY, 650, PosY);
			PosY += 10;
			//    Всего
			e.Graphics.DrawString("Всего:", new Font("Microsoft Sans Serif", 12, FontStyle.Regular), Brushes.Black, 200, PosY);
			//    Общее количество по дебету
			e.Graphics.DrawString(ClassConversion.StringToMoney(totalDT.ToString()), new Font("Microsoft Sans Serif", 12, FontStyle.Regular), Brushes.Black, 315, PosY);
			//    Общее количество по кредиту
			e.Graphics.DrawString(ClassConversion.StringToMoney(totalKT.ToString()), new Font("Microsoft Sans Serif", 12, FontStyle.Regular), Brushes.Black, 470, PosY);
						
		}
	}
}
