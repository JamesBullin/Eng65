# Answers to Exercise 1 of SQL Mini Project

```c#
using System;
using System.Linq;
using System.Web.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EFNorthwindApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new NorthwindContext())
            {
                //Q1.1 Query Syntax
                var londonParisQuery =
                 from customer in db.Customers
                 where customer.City == "London" || customer.City == "Paris"
                 select customer;

                //Q1.1 Method Syntax
                var londonParisQuery2 =
                   db.Customers.Where(c => c.City == "Paris" || c.City == "London");
    
                foreach (var c in londonParisQuery2)
                {
                    Console.WriteLine($"{c.CompanyName} is located in {c.City},{c.Country}");
                }
    
                //Q1.2 Query Syntax
                var bottleQuery =
                from product in db.Products
                where product.QuantityPerUnit.Contains("bottle")
                select product;
    
                foreach (var product in bottleQuery)
                {
                    Console.WriteLine($"Products which are contained in bottles are {product.ProductName}. Quantity Per Unit: {product.QuantityPerUnit}");
                }
    
                Q1.2 Method Syntax
    
                var bottleQuery2 =
                    db.Products.Where(p => p.QuantityPerUnit.Contains("bottle"));
    
                foreach (var p in bottleQuery2)
                {
                    Console.WriteLine($"Products which are contained in bottles are {p.ProductName}. Quantity Per Unit: {p.QuantityPerUnit}");
                }
    
                //Q1.3 Query Syntax
                var bottleQueryJoin =
                from product in db.Products
                join supplier in db.Suppliers on product.SupplierId equals supplier.SupplierId
                where product.QuantityPerUnit.Contains("bottle")
                select new { productName = product.ProductName, supplierName = supplier.CompanyName, quantityPerUnit = product.QuantityPerUnit };
    
                foreach (var result in bottleQueryJoin)
                {
                    Console.WriteLine($"Product:{result.productName}. Company Name: {result.supplierName}. Quantity per Unit: {result.quantityPerUnit}");
                }
    
                //Q1.3 Method Syntax
    
                var bottleQueryJoin2 =
                    db.Products.Where(p => p.QuantityPerUnit.Contains("Bottle")).Include(s => s.Supplier);
    
                foreach (var p in bottleQueryJoin2)
                {
                    Console.WriteLine($"Product:{p.ProductName}. Company Name: {p.CompanyName}. Quantity per Unit: {p.QuantityPerUnit}");
                }
    
                //1.4 Query Syntax //how many products are there in each category
    
                var prodGroupedByCategory =
                     from product in db.Products
                     join category in db.Categories on product.CategoryId equals category.CategoryId
                     group product by category.CategoryName into newGroup
                     select new { Category = newGroup.Key, NumOfProd = newGroup.Count() };


                foreach (var result in prodGroupedByCategory)
                {
                    Console.WriteLine($"{result.Category} - {result.NumOfProd}");
                }


                //1.4 Method Syntax 
    
                var prodGroupedByCategory2 =
                    db.Products.Include(c => c.Category).ToList().GroupBy(C => C.Category.CategoryName);
    
                foreach (var result in prodGroupedByCategory2)
                {
                    Console.WriteLine($"{result.Key} - {result.Count()}");
                }
    
                //1.5 Query Syntax
                /
                var employeesUKQuery =
                from emp in db.Employees
                where emp.Country == "UK"
                select new { firstName = emp.FirstName, lastName = emp.LastName, Country = emp.Country };
    
                foreach (var result in employeesUKQuery)
                {
                    Console.WriteLine($"{result.firstName} {result.lastName} - {result.Country}");
                }
    
                //1.5 Method syntax
                /
                var employeesUKQuery2 =
                    db.Employees.Where(e => e.Country == "UK");


                foreach (var result in employeesUKQuery2)
                {
                    Console.WriteLine($"{result.FirstName} {result.LastName} - {result.Country}");
                }
    
                //1.6 Method Syntax
    
                var manyjoinsQuery =


                //1.7 Query Syntax
                var moreThan100OrdersUKUSQuery =
                    (from order in db.Orders
                     where order.Freight > 100 && (order.ShipCountry == "UK" || order.ShipCountry == "USA")
                     select order).Count();
    
                Console.WriteLine($"{moreThan100OrdersUKUSQuery}");


                //1.7 method Syntax
                var moreThan100OrdersUKUSQuery2 =
                    db.Orders.Where(x => x.Freight > 100).Where(y => y.ShipCountry.Contains("USA") || y.ShipCountry.Contains("UK")).Count();
    
                Console.WriteLine($"No. of Order >100 from US or UK {moreThan100OrdersUKUSQuery2}");
    
                //1.8



                //  Class examples:
    
                var orderQuery =
                from order in db.Orders.Include(o => o.Customer)
                where order.Freight > 750
                select order;


                foreach (var order in orderQuery)
                {
                    Console.WriteLine($"{order.CustomerId} paid {order.Freight} for shipping to {order.ShipCity}");
                }
    
                var orderQueryUsingInnerJoin =
                    from order in db.Orders
                    where order.Freight > 750
                    join customer in db.Customers on order.CustomerId equals customer.CustomerId
                    select new { CustomerContactName = customer.ContactName, City = customer.City, Freight = order.Freight };



                foreach (var result in orderQueryUsingInnerJoin)
                {
                    Console.WriteLine($" {result.CustomerContactName} of {result.City} paid {result.Freight} for shipping");
                }
            }


        }
    }

}
```

