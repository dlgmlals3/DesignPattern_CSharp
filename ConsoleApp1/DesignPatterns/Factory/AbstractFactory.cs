using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory.AbstractFactory
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
		// AvailableDrink에 항목을 추가하는 것이 open closed에 위반.
		public enum AvailableDrink
		{
			Coffee, Tea
		}
		private Dictionary<AvailableDrink, IHotDrinkFactory> factories = new Dictionary<AvailableDrink, IHotDrinkFactory>();
		public HotDrinkMachine()
		{
			foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
			{
				// 지정한 매개 변수와 가장 일치하는 생성자를 사용하여 지정한 유형의 인스턴스를 만듭니다.
				// CreateInstance의 파라메터에는 TeaFactory.
				// HotDrinkMacine 생성자 호출되면, AvailableDrink의 항목수만큼 factories dictionary에 추가됨.
				var factory = (IHotDrinkFactory)Activator.CreateInstance(
					Type.GetType("DesignPatterns.Factory.AbstractFactory." + Enum.GetName(typeof(AvailableDrink), drink) + "Factory")
				);
				factories.Add(drink, factory);
			}
		}
		public IHotDrink MakeDrink(AvailableDrink drink, int amount)
		{
			return factories[drink].Prepare(amount);
		}
	}

	public static class AbstractFactory
	{
		public static void Test()
		{
			Console.WriteLine("\nAbstractFactory Test");
			var machine = new HotDrinkMachine();
			var drink = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Tea, 100);
			drink.Consume();
		}		
	}
}
