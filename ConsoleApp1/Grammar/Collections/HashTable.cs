using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammar.Collections.HashTable
{
	/// <summary>
	/// Hash Table 경우 key value가 다른 여러가지 타입도 가능함.
	/// </summary>
	public static class HashtableCollection
	{
		public static void Test()
		{
			Console.WriteLine("\n HashTable");
			Hashtable employees = new Hashtable()
			{
				{ 103, "Scott" },
				{ 101, "Heeminlee"},
				{ 104, "Heesun lee"},
				{"hello", 10.934 }
			};
			foreach (var item in employees.Keys)
			{
				Console.WriteLine(item);
			}
			foreach (DictionaryEntry item in employees)
			{
				Console.WriteLine(item.Key + " " + item.Value);
			}

			//////////////////////////////////
			HashSet<string> messages = new HashSet<string>()
			{
				"Good Morning", "How Are you", "Have a good day"
			};
			messages.Add("Good Morning");
			Console.WriteLine($"{string.Join(" ", messages)}");

			messages.Remove("How Are you");
			Console.WriteLine($"{string.Join(" ", messages)}");

			messages.RemoveWhere(c => c.StartsWith("Good"));
			Console.WriteLine($"{string.Join(" ", messages)}");


		}
	}
}
