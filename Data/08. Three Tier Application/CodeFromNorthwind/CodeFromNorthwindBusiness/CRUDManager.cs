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

		public void SetSelectedCustomer(object selectedItem)
		{
			SelectedCustomer = (Customers)selectedItem;
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





