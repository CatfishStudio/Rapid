/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 21.09.2013
 * Время: 9:22
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Rapid
{
	/// <summary>
	/// Description of ClassCreateTableInBase.
	/// </summary>
	public class ClassCreateTableInBase
	{
		//конструктор -----------------
		public ClassCreateTableInBase()
		{
			_MySql_Connection = new MySqlConnection();
			_MySql_Command = new MySqlCommand("", _MySql_Connection);
		}
		
		//свойства ---------------------
		public String Server
		{
			get {return _server;}
			set {_server = value;}
		}
		public String DataBase
		{
			get {return _database;}
			set {_database = value;}
		}
		public String UserID
		{
			get {return _userid;}
			set {_userid = value;}
		}
		public String Pass
		{
			get {return _pass;}
			set {_pass = value;}
		}
		
		//методы --------------------------
		public bool CreateTables()
		{
			try{
				//Создание базы данных ===================================
				_MySql_Connection.ConnectionString = "server=" + _server + ";database=;uid=" + _userid + ";pwd=" + _pass + ";";
				_MySql_Connection.Open();
				_SqlCommand = "CREATE DATABASE " + _database;
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_MySql_Connection.Close();
				
				//Создание таблиц в базе данных ===========================
				_MySql_Connection.ConnectionString = "server=" + _server + ";database=" + _database + ";uid=" + _userid + ";pwd=" + _pass + ";";
				_MySql_Connection.Open();
				
				/*Создание таблицы "Пользователи" (users)
				 * id_user				- идентификатор
				 * user_name			- имя пользователя
				 * user_pass			- пароль
				 * user_right			- права
				 * user_additionally	- дополнительно
				 */
				_SqlCommand = "CREATE TABLE users (id_user INT NOT NULL AUTO_INCREMENT PRIMARY KEY, " +
					"user_name VARCHAR(250) DEFAULT '' UNIQUE, " +
					"user_pass VARCHAR(250) DEFAULT '', " +
					"user_right VARCHAR(100) DEFAULT '', " +
					"user_additionally TEXT DEFAULT '')";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO users (user_name, user_pass, user_right, user_additionally) VALUES ('Администратор', '12345', 'admin', 'Администратор конфигурации')";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO users (user_name, user_pass, user_right, user_additionally) VALUES ('Пользователь', '', 'user', 'Пользователь конфигурации')";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				
				/*Создание таблицы "Константы" (constants)
				 * id_const				- идентификатор
				 * const_name			- наименование
				 * const_value			- значение
				 * const_additionally	- дополнительно
				 * const_delete			- флаг удаления
				 */
				_SqlCommand = "CREATE TABLE constants (id_const INT NOT NULL AUTO_INCREMENT PRIMARY KEY, " +
					"const_name VARCHAR(250) DEFAULT '' UNIQUE, " +
					"const_value VARCHAR(250) DEFAULT '', " +
					"const_additionally TEXT DEFAULT '', " +
					"const_delete INT(1) DEFAULT 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO constants (const_name, const_value, const_additionally, const_delete) VALUES ('Наша фирма', '', '', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO constants (const_name, const_value, const_additionally, const_delete) VALUES ('Поставщик', '', '', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO constants (const_name, const_value, const_additionally, const_delete) VALUES ('Покупатель', '', '', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO constants (const_name, const_value, const_additionally, const_delete) VALUES ('Вид НДС', '', '', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO constants (const_name, const_value, const_additionally, const_delete) VALUES ('Основной склад', '', '', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO constants (const_name, const_value, const_additionally, const_delete) VALUES ('Ед. измерения', '', '', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO constants (const_name, const_value, const_additionally, const_delete) VALUES ('Директор', '', '', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO constants (const_name, const_value, const_additionally, const_delete) VALUES ('Главный бухгалтер', '', '', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				
				/*Создать таблицу "Фирмы" (firms)
				 * id_firm						- идентификатор
				 * firm_name					- наименование
				 * firm_details					- реквизиты
				 * firm_address_phone			- адрес и телефон
				 * firm_trade_representative	- сотрудник (торг. представитель) +
				 * firm_additionally			- дополнительно
				 * firm_type					- флаг тип записи (папка / запись)
				 * firm_folder					- имя родительской папки
				 * firm_delete					- флаг удаления
				 */
				_SqlCommand = "CREATE TABLE firms (id_firm INT NOT NULL AUTO_INCREMENT PRIMARY KEY, " +
					"firm_name VARCHAR(250) DEFAULT '' UNIQUE, " +
					"firm_details TEXT DEFAULT '', " +
					"firm_address_phone TEXT DEFAULT '', " +
					"firm_trade_representative VARCHAR(250) DEFAULT '', " +
					"firm_additionally TEXT DEFAULT '', " +
					"firm_type INT(1) DEFAULT 0, " +
					"firm_folder VARCHAR(250) DEFAULT '', " +
					"firm_delete INT(1) DEFAULT 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO firms (firm_name, firm_details, firm_address_phone, firm_trade_representative, firm_additionally, firm_type, firm_folder, firm_delete) VALUES ('Поставщики', '', '', '', '', 1, '', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO firms (firm_name, firm_details, firm_address_phone, firm_trade_representative, firm_additionally, firm_type, firm_folder, firm_delete) VALUES ('Покупатели', '', '', '', '', 1, '', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO firms (firm_name, firm_details, firm_address_phone, firm_trade_representative, firm_additionally, firm_type, firm_folder, firm_delete) VALUES ('Наша Фирма', '', '', '', '', 0, '', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				
				/*Создать таблицу "ТМЦ" (tmc)
				 * id_tmc				- идентификатор
				 * tmc_name				- наименование
				 * tmc_type_tax			- вид налога +
				 * tmc_units			- единицы измерения +
				 * tmc_buy				- цена покупки
				 * tmc_sale				- цена продажи
				 * tmc_store			- склад хранения
				 * tmc_additionally		- дополнительно
				 * tmc_type				- флаг тип записи (папка / запись)
				 * tmc_folder			- имя родительской папки
				 * tmc_delete			- флаг удаления
				 */
				_SqlCommand = "CREATE TABLE tmc (id_tmc INT NOT NULL AUTO_INCREMENT PRIMARY KEY, " +
					"tmc_name VARCHAR(250) DEFAULT '' UNIQUE, " +
					"tmc_type_tax VARCHAR(250) DEFAULT '', " +
					"tmc_units VARCHAR(250) DEFAULT '', " +
					"tmc_buy DOUBLE(10,2) DEFAULT 0.00, " +
					"tmc_sale DOUBLE(10,2) DEFAULT 0.00, " +
					"tmc_store VARCHAR(250) DEFAULT '', " +
					"tmc_additionally TEXT DEFAULT '', " +
					"tmc_type INT(1) DEFAULT 0, " +
					"tmc_folder VARCHAR(250) DEFAULT '', " +
					"tmc_delete INT(1) DEFAULT 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				
				/*Создать таблицу "Склады" (store)
				 * id_store				- идентификатор
				 * store_name			- наименование
				 * store_additionally	- дополнительно
				 * store_delete			- флаг удаления
				 */
				_SqlCommand = "CREATE TABLE store (id_store INT NOT NULL AUTO_INCREMENT PRIMARY KEY, " +
					"store_name VARCHAR(250) DEFAULT '' UNIQUE, " +
					"store_additionally TEXT DEFAULT '', " +
					"store_delete INT(1) DEFAULT 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO store (store_name, store_additionally, store_delete) VALUES ('Основной', 'Основной склад по умолчанию.', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
								
				/*Создать таблицу "Единицы измерения" (units)
				 * id_units				- идентификатор
				 * units_name			- наименование
				 * units_additionally	- дополнительно
				 * units_delete			- флаг удаления
				 */
				_SqlCommand = "CREATE TABLE units (id_units INT NOT NULL AUTO_INCREMENT PRIMARY KEY, " +
					"units_name VARCHAR(250) DEFAULT '' UNIQUE, " +
					"units_additionally TEXT DEFAULT '', " +
					"units_delete INT(1) DEFAULT 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO units (units_name, units_additionally, units_delete) VALUES ('шт.', 'Штуки.', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO units (units_name, units_additionally, units_delete) VALUES ('кг.', 'Килограммы.', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO units (units_name, units_additionally, units_delete) VALUES ('м.', 'Метры.', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO units (units_name, units_additionally, units_delete) VALUES ('см.', 'Сантиметны.', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO units (units_name, units_additionally, units_delete) VALUES ('л.', 'Литры.', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO units (units_name, units_additionally, units_delete) VALUES ('г.', 'Граммы.', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				
				/*Создать таблицу "Вид налога" (typeTax)
				 * id_typeTax			- идентификатор
				 * typeTax_name			- наименование
				 * typeTax_rating		- ставка
				 * typeTax_additionally	- дополнительно
				 * typeTax_delete		- флаг удаления
				 */
				_SqlCommand = "CREATE TABLE typeTax (id_typeTax INT NOT NULL AUTO_INCREMENT PRIMARY KEY, " +
					"typeTax_name VARCHAR(250) DEFAULT '' UNIQUE, " +
					"typeTax_rating DOUBLE(10,2) DEFAULT 0.00, " +
					"typeTax_additionally TEXT DEFAULT '', " +
					"typeTax_delete INT(1) DEFAULT 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO typeTax (typeTax_name, typeTax_rating, typeTax_additionally, typeTax_delete) VALUES ('Налог 20%', 20, 'Ставка НДС 20%', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO typeTax (typeTax_name, typeTax_rating, typeTax_additionally, typeTax_delete) VALUES ('Налог 0%', 0, 'Ставка НДС 0% или без НДС', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				
				/*Создать таблицу  "Сотрудники" (staff)
				 * id_staff				-идентификатор
				 * staff_name			- ф.и.о.
				 * staff_details		- реквизиты
				 * staff_address_phone	- адрес и телефон
				 * staff_date_hired		- нанят на работу
				 * staff_date_fired		- уволен с работы
				 * staff_salary			- зарплата
				 * staff_additionally	- дополнительно
				 * staff_type			- флаг тип записи (папка / запись)
				 * staff_folder			- имя родительской папки
				 * staff_delete			- флаг удаления
				 */
				_SqlCommand = "CREATE TABLE staff (id_staff INT NOT NULL AUTO_INCREMENT PRIMARY KEY, " +
					"staff_name VARCHAR(250) DEFAULT '' UNIQUE, " +
					"staff_details TEXT DEFAULT '', " +
					"staff_address_phone TEXT DEFAULT '', " +
					"staff_date_hired DATE, staff_date_fired DATE, " +
					"staff_salary DOUBLE(10,2) DEFAULT 0.00, " +
					"staff_additionally TEXT DEFAULT '', " +
					"staff_type INT(1) DEFAULT 0, " +
					"staff_folder VARCHAR(250) DEFAULT '', " +
					"staff_delete INT(1) DEFAULT 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				
				/*Создать таблицу "Полный журнал документов" (journal)
				 * id_journal			- идентификатор
				 * journal_id_doc		- идентификатор документа (для табличной части и операции)
				 * journal_date			- дата документа
				 * journal_number		- номер документа
				 * journal_user_autor	- пользователь (автор документа) +
				 * journal_type			- тип документа (приход / расход / заказ / перемещение)
				 * journal_store		- склад +
				 * journal_firm_buyer	- покупатель +
				 * journal_firm_buyer_details			- реквизиты покупателя +
				 * journal_firm_seller	- продавец +
				 * journal_firm_seller_details			- реквизиты продавца +
				 * journal_staff_trade_representative	- торговый представитель +
				 * journal_typeTax		- вид налога +
				 * journal_sum			- сумма
				 * journal_tax			- налог
				 * journal_total		- итого
				 * journal_delete		- флаг удаления
				 */
				_SqlCommand = "CREATE TABLE journal (id_journal INT NOT NULL AUTO_INCREMENT PRIMARY KEY, " +
					"journal_id_doc VARCHAR(250) NOT NULL DEFAULT '' UNIQUE, " +
					"journal_date DATE NOT NULL, " +
					"journal_number VARCHAR(250) NOT NULL DEFAULT '', " +
					"journal_user_autor VARCHAR(250) NOT NULL DEFAULT '', " +
					"journal_type VARCHAR(100) NOT NULL DEFAULT '', " +
					"journal_store VARCHAR(250) NOT NULL DEFAULT '', " +
					"journal_firm_buyer VARCHAR(250) NOT NULL DEFAULT '', " +
					"journal_firm_buyer_details TEXT DEFAULT '', " +
					"journal_firm_seller VARCHAR(250) NOT NULL DEFAULT '', " +
					"journal_firm_seller_details TEXT DEFAULT '', " +
					"journal_staff_trade_representative VARCHAR(250) NOT NULL DEFAULT '', " +
					"journal_typeTax VARCHAR(250) NOT NULL DEFAULT '', " +
					"journal_sum DOUBLE(10,2) DEFAULT 0.00, " +
					"journal_tax DOUBLE(10,2) DEFAULT 0.00, " +
					"journal_total DOUBLE(10,2) DEFAULT 0.00, " +
					"journal_delete INT(1) DEFAULT 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				
				/*Создать таблицу "Табличная часть Документа" (tabularSection)
				 * id_tabularSection	- идентификатор
				 * tabularSection_tmc	- ТМЦ
				 * tabularSection_units	- ед. измерения
				 * tabularSection_number- количество
				 * tabularSection_price	- цена
				 * tabularSection_NDS	- НДС
				 * tabularSection_sum	- сумма
				 * tabularSection_total	- всего
				 * tabularSection_id_doc- документ (внешний ключ)
				 */
				_SqlCommand = "CREATE TABLE tabularSection (id_tabularSection INT NOT NULL AUTO_INCREMENT PRIMARY KEY, " +
					"tabularSection_tmc VARCHAR(250) NOT NULL DEFAULT '', " +
					"tabularSection_units VARCHAR(250) NOT NULL DEFAULT '', " +
					"tabularSection_number DOUBLE(10,2) DEFAULT 0.00, " +
					"tabularSection_price DOUBLE(10,2) DEFAULT 0.00, " +
					"tabularSection_NDS DOUBLE(10,2) DEFAULT 0.00, " +
					"tabularSection_sum DOUBLE(10,2) DEFAULT 0.00, " +
					"tabularSection_total DOUBLE(10,2) DEFAULT 0.00, " +
					"tabularSection_id_doc VARCHAR(250) NOT NULL, " +
					"FOREIGN KEY (tabularSection_id_doc) REFERENCES journal(journal_id_doc) ON UPDATE CASCADE ON DELETE RESTRICT" +
					")";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				
				/*Создать таблицу "Остатки" (balance)
				 * id_balance			- идентификатор
				 * balance_tmc			- ТМЦ
				 * balance_date			- дата
				 * balance_number		- количество
				 */
				_SqlCommand = "CREATE TABLE balance (id_balance INT NOT NULL AUTO_INCREMENT PRIMARY KEY, " +
					"balance_tmc VARCHAR(250) NOT NULL DEFAULT '', " +
					"balance_date DATE NOT NULL, " +
					"balance_number DOUBLE(10,2) DEFAULT 0.00)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				
				/*Создать таблицу "Операции" (operations)
				 * id_operations		- идентификатор
				 * operations_date		- дата
				 * operations_id_doc	- идентификатор документа
				 * operations_DT		- счет ДТ
				 * operations_KT		- счет КД
				 * operations_sum		- сумма
				 * operations_specification - описание
				 */
				_SqlCommand = "CREATE TABLE operations (id_operations INT NOT NULL AUTO_INCREMENT PRIMARY KEY, " +
					"operations_date DATE NOT NULL, " +
					"operations_id_doc VARCHAR(250) DEFAULT '', " +
					"operations_DT INT(3) NOT NULL DEFAULT 0, " +
					"operations_KT INT(3) NOT NULL DEFAULT 0, " +
					"operations_sum DOUBLE(10,2) DEFAULT 0.00, " +
					"operations_specification VARCHAR(50) DEFAULT '')";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				
				
				/*Создать таблицу "План счетов" (planAccounts)
				 * id_planAccounts		- идентификатор
				 * planAccounts_name	- наименование
				 * planAccounts_account	- счёт
				 * planAccounts_type	- тип
				 * planAccounts_delete	- флаг удаления
				 */
				_SqlCommand = "CREATE TABLE planAccounts (id_planAccounts INT NOT NULL AUTO_INCREMENT PRIMARY KEY, " +
					"planAccounts_name VARCHAR(250) NOT NULL DEFAULT '', " +
					"planAccounts_account INT(3) NOT NULL DEFAULT 0 UNIQUE, " +
					"planAccounts_type VARCHAR(5) NOT NULL DEFAULT 'АП', " +
					"planAccounts_delete INT(1) DEFAULT 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Основные средства', 10, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Прочиe необоротные материальные активы', 11, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Нематериальные активы', 12, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Износ (амортизация) неoборотных активов', 13, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Долгосрочные финансовые инвестиции', 14, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Капитальные инвестиции', 15, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Долгосрочные биологические активы', 16, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Отсроченные налоговые aктивы', 17, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Долгосрочнaя дебиторская задолженность и проч. необоротные активы', 18, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Гудвилл', 19, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Производственные зaпасы', 20, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Текущие биологические активы', 21, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Малоценные быстроизнашивающиеся предметы', 22, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Производство', 23, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Брак в производстве', 24, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Полуфабрикаты', 25, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Готовая продукция', 26, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Продукция сельскохозяйственного производства', 27, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Товары', 28, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Касса', 30, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Счета в банках', 31, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Пpoчие денежные средства', 33, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Краткосрочные векселя полученные', 34, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Текущие финансовые инвестиции', 35, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Расчеты с покупателями, заказчиками', 36, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Расчеты с рaзными дебиторами', 37, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Резерв сомнительных долгoв', 38, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Расходы будущих периодов', 39, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Уставный капитaл', 40, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Паевой капитал', 41, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Дополнительный капитал', 42, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Резервный капитал', 43, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Нераспредeлeнные прибыли (непокрытые убытки)', 44, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Изъятый капитал', 45, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Неоплаченный капитал', 46, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Обеспечение предстоящиx расходов и платежей', 47, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Целевое финансирование и цeлевые поступления', 48, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Страховые резервы', 49, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Долгосрочные займы', 50, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Долгосрочные векселя выданные', 51, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Долгосрочные обязатeльcтва по облигациям', 52, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Долгосрочные обязaтельства по аренде', 53, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Отсроченные налоговые обязательства', 54, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Прочие долгосрочные обязательства', 55, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Краткосрочные зaймы', 60, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Тeкущая задолженность по долгосрочным обязательствам', 61, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Краткосрочные векселя выданные', 62, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Расчеты с поставщиками, подрядчиками', 63, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Расчеты по налогам и плaтежам', 64, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Расчеты по страхованию', 65, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Расчеты по выплaтам работникам', 66, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Расчеты с участниками', 67, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Расчеты по дpугим операциям', 68, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Доходы будущих периодов', 69, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Доходы от реализации', 70, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Прочий операционный доход ', 71, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Доход от учаcтия в капитале', 72, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Прочие финансовые доходы', 73, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Прочие доходы', 74, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Чрезвычайные доходы', 75, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Страховые платежи', 76, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Финансовые результаты', 79, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Материальные затраты', 80, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Затраты на оплату труда', 81, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Отчисления на социальные мерoприятия', 82, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Амортизация', 83, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Прочие операционные затраты', 84, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Прочие затраты', 85, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Себестоимость реализации', 90, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Общепроизводственные расходы', 91, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Административные расходы', 92, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Расходы на сбыт', 93, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Пpочиe расходы операционной деятельности', 94, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Финансовые расходы', 95, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Потери от учacтия в капитале', 96, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Прочие расходы', 97, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Налог на прибыль', 98, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO planAccounts (planAccounts_name, planAccounts_account, planAccounts_type, planAccounts_delete) VALUES ('Чрезвычайные расходы', 99, 'АП', 0)";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				
				/*Создать таблицу "История Обновлений" (historyUpdate)
				 * id_history			- идентификатор
				 * history_table_name	- имя таблицы
				 * history_table_represent - представление имени таблиц
				 * history_datetime		- дата и время обновления
				 * history_error		- сообщение об ошибке
				 * history_user			- пользователь
				 * history_client		- клиент
				 * history_action		- активность
				 * history_additionally - дополнительно
				 */
				_SqlCommand = "CREATE TABLE historyUpdate (id_history INT NOT NULL AUTO_INCREMENT PRIMARY KEY, " +
					"history_table_name VARCHAR(250) NOT NULL DEFAULT '' UNIQUE, " +
					"history_table_represent VARCHAR(250) DEFAULT '', " +
					"history_datetime VARCHAR(250) NOT NULL DEFAULT '', " +
					"history_error VARCHAR(250) DEFAULT '', " +
					"history_user VARCHAR(250) DEFAULT '', " +
					"history_client VARCHAR(250) DEFAULT '', " +
					"history_action VARCHAR(250) DEFAULT '', " +
					"history_additionally TEXT DEFAULT '')";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO historyUpdate (history_table_name, history_table_represent, history_datetime, history_error, history_user, history_client, history_action, history_additionally) VALUES ('users', 'Пользователи', '" + DateTime.Now.ToString() + "', '', '', '', '', '')";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса			
				_SqlCommand = "INSERT INTO historyUpdate (history_table_name, history_table_represent, history_datetime, history_error, history_user, history_client, history_action, history_additionally) VALUES ('constants', 'Константы', '" + DateTime.Now.ToString() + "', '', '', '', '', '')";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO historyUpdate (history_table_name, history_table_represent, history_datetime, history_error, history_user, history_client, history_action, history_additionally) VALUES ('firms', 'Фирмы', '" + DateTime.Now.ToString() + "', '', '', '', '', '')";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO historyUpdate (history_table_name, history_table_represent, history_datetime, history_error, history_user, history_client, history_action, history_additionally) VALUES ('tmc', 'ТМЦ', '" + DateTime.Now.ToString() + "', '', '', '', '', '')";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO historyUpdate (history_table_name, history_table_represent, history_datetime, history_error, history_user, history_client, history_action, history_additionally) VALUES ('store', 'Склады', '" + DateTime.Now.ToString() + "', '', '', '', '', '')";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO historyUpdate (history_table_name, history_table_represent, history_datetime, history_error, history_user, history_client, history_action, history_additionally) VALUES ('units', 'Единицы измерения', '" + DateTime.Now.ToString() + "', '', '', '', '', '')";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO historyUpdate (history_table_name, history_table_represent, history_datetime, history_error, history_user, history_client, history_action, history_additionally) VALUES ('typeTax', 'Вид НДС', '" + DateTime.Now.ToString() + "', '', '', '', '', '')";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO historyUpdate (history_table_name, history_table_represent, history_datetime, history_error, history_user, history_client, history_action, history_additionally) VALUES ('staff', 'Сотрудники', '" + DateTime.Now.ToString() + "', '', '', '', '', '')";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO historyUpdate (history_table_name, history_table_represent, history_datetime, history_error, history_user, history_client, history_action, history_additionally) VALUES ('journal', 'Журнал документов', '" + DateTime.Now.ToString() + "', '', '', '', '', '')";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO historyUpdate (history_table_name, history_table_represent, history_datetime, history_error, history_user, history_client, history_action, history_additionally) VALUES ('tabularSection', 'Табличная часть документа', '" + DateTime.Now.ToString() + "', '', '', '', '', '')";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO historyUpdate (history_table_name, history_table_represent, history_datetime, history_error, history_user, history_client, history_action, history_additionally) VALUES ('balance', 'Остатки', '" + DateTime.Now.ToString() + "', '', '', '', '', '')";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO historyUpdate (history_table_name, history_table_represent, history_datetime, history_error, history_user, history_client, history_action, history_additionally) VALUES ('operations', 'Операции', '" + DateTime.Now.ToString() + "', '', '', '', '', '')";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				_SqlCommand = "INSERT INTO historyUpdate (history_table_name, history_table_represent, history_datetime, history_error, history_user, history_client, history_action, history_additionally) VALUES ('planAccounts', 'План счетов', '" + DateTime.Now.ToString() + "', '', '', '', '', '')";
				_MySql_Command.CommandText = _SqlCommand;
				_MySql_Command.ExecuteNonQuery();	//выполнение запроса
				
				
				
				_MySql_Connection.Close();
				return true;
			}catch(Exception ex){
				_MySql_Connection.Close();
				MessageBox.Show(ex.ToString());	//Сообщение об ошибке
				return false;
			}
		}
		
		//поля ---------------------------
		private MySqlConnection _MySql_Connection;
		private MySqlCommand _MySql_Command;
		private String _server;
		private String _database;
		private String _userid;
		private String _pass;
		private String _SqlCommand;
	}
}
