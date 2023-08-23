using System;
using System.Collections.Generic;
using System.Collections;

namespace Grammar.Collections.GenericCustomCollection
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
	}

	public class CustomersList : IEnumerable<Customer>
	{
		private List<Customer> customers = new List<Customer>();

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
	}

	public static class GenericCustomCollection
	{
		public static void Test()
		{
			Console.WriteLine("\nCustomCollection");
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

		}
	}
}

