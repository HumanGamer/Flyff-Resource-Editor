using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ResEditor
{
	public partial class ResEditor : Form
	{
		public string[] args;
		private ResourceFile _currentFile;
		private string _currentPath;
		private bool _dirty;

		public ResEditor()
		{
			InitializeComponent();
		}

		private void UpdateDisplay()
		{
			if (this._currentFile == null)
			{
				Text = "Flyff ResEditor";
				return;
			}

			if (string.IsNullOrWhiteSpace(_currentPath))
				Text = "Untitled - Flyff ResEditor";
			else
				Text = Path.GetFileName(this._currentPath) + " - Flyff ResEditor";

			this.fileList.Items.Clear();

			for (int i = 0; i < this._currentFile.Entries.Length; i++)
			{
				string text = this._currentFile.Entries[i].FileName;

				int imgIndex = GetImageIndex(text);

				ListViewItem listViewItem = this.fileList.Items.Add(text);
				listViewItem.SubItems.Add(GetSizeString(this._currentFile.Entries[i].FileSize));
				listViewItem.ImageIndex = imgIndex;
				this.fileList.Groups[imgIndex].Items.Add(listViewItem);
			}
			this.mniClose.Enabled = true;
		}

		private bool CheckDirty()
		{
			if (this._dirty)
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
			Process process = new Process();
			process.StartInfo.FileName = Application.ExecutablePath;
			process.Start();
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
			this._currentFile = new ResourceFile(path);
			this._currentPath = path;

			this._dirty = false;

			UpdateDisplay();
		}

		private bool Save()
		{
			if (this._currentFile == null || this._currentPath == null)
			{
				return SaveAs();
			}
			this._currentFile.Save(this._currentPath);
			mniSave.Enabled = false;
			tsbSave.Enabled = false;
			this._dirty = false;

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
			//Text = sfd.FileName.Substring(sfd.FileName.LastIndexOf('\\') + 1) + " - Flyff ResEditor";
			mniSave.Enabled = false;
			tsbSave.Enabled = false;
			this._dirty = false;

			UpdateDisplay();

			return true;
		}

		private void CloseFile()
		{
			if (CheckDirty())
				return;
			mniSave.Enabled = false;
			tsbSave.Enabled = false;
			this._dirty = false;
			this._currentFile = null;
			Text = "Flyff ResEditor";
			this.fileList.Items.Clear();
			this.mniClose.Enabled = false;
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

			if (this._currentFile == null)
				this._currentFile = new ResourceFile();

			string[] fileNames = ofd.FileNames;
			foreach (string text in fileNames)
			{
				int existingIndex = -1;
				bool cancel = false;

				if (this._currentFile.Entries != null)
				{
					for (int j = 0; j < this._currentFile.Entries.Length; j++)
					{
						if (this._currentFile.Entries[j].FileName == Path.GetFileName(text))
						{
							existingIndex = j;
						}
					}
				}

				if (existingIndex >= 0)
				{
					if (MessageBox.Show(this._currentFile.Entries[existingIndex].FileName + "\nA file with the same name already exists. Do you want to replace it?", "Flyff ResEditor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
					{
						cancel = true;
					}
					else
					{
						this.fileList.Items[existingIndex].Remove();
						this._currentFile.Remove(existingIndex);
					}
				}

				if (!cancel)
				{
					this._currentFile.AddFile(text);

					this.mniClose.Enabled = true;
					mniSave.Enabled = true;
					tsbSave.Enabled = true;
					this._dirty = true;

					UpdateDisplay();
				}
			}
		}

		private void RemoveFile()
		{
			foreach (int selectedIndex in this.fileList.SelectedIndices)
			{
				this.fileList.Items[selectedIndex].Remove();
				this._currentFile.Remove(selectedIndex);
			}
			this._dirty = true;
			mniSave.Enabled = true;
			tsbSave.Enabled = true;
		}

		private void ExtractFile()
		{
			if (this.fileList.SelectedItems.Count == 1)
			{
				string text = this.fileList.SelectedItems[0].Text;

				this.saveFileDialog1.Filter = GetFilter(text);
				this.saveFileDialog1.FileName = text;
				if (this.saveFileDialog1.ShowDialog() != DialogResult.Cancel)
				{
					this._currentFile.ExtractFile(this.fileList.SelectedIndices[0], this.saveFileDialog1.FileName);
				}
			}
			else if (this.folderBrowserDialog1.ShowDialog() != DialogResult.Cancel)
			{
				foreach (int selectedIndex in this.fileList.SelectedIndices)
				{
					this._currentFile.ExtractFile(selectedIndex, this.folderBrowserDialog1.SelectedPath + "\\" + this._currentFile.Entries[selectedIndex].FileName);
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
				string path = Path.GetTempPath() + "\\FlyffResEditor\\" + ((this._currentPath == null) ? "NewRes.res" : Path.GetFileName(this._currentPath));

				this._currentFile.Save(path);
				DoDragDrop(new DataObject(DataFormats.FileDrop, new[] { path }), DragDropEffects.Copy | DragDropEffects.Move);
			}
		}

		private void OnAppStarting()
		{
			Directory.CreateDirectory(Path.GetTempPath() + "\\FlyffResEditor\\");
			if (this.args.Length <= 0 || !File.Exists(this.args[0]))
				return;

			Open(this.args[0]);

			UpdateDisplay();
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
					array[i] = Path.GetTempPath() + "\\FlyffResEditor\\" + this._currentFile.Entries[this.fileList.SelectedIndices[i]].FileName;
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
			if (this._currentFile == null)
			{
				this._currentFile = new ResourceFile();
			}

			string[] array = (string[])data.GetData(DataFormats.FileDrop, false);
			string[] array2 = array;
			foreach (string text in array2)
			{
				int num = -1;
				bool flag = false;
				if (this._currentFile.Entries != null)
				{
					for (int j = 0; j < this._currentFile.Entries.Length; j++)
					{
						if (this._currentFile.Entries[j].FileName == text.Substring(text.LastIndexOf('\\') + 1))
						{
							num = j;
						}
					}
				}
				if (num >= 0)
				{
					if (MessageBox.Show(this._currentFile.Entries[num].FileName + "\nA file with the same name already exists. Do you want to replace it ?", "Flyff ResEditor", MessageBoxButtons.YesNo) == DialogResult.No)
					{
						flag = true;
					}
					else
					{
						this.fileList.Items[num].Remove();
						this._currentFile.Remove(num);
					}
				}
				if (!flag)
				{
					this._currentFile.AddFile(text);
					int imgIndex = GetImageIndex(this._currentFile.Entries[(int)this._currentFile.Entries.LongLength - 1].FileName);
					ListViewItem listViewItem = this.fileList.Items.Add(this._currentFile.Entries[this._currentFile.Entries.Length - 1].FileName);
					listViewItem.SubItems.Add(GetSizeString(this._currentFile.Entries[this._currentFile.Entries.Length - 1].FileSize));
					listViewItem.ImageIndex = imgIndex;
					this.fileList.Groups[imgIndex].Items.Add(listViewItem);
				}
			}

			this._dirty = true;
			this.mniClose.Enabled = true;
			mniSave.Enabled = true;
			tsbSave.Enabled = true;
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

		private string GetSizeString(long size)
		{
			string str = "";
			long num;
			for (num = 0L; size / (int)Math.Pow(1024.0, num) > 1023; num++)
			{
			}
			long num2 = num;
			if (num2 <= 4 && num2 >= 0)
			{
				switch (num2)
				{
					case 0L:
						str = " b";
						break;
					case 1L:
						str = " Kb";
						break;
					case 2L:
						str = " Mb";
						break;
					case 3L:
						str = " Gb";
						break;
					case 4L:
						str = " Tb";
						break;
				}
			}
			return (Math.Round((double)(100 * size / (int)Math.Pow(1024.0, num))) / 100.0).ToString() + str;
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

		private void MniClose_Click(object A_0, EventArgs A_1)
		{
			CloseFile();
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
