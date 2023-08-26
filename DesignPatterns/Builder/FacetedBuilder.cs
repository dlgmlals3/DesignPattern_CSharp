using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Builder.FacetedBuilder
{
	public class Person
	{
		public string StreetAddress, Postcode, City;
		public string CompanyName, Position;
		public int AnnualIncome;
		
		public override string ToString()
		{
			return $"{nameof(StreetAddress)} : {StreetAddress}, {nameof(Postcode)} {Postcode}, {nameof(City)} : {City}";
		}
	}

	public class PersonBuilder // facade
	{
		// reference !
		protected Person person = new Person();

		public PersonJobBuilder Works => new PersonJobBuilder(person);

		public PersonAddressBuilder Lives => new PersonAddressBuilder(person);
		
		// implicit (암시적) PersonBuilder ==> Person type으로 변경
		// explicit (명시적) 명시적으로 변환할때 캐스팅 해줘야 함.
		public static explicit operator Person(PersonBuilder pb)
		{
			return pb.person;
		}
	}

	public class PersonJobBuilder : PersonBuilder
	{
		public PersonJobBuilder(Person person)
		{
			this.person = person;
		}
		public PersonJobBuilder At(string comanyName) 
		{
			person.CompanyName = comanyName;
			return this;
		}
		public PersonJobBuilder AsA(string position)
		{
			person.Position = position;
			return this;
		}
		public PersonJobBuilder Earning(int amount)
		{
			person.AnnualIncome = amount;
			return this;
		}
	}

	public class PersonAddressBuilder : PersonBuilder
	{
		public PersonAddressBuilder(Person person)
		{
			this.person = person;
		}
		public PersonAddressBuilder At(string streetAddress)
		{
			person.StreetAddress = streetAddress;
			return this;
		}
		public PersonAddressBuilder WithPostcode(string postcode)
		{
			person.Postcode = postcode;
			return this;
		}
		public PersonAddressBuilder In(string city)
		{
			person.City = city;
			return this;
		}
	}

	public static class FacetedBuilder
	{
		public static void Test()
		{
			var pb = new PersonBuilder();

			Person person = (Person)pb
				.Lives.At("123 London Road")
					  .In("London")
					  .WithPostcode("SW12AC")
				.Works.At("Fabrikam")
					  .AsA("Engineer")
					  .Earning(10000);

			Console.WriteLine(person);
		}
	}
}

