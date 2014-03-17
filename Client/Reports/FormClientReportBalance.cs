/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 16.03.2014
 * Время: 15:42
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
	/// Description of FormClientReportBalance.
	/// </summary>
	public partial class FormClientReportBalance : Form
	{
		private ClassMySQL_Full _mySQL = new ClassMySQL_Full();
		private DataSet _dataSet = new DataSet();
			
		public FormClientReportBalance()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void FormClientReportBalanceLoad(object sender, EventArgs e)
		{
			//...
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			Close();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			_dataSet.Clear();
			_dataSet.DataSetName = "balance";
			if(checkBox1.Checked){
				_mySQL.SelectSqlCommand = "SELECT * FROM balance ORDER BY balance_tmc ASC";
			}else _mySQL.SelectSqlCommand = "SELECT * FROM balance WHERE (balance_date BETWEEN '" + dateTimePicker1.Text + "' AND '" + dateTimePicker2.Text + "') ORDER BY balance_tmc ASC";
			if(_mySQL.ExecuteFill(_dataSet, "balance")){
				// ФОРМИРУЕМ ОТЧЁТ
				PrintPreviewDialog ppd = new PrintPreviewDialog();
				ppd.Document = printDocument1;
				ppd.MdiParent = ClassForms.Rapid_Client;
				ppd.Show();	
				
			}else ClassForms.Rapid_Client.MessageConsole("Отчёт Остатки ТМЦ: Ошибка вывода информации.", true);
		}
		
		void PrintDocument1PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			double total = 0;
			// ЗАГОЛОВОК ОТЧЁТА:
			if(checkBox1.Checked){
				e.Graphics.DrawString("Отчёт: остатки ТМЦ.", new Font("Microsoft Sans Serif", 14, FontStyle.Regular), Brushes.Black, 20, 20);
			}else e.Graphics.DrawString("Отчёт: остатки ТМЦ.    с " + dateTimePicker1.Text + " по " + dateTimePicker2.Text, new Font("Microsoft Sans Serif", 14, FontStyle.Regular), Brushes.Black, 20, 20);
			// ТАБЛИЦА
			//    Наименование
			e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(0, 60, 500, 25));
			e.Graphics.DrawString("Наименование:", new Font("Microsoft Sans Serif", 12, FontStyle.Regular), Brushes.Black, 5, 60);
			//    Количество
			e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(505, 60, 120, 25));
			e.Graphics.DrawString("Количество:", new Font("Microsoft Sans Serif", 12, FontStyle.Regular), Brushes.Black, 510, 60);
			
			int PosY = 60;
			foreach(DataRow row in _dataSet.Tables["balance"].Rows)
        	{
				PosY += 30;
				//    Наименование
				e.Graphics.FillRectangle(Brushes.White, new Rectangle(0, PosY, 500, 25));
				e.Graphics.DrawString(row["balance_tmc"].ToString(), new Font("Microsoft Sans Serif", 12, FontStyle.Regular), Brushes.Black, 5, PosY);
				//    Количество
				total = total + ClassConversion.StringToDouble(row["balance_number"].ToString());
				e.Graphics.FillRectangle(Brushes.White, new Rectangle(505, PosY, 120, 25));
				e.Graphics.DrawString(ClassConversion.StringToMoney(row["balance_number"].ToString()), new Font("Microsoft Sans Serif", 12, FontStyle.Regular), Brushes.Black, 510, PosY);
			
			}
			PosY += 30;
			e.Graphics.DrawLine(new Pen(Color.Black), 0, PosY, 650, PosY);
			PosY += 10;
			//    Всего
			e.Graphics.DrawString("Всего:", new Font("Microsoft Sans Serif", 12, FontStyle.Regular), Brushes.Black, 450, PosY);
			//    Общее количество
			e.Graphics.FillRectangle(Brushes.White, new Rectangle(505, PosY, 120, 25));
			e.Graphics.DrawString(ClassConversion.StringToMoney(total.ToString()), new Font("Microsoft Sans Serif", 12, FontStyle.Regular), Brushes.Black, 510, PosY);
			
		}
	}
}
