using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrammarCSharp_Event
{
	// delegate type
	public delegate int MyDelegateType(int a, int b);

	public class Publisher
	{
		//private MyDelegateType myDelegate;

		// step 1 : create event
		public event MyDelegateType myEvent;
		/*{
			add
			{
				myDelegate += value;
			}
			remove
			{
				myDelegate -= value;
			}
		}*/

		public int RaiseEvent(int a, int b)
		{
			// step 2 : raise event
			/*if (this.myDelegate != null)
			{
				this.myDelegate(a, b);
			}*/
			return myEvent(a, b);
		}
	}

	public class EventTest
	{
		/// <summary>
		/// anonymous method
		/// 함수의 리턴타입은 myEvent 의 type을 가져온다.
		/// No Function name.
		/// 외부 변수도 사용가능.
		/// Subscriber Publisher 같은 경우 사용한다. 
		/// </summary>
		public static void AnonymouseTest()
		{
			Publisher publisher = new Publisher();
			int k = 0;

			publisher.myEvent += delegate(int a, int b)
			{
				int c = a + b + k;
				Console.WriteLine(c);
				return c;
			};

			publisher.RaiseEvent(10, 30);
		}

		/// <summary>
		/// lambda anonymouse function 이랑 거의 동일
		/// delegate keyword 빼고 뒤에 에로우 => 키워드 붙임.
		/// </summary>
		public static void LamdaTest()
		{
			Publisher publisher = new Publisher();
			publisher.myEvent += (a, b) =>
			{
				int c = a + b;
				Console.WriteLine(c);
				return c;
			};

			publisher.RaiseEvent(10, 20);
		}

		/// <summary>
		/// 인라인 람다식은 한줄이고 body가 없다.
		/// body가 없으니, 로컬변수도 사용하지 못한다.
		/// Find 계열의 함수를 사용할때 사용한다...
		/// </summary>
		public static void InlineLambdaTest()
		{
			Publisher publisher = new Publisher();
			publisher.myEvent += (a, b) => a + b;
			var c = publisher.RaiseEvent(20, 20);
			Console.WriteLine(c);
		}

		public static void Test()
		{
			Subscriber subscriber = new Subscriber();
			Publisher publisher = new Publisher();

			// handle the event or subscribe to event
			publisher.myEvent += subscriber.Add;

			// invoke the event
			publisher.RaiseEvent(10, 20);
		}
	}
}
