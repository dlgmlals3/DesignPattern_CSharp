using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ProtoType.Inheritance
{
	public interface IDeepCopyable<T>
	{
		T DeepCopy();
	}

	public class Address : IDeepCopyable<Address>
	{
		public string Streetname;
		public int HouseNumber;

		public Address()
		{
		}
		public Address(string streetname, int housenumber)
		{
			Streetname = streetname;
			HouseNumber = housenumber;
		}

		public Address DeepCopy()
		{
			return (Address)MemberwiseClone();
		}

		public override string ToString()
		{
			return $"{nameof(Streetname)} : {Streetname}, {nameof(HouseNumber)} : {HouseNumber} ";
		}
	}

	public class Person : IDeepCopyable<Person>
	{
		public string[] Names;
		public Address Address;
		public Person()
		{

		}

		public Person(string[] names, Address address)
		{
			Names = names;
			Address = address;
		}

		public Person DeepCopy()
		{
			return new Person((string[])Names.Clone(), Address.DeepCopy()); // Deep Copy
		}

		public override string ToString()
		{
			return $"{nameof(Names)} : {string.Join(" ", Names)}, {nameof(Address)} : {Address}";
		}
	}
	
	public class Employee : Person, IDeepCopyable<Employee>
	{
		public int Salary;
		public Employee()
		{

		}
		public Employee(string[] names, Address address, int salary) : base(names, address)
		{
			Salary = salary;
		}
		public override string ToString()
		{
			return $"{base.ToString()} , {nameof(Salary)} : {Salary}";
		}

		// 부모에서 DeepCopy 함수가 이미 있고 abstract 함수가 아니기 때문에 자동으로 숨겨버림
		// 이때 숨기려는 것을 명시적으로 하려면 new 키워드를 붙임.
		public new Employee DeepCopy() // person을 가려버림
		{
			return new Employee((string[])Names.Clone(), Address.DeepCopy(), Salary); //deep Copy
			//return new Employee(Names, Address, Salary); //sallow copy
		}
	}

	public static class Inheritance
	{
		public static void Test()
		{
			Console.WriteLine("\n InHeritance Test");
			var john = new Employee();
			john.Names = new[] { "John", "Doe" };
			john.Address = new Address
			{
				HouseNumber = 123,
				Streetname = "London Road"
			};
			john.Salary = 321000;

			var copy = john.DeepCopy();
			copy.Names[1] = "Smith";
			copy.Address.HouseNumber++;
			copy.Salary = 123000;

			Console.WriteLine(john);
			Console.WriteLine(copy);
		}
	}
}
