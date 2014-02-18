/*
 * Сделано в SharpDevelop.
 * Пользователь: Сомов Евгений Павлович
 * Дата: 12.09.2013
 * Время: 10:35
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Rapid
{
	/// <summary>
	/// Description of FormSelectLoad.
	/// </summary>
	public partial class FormSelectLoad : Form
	{
		public FormSelectLoad()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		//Глобальные переменные =================================
		public bool ProgramClose = true;//флаг закрытия приложения
		public String SelectBase = "0";	//выбранная конфигурация.
		public OleDbConnection OleDb_Connection = new OleDbConnection();
		public OleDbCommand OleDb_CommandSelect;
		public OleDbCommand OleDb_CommandDelete;
		public OleDbCommand OleDb_CommandUpdate;
		public OleDbCommand OleDb_CommandInsert;
		public OleDbDataAdapter OleDb_DataAdapter1 = new OleDbDataAdapter();
		public System.Data.DataSet DataSet_ListBase = new System.Data.DataSet();
		public System.Data.DataTable DataTable_ListBase = new System.Data.DataTable();
		//=======================================================
		
		//Глобальные процедуры и функции ========================
		public void TreeInitialize(){
			//Подключение локальной базы данных (список серверов)
			try{
			
				OleDb_Connection.ConnectionString = ClassConfig.ConnectLineBegin + ClassConfig.Rapid_FileListBase + ClassConfig.ConnectLineEnd + ClassConfig.ConnectPass;
				OleDb_Connection.Open(); //соединение с базой
			
				//Создание таблицы DataTable
				DataTable_ListBase.Clear();
				DataTable_ListBase.CaseSensitive = false;
				DataTable_ListBase.Columns.Add("Name", Type.GetType("System.String"));
				DataTable_ListBase.Columns.Add("Server", Type.GetType("System.String"));
				DataTable_ListBase.Columns.Add("DataBase", Type.GetType("System.String"));
				DataTable_ListBase.Columns.Add("Uid", Type.GetType("System.String"));
				DataTable_ListBase.Columns.Add("Pwd", Type.GetType("System.String"));
				DataTable_ListBase.Columns.Add("Admin", Type.GetType("System.String"));
				DataTable_ListBase.Columns.Add("Client", Type.GetType("System.String"));
				//Вставка таблицы в DataSet
				DataSet_ListBase.Clear();
				DataSet_ListBase.Tables.Add(DataTable_ListBase);
				DataSet_ListBase.DataSetName = "ListBase";
			
				OleDb_CommandSelect = new OleDbCommand("SELECT * FROM ListBase", OleDb_Connection);
				OleDb_CommandDelete = new OleDbCommand("DELETE FROM ListBase WHERE ([ID_ListBase] = ?) AND (Name = ? OR ? IS NULL AND Name IS NULL) AND (Server = ? OR ? IS NULL AND Server IS NULL) AND (DataBase = ? OR ? IS NULL AND DataBase IS NULL) AND (Uid = ? OR ? IS NULL AND Uid IS NULL) AND (Pwd = ? OR ? IS NULL AND Pwd IS NULL) AND (Admin = ? OR ? IS NULL AND Admin IS NULL) AND (Client = ? OR ? IS NULL AND Client IS NULL)", OleDb_Connection);
				OleDb_CommandUpdate = new OleDbCommand("UPDATE ListBase SET [Name] = ?, [Server] = ?, [DataBase] = ?, [Uid] = ?, [Pwd] = ?, [Admin] = ?, [Client] = ? WHERE ([ID_ListBase] = ?) AND (Name = ? OR ? IS NULL AND Name IS NULL) AND (Server = ? OR ? IS NULL AND Server IS NULL) AND (DataBase = ? OR ? IS NULL AND DataBase IS NULL) AND (Uid = ? OR ? IS NULL AND Uid IS NULL) AND (Pwd = ? OR ? IS NULL AND Pwd IS NULL) AND (Admin = ? OR ? IS NULL AND Admin IS NULL) AND (Client = ? OR ? IS NULL AND Client IS NULL)", OleDb_Connection);
				OleDb_CommandInsert = new OleDbCommand("INSERT INTO ListBase ([Name], [Server], [DataBase], [Uid], [Pwd], [Admin], [Client]) VALUES (?, ?, ?, ?, ?, ?, ?)", OleDb_Connection);
				OleDb_DataAdapter1.SelectCommand = OleDb_CommandSelect;
				OleDb_DataAdapter1.DeleteCommand = OleDb_CommandDelete;
				OleDb_DataAdapter1.UpdateCommand = OleDb_CommandUpdate;
				OleDb_DataAdapter1.InsertCommand = OleDb_CommandInsert;
				OleDb_DataAdapter1.Fill(DataSet_ListBase, "ListBase");
			
				OleDb_Connection.Close();//отключение соединения
			
				// Выгрузка данных
				treeView1.Nodes.Clear();
				treeView1.Nodes.Add("Конфигурации").ImageKey = "folder_close.png";
				treeView1.Nodes[0].SelectedImageKey = "folder_close.png";
				foreach(System.Data.DataTable table in DataSet_ListBase.Tables)
    			{
					foreach(System.Data.DataRow row in table.Rows)
        			{
						treeView1.Nodes[0].Nodes.Add(row[1].ToString()).Tag = row[0].ToString();
					}
   			 	}
			
				
			}catch(Exception ex){
				MessageBox.Show(ex.ToString());	//Сообщение об ошибке
				OleDb_Connection.Close();
				Application.Exit();
			}
		}
		public void TreeDelete(String SelectID){
			int dsCount = DataSet_ListBase.Tables["ListBase"].Rows.Count - 1;
			for (int i = 0; i <= dsCount; i++){
				if(DataSet_ListBase.Tables["ListBase"].Rows[i]["ID_ListBase"].ToString() == SelectID){
					try{
						DataSet_ListBase.Tables["ListBase"].Rows[i].Delete();	//удаление строки из таблицы
						//Удаление выполняется в базе данных
						OleDb_Connection.Open();
						OleDb_DataAdapter1.DeleteCommand.CommandText = "DELETE FROM ListBase WHERE ([ID_ListBase] = " + SelectID + ")";
						OleDb_DataAdapter1.Update(DataSet_ListBase, "ListBase");
						OleDb_Connection.Close();
						MessageBox.Show("Удаление завершено успешно!");
					}catch(Exception ex){
						MessageBox.Show(ex.ToString());	//Сообщение об ошибке
						OleDb_Connection.Close();
						break;
					}
					break;	//завершение цикла
				}
			}
		}
		public void TreeUpdateInit(){
			DataTable_ListBase.Clear();
			DataSet_ListBase.Clear();
			OleDb_Connection.Open(); //соединение с базой
			OleDb_DataAdapter1.Fill(DataSet_ListBase, "ListBase");
			OleDb_Connection.Close();//отключение соединения
			treeView1.Nodes.Clear();
			treeView1.Nodes.Add("Конфигурации").ImageKey = "folder_close.png";
			treeView1.Nodes[0].SelectedImageKey = "folder_close.png";
			foreach(System.Data.DataTable table in DataSet_ListBase.Tables)
    		{
				foreach(System.Data.DataRow row in table.Rows)
        		{
             		treeView1.Nodes[0].Nodes.Add(row[1].ToString()).Tag = row[0].ToString();
				}
   			}
		}
		public void TreeUpdate(String ID_ListBase, String Name, String Server, String DataBase, String Uid, String Pwd, String Admin, String Client){
			int dsCount = DataSet_ListBase.Tables["ListBase"].Rows.Count - 1;
			for (int i = 0; i <= dsCount; i++){
				if(DataSet_ListBase.Tables["ListBase"].Rows[i]["ID_ListBase"].ToString() == ID_ListBase){
					try{
						DataSet_ListBase.Tables["ListBase"].Rows[i]["Name"] = Name;
						DataSet_ListBase.Tables["ListBase"].Rows[i]["Server"] = Server;
						DataSet_ListBase.Tables["ListBase"].Rows[i]["DataBase"] = DataBase;
						DataSet_ListBase.Tables["ListBase"].Rows[i]["Uid"] = Uid;
						DataSet_ListBase.Tables["ListBase"].Rows[i]["Pwd"] = Pwd;
						DataSet_ListBase.Tables["ListBase"].Rows[i]["Admin"] = Admin;
						DataSet_ListBase.Tables["ListBase"].Rows[i]["Client"] = Client;
						
						//Сохранение изменений в базе данных
						OleDb_Connection.Open();
						OleDb_DataAdapter1.UpdateCommand.CommandText = "UPDATE ListBase SET [Name] = '" + Name + "', [Server] = '" + Server + "', [DataBase] = '" + DataBase + "', [Uid] = '" + Uid + "', [Pwd] = '" + Pwd + "', [Admin] = '" + Admin + "', [Client] = '" + Client + "' WHERE ([ID_ListBase] = " + ID_ListBase + ")";
						OleDb_DataAdapter1.Update(DataSet_ListBase, "ListBase");
						OleDb_Connection.Close();
						MessageBox.Show("Сохранение изменений завершено успешно!");
					}catch(Exception ex){
						MessageBox.Show(ex.ToString());	//Сообщение об ошибке
						OleDb_Connection.Close();
						break;
					}
					break;	//завершение цикла
				}
			}
		}
		public void TreeInsert(String Name, String Server, String DataBase, String Uid, String Pwd, String Admin, String Client){
			//Добавление записи в базу данных
			try{
				System.Data.DataTable DT = DataSet_ListBase.Tables["ListBase"];
				System.Data.DataRow row;
				row = DT.NewRow();
				row["Name"] = Name;
				row["Server"] = Server;
				row["DataBase"] = DataBase;
				row["Uid"] = Uid;
				row["Pwd"] = Pwd;
				row["Admin"] = Admin;
				row["Client"] = Client;
				DT.Rows.Add(row);
				OleDb_Connection.Open();
				OleDb_DataAdapter1.InsertCommand.CommandText = "INSERT INTO ListBase ([Name], [Server], [DataBase], [Uid], [Pwd], [Admin], [Client]) VALUES ('" + Name + "', '" + Server + "', '" + DataBase + "', '" + Uid + "', '" + Pwd + "', '" + Admin + "', '" + Client + "')";
				OleDb_DataAdapter1.Update(DataSet_ListBase, "ListBase");
				OleDb_Connection.Close();
				MessageBox.Show("Сохранение новой записи прошло успешно!");
			}catch(Exception ex){
				MessageBox.Show(ex.ToString());	//Сообщение об ошибке
				OleDb_Connection.Close();
			}
		}
		//=======================================================
		
		void Button5Click(object sender, EventArgs e)
		{
			Application.Exit();	//выход из программы
		}
		
		void FormSelectLoadLoad(object sender, EventArgs e)
		{
			TreeInitialize();	//загрузка данных из базы данных
		}
		
		void FormSelectLoadClosed(object sender, EventArgs e)
		{
			if(ProgramClose){
				Application.Exit();	//выход из программы
			}
		}
		
		void TreeView1AfterSelect(object sender, TreeViewEventArgs e)
		{
			//Идентификатор выбранной записи в базе данных
			if(treeView1.SelectedNode.Text != "Конфигурации")
				SelectBase = treeView1.SelectedNode.Tag.ToString();
			
		}
		
		/* ЗАПУСК КОНФИГУРАЦИИ */
		void LoadConfiguration()
		{
			if(treeView1.SelectedNode.Text == "Конфигурации"){
				MessageBox.Show("Пожалуйста выберите конфигурацию для загрузки.");
			}else{
				//Загрузка конфигурации (Администратор / Клиент)
				int dsCount = DataSet_ListBase.Tables["ListBase"].Rows.Count - 1;
				for (int i = 0; i <= dsCount; i++){
					if(DataSet_ListBase.Tables["ListBase"].Rows[i]["ID_ListBase"].ToString() == SelectBase){
						ClassConfig.Rapid_Run_Type = comboBox1.Text;
						ClassConfig.Rapid_Run_Name = DataSet_ListBase.Tables["ListBase"].Rows[i]["Name"].ToString();
						ClassConfig.Rapid_Run_Server = DataSet_ListBase.Tables["ListBase"].Rows[i]["Server"].ToString();
						ClassConfig.Rapid_Run_DataBase = DataSet_ListBase.Tables["ListBase"].Rows[i]["DataBase"].ToString();
						ClassConfig.Rapid_Run_Uid = DataSet_ListBase.Tables["ListBase"].Rows[i]["Uid"].ToString();
						ClassConfig.Rapid_Run_Pwd = DataSet_ListBase.Tables["ListBase"].Rows[i]["Pwd"].ToString();
						ClassConfig.Rapid_Run_Admin = DataSet_ListBase.Tables["ListBase"].Rows[i]["Admin"].ToString();
						ClassConfig.Rapid_Run_Client = DataSet_ListBase.Tables["ListBase"].Rows[i]["Client"].ToString();
						ClassForms.Rapid_SelectUser = new FormSelectUser();
						ClassForms.Rapid_SelectUser.Show();
						ProgramClose = false;
						this.Close();
						break;
					}
				}
			}
		}
		void Button1Click(object sender, EventArgs e)
		{
			LoadConfiguration(); // запуск конфигурации.
		}
		
		/* Удаление записи о конфигурации */
		void DeleteRecord()
		{
			//Удаление выбранной записи в локальной базе данных
			if(treeView1.SelectedNode.Text == "Конфигурации"){
				MessageBox.Show("Папку [Конфигурации] удалить нельзя.");
			}else{
				if(MessageBox.Show("Удалить выбранную запись?", "Вопрос:", MessageBoxButtons.YesNo) == DialogResult.Yes){
					TreeDelete(SelectBase);	//выполнение удаления ихвормации из базы данных
					TreeUpdateInit();	//обновление дерева конфигураций
				}
			}
		}
		void Button4Click(object sender, EventArgs e)
		{
			DeleteRecord(); // удаление записи
		}
		
		/* Добавить новую информацию о конфигурации */
		void AddRecords()
		{
			//Добавить новую запись
			ClassForms.Rapid_EditListConnect = new FormEditListConnect();
			ClassForms.Rapid_EditListConnect.Text = "Добавить запись";
			ClassForms.Rapid_EditListConnect.ShowDialog();
		}
		void Button2Click(object sender, EventArgs e)
		{
			AddRecords(); // добавить новую запись.
		}
		
		/* Изменить информацию об конфигурации */
		void EditRecords()
		{
			//Изменить выбранную запись
			if(treeView1.SelectedNode.Text == "Конфигурации"){
				MessageBox.Show("Папку [Конфигурации] редактировать нельзя.");
			}else{
				int dsCount = DataSet_ListBase.Tables["ListBase"].Rows.Count - 1;
				for (int i = 0; i <= dsCount; i++){
					if(DataSet_ListBase.Tables["ListBase"].Rows[i]["ID_ListBase"].ToString() == SelectBase){
						ClassForms.Rapid_EditListConnect = new FormEditListConnect();
						ClassForms.Rapid_EditListConnect.Text = "Изменить запись";
						ClassForms.Rapid_EditListConnect.SelectBase = SelectBase;
						ClassForms.Rapid_EditListConnect.textBox1.Text = DataSet_ListBase.Tables["ListBase"].Rows[i]["Name"].ToString();
						ClassForms.Rapid_EditListConnect.textBox2.Text = DataSet_ListBase.Tables["ListBase"].Rows[i]["Server"].ToString();
						ClassForms.Rapid_EditListConnect.textBox3.Text = DataSet_ListBase.Tables["ListBase"].Rows[i]["DataBase"].ToString();
						ClassForms.Rapid_EditListConnect.textBox4.Text = DataSet_ListBase.Tables["ListBase"].Rows[i]["Uid"].ToString();
						ClassForms.Rapid_EditListConnect.textBox5.Text = DataSet_ListBase.Tables["ListBase"].Rows[i]["Pwd"].ToString();
						ClassForms.Rapid_EditListConnect.textBox6.Text = DataSet_ListBase.Tables["ListBase"].Rows[i]["Admin"].ToString();
						ClassForms.Rapid_EditListConnect.textBox7.Text = DataSet_ListBase.Tables["ListBase"].Rows[i]["Client"].ToString();
						ClassForms.Rapid_EditListConnect.ShowDialog();
						break;
					}
				}
			}
		}
		void Button3Click(object sender, EventArgs e)
		{
			EditRecords(); // Изменить запись.
		}
	}
}
