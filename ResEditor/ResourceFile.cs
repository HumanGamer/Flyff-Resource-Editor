using System;
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
		public ResourceEntry[] Entries;

		/// <summary>
		/// Path of the resource file
		/// </summary>
		public string Path;

		/// <summary>
		/// Opens the resource file at the specified path
		/// </summary>
		/// <param name="path">The path of the resource file to open</param>
		public ResourceFile(string path)
		{
			Path = path;

			// Read in all the bytes
			FileStream fileStream = new FileStream(path, FileMode.Open);
			byte[] buffer = new byte[fileStream.Length];
			fileStream.Read(buffer, 0, (int)fileStream.Length);
			fileStream.Close();

			// Create a binary reader for the file's bytes
			BinaryReader br = new BinaryReader(new MemoryStream(buffer));

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

			// Create a new binary reader for the decrypted data
			BinaryReader br2 = new BinaryReader(new MemoryStream(array));

			// Skip the first 7 bytes
			br2.ReadBytes(7);

			// Read in the file entries
			Entries = new ResourceEntry[br2.ReadInt16()];
			for (int i = 0; i < Entries.Length; i++)
			{
				Entries[i].FileName = Encoding.ASCII.GetString(br2.ReadBytes(br2.ReadInt16()));
				Entries[i].FileSize = br2.ReadInt32();
				Entries[i].Time = br2.ReadInt32();
				Entries[i].FileOffset = br2.ReadInt32();
			}
			br2.Close();

			// Read the entry data
			for (int i = 0; i < Entries.Length; i++)
			{
				br.BaseStream.Seek(Entries[i].FileOffset, SeekOrigin.Begin);

				Entries[i].Data = br.ReadBytes(Entries[i].FileSize);

				// If the data is encrypted, then we need to decrypt it...
				if (this._encrypted == 1)
				{
					for (int l = 0; l < Entries[i].FileSize; l++)
					{
						Entries[i].Data[l] = (byte)((16 * (this._encryptionKey ^ (byte)(~Entries[i].Data[l]))) | ((this._encryptionKey ^ (byte)(~Entries[i].Data[l])) >> 4));
					}
				}
			}
			br.Close();
		}

		/// <summary>
		/// Initializes an empty resource file
		/// </summary>
		public ResourceFile()
		{
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
			FileStream fileStream = new FileStream(path, FileMode.Create);
			fileStream.Write(Entries[index].Data, 0, Entries[index].FileSize);
			fileStream.Close();
		}

		/// <summary>
		/// Adds a file to the resource
		/// </summary>
		/// <param name="path">The path of the file to add</param>
		public void AddFile(string path)
		{
			// Read in all the bytes
			FileStream fileStream = new FileStream(path, FileMode.Open);
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, (int)fileStream.Length);
			fileStream.Close();

			// If the entries array is null, create it
			if (Entries == null)
			{
				Entries = new ResourceEntry[1];
				Entries[0].FileName = path.Substring(path.LastIndexOf('\\') + 1);
				Entries[0].FileSize = array.Length;
				Entries[0].Data = array;
				Entries[0].Time = 0;
				return;
			}

			// Resize the array
			ResourceEntry[] array2 = new ResourceEntry[Entries.Length + 1];
			for (int i = 0; i < Entries.Length; i++)
			{
				array2[i] = Entries[i];
			}

			array2[Entries.Length].FileName = path.Substring(path.LastIndexOf('\\') + 1);
			array2[Entries.Length].FileSize = array.Length;
			array2[Entries.Length].Data = array;
			array2[Entries.Length].Time = 0;
			Entries = array2;
		}

		/// <summary>
		/// Removes the entry at the specified index
		/// </summary>
		/// <param name="index"></param>
		public void Remove(int index)
		{
			// Create a new entry array with 1 less than the current one
			ResourceEntry[] tmp = new ResourceEntry[Entries.Length - 1];

			// Copy everything prior to the removed item into the new array
			for (int i = 0; i < index; i++)
			{
				tmp[i] = Entries[i];
			}

			// Copy everything after the removed item into the new array
			for (int j = index; j < Entries.Length - 1; j++)
			{
				tmp[j] = Entries[j + 1];
			}

			// Replace the old array with the new one
			Entries = tmp;
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
			ResourceEntry[] entriesArray1 = Entries;
			for (int i = 0; i < entriesArray1.Length; i++)
			{
				ResourceEntry a = entriesArray1[i];
				nameLength += a.FileName.Length + 14;
				size += a.FileSize;
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
			ResourceEntry[] entriesArray2 = Entries;

			// Write the entries
			for (int i = 0; i < entriesArray2.Length; i++)
			{
				ResourceEntry entry = entriesArray2[i];
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
