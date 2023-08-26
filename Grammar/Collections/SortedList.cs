using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Grammar.Collections.SortedList
{
	/// <summary>
	/// SortedList
	/// 순서 보장하지 못함. Dictionary 동일하고
	/// 차이점은 넣는 순간 key 값으로 정렬함.
	/// comparable 함수 정의된 type 만 가능함.
	/// </summary>
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
			//employees.Remove(103);
			Console.WriteLine($"{string.Join(" ", employees)}");
			// Index로 접근하면 key 값으로 접근됨..

			int ki = employees.IndexOfKey(101);
			Console.WriteLine("index of 101 : " + ki);

			int vi = employees.IndexOfValue("Scott");
			Console.WriteLine("index of Scott : " + vi);

			Console.WriteLine(string.Join(" ", employees.Keys));
			Console.WriteLine(string.Join(" ", employees.Values));

		}
	}
}
