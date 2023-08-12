/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	public abstract class BaseAttribute<T>
	{
		private T value;
		public BaseAttribute()
		{
			Console.WriteLine("BaseAttribute의 생성자 호출");
		}
		public void Common()
		{
			Console.WriteLine("BaseAttribute의 Common 호출");
		}
		public abstract void Add(in BaseAttribute<T> _other);
		public virtual T GetValue()
		{
			return value;
		}
		
	}
	

	public class ChildAttribute<T> : BaseAttribute<T>
		where T : new()
	{
		public T ChildValue { 
			get { return childValue; } 
		}
		private T childValue;

		public ChildAttribute(T v1) : base()
		{
			childValue = v1;
		}

		public override void Add(in BaseAttribute<T> other)
		{
			Console.WriteLine("ChildAttribute Add");
			childValue += (dynamic)other.GetValue();
		}
		public override T GetValue()
		{
			return childValue;
		}
	}

	public class GrandChildAttribute<T> : ChildAttribute<T>
		where T: new()
	{
		public T ChildValue { get { return childValue; } }
		private T childValue;
		public GrandChildAttribute(T v1) : base(v1)
		{
			childValue = v1;
		}
		
		public override void Add(in BaseAttribute<T> other)
		{
			Console.WriteLine("GrandChildAttribute Add");
			childValue += (dynamic)other.GetValue();
		}
		public override T GetValue()
		{
			return childValue;
		}
	}

	public class Test
	{
		static void Main(string[] args)
		{
			BaseAttribute<int> a = new ChildAttribute<int>(2);
			BaseAttribute<int> b = new GrandChildAttribute<int>(3);


			a.Add(b); // ChildAttribute의 Add가 호출.
			b.Add(a); // GrandChildAttribute Add가 호출.

			Console.WriteLine($"1 : {a.GetValue()}, type : {a.GetType()}"); // 4


		}
	}
}
*/