using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammar.Collections.Dictionary
{
	public static class DictionaryCollection
	{
		public static void Test()
		{
			Console.WriteLine("\n DictionaryCollection");
			Dictionary<int, string> employees = new Dictionary<int, string>()
			{
				{101, "smith" },
				{102, "heemin" },
				{103, "heesun" }
			};
			employees.Remove(102);
			Console.WriteLine($"{string.Join(" ", employees)}");

			var c = employees.ContainsKey(12);
			var d = employees.ContainsValue("smith");
			Console.WriteLine($"{c} {d}");


			Dictionary<int, string>.KeyCollection keys = employees.Keys;
			Console.WriteLine($"keys : {string.Join(" ", keys)}");

			Dictionary<int, string>.ValueCollection values = employees.Values;
			Console.WriteLine($"values : {string.Join(" ", values)}");

			
		}
	}
}
