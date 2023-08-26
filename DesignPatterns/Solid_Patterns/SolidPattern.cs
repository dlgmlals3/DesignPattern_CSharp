using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
	class Solid_Patterns
	{
		public static void Structure_1()
		{
			var j = new journal();
			j.AddEntry("dlgmlals3");
			j.AddEntry("dlgmlals4");
			Console.WriteLine(j);

			var p = new Persistence();
			var filename = @"c:\Temp\journal.txt";
			p.SaveToFile(j, filename, true);
			Process.Start(filename);
		}

		public static void Filter_2()
		{
			var apple = new Product("dlgmlals1", Color.Green, Size.Small);
			var tree = new Product("dlgmlals2", Color.Green, Size.Large);
			var house = new Product("dlgmlals3", Color.Blue, Size.Medium);
			Product[] products = { apple, tree, house };
			var pf = new ProductFilter();
			Console.WriteLine("Green Products (old): ");
			foreach (var p in pf.FilterByColor(products, Color.Green))
			{
				Console.WriteLine($" - {p.Name} is green");
			}
		}

		public static void OpenClosed_3()
		{
			var apple = new Product("dlgmlals1", Color.Green, Size.Small);
			var tree = new Product("dlgmlals2", Color.Blue, Size.Medium);
			var house = new Product("dlgmlals3", Color.Red, Size.Large);
			Product[] products = { apple, tree, house };

			var bf = new BetterFilter();
			Console.WriteLine("Green Products (new)");
			foreach (var p in bf.Filter(
				products,
				new AndSpecification<Product>(
					new ColorSpecification(Color.Blue),
					new SizeSpecification(Size.Medium)
				)))
			{
				Console.WriteLine($" - {p.Name} is Blue & Medium");
			}
		}

		public static int Area(Rectangle r) => r.Width * r.Height;
		public static void Sustitution_4()
		{
			Rectangle rc = new Rectangle(2, 3);
			Console.WriteLine($"{rc} has area {Area(rc)}");

			Rectangle sq = new Square();
			sq.Width = 4;
			Console.WriteLine($"{sq} has area {Area(sq)}");
		}

		public class Research
		{
			//public Research(Relationship relationships)
			public Research(IRelationshipBrowser browser)
			{
				foreach (var p in browser.FindAllChildrenOf("John"))
				{
					Console.WriteLine($"John has a child {p.Name} ");
				}
			}
		}
		public static void DependentInversion_5()
		{
			var parent = new Person { Name = "John" };
			var child1 = new Person { Name = "Chris" };
			var child2 = new Person { Name = "Mery" };

			var relationships = new Relationships();
			relationships.AddParentAndChild(parent, child1);
			relationships.AddParentAndChild(parent, child2);
			new Research(relationships);
		}
	}
}
