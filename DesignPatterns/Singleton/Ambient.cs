﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.DesignPatterns.Singleton.Ambient
{
	// dlgmlals3 sealed IDisposable 다시 공부
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
