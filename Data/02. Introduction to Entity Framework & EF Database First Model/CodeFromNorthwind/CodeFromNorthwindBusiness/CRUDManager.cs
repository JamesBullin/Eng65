using System;
using System.Collections.Generic;
using System.Linq;
using CodeFromNorthwindModel;

namespace CodeFromNorthwindBusiness
{
    public class CRUDManager
    {
		static void Main(string[] args)
		{
			using (var db = new NorthwindContext())
			{



				//var newCustomer = new Customers()
				//{
				//	CustomerId = "MAND",

				//	ContactName = "Nish Mandal",
				//	CompanyName = "ToysRUs",
				//};

				//db.Customers.Add(newCustomer);

				var removeCustomer = db.Customers.Where(c => c.City == "Birmingham").FirstOrDefault();


				db.Customers.Remove(removeCustomer);

				db.SaveChanges();
			}

		}
	}
}
