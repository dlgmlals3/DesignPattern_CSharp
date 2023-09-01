using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammar.Delegation.Publisher
{
	class Subscriber
	{
		// target method (event handler)
		public int Add(int a, int b)
		{
			Console.WriteLine("Subscriber : " + (a + b));
			return a + b;
		}
		public int Subtract(int a, int b)
		{
			Console.WriteLine("Subscriber : " + (a - b));
			return a - b;
		}

	}

	// delegate type
	public delegate int MyDelegateType(int a, int b);

	/// <summary>
	/// 1. Create Events 
	/// 2. Subscribe to the Events
	/// 3. Send(raised) Event
	/// 4. Invoke the Event Handler method Automatically
	/// </summary>
	public class EventPublisher
	{
		private MyDelegateType myDelegate;
		// step 1 : create event
		public event MyDelegateType myEvent
		{
			add
			{
				myDelegate += value;
			}
			remove
			{
				myDelegate -= value;
			}
		}

		public void RaiseEvent(int a, int b)
		{
			if (myDelegate != null)
			{
				this.myDelegate(a, b);
			}
		}
	}

	/// <summary>
	/// myDelegate 선언할때 앞에 event 키워드를 붙여주면
	/// create event 과정을 생략할수 있다. 
	/// public event MyDelegateType myEvent ( add, remove ) 
	/// </summary>
	public class AutoCreatedPublisher
	{
		public event MyDelegateType myDelegate;

		public void RaiseEvent(int a, int b)
		{
			if (myDelegate != null) myDelegate(a, b); 
		}
	}

	/// <summary>
	/// Action은 리턴타입을 정의할수 없다. only void
	/// </summary>
	public class ActionPublisher
	{
		public event Action<int, int> myAction;

		public void RaiseAction(int a, int b)
		{
			if (myAction != null)
			{
				myAction(a, b);
			}
		}
	}



	//child class of EventArgs
	public class CustomEventArgs : EventArgs
	{
		public int a { get; set; }
		public int b { get; set; }
	}




	public class Publisher
	{
		public event Func<int, int, int, int> myFunc;
		// step 1 : create event
		public event Action<int, int> myAction;
		
		// step 1 : create event
		public event Predicate<int> myPredicate;

		// step 1 : create event
		public event EventHandler<CustomEventArgs> myEventHandler;

		// step 1 : create event
		public event MyDelegateType myEvent;
		

		public int RaiseEvent(int a, int b)
		{
			// step 2 : raise event
			/*if (this.myDelegate != null)
			{
				this.myDelegate(a, b);
			}*/
			return myEvent(a, b);
		}

		public int RaiseEvent(int a, int b, int c)
		{
			return myFunc(a, b, c);
		}

		public void RaiseAction(int a, int b)
		{
			myAction(a, b);
		}

		public bool RaiseAction(int a)
		{
			return myPredicate(a);
		}

		public void RaiseEventHandler(object sender, int a, int b)
		{
			if (this.myEventHandler != null)
			{
				CustomEventArgs args = new CustomEventArgs() { a = a, b = b };
				this.myEventHandler(sender, args);
			}
		}
	}

	public class EventTest
	{
	
		public static void EventPublisherTest()
		{
			Subscriber subscriber = new Subscriber();
			EventPublisher publisher = new EventPublisher();

			// handle the event or subscribe to event
			publisher.myEvent += subscriber.Add;
			publisher.myEvent += subscriber.Subtract;
			// invoke the event
			publisher.RaiseEvent(10, 20);
		}

		public static void AutoCreatedPublisherTest()
		{
			Console.WriteLine("\n AutoCreatedPublisherTest");
			var publisher = new AutoCreatedPublisher();
			var subscriber = new Subscriber();

			publisher.myDelegate += subscriber.Add;
			publisher.RaiseEvent(10, 20);
		}


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

			publisher.myEvent += delegate (int a, int b)
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

		/// <summary>
		/// Func는 람다식만 가능 리턴 가능.
		/// </summary>
		public static void FuncTest()
		{
			Publisher publisher = new Publisher();
			publisher.myFunc += (a, b, c) => a + b + c;
			var c = publisher.RaiseEvent(10, 20, 30);
			Console.Write(c);
		}


		/// <summary>
		/// Action은 람다식 불가능 리턴 안됨.
		/// </summary>
		public static void ActionTest2(int a, int b)
		{
			Console.WriteLine("ActionTest2 : " + (a + b));
		}
		public static void ActionTest()
		{
			Console.WriteLine("\n ActionTest");
			var publisher = new ActionPublisher();
			publisher.myAction += (a, b) =>
			{
				Console.WriteLine(a + b);
			};
			publisher.myAction += ActionTest2;
			publisher.RaiseAction(10, 20);
		}

		/// <summary>
		/// 프리디케이트는 람다식만 가능 리턴은 bool 타입
		/// </summary>
		public static void PredicateTest()
		{
			Publisher publisher = new Publisher();
			publisher.myPredicate += (a) => a > 5;
			var a = publisher.RaiseAction(0);
			var b = publisher.RaiseAction(10);
			var c = publisher.RaiseAction(20);
			Console.WriteLine($"{a} {b} {c}");
		}

		public void EventHandlerTest()
		{
			Publisher publisher = new Publisher();
			publisher.myEventHandler += (sender, e) =>
		 	{
				var c = e.a + e.b;
				Console.WriteLine(c);	
			};
			publisher.RaiseEventHandler(this, 10, 20);
		}
	}
}
