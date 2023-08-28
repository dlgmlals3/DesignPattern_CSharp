using Autofac;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns.Singleton.Issue
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
		int GetPopulation(string name);
	}

	public class SingleTonDatabase : IDatabase
	{
		private Dictionary<string, int> capitals;
		private static int instanceCount;
		public static int Count => instanceCount;

		private SingleTonDatabase()
		{
			Console.WriteLine("SingleTonDatabase");
			instanceCount++;
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
		
		// Lazy 타입은 선언시가 아닌 호출시에 객체생성을 하는 것을 보장!!
		// 사용하지 않는 경우 객체를 생성하지 않음.
		private static Lazy<SingleTonDatabase> instance = new Lazy<SingleTonDatabase>(
			() => new SingleTonDatabase()
		);

		public static SingleTonDatabase Instance => instance.Value;
	}

	public class OrdinaryDatabase : IDatabase
	{
		private Dictionary<string, int> capitals;
		private static int instanceCount;
		public static int Count => instanceCount;

		private OrdinaryDatabase()
		{
			Console.WriteLine("SingleTonDatabase");
			instanceCount++;
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
	}

	/// <summary>
	/// 하드 코딩된 SingleTonDatabase.Instance 로 인해서 문제가 있음.
	/// </summary>
	public class SingletonRecordFinder
	{
		
	}

	public class ConfigurableRecordFinder
	{
		private IDatabase database;
		public ConfigurableRecordFinder(IDatabase database)
		{
			this.database = database ?? throw new ArgumentNullException(paramName: nameof(database));
		}

		public int GetTotalPopulation(IEnumerable<string> names)
		{
			int result = 0;
			foreach (var name in names)
			{
				result += database.GetPopulation(name);
			}
			return result;
		}
	}
	public class DummyDatabase : IDatabase
	{
		public int GetPopulation(string name)
		{
			return new Dictionary<string, int>
			{
				["alpha"] = 1,
				["beta"] = 2,
				["gamma"] = 3,
			}[name];
		}
	}

	[TestFixture]
	public class SingletonTests
	{
		[Test]
		public void IsSingleTonTest()
		{
			Console.WriteLine("IsSingleTonTest");
			var db = SingleTonDatabase.Instance;
			var db2 = SingleTonDatabase.Instance;
			Assert.That(db, Is.SameAs(db2));
			Assert.That(SingleTonDatabase.Count, Is.EqualTo(1));
		}
		[Test]
		public void SingletonTotalPopulationTest()
		{
			var rf = new SingletonRecordFinder();
			var names = new[] { "Seoul", "maxico city" };
			/*int tp = rf.GetTotalPopulation(names);
			Assert.That(tp, Is.EqualTo(17500000 + 17400000));*/
		}
		[Test]
		public void ConfigurablePopulationTest()
		{
			var rf = new ConfigurableRecordFinder(new DummyDatabase());
			var names = new[] { "alpha", "gamma" };
			int tp = rf.GetTotalPopulation(names);
			Assert.That(tp, Is.EqualTo(4));
		}

		[Test]
		public void DIPopulationTest()
		{
			// 콘테이너빌드를 사용해서 싱글 인스턴스를 사용할수 있다. ? 
			var cb = new ContainerBuilder();
			cb.RegisterType<OrdinaryDatabase>()
				.As<IDatabase>()
				.SingleInstance();

			cb.RegisterType<ConfigurableRecordFinder>();
			using (var c = cb.Build())
			{
				var rf = c.Resolve<ConfigurableRecordFinder>();
			}
		}
	}

	public static class SingleTonIssue
	{
		public static void Test()
		{
			Console.WriteLine("\nSingleTonIssue Start");
			SingletonTests test = new SingletonTests();
			test.IsSingleTonTest();
			test.SingletonTotalPopulationTest();
			test.ConfigurablePopulationTest();
			//test.DIPopulationTest();
		}

	}
}
