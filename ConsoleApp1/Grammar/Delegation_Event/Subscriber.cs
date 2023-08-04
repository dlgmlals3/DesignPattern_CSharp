using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrammarCSharp_Event
{
	class Subscriber
	{
		// target method (event handler)
		public int Add(int a, int b)
		{
			Console.WriteLine(a + b);
			return a + b;
		}

	}
}
