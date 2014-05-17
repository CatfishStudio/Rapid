/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 16.09.2013
 * Время: 9:58
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
namespace Rapid
{
	partial class FormAdministrator
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdministrator));
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.открытьФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.сохранитьФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.сохранитьФайлКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.конфигурацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.пользователиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.удалениеПомеченныхОбъектовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.создатьКонфигурациюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.сервисToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.конструкторЗапросовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.мониторАктивностиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.калькуляторToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.toolStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 539);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(784, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripButton1,
									this.toolStripButton2,
									this.toolStripSeparator4,
									this.toolStripButton3,
									this.toolStripButton9,
									this.toolStripSeparator5,
									this.toolStripButton4,
									this.toolStripSeparator6,
									this.toolStripButton5,
									this.toolStripButton6,
									this.toolStripSeparator8,
									this.toolStripButton7,
									this.toolStripSeparator9,
									this.toolStripButton8});
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(784, 25);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton1.Text = "Открыть файл";
			this.toolStripButton1.Click += new System.EventHandler(this.ToolStripButton1Click);
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton2.Text = "Сохранить файл";
			this.toolStripButton2.Click += new System.EventHandler(this.ToolStripButton2Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButton3
			// 
			this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
			this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton3.Name = "toolStripButton3";
			this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton3.Text = "Пользователи";
			this.toolStripButton3.Click += new System.EventHandler(this.ToolStripButton3Click);
			// 
			// toolStripButton9
			// 
			this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
			this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton9.Name = "toolStripButton9";
			this.toolStripButton9.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton9.Text = "Удаленить помеченные объекты.";
			this.toolStripButton9.Click += new System.EventHandler(this.ToolStripButton9Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButton4
			// 
			this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
			this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton4.Name = "toolStripButton4";
			this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton4.Text = "Создать конфигурацию";
			this.toolStripButton4.Click += new System.EventHandler(this.ToolStripButton4Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButton5
			// 
			this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
			this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton5.Name = "toolStripButton5";
			this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton5.Text = "Конструктор запросов";
			this.toolStripButton5.Click += new System.EventHandler(this.ToolStripButton5Click);
			// 
			// toolStripButton6
			// 
			this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
			this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton6.Name = "toolStripButton6";
			this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton6.Text = "Монитор активности";
			this.toolStripButton6.Click += new System.EventHandler(this.ToolStripButton6Click);
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButton7
			// 
			this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
			this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton7.Name = "toolStripButton7";
			this.toolStripButton7.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton7.Text = "Калькулятор";
			this.toolStripButton7.Click += new System.EventHandler(this.ToolStripButton7Click);
			// 
			// toolStripSeparator9
			// 
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButton8
			// 
			this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
			this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton8.Name = "toolStripButton8";
			this.toolStripButton8.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton8.Text = "О программе.";
			this.toolStripButton8.Click += new System.EventHandler(this.ToolStripButton8Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.файлToolStripMenuItem,
									this.конфигурацияToolStripMenuItem,
									this.сервисToolStripMenuItem,
									this.справкаToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(784, 24);
			this.menuStrip1.TabIndex = 3;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// файлToolStripMenuItem
			// 
			this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.открытьФайлToolStripMenuItem,
									this.toolStripSeparator1,
									this.сохранитьФайлToolStripMenuItem,
									this.сохранитьФайлКакToolStripMenuItem,
									this.toolStripSeparator2,
									this.выходToolStripMenuItem});
			this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
			this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.файлToolStripMenuItem.Text = "Файл";
			// 
			// открытьФайлToolStripMenuItem
			// 
			this.открытьФайлToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("открытьФайлToolStripMenuItem.Image")));
			this.открытьФайлToolStripMenuItem.Name = "открытьФайлToolStripMenuItem";
			this.открытьФайлToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.открытьФайлToolStripMenuItem.Text = "Открыть файл.";
			this.открытьФайлToolStripMenuItem.Click += new System.EventHandler(this.ОткрытьФайлToolStripMenuItemClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(191, 6);
			// 
			// сохранитьФайлToolStripMenuItem
			// 
			this.сохранитьФайлToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("сохранитьФайлToolStripMenuItem.Image")));
			this.сохранитьФайлToolStripMenuItem.Name = "сохранитьФайлToolStripMenuItem";
			this.сохранитьФайлToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.сохранитьФайлToolStripMenuItem.Text = "Сохранить файл.";
			this.сохранитьФайлToolStripMenuItem.Click += new System.EventHandler(this.СохранитьФайлToolStripMenuItemClick);
			// 
			// сохранитьФайлКакToolStripMenuItem
			// 
			this.сохранитьФайлКакToolStripMenuItem.Name = "сохранитьФайлКакToolStripMenuItem";
			this.сохранитьФайлКакToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.сохранитьФайлКакToolStripMenuItem.Text = "Сохранить файл как...";
			this.сохранитьФайлКакToolStripMenuItem.Click += new System.EventHandler(this.СохранитьФайлКакToolStripMenuItemClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(191, 6);
			// 
			// выходToolStripMenuItem
			// 
			this.выходToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("выходToolStripMenuItem.Image")));
			this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
			this.выходToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.выходToolStripMenuItem.Text = "Выход.";
			// 
			// конфигурацияToolStripMenuItem
			// 
			this.конфигурацияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.пользователиToolStripMenuItem,
									this.удалениеПомеченныхОбъектовToolStripMenuItem,
									this.toolStripSeparator3,
									this.создатьКонфигурациюToolStripMenuItem});
			this.конфигурацияToolStripMenuItem.Name = "конфигурацияToolStripMenuItem";
			this.конфигурацияToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
			this.конфигурацияToolStripMenuItem.Text = "Конфигурация";
			// 
			// пользователиToolStripMenuItem
			// 
			this.пользователиToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("пользователиToolStripMenuItem.Image")));
			this.пользователиToolStripMenuItem.Name = "пользователиToolStripMenuItem";
			this.пользователиToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
			this.пользователиToolStripMenuItem.Text = "Пользователи.";
			this.пользователиToolStripMenuItem.Click += new System.EventHandler(this.ПользователиToolStripMenuItemClick);
			// 
			// удалениеПомеченныхОбъектовToolStripMenuItem
			// 
			this.удалениеПомеченныхОбъектовToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("удалениеПомеченныхОбъектовToolStripMenuItem.Image")));
			this.удалениеПомеченныхОбъектовToolStripMenuItem.Name = "удалениеПомеченныхОбъектовToolStripMenuItem";
			this.удалениеПомеченныхОбъектовToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
			this.удалениеПомеченныхОбъектовToolStripMenuItem.Text = "Удаленить помеченные объекты.";
			this.удалениеПомеченныхОбъектовToolStripMenuItem.Click += new System.EventHandler(this.УдалениеПомеченныхОбъектовToolStripMenuItemClick);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(255, 6);
			// 
			// создатьКонфигурациюToolStripMenuItem
			// 
			this.создатьКонфигурациюToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("создатьКонфигурациюToolStripMenuItem.Image")));
			this.создатьКонфигурациюToolStripMenuItem.Name = "создатьКонфигурациюToolStripMenuItem";
			this.создатьКонфигурациюToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
			this.создатьКонфигурациюToolStripMenuItem.Text = "Создать конфигурацию.";
			this.создатьКонфигурациюToolStripMenuItem.Click += new System.EventHandler(this.СоздатьКонфигурациюToolStripMenuItemClick);
			// 
			// сервисToolStripMenuItem
			// 
			this.сервисToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.конструкторЗапросовToolStripMenuItem,
									this.мониторАктивностиToolStripMenuItem,
									this.toolStripSeparator7,
									this.калькуляторToolStripMenuItem});
			this.сервисToolStripMenuItem.Name = "сервисToolStripMenuItem";
			this.сервисToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
			this.сервисToolStripMenuItem.Text = "Сервис";
			// 
			// конструкторЗапросовToolStripMenuItem
			// 
			this.конструкторЗапросовToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("конструкторЗапросовToolStripMenuItem.Image")));
			this.конструкторЗапросовToolStripMenuItem.Name = "конструкторЗапросовToolStripMenuItem";
			this.конструкторЗапросовToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
			this.конструкторЗапросовToolStripMenuItem.Text = "Конструктор запросов.";
			this.конструкторЗапросовToolStripMenuItem.Click += new System.EventHandler(this.КонструкторЗапросовToolStripMenuItemClick);
			// 
			// мониторАктивностиToolStripMenuItem
			// 
			this.мониторАктивностиToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("мониторАктивностиToolStripMenuItem.Image")));
			this.мониторАктивностиToolStripMenuItem.Name = "мониторАктивностиToolStripMenuItem";
			this.мониторАктивностиToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
			this.мониторАктивностиToolStripMenuItem.Text = "Монитор активности.";
			this.мониторАктивностиToolStripMenuItem.Click += new System.EventHandler(this.МониторАктивностиToolStripMenuItemClick);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(198, 6);
			// 
			// калькуляторToolStripMenuItem
			// 
			this.калькуляторToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("калькуляторToolStripMenuItem.Image")));
			this.калькуляторToolStripMenuItem.Name = "калькуляторToolStripMenuItem";
			this.калькуляторToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
			this.калькуляторToolStripMenuItem.Text = "Калькулятор";
			this.калькуляторToolStripMenuItem.Click += new System.EventHandler(this.КалькуляторToolStripMenuItemClick);
			// 
			// справкаToolStripMenuItem
			// 
			this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.оПрограммеToolStripMenuItem});
			this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
			this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
			this.справкаToolStripMenuItem.Text = "Справка";
			// 
			// оПрограммеToolStripMenuItem
			// 
			this.оПрограммеToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("оПрограммеToolStripMenuItem.Image")));
			this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
			this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.оПрограммеToolStripMenuItem.Text = "О программе.";
			this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.ОПрограммеToolStripMenuItemClick);
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.richTextBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 401);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(784, 138);
			this.panel1.TabIndex = 5;
			this.panel1.Visible = false;
			// 
			// richTextBox1
			// 
			this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBox1.Location = new System.Drawing.Point(3, 3);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(774, 130);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "";
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "*.*|*.*";
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.Filter = "*.txt|*.txt";
			// 
			// FormAdministrator
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 561);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FormAdministrator";
			this.Text = "Rapid Sales Administrator v 1.0 (GNU)";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Closed += new System.EventHandler(this.FormAdministratorClosed);
			this.Load += new System.EventHandler(this.FormAdministratorLoad);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem удалениеПомеченныхОбъектовToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton toolStripButton9;
		private System.Windows.Forms.ToolStripButton toolStripButton8;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
		private System.Windows.Forms.ToolStripButton toolStripButton7;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		private System.Windows.Forms.ToolStripMenuItem калькуляторToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripButton toolStripButton6;
		private System.Windows.Forms.ToolStripButton toolStripButton5;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolStripMenuItem мониторАктивностиToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem конструкторЗапросовToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem сервисToolStripMenuItem;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem создатьКонфигурациюToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem пользователиToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem конфигурацияToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem сохранитьФайлКакToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem сохранитьФайлToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem открытьФайлToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripButton toolStripButton4;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripButton toolStripButton3;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.StatusStrip statusStrip1;
	}
}
