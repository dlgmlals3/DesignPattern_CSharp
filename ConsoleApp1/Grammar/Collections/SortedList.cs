using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammar.Collections.SortedList
{
	public static class SortedListCollection
	{
		public static void Test()
		{
			Console.WriteLine("\n SortedList");
			SortedList<int, string> employees = new SortedList<int, string>()
			{
				{ 103, "Scott" },
				{ 101, "Heeminlee"},
				{ 104, "Heesun lee"}
			};

			employees.Add(100, "Anna");
			employees.Remove(103);
			Console.WriteLine($"{string.Join(" ", employees)}");

		}
	}
}
