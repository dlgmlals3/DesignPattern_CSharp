using System;
using System.Collections.Generic;

namespace Grammar.Collections.List
{
	public static class ListCollection
	{
		public static void Test()
		{
			List<int> myList;
			List<int> otherList;

			/// AddRange
			myList = new List<int>(10) { 10, 20, 30 };
			otherList = new List<int>() { 50, 60, 70 };
			myList.AddRange(otherList); // 10 20 30 50 60 70
			Console.WriteLine("1. AddRange : " + string.Join(" ", myList));
			
			//// Insert
			myList = new List<int>(10) { 10, 20, 30 };
			myList.Insert(1, 100); // 10 100 20 30
			Console.WriteLine("2. Insert : " + string.Join(" ", myList));
			
			//// InsertRange
			myList = new List<int>(10) { 10, 20, 60 };
			otherList = new List<int> { 30, 40, 50 };
			myList.InsertRange(2, otherList); // 10 20 30 40 50 60
			Console.WriteLine("3. InsertRange : " + string.Join(" ", myList));

			//// Remove
			myList = new List<int>(10) { 10, 20, 30, 40, 50 };
			// remove 30, value method
			myList.Remove(30); // 10 20 40 50
			Console.WriteLine("4. Remove : " + string.Join(" ", myList));

			//// RemoveAt
			myList = new List<int>(10) { 10, 20, 30, 40, 50 };
			if (2 < myList.Count)
			{
				// removeAt 30, index method need to check
				myList.RemoveAt(2); // 10 20 40 50
			}
			Console.WriteLine("5. RemoveAt : " + string.Join(" ", myList));

			////
			myList = new List<int>(10) { 10, 20, 30, 40, 50 };
			myList.RemoveRange(2, 3); // 10 20
			Console.WriteLine("6. RemoveRange : " + string.Join(" ", myList));

			/// 파라메터 안에 predicate 나오면 람다식 적용..
			myList = new List<int>(10) { 10, 20, 30, 40, 50 };
			myList.RemoveAll(value => value >= 30); // 10 20
			Console.WriteLine("6. RemoveAll : " + string.Join(" ", myList));

			/// Clear
			myList = new List<int>(10) { 10, 20, 30, 40, 50 };
			myList.Clear();
			Console.WriteLine("7. Clear : " + string.Join(" ", myList));

			/// IndexOf
			/// IndexOf is Sequential Search... 성능 느림.
			myList = new List<int>(10) { 10, 20, 30, 40, 50, 40 };
			int n = myList.IndexOf(40); // 3
			int n2 = myList.IndexOf(70); // -1
			// IndexOf(foundNumber, startIndex)
			int n3 = myList.IndexOf(40, n + 1); // 5
			Console.WriteLine($"8. IndexOf : {n} n2 : {n2} n3 : {n3}");

			/// Binary Search
			myList = new List<int>(10) { 10, 20, 30, 40, 50, 60 };
			int n4 = myList.BinarySearch(30);
			int n5 = myList.BinarySearch(80);
			Console.WriteLine($"9 Binary search of 40 {n4}"); // 2
			Console.WriteLine($"10 Binary search of 80 {n5}"); // ???

			/// contains
			myList = new List<int>(10) { 10, 20, 30, 40, 50, 60 };
			bool b = myList.Contains(110);
			Console.WriteLine($"110 is {b}");

			// Sort
			myList = new List<int>(10) { 1, 20, 3, 5, 4, 0 };
			myList.Sort();
			Console.WriteLine($"11. Sort {string.Join(" ", myList)}");
			myList.Reverse();
			Console.WriteLine($"12. Reverse  {string.Join(" ", myList)}");

			// ToArray
			List<string> myFriends;
			myFriends = new List<string>() { "Scott", "Allen", "James", "Jones" };
			string[] array = myFriends.ToArray();
			Console.WriteLine($"13 ToArray : {string.Join(" ", array)}");

			// Foreach lambda expresion
			myFriends = new List<string>() { "Scott", "Allen", "James", "Jones" };
			myFriends.ForEach(friend => {
				if (friend is "Scott")
				{
					Console.WriteLine(friend); // Scott
				}
			});

			// Exist
			myList = new List<int>(10) { 49, 20, 34, 51, 94, 10 };
			// 적어도 하나라도 성립하면 true , 아니면 fail
			bool ret = myList.Exists(m => m < 11);
			Console.WriteLine($"14. {ret}"); // true

			// Find
			// 람다 조건에 부합하는 가장 빠른 값을 리턴.
			int num, num2;
			myList = new List<int>(10) { 49, 20, 34, 51, 94, 20, 10 };
			num = myList.Find(m => m < 35);
			Console.WriteLine($"15. {num}"); // 20
			num = myList.Find(m => m < 5); // not found data
			Console.WriteLine($"16. {num}"); // 0

			// FindIndex.
			myList = new List<int>(10) { 49, 20, 34, 51, 94, 20, 10 };
			num = myList.FindIndex(m => m <= 20); // 1
			Console.WriteLine($"17. {num}");

			// FindLast
			myList = new List<int>(10) { 49, 20, 34, 51, 94, 20, 10 };
			num = myList.FindLast(m => m >= 20); // 20
			Console.WriteLine($"18. {num}");

			// FindLastIndex
			// 중복된 데이터중에 마지막으로 찾은 것 리턴.
			myList = new List<int>(10) { 49, 20, 34, 51, 94, 20, 10 };
			num = myList.FindLastIndex(m => m >= 20); // 5
			Console.WriteLine($"19. {num}");

			// !!!! FindAll
			myList = new List<int>(10) { 49, 20, 34, 51, 94, 20, 10 };
			var match = myList.FindAll(value => value >= 50); // 51, 94
			Console.WriteLine($"20. {string.Join(" ", match)}");

			// ConvertAll lambda
			myList = new List<int>(10) { 49, 20, 34, 51, 94, 20, 10 };
			List<string> doubleList = myList.ConvertAll(value =>
			{
				return Convert.ToString(value);
			});
			doubleList = myList.ConvertAll(value => Convert.ToString(value));

			Console.WriteLine($"21 {string.Join(" ", doubleList)} {doubleList[0].GetType()}");

		}
	}
}
