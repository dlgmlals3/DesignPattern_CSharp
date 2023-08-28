using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammar.Collections.IEnumeratorAndYield
{
	public class Sample
	{
		public List<double> Prices { get; set; } = new List<double>() { 90, 34, 12, 80 };

		public IEnumerable<double> Method()
		{
			double sum = 0;
			foreach (double price in Prices)
			{
				sum += price;
				yield return sum;
			}	
		}
	}
	public static class IEnumeratorAndYield
	{
		public static void Test()
		{
			Console.WriteLine("\n IEnumerator And yield");
			Sample s = new Sample();
			IEnumerable<double> enumerable = s.Method(); // not execute Method...

			var enumerator = enumerable.GetEnumerator();
			enumerator.MoveNext();
			Console.WriteLine("current : " + enumerator.Current);
			enumerator.MoveNext();
			Console.WriteLine("current : " + enumerator.Current);
			enumerator.MoveNext();
			Console.WriteLine("current : " + enumerator.Current);

			// Itoration
			foreach (var item in enumerable)
			{
				Console.WriteLine("dlgmlals : " + item);
			}
		}
	}
}
