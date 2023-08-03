using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrammarCSharp_Event
{
	// delegate type
	public delegate void MyDelegateType(int a, int b);

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

		public void RaiseEvent(int a, int b)
		{
			// step 2 : raise event
			/*if (this.myDelegate != null)
			{
				this.myDelegate(a, b);
			}*/
			myEvent(a, b);
		}
	}

	public class EventTest
	{
		public static void AnonymouseTest()
		{
			Publisher publisher = new Publisher();
			int k = 0;
			// anonymous method
			// 함수의 리턴타입은 myEvent 의 type을 가져온다.
			// No Function name.
			// 외부 변수도 사용가능.
			// Subscriber Publisher 같은 경우 사용한다. 
			publisher.myEvent += delegate(int a, int b)
			{
				int c = a + b + k;

				Console.WriteLine(c);
			};

			publisher.RaiseEvent(10, 30);
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
