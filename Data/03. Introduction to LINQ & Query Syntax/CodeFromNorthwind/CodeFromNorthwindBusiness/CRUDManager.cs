using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

				//var query1 =
				//	from c in db.Customers
				//	where c.City == "London"
				//	orderby c.ContactName
				//	select c;

				//var query1 = db.Customers.Where(c => c.City == "London").OrderBy(c => c.ContactName).ToList();

				//foreach (var item in query1)
				//{
				//	Console.WriteLine(item);
				//}

				//var londBerlinQuery =
				//		from c in db.Customers
				//		where c.City == "London" || c.City == "Berlin"
				//		select new { CustomerID = c.CustomerId, Name = c.ContactName, City = c.City};

				//var ordersProductsByUniInStockQuery =
				//	from p in db.Products
				//	group p by p.SupplierId into newGroup
				//	select new 
				//	{ 
				//		SupplierID = newGroup.Key, 
				//		UnitsOnStock = newGroup.Sum(c => c.UnitsInStock)
				//	};


				//var orderProductsByUnitPrice =
				//	from p in db.Products
				//	orderby p.UnitPrice descending
				//	select new { UnitPrice = Math.Round(p.UnitPrice.GetValueOrDefault(), 2) };


				//foreach (var item in orderProductsByUnitPrice)
				//{
				//	Console.WriteLine(item);
				//}


				var selectBeatle =
					from c in db.Customers
					where c.CustomerId == "LENN"
					select c;

				foreach (var item in selectBeatle)
				{
					db.Customers.Remove(item);
				}

				db.SaveChanges();
			}

		}
	}
}
