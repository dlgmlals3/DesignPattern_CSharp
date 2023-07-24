
using static System.Console;

namespace DesignPattern
{
	
	class Builder
	{ 
		// Builder Pattern
		// 객체를 생성할때, 점진적으로 생성하는 로직.
		// 생성자에 모든 로직이 구현되려면 복잡 함.
		// 순차적으로 실행되는 함수(Setter) 형태이면 이해가 편함.
		public static void builder_1()
		{
			var builder = new HtmlBuilder("ul");
			builder.AddChild("li", "hello");
			builder.AddChild("li", "world");
			WriteLine(builder.ToString());
		}
	}
}
