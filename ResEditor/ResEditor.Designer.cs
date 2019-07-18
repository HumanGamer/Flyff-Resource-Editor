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
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Autres", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Fichiers header (*.h)", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Fichiers include (*.inc)", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Fichiers base de donnée CSV (*.csv)", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Fichiers texte (*.txt)", System.Windows.Forms.HorizontalAlignment.Left);
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResEditor));
			this.fileList = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.fileContext = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.extraireVersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.nouveauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ouvrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.enregistrerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.enregistrerSousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.fermerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ajouterUnFichieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.supprimerLesFicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.extraireLaSélectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.aProposDeFlyffResEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.but_new = new System.Windows.Forms.ToolStripButton();
			this.but_open = new System.Windows.Forms.ToolStripButton();
			this.but_save = new System.Windows.Forms.ToolStripButton();
			this.ag = new System.Windows.Forms.ToolStripSeparator();
			this.but_add = new System.Windows.Forms.ToolStripButton();
			this.but_del = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.but_extract = new System.Windows.Forms.ToolStripButton();
			this.resShortcut = new System.Windows.Forms.ToolStripButton();
			this.fileContext.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
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
			this.fileList.ContextMenuStrip = this.fileContext;
			listViewGroup1.Header = "Autres";
			listViewGroup1.Name = "other_files";
			listViewGroup2.Header = "Fichiers header (*.h)";
			listViewGroup2.Name = "h_files";
			listViewGroup3.Header = "Fichiers include (*.inc)";
			listViewGroup3.Name = "inc_files";
			listViewGroup4.Header = "Fichiers base de donnée CSV (*.csv)";
			listViewGroup4.Name = "csv_files";
			listViewGroup5.Header = "Fichiers texte (*.txt)";
			listViewGroup5.Name = "txt_files";
			this.fileList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4,
            listViewGroup5});
			this.fileList.HideSelection = false;
			this.fileList.LargeImageList = this.imageList1;
			this.fileList.Location = new System.Drawing.Point(-1, 49);
			this.fileList.Name = "fileList";
			this.fileList.Size = new System.Drawing.Size(626, 374);
			this.fileList.SmallImageList = this.imageList1;
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
			// fileContext
			// 
			this.fileContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripSeparator7,
            this.extraireVersToolStripMenuItem1});
			this.fileContext.Name = "fileContext";
			this.fileContext.Size = new System.Drawing.Size(188, 76);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(187, 22);
			this.toolStripMenuItem2.Text = "Add a file...";
			this.toolStripMenuItem2.Click += new System.EventHandler(this.ToolStripMenuItem2_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Enabled = false;
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(187, 22);
			this.toolStripMenuItem3.Text = "Remove selected files";
			this.toolStripMenuItem3.Click += new System.EventHandler(this.ToolStripMenuItem3_Click);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(184, 6);
			// 
			// extraireVersToolStripMenuItem1
			// 
			this.extraireVersToolStripMenuItem1.Enabled = false;
			this.extraireVersToolStripMenuItem1.Name = "extraireVersToolStripMenuItem1";
			this.extraireVersToolStripMenuItem1.Size = new System.Drawing.Size(187, 22);
			this.extraireVersToolStripMenuItem1.Text = "Extract selected files";
			this.extraireVersToolStripMenuItem1.Click += new System.EventHandler(this.ExtraireVersToolStripMenuItem1_Click);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "default.ico");
			this.imageList1.Images.SetKeyName(1, "h.ico");
			this.imageList1.Images.SetKeyName(2, "inc.ico");
			this.imageList1.Images.SetKeyName(3, "csv.ico");
			this.imageList1.Images.SetKeyName(4, "txt.ico");
			// 
			// folderBrowserDialog1
			// 
			this.folderBrowserDialog1.Description = "Veuillez sélectionner le dossier dans lequel les fichiers précedements sélectionn" +
    "és seront extraits";
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.actionsToolStripMenuItem,
            this.toolStripMenuItem1});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(624, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuStrip1_ItemClicked);
			// 
			// fichierToolStripMenuItem
			// 
			this.fichierToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nouveauToolStripMenuItem,
            this.ouvrirToolStripMenuItem,
            this.toolStripSeparator2,
            this.enregistrerToolStripMenuItem,
            this.enregistrerSousToolStripMenuItem,
            this.toolStripSeparator3,
            this.fermerToolStripMenuItem,
            this.toolStripSeparator1,
            this.quitterToolStripMenuItem});
			this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
			this.fichierToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fichierToolStripMenuItem.Text = "File";
			// 
			// nouveauToolStripMenuItem
			// 
			this.nouveauToolStripMenuItem.Name = "nouveauToolStripMenuItem";
			this.nouveauToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.nouveauToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.nouveauToolStripMenuItem.Text = "New";
			this.nouveauToolStripMenuItem.Click += new System.EventHandler(this.NouveauToolStripMenuItem_Click);
			// 
			// ouvrirToolStripMenuItem
			// 
			this.ouvrirToolStripMenuItem.Name = "ouvrirToolStripMenuItem";
			this.ouvrirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.ouvrirToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.ouvrirToolStripMenuItem.Text = "Open...";
			this.ouvrirToolStripMenuItem.Click += new System.EventHandler(this.OuvrirToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(152, 6);
			// 
			// enregistrerToolStripMenuItem
			// 
			this.enregistrerToolStripMenuItem.Enabled = false;
			this.enregistrerToolStripMenuItem.Name = "enregistrerToolStripMenuItem";
			this.enregistrerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.enregistrerToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.enregistrerToolStripMenuItem.Text = "Save";
			this.enregistrerToolStripMenuItem.Click += new System.EventHandler(this.EnregistrerToolStripMenuItem_Click);
			// 
			// enregistrerSousToolStripMenuItem
			// 
			this.enregistrerSousToolStripMenuItem.Name = "enregistrerSousToolStripMenuItem";
			this.enregistrerSousToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.enregistrerSousToolStripMenuItem.Text = "Save as...";
			this.enregistrerSousToolStripMenuItem.Click += new System.EventHandler(this.EnregistrerSousToolStripMenuItem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(152, 6);
			// 
			// fermerToolStripMenuItem
			// 
			this.fermerToolStripMenuItem.Enabled = false;
			this.fermerToolStripMenuItem.Name = "fermerToolStripMenuItem";
			this.fermerToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.fermerToolStripMenuItem.Text = "Close";
			this.fermerToolStripMenuItem.Click += new System.EventHandler(this.FermerToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
			// 
			// quitterToolStripMenuItem
			// 
			this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
			this.quitterToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.quitterToolStripMenuItem.Text = "Exit";
			this.quitterToolStripMenuItem.Click += new System.EventHandler(this.QuitterToolStripMenuItem_Click);
			// 
			// actionsToolStripMenuItem
			// 
			this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterUnFichieToolStripMenuItem,
            this.supprimerLesFicToolStripMenuItem,
            this.toolStripSeparator6,
            this.extraireLaSélectionToolStripMenuItem});
			this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
			this.actionsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
			this.actionsToolStripMenuItem.Text = "Actions";
			// 
			// ajouterUnFichieToolStripMenuItem
			// 
			this.ajouterUnFichieToolStripMenuItem.Name = "ajouterUnFichieToolStripMenuItem";
			this.ajouterUnFichieToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
			this.ajouterUnFichieToolStripMenuItem.Text = "Add a file...";
			this.ajouterUnFichieToolStripMenuItem.Click += new System.EventHandler(this.AjouterUnFichieToolStripMenuItem_Click);
			// 
			// supprimerLesFicToolStripMenuItem
			// 
			this.supprimerLesFicToolStripMenuItem.Enabled = false;
			this.supprimerLesFicToolStripMenuItem.Name = "supprimerLesFicToolStripMenuItem";
			this.supprimerLesFicToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
			this.supprimerLesFicToolStripMenuItem.Text = "Remove selected files";
			this.supprimerLesFicToolStripMenuItem.Click += new System.EventHandler(this.SupprimerLesFicToolStripMenuItem_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(186, 6);
			// 
			// extraireLaSélectionToolStripMenuItem
			// 
			this.extraireLaSélectionToolStripMenuItem.Enabled = false;
			this.extraireLaSélectionToolStripMenuItem.Name = "extraireLaSélectionToolStripMenuItem";
			this.extraireLaSélectionToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
			this.extraireLaSélectionToolStripMenuItem.Text = "Extract selected files...";
			this.extraireLaSélectionToolStripMenuItem.Click += new System.EventHandler(this.ExtraireLaSélectionToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aProposDeFlyffResEditorToolStripMenuItem});
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
			this.toolStripMenuItem1.Text = "?";
			// 
			// aProposDeFlyffResEditorToolStripMenuItem
			// 
			this.aProposDeFlyffResEditorToolStripMenuItem.Name = "aProposDeFlyffResEditorToolStripMenuItem";
			this.aProposDeFlyffResEditorToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.aProposDeFlyffResEditorToolStripMenuItem.Text = "About Flyff ResEditor";
			this.aProposDeFlyffResEditorToolStripMenuItem.Click += new System.EventHandler(this.AProposDeFlyffResEditorToolStripMenuItem_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 422);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(624, 22);
			this.statusStrip1.TabIndex = 3;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(537, 17);
			this.toolStripStatusLabel2.Spring = true;
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(72, 17);
			this.toolStripStatusLabel1.Text = "Exos © 2009";
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.but_new,
            this.but_open,
            this.but_save,
            this.ag,
            this.but_add,
            this.but_del,
            this.toolStripSeparator5,
            this.but_extract,
            this.resShortcut});
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(624, 25);
			this.toolStrip1.TabIndex = 4;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// but_new
			// 
			this.but_new.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.but_new.Image = ((System.Drawing.Image)(resources.GetObject("but_new.Image")));
			this.but_new.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.but_new.Name = "but_new";
			this.but_new.Size = new System.Drawing.Size(23, 22);
			this.but_new.Text = "New";
			this.but_new.Click += new System.EventHandler(this.But_new_Click);
			// 
			// but_open
			// 
			this.but_open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.but_open.Image = ((System.Drawing.Image)(resources.GetObject("but_open.Image")));
			this.but_open.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.but_open.Name = "but_open";
			this.but_open.Size = new System.Drawing.Size(23, 22);
			this.but_open.Text = "Open";
			this.but_open.Click += new System.EventHandler(this.But_open_Click);
			// 
			// but_save
			// 
			this.but_save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.but_save.Enabled = false;
			this.but_save.Image = ((System.Drawing.Image)(resources.GetObject("but_save.Image")));
			this.but_save.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.but_save.Name = "but_save";
			this.but_save.Size = new System.Drawing.Size(23, 22);
			this.but_save.Text = "Save";
			this.but_save.Click += new System.EventHandler(this.But_save_Click);
			// 
			// ag
			// 
			this.ag.Name = "ag";
			this.ag.Size = new System.Drawing.Size(6, 25);
			// 
			// but_add
			// 
			this.but_add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.but_add.Image = ((System.Drawing.Image)(resources.GetObject("but_add.Image")));
			this.but_add.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.but_add.Name = "but_add";
			this.but_add.Size = new System.Drawing.Size(23, 22);
			this.but_add.Text = "Add a file";
			this.but_add.Click += new System.EventHandler(this.But_add_Click);
			// 
			// but_del
			// 
			this.but_del.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.but_del.Enabled = false;
			this.but_del.Image = ((System.Drawing.Image)(resources.GetObject("but_del.Image")));
			this.but_del.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.but_del.Name = "but_del";
			this.but_del.Size = new System.Drawing.Size(23, 22);
			this.but_del.Text = "Remove selected files";
			this.but_del.Click += new System.EventHandler(this.But_del_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
			// 
			// but_extract
			// 
			this.but_extract.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.but_extract.Enabled = false;
			this.but_extract.Image = ((System.Drawing.Image)(resources.GetObject("but_extract.Image")));
			this.but_extract.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.but_extract.Name = "but_extract";
			this.but_extract.Size = new System.Drawing.Size(23, 22);
			this.but_extract.Text = "Extract selected files";
			this.but_extract.Click += new System.EventHandler(this.But_extract_Click);
			// 
			// resShortcut
			// 
			this.resShortcut.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.resShortcut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.resShortcut.Image = ((System.Drawing.Image)(resources.GetObject("resShortcut.Image")));
			this.resShortcut.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.resShortcut.Name = "resShortcut";
			this.resShortcut.Size = new System.Drawing.Size(23, 22);
			this.resShortcut.Text = "Drag this shortcut to live create the .res file";
			this.resShortcut.Click += new System.EventHandler(this.ResShortcut_Click);
			this.resShortcut.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ResShortcut_MouseMove);
			// 
			// ResEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 444);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.fileList);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "ResEditor";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Flyff ResEditor";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ResEditor_FormClosing);
			this.Load += new System.EventHandler(this.ResEditor_Load);
			this.fileContext.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView fileList;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ContextMenuStrip fileContext;
		private System.Windows.Forms.ToolStripMenuItem extraireVersToolStripMenuItem1;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ouvrirToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fermerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem nouveauToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripMenuItem enregistrerSousToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem enregistrerToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton but_new;
		private System.Windows.Forms.ToolStripButton but_open;
		private System.Windows.Forms.ToolStripButton but_save;
		private System.Windows.Forms.ToolStripSeparator ag;
		private System.Windows.Forms.ToolStripButton but_del;
		private System.Windows.Forms.ToolStripButton but_add;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripButton but_extract;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem aProposDeFlyffResEditorToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton resShortcut;
		private System.Windows.Forms.ToolStripMenuItem ajouterUnFichieToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem supprimerLesFicToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripMenuItem extraireLaSélectionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
	}
}
