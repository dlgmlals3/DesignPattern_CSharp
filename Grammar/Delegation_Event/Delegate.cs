using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Delegate는 하나이상의 메소드의 레퍼런스를 저장할수 있는 레퍼런스 오브젝트..
/// Delegate는 이벤트를 생성하기 위해 블록{ } 을 생성한다.
/// 내부적으로 Delegate도 class 임.
/// 장점은 이벤트 핸들러 사용할때 효과적이다.
/// 
/// </summary>
namespace Grammar.Delegation
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

		public delegate void MyDelegateType3(int a, int b);
		public delegate void MyDelegateType2(double a, double b);
		
		/// <summary>
		/// 멀티 델리게이트의 경우 인풋은 상관없지만, 리턴타입은 void 입니다.
		/// </summary>
		public static void MultiDelegateTest()
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
			// result : Addition is 50, Multiplication is 400
		}
	}
}
