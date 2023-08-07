using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GrammarCSharp
{
	class Student
	{
		public int StudentId { get; set; }
		public string StudentName { get; set; }
		public int Age { get; set; }
	}
	class Student_
	{
		private string _studentName;
		
		// statement가 둘이상이면 불가능.
		public int GetStudentNameLength() => _studentName.Length;

		// public constructors
		public Student_() => _studentName = "Harasha";

		// public properties
		public string StudentName
		{
			set => _studentName = value;
			get => _studentName;
		}
	}

	class ExpressionGrammar
	{
		public void ExpressionTest()
		{
			// Create Object of Student class
			var st = new Student() { StudentId = 101, StudentName = "Scott", Age = 15 };

			// Create expression tree with func
			Expression<Func<Student, bool>> expression = st => st.Age > 12 && st.Age < 20;

			// Compile expression using compile method to invoke it as delegate
			Func<Student, bool> myDelegate = expression.Compile();

			// execute the method
			bool result = myDelegate.Invoke(st);
			
			Console.WriteLine(result);
		}

		/// <summary>
		/// expression bodied member syntax : only one statement 
		/// constructor 도 expression body syntax 사용가능.
		/// c# 7.0에 도입됨.
		/// </summary>

		public void ExpressionBodyTest()
		{
			var st = new Student_() { StudentName = "Scott" };
			Console.WriteLine(st.StudentName);
			Console.WriteLine(st.GetStudentNameLength());
		}
	}
}
