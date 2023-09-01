using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Csharp.DesignPatterns.Adaptor.Assignment
{
    public class Square
    {
        public int Side;
    }

    public interface IRectangle
    {
        int Width { get; }
        int Height { get; }
    }

    public static class ExtensionMethods
    {
        public static int Area(this IRectangle rc)
        {
            return rc.Width * rc.Height;
        }
    }

    public class SquareToRectangleAdapter : IRectangle
    {
        private readonly Square sqaure;
        public SquareToRectangleAdapter(Square square)
        {
            this.sqaure = square;
        }
        public int Width => sqaure.Side;

        public int Height => sqaure.Side;
        // todo
    }
    public static class AdaptorAssignment
    {
        public static void Test()
        {
            var sq = new Square { Side = 11 };
            var adapter = new SquareToRectangleAdapter(sq);
            Assert.That(adapter.Area(), Is.EqualTo(121));
        }
	}
}
