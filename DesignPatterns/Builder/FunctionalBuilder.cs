using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Builder
{
	public class Person
	{
		public string Name, Position;
	}

	public abstract class FunctionalBuilder<TSubject, TSelf>
		where TSelf : FunctionalBuilder<TSubject, TSelf>
		where TSubject : new()
	{
		private readonly List<Func<Person, Person>> actions =
		  new List<Func<Person, Person>>();

		// Action 키워드는 리턴값이 없는 함수 포인터와 같음
		// Person 하나만 Input 으로 들어간다.
		public TSelf Do(Action<Person> action) => AddAction(action);

		// new Person() 초기값 
		// 함수 포인터에서 p는 new Person() 가리키는 듯? 
		// k는 actions list type
		public Person Build() => actions.Aggregate(new Person(), (p, k) => k(p));

		private TSelf AddAction(Action<Person> action)
		{
			Console.WriteLine("AddActions");
			actions.Add(p => { action(p); return p; });
			return (TSelf) this;
		}
	}

	public sealed class PersonBuilder : FunctionalBuilder<Person, PersonBuilder>
	{
		public PersonBuilder Called(string name) => Do(p => p.Name = name);
	}

	public static class PersonBuilderExtensions
	{
		public static PersonBuilder WorksAs
			(this PersonBuilder builder, string position)
			=> builder.Do(p => p.Position = position);
	}

	class FunctionalBuilder
	{
		public static void Test()
		{
			var person = new PersonBuilder()
				.Called("Sarah")
				.WorksAs("asdf")
				.Build();
		}
	}
}

