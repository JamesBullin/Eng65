# Testing CRUD operations

## Prerequisites

1. Complete "Loading & Joining Tables" Lesson
2. Create a new Testing Project called `CodeFromNorthwindTests` with `.cs` files called `CRUDManagerTests`. Test needs to reference `CodeFromNowrthindModel` and `CodeFromNorthwindBusiness` . Add the following to the following packages to the test project:
   - `Microsoft.EntityFrameworkCore`
   - `Microsoft.EntityFrameworkCore.SqlServer`
   - `Microsoft.EntityFrameworkCore.Tools`

## Contents

1. [Exercise](#exercise)
2. [Example Tests](#Example-tests)



## Exercise

Trainees to create CRUD methods and test methods:

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CodeFromNorthwindModel;
using Microsoft.EntityFrameworkCore;

namespace CodeFromNorthwindBusiness
{
	public class CRUDManager
	{
		public Customers SelectedCustomer { get; set; }


		public List<Customers> RetrieveAll()
		{
			using (var db = new NorthwindContext())
			{
				return db.Customers.ToList();
			}
		}


		static void Main(string[] args)
		{
			using (var db = new NorthwindContext())
			{
				//Delete("MAND");
				//Create("MAND", "Nish Mandal", "ToysRUs");
				//Update("MAND", "Paris");
				//Delete("MAND");


			}
		}
			public void Create(string customerid, string contactname, string companyname)
			{

				using (var db = new NorthwindContext())
				{
					var newCustomer = new Customers()
					{
						CustomerId = customerid.Trim(),
						ContactName = contactname.Trim(),
						CompanyName = companyname.Trim()
					};

					db.Customers.Add(newCustomer);

					db.SaveChanges();
				}


			}

		public void Update(string customerId, string contactName, string city, string postcode, string country)
		{
			using (var db = new NorthwindContext())
			{
				SelectedCustomer = db.Customers.Where(c => c.CustomerId == customerId).FirstOrDefault();
				SelectedCustomer.ContactName = contactName;
				SelectedCustomer.City = city;
				SelectedCustomer.PostalCode = postcode;
				SelectedCustomer.Country = country;
				// write changes to database
				db.SaveChanges();
			}
		}


		public void Update(string customerid, string city)
			{
				using (var db = new NorthwindContext())
				{
					// obtain your selected customer
					var selectedCustomer =
							from c in db.Customers
							where c.CustomerId == customerid
							select c;
					// now update
					foreach (var item in selectedCustomer)
					{
						item.City = city;
					}
					// save back to database
					db.SaveChanges();

				}

			}

			public void Delete(string customerid)
			{

				using (var db = new NorthwindContext())
				{
					var selectedCustomer =
				from c in db.Customers
				where c.CustomerId == customerid
				select c;
					foreach (var c in selectedCustomer)
					{
						db.Customers.Remove(c);
					}

					db.SaveChanges();
				}
			}
		}
	}

```

Layout of tests:

```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using CodeFromNorthwindModel;
using CodeFromNorthwindBusiness;
using NUnit.Framework;

namespace NorthwindTests
{
	public class Tests
	{
		CRUDManager _crudManager = new CRUDManager();

		[SetUp]

		public void Setup()
		{
			using (var db = new NorthwindContext())
			{
var numberOfCustomersBefore = db.Customers.ToList().Count();
				_crudManager.Create("MAND", "Nish Mandal", "Sparta Global");
				var numberOfCustomersAfter = db.Customers.ToList().Count();

				Assert.AreEqual(numberOfCustomersBefore + 1, numberOfCustomersAfter);

				var createdCustomer =
					from c in db.Customers
					where c.CustomerId == "MAND"
					select c;

				foreach (var c in createdCustomer)
				{
					Assert.AreEqual("MAND ", c.CustomerId);
					Assert.AreEqual("Nish Mandal", c.ContactName);
					Assert.AreEqual("Sparta Global", c.CompanyName);

				}

				Setup();

			}
		}


		[Test]
		public void CustomerAddedTest()
		{
			using (var db = new NorthwindContext())
			{

				Assert.AreEqual("","1");

			}
		}

		[Test]
		public void CustomerAddedDetailsCorrectTest()
		{
			using (var db = new NorthwindContext())
			{

				Assert.AreEqual("","1");

			}
		}


		[Test]
		public void UpdateTest()
		{
			using (var db = new NorthwindContext())
			{

				var newCustomer = new Customers()
				{
					CustomerId = "MAND",
					ContactName = "Nish Mandal",
					CompanyName = "Sparta Global",
				};

				db.Customers.Add(newCustomer);

				db.SaveChanges();

				_crudManager.Update("MAND", "Paris");

				var updatedCustomer =
							from c in db.Customers
							where c.CustomerId == "MAND"
							select c;

				foreach (var c in updatedCustomer)
				{
					Assert.AreEqual("Paris", c.City);
				}				
				Setup();

			}
		}

		[Test]
		public void UpdateSeveralDetailsTest()
		{
			using (var db = new NorthwindContext())
			{
				Assert.AreEqual("","1"); //test the update method which takes 5 parameters

			}
		}

		[Test]
		public void RemoveTest()
		{
			using (var db = new NorthwindContext())
			{

				Assert.AreEqual("","1");


			}
		}
	}
}
```


