using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Builder
{
	public class Person
	{
		public string Name;
		public string Position;
		public class Builder : PersonJobBuilder<Builder>
		{

		}
		public static Builder New => new Builder();

		public override string ToString()
		{
			return $"{nameof(Name)} : {Name}, {nameof(Position)} : {Position}";
		}
	}

	public abstract class PersonBuilder
	{
		protected Person person = new Person();
		public Person Build()
		{
			return person;
		}
	}

	// class Foo : Bar<Foo>
	public class PersonInfoBuilder<T> : PersonBuilder
		where T : PersonInfoBuilder<T>
	{
		public T Called(string name)
		{
			person.Name = name;
			return (T)this;
		}
	}

	public class PersonJobBuilder<T>
		: PersonInfoBuilder<PersonJobBuilder<T>>
		where T : PersonJobBuilder<T>
	{
		public T WorksAsA(string position)
		{
			person.Position = position;
			return (T) this;
		}
	}
}
