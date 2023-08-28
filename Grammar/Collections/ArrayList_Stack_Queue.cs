using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammar.Collections.ArrayListExam
{
	class Employee
	{
		public string name;
	}
	/// <summary>
	/// Array List는 list와 동일하다. 차이점은 아무거나 다 넣을수있음.
	/// </summary>
	public static class ArrayListExam
	{
		class Student
		{
			public int Marks { get; set; }
			public int Rank { get; set; }

			public override string ToString()
			{
				return $"{{{nameof(Marks)}={Marks.ToString()}, {nameof(Rank)}={Rank.ToString()}}}";
			}
		}

		public static void Test()
		{
			Console.WriteLine("\n ArrayList");
			ArrayList arrayList = new ArrayList() { 100, 'A' };

			arrayList.Add(10);
			arrayList.Add(10.7);
			arrayList.Add("dlgmlals3");
			arrayList.Add(new Employee() { name = "dlgmlals" });

			foreach (var item in arrayList)
			{
				if (item is Employee emp)
				{
					Console.WriteLine(emp.name);
				}
				else
				{
					Console.WriteLine(item);
				}
			}


			Console.WriteLine("\n Stack");
			Stack<int> marks = new Stack<int>();
			marks.Push(45);
			marks.Push(61);
			marks.Push(80);
			Console.WriteLine(string.Join(" ", marks));

			Stack<Student> marks2 = new Stack<Student>();
			marks2.Push(new Student() { Marks = 45 });
			marks2.Push(new Student() { Marks = 61 });
			marks2.Push(new Student() { Marks = 80 });

			int r = 1;
			foreach (var item in marks2)
			{
				item.Rank = r++;
				Console.WriteLine(item);
			}

			// marks2.Pop();
			Console.WriteLine("Peek :  " + marks2.Peek());


			Console.WriteLine("\n Queue");
			Queue<string> queue = new Queue<string>();
			queue.Enqueue("Task 3");
			queue.Enqueue("Task 5");
			queue.Enqueue("Task 1");
			queue.Enqueue("Task 4");
			queue.Enqueue("Task 2");

			Console.WriteLine(string.Join(" ", queue));
			queue.Dequeue();
			Console.WriteLine(string.Join(" ", queue));
			Console.WriteLine(queue.Peek());
			
		}
	}
}
