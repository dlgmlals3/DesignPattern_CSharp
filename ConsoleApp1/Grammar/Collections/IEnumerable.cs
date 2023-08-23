using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammar.Collections.IEnumerableCollection
{
	public static class IEnumerableCollection
	{
		public static void Test()
		{
			Console.WriteLine("\n IEnumerable");
			IEnumerable<string> messages;

			messages = new List<string>()
			{
				"How are you",
				"have a great day",
				"Thank for meeting"
			};
			Console.WriteLine($"{string.Join(" ", messages)}");
			
			foreach (string item in messages)
			{
				Console.WriteLine(item);
			}

			// IEnumerator
			IEnumerator<string> enumerator = messages.GetEnumerator();
			enumerator.Reset();
			enumerator.MoveNext();
			Console.WriteLine("IEnumerator : " + enumerator.Current);
			enumerator.MoveNext();
			Console.WriteLine("IEnumerator : " + enumerator.Current);
			enumerator.MoveNext();
			Console.WriteLine("IEnumerator : " + enumerator.Current);
			enumerator.MoveNext();
			Console.WriteLine("IEnumerator : " + enumerator.Current);
			enumerator.Reset();
			enumerator.MoveNext();
			Console.WriteLine("IEnumerator : " + enumerator.Current);

			enumerator.Reset();
			while (enumerator.MoveNext())
			{
				Console.WriteLine("While : " + enumerator.Current);
			}
		}
	}
}
