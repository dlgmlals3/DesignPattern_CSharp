using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns.Singleton
{
	
	public static class Extensions
	{
		/// <summary>
		/// Breaks a list into smaller sub-lists of a specified size
		/// </summary>
		/// <param name="source">An IEnumerable to split into smaller sub-lists</param>
		/// <param name="size">The maximum size of each sub-list</param>
		/// <returns>The smaller sub-lists of the specified size</returns>
		public static List<List<T>> Batch<T>(this IEnumerable<T> source, int size)
		{
			var result = new List<List<T>>();
			List<T> batch = null;
			int index = 0;
			foreach (var item in source)
			{
				if (index % size == 0)
				{
					batch = new List<T>();
					result.Add(batch);
				}
				batch.Add(item);
				++index;
			}
			return result;
		}
	}


	public interface IDatabase
	{
		int GetPopultation(string name);
	}

	public class SingleTonDatabase : IDatabase
	{
		private Dictionary<string, int> capitals;

		private SingleTonDatabase()
		{
			Console.WriteLine("SingleTonDatabase");
			string workingDirectory = Environment.CurrentDirectory;
			string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
			string path = projectDirectory + "\\DesignPatterns\\Singleton\\capitals.txt";



			capitals = File.ReadAllLines(path)
				.Batch(2)
				.ToDictionary(
					item => item.ElementAt(0),
					item => int.Parse(item.ElementAt(1))
				);
		}
		public int GetPopulation(string name)
		{
			return capitals[name];
		}

		public int GetPopultation(string name)
		{
			throw new NotImplementedException();
		}

		// Lazy 타입은 선언시가 아닌 호출시에 객체생성을 하는 것을 보장!!
		// 사용하지 않는 경우 객체를 생성하지 않음.
		private static Lazy<SingleTonDatabase> instance = new Lazy<SingleTonDatabase>(
			() => new SingleTonDatabase()
		);

		public static SingleTonDatabase Instance => instance.Value;
	}

	public static class SingleTon
	{
	

		public static void Test()
		{
			Console.WriteLine("\nSingleTon Start");
			var db = SingleTonDatabase.Instance;
			
			Console.WriteLine($"{db.GetPopulation("Seoul")}");
		}
	}
}
