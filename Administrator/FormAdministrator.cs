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
	}
}
