using System;
using System.Collections;
using System.Collections.Generic;

namespace Grammar.Collections.IEquatableExample
{
	public enum TypeOfCustomer
	{
		RegularCustomer,
		VIPCustomer
	}

	public class Customer : IEquatable<Customer>
	{
		public string CustomerID { get; set; }
		public string CustomerName { get; set; }
		public string Email { get; set; }
		public TypeOfCustomer CustomerType { get; set; }

		public bool Equals(Customer other)
		{
			return this.CustomerID == other.CustomerID && this.CustomerName == other.CustomerName
				&& this.Email == other.Email && this.CustomerType == CustomerType;
		}

		public override string ToString()
		{
			return $"{{{nameof(CustomerID)}={CustomerID}, {nameof(CustomerName)}={CustomerName}, {nameof(Email)}={Email}, {nameof(CustomerType)}={CustomerType.ToString()}}}";
		}
	}

	public class CustomersList : IList<Customer>
	{
		private List<Customer> customers = new List<Customer>();

		public int Count => customers.Count;

		public bool IsReadOnly => false;

		/// <summary>
		/// customerLists[0] <-- called
		/// set, get accessor of Indexor
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public Customer this[int index]
		{
			get => customers[index];
			set => customers[index] = value;
		}

		// implementing IEnumerable.GetEnumerator()
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Implemeting IEnumerable<T>.GetEnumerator()
		public IEnumerator<Customer> GetEnumerator()
		{
			for (int i = 0; i < customers.Count; i++)
			{
				yield return customers[i];
			}
		}

		/// <summary>
		/// CustomersList() 내부에서 객체 생성할때도 호출이됨.. override 인가보네
		/// </summary>
		/// <param name="cust"></param>
		public void Add(Customer cust)
		{
			Console.WriteLine("Add");
			if (cust.CustomerID.StartsWith("A") || cust.CustomerID.StartsWith("a"))
			{
				customers.Add(cust);
			}
			else
			{
				Console.WriteLine("Invalid Customer ID");
			}
		}

		public void Clear()
		{
			customers.Clear();
		}

		/// <summary>
		/// Contains는 내부적으로 Equals 호출
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public bool Contains(Customer item)
		{
			return customers.Contains(item);
		}

		public void CopyTo(Customer[] array, int arrayIndex)
		{
			customers.CopyTo(array, arrayIndex);
		}

		public bool Remove(Customer item)
		{
			return customers.Remove(item);
		}

		public Customer Find(Predicate<Customer> match)
		{
			return customers.Find(match);
		}

		public List<Customer> FindAll(Predicate<Customer> match)
		{
			return customers.FindAll(match);
		}

		public int IndexOf(Customer item)
		{
			return customers.IndexOf(item);
		}

		public void Insert(int index, Customer item)
		{
			if (index < 0)
			{
				Console.WriteLine("Invalid index");
			}
			else
			{
				customers.Insert(index, item);
			}
		}

		public void RemoveAt(int index)
		{
			if (index < 0)
			{
				Console.WriteLine("Invalid Index");
			}
			else
			{
				customers.RemoveAt(index);
			}
		}
	}

	public static class IEquatableExample
	{
		public static void Test()
		{
			CustomersList customersList = new CustomersList()
			{
				new Customer() {
					CustomerID ="A101", CustomerName = "heemin", Email = "dlgmlals3@naver.com", CustomerType = TypeOfCustomer.RegularCustomer
				},
				new Customer() {
					CustomerID ="A102", CustomerName = "heesun", Email = "heesun@naver.com", CustomerType = TypeOfCustomer.RegularCustomer
				},
				new Customer() {
					CustomerID ="A103", CustomerName = "jihayng", Email = "jihayng@naver.com", CustomerType = TypeOfCustomer.VIPCustomer
				},
			};
			var jihyang = new Customer()
			{
				CustomerID = "A103",
				CustomerName = "jihayng",
				Email = "jihayng@naver.com",
				CustomerType = TypeOfCustomer.VIPCustomer
			};
			//customersList.Add(jihyang);

			Console.WriteLine("Contains : " + customersList.Contains(jihyang));
		}
	}
}
