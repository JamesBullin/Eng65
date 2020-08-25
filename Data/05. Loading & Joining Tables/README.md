# Loading & Joining Tables

## Prerequisites

1. Complete "Lambda Expressions & Method Syntax" Lesson

   

## Contents

1. [Review of how we've been writing queries so far](#Review-of-how-we've-been-writing-queries-so-far)

2. [Loading Tables](#Loading-Tables)

3. [Joining Tables](#joining-tables)

4. [Eager Loading vs Lazy Loading](#Lazy-loading-vs-eager-loading)

5. [Join Clause](#Join-clause)

6. [OO vs relational Approach](#oo-vs-relational-approach)

7. [Exercises](#Exercises)

8. [Further Reading](#further-reading)

   

## Review of how we've been writing queries so far

As already covered, we can write code in the `Main` method (in `Program.cs`) to access the database:

```c#
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CodeFromNorthwindApp {
  class Program {

    public static void Main(string[] args)  {

      using (var db = new NorthwindContext()) {
        var orderQuery =         
        from order in db.Orders
        where order.Freight > 750
        select order;

        foreach (var order in orderQuery)
        {
           Console.WriteLine($"{order.CustomerId} paid {order.Freight} for shipping to {order.ShipCity}");
        } 
      } 
    } 
  }
}
```

[Back to contents](#contents)

## Loading Tables

By default, a LINQ query will only load the data asked for. So if you load a an object representing an entry in the `Orders` table, associated objects (such as `Customer`) are not loaded 

The created `Order` object will have the `CustomerID` (foreign key) of the associated `Customer`, but the `Customer` property will be null

To be able to access the associated Customer object, use to LINQ method `Include`

## Joining Tables:

To access data from more than one table you don’t need to write a table join

The Include method indicates you also want to load the `order.Customer` object associated with the selected order:

```c#
using (var db = new NorthwindContext())
{
     
   var orderQuerywithCust =
       from order in db.Orders.Include(o => o.Customer)
       where order.Freight > 750
       select order;
    foreach (var order in orderQuerywithCust)
     {
		if (order.Customer != null)
        		Console.WriteLine($" {order.Customer.ContactName} of {order.Customer.City} paid {order.Freight} for shipping");
      }
}
```

We are joining two tables.

![image](https://raw.githubusercontent.com/nishman89/CSharpData/master/Lessons/Images/JoinsLessonORM.png)

**Why don't we just load all associated data when we load an `Order`?**

Because we would also load:

- A collection of OrderDetail objects (Each of which has an associated Product object which has an associated `Categories` object)
- An `Employee` object
- A `Customer` object

If we are not careful, a simple query could load up the entire database!!

By default, we don’t load any associated objects

We specified Eager (immediate) loading of the associated `Customer` object using the `Include()` method. If we did.

[Back to contents](#contents)

## Eager Loading vs Lazy Loading

While **lazy loading** delays the initialisation of a resource, **eager loading** initializes or **loads** a resource as soon as the code is executed. **Eager loading** also involves pre-**loading** related entities referenced by a resource.

<u>Put simply:</u>

Lazy Loading means the related entities are not loaded, until we iterate through them or bind them the data. 

Eager Loading is the process where a query for one type of entity also loads related entities as a part of the query.

**When to use eager loading**

1. In "one side" of one-to-many relations that you sure are used every where with main entity. like User property of an Article. Category property of a Product.
2. Generally When relations are not too much and eager loading will be good practice to reduce further queries on server.

**When to use lazy loading**

1. Almost on every "collection side" of one-to-many relations. like Articles of User or Products of a Category
2. You exactly know that you will not need a property instantly.

[Back to contents](#contents)

### Lazy Loading

Not enabled by default – need to opt in (see https://www.learnentityframeworkcore.com/lazy-loading )

Only the selected object is loaded as before

But as soon as we attempt to access an associated class, it is loaded, ready for use. In the default mechanism, the associated object property (eg `Customer`) has the value `null`

Trade-off between

- Only loading objects when they are needed vs loading all at once
- Many small database queries vs one large query

### Eager Loading

Eager Loading helps you to load all your needed entities at once. i.e. related objects (child objects) are loaded automatically with its parent object.

Example of eager loading using method syntax:

```c#
var orderQuerywithCustMethod = 
 db.Orders
 Where(o => o.Freight > 750)
 Include(o => o.Customer);
```

If we execute the Query:



```c#
foreach (var order in orderQuerywithCust)
{
    if (order.Customer != null)
        Console.WriteLine($" {order.Customer.ContactName} of {order.Customer.City} paid {order.Freight} for shipping. Employee: {order.Employee}");
}
```
Employee will be `null`

However if we change our query to add another `Include`:

```c#
var orderQuerywithCustMethod = 
 db.Orders
 Where(o => o.Freight > 750)
 Include(o => o.Customer);
```

Add execute the query using the above `foreach` loop, what we will return is the name of the `Employee` object associated with that order.

[Back to contents](#contents)

## Join clause

Sometimes you don't want to load entire collections of related objects into your object model (**t****he OO approach**)

You may just want to load specific attributes of related items – **the relational approach**

You can use a join clause which is similar to SQL joins.

```c#
var orderQueryUsingInnerJoin =
  from order in db.Orders
  where order.Freight > 750
  join customer in db.Customers on order.CustomerId equals customer.CustomerId 
  select new { CustomerContactName = customer.ContactName, City = customer.City, Freight = order.Freight };

foreach (var result in orderQueryUsingInnerJoin)
{
          Console.WriteLine($" {result.CustomerContactName} of {result.City} paid {result.Freight} for shipping");
}
```

Notice each result is of type <Anonymous Type> with properties CustomerContactName, City, and Freight.

Another example of using the `join` clause is shown below which gives the name, address, city, and region of employees that have placed orders to be delivered in Belgium:

```c#
var orderEmployeesBelgiumQuery =
	from e in db.Employees
	join o in db.Orders on e.EmployeeId equals o.EmployeeId
	where o.ShipCountry == "Belgium"
	select new { e.FirstName, e.LastName, e.Address, e.City, e.Region };

foreach (var c in orderEmployeesBelgiumQuery)
{                 
	Console.WriteLine(c);
}
```

[Back to contents](#contents)

## OO vs Relational Approach

```c#
var orderQuerywithCust =
  from order in db.Orders.Include(o => o.Customer)
  where order.Freight > 750
  select order;
```

The above query uses a **OO approach**

The result is a collection of `Order` objects each of which holds a reference to a `Customer` objects

We can use this result in our OO application:

- Perhaps load it when the application starts
- Assign it to an object field or property – `OrderManager` class?
- Save any updates to the database
- Save the final version to the database before exiting the program

```c#
var orderQueryUsingInnerJoin =
  from order in db.Orders
  where order.Freight > 750
  join customer in db.Customers on order.CustomerId equals customer.CustomerId
  select new { CustomerContactName = customer.ContactName, City = customer.City, Freight = order.Freight };

```

The above uses a **relational approach**

We query the database and get the data we want and use it immediately (i.e. display to the user, or send as a result of a API call) - don't keep it in memory. 

In what scenarios might each approach be used?

[Back to contents](#contents)

## Exercises

1. At end of lesson, trainees to write queries in both Method and Query syntax for Section 1 of the SQL Mini Project.
2. Look into `ThenInclude()` method. What does it do? Apply it to the query above!

## Further Reading

1. Eager vs Lazy Loading: https://www.c-sharpcorner.com/article/lazy-loading-and-eager-loading-in-linq-to-sql/
2. Lazy Loading: https://www.learnentityframeworkcore.com/lazy-loading 