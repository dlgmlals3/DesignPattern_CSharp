using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using static System.Console;

namespace DesignPattern
{
	public class journal
	{
		private readonly List<string> entries = new List<string>();
		private static int count = 0;
		public int AddEntry(string text)
		{
			entries.Add($"{++count}:{text}");
			return count;
		}

		public void RemoveEntry(int index)
		{
			entries.RemoveAt(index);
		}
		public override string ToString()
		{
			return string.Join(Environment.NewLine, entries);
		}
	}

	public class Persistence
	{
		public void SaveToFile(journal j, string filename, bool overwrite = true)
		{
			if (overwrite || !File.Exists(filename))
			{
				File.WriteAllText(filename, j.ToString());
			}
		}
		public void Save(string filename)
		{
			File.WriteAllText(filename, ToString());
		}
	}
}