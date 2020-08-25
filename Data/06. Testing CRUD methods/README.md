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

namespace CRUDManager
{
	public class Program
	{
		static void Main(string[] args)
		{
			Delete("MAND");
			Create("MAND", "Nish Mandal", "ToysRUs");
			Update("MAND", "Paris");
			Delete("MAND");
		}

		public static void Create(string customerid, string contactname, string companyname)
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

	
		public static void Update(string customerid, string city)
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

		public static void  Delete(string customerid)
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

public class Tests
{
    [SetUp]

    public void Setup()
    {
        using (var db = new NorthwindContext())
		{
			Assert.Pass();
        }
    }

	[Test]
	public void CustomerAddedToDatabaseTest()
	{
        using (var db = new NorthwindContext())
		{
			Assert.Pass();
        }
	}
    
    	public void CustomerAddedTODatabaseCorrectDetails()
	{
        using (var db = new NorthwindContext())
		{
			Assert.Pass();
        }
	}
    
	[Test]
	public void UpdateTest()
	{
		using (var db = new NorthwindContext())
		{
			Assert.Pass();
        }
	}
	[Test]
	public void DeleteTest()
	{
		using (var db = new NorthwindContext())
		{
			Assert.Pass();
        }
	}
}
```


