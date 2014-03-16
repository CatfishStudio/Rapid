/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 16.03.2014
 * Время: 11:39
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Rapid.Service
{
	/// <summary>
	/// Description of FormNotePad.
	/// </summary>
	public partial class FormNotePad : Form
	{
		public String pathFile;
		public FormNotePad()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void FormNotePadLoad(object sender, EventArgs e)
		{
			
		}
		
		void FormNotePadActivated(object sender, EventArgs e)
		{
			ClassForms.NotePad = this;
		}
	}
}
