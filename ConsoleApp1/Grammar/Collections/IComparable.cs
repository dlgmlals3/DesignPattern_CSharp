using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammar.Collections.IComparableExample
{
	class Employee : IComparable
	{
		public int EmpID { get; set; }
		public string EmpName { get; set; }
		public string Job { get; set; }

		public int CompareTo(object other)
		{
			var otherEmp = (Employee)other;
			return this.EmpName.CompareTo(otherEmp.EmpName);
		}

		public override string ToString()
		{
			return $"{{{nameof(EmpID)}={EmpID.ToString()}, {nameof(EmpName)}={EmpName}, {nameof(Job)}={Job}}}";
		}
	}

	/// //////////////////////////////////

	class CustomComparer : IComparer<Employee2>
	{
		public int Compare(Employee2 x, Employee2 y)
		{
			int result = 0;
			switch (this.sortBy)
			{
				case SortBy.EmpID:
					result = x.EmpID - y.EmpID;
					break;
				case SortBy.EmpName:
					result = (x.EmpName != null) ? x.EmpName.CompareTo(y.EmpName) : 0;
					break;
				case SortBy.Job:
					result = (x.Job != null) ? x.Job.CompareTo(y.Job) : 0;
					break;
			}
			return result;
			/*int result = x.EmpName.CompareTo(y.EmpName); // first sorting column
			if (result == 0)
			{
				result = x.Job.CompareTo(y.Job); // second sorting column
			}
			return result;*/
		}
		public SortBy sortBy { get; set; }
	}

	class Employee2
	{
		public int EmpID { get; set; }
		public string EmpName { get; set; }
		public string Job { get; set; }

		public override string ToString()
		{
			return $"{{{nameof(EmpID)}={EmpID.ToString()}, {nameof(EmpName)}={EmpName}, {nameof(Job)}={Job}}}";
		}
	}

	public enum SortBy
	{
		EmpID, EmpName, Job
	};

	public static class IComparableExample
	{
		public static void Test()
		{
			Console.WriteLine("\n IComparableExample");

			List<Employee> employees;
			employees = new List<Employee>()
			{
				new Employee(){ EmpID = 104, EmpName = "dlgmlasl3", Job = "Designer" },
				new Employee(){ EmpID = 105, EmpName = "dlgmlasl4", Job = "Developer" },
				new Employee(){ EmpID = 101, EmpName = "dlgmlasl5", Job = "Developer" },
				new Employee(){ EmpID = 102, EmpName = "dlgmlasl6", Job = "Developer" }
			};
			employees.Sort();

			Console.WriteLine(string.Join("\n", employees));


			Console.WriteLine("\n IComparer Example");
			var employees2 = new List<Employee2>()
			{
				new Employee2(){ EmpID = 104, EmpName = "dlgmlasl3", Job = "Designer" },
				new Employee2(){ EmpID = 105, EmpName = "dlgmlasl4", Job = "Developer" },
				new Employee2(){ EmpID = 101, EmpName = "dlgmlasl5", Job = "Developer" },
				new Employee2(){ EmpID = 102, EmpName = "dlgmlasl6", Job = "Developer" }
			};
			CustomComparer customComparer = new CustomComparer();
			customComparer.sortBy = SortBy.EmpID;
			employees2.Sort(customComparer);
			Console.WriteLine(string.Join("\n", employees2));

		}
	}
}
