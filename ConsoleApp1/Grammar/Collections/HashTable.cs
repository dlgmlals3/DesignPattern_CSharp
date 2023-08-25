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
	/// 들어오는 순서 보장 못함.
	/// </summary>
	public static class HashtableCollection
	{
		public static void Test()
		{
			Console.WriteLine("\n HashTable");
			Hashtable employees;
			employees = new Hashtable()
			{
				{ 103, "Scott" },
				{ 101, "Heeminlee"},
				{ 104, "Heesun lee"},
				{"hello", 10.934 }
			};
			// string type으로 됨.
			
			foreach (var item in employees.Keys)
			{
				Console.WriteLine(item);
			}

			foreach (var item in employees.Values)
			{
				Console.WriteLine(item);
			}

			foreach (DictionaryEntry item in employees)
			{
				Console.WriteLine(item.Key + " " + item.Value);
			}

			//////////////////////////////////
			// HashSet
			HashSet<string> messages;
			messages = new HashSet<string>()
			{
				"Good Morning", "How Are you", "Have a good day"
			};
			messages.Add("Good Morning");
			Console.WriteLine($"{string.Join(" ", messages)}");

			messages.Remove("How Are you");
			Console.WriteLine($"{string.Join(" ", messages)}");

			messages.RemoveWhere(c => c.StartsWith("Good"));
			Console.WriteLine($"{string.Join(" ", messages)}");

			messages = new HashSet<string>()
			{
				"Good Morning", "How Are you", "Have a good day"
			};
			bool ret = messages.Contains("Good Morning");
			Console.WriteLine("Search : " + ret);

			var employees3 = new HashSet<string>() { "Amar", "Akhll", "Samreen" };
			var employees4 = new HashSet<string>() { "John", "Scott", "Smith", "David", "Amar" };
			employees4.UnionWith(employees3);
			Console.WriteLine("UnionWith : " + string.Join(" " , employees4));

			// 둘다 있는 경우 출력
			employees3 = new HashSet<string>() { "Amar", "Akhll", "Samreen" };
			employees4 = new HashSet<string>() { "John", "Scott", "Smith", "David", "Amar" };
			employees4.IntersectWith(employees3);
			Console.WriteLine("IntersectWith : " + string.Join(" ", employees4));
		}
	}
}
