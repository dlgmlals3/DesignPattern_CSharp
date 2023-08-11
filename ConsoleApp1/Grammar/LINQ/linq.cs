using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Grammar.LINQ
{
	class Employee
	{
		public int EmpID { get; set; }
		public string EmpName { get; set; }
		public string Job { get; set; }
		public string City { get; set; }
	}

	class Employee_S
	{
		public int EmpID { get; set; }
		public string EmpName { get; set; }
		public string Job { get; set; }
		public double Salary { get; set; }
	}
	class Templorary
	{
		public bool Check(Employee emp)
		{
			return emp.Job == "Manager";
		}
	}
	class LINQ
	{
		public static void Test()
		{
			List<Employee> employees = new List<Employee>()
			{
				new Employee() { EmpID = 101, EmpName = "A", Job = "Designer", City = "Tokyeo" },
				new Employee() { EmpID = 102, EmpName = "B", Job = "Doctor", City = "Seoul" },
				new Employee() { EmpID = 103, EmpName = "C", Job = "Student", City = "Boston" },
				new Employee() { EmpID = 104, EmpName = "D", Job = "Manager", City = "PP"},
				new Employee() { EmpID = 105, EmpName = "E", Job = "Manager", City = "JJ"}
			};

			// 람다식 사용. 
			// 리턴타입.
			IEnumerable<Employee> result = employees.Where(emp => (emp.Job == "Manager"));
			List<Employee> list = employees.Where(emp => (emp.Job == "Manager")).ToList();
			var result2 = result.Where(emp => (emp.EmpName == "D"));
			foreach (Employee item in result)
			{
				Console.WriteLine(item.EmpID + " " + item.EmpName + " " + item.Job + " " + item.City);
			}
		}

		public static void OrderTest()
		{
			Console.WriteLine("\nOrderTest");
			List<Employee_S> employees = new List<Employee_S>()
			{
				new Employee_S() { EmpID = 101, EmpName = "A", Job = "Designer", Salary = 7283 },
				new Employee_S() { EmpID = 102, EmpName = "B", Job = "Doctor", Salary = 7283 },
				new Employee_S() { EmpID = 103, EmpName = "C", Job = "Student", Salary = 7283 },
				new Employee_S() { EmpID = 104, EmpName = "E", Job = "Manager", Salary = 32323},
				new Employee_S() { EmpID = 105, EmpName = "E", Job = "Manager", Salary = 3333}
			};
			IEnumerable<Employee_S> sorted = employees.OrderBy(emp => emp.Salary);
			IEnumerable<Employee_S> sortedDescending = employees.OrderByDescending(emp => emp.Salary);

			// emp.job으로 정렬 후, 다시 empname으로 정렬.
			// ThenBy 쓴다음에 또 쓸수있음.
			IEnumerable<Employee_S> sortedJob = employees.OrderBy(emp => emp.Job)
				.ThenBy(emp => emp.EmpName)
				.ThenByDescending(emp => emp.Salary);

			foreach (Employee_S item in sortedJob)
			{
				Console.WriteLine(item.EmpID + "," + item.EmpName + "," + item.Job + "," + item.Salary);
			}
		}

		public static void FirstOrDefulat()
		{
			Console.WriteLine("\nFirstOrDefulat");
			List<Employee_S> employees = new List<Employee_S>()
			{
				new Employee_S() { EmpID = 101, EmpName = "A", Job = "Designer", Salary = 7283 },
				new Employee_S() { EmpID = 102, EmpName = "B", Job = "Doctor", Salary = 7283 },
				new Employee_S() { EmpID = 103, EmpName = "C", Job = "Student", Salary = 7283 },
				new Employee_S() { EmpID = 104, EmpName = "E", Job = "Manager", Salary = 32323},
				new Employee_S() { EmpID = 105, EmpName = "E", Job = "Manager", Salary = 3333}
			};

			var filtered = employees.Where(emp => emp.Job == "Manager").ToList();
			Console.WriteLine(filtered[0].EmpID + " " + filtered[0].EmpName);

			// First
			// Exception 발생...
			//var filtered2 = employees.First(emp => emp.Job == "Manager2");
			//Console.WriteLine(filtered2.EmpID + " " + filtered2.EmpName + " " + filtered2.Job + " " + filtered2.Salary);

			// First와 달리 Exception 발생하지 않고 없으면 null을 리턴함.
			Employee_S filtered3 = employees.FirstOrDefault(emp => emp.Job == "Manager");
			if (filtered3 is not null)
			{
				Console.WriteLine(filtered3.EmpID + " " + filtered3.EmpName + " " + filtered3.Job + " " + filtered3.Salary);
			}
		}

		public static void Last_LastOrDefault()
		{
			Console.WriteLine("\nLast_LastOrDefault");
			List<Employee> employees = new List<Employee>()
			{
				new Employee() { EmpID = 101, EmpName = "A", Job = "Designer", City = "Tokyeo" },
				new Employee() { EmpID = 102, EmpName = "B", Job = "Doctor", City = "Seoul" },
				new Employee() { EmpID = 103, EmpName = "C", Job = "Student", City = "Boston" },
				new Employee() { EmpID = 104, EmpName = "D", Job = "Manager", City = "PP"},
				new Employee() { EmpID = 105, EmpName = "E", Job = "Manager", City = "JJ"}
			};

			// Where
			List<Employee> filtered = employees.Where(emp => emp.Job == "Manager").ToList();
			Console.WriteLine(filtered[filtered.Count - 1].EmpName + " " + filtered[filtered.Count - 1].Job);

			// Last
			Employee last = employees.Last(emp => emp.Job == "Manager");
			Console.WriteLine(last.EmpName + " " + last.Job);

			// LastOrDefault
			Employee lastOrDefault = employees.LastOrDefault(emp => emp.Job == "Manager2");
			if (lastOrDefault is null)
			{
				Console.WriteLine("not exception, is null");
			}
			else
			{
				Console.WriteLine(lastOrDefault.EmpName + " " + lastOrDefault.Job);
			}
		}
		public static void ElementAtOrDefault()
		{
			Console.WriteLine("\nElementAtOrDefault");
			List<Employee> employees = new List<Employee>()
			{
				new Employee() { EmpID = 101, EmpName = "A", Job = "Designer", City = "Tokyeo" },
				new Employee() { EmpID = 102, EmpName = "B", Job = "Doctor", City = "Seoul" },
				new Employee() { EmpID = 103, EmpName = "C", Job = "Manager", City = "Boston" },
				new Employee() { EmpID = 104, EmpName = "D", Job = "Manager", City = "PP"},
				new Employee() { EmpID = 105, EmpName = "E", Job = "Manager", City = "JJ"}
			};

			// how to get middle item
			var filtered = employees.Where(emp => emp.Job == "Manager").ElementAt(1);
			Console.WriteLine(filtered.EmpName + " " + filtered.Job);

			// raise exception...
			//var filtered2 = employees.Where(emp => emp.Job == "Manager").ElementAt(4);

			var filtered3 = employees.Where(emp => emp.Job == "Manager").ElementAtOrDefault(0);
			if (filtered3 is null)
			{
				Console.WriteLine("not exception is null");
			}
			else
			{
				Console.WriteLine(filtered3.EmpName + " " + filtered3.Job);
			}
		}

		public static void SingleOrDefault()
		{
			Console.WriteLine("\nSingleOrDefault");
			List<Employee> employees = new List<Employee>()
			{
				new Employee() { EmpID = 101, EmpName = "A", Job = "Designer", City = "Tokyeo" },
				new Employee() { EmpID = 102, EmpName = "B", Job = "Doctor", City = "Seoul" },
				new Employee() { EmpID = 103, EmpName = "C", Job = "Manager", City = "Boston" },
				new Employee() { EmpID = 104, EmpName = "D", Job = "Manager", City = "PP"},
				new Employee() { EmpID = 105, EmpName = "E", Job = "Manager", City = "JJ"}
			};

			// 전체목록에서 오직 하나만 있어야함.. 그렇지 않을 경우 exception
			//Employee first = employees.Single(emp => emp.Job == "Manager2");			

			// 데이터가 여러개인 경우에는 single, singleOrDefault 전부 Exception
			// Employee singleOrDefault = employees.SingleOrDefault(emp => emp.Job == "Manager");

			// SingleOrDefault
			// 데이터가 없는 경우 null 리턴.
			Employee singleOrDefault2 = employees.SingleOrDefault(emp => emp.EmpID == 105);
			if (singleOrDefault2 is not null)
			{
				Console.WriteLine(singleOrDefault2.EmpID + " " + singleOrDefault2.EmpName);
			}
		}

		class Person
		{
			public string PersonName { get; set; }
		}

		public static void Select()
		{
			Console.WriteLine("\nSelect");
			List<Employee> employees = new List<Employee>()
			{
				new Employee() { EmpID = 101, EmpName = "A", Job = "Designer", City = "Tokyeo" },
				new Employee() { EmpID = 102, EmpName = "B", Job = "Doctor", City = "Seoul" },
				new Employee() { EmpID = 103, EmpName = "C", Job = "Manager", City = "Boston" },
				new Employee() { EmpID = 104, EmpName = "D", Job = "Manager", City = "PP"},
				new Employee() { EmpID = 105, EmpName = "E", Job = "Manager", City = "JJ"}
			};
			IEnumerable<int> result = employees.Select(emp => 10);
			foreach (var item in result)
			{
				Console.WriteLine(item);
			}
			
			List<Person> result2 = employees.Select(emp => new Person() { PersonName = emp.EmpName} ).ToList();
			foreach (var item in result2)
			{
				Console.WriteLine(item.PersonName);
			}
			Console.WriteLine("filtered\n");
			List<Person> filtered = employees.Where(emp => emp.Job == "Manager").Select(emp => new Person() { PersonName = emp.EmpName }).ToList();
			foreach (var item in filtered)
			{
				Console.WriteLine(item.PersonName);
			}
		}

		public static void MinMax()
		{
			Console.WriteLine("\nMinMax");
			List<Employee_S> employees = new List<Employee_S>()
			{
				new Employee_S() { EmpID = 101, EmpName = "A", Job = "Designer", Salary = 322 },
				new Employee_S() { EmpID = 102, EmpName = "B", Job = "Doctor", Salary = 1143 },
				new Employee_S() { EmpID = 103, EmpName = "C", Job = "Student", Salary = 7283 },
				new Employee_S() { EmpID = 104, EmpName = "E", Job = "Manager", Salary = 32323},
				new Employee_S() { EmpID = 105, EmpName = "E", Job = "Manager", Salary = 3333}
			};
			
			// This Group method...
			double min = employees.Min(emp => emp.Salary);
			double max = employees.Max(emp => emp.Salary);
			double sum = employees.Sum(emp => emp.Salary);
			double avg = employees.Average(emp => emp.Salary);
			double cnt = employees.Count();
			Console.WriteLine(min + " " + max + " " + sum + " " + avg + " " + cnt);
		}
	}
}
