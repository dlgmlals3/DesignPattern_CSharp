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
		public void Test()
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

		public void OrderTest()
		{
			Console.WriteLine("OrderTest");
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

		public void FirstOrDefulat()
		{
			Console.WriteLine("FirstOrDefulat");
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
			var filtered3 = employees.FirstOrDefault(emp => emp.Job == "Manager");
			if (filtered3 is not null)
			{
				Console.WriteLine(filtered3.EmpID + " " + filtered3.EmpName + " " + filtered3.Job + " " + filtered3.Salary);
			}
		}
	}
}
