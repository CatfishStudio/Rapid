/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 26.02.2014
 * Время: 11:46
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
namespace Rapid
{
	partial class FormClientJournalDoc
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClientJournalDoc));
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.папкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.создатьПапкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.изменитьПапкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.удалитьПапкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.создатьЗаписьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.изменитьЗаписьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.удалитьЗаписьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.выбратьЗаписьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.panel5 = new System.Windows.Forms.Panel();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.panel4 = new System.Windows.Forms.Panel();
			this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.button8 = new System.Windows.Forms.Button();
			this.contextMenuStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "folder.png");
			this.imageList1.Images.SetKeyName(1, "folder_delete.png");
			this.imageList1.Images.SetKeyName(2, "application.png");
			this.imageList1.Images.SetKeyName(3, "application_delete.png");
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.папкиToolStripMenuItem,
									this.toolStripMenuItem1,
									this.создатьЗаписьToolStripMenuItem,
									this.изменитьЗаписьToolStripMenuItem,
									this.удалитьЗаписьToolStripMenuItem,
									this.toolStripMenuItem2,
									this.выбратьЗаписьToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(172, 126);
			// 
			// папкиToolStripMenuItem
			// 
			this.папкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.создатьПапкуToolStripMenuItem,
									this.изменитьПапкуToolStripMenuItem,
									this.удалитьПапкуToolStripMenuItem});
			this.папкиToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("папкиToolStripMenuItem.Image")));
			this.папкиToolStripMenuItem.Name = "папкиToolStripMenuItem";
			this.папкиToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.папкиToolStripMenuItem.Text = "Папки:";
			// 
			// создатьПапкуToolStripMenuItem
			// 
			this.создатьПапкуToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("создатьПапкуToolStripMenuItem.Image")));
			this.создатьПапкуToolStripMenuItem.Name = "создатьПапкуToolStripMenuItem";
			this.создатьПапкуToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.создатьПапкуToolStripMenuItem.Text = "Создать папку.";
			// 
			// изменитьПапкуToolStripMenuItem
			// 
			this.изменитьПапкуToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("изменитьПапкуToolStripMenuItem.Image")));
			this.изменитьПапкуToolStripMenuItem.Name = "изменитьПапкуToolStripMenuItem";
			this.изменитьПапкуToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.изменитьПапкуToolStripMenuItem.Text = "Изменить папку.";
			// 
			// удалитьПапкуToolStripMenuItem
			// 
			this.удалитьПапкуToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("удалитьПапкуToolStripMenuItem.Image")));
			this.удалитьПапкуToolStripMenuItem.Name = "удалитьПапкуToolStripMenuItem";
			this.удалитьПапкуToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.удалитьПапкуToolStripMenuItem.Text = "Удалить папку.";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(168, 6);
			// 
			// создатьЗаписьToolStripMenuItem
			// 
			this.создатьЗаписьToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("создатьЗаписьToolStripMenuItem.Image")));
			this.создатьЗаписьToolStripMenuItem.Name = "создатьЗаписьToolStripMenuItem";
			this.создатьЗаписьToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.создатьЗаписьToolStripMenuItem.Text = "Создать запись.";
			// 
			// изменитьЗаписьToolStripMenuItem
			// 
			this.изменитьЗаписьToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("изменитьЗаписьToolStripMenuItem.Image")));
			this.изменитьЗаписьToolStripMenuItem.Name = "изменитьЗаписьToolStripMenuItem";
			this.изменитьЗаписьToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.изменитьЗаписьToolStripMenuItem.Text = "Изменить запись.";
			// 
			// удалитьЗаписьToolStripMenuItem
			// 
			this.удалитьЗаписьToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("удалитьЗаписьToolStripMenuItem.Image")));
			this.удалитьЗаписьToolStripMenuItem.Name = "удалитьЗаписьToolStripMenuItem";
			this.удалитьЗаписьToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.удалитьЗаписьToolStripMenuItem.Text = "Удалить запись.";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(168, 6);
			this.toolStripMenuItem2.Visible = false;
			// 
			// выбратьЗаписьToolStripMenuItem
			// 
			this.выбратьЗаписьToolStripMenuItem.Name = "выбратьЗаписьToolStripMenuItem";
			this.выбратьЗаписьToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.выбратьЗаписьToolStripMenuItem.Text = "Выбрать запись.";
			this.выбратьЗаписьToolStripMenuItem.Visible = false;
			// 
			// button1
			// 
			this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
			this.button1.Location = new System.Drawing.Point(10, 10);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(25, 23);
			this.button1.TabIndex = 1;
			this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolTip1.SetToolTip(this.button1, "Создать папку.");
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
			this.button2.Location = new System.Drawing.Point(41, 10);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(25, 23);
			this.button2.TabIndex = 2;
			this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolTip1.SetToolTip(this.button2, "Создать папку.");
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
			this.button3.Location = new System.Drawing.Point(72, 10);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(25, 23);
			this.button3.TabIndex = 3;
			this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolTip1.SetToolTip(this.button3, "Создать папку.");
			this.button3.UseVisualStyleBackColor = true;
			// 
			// button4
			// 
			this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
			this.button4.Location = new System.Drawing.Point(113, 10);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(25, 23);
			this.button4.TabIndex = 10;
			this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolTip1.SetToolTip(this.button4, "Создать папку.");
			this.button4.UseVisualStyleBackColor = true;
			// 
			// button5
			// 
			this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
			this.button5.Location = new System.Drawing.Point(388, 10);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(25, 23);
			this.button5.TabIndex = 15;
			this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolTip1.SetToolTip(this.button5, "Создать папку.");
			this.button5.UseVisualStyleBackColor = true;
			// 
			// button6
			// 
			this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
			this.button6.Location = new System.Drawing.Point(540, 10);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(25, 23);
			this.button6.TabIndex = 18;
			this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolTip1.SetToolTip(this.button6, "Создать папку.");
			this.button6.UseVisualStyleBackColor = true;
			// 
			// button7
			// 
			this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
			this.button7.Location = new System.Drawing.Point(699, 10);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(25, 23);
			this.button7.TabIndex = 21;
			this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolTip1.SetToolTip(this.button7, "Поиск.");
			this.button7.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.button7);
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Controls.Add(this.panel5);
			this.panel1.Controls.Add(this.button6);
			this.panel1.Controls.Add(this.comboBox1);
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Controls.Add(this.button5);
			this.panel1.Controls.Add(this.dateTimePicker2);
			this.panel1.Controls.Add(this.dateTimePicker1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.button4);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.button3);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Location = new System.Drawing.Point(2, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(745, 41);
			this.panel1.TabIndex = 1;
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(581, 12);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(112, 20);
			this.textBox1.TabIndex = 20;
			// 
			// panel5
			// 
			this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel5.Location = new System.Drawing.Point(571, 13);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(4, 20);
			this.panel5.TabIndex = 19;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
									"Все",
									"Заказ",
									"Приходная накладная",
									"Расходная накладная"});
			this.comboBox1.Location = new System.Drawing.Point(429, 12);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(105, 21);
			this.comboBox1.TabIndex = 17;
			this.comboBox1.Text = "Все";
			// 
			// panel4
			// 
			this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel4.Location = new System.Drawing.Point(419, 13);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(4, 20);
			this.panel4.TabIndex = 16;
			// 
			// dateTimePicker2
			// 
			this.dateTimePicker2.CustomFormat = "yyyy-MM-dd";
			this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker2.Location = new System.Drawing.Point(286, 12);
			this.dateTimePicker2.Name = "dateTimePicker2";
			this.dateTimePicker2.Size = new System.Drawing.Size(96, 20);
			this.dateTimePicker2.TabIndex = 14;
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker1.Location = new System.Drawing.Point(168, 12);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(96, 20);
			this.dateTimePicker1.TabIndex = 11;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(154, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(138, 15);
			this.label1.TabIndex = 13;
			this.label1.Text = "с                                    по";
			// 
			// panel3
			// 
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel3.Location = new System.Drawing.Point(144, 13);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(4, 20);
			this.panel3.TabIndex = 12;
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel2.Location = new System.Drawing.Point(103, 13);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(4, 20);
			this.panel2.TabIndex = 9;
			// 
			// listView1
			// 
			this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2,
									this.columnHeader3,
									this.columnHeader4,
									this.columnHeader5,
									this.columnHeader6,
									this.columnHeader7});
			this.listView1.ContextMenuStrip = this.contextMenuStrip1;
			this.listView1.Cursor = System.Windows.Forms.Cursors.Default;
			this.listView1.FullRowSelect = true;
			this.listView1.LargeImageList = this.imageList1;
			this.listView1.Location = new System.Drawing.Point(2, 45);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(745, 276);
			this.listView1.SmallImageList = this.imageList1;
			this.listView1.StateImageList = this.imageList1;
			this.listView1.TabIndex = 5;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "...";
			this.columnHeader1.Width = 40;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Дата:";
			this.columnHeader2.Width = 100;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Номер документа:";
			this.columnHeader3.Width = 120;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Документ:";
			this.columnHeader4.Width = 300;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Всего:";
			this.columnHeader5.Width = 100;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Автор";
			this.columnHeader6.Width = 150;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "№";
			// 
			// button8
			// 
			this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button8.Location = new System.Drawing.Point(662, 331);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(75, 23);
			this.button8.TabIndex = 7;
			this.button8.Text = "Закрыть.";
			this.button8.UseVisualStyleBackColor = true;
			// 
			// FormClientJournalDoc
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(749, 366);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormClientJournalDoc";
			this.Text = "Полный журнал";
			this.contextMenuStrip1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dateTimePicker2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ToolStripMenuItem выбратьЗаписьToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem удалитьЗаписьToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem изменитьЗаписьToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem создатьЗаписьToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem удалитьПапкуToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem изменитьПапкуToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem создатьПапкуToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem папкиToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ImageList imageList1;
	}
}
