/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 26.09.2013
 * Время: 19:26
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace Rapid
{
	/// <summary>
	/// Description of FormAdminUserEdit.
	/// </summary>
	public partial class FormAdminUserEdit : Form
	{
		public FormAdminUserEdit()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public String ActionID;
		
		void FormAdminUserEditLoad(object sender, EventArgs e)
		{
			//Создание новой записи
			if(this.Text == "Создать"){
				//...
			}

			//Изменение записи	
			if(this.Text == "Редактировать"){
				// Загрузка данных из базы данных
				ClassMySQL_Full UsersMySQL = new ClassMySQL_Full();
				DataSet UsersDataSet = new DataSet();
				UsersDataSet.Clear();
				UsersDataSet.DataSetName = "users";
				UsersMySQL.SelectSqlCommand = "SELECT * FROM users WHERE (id_user = " + ActionID + ")";
				UsersMySQL.ExecuteFill(UsersDataSet, "users");
				
				DataTable table = UsersDataSet.Tables["users"];
				DataRow row = table.Rows[0];
				textBox1.Text = row["user_name"].ToString();
				comboBox1.Text = row["user_right"].ToString();
				textBox2.Text = row["user_pass"].ToString();
				textBox3.Text = textBox2.Text;
				richTextBox1.Text = row["user_additionally"].ToString();
			}			
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			//Закрыть окно
			Close();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			//СОХРАНЕНИЕ ДАННЫХ
			//Создание новой записи
			if(this.Text == "Создать"){
				ClassMySQL_Short UsersMySQL = new ClassMySQL_Short();
				UsersMySQL.SqlCommand = "INSERT INTO users (user_name, user_pass, user_right, user_additionally) VALUES ('"+ textBox1.Text +"', '"+ textBox2.Text +"', '"+ comboBox1.Text +"', '"+ richTextBox1.Text +"') ";
				if (UsersMySQL.ExecuteNonQuery()){
					// ИСТОРИЯ: Запись в журнал истории обновлений
					ClassServer.SaveUpdateInBase(1, DateTime.Now.ToString(), "", "Создан новый пользователь.", "");
					Close();
				}
				
			}

			//Изменение записи	
			if(this.Text == "Редактировать"){
				ClassMySQL_Short UsersMySQL = new ClassMySQL_Short();
				UsersMySQL.SqlCommand = "UPDATE users SET user_name = '" + textBox1.Text + "', user_pass = '" + textBox2.Text+ "', user_right = '" + comboBox1.Text + "', user_additionally = '" + richTextBox1.Text + "' WHERE (id_user = " + ActionID + ")";
				if (UsersMySQL.ExecuteNonQuery()){
					// ИСТОРИЯ: Запись в журнал истории обновлений
					ClassServer.SaveUpdateInBase(1, DateTime.Now.ToString(), "", "Изменения пользователя.", "");
					Close();
				}
			}				
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			textBox1.Clear(); // очистка.
		}
	}
}
