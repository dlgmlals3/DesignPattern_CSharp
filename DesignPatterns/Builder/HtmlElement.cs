using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Builder
{
	public class HtmlElement
	{
		public string Name, Text;
		public List<HtmlElement> Elements = new List<HtmlElement>();
		private const int indentSize = 2;
		public HtmlElement() {}

		public HtmlElement(string name, string text)
		{
			Name = name ?? throw new ArgumentNullException(paramName : nameof(name));
			Text = text ?? throw new ArgumentNullException(paramName: nameof(text));
		}

		private string ToStringImpl(int indent)
		{
			var sb = new StringBuilder();
			var i = new string(' ', indentSize * indent);
			sb.AppendLine($"{i}<{Name}>");
			if (!string.IsNullOrWhiteSpace(Text))
			{
				sb.Append(new string(' ', indentSize * (indent + 1)));
				sb.AppendLine(Text);
			}
			
			// recursive 하게 처리 가능하도록 함.
			foreach (var e in Elements)
			{
				sb.Append(e.ToStringImpl(indent + 1));
			}

			sb.AppendLine($"{i}</{Name}>");
			return sb.ToString();
		}

		public override string ToString()
		{
			return ToStringImpl(0);
		}
	}

	public class HtmlBuilder
	{
		private readonly string rootName;
		HtmlElement root = new HtmlElement();
		public HtmlBuilder(string rootName)
		{
			this.root.Name = rootName;
			this.rootName = rootName;
		}

		public HtmlBuilder AddChild(string childName, string childText)
		{
			var e = new HtmlElement(childName, childText);
			root.Elements.Add(e);
			return this;
		}

		public override string ToString()
		{
			return root.ToString();
		}

		public void Clear()
		{
			root = new HtmlElement { Name = rootName };
		}
	}
	class Builder
	{
		// Builder Pattern
		// 객체를 생성할때, 점진적으로 생성하는 로직.
		// 생성자에 모든 로직이 구현되려면 복잡 함.
		// 순차적으로 실행되는 함수(Setter) 형태이면 이해가 편함.
		public static void builder_1()
		{
			var builder = new HtmlBuilder("ul");
			builder.AddChild("li", "hello").AddChild("li", "world");
			Console.WriteLine(builder.ToString());
		}


	}
}
