﻿/*
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
	}
}
