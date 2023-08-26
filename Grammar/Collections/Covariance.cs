using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammar.Collections.Covariance
{
	class LivingThing
	{
		public int NumberOfLegrs { get; set; }
	}
	class Parrot : LivingThing
	{

	}

	class Dog : LivingThing
	{

	}

	/// <summary>
	/// Covariance 경우 out keyword 붙임.
	/// out 의미는 T를 return 형태로만 써라..parameter type 안됨..
	/// </summary>
	interface IMover<out T>
	{
		// Method(T t); // error not allowance use T in Paramter about convariance.
		// T Method1(); // allowance 
		public T Move();
	}

	class Mover<T> : IMover<T>
	{
		public T thing { get; set; }
		public T Move()
		{
			return thing;
		}
	}

	class Sample
	{
		public void PrintValues(List<object> values)
		{
			foreach (var item in values)
			{
				Console.Write(item + ",");
			}
			Console.WriteLine();
		}

		/// <summary>
		/// public void PrintValues(List<object> values)
		/// string 타입의 부모는 object이긴 하지만, 제네릭 안에 있기 때문에 error 발생.
		/// 이를 해결하기 위해 List class 내부에서 out T 라고 선언해야 하지만, 우리가 임의로 수정할수 없기 떄문에,
		/// Covariance 적용이 되어 있는 IEnumerable 타입으로 선언..
		/// public interface IEnumerable<out T> : IEnumerable
		/// </summary>
		public void PrintValues(IEnumerable<object> values)
		{
			foreach (var item in values)
			{
				Console.Write(item + ",");
			}
			Console.WriteLine();
		}
	}

	public static class Covariance
	{
		public static void Test()
		{
			Console.WriteLine("\n Convariance");
			LivingThing livingThing = new Parrot();
			Parrot parrot = new Parrot() { NumberOfLegrs = 2 };

			// Convariance
			// supply the child type (Parrot) name, where the parent type (LivingThing) is expected.
			IMover<LivingThing> mover = new Mover<Parrot>() { thing = parrot };

			// 이를 해결하기 위해서는 IMover 클래스에서 generic 선언할때 out t라고 선언.
			//Console.WriteLine("NumberOfLegs : " + mover.Move().NumberOfLegrs);

			Sample s = new Sample();
			// Convariance needs in genenric
			s.PrintValues(new List<string>() { "hello", "dlgmlals"});
		}
	}
}
