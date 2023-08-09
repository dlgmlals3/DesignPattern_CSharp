using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrammarCSharp_Event
{
	class SwitchExpression
	{
		public void Test()
		{
			int operation = 1;
			string result;

			result = operation switch
			{
				1 => "Customer",
				2 => "Employee",
				3 => "Distributor",
				_ => "No case available"
			};

			Console.WriteLine(result);
		}
	}
}
