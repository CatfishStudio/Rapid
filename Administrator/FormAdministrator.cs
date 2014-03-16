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
		
		void СоздатьКонфигурациюToolStripMenuItemClick(object sender, EventArgs e)
		{
			ClassForms.Rapid_CreateConfig = new FormAdminCreateConfig();
			ClassForms.Rapid_CreateConfig.MdiParent = ClassForms.Rapid_Administrator;
			ClassForms.Rapid_CreateConfig.Show();
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
		
		void ПользователиToolStripMenuItemClick(object sender, EventArgs e)
		{
			//Окно редактирования пользователей системы
			if(!ClassForms.OpenCloseFormUser){
				ClassForms.Rapid_Users = new FormAdminUsers();
				ClassForms.Rapid_Users.MdiParent = ClassForms.Rapid_Administrator;
				ClassForms.Rapid_Users.Show();
			}
		}
		
		void Timer1Tick(object sender, EventArgs e)
		{
			ClassServer.CheckBaseUpdate();
		}
		
		void КонструкторЗапросовToolStripMenuItemClick(object sender, EventArgs e)
		{
			FormAdminQuerySQL Rapid_AdminQuerySQL = new FormAdminQuerySQL();
			Rapid_AdminQuerySQL.MdiParent = ClassForms.Rapid_Administrator;
			Rapid_AdminQuerySQL.Show();
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
		
		void МониторАктивностиToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(panel1.Visible) panel1.Visible = false;
			else panel1.Visible = true;
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
		
		void СохранитьФайлКакToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(saveFileDialog1.ShowDialog() == DialogResult.OK){
				ClassForms.NotePad.richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
				ClassForms.NotePad.pathFile = saveFileDialog1.FileName;
			}			
		}
	}
}
