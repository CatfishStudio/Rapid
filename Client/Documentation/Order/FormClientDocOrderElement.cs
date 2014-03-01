/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 27.02.2014
 * Время: 9:58
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
	/// Description of FormClientDocOrderElement.
	/// </summary>
	public partial class FormClientDocOrderElement : Form
	{
		/* Глобальные переменные */
		public DataSet ParentDataSet;			// родительский объект DataSet
		public int indexLineParentDataSet;		// индекс строки родительского объекта DataSet
		
		public FormClientDocOrderElement()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		/* Закрытие окна*/
		void Button14Click(object sender, EventArgs e)
		{
			Close();
		}
		
		void FormClientDocOrderElementClosed(object sender, EventArgs e)
		{
			ClassForms.Rapid_Client.MessageConsole("Строка заказа: закрыто окно обработки строки табличной части документа Заказ.", false);
		}
		/*----------------------------------------------------------------*/
		
		/* Загрузка окна */
		void FormClientDocOrderElementLoad(object sender, EventArgs e)
		{
			
		}
	}
}
