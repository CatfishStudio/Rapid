/*
 * Сделано в SharpDevelop.
 * Пользователь: Catfish
 * Дата: 21.01.2014
 * Время: 14:19
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
namespace Rapid
{
	partial class FormClientConst
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClientConst));
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.создатьКонстантуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.изменитьКонстантуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.удалитьКонстантуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.panel1.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "ticket1.ico");
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.button3);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Location = new System.Drawing.Point(2, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(488, 41);
			this.panel1.TabIndex = 1;
			// 
			// button3
			// 
			this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
			this.button3.Location = new System.Drawing.Point(72, 10);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(25, 23);
			this.button3.TabIndex = 1;
			this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolTip1.SetToolTip(this.button3, "Удалить.");
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// button2
			// 
			this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
			this.button2.Location = new System.Drawing.Point(41, 10);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(25, 23);
			this.button2.TabIndex = 1;
			this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolTip1.SetToolTip(this.button2, "Изменить.");
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// button1
			// 
			this.button1.Enabled = false;
			this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
			this.button1.Location = new System.Drawing.Point(10, 10);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(25, 23);
			this.button1.TabIndex = 0;
			this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolTip1.SetToolTip(this.button1, "Создать.");
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button4
			// 
			this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button4.Location = new System.Drawing.Point(404, 262);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 3;
			this.button4.Text = "Закрыть.";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.Button4Click);
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
									this.columnHeader4});
			this.listView1.ContextMenuStrip = this.contextMenuStrip1;
			this.listView1.Cursor = System.Windows.Forms.Cursors.Default;
			this.listView1.FullRowSelect = true;
			this.listView1.LargeImageList = this.imageList1;
			this.listView1.Location = new System.Drawing.Point(2, 49);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(488, 199);
			this.listView1.SmallImageList = this.imageList1;
			this.listView1.StateImageList = this.imageList1;
			this.listView1.TabIndex = 4;
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
			this.columnHeader2.Text = "Наименование";
			this.columnHeader2.Width = 400;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Значение";
			this.columnHeader3.Width = 200;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "№";
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.создатьКонстантуToolStripMenuItem,
									this.изменитьКонстантуToolStripMenuItem,
									this.удалитьКонстантуToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(190, 70);
			// 
			// создатьКонстантуToolStripMenuItem
			// 
			this.создатьКонстантуToolStripMenuItem.Enabled = false;
			this.создатьКонстантуToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("создатьКонстантуToolStripMenuItem.Image")));
			this.создатьКонстантуToolStripMenuItem.Name = "создатьКонстантуToolStripMenuItem";
			this.создатьКонстантуToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
			this.создатьКонстантуToolStripMenuItem.Text = "Создать константу.";
			// 
			// изменитьКонстантуToolStripMenuItem
			// 
			this.изменитьКонстантуToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("изменитьКонстантуToolStripMenuItem.Image")));
			this.изменитьКонстантуToolStripMenuItem.Name = "изменитьКонстантуToolStripMenuItem";
			this.изменитьКонстантуToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
			this.изменитьКонстантуToolStripMenuItem.Text = "Изменить константу.";
			this.изменитьКонстантуToolStripMenuItem.Click += new System.EventHandler(this.ИзменитьКонстантуToolStripMenuItemClick);
			// 
			// удалитьКонстантуToolStripMenuItem
			// 
			this.удалитьКонстантуToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("удалитьКонстантуToolStripMenuItem.Image")));
			this.удалитьКонстантуToolStripMenuItem.Name = "удалитьКонстантуToolStripMenuItem";
			this.удалитьКонстантуToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
			this.удалитьКонстантуToolStripMenuItem.Text = "Удалить константу.";
			this.удалитьКонстантуToolStripMenuItem.Click += new System.EventHandler(this.УдалитьКонстантуToolStripMenuItemClick);
			// 
			// FormClientConst
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(491, 297);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormClientConst";
			this.Text = "Константы:";
			this.Closed += new System.EventHandler(this.FormClientConstClosed);
			this.Load += new System.EventHandler(this.FormClientConstLoad);
			this.panel1.ResumeLayout(false);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ToolStripMenuItem удалитьКонстантуToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem изменитьКонстантуToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem создатьКонстантуToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ImageList imageList1;
	}
}
