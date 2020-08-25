using System;
using System.Collections.Generic;
using System.Linq;


namespace CodeFromNorthwindModel
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var db = new NorthwindContext())
			{


				var removeCustomer = db.Customers.Where(c => c.City == "Birmingham").FirstOrDefault();


				db.Customers.Remove(removeCustomer);

				db.SaveChanges();
			}
		}
	}
}
