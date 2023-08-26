using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Factory.FactoryClass
{
	public static class PointFactory
	{
		public static Point newCartesianPoint(double x, double y)
		{
			return new Point(x, y);
		}
		public static Point newPolarPoint(double rho, double theta)
		{
			return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
		}
	}


	public class Point
	{
		private double x, y;

		/// <summary>
		/// Point class 접근권한은 Factory class 접근하기 위해 public으로 설정..
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public Point(double x, double y)
		{
			this.x = x;
			this.y = y;
		}

		public override string ToString()
		{
			return $"{nameof(x)} : {x} , {nameof(y)} : {y}";
		}
	}

	public static class FactoryClass
	{
		public static void Test()
		{
			var point = PointFactory.newCartesianPoint(0, 0);
			Console.WriteLine(point);
		}
	}

}
