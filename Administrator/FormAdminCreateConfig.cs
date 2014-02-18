/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 23.09.2013
 * Время: 9:32
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Rapid
{
	/// <summary>
	/// Description of FormAdminCreateConfig.
	/// </summary>
	public partial class FormAdminCreateConfig : Form
	{
		public FormAdminCreateConfig()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			Close();	//закрыть окно
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			//Создание конфигурации
			ClassCreateTableInBase CreateTableInBase = new ClassCreateTableInBase();
			CreateTableInBase.Server = textBox1.Text;
			CreateTableInBase.DataBase = textBox2.Text;
			CreateTableInBase.UserID = textBox3.Text;
			CreateTableInBase.Pass = textBox4.Text;
			if(CreateTableInBase.CreateTables()){
				MessageBox.Show("Конфигурация успешно создана.", "Сообщение:");
				Close();
			}else{
				MessageBox.Show("Ошибка!!! Конфигурация не создана.", "Сообщение:");
			}		
		}
	}
}
