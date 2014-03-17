/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 17.03.2014
 * Время: 9:43
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
	/// Description of FormClientReportTradeRepresentative.
	/// </summary>
	public partial class FormClientReportTradeRepresentative : Form
	{
		private ClassMySQL_Full _mySQL = new ClassMySQL_Full();
		private DataSet _dataSet = new DataSet();
		
		public FormClientReportTradeRepresentative()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void FormClientReportTradeRepresentativeLoad(object sender, EventArgs e)
		{
			//..			
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			Close();
		}
		
		/* Обращение к справочнику "Сотрудник" */
		void SelectStaff() // выбрать сотрудник.
		{
			ClassForms.Rapid_ClientStaff = new FormClientStaff();
			ClassForms.Rapid_ClientStaff.ShowMenuReturnValue();
			ClassForms.Rapid_ClientStaff.MdiParent = ClassForms.Rapid_Client;
			ClassForms.Rapid_ClientStaff.TextBoxReturnValue = textBox3;
			ClassForms.Rapid_ClientStaff.Show();
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			SelectStaff();
		}
		
		void Button4Click(object sender, EventArgs e)
		{
			textBox3.Clear();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			_dataSet.Clear();
			_dataSet.DataSetName = "journal";
			_mySQL.SelectSqlCommand = "SELECT * FROM journal WHERE (journal_date BETWEEN '" + dateTimePicker1.Text + "' AND '" + dateTimePicker2.Text + "' AND journal_staff_trade_representative = '" + textBox3.Text + "' AND journal_type = 'Расходная Накладная' AND journal_delete = 0)";
			if(_mySQL.ExecuteFill(_dataSet, "journal")){
				// ФОРМИРУЕМ ОТЧЁТ
				PrintPreviewDialog ppd = new PrintPreviewDialog();
				ppd.Document = printDocument1;
				ppd.MdiParent = ClassForms.Rapid_Client;
				ppd.Show();	
			}else ClassForms.Rapid_Client.MessageConsole("Отчёт Оборотная ведомость по торг. представителю: Ошибка вывода информации.", true);
		}
		
		void PrintDocument1PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			double total = 0;
			// ЗАГОЛОВОК ОТЧЁТА:
			e.Graphics.DrawString("Оборотная ведомость по торговому представителю: ", new Font("Microsoft Sans Serif", 14, FontStyle.Regular), Brushes.Black, 20, 20);
			e.Graphics.DrawString(textBox3.Text, new Font("Microsoft Sans Serif", 12, FontStyle.Regular), Brushes.Black, 35, 45);
			e.Graphics.DrawString("на период с " + dateTimePicker1.Text + " по " + dateTimePicker2.Text, new Font("Microsoft Sans Serif", 12, FontStyle.Regular), Brushes.Black, 35, 70);
			// ТАБЛИЦА
			
			//    Дата
			e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(0, 100, 150, 25));
			e.Graphics.DrawString("Дата:", new Font("Microsoft Sans Serif", 12, FontStyle.Regular), Brushes.Black, 5, 100);
			//    Документ
			e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(155, 100, 300, 25));
			e.Graphics.DrawString("Документ:", new Font("Microsoft Sans Serif", 12, FontStyle.Regular), Brushes.Black, 160, 100);
			//    Сумма
			e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(460, 100, 150, 25));
			e.Graphics.DrawString("Сумма:", new Font("Microsoft Sans Serif", 12, FontStyle.Regular), Brushes.Black, 465, 100);
			
			int PosY = 100;
			foreach(DataRow row in _dataSet.Tables["journal"].Rows)
        	{
				PosY += 30;
				//    Дата
				e.Graphics.FillRectangle(Brushes.White, new Rectangle(0, PosY, 150, 25));
				e.Graphics.DrawString(row["journal_date"].ToString(), new Font("Microsoft Sans Serif", 12, FontStyle.Regular), Brushes.Black, 5, PosY);
				//    Документ
				e.Graphics.FillRectangle(Brushes.White, new Rectangle(155, PosY, 300, 25));
				e.Graphics.DrawString(row["journal_number"].ToString(), new Font("Microsoft Sans Serif", 12, FontStyle.Regular), Brushes.Black, 160, PosY);
				//    Сумма
				total = total + ClassConversion.StringToDouble(row["journal_total"].ToString());
				e.Graphics.FillRectangle(Brushes.White, new Rectangle(460, PosY, 150, 25));
				e.Graphics.DrawString(ClassConversion.StringToMoney(row["journal_total"].ToString()), new Font("Microsoft Sans Serif", 12, FontStyle.Regular), Brushes.Black, 465, PosY);
			}
			PosY += 30;
			e.Graphics.DrawLine(new Pen(Color.Black), 0, PosY, 650, PosY);
			PosY += 10;
			//    Всего
			e.Graphics.DrawString("Всего:", new Font("Microsoft Sans Serif", 12, FontStyle.Regular), Brushes.Black, 400, PosY);
			e.Graphics.DrawString(ClassConversion.StringToMoney(total.ToString()), new Font("Microsoft Sans Serif", 12, FontStyle.Regular), Brushes.Black, 465, PosY);
		}
	}
}
