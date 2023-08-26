using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory.Assignment
{
    public class PersonFactory
	{
        private int id = 0;

        public Person CreatePerson(string name)
        {
            return new Person() { Id = id++, Name = name };
		}
	}

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

		public override string ToString()
		{
			return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}}}";
		}
	}

    public static class Assignment
	{
        public static void Test()
		{
			Console.WriteLine(" \n Assignment Test");
            var pf = new PersonFactory();
            var person1 = pf.CreatePerson("dlgmlals3");
            var person2 = pf.CreatePerson("dlgmlals4");
            Console.WriteLine(person1);
            Console.WriteLine(person2);
        }
	}
}
