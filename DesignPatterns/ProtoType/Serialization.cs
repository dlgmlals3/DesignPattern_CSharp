using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace DesignPatterns.ProtoType.Serialization
{
	public static class ExtensionMethods
	{
		public static T DeepCopy<T>(this T self)
		{
			var stream = new MemoryStream();
			var formatter = new BinaryFormatter();
			formatter.Serialize(stream, self);
			stream.Seek(0, SeekOrigin.Begin);
			object copy = formatter.Deserialize(stream);
			stream.Close();
			return (T) copy;
		}

		public static T DeepCopyXml<T>(this T self)
		{
			using (var ms = new MemoryStream())
			{
				var s = new XmlSerializer(typeof(T));
				s.Serialize(ms, self);
				ms.Position = 0;
				return (T)s.Deserialize(ms);
			}
		}

		/// <summary>
		/// Extension API 신기허네
		/// static int 리턴 타입이고, (this string i) 요부분이 객체의 타입으로 들어감.
		/// </summary>
		public static int GetCountK(this string j)
		{
			return j.Length;
		}
	}

	public interface IDeepCopyable<T> where T : new()
	{
		void CopyTo(T target);
	}

	[Serializable]
	public class Person
	{
		public string[] Names;
		public Address Address;
		public Person()
		{

		}
		public Person(string[] names, Address address)
		{
			Names = names;
			this.Address = address;
		}

		public override string ToString()
		{
			return $"{nameof(Names)} : {string.Join(" ", Names)}, {nameof(Address)} {Address}";
		}
	}

	[Serializable]
	public class Address
	{
		public string StreetName;
		public int HouseNumber;

		public Address()
		{

		}
		public Address(string streetName, int houseNumber)
		{
			StreetName = streetName;
			HouseNumber = houseNumber;
		}

		public override string ToString()
		{
			return $"{nameof(StreetName)} : {StreetName} , {nameof(HouseNumber)} : {HouseNumber}";
		}
	}

	
	public static class Serialization
	{
		public static void Test()
		{
			Console.WriteLine("\nSerialization");
			var john = new Person(new[] { "John", "Smith" },
				new Address("London", 3000));
			//var jane = john.DeepCopy();
			var jane = john.DeepCopyXml();
			jane.Names[0] = "Jane";
			jane.Address.HouseNumber = 0;

			Console.WriteLine(john);
			Console.WriteLine(jane);

			//string k = "asdf";
			//Console.WriteLine(k.GetCountK());
		}
	}
}
