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
			// step 2 : raise event
			if (this.myDelegate != null)
			{
				this.myDelegate(a, b);
			}
		}
	}

	public class EventTest
	{
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
