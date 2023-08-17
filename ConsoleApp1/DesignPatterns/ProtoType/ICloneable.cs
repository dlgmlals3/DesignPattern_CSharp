﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ProtoType
{
	public class Person : ICloneable
	{
		public string[] Names;
		public Address Address;

		public Person(string[] names, Address address)
		{
			Names = names;
			Address = address;
		}

		/// <summary>
		/// Deep Copy
		/// </summary>
		/// <param name="other"></param>
		public Person(Person other)
		{
			Names = other.Names;
			Address = new Address(other.Address);
		}

		public object Clone()
		{
			return new Person((string[])Names.Clone(), (Address)Address.Clone());
		}

		public override string ToString()
		{
			return $"{nameof(Names)} : {string.Join(" ", Names)}, {nameof(Address)} : {Address}";
		}
	}


	public class Address : ICloneable
	{
		public string StreetName;
		public int HouseNumber;

		public Address(string streetName, int houseNumber)
		{
			StreetName = streetName;
			HouseNumber = houseNumber;
		}

		/// <summary>
		/// Deep Copy
		/// </summary>
		/// <param name="otherAddress"></param>
		public Address(Address otherAddress)
		{
			StreetName = otherAddress.StreetName;
			HouseNumber = otherAddress.HouseNumber;
		}

		/// <summary>
		/// Shallow Copy not Depp copy.
		/// </summary>
		/// <returns></returns>
		public object Clone()
		{
			return new Address(StreetName, HouseNumber);
		}

		public override string ToString()
		{
			return $"{nameof(StreetName)} : {StreetName} {nameof(HouseNumber)} : {HouseNumber}";
		}
	}
	public static class ICloneableBad
	{
		/// <summary>
		/// john is changed to Jane !!
		/// So we use ICloneable interface
		/// </summary>
		public static void Test()
		{
			var john = new Person(new[] { "john", "Smith" }, new Address("gurogu", 3));
			var jane = (Person)john.Clone();
			jane.Names[0] = "KO";
			jane.Address.StreetName = "sindorim";
			
			Console.WriteLine(john);
			Console.WriteLine(jane);
		}
	}
}
