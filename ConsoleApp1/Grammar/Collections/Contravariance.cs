using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammar.Collections.Contraraiance
{
	class LivingThing
	{
		public int NumberOfLegrs { get; set; }
	}
	class Parrot : LivingThing
	{

	}

	class Dog : LivingThing
	{

	}

	interface IMover<in T>
	{
		void Move(T x);
	}

	class Mover<T> : IMover<T> where T : LivingThing
	{
		public void Move(T x)
		{
			if (x is Parrot)
			{
				Console.WriteLine("Moving width " + (x as Parrot).NumberOfLegrs + " legs");
			}
			else if (x is Dog)
			{
				Console.WriteLine("Moving width " + (x as Dog).NumberOfLegrs + " legs");
			}
			Console.WriteLine("Moving width " + x.NumberOfLegrs + " legs");
		}
	}

	public static class Contravariance
	{
		public static void Test()
		{
			Console.WriteLine("\n Contravariance");
			Parrot parrot = new Parrot() { NumberOfLegrs = 2 };
			Dog dog = new Dog() { NumberOfLegrs = 4 };

			IMover<Parrot> obj1 = new Mover<Parrot>(); // normal
			
			// contravariance
			// supply the parent type (LivingThing) name, where the cild type (Parrot) is expected.
			// use in keyword in IMover
			IMover<Parrot> obj2 = new Mover<LivingThing>();
			IMover<Dog> obj3 = new Mover<LivingThing>();
			obj2.Move(parrot);
			obj3.Move(dog);
		}
	}
}
