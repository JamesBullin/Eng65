# Examples Tests for CRUD operations

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using CodeFromNorthwindModel;
using CodeFromNorthwindBusiness;

namespace NorthwindTests
{
	public class Tests
	{
		[SetUp]

		public void Setup()
		{
			using (var db = new NorthwindContext())
			{
				var selectedCustomer =
				from c in db.Customers
				where c.CustomerId == "MAND"
				select c;


				foreach (var c in selectedCustomer)
				{
					db.Customers.Remove(c);
				}
	
				db.SaveChanges();
	
			}
		}


		[Test]
		public void CustomerAddedTest()
		{
			using (var db = new NorthwindContext())
			{

				var numberOfCustomersBefore = db.Customers.ToList().Count();
				CRUDManager.Program.Create("MAND", "Nish Mandal", "Sparta Global");
				var numberOfCustomersAfter = db.Customers.ToList().Count();

				Assert.AreEqual(numberOfCustomersBefore + 1, numberOfCustomersAfter);


				Setup();
			}
		}

        [Test]
        public void CustomerAddedDetailsCorrectTest()
        {
            using (var db = new NorthwindContext())
            {

                var numberOfCustomersBefore = db.Customers.ToList().Count();
                CRUDManager.Program.Create("MAND", "Nish Mandal", "Sparta Global");
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

			CRUDManager.Program.Update("MAND", "Paris");

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
	public void RemoveTest()
	{
		using (var db = new NorthwindContext())
		{
			
			var newCustomer = new Customers()
			{
				CustomerId = "MAND",
				ContactName = "Nish Mandal",
				CompanyName = "Sparta Global"
			};

			db.Customers.Add(newCustomer);

			db.SaveChanges();

			var numberOfCustomersBefore = db.Customers.ToList().Count();

			CRUDManager.Program.Delete("MAND");

			var numberOfCustomersAfter = db.Customers.ToList().Count();

			Assert.AreEqual(numberOfCustomersBefore - 1, numberOfCustomersAfter);
			
		}
	}
  }
}
```

