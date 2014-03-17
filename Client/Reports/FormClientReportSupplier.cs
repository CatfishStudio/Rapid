/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 17.03.2014
 * Время: 14:24
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Rapid.Client;
using Rapid.Client.Firms;

namespace Rapid
{
	/// <summary>
	/// Description of FormClientReportSupplier.
	/// </summary>
	public partial class FormClientReportSupplier : Form
	{
		private ClassMySQL_Full _mySQL = new ClassMySQL_Full();
		private DataSet _dataSet = new DataSet();
		
		public FormClientReportSupplier()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void FormClientReportSupplierLoad(object sender, EventArgs e)
		{
			//..			
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			Close();
		}
		
		/* Обращение к справочнику "Фирмы" */
		void SelectFirm() // выбрать фирму.
		{
			ClassForms.Rapid_ClientFirms = new FormClientFirms();
			ClassForms.Rapid_ClientFirms.ShowMenuReturnValue();
			ClassForms.Rapid_ClientFirms.MdiParent = ClassForms.Rapid_Client;
			ClassForms.Rapid_ClientFirms.TextBoxReturnValue = textBox3;
			ClassForms.Rapid_ClientFirms.Show();
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			SelectFirm();
		}
		
		void Button4Click(object sender, EventArgs e)
		{
			textBox3.Clear();
		}
		/*------------------------------------------*/
		
		void Button1Click(object sender, EventArgs e)
		{
			_dataSet.Clear();
			_dataSet.DataSetName = "journal";
			_mySQL.SelectSqlCommand = "SELECT * FROM journal WHERE (journal_date BETWEEN '" + dateTimePicker1.Text + "' AND '" + dateTimePicker2.Text + "' AND journal_firm_seller = '" + textBox3.Text + "' AND journal_type = 'Приходная Накладная' AND journal_delete = 0)";
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
			e.Graphics.DrawString("Оборотная ведомость по поставщику: ", new Font("Microsoft Sans Serif", 14, FontStyle.Regular), Brushes.Black, 20, 0);
			e.Graphics.DrawString("наименование: " + textBox3.Text, new Font("Microsoft Sans Serif", 12, FontStyle.Regular), Brushes.Black, 20, 45);
			e.Graphics.DrawString("на период с " + dateTimePicker1.Text + " по " + dateTimePicker2.Text, new Font("Microsoft Sans Serif", 12, FontStyle.Regular), Brushes.Black, 20, 70);
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
