using System.Threading.Tasks;

namespace DesignPattern.Factory
{
	public static class FactoryAsync
	{
		public class Foo
		{
			private Foo()
			{

			}
			public static Task<Foo> CreateAsync()
			{
				return new Foo().InitAsync();
			}

			public async Task<Foo> InitAsync()
			{
				await Task.Delay(1000);
				return this;
			}
		}

		/// <summary>
		/// Foo 객체 생성시 InitAsync 함수 실행을 실수로 하지 않으면 제대로 초기화되지 않는 문제
		/// </summary>
		/// <returns></returns>
		public static async Task Test()
		{
			var x = Foo.CreateAsync();
		}


#if false
		public class Foo
		{
			public Foo()
			{
				// compile error this function is only used in method not constructor
				// await Task.Delay(1000);
			}
			public async Task<Foo> InitAsync()
			{
				await Task.Delay(1000);
				return this;
			}
		}

		/// <summary>
		/// Foo 객체 생성시 InitAsync 함수 실행을 실수로 하지 않으면 제대로 초기화되지 않는 문제
		/// </summary>
		/// <returns></returns>
		public static async Task Test()
		{
			var foo = new Foo();
			await foo.InitAsync();
		}
#endif
	}

}
