using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_FunctionBuilder
{
	public class Person
	{
		public string Name, Position;
	}

	public sealed class PersonBuilder
	{
		private readonly List<Func<Person, Person>> actions =
		  new List<Func<Person, Person>>();
		
		// p 변수가 action 함수의 input인 Person class 타입이다.
		public PersonBuilder Called(string name)
		=> Do(p => { p.Name = name; });

		// Action 키워드는 리턴값이 없는 함수 포인터와 같음
		// Person 하나만 Input 으로 들어간다.
		public PersonBuilder Do(Action<Person> action)
		=> AddAction(action);

		public Person Build()
			=> actions.Aggregate(new Person(), (p, k) => k(p));

		private PersonBuilder AddAction(Action<Person> action)
		{
			// => 람다식
			// 람다식 받을 변수 = (input) => ( 함수 내용 )
			// p를 input으로 받고 p는 action 함수에 인자값이니, Person 이된다.
			actions.Add(p => { action(p); return p; });
			return this;
		}	
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

