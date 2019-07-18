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

		private void FileList_SelectedIndexChanged(object A_0, EventArgs A_1)
		{
			if (this.fileList.SelectedItems.Count == 0)
			{
				but_del.Enabled = false;
				but_extract.Enabled = false;
				supprimerLesFicToolStripMenuItem.Enabled = false;
				extraireLaSélectionToolStripMenuItem.Enabled = false;
				this.extraireVersToolStripMenuItem1.Enabled = false;
				toolStripMenuItem3.Enabled = false;
				toolStripMenuItem2.Enabled = true;
			}
			else
			{
				but_del.Enabled = true;
				but_extract.Enabled = true;
				supprimerLesFicToolStripMenuItem.Enabled = true;
				extraireLaSélectionToolStripMenuItem.Enabled = true;
				this.extraireVersToolStripMenuItem1.Enabled = true;
				toolStripMenuItem3.Enabled = true;
				toolStripMenuItem2.Enabled = false;
			}
		}

		private void ExtraireVersToolStripMenuItem1_Click(object A_0, EventArgs A_1)
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

		private void ResEditor_Load(object A_0, EventArgs A_1)
		{
			Directory.CreateDirectory(Path.GetTempPath() + "\\FlyffResEditor\\");
			if (this.args.Length <= 0 || !File.Exists(this.args[0]))
			{
				return;
			}
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
			this.fermerToolStripMenuItem.Enabled = true;
			this._dirty = false;
		}

		private void FileList_ItemDrag(object A_0, ItemDragEventArgs A_1)
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

		private void OuvrirToolStripMenuItem_Click(object A_0, EventArgs A_1)
		{
			if (this._dirty)
			{
				switch (MessageBox.Show("Do you want to save modifications ?", "Flyff ResEditor", MessageBoxButtons.YesNoCancel))
				{
					case DialogResult.Cancel:
						return;
					case DialogResult.Yes:
						EnregistrerSousToolStripMenuItem_Click(A_0, A_1);
						break;
				}
			}
			this.openFileDialog1.Multiselect = false;
			if (this.openFileDialog1.ShowDialog() == DialogResult.Cancel)
			{
				return;
			}
			this.resourceFile = null;
			Text = "Flyff ResEditor";
			this.fileList.Items.Clear();
			this.resourceFile = new ResourceFile(this.openFileDialog1.FileName);
			this.resourceFile.Path = this.openFileDialog1.FileName;
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
			this.fermerToolStripMenuItem.Enabled = true;
			this._dirty = false;
		}

		private void MenuStrip1_ItemClicked(object A_0, ToolStripItemClickedEventArgs A_1)
		{
		}

		private void NouveauToolStripMenuItem_Click(object A_0, EventArgs A_1)
		{
			Process process = new Process();
			process.StartInfo.FileName = Application.ExecutablePath;
			process.Start();
		}

		private void FileList_DragEnter(object A_0, DragEventArgs A_1)
		{
			if (A_1.Data.GetDataPresent(DataFormats.FileDrop))
			{
				A_1.Effect = DragDropEffects.Copy;
			}
		}

		private void FileList_DragDrop(object A_0, DragEventArgs A_1)
		{
			if (this.resourceFile == null)
			{
				this.resourceFile = new ResourceFile();
			}
			string[] array = (string[])A_1.Data.GetData(DataFormats.FileDrop, autoConvert: false);
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
			this.fermerToolStripMenuItem.Enabled = true;
			enregistrerToolStripMenuItem.Enabled = true;
			but_save.Enabled = true;
		}

		private void EnregistrerSousToolStripMenuItem_Click(object A_0, EventArgs A_1)
		{
			this.saveFileDialog1.Filter = "Flyff resources files (*.res)|*.res";
			this.saveFileDialog1.FileName = ((this.resourceFile == null || this.resourceFile.Path == null) ? "" : this.resourceFile.Path.Substring(this.resourceFile.Path.LastIndexOf('\\') + 1));
			if (this.saveFileDialog1.ShowDialog() != DialogResult.Cancel)
			{
				this.resourceFile.Save(this.saveFileDialog1.FileName);
				this.resourceFile.Path = this.saveFileDialog1.FileName;
				Text = this.saveFileDialog1.FileName.Substring(this.saveFileDialog1.FileName.LastIndexOf('\\') + 1) + " - Flyff ResEditor";
				enregistrerToolStripMenuItem.Enabled = false;
				but_save.Enabled = false;
				this._dirty = false;
			}
		}

		private void EnregistrerToolStripMenuItem_Click(object A_0, EventArgs A_1)
		{
			if (this.resourceFile == null || this.resourceFile.Path == null)
			{
				EnregistrerSousToolStripMenuItem_Click(A_0, A_1);
				return;
			}
			this.resourceFile.Save(this.resourceFile.Path);
			enregistrerToolStripMenuItem.Enabled = false;
			but_save.Enabled = false;
			this._dirty = false;
		}

		private void FermerToolStripMenuItem_Click(object A_0, EventArgs A_1)
		{
			if (this._dirty)
			{
				switch (MessageBox.Show("Do you want to save modifications ?", "Flyff ResEditor", MessageBoxButtons.YesNoCancel))
				{
					case DialogResult.Cancel:
						return;
					case DialogResult.Yes:
						EnregistrerSousToolStripMenuItem_Click(A_0, A_1);
						break;
				}
			}
			enregistrerToolStripMenuItem.Enabled = false;
			but_save.Enabled = false;
			this._dirty = false;
			this.resourceFile = null;
			Text = "Flyff ResEditor";
			this.fileList.Items.Clear();
			this.fermerToolStripMenuItem.Enabled = false;
		}

		private void ResEditor_FormClosing(object A_0, FormClosingEventArgs A_1)
		{
			if (this._dirty)
			{
				switch (MessageBox.Show("Do you want to save modifications ?", "Flyff ResEditor", MessageBoxButtons.YesNoCancel))
				{
					case DialogResult.Yes:
						EnregistrerSousToolStripMenuItem_Click(A_0, A_1);
						break;
					case DialogResult.Cancel:
						A_1.Cancel = true;
						break;
				}
			}
		}

		private void QuitterToolStripMenuItem_Click(object A_0, EventArgs A_1)
		{
			if (this._dirty)
			{
				switch (MessageBox.Show("Do you want to save modifications ?", "Flyff ResEditor", MessageBoxButtons.YesNoCancel))
				{
					case DialogResult.Cancel:
						return;
					case DialogResult.Yes:
						EnregistrerSousToolStripMenuItem_Click(A_0, A_1);
						break;
				}
			}
			Environment.Exit(0);
		}

		private void But_new_Click(object A_0, EventArgs A_1)
		{
			NouveauToolStripMenuItem_Click(A_0, A_1);
		}

		private void AProposDeFlyffResEditorToolStripMenuItem_Click(object A_0, EventArgs A_1)
		{
			MessageBox.Show("Exos © 2009\nContact me with RageZone or use my personal mail address if you already have it", "About Flyff ResEditor");
		}

		private void ResShortcut_Click(object A_0, EventArgs A_1)
		{
		}

		private void ResShortcut_MouseMove(object A_0, MouseEventArgs A_1)
		{
			if (A_1.Button == MouseButtons.Left && this.resourceFile != null)
			{
				string[] array = new string[1]
				{
				Path.GetTempPath() + "\\FlyffResEditor\\" + ((this.resourceFile.Path == null) ? "NewRes.res" : this.resourceFile.Path.Substring(this.resourceFile.Path.LastIndexOf('\\') + 1))
				};
				this.resourceFile.Save(array[0]);
				DoDragDrop(new DataObject(DataFormats.FileDrop, array), DragDropEffects.Copy | DragDropEffects.Move);
			}
		}

		private void But_open_Click(object A_0, EventArgs A_1)
		{
			OuvrirToolStripMenuItem_Click(A_0, A_1);
		}

		private void But_save_Click(object A_0, EventArgs A_1)
		{
			EnregistrerToolStripMenuItem_Click(A_0, A_1);
		}

		private void ExtraireLaSélectionToolStripMenuItem_Click(object A_0, EventArgs A_1)
		{
			ExtraireVersToolStripMenuItem1_Click(A_0, A_1);
		}

		private void But_extract_Click(object A_0, EventArgs A_1)
		{
			ExtraireVersToolStripMenuItem1_Click(A_0, A_1);
		}

		private void SupprimerLesFicToolStripMenuItem_Click(object A_0, EventArgs A_1)
		{
			foreach (int selectedIndex in this.fileList.SelectedIndices)
			{
				this.fileList.Items[selectedIndex].Remove();
				this.resourceFile.Remove(selectedIndex);
			}
			this._dirty = true;
			enregistrerToolStripMenuItem.Enabled = true;
			but_save.Enabled = true;
		}

		private void ToolStripMenuItem3_Click(object A_0, EventArgs A_1)
		{
			SupprimerLesFicToolStripMenuItem_Click(A_0, A_1);
		}

		private void But_del_Click(object A_0, EventArgs A_1)
		{
			SupprimerLesFicToolStripMenuItem_Click(A_0, A_1);
		}

		private void AjouterUnFichieToolStripMenuItem_Click(object A_0, EventArgs A_1)
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
			this.fermerToolStripMenuItem.Enabled = true;
			enregistrerToolStripMenuItem.Enabled = true;
			but_save.Enabled = true;
		}

		private void ToolStripMenuItem2_Click(object A_0, EventArgs A_1)
		{
			AjouterUnFichieToolStripMenuItem_Click(A_0, A_1);
		}

		private void But_add_Click(object A_0, EventArgs A_1)
		{
			AjouterUnFichieToolStripMenuItem_Click(A_0, A_1);
		}
	}
}
