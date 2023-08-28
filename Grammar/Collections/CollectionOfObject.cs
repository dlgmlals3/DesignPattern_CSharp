using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammar.Collections.CollectionOfObject
{
	/// <summary>
	/// // Represennts a Product in ECommerce application
	/// </summary>
	public class Product
	{
		public int ProductID { get; set; }
		public string ProductName { get; set; }
		public double Price { get; set; }
		public DateTime DateOfManufacture { get; set; }

		public override string ToString()
		{
			return $"{{{nameof(ProductID)}={ProductID.ToString()}, {nameof(ProductName)}={ProductName}, {nameof(Price)}={Price.ToString()}, {nameof(DateOfManufacture)}={DateOfManufacture.ToString()}}}";
		}
	}

	public class Student
	{
		public int RollNo { get; set; }
		public string StudentName { get; set; }
		public string Email { get; set; }
		public Branch branch { get; set; }

		public override string ToString()
		{
			return $"{{{nameof(RollNo)}={RollNo.ToString()}, {nameof(StudentName)}={StudentName}, {nameof(Email)}={Email}, {nameof(branch)}={branch}}}";
		}
	}

	public class Branch
	{
		public string BranchName { get; set; }
		public int NoOfSemesters { get; set; }

		public override string ToString()
		{
			return $"{{{nameof(BranchName)}={BranchName}, {nameof(NoOfSemesters)}={NoOfSemesters.ToString()}}}";
		}
	}

	public static class CollectionOfObject
	{
		public static void Test2()
		{
			Console.WriteLine("\n Object Relations");
			Student student = new Student();
			student.RollNo = 123;
			student.StudentName = "Scott";
			student.Email = "scott@gmail.com";


			// one - to - one relation !!
			student.branch = new Branch();
			student.branch.BranchName = "computer science";
			student.branch.NoOfSemesters = 8;

			Console.WriteLine(student);
		}




		public static void Test()
		{
			Console.WriteLine("\n CollectionOfObject");
			List<Product> products = new List<Product>();
			string choice;
			do
			{
				Console.WriteLine("Enter Product ID");
				int pid = int.Parse(Console.ReadLine());
				Console.WriteLine("Enter ProductName");
				string pname = Console.ReadLine();
				Console.WriteLine("Enter Price ID");
				double price = double.Parse(Console.ReadLine());
				Console.WriteLine("Enter DateOfManufacture");
				DateTime dom = DateTime.Parse(Console.ReadLine());
				Product product = new Product()
				{
					ProductID = pid,
					ProductName = pname,
					Price = price,
					DateOfManufacture = dom
				};
				products.Add(product);
				Console.WriteLine("Product is added");
				Console.WriteLine("Do you wan to continue to next product ?");
				choice = Console.ReadLine();
			} while (choice != "No" || choice != "no" || choice != "n");

			foreach(Product item in products)
			{
				Console.WriteLine(item);
			}


			
		}

	}
}
