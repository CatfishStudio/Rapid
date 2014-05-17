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
using Rapid.Service;

namespace Rapid
{
	/// <summary>
	/// Description of FormAdministrator.
	/// </summary>
	public partial class FormAdministrator : Form
	{
		public FormAdministrator()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void CreateConfig()
		{
			ClassForms.Rapid_CreateConfig = new FormAdminCreateConfig();
			ClassForms.Rapid_CreateConfig.MdiParent = ClassForms.Rapid_Administrator;
			ClassForms.Rapid_CreateConfig.Show();
		}
		void СоздатьКонфигурациюToolStripMenuItemClick(object sender, EventArgs e)
		{
			CreateConfig();
		}
		
		void FormAdministratorLoad(object sender, EventArgs e)
		{
			//Запус администратора
			ClassForms.LoadAdministrator = true; // запущен администратор.
			timer1.Start();
		}
		
		void FormAdministratorClosed(object sender, EventArgs e)
		{
			timer1.Stop();
			Application.Exit();	//закрытие приложения
		}
		
		void ShowUsers()
		{
			//Окно редактирования пользователей системы
			if(!ClassForms.OpenCloseFormUser){
				ClassForms.Rapid_Users = new FormAdminUsers();
				ClassForms.Rapid_Users.MdiParent = ClassForms.Rapid_Administrator;
				ClassForms.Rapid_Users.Show();
			}
		}
		
		void ПользователиToolStripMenuItemClick(object sender, EventArgs e)
		{
			ShowUsers();
		}
		
		void Timer1Tick(object sender, EventArgs e)
		{
			if(ClassServer.CheckBaseUpdate() == false){
				timer1.Stop();
				if(MessageBox.Show("Связь с сервером потерята, закрыть приложение (ОК) или продолжить?","Сообщение", MessageBoxButtons.OKCancel) == DialogResult.OK){
					Application.Exit();
				} else timer1.Start();
			}
		}
		
		void ShowQuery()
		{
			FormAdminQuerySQL Rapid_AdminQuerySQL = new FormAdminQuerySQL();
			Rapid_AdminQuerySQL.MdiParent = ClassForms.Rapid_Administrator;
			Rapid_AdminQuerySQL.Show();
		}
		
		void КонструкторЗапросовToolStripMenuItemClick(object sender, EventArgs e)
		{
			ShowQuery();
		}
		
		/* КОНСОЛЬ: отображение сообщений */
		public void MessageConsole(String Message, bool Error, String UserIP)
		{
			if(panel1.Visible == false && Error == true){
				panel1.Visible = true;
				richTextBox1.Text = "ОШИБКА ["+ DateTime.Now.ToString() + "] " + Message + System.Environment.NewLine + richTextBox1.Text;
			}else{
				richTextBox1.Text = "["+ DateTime.Now.ToString() + "] " + Message + "			[IP - " + UserIP + "]" + System.Environment.NewLine + richTextBox1.Text;
			}
		}
		
		void ShowMonitor()
		{
			if(panel1.Visible) panel1.Visible = false;
			else panel1.Visible = true;
		}
		
		void МониторАктивностиToolStripMenuItemClick(object sender, EventArgs e)
		{
			ShowMonitor();
		}
		
		/* Открыть текстовый документ */
		void OpenFile()
		{
			if(openFileDialog1.ShowDialog() == DialogResult.OK){
				FormNotePad NotePad = new FormNotePad();
				NotePad.MdiParent = ClassForms.Rapid_Administrator;
				NotePad.pathFile = openFileDialog1.FileName;
				NotePad.richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
				NotePad.Show();
			}
		}
		void ОткрытьФайлToolStripMenuItemClick(object sender, EventArgs e)
		{
			OpenFile();
		}
		
		/* Сохранить текстовый документ */
		void SaveFile()
		{
			ClassForms.NotePad.richTextBox1.SaveFile(ClassForms.NotePad.pathFile, RichTextBoxStreamType.PlainText);			
		}
		
		void СохранитьФайлToolStripMenuItemClick(object sender, EventArgs e)
		{
			SaveFile();
		}
		
		void СохранитьФайлКакToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(saveFileDialog1.ShowDialog() == DialogResult.OK){
				ClassForms.NotePad.richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
				ClassForms.NotePad.pathFile = saveFileDialog1.FileName;
			}			
		}
		
		void ToolStripButton1Click(object sender, EventArgs e)
		{
			OpenFile();
		}
		
		void ToolStripButton2Click(object sender, EventArgs e)
		{
			SaveFile();
		}
		
		void ToolStripButton3Click(object sender, EventArgs e)
		{
			ShowUsers();
		}
		
		void ToolStripButton4Click(object sender, EventArgs e)
		{
			CreateConfig();
		}
		
		void ToolStripButton5Click(object sender, EventArgs e)
		{
			ShowQuery();
		}
		
		void ToolStripButton6Click(object sender, EventArgs e)
		{
			ShowMonitor();
		}
		
		/* калькулятор --------------------------------------------------*/
		void ShowCalc()
		{
			FormServiceCalculator Calc = new FormServiceCalculator(true);
			Calc.valuePaste = false;
			Calc.MdiParent = ClassForms.Rapid_Administrator;
			Calc.Show();
		}
		
		void КалькуляторToolStripMenuItemClick(object sender, EventArgs e)
		{
			ShowCalc();
		}
		
		void ToolStripButton7Click(object sender, EventArgs e)
		{
			ShowCalc();
		}
		
		void ShowAbout()
		{
			FormAbout Rapid_About = new FormAbout();
			Rapid_About.MdiParent = ClassForms.Rapid_Administrator;
			Rapid_About.Show();
		}
		
		void ОПрограммеToolStripMenuItemClick(object sender, EventArgs e)
		{
			ShowAbout();
		}
		
		void ToolStripButton8Click(object sender, EventArgs e)
		{
			ShowAbout();
		}
		
		/* Окно удаления отмеченных записей в таблице */
		void Removing()
		{
			FormAdminRemoving Rapid_Removing = new FormAdminRemoving();
			Rapid_Removing.MdiParent = ClassForms.Rapid_Administrator;
			Rapid_Removing.Show();
		}
		
		void УдалениеПомеченныхОбъектовToolStripMenuItemClick(object sender, EventArgs e)
		{
			Removing();
		}
		
		void ToolStripButton9Click(object sender, EventArgs e)
		{
			Removing();
		}
	}
}
