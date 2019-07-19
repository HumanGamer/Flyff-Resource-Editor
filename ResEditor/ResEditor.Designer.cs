namespace ResEditor
{
	partial class ResEditor
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Miscellaneous Files", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Header Files (*.h)", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Include Files (*.inc)", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Comma Separated Value Files (*.csv)", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Text Files (*.txt)", System.Windows.Forms.HorizontalAlignment.Left);
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResEditor));
			this.fileList = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.mnuContext = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mniContextAdd = new System.Windows.Forms.ToolStripMenuItem();
			this.mniContextRemove = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.mniContextExtract = new System.Windows.Forms.ToolStripMenuItem();
			this.imlMain = new System.Windows.Forms.ImageList(this.components);
			this.mnuMain = new System.Windows.Forms.MenuStrip();
			this.mniFile = new System.Windows.Forms.ToolStripMenuItem();
			this.mniNew = new System.Windows.Forms.ToolStripMenuItem();
			this.mniOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.mniSave = new System.Windows.Forms.ToolStripMenuItem();
			this.mniSaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.mniExit = new System.Windows.Forms.ToolStripMenuItem();
			this.mniActions = new System.Windows.Forms.ToolStripMenuItem();
			this.mniAdd = new System.Windows.Forms.ToolStripMenuItem();
			this.mniRemove = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.mniExtract = new System.Windows.Forms.ToolStripMenuItem();
			this.mniHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.mniAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.stsMain = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.tspMain = new System.Windows.Forms.ToolStrip();
			this.tsbNew = new System.Windows.Forms.ToolStripButton();
			this.tsbOpen = new System.Windows.Forms.ToolStripButton();
			this.tsbSave = new System.Windows.Forms.ToolStripButton();
			this.ag = new System.Windows.Forms.ToolStripSeparator();
			this.tsbAdd = new System.Windows.Forms.ToolStripButton();
			this.tsbRemove = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbExtract = new System.Windows.Forms.ToolStripButton();
			this.tsbResShortcut = new System.Windows.Forms.ToolStripButton();
			this.mnuContext.SuspendLayout();
			this.mnuMain.SuspendLayout();
			this.stsMain.SuspendLayout();
			this.tspMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// fileList
			// 
			this.fileList.AllowDrop = true;
			this.fileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.fileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.fileList.ContextMenuStrip = this.mnuContext;
			listViewGroup1.Header = "Miscellaneous Files";
			listViewGroup1.Name = "other_files";
			listViewGroup2.Header = "Header Files (*.h)";
			listViewGroup2.Name = "h_files";
			listViewGroup3.Header = "Include Files (*.inc)";
			listViewGroup3.Name = "inc_files";
			listViewGroup4.Header = "Comma Separated Value Files (*.csv)";
			listViewGroup4.Name = "csv_files";
			listViewGroup5.Header = "Text Files (*.txt)";
			listViewGroup5.Name = "txt_files";
			this.fileList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4,
            listViewGroup5});
			this.fileList.HideSelection = false;
			this.fileList.LargeImageList = this.imlMain;
			this.fileList.Location = new System.Drawing.Point(-1, 49);
			this.fileList.Name = "fileList";
			this.fileList.Size = new System.Drawing.Size(626, 374);
			this.fileList.SmallImageList = this.imlMain;
			this.fileList.TabIndex = 1;
			this.fileList.UseCompatibleStateImageBehavior = false;
			this.fileList.View = System.Windows.Forms.View.Tile;
			this.fileList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.FileList_ItemDrag);
			this.fileList.SelectedIndexChanged += new System.EventHandler(this.FileList_SelectedIndexChanged);
			this.fileList.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileList_DragDrop);
			this.fileList.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileList_DragEnter);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Width = 164;
			// 
			// mnuContext
			// 
			this.mnuContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniContextAdd,
            this.mniContextRemove,
            this.toolStripSeparator7,
            this.mniContextExtract});
			this.mnuContext.Name = "fileContext";
			this.mnuContext.Size = new System.Drawing.Size(188, 76);
			// 
			// mniContextAdd
			// 
			this.mniContextAdd.Name = "mniContextAdd";
			this.mniContextAdd.Size = new System.Drawing.Size(187, 22);
			this.mniContextAdd.Text = "Add a file...";
			this.mniContextAdd.Click += new System.EventHandler(this.MniContextAdd_Click);
			// 
			// mniContextRemove
			// 
			this.mniContextRemove.Enabled = false;
			this.mniContextRemove.Name = "mniContextRemove";
			this.mniContextRemove.Size = new System.Drawing.Size(187, 22);
			this.mniContextRemove.Text = "Remove selected files";
			this.mniContextRemove.Click += new System.EventHandler(this.MniContextRemove_Click);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(184, 6);
			// 
			// mniContextExtract
			// 
			this.mniContextExtract.Enabled = false;
			this.mniContextExtract.Name = "mniContextExtract";
			this.mniContextExtract.Size = new System.Drawing.Size(187, 22);
			this.mniContextExtract.Text = "Extract selected files";
			this.mniContextExtract.Click += new System.EventHandler(this.MniContextExtract_Click);
			// 
			// imlMain
			// 
			this.imlMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlMain.ImageStream")));
			this.imlMain.TransparentColor = System.Drawing.Color.Transparent;
			this.imlMain.Images.SetKeyName(0, "default.ico");
			this.imlMain.Images.SetKeyName(1, "h.ico");
			this.imlMain.Images.SetKeyName(2, "inc.ico");
			this.imlMain.Images.SetKeyName(3, "csv.ico");
			this.imlMain.Images.SetKeyName(4, "txt.ico");
			// 
			// mnuMain
			// 
			this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniFile,
            this.mniActions,
            this.mniHelp});
			this.mnuMain.Location = new System.Drawing.Point(0, 0);
			this.mnuMain.Name = "mnuMain";
			this.mnuMain.Size = new System.Drawing.Size(624, 24);
			this.mnuMain.TabIndex = 2;
			this.mnuMain.Text = "menuStrip1";
			// 
			// mniFile
			// 
			this.mniFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.mniFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniNew,
            this.mniOpen,
            this.toolStripSeparator2,
            this.mniSave,
            this.mniSaveAs,
            this.toolStripSeparator3,
            this.mniExit});
			this.mniFile.Name = "mniFile";
			this.mniFile.Size = new System.Drawing.Size(37, 20);
			this.mniFile.Text = "File";
			// 
			// mniNew
			// 
			this.mniNew.Name = "mniNew";
			this.mniNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.mniNew.Size = new System.Drawing.Size(184, 22);
			this.mniNew.Text = "New";
			this.mniNew.Click += new System.EventHandler(this.MniNew_Click);
			// 
			// mniOpen
			// 
			this.mniOpen.Name = "mniOpen";
			this.mniOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.mniOpen.Size = new System.Drawing.Size(184, 22);
			this.mniOpen.Text = "Open...";
			this.mniOpen.Click += new System.EventHandler(this.MniOpen_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(181, 6);
			// 
			// mniSave
			// 
			this.mniSave.Enabled = false;
			this.mniSave.Name = "mniSave";
			this.mniSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.mniSave.Size = new System.Drawing.Size(184, 22);
			this.mniSave.Text = "Save";
			this.mniSave.Click += new System.EventHandler(this.MniSave_Click);
			// 
			// mniSaveAs
			// 
			this.mniSaveAs.Name = "mniSaveAs";
			this.mniSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
			this.mniSaveAs.Size = new System.Drawing.Size(184, 22);
			this.mniSaveAs.Text = "Save as...";
			this.mniSaveAs.Click += new System.EventHandler(this.MniSaveAs_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(181, 6);
			// 
			// mniExit
			// 
			this.mniExit.Name = "mniExit";
			this.mniExit.Size = new System.Drawing.Size(184, 22);
			this.mniExit.Text = "Exit";
			this.mniExit.Click += new System.EventHandler(this.MniExit_Click);
			// 
			// mniActions
			// 
			this.mniActions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniAdd,
            this.mniRemove,
            this.toolStripSeparator6,
            this.mniExtract});
			this.mniActions.Name = "mniActions";
			this.mniActions.Size = new System.Drawing.Size(59, 20);
			this.mniActions.Text = "Actions";
			// 
			// mniAdd
			// 
			this.mniAdd.Name = "mniAdd";
			this.mniAdd.Size = new System.Drawing.Size(180, 22);
			this.mniAdd.Text = "Add";
			this.mniAdd.Click += new System.EventHandler(this.MniAdd_Click);
			// 
			// mniRemove
			// 
			this.mniRemove.Enabled = false;
			this.mniRemove.Name = "mniRemove";
			this.mniRemove.Size = new System.Drawing.Size(180, 22);
			this.mniRemove.Text = "Remove";
			this.mniRemove.Click += new System.EventHandler(this.MniRemove_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(177, 6);
			// 
			// mniExtract
			// 
			this.mniExtract.Enabled = false;
			this.mniExtract.Name = "mniExtract";
			this.mniExtract.Size = new System.Drawing.Size(180, 22);
			this.mniExtract.Text = "Extract";
			this.mniExtract.Click += new System.EventHandler(this.MniExtract_Click);
			// 
			// mniHelp
			// 
			this.mniHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniAbout});
			this.mniHelp.Name = "mniHelp";
			this.mniHelp.Size = new System.Drawing.Size(44, 20);
			this.mniHelp.Text = "Help";
			// 
			// mniAbout
			// 
			this.mniAbout.Name = "mniAbout";
			this.mniAbout.Size = new System.Drawing.Size(180, 22);
			this.mniAbout.Text = "About";
			this.mniAbout.Click += new System.EventHandler(this.MniAbout_Click);
			// 
			// stsMain
			// 
			this.stsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel1});
			this.stsMain.Location = new System.Drawing.Point(0, 422);
			this.stsMain.Name = "stsMain";
			this.stsMain.Size = new System.Drawing.Size(624, 22);
			this.stsMain.TabIndex = 3;
			this.stsMain.Text = "statusStrip1";
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(534, 17);
			this.toolStripStatusLabel2.Spring = true;
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(75, 17);
			this.toolStripStatusLabel1.Text = "© 2009 Exos ";
			// 
			// tspMain
			// 
			this.tspMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNew,
            this.tsbOpen,
            this.tsbSave,
            this.ag,
            this.tsbAdd,
            this.tsbRemove,
            this.toolStripSeparator5,
            this.tsbExtract,
            this.tsbResShortcut});
			this.tspMain.Location = new System.Drawing.Point(0, 24);
			this.tspMain.Name = "tspMain";
			this.tspMain.Size = new System.Drawing.Size(624, 25);
			this.tspMain.TabIndex = 4;
			this.tspMain.Text = "toolStrip1";
			// 
			// tsbNew
			// 
			this.tsbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbNew.Image")));
			this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbNew.Name = "tsbNew";
			this.tsbNew.Size = new System.Drawing.Size(23, 22);
			this.tsbNew.Text = "New";
			this.tsbNew.Click += new System.EventHandler(this.TsbNew_Click);
			// 
			// tsbOpen
			// 
			this.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpen.Image")));
			this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbOpen.Name = "tsbOpen";
			this.tsbOpen.Size = new System.Drawing.Size(23, 22);
			this.tsbOpen.Text = "Open";
			this.tsbOpen.Click += new System.EventHandler(this.TsbOpen_Click);
			// 
			// tsbSave
			// 
			this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbSave.Enabled = false;
			this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
			this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbSave.Name = "tsbSave";
			this.tsbSave.Size = new System.Drawing.Size(23, 22);
			this.tsbSave.Text = "Save";
			this.tsbSave.Click += new System.EventHandler(this.TsbSave_Click);
			// 
			// ag
			// 
			this.ag.Name = "ag";
			this.ag.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbAdd
			// 
			this.tsbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbAdd.Image")));
			this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbAdd.Name = "tsbAdd";
			this.tsbAdd.Size = new System.Drawing.Size(23, 22);
			this.tsbAdd.Text = "Add a file";
			this.tsbAdd.Click += new System.EventHandler(this.TsbAdd_Click);
			// 
			// tsbRemove
			// 
			this.tsbRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbRemove.Enabled = false;
			this.tsbRemove.Image = ((System.Drawing.Image)(resources.GetObject("tsbRemove.Image")));
			this.tsbRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbRemove.Name = "tsbRemove";
			this.tsbRemove.Size = new System.Drawing.Size(23, 22);
			this.tsbRemove.Text = "Remove selected files";
			this.tsbRemove.Click += new System.EventHandler(this.TsbRemove_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbExtract
			// 
			this.tsbExtract.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbExtract.Enabled = false;
			this.tsbExtract.Image = ((System.Drawing.Image)(resources.GetObject("tsbExtract.Image")));
			this.tsbExtract.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbExtract.Name = "tsbExtract";
			this.tsbExtract.Size = new System.Drawing.Size(23, 22);
			this.tsbExtract.Text = "Extract selected files";
			this.tsbExtract.Click += new System.EventHandler(this.TsbExtract_Click);
			// 
			// tsbResShortcut
			// 
			this.tsbResShortcut.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbResShortcut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbResShortcut.Image = ((System.Drawing.Image)(resources.GetObject("tsbResShortcut.Image")));
			this.tsbResShortcut.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbResShortcut.Name = "tsbResShortcut";
			this.tsbResShortcut.Size = new System.Drawing.Size(23, 22);
			this.tsbResShortcut.Text = "Drag this shortcut to live create the .res file";
			this.tsbResShortcut.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ResShortcut_MouseMove);
			// 
			// ResEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 444);
			this.Controls.Add(this.tspMain);
			this.Controls.Add(this.stsMain);
			this.Controls.Add(this.mnuMain);
			this.Controls.Add(this.fileList);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.mnuMain;
			this.Name = "ResEditor";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Flyff ResEditor";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ResEditor_FormClosing);
			this.Load += new System.EventHandler(this.ResEditor_Load);
			this.mnuContext.ResumeLayout(false);
			this.mnuMain.ResumeLayout(false);
			this.mnuMain.PerformLayout();
			this.stsMain.ResumeLayout(false);
			this.stsMain.PerformLayout();
			this.tspMain.ResumeLayout(false);
			this.tspMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView fileList;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ImageList imlMain;
		private System.Windows.Forms.ContextMenuStrip mnuContext;
		private System.Windows.Forms.ToolStripMenuItem mniContextExtract;
		private System.Windows.Forms.MenuStrip mnuMain;
		private System.Windows.Forms.ToolStripMenuItem mniFile;
		private System.Windows.Forms.ToolStripMenuItem mniOpen;
		private System.Windows.Forms.ToolStripMenuItem mniActions;
		private System.Windows.Forms.ToolStripMenuItem mniExit;
		private System.Windows.Forms.ToolStripMenuItem mniNew;
		private System.Windows.Forms.StatusStrip stsMain;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripMenuItem mniSaveAs;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem mniSave;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStrip tspMain;
		private System.Windows.Forms.ToolStripButton tsbNew;
		private System.Windows.Forms.ToolStripButton tsbOpen;
		private System.Windows.Forms.ToolStripButton tsbSave;
		private System.Windows.Forms.ToolStripSeparator ag;
		private System.Windows.Forms.ToolStripButton tsbRemove;
		private System.Windows.Forms.ToolStripButton tsbAdd;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripButton tsbExtract;
		private System.Windows.Forms.ToolStripMenuItem mniHelp;
		private System.Windows.Forms.ToolStripMenuItem mniAbout;
		private System.Windows.Forms.ToolStripButton tsbResShortcut;
		private System.Windows.Forms.ToolStripMenuItem mniAdd;
		private System.Windows.Forms.ToolStripMenuItem mniRemove;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripMenuItem mniExtract;
		private System.Windows.Forms.ToolStripMenuItem mniContextAdd;
		private System.Windows.Forms.ToolStripMenuItem mniContextRemove;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
	}
}
