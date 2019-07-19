using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ResEditor
{
	public partial class ResEditor : Form
	{
		private ResourceFile _currentFile;

		private string _currentPath;

		private bool _dirty;

		private bool Dirty
		{
			get
			{
				return _dirty;
			}
			set
			{
				_dirty = value;

				mniSave.Enabled = value;
				tsbSave.Enabled = value;
			}
		}

		public ResEditor()
		{
			InitializeComponent();

			UpdateDisplay();
		}

		private void UpdateDisplay()
		{
			if (this._currentFile == null)
			{
				Text = "Flyff ResEditor";
				fileList.Enabled = false;
				mniAdd.Enabled = false;
				tsbAdd.Enabled = false;
				mniSave.Enabled = false;
				mniSaveAs.Enabled = false;
				Dirty = false;
				return;
			}

			fileList.Enabled = true;
			mniAdd.Enabled = true;
			tsbAdd.Enabled = true;
			mniSaveAs.Enabled = true;

			if (string.IsNullOrWhiteSpace(_currentPath))
				Text = "Untitled - Flyff ResEditor";
			else
				Text = Path.GetFileName(this._currentPath) + " - Flyff ResEditor";

			this.fileList.Items.Clear();

			for (int i = 0; i < this._currentFile.Count; i++)
			{
				var entry = this._currentFile[i];

				string name = entry.FileName;
				int imgIndex = GetImageIndex(name);

				ListViewItem listViewItem = this.fileList.Items.Add(name);
				listViewItem.SubItems.Add(GetCalculatedSizeLabel(entry.FileSize));
				listViewItem.ImageIndex = imgIndex;
				this.fileList.Groups[imgIndex].Items.Add(listViewItem);
			}
		}

		private bool CheckDirty()
		{
			if (Dirty)
			{
				switch (MessageBox.Show("The resource has been modified.\n\nDo you want to save your changes?", "Flyff ResEditor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
				{
					case DialogResult.Cancel:
						return true;
					case DialogResult.No:
						return false;
					case DialogResult.Yes:
						return !Save();
				}
			}

			return false;
		}

		private void New()
		{
			if (CheckDirty())
				return;

			_currentFile = new ResourceFile();
			_currentPath = null;

			Dirty = false;

			UpdateDisplay();
		}

		private void Open()
		{
			if (CheckDirty())
				return;

			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Flyff Resource Files|*.res|All Files|*.*";
			ofd.Multiselect = false;

			if (ofd.ShowDialog() == DialogResult.Cancel || string.IsNullOrWhiteSpace(ofd.FileName))
				return;

			Open(ofd.FileName);
		}

		public void Open(string path)
		{
			if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
				return;

			this._currentFile = ResourceFile.Open(path);
			this._currentPath = path;

			Dirty = false;

			UpdateDisplay();
		}

		private bool Save()
		{
			if (string.IsNullOrWhiteSpace(this._currentPath))
			{
				return SaveAs();
			}
			this._currentFile.Save(this._currentPath);
			mniSave.Enabled = false;
			tsbSave.Enabled = false;
			Dirty = false;

			return true;
		}

		private bool SaveAs()
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "Flyff Resources Files|*.res|All Files|*.*";

			if (this._currentFile != null && this._currentPath != null)
				sfd.FileName = Path.GetFileName(this._currentPath);

			if (sfd.ShowDialog() == DialogResult.Cancel)
				return false;

			this._currentFile.Save(sfd.FileName);
			this._currentPath = sfd.FileName;
			Dirty = false;

			UpdateDisplay();

			return true;
		}

		private void Exit()
		{
			if (CheckDirty())
				return;
			Environment.Exit(0);
		}

		private void AddFile()
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "All Files|*.*";
			ofd.Multiselect = true;
			if (ofd.ShowDialog() == DialogResult.Cancel)
				return;

			AddFileCheckReplace(ofd.FileNames);
		}

		public void AddFileCheckReplace(params string[] paths)
		{
			foreach (string text in paths)
			{
				string fileName = Path.GetFileName(text);

				// Entry already exists
				if (!this._currentFile.Contains(fileName)
					|| (this._currentFile.Contains(fileName) &&
						MessageBox.Show(fileName + "\nA file with the same name already exists. Do you want to replace it?", "Flyff ResEditor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
					AddFileInternal(text);
			}
		}

		private void AddFileInternal(string path)
		{
			try
			{
				this._currentFile.AddFile(path);
			}
			catch (IOException ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			Dirty = true;

			UpdateDisplay();
		}

		private void RemoveFile()
		{
			foreach (int selectedIndex in this.fileList.SelectedIndices)
			{
				this.fileList.Items[selectedIndex].Remove();
				this._currentFile.Remove(selectedIndex);
			}
			Dirty = true;
		}

		private void ExtractFile()
		{
			if (this.fileList.SelectedItems.Count == 1)
			{
				string text = this.fileList.SelectedItems[0].Text;

				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Filter = GetFilter(text);
				sfd.FileName = text;
				if (sfd.ShowDialog() != DialogResult.Cancel)
					this._currentFile.ExtractFile(this.fileList.SelectedIndices[0], sfd.FileName);
			}
			else
			{
				FolderBrowserDialog fbd = new FolderBrowserDialog();
				if (fbd.ShowDialog() != DialogResult.Cancel)
				{
					foreach (int selectedIndex in this.fileList.SelectedIndices)
					{
						this._currentFile.ExtractFile(selectedIndex, Path.Combine(fbd.SelectedPath, this._currentFile[selectedIndex].FileName));
					}
				}
			}
		}

		private void ShowAbout()
		{
			MessageBox.Show(this, "This program is © 2009 Exos.\nContact me on RageZone or use my personal e-mail address if you have it.", "About Flyff ResEditor", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void OnDragShortcut()
		{
			if (this._currentFile != null)
			{
				string path = Path.GetTempPath() + "\\FlyffResEditor\\" + ((this._currentPath == null) ? "Untitled.res" : Path.GetFileName(this._currentPath));

				this._currentFile.Save(path);
				DoDragDrop(new DataObject(DataFormats.FileDrop, new[] { path }), DragDropEffects.Copy | DragDropEffects.Move);
			}
		}

		private void OnAppStarting()
		{
			Directory.CreateDirectory(Path.GetTempPath() + "\\FlyffResEditor\\");
		}

		private bool OnAppClosing()
		{
			return !CheckDirty();
		}

		private void OnSelectFile()
		{
			bool hasEntries = this.fileList.SelectedItems.Count > 0;

			tsbRemove.Enabled = hasEntries;
			tsbExtract.Enabled = hasEntries;
			mniRemove.Enabled = hasEntries;
			mniExtract.Enabled = hasEntries;
			this.mniContextExtract.Enabled = hasEntries;
			mniContextRemove.Enabled = hasEntries;
			mniContextAdd.Enabled = !hasEntries;
		}

		private void OnItemDrag()
		{
			if (this.fileList.SelectedItems.Count > 0)
			{
				string[] array = new string[this.fileList.SelectedItems.Count];
				for (int i = 0; i < this.fileList.SelectedItems.Count; i++)
				{
					array[i] = Path.GetTempPath() + "\\FlyffResEditor\\" + this._currentFile[this.fileList.SelectedIndices[i]].FileName;
					this._currentFile.ExtractFile(this.fileList.SelectedIndices[i], array[i]);
				}

				DoDragDrop(new DataObject(DataFormats.FileDrop, array), DragDropEffects.Copy | DragDropEffects.Move);
			}
		}

		private bool IsDraggableData(IDataObject data)
		{
			return data.GetDataPresent(DataFormats.FileDrop);
		}

		private void OnFileDragged(IDataObject data)
		{
			string[] array = (string[])data.GetData(DataFormats.FileDrop, false);

			AddFileCheckReplace(array);
		}

		private int GetImageIndex(string filename)
		{
			switch (Path.GetExtension(filename))
			{
				case "h":
					return 1;
				case "inc":
					return 2;
				case "csv":
					return 3;
				case "txt":
					return 4;
				default:
					return 0;
			}
		}

		private string GetFilter(string filename)
		{
			switch (Path.GetExtension(filename))
			{
				case "inc":
					return "Include Files (*.inc)|*.inc";
				case "h":
					return "Header Files (*.h)|*.h";
				case "csv":
					return "Comma Separated Value Files (*.csv)|*.csv";
				case "txt":
					return "Text Files (*.txt)|*.txt";
				default:
					return "All Files|*.*";
			}
		}

		private string GetCalculatedSizeLabel(long size)
		{
			string str = "";

			long dataType;
			for (dataType = 0L; size / (int)Math.Pow(1024.0, dataType) > 1023; dataType++) ;

			if (dataType <= 4 && dataType >= 0)
			{
				switch (dataType)
				{
					case 0L:
						str = " Bytes";
						break;
					case 1L:
						str = " KB";
						break;
					case 2L:
						str = " MB";
						break;
					case 3L:
						str = " GB";
						break;
					case 4L:
						str = " TB";
						break;
				}
			}

			return (Math.Round((double)(100 * size / (int)Math.Pow(1024.0, dataType))) / 100.0).ToString() + str;
		}

		#region Event Handlers

		private void MniNew_Click(object A_0, EventArgs A_1)
		{
			New();
		}

		private void MniOpen_Click(object A_0, EventArgs A_1)
		{
			Open();
		}

		private void MniSave_Click(object A_0, EventArgs A_1)
		{
			Save();
		}

		private void MniSaveAs_Click(object A_0, EventArgs A_1)
		{
			SaveAs();
		}

		private void MniExit_Click(object A_0, EventArgs A_1)
		{
			Exit();
		}

		private void MniAdd_Click(object A_0, EventArgs A_1)
		{
			AddFile();
		}

		private void MniRemove_Click(object A_0, EventArgs A_1)
		{
			RemoveFile();
		}

		private void MniExtract_Click(object A_0, EventArgs A_1)
		{
			ExtractFile();
		}

		private void MniAbout_Click(object A_0, EventArgs A_1)
		{
			ShowAbout();
		}

		private void TsbNew_Click(object A_0, EventArgs A_1)
		{
			New();
		}

		private void TsbOpen_Click(object A_0, EventArgs A_1)
		{
			Open();
		}

		private void TsbSave_Click(object A_0, EventArgs A_1)
		{
			Save();
		}

		private void TsbAdd_Click(object A_0, EventArgs A_1)
		{
			AddFile();
		}

		private void TsbRemove_Click(object A_0, EventArgs A_1)
		{
			RemoveFile();
		}

		private void TsbExtract_Click(object A_0, EventArgs A_1)
		{
			ExtractFile();
		}

		private void MniContextAdd_Click(object A_0, EventArgs A_1)
		{
			AddFile();
		}

		private void MniContextRemove_Click(object A_0, EventArgs A_1)
		{
			RemoveFile();
		}

		private void MniContextExtract_Click(object A_0, EventArgs A_1)
		{
			ExtractFile();
		}

		private void ResEditor_Load(object A_0, EventArgs A_1)
		{
			OnAppStarting();
		}

		private void ResEditor_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!OnAppClosing())
				e.Cancel = true;
		}

		private void FileList_SelectedIndexChanged(object A_0, EventArgs A_1)
		{
			OnSelectFile();
		}

		private void FileList_ItemDrag(object A_0, ItemDragEventArgs A_1)
		{
			OnItemDrag();
		}

		private void FileList_DragEnter(object sender, DragEventArgs e)
		{
			if (IsDraggableData(e.Data))
				e.Effect = DragDropEffects.Copy;
		}

		private void FileList_DragDrop(object sender, DragEventArgs e)
		{
			OnFileDragged(e.Data);
		}

		private void ResShortcut_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
				OnDragShortcut();
		}

		#endregion
	}
}
