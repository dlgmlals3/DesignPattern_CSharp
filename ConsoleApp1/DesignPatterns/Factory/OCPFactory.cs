﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DesignPatterns.Factory.OCP
{
	public interface IHotDrink
	{
		void Consume();
	}

	internal class Tea : IHotDrink
	{
		public void Consume()
		{
			Console.WriteLine("This tea is nice but I'd prefer it with milk.");
		}
	}

	internal class Coffee : IHotDrink
	{
		public void Consume()
		{
			Console.WriteLine("This coffee is sensational!.");
		}
	}

	public interface IHotDrinkFactory
	{
		IHotDrink Prepare(int amount);
	}

	internal class TeaFactory : IHotDrinkFactory
	{
		public IHotDrink Prepare(int amount)
		{
			Console.WriteLine($"Put in a tea bag, boil water, pour {amount}");
			return new Tea();
		}
	}
	internal class CoffeeFactory : IHotDrinkFactory
	{
		public IHotDrink Prepare(int amount)
		{
			Console.WriteLine($"Grind some beans, boil water, pour {amount} ml, add cream and sugar, and enjoy");
			return new Coffee();
		}
	}

	public class HotDrinkMachine
	{
		private List<Tuple<string, IHotDrinkFactory>> factories =
			new List<Tuple<string, IHotDrinkFactory>>();
		public HotDrinkMachine()
		{
			foreach (System.Type t in typeof(IHotDrinkFactory).Assembly.GetTypes())
			{
				Console.WriteLine("dlgmlals3 " + t.FullName);

				// IHotDrinkFactory를 상속받고, interface가 아닌 class만 select
				if (typeof(IHotDrinkFactory).IsAssignableFrom(t) && !t.IsInterface)
				{
					factories.Add(Tuple.Create(
						t.Name.Replace("Factory", string.Empty),
						(IHotDrinkFactory)Activator.CreateInstance(t)
					));
				}
			}
		}

		public IHotDrink MakeDrink()
		{
			Console.WriteLine("Available drinks");
			for (var index = 0; index < factories.Count; index++)
			{
				var tuple = factories[index];
				Console.WriteLine($"{index} : {tuple.Item1}");
			}

			while (true)
			{
				string s;
				
				if ((s = Console.ReadLine()) != null
					&& int.TryParse(s, out int i)
					&& i >= 0
					&& i < factories.Count)
				{
					Console.WriteLine("Specify amount : ");
					s = Console.ReadLine();
					if (s != null 
						&& int.TryParse(s, out int amount)
						&& amount > 0)
					{
						return factories[i].Item2.Prepare(amount);
					}
				}
				Console.WriteLine("Incorrect input, try again!");
			}
		}
	}

	public static class OOPFactory
	{
		public static void Test()
		{
			Console.WriteLine("\n OOPFactory Test");
			var machine = new HotDrinkMachine();
			var drink = machine.MakeDrink();
			drink.Consume();
		}
	}
}
