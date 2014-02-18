/*
 * Сделано в SharpDevelop.
 * Пользователь: Сомов Евгений Павлович
 * Дата: 12.09.2013
 * Время: 10:29
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using ADOX;

namespace Rapid
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			timer1.Start();	//запуск таймера
		}
		
		void Timer1Tick(object sender, EventArgs e)
		{
			timer1.Stop();	//остановка таймера
			//определяем расположение программы (путь)
			ClassConfig.Rapid_ProgramPath = Environment.CurrentDirectory + "\\";
			//расположение папки ресурсов
			ClassConfig.Rapid_Resource = ClassConfig.Rapid_ProgramPath + "resource";
			//Проверка существования папки
			if(!Directory.Exists(ClassConfig.Rapid_Resource)){
				//папки нет, она будет создана заново
				Directory.CreateDirectory(ClassConfig.Rapid_Resource);
			}
			//поиск локальной базы данный (список серверов)
			ClassConfig.Rapid_FileListBase = ClassConfig.Rapid_Resource + "\\list.mdb";
			if(!File.Exists(ClassConfig.Rapid_FileListBase)){
				//файл не найден, он будет создан
				ADOX.Catalog ADOXCatalog = new ADOX.Catalog();
				try{
					ADOXCatalog.Create(ClassConfig.ConnectLineBegin + ClassConfig.Rapid_FileListBase + ClassConfig.ConnectLineEnd + ClassConfig.ConnectPass);
					//Создание базы данных и таблицы подключений.
					OleDbConnection OleDb_Connection = new OleDbConnection();
					OleDbCommand OleDb_Command;
					String SQLFullCommand = "";
					String SQLCommand = "";
					
					OleDb_Connection.ConnectionString = ClassConfig.ConnectLineBegin + ClassConfig.Rapid_FileListBase + ClassConfig.ConnectLineEnd + ClassConfig.ConnectPass;
					OleDb_Connection.Open(); //соединение с базой
					//Создаем таблицу
					SQLCommand = "CREATE TABLE ListBase ([ID_ListBase] COUNTER PRIMARY KEY, ";
					SQLFullCommand += SQLCommand;
					SQLCommand = "[Name] VARCHAR DEFAULT " + "\"" + "\"" + ", ";
					SQLFullCommand += SQLCommand;
					SQLCommand = "[Server] VARCHAR DEFAULT " + "\"" + "\"" + ", ";
					SQLFullCommand += SQLCommand;
					SQLCommand = "[DataBase] VARCHAR DEFAULT " + "\"" + "\"" + ", ";
					SQLFullCommand += SQLCommand;
					SQLCommand = "[Uid] VARCHAR DEFAULT " + "\"" + "\"" + ", ";
					SQLFullCommand += SQLCommand;
					SQLCommand = "[Pwd] VARCHAR DEFAULT " + "\"" + "\"" + ", ";
					SQLFullCommand += SQLCommand;
					SQLCommand = "[Admin] VARCHAR DEFAULT " + "\"" + "\"" + ", ";
					SQLFullCommand += SQLCommand;
					SQLCommand = "[Client] VARCHAR DEFAULT " + "\"" + "\"" + ")";
					SQLFullCommand += SQLCommand;
					OleDb_Command = new OleDbCommand(SQLFullCommand, OleDb_Connection);
					OleDb_Command.ExecuteNonQuery();	//выполнение запроса
					//создание первой записи по умолчению для локального сервера
					SQLFullCommand = "INSERT INTO ListBase ([Name], [Server], [DataBase], [Uid], [Pwd], [Admin], [Client]) VALUES ('Информационная база №1', 'localhost', 'rapid', 'root', '', 'http://localhost/rapid.com/Admin/', 'http://localhost/rapid.com')";
					OleDb_Command = new OleDbCommand(SQLFullCommand, OleDb_Connection);
					OleDb_Command.ExecuteNonQuery();	//выполнение запроса
					//отключение соединения
					OleDb_Connection.Close();
				}catch(Exception ex){
					MessageBox.Show(ex.ToString());	//Сообщение об ошибке
					Application.Exit();
				}
			}
			
			
			//--------------------------------------------
			//Открытие окна выбора конфигурации
			ClassForms.Rapid_SelectLoad = new FormSelectLoad();
			ClassForms.Rapid_SelectLoad.Show();
			//--------------------------------------------
			Visible = false;	//главная форма становится невидимой
		}
	}
}
