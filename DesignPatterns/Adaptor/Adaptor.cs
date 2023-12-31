﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Adaptor
{
    public class Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
        }

        public override bool Equals(object obj)
		{
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return base.Equals((Point)obj);
		}


		public override int GetHashCode()
        {
	        unchecked
	        {
		        return (X * 397) ^ Y;
	        }
        }
	}

    public class Line
    {
        public Point Start;
        public Point End;

        public Line(Point start, Point end)
        {
            this.Start = start;
            this.End = end;
        }

		public override int GetHashCode()
		{
			return HashCode.Combine(Start, End);
		}

		protected bool Equals(Object Other)
		{
            return Equals(Start, ((Line)Other).Start) && Equals(End, ((Line)Other).End);
		}

    }

    public class VectorObject : Collection<Line>
    {

    }

    public class VectorRectangle : VectorObject
    {
        public VectorRectangle(int x, int y, int width, int height)
        {
            Add(new Line(new Point(x, y), new Point(x + width, y)));
            Add(new Line(new Point(x + width, y), new Point(x + width, y + height)));
            Add(new Line(new Point(x, y), new Point(x, y + height)));
            Add(new Line(new Point(x, y + height), new Point(x + width, y + height)));
        }
    }

    public class LineToPointAdapter : IEnumerable<Point>
    {
        private static int count = 0;
        static Dictionary<int, List<Point>> cache = new Dictionary<int, List<Point>>();
        private int hash;

        public LineToPointAdapter(Line line)
        {
            hash = line.GetHashCode();
            if (cache.ContainsKey(hash)) return; // we already have it

            Console.WriteLine($"{++count}: Generating points for line [{line.Start.X},{line.Start.Y}]-[{line.End.X},{line.End.Y}] (with caching)");
            //                                                 ^^^^

            List<Point> points = new List<Point>();

            int left = Math.Min(line.Start.X, line.End.X);
            int right = Math.Max(line.Start.X, line.End.X);
            int top = Math.Min(line.Start.Y, line.End.Y);
            int bottom = Math.Max(line.Start.Y, line.End.Y);
            int dx = right - left;
            int dy = line.End.Y - line.Start.Y;

            if (dx == 0)
            {
                for (int y = top; y <= bottom; ++y)
                {
                    points.Add(new Point(left, y));
                }
            }
            else if (dy == 0)
            {
                for (int x = left; x <= right; ++x)
                {
                    points.Add(new Point(x, top));
                }
            }

            cache.Add(hash, points);
        }

        public IEnumerator<Point> GetEnumerator()
		{
            return cache[hash].GetEnumerator();
        }

		IEnumerator IEnumerable.GetEnumerator()
		{
            return GetEnumerator();
		}

		internal void ForEach(Action<Point> drawPoint)
		{
            /*while (GetEnumerator().MoveNext())
			{
                drawPoint(GetEnumerator().Current);
            }*/
            GetEnumerator().MoveNext();
            drawPoint(GetEnumerator().Current);
        }
	}

    public static class Adapter
    {
        private static readonly List<VectorObject> vectorObjects = new List<VectorObject>
        {
          new VectorRectangle(1, 1, 10, 10),
          new VectorRectangle(3, 3, 6, 6)
        };

        // the interface we have
        public static void DrawPoint(Point p)
        {
            Console.Write(".");
        }

        /// <summary>
        /// Foreach는 컬렉션에서 제공하는  집계함수
        /// 그밖에도 FindAll, Except, ToDictionary, Select, Sum, Aggregate
        /// </summary>
        private static void Draw()
        {
            foreach (var vo in vectorObjects)
            {
                foreach (var line in vo)
                {
                    var adapter = new LineToPointAdapter(line);
                    adapter.ForEach(DrawPoint);
                }
            }
        }
        public static void Test()
		{
            Console.WriteLine("\n Adaptor Test");
			Draw();
        }
    }
}
