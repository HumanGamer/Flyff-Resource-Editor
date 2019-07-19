using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ResEditor
{
	/// <summary>
	/// A class representing a Flyff Resource File
	/// </summary>
	public class ResourceFile
	{
		/// <summary>
		/// A struct representing an entry in the resource file
		/// </summary>
		public struct ResourceEntry
		{
			/// <summary>
			/// The name of the entry file
			/// </summary>
			public string FileName;

			/// <summary>
			/// The size of the entry file in bytes
			/// </summary>
			public int FileSize;

			/// <summary>
			/// The time the file was created/modified
			/// </summary>
			public int Time;

			/// <summary>
			/// The offset in the resource file
			/// </summary>
			public int FileOffset;

			/// <summary>
			/// The contents of the entry file
			/// </summary>
			public byte[] Data;

			/// <summary>
			/// Creates a new ResourceEntry instance
			/// </summary>
			/// <param name="fileName">Name of the file</param>
			/// <param name="fileSize">Size of the file in bytes</param>
			/// <param name="data">Contents of the file</param>
			/// <param name="time">File creation/modify time</param>
			/// <param name="fileOffset">Offset of the file in the resource</param>
			public ResourceEntry(string fileName, int fileSize, byte[] data = null, int time = 0, int fileOffset = 0)
			{
				FileName = fileName;
				FileSize = fileSize;
				Data = data;
				Time = time;
				FileOffset = fileOffset;
			}
		}

		/// <summary>
		/// The encryption key for the file
		/// </summary>
		private byte _encryptionKey;

		/// <summary>
		/// Whether or not this file is encrypted
		/// </summary>
		private byte _encrypted;

		/// <summary>
		/// List of Resource Entries in the file
		/// </summary>
		private List<ResourceEntry> _entries;

		/// <summary>
		/// Path of the resource file
		/// </summary>
		public string FilePath;

		/// <summary>
		/// The number of entries in this resource
		/// </summary>
		public int Count => _entries.Count;

		/// <summary>
		/// Initializes an empty resource file
		/// </summary>
		public ResourceFile()
		{
			_entries = new List<ResourceEntry>();
			this._encryptionKey = (byte)new Random().Next(255);
			this._encrypted = 0;
		}

		/// <summary>
		/// Extracts the file at the specified index
		/// </summary>
		/// <param name="index">The index of the file</param>
		/// <param name="path">The path to extract the file to</param>
		public void ExtractFile(int index, string path)
		{
			var entry = _entries[index];

			using (Stream s = new FileStream(path, FileMode.Create))
			{
				s.Write(entry.Data, 0, entry.FileSize);
			}
		}

		/// <summary>
		/// Adds a file to the resource
		/// </summary>
		/// <param name="path">The path of the file to add</param>
		public void AddFile(string path)
		{
			int existingIndex = IndexOf(Path.GetFileName(path));

			// Read in all the bytes
			byte[] data = File.ReadAllBytes(path);

			ResourceEntry entry = new ResourceEntry(Path.GetFileName(path), data.Length, data);

			if (existingIndex >= 0)
				_entries[existingIndex] = entry;
			else
				_entries.Add(entry);
		}

		/// <summary>
		/// Removes the entry at the specified index
		/// </summary>
		/// <param name="index"></param>
		public void Remove(int index)
		{
			_entries.RemoveAt(index);
		}

		/// <summary>
		/// Gets a resource at the specified index
		/// </summary>
		/// <param name="index">The index of the resource to get</param>
		/// <returns>The resource at the specified index</returns>
		public ResourceEntry this[int index]
		{
			get
			{
				return _entries[index];
			}
			set
			{
				_entries[index] = value;
			}
		}

		/// <summary>
		/// Gets the index of the specified file name in this resource
		/// </summary>
		/// <param name="name">The name of the file</param>
		/// <returns>The index of the specified file name or -1 if the file was not found.</returns>
		public int IndexOf(string name)
		{
			for(int i = 0; i < Count; i++)
			{
				if (this[i].FileName == name)
					return i;
			}

			return -1;
		}

		/// <summary>
		/// Gets whether or not there is a file of the specified name in this resource
		/// </summary>
		/// <param name="name">The name of the file</param>
		/// <returns>True if the file is was found, otherwise false.</returns>
		public bool Contains(string name)
		{
			return IndexOf(name) != -1;
		}

		/// <summary>
		/// Opens the resource file at the specified path
		/// </summary>
		/// <param name="path">The path of the resource file to open</param>
		/// <returns>The loaded resource file</returns>
		public static ResourceFile Open(string path)
		{
			ResourceFile result = new ResourceFile();
			result.FilePath = path;

			result.Read();

			return result;
		}

		/// <summary>
		/// Reads the resource file from the file system
		/// </summary>
		private void Read()
		{
			// Create a binary reader for the file's bytes
			using (Stream ms = File.OpenRead(FilePath))
			using (BinaryReader br = new BinaryReader(ms))
			{
				// Read header
				this._encryptionKey = br.ReadByte();
				this._encrypted = br.ReadByte();

				// Read data
				byte[] array = br.ReadBytes(br.ReadInt32());

				// Decrypt the file headers
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = (byte)((16 * (this._encryptionKey ^ (byte)(~array[i]))) | ((this._encryptionKey ^ (byte)(~array[i])) >> 4));
				}

				// Create a new binary reader for the decrypted header
				using (MemoryStream msHeader = new MemoryStream(array))
				using (BinaryReader brHeader = new BinaryReader(msHeader))
				{
					// Skip the first 7 bytes
					brHeader.ReadBytes(7);

					// Read in the file entries
					short count = brHeader.ReadInt16();
					for (int i = 0; i < count; i++)
					{
						string name = Encoding.ASCII.GetString(brHeader.ReadBytes(brHeader.ReadInt16()));
						int size = brHeader.ReadInt32();
						int time = brHeader.ReadInt32();
						int offset = brHeader.ReadInt32();

						_entries.Add(new ResourceEntry(name, size, null, time, offset));
					}
				}

				// Read the entry data
				for (int i = 0; i < _entries.Count; i++)
				{
					ResourceEntry entry = _entries[i];

					// Go to the entry offset
					br.BaseStream.Seek(entry.FileOffset, SeekOrigin.Begin);

					// Read the entry data
					entry.Data = br.ReadBytes(entry.FileSize);

					// If the data is encrypted, then we need to decrypt it...
					if (this._encrypted == 1)
					{
						for (int j = 0; j < _entries[i].FileSize; j++)
						{
							entry.Data[j] = (byte)((16 * (this._encryptionKey ^ (byte)(~entry.Data[j]))) | ((this._encryptionKey ^ (byte)(~entry.Data[j])) >> 4));
						}
					}
					_entries[i] = entry;
				}
			}
		}

		/// <summary>
		/// Saves the resource file at the specified path
		/// </summary>
		/// <param name="path">The path to save the resource file to</param>
		public void Save(string path)
		{
			int nameLength = 2;
			int size = 0;
			int fileCount = 0;

			// Calculate sizes
			for (int i = 0; i < _entries.Count; i++)
			{
				ResourceEntry entry = _entries[i];
				nameLength += entry.FileName.Length + 14;
				size += entry.FileSize;
				fileCount++;
			}

			int nameLength2 = nameLength;

			// Create header buffer
			byte[] fileHeaders = new byte[nameLength];
			BinaryWriter bwHeaders = new BinaryWriter(new MemoryStream(fileHeaders));

			// Write the file count
			bwHeaders.Write((short)fileCount);

			// Create entry data buffer
			byte[] entryData = new byte[size];
			BinaryWriter bwEntryData = new BinaryWriter(new MemoryStream(entryData));

			// Write the entries
			for (int i = 0; i < _entries.Count; i++)
			{
				ResourceEntry entry = _entries[i];
				bwHeaders.Write((short)entry.FileName.Length);
				bwHeaders.Write(new ASCIIEncoding().GetBytes(entry.FileName));
				bwHeaders.Write(entry.FileSize);
				bwHeaders.Write(entry.Time);
				bwHeaders.Write(nameLength2 + 13);
				bwEntryData.Write(entry.Data);
				nameLength2 += entry.FileSize;
			}
			bwHeaders.Close();
			bwEntryData.Close();

			// Encrypt the file headers
			for (int i = 0; i < nameLength; i++)
			{
				fileHeaders[i] = (byte)(~(((fileHeaders[i] * 16) | (fileHeaders[i] >> 4)) ^ this._encryptionKey));
			}

			// Encrypt entry data if nessecary
			if (this._encrypted == 1)
			{
				for (int i = 0; i < size; i++)
				{
					entryData[i] = (byte)(~(((entryData[i] * 16) | (entryData[i] >> 4)) ^ this._encryptionKey));
				}
			}

			// Write the file
			FileStream fileStream = new FileStream(path, FileMode.Create);
			BinaryWriter bwMain = new BinaryWriter(fileStream);

			// Write all the data to the file
			bwMain.Write(this._encryptionKey);
			bwMain.Write(this._encrypted);
			bwMain.Write(nameLength + 7);
			bwMain.Seek(7, SeekOrigin.Current);
			bwMain.Write(fileHeaders);
			bwMain.Write(entryData);

			bwMain.Close();
			fileStream.Close();
		}
	}
}
