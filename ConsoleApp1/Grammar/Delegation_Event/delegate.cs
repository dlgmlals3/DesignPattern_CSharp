using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrammarCSharp
{
	public class Sample
	{
		// target method
		public int Add(int a, int b)
		{
			int c = a + b;
			return c;
		}

		// target method 1
		public void Add2(double a, double b)
		{
			double c = a + b;
			Console.WriteLine("Addition is : " + c);
		}

		// target method 2
		public void Multiply(double a, double b)
		{
			double c = a * b;
			Console.WriteLine("multiplication is : " + c);
		}
	}

	public delegate int MyDelegateType(int a, int b);

	public class DelegateGrammar
	{
		public static void Test()
		{
			Sample s = new Sample();

			// create delegate object or delegate
			MyDelegateType myDeleagte;

			// add method reference to delegate
			myDeleagte = new MyDelegateType(s.Add);

			// invoke method using delegate object
			Console.WriteLine(myDeleagte.Invoke(30, 40));
		}

		public delegate void MyDelegateType2(double a, double b);
		public static void MultiTest()
		{
			// create object of sample
			Sample s = new Sample();

			// create reference variable of mydelegate
			MyDelegateType2 myDelegate;

			// add ref of First target method
			myDelegate = s.Add2;

			// add ref of second target method
			myDelegate += s.Multiply;

			// invoke both target methods Add method, and multiply method
			// add2, multiply method are executed orderly...
			// in caseof multi delegate, parameter is same, no return value
			myDelegate.Invoke(40, 10);

			Console.ReadKey();
		}
	}
}
