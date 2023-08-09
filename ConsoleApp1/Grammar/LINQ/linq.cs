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
	}
}
