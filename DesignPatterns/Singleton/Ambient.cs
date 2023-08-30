using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.DesignPatterns.Singleton.Ambient
{
	/// <summary>
	/// sealed 클래스는 BuildingContext를 다른 class에서 상속할수 없음.
	/// selaed 메소드로 정의하면, 
	/// 해당 메소드를 포함한 클래스를 다른 class에서 상속은 가능하지만,
	/// selaed 메소드는 override가 불가능.	
	/// virtual 메소드와 sealed 메소드는 반대의 개념..
	/// 
	/// Dispose 함수를 소멸자처럼 사용해서, 
	/// 생성자에 push 구분, Dispose() 에서 pop()을 통해 항상 stck에는 this 객체가 
	/// 있음을 보장한다.
	/// </summary>
	public sealed class BuildingContext : IDisposable
	{
		public int WallHeight;
		private static Stack<BuildingContext> stack = new Stack<BuildingContext>();

		static BuildingContext() 
		{
			stack.Push(new BuildingContext(0));
		}

		public BuildingContext(int wallHeight)
		{
			WallHeight = wallHeight;
			stack.Push(this);
		}
		public static BuildingContext Current => stack.Peek();

		public void Dispose()
		{
			if (stack.Count > 1)
			{
				stack.Pop();
			}
		}
	}

	public struct Point
	{
		private int x, y;
		public Point(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public override string ToString()
		{
			return $"{nameof(x)} {x} {nameof(y)} {y}";
		}
	}

	public class Wall
	{
		public Point Start, End;
		public int Height;
		public Wall(Point start, Point end)
		{
			Start = start;
			End = end;
			Height = BuildingContext.Current.WallHeight;
		}

		public override string ToString()
		{
			return $"{nameof(Start)} {Start} {nameof(End)} {End} {nameof(Height)} {Height}";
		}
	}

	public class Building
	{
		public List<Wall> Walls = new List<Wall>();

		public override string ToString()
		{
			var sb = new StringBuilder();
			foreach (var wall in Walls)
			{
				sb.AppendLine(wall.ToString());
			}
			return sb.ToString();
		}
	}
	public static class Ambient
	{
		public static void Test()
		{
			Console.WriteLine("\n Test");
			var house = new Building();
			// gnd 3000

			using (new BuildingContext(3000))
			{
				house.Walls.Add(new Wall(new Point(0, 0), new Point(5000, 0)));
				house.Walls.Add(new Wall(new Point(0, 0), new Point(0, 4000)));

				// 1st 3500
				using (new BuildingContext(3500))
				{
					house.Walls.Add(new Wall(new Point(0, 0), new Point(6000, 0)));
					house.Walls.Add(new Wall(new Point(0, 0), new Point(0, 4000)));
				}

				// gnd 3000
				house.Walls.Add(new Wall(new Point(0, 0), new Point(5000, 4000)));
			}
			Console.WriteLine(house);
		}
	}
}
