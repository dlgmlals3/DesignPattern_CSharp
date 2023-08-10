using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Builder
{
	public enum CarType
	{
		Sedan,
		CrossOver,
	}

	public class Car
	{
		public CarType Type;
		public int WheelSize;
		public override string ToString()
		{
			return $"{nameof(Type)} is {Type}, {nameof(WheelSize)} is {WheelSize} ";
		}
	}

	public interface ISpecifyCarType
	{
		ISpecifyWeelSize OfType(CarType type);
	}

	public interface ISpecifyWeelSize
	{
		IBuildCar WithWheels(int size);
	}

	public interface IBuildCar
	{
		public Car Build();
	}

	public class CarBuilder
	{
		private class Impl :
			ISpecifyCarType,
			ISpecifyWeelSize,
			IBuildCar

		{
			private Car car = new Car();
			public Car Build()
			{
				Console.WriteLine($"{car.WheelSize}");
				return car;
			}

			public ISpecifyWeelSize OfType(CarType type)
			{
				car.Type = type;
				return this;
			}

			public IBuildCar WithWheels(int size)
			{
				switch (car.Type)
				{
					case CarType.CrossOver when size < 17 || size > 20:
					case CarType.Sedan when size < 15 || size > 17:
						throw new ArgumentException($"Wrong size of wheel for {car.Type}.");
				}
				car.WheelSize = size;
				return this;
			}

			
		}
		public static ISpecifyCarType Create()
		{
			return new Impl();
		}
	}

	class StepWiseBuilder
	{
		static public void Test()
		{
			Car car = CarBuilder.Create() // ISpecifyCarType
				.OfType(CarType.CrossOver) // ISpeficyWheelSize
				.WithWheels(18) // IBuilderCar
				.Build();
			Console.WriteLine(car);
		}
	}
}
