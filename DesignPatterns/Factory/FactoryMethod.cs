using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Factory
{
	/// <summary>
	/// Factory 메소드의 장점 : API를 오버로딩 할수있음. API name으로 목적을 명확하게 함.
	/// </summary>
	public class Point
	{
		/// <summary>
		/// factory method
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public static Point newCartesianPoint(double x, double y)
		{
			return new Point(x, y);
		}

		public static Point newPolarPoint(double rho, double theta)
		{
			return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
		}

		private double x, y;

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

	public static class FactoryMethod
	{
		public static void Test()
		{
			var point = Point.newPolarPoint(1.0, Math.PI / 2);
			Console.WriteLine(point);
		}
	}


#if false
	/// <summary>
	/// 해당 소스의 문제점
	/// </summary>
	public class Point
	{
		public enum CoordinateSystem
		{
			Cartesian,
			Polar
		}
		private double x, y;
		
		/// <summary>
		/// Initializes a point from EITHER cartesian or polar
		/// That makes confusion to developer!!!
		/// </summary>
		/// <param name="a">if cartesian, rho if polar </param>
		/// <param name="b"></param>
		/// <param name="system"></param>
		public Point(double a, double b, CoordinateSystem system = CoordinateSystem.Cartesian)
		{
			switch (system)
			{
				case CoordinateSystem.Cartesian:
					x = a;
					y = b;
					break;
				case CoordinateSystem.Polar:
					y = a * Math.Cos(b);
					y = a * Math.Sin(b);
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(system), system, null);
			}
		}
	}
#endif
}
