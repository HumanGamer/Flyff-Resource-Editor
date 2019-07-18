using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ResEditor
{
	public partial class ResEditor : Form
	{
		public string[] args;
		private ResourceFile resourceFile;
		private bool _dirty;

		public ResEditor()
		{
			InitializeComponent();
		}

		private void New()
		{
			Process process = new Process();
			process.StartInfo.FileName = Application.ExecutablePath;
			process.Start();
		}

		private void Open()
		{
			if (this._dirty)
			{
				switch (MessageBox.Show("Do you want to save your changes?", "Flyff ResEditor", MessageBoxButtons.YesNoCancel))
				{
					case DialogResult.Cancel:
						return;
					case DialogResult.Yes:
						SaveAs();
						break;
				}
			}
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Flyff Resource Files|*.res|All Files|*.*";
			ofd.Multiselect = false;
			if (ofd.ShowDialog() == DialogResult.Cancel)
				return;

			this.resourceFile = null;
			Text = "Flyff ResEditor";
			this.fileList.Items.Clear();
			this.resourceFile = new ResourceFile(ofd.FileName);
			this.resourceFile.Path = ofd.FileName;
			Text = this.resourceFile.Path.Substring(this.resourceFile.Path.LastIndexOf('\\') + 1) + " - Flyff ResEditor";
			for (int i = 0; i < this.resourceFile.Entries.Length; i++)
			{
				string text = this.resourceFile.Entries[i].FileName;
				int num;
				switch (text.Substring(text.LastIndexOf('.') + 1))
				{
					case "inc":
						num = 2;
						break;
					case "h":
						num = 1;
						break;
					case "csv":
						num = 3;
						break;
					case "txt":
						num = 4;
						break;
					default:
						num = 0;
						break;
				}
				ListViewItem listViewItem = this.fileList.Items.Add(this.resourceFile.Entries[i].FileName);
				listViewItem.SubItems.Add(GetSizeString(this.resourceFile.Entries[i].FileSize));
				listViewItem.ImageIndex = num;
				this.fileList.Groups[num].Items.Add(listViewItem);
			}
			this.mniClose.Enabled = true;
			this._dirty = false;
		}

		private void Save()
		{
			if (this.resourceFile == null || this.resourceFile.Path == null)
			{
				SaveAs();
				return;
			}
			this.resourceFile.Save(this.resourceFile.Path);
			mniSave.Enabled = false;
			tsbSave.Enabled = false;
			this._dirty = false;
		}

		private void SaveAs()
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "Flyff Resources Files|*.res|All Files|*.*";
			sfd.FileName = ((this.resourceFile == null || this.resourceFile.Path == null) ? "" : this.resourceFile.Path.Substring(this.resourceFile.Path.LastIndexOf('\\') + 1));
			if (sfd.ShowDialog() == DialogResult.Cancel)
				return;

			this.resourceFile.Save(sfd.FileName);
			this.resourceFile.Path = sfd.FileName;
			Text = sfd.FileName.Substring(sfd.FileName.LastIndexOf('\\') + 1) + " - Flyff ResEditor";
			mniSave.Enabled = false;
			tsbSave.Enabled = false;
			this._dirty = false;
		}

		private void CloseFile()
		{
			if (this._dirty)
			{
				switch (MessageBox.Show("Do you want to save modifications ?", "Flyff ResEditor", MessageBoxButtons.YesNoCancel))
				{
					case DialogResult.Cancel:
						return;
					case DialogResult.Yes:
						SaveAs();
						break;
				}
			}
			mniSave.Enabled = false;
			tsbSave.Enabled = false;
			this._dirty = false;
			this.resourceFile = null;
			Text = "Flyff ResEditor";
			this.fileList.Items.Clear();
			this.mniClose.Enabled = false;
		}

		private void Exit()
		{
			if (this._dirty)
			{
				switch (MessageBox.Show("Do you want to save modifications ?", "Flyff ResEditor", MessageBoxButtons.YesNoCancel))
				{
					case DialogResult.Cancel:
						return;
					case DialogResult.Yes:
						SaveAs();
						break;
				}
			}
			Environment.Exit(0);
		}

		private void AddFile()
		{
			this.openFileDialog1.Filter = "All Files|*.*";
			this.openFileDialog1.Multiselect = true;
			if (this.openFileDialog1.ShowDialog() == DialogResult.Cancel)
			{
				return;
			}
			if (this.resourceFile == null)
			{
				this.resourceFile = new ResourceFile();
			}
			string[] fileNames = this.openFileDialog1.FileNames;
			foreach (string text in fileNames)
			{
				int num = -1;
				bool flag = false;
				if (this.resourceFile.Entries != null)
				{
					for (int j = 0; j < this.resourceFile.Entries.Length; j++)
					{
						if (this.resourceFile.Entries[j].FileName == text.Substring(text.LastIndexOf('\\') + 1))
						{
							num = j;
						}
					}
				}
				if (num >= 0)
				{
					if (MessageBox.Show(this.resourceFile.Entries[num].FileName + "\nA file with the same name already exists. Do you want to replace it ?", "Flyff ResEditor", MessageBoxButtons.YesNo) == DialogResult.No)
					{
						flag = true;
					}
					else
					{
						this.fileList.Items[num].Remove();
						this.resourceFile.Remove(num);
					}
				}
				if (!flag)
				{
					this.resourceFile.AddFile(text);
					int num2;
					switch (this.resourceFile.Entries[(int)this.resourceFile.Entries.LongLength - 1].FileName.Substring(this.resourceFile.Entries[(int)this.resourceFile.Entries.LongLength - 1].FileName.LastIndexOf('.') + 1))
					{
						case "inc":
							num2 = 2;
							break;
						case "h":
							num2 = 1;
							break;
						case "csv":
							num2 = 3;
							break;
						case "txt":
							num2 = 4;
							break;
						default:
							num2 = 0;
							break;
					}
					ListViewItem listViewItem = this.fileList.Items.Add(this.resourceFile.Entries[this.resourceFile.Entries.Length - 1].FileName);
					listViewItem.SubItems.Add(GetSizeString(this.resourceFile.Entries[this.resourceFile.Entries.Length - 1].FileSize));
					listViewItem.ImageIndex = num2;
					this.fileList.Groups[num2].Items.Add(listViewItem);
				}
			}
			this._dirty = true;
			this.mniClose.Enabled = true;
			mniSave.Enabled = true;
			tsbSave.Enabled = true;
		}

		private void RemoveFile()
		{
			foreach (int selectedIndex in this.fileList.SelectedIndices)
			{
				this.fileList.Items[selectedIndex].Remove();
				this.resourceFile.Remove(selectedIndex);
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
				switch (text.Substring(text.LastIndexOf('.') + 1))
				{
					case "inc":
						this.saveFileDialog1.Filter = "Include Files (*.inc)|*.inc";
						break;
					case "h":
						this.saveFileDialog1.Filter = "Header Files (*.h)|*.h";
						break;
					case "csv":
						this.saveFileDialog1.Filter = "Comma Separated Value Files (*.csv)|*.csv";
						break;
					case "txt":
						this.saveFileDialog1.Filter = "Text Files (*.txt)|*.txt";
						break;
					default:
						this.saveFileDialog1.Filter = "All Files|*.*";
						break;
				}
				this.saveFileDialog1.FileName = text;
				if (this.saveFileDialog1.ShowDialog() != DialogResult.Cancel)
				{
					this.resourceFile.ExtractFile(this.fileList.SelectedIndices[0], this.saveFileDialog1.FileName);
				}
			}
			else if (this.folderBrowserDialog1.ShowDialog() != DialogResult.Cancel)
			{
				foreach (int selectedIndex in this.fileList.SelectedIndices)
				{
					this.resourceFile.ExtractFile(selectedIndex, this.folderBrowserDialog1.SelectedPath + "\\" + this.resourceFile.Entries[selectedIndex].FileName);
				}
			}
		}

		private void ShowAbout()
		{
			MessageBox.Show(this, "This program is © 2009 Exos.\nContact me on RageZone or use my personal e-mail address if you have it.", "About Flyff ResEditor", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void OnDragShortcut()
		{
			if (this.resourceFile != null)
			{
				string path = Path.GetTempPath() + "\\FlyffResEditor\\" + ((this.resourceFile.Path == null) ? "NewRes.res" : this.resourceFile.Path.Substring(this.resourceFile.Path.LastIndexOf('\\') + 1));

				this.resourceFile.Save(path);
				DoDragDrop(new DataObject(DataFormats.FileDrop, new[] { path }), DragDropEffects.Copy | DragDropEffects.Move);
			}
		}

		private void OnAppStarting()
		{
			Directory.CreateDirectory(Path.GetTempPath() + "\\FlyffResEditor\\");
			if (this.args.Length <= 0 || !File.Exists(this.args[0]))
				return;

			this.resourceFile = new ResourceFile(this.args[0]);
			this.resourceFile.Path = this.args[0];
			Text = this.resourceFile.Path.Substring(this.resourceFile.Path.LastIndexOf('\\') + 1) + " - Flyff ResEditor";
			for (int i = 0; i < this.resourceFile.Entries.Length; i++)
			{
				string text = this.resourceFile.Entries[i].FileName;
				int num;
				switch (text.Substring(text.LastIndexOf('.') + 1))
				{
					case "inc":
						num = 2;
						break;
					case "h":
						num = 1;
						break;
					case "csv":
						num = 3;
						break;
					case "txt":
						num = 4;
						break;
					default:
						num = 0;
						break;
				}
				ListViewItem listViewItem = this.fileList.Items.Add(this.resourceFile.Entries[i].FileName);
				listViewItem.SubItems.Add(GetSizeString(this.resourceFile.Entries[i].FileSize));
				listViewItem.ImageIndex = num;
				this.fileList.Groups[num].Items.Add(listViewItem);
			}
			this.mniClose.Enabled = true;
			this._dirty = false;
		}

		private bool OnAppClosing()
		{
			if (this._dirty)
			{
				switch (MessageBox.Show("Do you want to save modifications ?", "Flyff ResEditor", MessageBoxButtons.YesNoCancel))
				{
					case DialogResult.Yes:
						SaveAs();
						return true;
					case DialogResult.Cancel:
						return false;
				}
			}

			return true;
		}

		private void OnSelectFile()
		{
			if (this.fileList.SelectedItems.Count == 0)
			{
				tsbRemove.Enabled = false;
				tsbExtract.Enabled = false;
				mniRemove.Enabled = false;
				mniExtract.Enabled = false;
				this.mniContextExtract.Enabled = false;
				mniContextRemove.Enabled = false;
				mniContextAdd.Enabled = true;
			}
			else
			{
				tsbRemove.Enabled = true;
				tsbExtract.Enabled = true;
				mniRemove.Enabled = true;
				mniExtract.Enabled = true;
				this.mniContextExtract.Enabled = true;
				mniContextRemove.Enabled = true;
				mniContextAdd.Enabled = false;
			}
		}

		private void OnItemDrag()
		{
			if (this.fileList.SelectedItems.Count > 0)
			{
				string[] array = new string[this.fileList.SelectedItems.Count];
				for (int i = 0; i < this.fileList.SelectedItems.Count; i++)
				{
					array[i] = Path.GetTempPath() + "\\FlyffResEditor\\" + this.resourceFile.Entries[this.fileList.SelectedIndices[i]].FileName;
					this.resourceFile.ExtractFile(this.fileList.SelectedIndices[i], array[i]);
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
			if (this.resourceFile == null)
			{
				this.resourceFile = new ResourceFile();
			}
			string[] array = (string[])data.GetData(DataFormats.FileDrop, false);
			string[] array2 = array;
			foreach (string text in array2)
			{
				int num = -1;
				bool flag = false;
				if (this.resourceFile.Entries != null)
				{
					for (int j = 0; j < this.resourceFile.Entries.Length; j++)
					{
						if (this.resourceFile.Entries[j].FileName == text.Substring(text.LastIndexOf('\\') + 1))
						{
							num = j;
						}
					}
				}
				if (num >= 0)
				{
					if (MessageBox.Show(this.resourceFile.Entries[num].FileName + "\nA file with the same name already exists. Do you want to replace it ?", "Flyff ResEditor", MessageBoxButtons.YesNo) == DialogResult.No)
					{
						flag = true;
					}
					else
					{
						this.fileList.Items[num].Remove();
						this.resourceFile.Remove(num);
					}
				}
				if (!flag)
				{
					this.resourceFile.AddFile(text);
					int num2;
					switch (this.resourceFile.Entries[(int)this.resourceFile.Entries.LongLength - 1].FileName.Substring(this.resourceFile.Entries[(int)this.resourceFile.Entries.LongLength - 1].FileName.LastIndexOf('.') + 1))
					{
						case "inc":
							num2 = 2;
							break;
						case "h":
							num2 = 1;
							break;
						case "csv":
							num2 = 3;
							break;
						case "txt":
							num2 = 4;
							break;
						default:
							num2 = 0;
							break;
					}
					ListViewItem listViewItem = this.fileList.Items.Add(this.resourceFile.Entries[this.resourceFile.Entries.Length - 1].FileName);
					listViewItem.SubItems.Add(GetSizeString(this.resourceFile.Entries[this.resourceFile.Entries.Length - 1].FileSize));
					listViewItem.ImageIndex = num2;
					this.fileList.Groups[num2].Items.Add(listViewItem);
				}
			}
			this._dirty = true;
			this.mniClose.Enabled = true;
			mniSave.Enabled = true;
			tsbSave.Enabled = true;
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
	}
}
