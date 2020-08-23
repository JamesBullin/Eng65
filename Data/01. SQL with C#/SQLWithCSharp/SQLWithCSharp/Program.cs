using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SQLWithCSharp
{
	class Program
	{
		static void Main(string[] args)
		{
			{
				var Customers = new List<Customer>();
				using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;"))
				{
					//Testing our connection is open
					connection.Open();
					Console.WriteLine(connection.State);

					var newCustomer = new Customer()
					{
						CustomerID = "MAND",
						ContactName = "Nish Mandal",
						City = "Birmingham",
						CompanyName = "ToysRUs"
					};

					//string sqlString = $"INSERT INTO CUSTOMERS(CustomerID, ContactName, CompanyName, City) VALUES   ('{newCustomer.CustomerID}', '{newCustomer.ContactName}', '{newCustomer.CompanyName}', '{newCustomer.City}')";
					//// execute insert SQL command
					//using (var command2 = new SqlCommand(sqlString, connection))
					//{
					//	int affected = command2.ExecuteNonQuery();
					//}

					using (var updateCustomerCommand = new SqlCommand("UpdateCustomer", connection))
					{
						// Using System.Data;
						updateCustomerCommand.CommandType = CommandType.StoredProcedure;
						// add parameters
						updateCustomerCommand.Parameters.AddWithValue("ID", newCustomer.CustomerID);
						updateCustomerCommand.Parameters.AddWithValue("NewName", "Nish Mandal Updated Name");
						// run the update
						int affected = updateCustomerCommand.ExecuteNonQuery();
					}


					//using (var command = new SqlCommand("select * from customers", connection))
					//{



					//	//SQL reader Provides a way of reading a forward-only stream of rows from a SQL Server database. 
					//	SqlDataReader sqlReader = command.ExecuteReader();
					//	//List where we will add customer objects to
					//	List<Customer> customers = new List<Customer>();

					//	while (sqlReader.Read())
					//	{
					//		//creating variables for customer
					//		var customerID = sqlReader["CustomerID"].ToString();
					//		var contactName = sqlReader["ContactName"].ToString();
					//		var companyName = sqlReader["CompanyName"].ToString();
					//		var city = sqlReader["City"].ToString();
					//		var contactTitle = sqlReader["ContactTitle"].ToString();

					//		//new customer object
					//		var customer = new Customer() { ContactTitle = contactTitle, CustomerID = customerID, ContactName = contactName, City = city, CompanyName = companyName };

					//		customers.Add(customer);
					//	}

					//	foreach (var c in customers)
					//	{
					//		Console.WriteLine($"Customer {c.GetFullName()} has ID {c.CustomerID} and lives in {c.City}");
					//	}


					//	sqlReader.Close();
				}
				
				}
			}
		}

		public class Customer
		{
			public string CustomerID { get; set; }
			public string CompanyName { get; set; }
			public string ContactName { get; set; }
			public string ContactTitle { get; set; }
			public string City { get; set; }

			public string GetFullName()
			{
				return $"{ContactTitle} - {ContactName} - {CompanyName} - {City}";
			}
		}
	}
