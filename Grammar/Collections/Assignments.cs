using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammar.Collections.Assignments
{
	public class FirstAssignments
	{
        public List<int> FindLargest(List<List<int>> collections)
        {
            List<int> finalValues = new List<int>();
            foreach (var item in collections)
            {
				finalValues.Add(item.Max());
            }
            return finalValues;
        }

        public void Test()
		{
			var largestGroup = FindLargest(new List<List<int>>() {
				new List<int>( ) { 67, 100, 23 },
				new List<int>( ) { 80, 99, 750, 99 },
				new List<int>( ) { 888, 333, 9898 } });
			Console.WriteLine(string.Join(" ", largestGroup));
		}
	}



	public class SecondAssignments
	{

		interface ILonable
		{
			public int LoanPeriod();
			public void Borrow();
			public void Retrun();

		}
		interface IPrintable
		{
			void Print();
		}

		class Book : IPrintable, ILonable
		{
			public string Author;
			public string Title;
			public int ISBN;

			public int LoanPeriod()
			{
				return 21;
			}

			public void Print()
			{
				throw new NotImplementedException();
			}
		}

		class DVD : IPrintable, ILonable
		{
			public string Director;
			public string Title;
			public int LengthInMinutes;

			public int LoanPeriod()
			{
				return 7;
			}

			public void Print()
			{
				throw new NotImplementedException();
			}
		}
		class CD : IPrintable, ILonable
		{
			public string Artist;
			public string Title;
			public int NumberOfTrakcs;

			public int LoanPeriod()
			{
				return 14;
			}

			public void Print()
			{
				throw new NotImplementedException();
			}
		}
		public class Library 
		{
			private List<>
		}
		public void Test()
		{

		}
	}
}
