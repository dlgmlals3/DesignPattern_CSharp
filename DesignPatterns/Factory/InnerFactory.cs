using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Factory.InnerFactory
{
	public class Point
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

		private double x, y;

		/// <summary>
		/// 생성자 Point 접근하기 위해 Factory 클래스를 Point 클래스 내부로 이동.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		private Point(double x, double y)
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
			var point = Point.PointFactory.newCartesianPoint(0, 0);
			Console.WriteLine(point);
		}
	}

}
