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
		
		/* КОНСТАНТЫ ---------------------------------------------------*/
		void ShowConst()
		{
			// Отображение окна констант
			if(!ClassForms.OpenCloseFormConst){
				ClassForms.Rapid_ClientConst = new FormClientConst();
				ClassForms.Rapid_ClientConst.MdiParent = ClassForms.Rapid_Client;
				ClassForms.Rapid_ClientConst.Show();
			}
		}
		
		void КонстантыToolStripMenuItemClick(object sender, EventArgs e)
		{
			ShowConst();
		}
		
		/* ФИРМЫ -------------------------------------------------------*/
		void ShowFirm()
		{
			// Отображение окна фирм
			if(!ClassForms.OpenCloseFormFirms){
				ClassForms.Rapid_ClientFirms = new FormClientFirms();
				ClassForms.Rapid_ClientFirms.MdiParent = ClassForms.Rapid_Client;
				ClassForms.Rapid_ClientFirms.Show();
			}
		}
		
		void ФирмыToolStripMenuItemClick(object sender, EventArgs e)
		{
			ShowFirm();
		}
		
		/* СЕРВЕР: проверка обновления */
		void Timer1Tick(object sender, EventArgs e)
		{
			if(ClassServer.CheckBaseUpdate() == false){
				timer1.Stop();
				if(MessageBox.Show("Связь с сервером потерята, закрыть приложение (ОК) или продолжить?","Сообщение", MessageBoxButtons.OKCancel) == DialogResult.OK){
					Application.Exit();
				} else timer1.Start();
			}
		}
		
		/* ТМЦ ----------------------------------------------------------*/
		void ShowTMC()
		{
			// Отображение окна тмц
			if(!ClassForms.OpenCloseFormTmc){
				ClassForms.Rapid_ClientTmc = new FormClientTmc();
				ClassForms.Rapid_ClientTmc.MdiParent = ClassForms.Rapid_Client;
				ClassForms.Rapid_ClientTmc.Show();
			}
		}
		
		void ТоварToolStripMenuItemClick(object sender, EventArgs e)
		{
			ShowTMC();
		}
		
		/* Склады --------------------------------------------------------*/
		void ShowStore()
		{
			// Отображение окна склады
			if(!ClassForms.OpenCloseFormStore){
				ClassForms.Rapid_ClientStore = new FormClientStore();
				ClassForms.Rapid_ClientStore.MdiParent = ClassForms.Rapid_Client;
				ClassForms.Rapid_ClientStore.Show();
			}
		}
		
		void СкладToolStripMenuItemClick(object sender, EventArgs e)
		{
			ShowStore();
		}
		
		/* Единицы измерения ---------------------------------------------*/
		void ShowUnits()
		{
			if(!ClassForms.OpenCloseFormUnits){
				ClassForms.Rapid_ClientUnits = new FormClientUnits();
				ClassForms.Rapid_ClientUnits.MdiParent = ClassForms.Rapid_Client;
				ClassForms.Rapid_ClientUnits.Show();
			}
		}
		
		void ЕдИзмToolStripMenuItemClick(object sender, EventArgs e)
		{
			ShowUnits();
		}
		
		/* Вид налога --------------------------------------------------*/
		void ShowTypeTax()
		{
			if(!ClassForms.OpenCloseFormTypeTax){
				ClassForms.Rapid_ClientTypeTax = new FormClientTypeTax();
				ClassForms.Rapid_ClientTypeTax.MdiParent = ClassForms.Rapid_Client;
				ClassForms.Rapid_ClientTypeTax.Show();
			}
		}
		
		void ВидНалогаToolStripMenuItemClick(object sender, EventArgs e)
		{
			ShowTypeTax();
		}
		
		/* Сотрудники -------------------------------------------------*/
		void ShowStaff()
		{
			if(!ClassForms.OpenCloseFormStaff){
				ClassForms.Rapid_ClientStaff = new FormClientStaff();
				ClassForms.Rapid_ClientStaff.MdiParent = ClassForms.Rapid_Client;
				ClassForms.Rapid_ClientStaff.Show();
			}
		}
		
		void СотрудникиToolStripMenuItemClick(object sender, EventArgs e)
		{
			ShowStaff();
		}
		
		/* План счетов ------------------------------------------------*/
		void ShowPlanAccounts()
		{
			if(!ClassForms.OpenCloseFormPlanAccounts){
				ClassForms.Rapid_ClientPlanAccounts = new FormClientPlanAccounts();
				ClassForms.Rapid_ClientPlanAccounts.MdiParent = ClassForms.Rapid_Client;
				ClassForms.Rapid_ClientPlanAccounts.Show();
			}
		}
		
		void ПранСчетовToolStripMenuItemClick(object sender, EventArgs e)
		{
			ShowPlanAccounts();
		}
		
		/* документ Заказ --------------------------------------------*/
		void ShowOrder()
		{
			FormClientDocOrder Rapid_ClientDocOrder = new FormClientDocOrder();
			Rapid_ClientDocOrder.MdiParent = ClassForms.Rapid_Client;
			Rapid_ClientDocOrder.Text = "Новая документ.";
			Rapid_ClientDocOrder.Show();
		}
		
		void ЗаказToolStripMenuItemClick(object sender, EventArgs e)
		{
			ShowOrder();
		}
		
		/* документ Приходная накладная ------------------------------*/
		void ShowComing()
		{
			FormClientDocComing Rapid_ClientDocComing = new FormClientDocComing();
			Rapid_ClientDocComing.MdiParent = ClassForms.Rapid_Client;
			Rapid_ClientDocComing.Text = "Новая документ.";
			Rapid_ClientDocComing.Show();
		}
		
		void ПриходнаяНакладнаяToolStripMenuItemClick(object sender, EventArgs e)
		{
			ShowComing();
		}
		
		/* документ Расходная накладная ------------------------------*/
		void ShowExpense()
		{
			FormClientDocExpense Rapid_ClientDocExpense = new FormClientDocExpense();
			Rapid_ClientDocExpense.MdiParent = ClassForms.Rapid_Client;
			Rapid_ClientDocExpense.Text = "Новая документ.";
			Rapid_ClientDocExpense.Show();
		}
		
		void РасходнаяНакладнаяToolStripMenuItemClick(object sender, EventArgs e)
		{
			ShowExpense();
		}
		
		/* журнал: Полный журнал --------------------------------------*/
		void ShowJournalDocs()
		{
			if(!ClassForms.OpenCloseFormJournalDoc){
				ClassForms.Rapid_ClientJournalDoc = new FormClientJournalDoc();
				ClassForms.Rapid_ClientJournalDoc.MdiParent = ClassForms.Rapid_Client;
				ClassForms.Rapid_ClientJournalDoc.Show();
			}
		}
		
		void ПолныйЖурналToolStripMenuItemClick(object sender, EventArgs e)
		{
			ShowJournalDocs();
		}
		
		/* журнал: Заказов ---------------------------------------------*/
		void ShowJournalOrders()
		{
			if(!ClassForms.OpenCloseFormJournalOrder){
				ClassForms.Rapid_ClientJournalOrder = new FormClientJournalOrder();
				ClassForms.Rapid_ClientJournalOrder.MdiParent = ClassForms.Rapid_Client;
				ClassForms.Rapid_ClientJournalOrder.Show();
			}
		}
		
		void ЖурналЗаказовToolStripMenuItemClick(object sender, EventArgs e)
		{
			ShowJournalOrders();
		}
		
		/* журнал: приходных накладных ---------------------------------*/
		void ShowJournalComings()
		{
			if(!ClassForms.OpenCloseFormJournalComing){
				ClassForms.Rapid_ClientJournalComing = new FormClientJournalComing();
				ClassForms.Rapid_ClientJournalComing.MdiParent = ClassForms.Rapid_Client;
				ClassForms.Rapid_ClientJournalComing.Show();
			}
		}
		
		void ЖурналНакладныхToolStripMenuItemClick(object sender, EventArgs e)
		{
			ShowJournalComings();
		}
		
		/* журнал: расходных накладных ---------------------------------*/
		void ShowJournalExpense()
		{
			if(!ClassForms.OpenCloseFormJournalExpense){
				ClassForms.Rapid_ClientJournalExpense = new FormClientJournalExpense();
				ClassForms.Rapid_ClientJournalExpense.MdiParent = ClassForms.Rapid_Client;
				ClassForms.Rapid_ClientJournalExpense.Show();
			}
		}
		
		void ЖурналРасходныхНакладныхToolStripMenuItemClick(object sender, EventArgs e)
		{
			ShowJournalExpense();
		}
		
		/* журнал: бухгалтерские операции -------------------------------*/
		void ShowJournalOperations()
		{
			if(!ClassForms.OpenCloseFormJournalOperations){
				ClassForms.Rapid_ClientJournalOperations = new FormClientJournalOperations();
				ClassForms.Rapid_ClientJournalOperations.MdiParent = ClassForms.Rapid_Client;
				ClassForms.Rapid_ClientJournalOperations.Show();
			}
		}
		
		void БухгалтерскиеОперацииToolStripMenuItemClick(object sender, EventArgs e)
		{
			ShowJournalOperations();
		}
		
		/* калькулятор --------------------------------------------------*/
		void ShowCalc()
		{
			FormServiceCalculator Calc = new FormServiceCalculator(true);
			Calc.valuePaste = false;
			Calc.MdiParent = ClassForms.Rapid_Client;
			Calc.Show();
		}
		
		void КалькуляторToolStripMenuItemClick(object sender, EventArgs e)
		{
			ShowCalc();
		}
		
		/* Открыть текстовый документ ----------------------------------*/
		void ShowOpenFile()
		{
			if(openFileDialog1.ShowDialog() == DialogResult.OK){
				FormNotePad NotePad = new FormNotePad();
				NotePad.MdiParent = ClassForms.Rapid_Client;
				NotePad.pathFile = openFileDialog1.FileName;
				NotePad.richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
				NotePad.Show();
			}
		}
		
		void ОткрытьФайлToolStripMenuItemClick(object sender, EventArgs e)
		{
			ShowOpenFile();
		}
		
		/* Сохранить текстовый документ */
		void SaveFile()
		{
			try{
				ClassForms.NotePad.richTextBox1.SaveFile(ClassForms.NotePad.pathFile, RichTextBoxStreamType.PlainText);
			}catch{
				
			}
		}
		
		void СохранитьФайлToolStripMenuItemClick(object sender, EventArgs e)
		{
			SaveFile();
		}
		
		void ShowSaveFile()
		{
			if(saveFileDialog1.ShowDialog() == DialogResult.OK){
				try{
					ClassForms.NotePad.richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
					ClassForms.NotePad.pathFile = saveFileDialog1.FileName;
				}catch{
					
				}
			}
		}
		
		void СохранитьКакToolStripMenuItemClick(object sender, EventArgs e)
		{
			ShowSaveFile();
		}
		
		void ОтменаToolStripMenuItemClick(object sender, EventArgs e)
		{
			try{
				ClassForms.NotePad.richTextBox1.Undo();
			}catch{
			}
		}
		
		void ПовторToolStripMenuItemClick(object sender, EventArgs e)
		{
			try{
				ClassForms.NotePad.richTextBox1.Redo();
			}catch{
			}
		}
		
		void ВырезатьToolStripMenuItemClick(object sender, EventArgs e)
		{
			try{
				ClassForms.NotePad.richTextBox1.Cut();
			}catch{
			}
		}
		
		void КопироватьToolStripMenuItemClick(object sender, EventArgs e)
		{
			try{
				ClassForms.NotePad.richTextBox1.Copy();
			}catch{
			}
		}
		
		void ВставитьToolStripMenuItemClick(object sender, EventArgs e)
		{
			try{
				ClassForms.NotePad.richTextBox1.Paste();
			}catch{
			}
		}
		
		void УдалитьToolStripMenuItemClick(object sender, EventArgs e)
		{
			try{
				Clipboard.SetDataObject("");
				ClassForms.NotePad.richTextBox1.Paste();
			}catch{
			}
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
		
		/* Оборотная ведомость по торг. представителю */
		void ReportTradeRepresentative()
		{
			FormClientReportTradeRepresentative Rapid_ClientReportTradeRepresentative = new FormClientReportTradeRepresentative();
			Rapid_ClientReportTradeRepresentative.MdiParent = ClassForms.Rapid_Client;
			Rapid_ClientReportTradeRepresentative.Show();
		} 
		
		void ОборотнаяВедомостьПоТоргПредставителюToolStripMenuItemClick(object sender, EventArgs e)
		{
			ReportTradeRepresentative();
		}
		
		/* Оборотная ведомость по поставщику */
		void ReportSupplier()
		{
			FormClientReportSupplier Rapid_ClientReportSupplier = new FormClientReportSupplier();
			Rapid_ClientReportSupplier.MdiParent = ClassForms.Rapid_Client;
			Rapid_ClientReportSupplier.Show();
		}
		
		void ОборотнаяВедомостьПоПоставщикуToolStripMenuItemClick(object sender, EventArgs e)
		{
			ReportSupplier();
		}
		
		/* Оборотная ведомость по покупателю */
		void ReportBuyer()
		{
			FormClientReportBuyer Rapid_ClientReportBuyer = new FormClientReportBuyer();
			Rapid_ClientReportBuyer.MdiParent = ClassForms.Rapid_Client;
			Rapid_ClientReportBuyer.Show();
		}
		
		void ОборотнаяВедомостьПоПокупателюToolStripMenuItemClick(object sender, EventArgs e)
		{
			ReportBuyer();
		}
		
		/* ПАНЕЛЬ ИНСТРУМЕНТОВ -----------------------------------*/
		void ToolStripButton1Click(object sender, EventArgs e)
		{
			ShowOpenFile();
		}
		
		void ToolStripButton2Click(object sender, EventArgs e)
		{
			SaveFile();
		}
		
		void ToolStripButton3Click(object sender, EventArgs e)
		{
			ShowConst();
		}
		
		void ToolStripButton4Click(object sender, EventArgs e)
		{
			ShowFirm();
		}
		
		void ToolStripButton5Click(object sender, EventArgs e)
		{
			ShowTMC();
		}
		
		void ToolStripButton6Click(object sender, EventArgs e)
		{
			ShowStore();
		}
		
		void ToolStripButton7Click(object sender, EventArgs e)
		{
			ShowUnits();
		}
		
		void ToolStripButton8Click(object sender, EventArgs e)
		{
			ShowTypeTax();
		}
		
		void ToolStripButton9Click(object sender, EventArgs e)
		{
			ShowStaff();
		}
		
		void ToolStripButton10Click(object sender, EventArgs e)
		{
			ShowPlanAccounts();
		}
		
		void ToolStripButton11Click(object sender, EventArgs e)
		{
			ShowOrder();
		}
		
		void ToolStripButton12Click(object sender, EventArgs e)
		{
			ShowComing();
		}
		
		void ToolStripButton13Click(object sender, EventArgs e)
		{
			ShowExpense();
		}
		
		void ToolStripButton14Click(object sender, EventArgs e)
		{
			ShowJournalDocs();
		}
		
		void ToolStripButton15Click(object sender, EventArgs e)
		{
			ShowJournalComings();
		}
		
		void ToolStripButton16Click(object sender, EventArgs e)
		{
			ShowJournalExpense();
		}
		
		void ToolStripButton17Click(object sender, EventArgs e)
		{
			ShowJournalOrders();
		}
		
		void ToolStripButton18Click(object sender, EventArgs e)
		{
			ShowJournalOperations();
		}
		
		void ToolStripButton19Click(object sender, EventArgs e)
		{
			ReportBalance();
		}
		
		void ToolStripButton20Click(object sender, EventArgs e)
		{
			ReportAccount();
		}
		
		void ToolStripButton21Click(object sender, EventArgs e)
		{
			ReportTradeRepresentative();
		}
		
		void ToolStripButton22Click(object sender, EventArgs e)
		{
			ReportSupplier();
		}
		
		void ToolStripButton23Click(object sender, EventArgs e)
		{
			ReportBuyer();
		}
		
		void ToolStripButton24Click(object sender, EventArgs e)
		{
			ShowCalc();
		}
		
		void ShowAbout()
		{
			FormAbout Rapid_About = new FormAbout();
			Rapid_About.MdiParent = ClassForms.Rapid_Client;
			Rapid_About.Show();
		}
		
		void ОПрограммеToolStripMenuItemClick(object sender, EventArgs e)
		{
			ShowAbout();
		}
		
		void ToolStripButton25Click(object sender, EventArgs e)
		{
			ShowAbout();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			panel1.Visible = false;
			консольСообщенийToolStripMenuItem.Checked = false;			
		}
	}
}
