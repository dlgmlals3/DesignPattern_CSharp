using System;
using System.Collections;
using System.Collections.Generic;


namespace Grammar.Collections.ICollectionE
{
	public enum TypeOfCustomer
	{
		RegularCustomer,
		VIPCustomer
	}

	public class Customer
	{
		public string CustomerID { get; set; }
		public string CustomerName { get; set; }
		public string Email { get; set; }
		public TypeOfCustomer CustomerType { get; set; }

		public override string ToString()
		{
			return $"{{{nameof(CustomerID)}={CustomerID}, {nameof(CustomerName)}={CustomerName}, {nameof(Email)}={Email}, {nameof(CustomerType)}={CustomerType.ToString()}}}";
		}
	}

	public class CustomersList : ICollection<Customer>
	{
		private List<Customer> customers = new List<Customer>();

		public int Count => customers.Count;

		public bool IsReadOnly => false;

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
	}

	public static class ICollectionE
	{
		public static void Test()
		{
			Console.WriteLine("\n ICollectionE");
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
			Customer new_cust = new Customer()
			{
				CustomerID = "A104",
				CustomerName = "khyngsook",
				Email = "khyngsook@naver.com",
				CustomerType = TypeOfCustomer.RegularCustomer
			};
			customersList.Add(new_cust);

			IEnumerator enumerator = customersList.GetEnumerator();

			foreach (Customer customer in customersList)
			{
				Console.WriteLine(customer.CustomerID + "," + customer.CustomerName + "," +
					customer.Email + " " + customer.CustomerType);
			}

			Console.WriteLine(string.Join("\n", customersList));
			Console.WriteLine(customersList.Count + " customer find");
			var node = customersList.Find(value => value.CustomerID == "A101");
			Console.WriteLine(node);
			Console.WriteLine("remove : " + customersList.Remove(node));
			Console.WriteLine(string.Join("\n", customersList));

			// FindAll
			var customers = customersList.FindAll(cust => cust.CustomerType == TypeOfCustomer.VIPCustomer);
			Console.WriteLine("VIP");
			Console.WriteLine(string.Join("\n", customers));

			customersList.Clear();
			Console.WriteLine(string.Join("\n", customersList));
		}
	}
}
