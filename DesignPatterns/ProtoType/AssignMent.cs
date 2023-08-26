using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ProtoType.AssignMent
{
	public interface IPrototype<T>
	{
		T DeepCopy();
	}

	public class Point : IPrototype<Point>
	{        
        public int X, Y;

		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}

		public Point DeepCopy()
		{
			return (Point)MemberwiseClone();
		}

		public override string ToString()
		{
			return $"{nameof(X)} : {X} {nameof(Y)} : {Y}";
		}
	}

    public class Line : IPrototype<Line>
	{
        public Point Start, End;

		public Line(Point start, Point end)
		{
			Start = start;
			End = end;
		}

		
		public override string ToString()
		{
			return $"{nameof(Start)} : {Start} {nameof(End)} {End}";
		}


		public Line DeepCopy()
		{
			return new Line(Start.DeepCopy(), End.DeepCopy());
		}
	}

    public static class AssignMent
	{
		public static void Test()
		{
			Console.WriteLine("\nTest");
			var line = new Line(new Point(0, 0), new Point(2, 2));

			var copy = line.DeepCopy();
			copy.Start.X = 100; copy.Start.Y = 100; 

			Console.WriteLine(line);
			Console.WriteLine(copy);
		}
	}
}
