using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammar.Generic
{
	public class User<T>
	{
		// Generic field
		public T RegistrationStatus;
	}

	public class User<T1, T2>
	{
		// Generic field
		public T1 RegistrationStatus;
		public T2 Age;
	}

	public static class Generic
	{
		public static void Test()
		{
			Console.WriteLine("\nTest");
			User<int> k = new User<int>();
			User<bool> k2 = new User<bool>();
			k.RegistrationStatus = 1234;
			k2.RegistrationStatus = false;
			Console.WriteLine(k.RegistrationStatus + " " + k2.RegistrationStatus);
		}

		public static void MultiGenericTest()
		{
			Console.WriteLine("\nMultiGenericTest");
			User<int, int> user1 = new User<int, int>();
			// 나이때를 대략 아는 경우 35-40 저장할 string 필드 필요.
			User<bool, string> user2 = new User<bool, string>();

			user1.Age = 22;
			user2.Age = "35-40";
			Console.WriteLine(user1.Age + " " + user2.Age);
		}

		public abstract class Student
		{
			public abstract int Marks { get; set; }
		}
		public class GraduateStudent : Student
		{
			public override int Marks { get; set; }
		}
		public class PostGraduateStudent : Student
		{
			public override int Marks { get; set; }
		}

		public class MarksPrinter<T, T2> where T : Student
		{
			public T stu;
			public T2 score;
			public void PrintMarks()
			{
				Student tmp = (Student)stu;
				Console.WriteLine(tmp.Marks + " " + score);
			}

		}

		/// <summary>
		/// Constraint로 지정할수 있는 것들
		/// where T : class
		/// where T : struct
		/// where T : class Name
		/// where T : interface Name
		/// where T : new()
		///  new()는 매개 변수가 없는 기본 생성자를 가지는 형식에 대한 제약 조건이다
		/// </summary>
		public static void ConstraintTest()
		{
			Console.WriteLine("\nConstraintTest");
			MarksPrinter<GraduateStudent, int> gs = new MarksPrinter<GraduateStudent, int>();
			MarksPrinter<PostGraduateStudent, int> ps = new MarksPrinter<PostGraduateStudent, int>();
			gs.stu = new GraduateStudent() { Marks = 80 };
			gs.score = 40;
			ps.stu = new PostGraduateStudent() { Marks = 90 };
			gs.PrintMarks();
		}

		public class Employee_
		{
			public int Salary;
		}
		public class Student_
		{
			public int Marks;
		}
		/// <summary>
		/// class With generic method
		/// </summary>
		public class Sample
		{
			/// <summary>
			/// generic method
			/// printData<T1, T2, T3>(T1 a1, T2 a2, T3 a3)
			/// </summary>
			/// <typeparam name="T"></typeparam>
			/// <param name="obj"></param>
			public void PrintData<T>(T obj) where T : class
			{
				if (obj.GetType() == typeof(Student_))
				{
					Student_ temp = obj as Student_;
					Console.WriteLine(temp.Marks);
				}
				else if (obj.GetType() == typeof(Employee_))
				{
					Employee_ temp = obj as Employee_;
					Console.WriteLine(temp.Salary);
				}
			}
		}
		public static void GenericMethodTest()
		{
			Console.WriteLine("\n GenericMethodTest");
			Sample sample = new Sample();
			Employee_ emp = new Employee_() { Salary = 1000 };
			Student_ stu = new Student_() { Marks = 80};

			sample.PrintData<Employee_>(emp);
			sample.PrintData<Student_>(stu);
		}
	}
}
