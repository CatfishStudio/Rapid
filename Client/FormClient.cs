/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 16.09.2013
 * Время: 9:58
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using Rapid.Client.Firms;
using Rapid.Service;

namespace Rapid
{
	/// <summary>
	/// Description of FormClient.
	/// </summary>
	public partial class FormClient : Form
	{
		public FormClient()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		/* ЗАКРЫТЬ КЛИЕНТ*/
		void ВыходToolStripMenuItemClick(object sender, EventArgs e)
		{
			Close(); //выход из программы.
		}
		
		/* ЗАПУСК КЛИЕНТА */
		void FormClientLoad(object sender, EventArgs e)
		{
			//при запуске клиента
			MessageConsole("Клиент: запущен! (пользователь: '" + ClassConfig.Rapid_Client_UserName + "'); (права: '" + ClassConfig.Rapid_Client_UserRight + "');", false);			
			timer1.Start();
		}
		
		/* ВЫХОД ИЗ ПРОГРАММЫ */
		void FormClientClosed(object sender, EventArgs e)
		{
			timer1.Stop();
			Application.Exit();	//закрытие приложения
		}
		
		/*ПАНЕЛЬ ИНСТРУМЕНТОВ */
		void ПанельИнструментовToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(панельИнструментовToolStripMenuItem.Checked == true){
				панельИнструментовToolStripMenuItem.Checked = false;
				toolStrip1.Visible = false;
			}else{
				панельИнструментовToolStripMenuItem.Checked = true;
				toolStrip1.Visible = true;
			}
		}
		
		/* КОНСОЛЬ: открытие */
		void КонсольСообщенийToolStripMenuItemClick(object sender, EventArgs e)
		{
			//управление окном консоль
			if(panel1.Visible){
				panel1.Visible = false;
				консольСообщенийToolStripMenuItem.Checked = false;
			}else{
				panel1.Visible = true;
				консольСообщенийToolStripMenuItem.Checked = true;
			}
		}
		
		/* КОНСОЛЬ: отображение сообщений */
		public void MessageConsole(String Message, bool Error)
		{
			if(panel1.Visible == false && Error == true){
				panel1.Visible = true;
				консольСообщенийToolStripMenuItem.Checked = true;
				richTextBox1.Text = "ОШИБКА ["+ DateTime.Now.ToString() + "] " + Message + System.Environment.NewLine + richTextBox1.Text;
			}else{
				richTextBox1.Text = "["+ DateTime.Now.ToString() + "] " + Message + System.Environment.NewLine + richTextBox1.Text;
			}
		}
		
		/* КОНСТАНТЫ */
		void КонстантыToolStripMenuItemClick(object sender, EventArgs e)
		{
			// Отображение окна констант
			if(!ClassForms.OpenCloseFormConst){
				ClassForms.Rapid_ClientConst = new FormClientConst();
				ClassForms.Rapid_ClientConst.MdiParent = ClassForms.Rapid_Client;
				ClassForms.Rapid_ClientConst.Show();
			}
		}
		
		/* ФИРМЫ */
		void ФирмыToolStripMenuItemClick(object sender, EventArgs e)
		{
			// Отображение окна фирм
			if(!ClassForms.OpenCloseFormFirms){
				ClassForms.Rapid_ClientFirms = new FormClientFirms();
				ClassForms.Rapid_ClientFirms.MdiParent = ClassForms.Rapid_Client;
				ClassForms.Rapid_ClientFirms.Show();
			}
		}
		
		/* СЕРВЕР: проверка обновления */
		void Timer1Tick(object sender, EventArgs e)
		{
			ClassServer.CheckBaseUpdate();
		}
		
		/* ТМЦ */
		void ТоварToolStripMenuItemClick(object sender, EventArgs e)
		{
			// Отображение окна тмц
			if(!ClassForms.OpenCloseFormTmc){
				ClassForms.Rapid_ClientTmc = new FormClientTmc();
				ClassForms.Rapid_ClientTmc.MdiParent = ClassForms.Rapid_Client;
				ClassForms.Rapid_ClientTmc.Show();
			}
		}
		
		/* Склады */
		void СкладToolStripMenuItemClick(object sender, EventArgs e)
		{
			// Отображение окна склады
			if(!ClassForms.OpenCloseFormStore){
				ClassForms.Rapid_ClientStore = new FormClientStore();
				ClassForms.Rapid_ClientStore.MdiParent = ClassForms.Rapid_Client;
				ClassForms.Rapid_ClientStore.Show();
			}
		}
		
		/* Единицы измерения */
		void ЕдИзмToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(!ClassForms.OpenCloseFormUnits){
				ClassForms.Rapid_ClientUnits = new FormClientUnits();
				ClassForms.Rapid_ClientUnits.MdiParent = ClassForms.Rapid_Client;
				ClassForms.Rapid_ClientUnits.Show();
			}
		}
		
		/* Вид налога */
		void ВидНалогаToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(!ClassForms.OpenCloseFormTypeTax){
				ClassForms.Rapid_ClientTypeTax = new FormClientTypeTax();
				ClassForms.Rapid_ClientTypeTax.MdiParent = ClassForms.Rapid_Client;
				ClassForms.Rapid_ClientTypeTax.Show();
			}
		}
		
		/* Сотрудники */
		void СотрудникиToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(!ClassForms.OpenCloseFormStaff){
				ClassForms.Rapid_ClientStaff = new FormClientStaff();
				ClassForms.Rapid_ClientStaff.MdiParent = ClassForms.Rapid_Client;
				ClassForms.Rapid_ClientStaff.Show();
			}
		}
		
		/* План счетов */
		void ПранСчетовToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(!ClassForms.OpenCloseFormPlanAccounts){
				ClassForms.Rapid_ClientPlanAccounts = new FormClientPlanAccounts();
				ClassForms.Rapid_ClientPlanAccounts.MdiParent = ClassForms.Rapid_Client;
				ClassForms.Rapid_ClientPlanAccounts.Show();
			}
		}
		
		/* документ Заказ */
		void ЗаказToolStripMenuItemClick(object sender, EventArgs e)
		{
			FormClientDocOrder Rapid_ClientDocOrder = new FormClientDocOrder();
			Rapid_ClientDocOrder.MdiParent = ClassForms.Rapid_Client;
			Rapid_ClientDocOrder.Text = "Новая документ.";
			Rapid_ClientDocOrder.Show();
		}
		
		/* документ Приходная накладная */
		void ПриходнаяНакладнаяToolStripMenuItemClick(object sender, EventArgs e)
		{
			FormClientDocComing Rapid_ClientDocComing = new FormClientDocComing();
			Rapid_ClientDocComing.MdiParent = ClassForms.Rapid_Client;
			Rapid_ClientDocComing.Text = "Новая документ.";
			Rapid_ClientDocComing.Show();
		}
		
		/* документ Расходная накладная */
		void РасходнаяНакладнаяToolStripMenuItemClick(object sender, EventArgs e)
		{
			FormClientDocExpense Rapid_ClientDocExpense = new FormClientDocExpense();
			Rapid_ClientDocExpense.MdiParent = ClassForms.Rapid_Client;
			Rapid_ClientDocExpense.Text = "Новая документ.";
			Rapid_ClientDocExpense.Show();
		}
		
		/* журнал: Полный журнал */
		void ПолныйЖурналToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(!ClassForms.OpenCloseFormJournalDoc){
				ClassForms.Rapid_ClientJournalDoc = new FormClientJournalDoc();
				ClassForms.Rapid_ClientJournalDoc.MdiParent = ClassForms.Rapid_Client;
				ClassForms.Rapid_ClientJournalDoc.Show();
			}
		}
		
		/* журнал: Заказов */
		void ЖурналЗаказовToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(!ClassForms.OpenCloseFormJournalOrder){
				ClassForms.Rapid_ClientJournalOrder = new FormClientJournalOrder();
				ClassForms.Rapid_ClientJournalOrder.MdiParent = ClassForms.Rapid_Client;
				ClassForms.Rapid_ClientJournalOrder.Show();
			}
		}
		
		/* журнал: приходных накладных */
		void ЖурналНакладныхToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(!ClassForms.OpenCloseFormJournalComing){
				ClassForms.Rapid_ClientJournalComing = new FormClientJournalComing();
				ClassForms.Rapid_ClientJournalComing.MdiParent = ClassForms.Rapid_Client;
				ClassForms.Rapid_ClientJournalComing.Show();
			}
		}
		
		/* журнал: расходных накладных */
		void ЖурналРасходныхНакладныхToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(!ClassForms.OpenCloseFormJournalExpense){
				ClassForms.Rapid_ClientJournalExpense = new FormClientJournalExpense();
				ClassForms.Rapid_ClientJournalExpense.MdiParent = ClassForms.Rapid_Client;
				ClassForms.Rapid_ClientJournalExpense.Show();
			}
		}
		
		/* журнал: бухгалтерские операции*/
		void БухгалтерскиеОперацииToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(!ClassForms.OpenCloseFormJournalOperations){
				ClassForms.Rapid_ClientJournalOperations = new FormClientJournalOperations();
				ClassForms.Rapid_ClientJournalOperations.MdiParent = ClassForms.Rapid_Client;
				ClassForms.Rapid_ClientJournalOperations.Show();
			}
		}
		
		/* калькулятор */
		void КалькуляторToolStripMenuItemClick(object sender, EventArgs e)
		{
			FormServiceCalculator Calc = new FormServiceCalculator(true);
			Calc.valuePaste = false;
			Calc.MdiParent = ClassForms.Rapid_Client;
			Calc.Show();
		}
		
		/* Открыть текстовый документ */
		void ОткрытьФайлToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(openFileDialog1.ShowDialog() == DialogResult.OK){
				FormNotePad NotePad = new FormNotePad();
				NotePad.MdiParent = ClassForms.Rapid_Client;
				NotePad.pathFile = openFileDialog1.FileName;
				NotePad.richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
				NotePad.Show();
			}
		}
		
		/* Сохранить текстовый документ */
		void СохранитьФайлToolStripMenuItemClick(object sender, EventArgs e)
		{
			ClassForms.NotePad.richTextBox1.SaveFile(ClassForms.NotePad.pathFile, RichTextBoxStreamType.PlainText);
		}
		
		void СохранитьКакToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(saveFileDialog1.ShowDialog() == DialogResult.OK){
				ClassForms.NotePad.richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
				ClassForms.NotePad.pathFile = saveFileDialog1.FileName;
			}
		}
		
		void ОтменаToolStripMenuItemClick(object sender, EventArgs e)
		{
			ClassForms.NotePad.richTextBox1.Undo();
		}
		
		void ПовторToolStripMenuItemClick(object sender, EventArgs e)
		{
			ClassForms.NotePad.richTextBox1.Redo();
		}
		
		void ВырезатьToolStripMenuItemClick(object sender, EventArgs e)
		{
			ClassForms.NotePad.richTextBox1.Cut();
		}
		
		void КопироватьToolStripMenuItemClick(object sender, EventArgs e)
		{
			ClassForms.NotePad.richTextBox1.Copy();
		}
		
		void ВставитьToolStripMenuItemClick(object sender, EventArgs e)
		{
			ClassForms.NotePad.richTextBox1.Paste();
		}
		
		void УдалитьToolStripMenuItemClick(object sender, EventArgs e)
		{
			Clipboard.SetDataObject("");
			ClassForms.NotePad.richTextBox1.Paste();
		}
		/* -------------------------------------------------------------------- */
		
		/* ОТЧЁТЫ ------------------------------------------------------------- */
		/* Остатки ТМЦ */
		void ReportBalance()
		{
			FormClientReportBalance Rapid_ClientReportBalance = new FormClientReportBalance();
			Rapid_ClientReportBalance.MdiParent = ClassForms.Rapid_Client;
			Rapid_ClientReportBalance.Show();
		}
		
		void ОстаткиТМЦToolStripMenuItemClick(object sender, EventArgs e)
		{
			ReportBalance();
		}
		
		/* Оборотная ведомость по счёту */
		void ReportAccount()
		{
			FormClientReportAccount Rapid_ClientReportAccount = new FormClientReportAccount();
			Rapid_ClientReportAccount.MdiParent = ClassForms.Rapid_Client;
			Rapid_ClientReportAccount.Show();
		}
		
		void ОтчетПоСчетуToolStripMenuItemClick(object sender, EventArgs e)
		{
			ReportAccount();
		}
	}
}
