# Introduction to LINQ & Query Syntax

## Prerequisites

1. Completed "Introduction to Entity Framework & EF Database First Model"
2. Have `CodeFromNorthwindModel`project in `CodeFromNorthwind` solution

## Contents

1. [Introduction to LINQ](#Introduction-to-LINQ)

2. [Using LINQ](#using-linq)

3. [Query Execution](#Query-execution)	

   ​	a. [Deferred execution](#Deferred-execution)

   ​	b. [Forcing Query Execution](#forcing-query-execution)

4. [LINQ to SQL](#LINQ-to-SQL)
5. [IENumerable and IQueryable](#ienumerable-and-iqueryable)
6. [Query Syntax versus Method Syntax](#Query-Syntax-versus-Method-Syntax)
7. [Query Syntax](#Query-Syntax)

​	a. [Keywords in Query Syntax](#keywords-in-query-syntax)

​			i. [WHERE](#Where)

​			ii. [SELECT](#select)

​			iii. [GROUP BY](#Group-by)

​			iv. [ORDER BY](#order-by)

​	b. [CRUD Operations using Query Syntax](#CRUD-Operations-using-Query-Syntax)

​			i. [READ](#read)

​			ii. [CREATE](#create)

​			iii. [UPDATE](#Update)

​			iv.  [DELETE](#Delete)

8. [Exercise](#Exercise)
9. [Further Reading](#Further-Reading)

## Introduction to LINQ

**L**anguage **IN**tegrated **Q**uery is the name for a set of technologies based on the integration of query capabilities directly into the C# language (i.e. C# way of doing queries).

Same syntax for any data source: SQL database, XML or JSON document, Web services, Collections 

Language integration means it has full debugger support (unlike query strings)

Three steps:

- Specify the data source
- Define the query expression
- Execute the query

[Back to Contents](#contents)

## Using LINQ

We will be using our `CodeFromNorthwind` as the example:

Define the query expression: `var query = db.Customers.Where(c => c.CustomerId == "BONAP");`

Execute the query: `var selectedCustomer = query.FirstOrDefault();`

Can define and execute the query in one line:`selectedCustomer = db.Customers.Where(c => c.CustomerId == "BONAP").FirstOrDefault();`

Linq to SQL: `var selectedCustomer2 = db.Customers.Find("BONAP");`

[Back to Contents](#contents)



## Query Execution

After a LINQ query is created by a user, it is converted to a command tree. A command tree is a representation of a query that is compatible with the Entity Framework. The command tree is then executed against the data source. At query execution time, all query expressions (that is, all components of the query) are evaluated, including those expressions that are used in result materialization.

### Deferred execution

When you create a query, it is not immediately executed:

```c#
IEnumerable<Customers> query1 = 
    from c in db.Customers
	where c.City == "London";
	select c;
```

`query1` is of type `IEnumerable<T>`:

- With one method, `GetEnumerator()`
- Which enables you to iterate over the query results

The query is executed when `GetEnumerator()` is (implicitly) called

Such as in a `foreach` loop:

```c#
foreach (var c in query1) 
{
	Console.WriteLine($"Customer {c.GetFullName()} lives in {c.City}"); 
}
```

The query is unchanged – we can use it again even if the data in the data source has been updated in the meantime

Lazy loading and joining tables!

[Back to Contents](#contents)

### Forcing query execution

You also force the query to be immediately executed by:

- Calling `ToList()`or `ToArray()` on the query object (returns a list or array of the query results)

- Calling an aggregation function:

  - ```c#
    int numCustomersInLondon = query1.Count();
    ```

  - Or `Max`, `Average`, `First`, `FirstOrDefault`, `Last`, `LastOrDefault`

    - The `..OrDefault` functions return a default value if the value searched for is not found.
      - 0 for a numerical type
      - null for reference and nullable types



Deferred execution is important as it gives you the flexibility of constructing a query in several steps by separating query construction from query execution.

This allows you to execute a query as frequently as you want to, like fetching the latest information from a database that is being updated frequently by other applications. You will always get the latest information from the database in this case.

## IEnumerable and IQueryable

When we've been declaring and initialising our queries, we've been using `var` instead of explicitly stating the data type. You can see that the type of the query variable is the  `IEnumerable<T>` or`IQueryable<T>` (if we use the `group` keyword).

### `IEnumerable<T>`

 `IEnumerable<T>` exposes an enumerator, which supports a simple iteration over a non-generic collection.

```c#
IEnumerable<Customers> query1 =
	from c in db.Customers
	where c.City == "London"
	select c;
```

To understand the method-based query, let's examine it more closely. On the right side of the expression, notice that the `where` clause is now expressed as an instance method on the `Customers` object, which as you will recall has a type of `IEnumerable<Customers>`. If you are familiar with the generic `IEnumerable` interface, you know that it does not have a `Where` method. However, if you invoke the IntelliSense completion list in the Visual Studio IDE, you will see not only a `Where` method, but many other methods such as `Select`, `SelectMany`, `Join`, and `Orderby`. These are all the standard query operators.

### `IQueryable<T>`

`IQueryable` groups the elements of a sequence according to a specified key selector function and creates a result value from each group and its key. Keys are compared by using a specified comparer and the elements of each group are projected by using a specified function.

The `IQueryable` interface enables queries to be polymorphic. That is, because a query against an `IQueryable` data source is represented as an expression tree, it can be executed against different types of data sources.

[Back to Contents](#back-to-contents)

## LINQ to SQL

Most of LINQ, such as selection, is generic

- Can be used with any data source

Some is specific to the source type

- Such as LINQ to SQL

Can use LINQ to SQL to insert, update, and delete

- First insert, update or delete the object in the object model (Might need to select it first)

- Then call `SubmitChanges() `to update the database

  

[Back to Contents](#contents)

## Introduction to Query Syntax and Method Syntax

LINQ queries can be written in either query syntax or method syntax. Below is an example of using query syntax to query our array,

```c#
int[] myArray = {1,2,3};
// query
var output = 
	from number in myArray
	select number;

foreach (int num in output){
	Console.WriteLine(num);
}
```

If we were to use **query syntax** to query our Northwind entity set (see previous lesson), we can do the following (note the use of the `using` statement):

```c#
using (var db = new NorthwindContext())
{
	IEnumerable<Customers> query1 =
			from c in db.Customers
			where c.City == "London"
			orderby c.ContactName
			select c;

    foreach (var c in query1)
        {
            Console.WriteLine(c);
        }
}
```

Notice how it looks like SQL, but backwards!

Another example:

```c#
using (var db = new NorthwindContext())
			{
				var orderQuery =
				from order in db.Orders
				where order.Freight > 750
				select order;

			foreach (var order in orderQuery)
			{
				Console.WriteLine($"{order.CustomerId} paid {order.Freight} for shipping to {order.ShipCity}");
			}

		}
```

Alternatively, we can use **method syntax** to query our Northwind entity set:

```c#
using (var db = new NorthwindContext())
{
	IEnumerable<Customers> query2 = db.Customers.Where(c => c.City == "London").OrderBy(c => c.ContactName);

foreach (var c in query2)
    {
        Console.WriteLine(c);
    }
}
```

The method syntax above uses the methods `Where()` and `OrderBy()` and lambda expressions `c => c.City == "London"`.

[Back to Contents](#contents)

## Query Syntax versus Method Syntax

Both query and method syntax generate the same query of type `IEnumerable<T>`

Query syntax can be easier to read - it is translated into the corresponding <u>method syntax</u> on compilation

Some functionality can only be done using method syntax:

- (`Sum`, `Max`, `Min`).

  

## Query Syntax

Query syntax is similar to SQL (Structured Query Language) for the database. It is defined within the C#. Below is a breakdown of Query Syntax.

![MethodSyntaxBreakdown](https://www.tutorialsteacher.com/Content/images/linq/linq-query-syntax.png)





The LINQ query syntax starts with `from` keyword and ends with select keyword.



Query syntax starts with a ***From\*** clause followed by a ***Range\*** variable. The ***From\*** clause is structured like:

 `from "rangeVariableName" in "IEnumerablecollection"`

 In English, this means, from each object in the collection. It is similar to a `foreach` loop: 

`foreach(Student s in studentList)`.

After the From clause, you can use different Standard Query Operators to filter, group, join elements of the collection. There are around 50 Standard Query Operators available in LINQ. In the above figure, we have used "where" operator (aka clause) followed by a condition. 

LINQ query syntax always ends with a `Select` or `Group` clause. The Select clause is used to shape the data. You can select the whole object as it is or only some properties of it. In the above example, we selected the each resulted string elements.



[Back to Contents](#contents)



### Keywords in Query Syntax

Remember that the above only represent an intent of what we want, we are not actually executing the query. We will go through a few keywords in `Linq` query syntax

#### WHERE

As with SQL we can filter our results using the `where` keyword:

```c#
using (var db = new NorthwindContext())
{		
        var londonBerlinQuery1 =
             from customer in db.Customers
             where customer.City == "London" || customer.City == "Berlin"
             select customer;

}
```
#### SELECT

The Select operator always returns an `IEnumerable` collection which contains elements based on a transformation function. It is similar to the Select clause of SQL that produces a flat result set. If we were to write:

```c#
 foreach (var customer in londonBerlinQuery)
{ 
	Console.WriteLine(customer); 
}
```

For the query above, we would call the `Customers` object's `ToString()` method.

The following example of the a select clause returns a collection of anonymous objects containing the `CompanyName` and `Country` property.

```c#
using (var db = new NorthwindContext())
{		
        var londonBerlinQuery2 =
             from customer in db.Customers
             where customer.City == "London" || customer.City == "Berlin"
             select new { Customer = customer.CompanyName, C = customer.Country };
    		//select new (){ Customer = customer.CompanyName, C = customer.Country };
    
}
```

The Select operator is optional in method syntax. However, you can use it to shape the data.

#### GROUP BY

```c#
using (var db = new NorthwindContext())
            {
                var orderProductsByUnitInStockQuery =
                 from p in db.Products
                 group p by p.SupplierId into newGroup
                 select new
                 {
                     SupplierID = newGroup.Key,
                     UnitsOnStock = newGroup.Sum(c => c.UnitsInStock)
                 };

                foreach (var result in orderProductsByUnitInStockQuery1)
                {
                    Console.WriteLine($"{result}");
                }
            }
```

In SQL syntax, we would write this:

```sql
SELECT SupplierID, SUM(UnitsInStock)
FROM products
GROUP BY SupplierID;
```

What is happening here?:

```c#
using (var db = new NorthwindContext())
{
        var x = 
            from p in db.Products
            group p by p.CategoryId into categProds
            select new
            {
                categProds.Key,
                AvgPrice = categProds.Average(C => C.UnitPrice)
            };

    foreach (var result in x)
    {
        Console.WriteLine($"{result.Key} - {result.AvgPrice}");
    }
}
```

Write it out as a SQL query!!



#### ORDER BY

```c#
 using (var db = new NorthwindContext())

{
        var orderProductsByUnitPrice =
            from p in db.Products
            //if we don't put descending, like SQL, default will be ascending
            orderby p.UnitPrice descending
            select p;

        foreach (var item in orderProductsByUnitPrice)
        {
        	Console.WriteLine($"{item.ProductId} - {item.UnitPrice}");
        }
}
```

[Back to Contents](#contents)

### CRUD operations using LINQ Query Syntax

Still using the same solution where we create the `CodeFromNorthwindModel` project

Firstly, create a new project, `Console App (.Net Core)`, called `CodeFromNorthwindBusiness`. Right click the project and ensure it references the `CodeFromNorthwindModel`. Rename the `Program.cs` file to `CRUDManager.cs`. The class in this file should be called `CRUDManager`. The file should look like below (Note the `using` statements):

```c#
using System.Collections.Generic;
using System.Linq;
using CodeFromNorthwindModel;

namespace CodeFromNorthwindBusiness
{
    public class CRUDManager
    {
		static void Main(string[] args)
		{
            Console.WriteLine("Hello World");
        }
 	}
}
```

[Back to Contents](#contents)

#### Read

We can read (select and output all customers)

```c#
static void Main(string[] args)
{
	using (var db = new NorthwindContext())
	{
		foreach (var c in db.Customers)
		{
			Console.WriteLine($"Customer {c.ContactName} has ID {c.CustomerId} and lives in {c.City}");
		}
	}
}
```

#### Create

We can add (create) a new customer:

```c#
static void Main(string[] args)
		{

			using (var db = new NorthwindContext())
			{
				var newCustomer = new Customers()
				{
					CustomerId = "MAND",
					ContactName = "Nish Mandal",
					CompanyName = "ToysRUs"
				};

				db.Customers.Add(newCustomer);

				db.SaveChanges();
			}
		}
```

Query the database:

```sql
SELECT * FROM customers WHERE CustomerID = 'MAND';
```

And now Nish Mandal is in the list!

If we were to add the same customer using SQL, we would write:

```c#
INSERT INTO Customers (CustomerID, ContactName, CompanyName)
VALUES ('MAND', 'Nish Mandal', 'ToysRUs');
```

#### Update

Below, we are using a query syntax to update the customer, Nish Mandal (we will cover lambda expressions in the next lesson)

```c#
static void Main(string[] args)
		{

		using (var db = new NorthwindContext())
		{
			// obtain your selected customer
			var selectedCustomer =
                    from c in db.Customers
                    where c.CustomerId == "MAND"
                    select c;
			// now update
			foreach (var item in selectedCustomer)
            {
                    item.City = "Paris";
            }
			// save back to database
			db.SaveChanges();

		}
	}
```

Query the database:

```sql
SELECT * FROM customers WHERE CustomerID = 'MAND';
```

And now Nish Mandal's City is Paris!



We can also do it as shown below:

```c#
static void Main(string[] args)
    {
        using (var db = new NorthwindContext())
        {
            // obtain your selected customer. Note firstOrDefault. selectedCustomer
            //is now a Customers object which we can change the properties of
            var selectedCustomer =
                (from c in db.Customers
                 where c.CustomerId == "MAND"
                 select c).FirstOrDefault();
            // now update
            foreach (var item in selectedCustomer)
            {
                item.City = "Paris";
            }
            // save back to database
            db.SaveChanges();
        }
    }
```

To do the same in SQL, we would write:

```sql
UPDATE Customers
SET City = 'Paris'
WHERE CustomerID = 'MAND'
```



#### Delete

Below, we are using a query syntax to delete the customer, Nish Mandal (we will cover lambda expressions in the next lesson)

```c#
static void Main(string[] args)
{
    using (var db = new NorthwindContext())
    {				
        //query the database for the rows to be deleted
        var selectedCustomer =
            from c in db.Customers
            where c.CustomerId == "MAND"
            select c;
        //delete those who appear in selected CustomerQuery for database
        foreach (var c in selectedCustomer)
        {
            db.Customers.Remove(c);
        }				

        db.SaveChanges();
    }		
}
```

To do this in SQL, we would write:

```c#
DELETE FROM Customers WHERE CustomerID = 'MAND';
```



[Back to Contents](#contents)

## Exercise

Follow walkthrough: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/walkthrough-writing-queries-linq

AND EXPLORE ASSOCIATED DOCUMENTATION!

## Further Reading:

1. Examples querying Northwind using Query Syntax: https://cs.ulb.ac.be/public/_media/teaching/infoh415/sdi_object_linq_sql.pdf

2. https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/ and references therein

3. https://docs.microsoft.com/en-us/ef

4. https://docs.microsoft.com/en-us/ef/core/managing-schemas/scaffolding?tabs=vs 

5. https://docs.microsoft.com/en-us/ef/core/querying/related-data

   
