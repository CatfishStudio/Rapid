/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 23.09.2013
 * Время: 11:36
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
	/// Description of FormAdminUsers.
	/// </summary>
	public partial class FormAdminUsers : Form
	{
		
		ClassMySQL_Full _usersMySQL = new ClassMySQL_Full();
		DataSet _usersDataSet = new DataSet();
		
		public FormAdminUsers()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public void TableUpdate(){
			//Загрузка данных в таблицу
			_usersDataSet.Clear();
			_usersDataSet.DataSetName = "users";
			_usersMySQL.SelectSqlCommand = "SELECT * FROM users";
			_usersMySQL.ExecuteFill(_usersDataSet, "users");
						
			DataTable table = _usersDataSet.Tables["users"];
			listView1.Items.Clear();
			foreach(DataRow row in table.Rows)
        	{
				ListViewItem ListViewItem_add = new ListViewItem();
				ListViewItem_add.SubItems.Add(row["user_name"].ToString());
				ListViewItem_add.SubItems.Add(row["user_right"].ToString());
				ListViewItem_add.SubItems.Add(row["id_user"].ToString());
				ListViewItem_add.StateImageIndex = 0;
				listView1.Items.Add(ListViewItem_add);
			}
		}
		
		void FormAdminUsersLoad(object sender, EventArgs e)
		{
			ClassForms.OpenCloseFormUser = true; // форма открыта
			TableUpdate();
		}
		
		void FormAdminUsersClosed(object sender, EventArgs e)
		{
			ClassForms.OpenCloseFormUser = false; // форма закрыта
		}
		
		//public String ActionID;
				
		void ListView1SelectedIndexChanged(object sender, EventArgs e)
		{
			//получаем идентификатор записи в таблице
			if(listView1.SelectedIndices.Count != 0){
				////MessageBox.Show(listView1.Items[listView1.SelectedIndices[0]].SubItems[3].Text.ToString());
			}
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			//Изменить выбранную запись
			if(listView1.SelectedIndices.Count != 0){
				ClassForms.Rapid_UserEdit = new FormAdminUserEdit();
				ClassForms.Rapid_UserEdit.ActionID = listView1.Items[listView1.SelectedIndices[0]].SubItems[3].Text.ToString();
				ClassForms.Rapid_UserEdit.Text = "Редактировать";
				ClassForms.Rapid_UserEdit.MdiParent = ClassForms.Rapid_Administrator;
				ClassForms.Rapid_UserEdit.Show();		
			}
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			//Создать новую запись
			ClassForms.Rapid_UserEdit = new FormAdminUserEdit();
			ClassForms.Rapid_UserEdit.ActionID = "";
			ClassForms.Rapid_UserEdit.Text = "Создать";
			ClassForms.Rapid_UserEdit.MdiParent = ClassForms.Rapid_Administrator;
			ClassForms.Rapid_UserEdit.Show();			
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			//Удалить выбранную запись
			if(MessageBox.Show("Вы уверены в том что хотите удалить выбранную запись?","Вопрос:", MessageBoxButtons.YesNo) == DialogResult.Yes){
				ClassMySQL_Short UsersMySQL = new ClassMySQL_Short();
				UsersMySQL.SqlCommand = "DELETE FROM users WHERE (id_user = " + listView1.Items[listView1.SelectedIndices[0]].SubItems[3].Text.ToString() + ")";
				if (UsersMySQL.ExecuteNonQuery()){ 
					// ИСТОРИЯ: Запись в журнал истории обновлений
					ClassServer.SaveUpdateInBase(1, DateTime.Now.ToString(), "", "Удаление пользователя.", "");
					MessageBox.Show("Запись успешно удалена!");
				}
			}
			
		}
		
		
		
		void Button4Click(object sender, EventArgs e)
		{
			Close();
		}
		
		
	}
}
