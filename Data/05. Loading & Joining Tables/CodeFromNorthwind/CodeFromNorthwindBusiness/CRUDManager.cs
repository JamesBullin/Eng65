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
		static void Main(string[] args)
		{
			using (var db = new NorthwindContext())
			{
				var OrderQuerywithCustom =
					from o in db.Orders.Include(o => o.Customer).Include(o => o.Employee)
					where o.Freight > 750
					select o;

				//foreach (var o in OrderQuerywithCustom)
				//{
				//	Console.WriteLine($" {o.Customer.ContactName} of {o.Customer.City} paid {o.Freight} for shipping. Employee: {o.Employee}");
				//}

				var orderQueryUsingInnerJoin =
						(from order in db.Orders
						join customer in db.Customers on order.CustomerId equals customer.CustomerId
						where order.Freight > 750
						select new { CustomerContactName = customer.ContactName, City = customer.City, Freight = order.Freight }).ToList();

				foreach (var result in orderQueryUsingInnerJoin)
				{
					Console.WriteLine($" {result.CustomerContactName} of {result.City} paid {result.Freight} for shipping");
				}



				//			IQueryable<Customers> custQuery1 =
				//from c in db.Customers
				//where c.City == "Berlin"
				//select c;

				//var custQuery2 = db.Customers.Where(c => c.City == "Berlin");

				//var customerOrderedQuery1 =
				//	from p in db.Products
				//	orderby p.ReorderLevel
				//	orderby p.QuantityPerUnit descending
				//	select new { p.QuantityPerUnit, p.ReorderLevel, p.ProductName };

				//foreach (var item in customerOrderedQuery1)
				//{
				//	Console.WriteLine($"{item.ProductName} || {item.QuantityPerUnit} ||{item.ReorderLevel}");
				//}

				//var selectedCustomer = db.Customers.Where(c => c.CustomerId == "phil1");


				//foreach (var item in selectedCustomer)
				//{
				//	db.Customers.Remove(item);
				//}

				//var selectedCustomer2 = db.Customers.Where(c => c.CustomerId == "phil1");

				//db.Remove(db.Customers.Where(c => c.CustomerId == "phil1").FirstOrDefault());

				//var selectedCustomer3 = db.Customers.Where(c => c.CustomerId == "phil1").FirstOrDefault();
				//db.Remove(selectedCustomer3);

				//var selectedCustomer4 = db.Customers.Find("phil1");

				//db.SaveChanges();
				//foreach (var c in readCustomer)
				//{
				//	Console.WriteLine(c);
				//}

				//db.Customers.Find("phil1").CompanyName = "Sparta Global";

				//	var updateQ = db.Customers.Where(c => c.CustomerId == "Phil1").FirstOrDefault();
				//updateQ.CompanyName = "Sparta Global";



			}
			//List<Person> eng65 = new List<Person>
			//{
			//	new Person { Name = "Fazal", Age = 20 },
			//	new Person { Name = "Huthaifa", Age = 55 },
			//	new Person { Name = "Vinay", Age = 40 }

			//};


			//var peopleCount = eng65.Count();
			//var youngPeopleCount = eng65.Count(n => n.Age < 30);
			//var ageSum = eng65.Sum(n => n.Age);
			//var oldPeeps = eng65.Sum(n => n.Age >= 30 ? n.Age : 0);
			//var oldPeeps2 = eng65.Where(n => n.Age > 30).Sum(n => n.Age);

			//List<int> nums = new List<int> { 3, 7, 1, 2, 8, 3, 0, 4, 5 };

			//var evenDCount = nums.Count(delegate (int n) { return n % 2 == 0;  } );

			//var evenLCount = nums.Count(n => n % 2 == 0);



		}
	}

	//public class Person
	//{
	//	public string Name { get; set; }
	//	public int Age { get; set; }
	//}
}



