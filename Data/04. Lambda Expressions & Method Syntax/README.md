# Lambda

## Prerequisites

1. Complete "Introduction to LINQ and Query Syntax" Lesson
2. Install LINQPad: https://www.linqpad.net/ (helpful for converting Query Syntax into Method Syntax)

## Exercises

1. At end of lesson, trainees to write queries in both Method and Query syntax for Section 1 of the SQL Mini Project.

## Contents

1. [Method Syntax](#Method-Syntax)

   ​	a. [Lambda Expressions](#Lambda-Expressions)

   ​	b. [Breakdown of Lambda](#Breakdown-of-Lambda)

   ​	c. [Using Lambda Expressions](#Using-Lambda-Expressions)

   ​	d. [Keywords in method syntax ](#keywords-in-method-syntax)

   ​				i. [WHERE](#Where)

   ​				ii. [GROUP BY](#Group-by)

   ​				iii. [ORDER BY](#order-by)

   ​	e. [CRUD Operations using Method Syntax](#CRUD-Operations-using-Method)

   ​			i. [CREATE](#create) 

   ​			ii. [UPDATE](#Update)

   ​			ii. [READ](#read)

   ​			iv. [DELETE](#delete)

2. [The `=>' operator'](# the-=>-operator)

3. [Further Reading](#further-reading)

## Method Syntax

We will now go through Method Syntax. Method syntax uses Lambda expressions. C# 2.0 introduced anonymous methods and in C# 3.0 and later, lambda expressions supersede anonymous methods as the preferred way to write inline code. Firstly, we explain what Lambda expression are.

### Lambda Expressions

A Lambda expression is an anonymous function. The syntax is as below:

**`Give this => return this => goes to`** 

Simply put, let's consider this example:

`x => x * x`

This example is saying, "given `x`, return `x * x`"

If were to write out the method for this, it would be:

```c#
static`int bMethod(int x) { return x*x;}`
```

Then call it!

`=>` is the "goes to" operator.

Another example, using the `Northwind` `dbset`:

```c#
using (var db = new NorthwindContext())
			{
				var query =
                    //select column name 'ContactName' from customers table
					db.Customers.Select(c => c.ContactName);

    			//executre query
				foreach (var c in query)
				{
					Console.WriteLine(c);
				}	
             }
```

 If we were to use a method, we would have to write:

```c#
using (var db = new NorthwindContext())
{
			static string aMethod(Customers c) { return c.ContactName; }

			foreach (var c in db.Customers)
			{
                //call aMethod for each customer in Customers
				Console.WriteLine(aMethod(c));
			}
}
```

The above query is stating "given a `Customer` `c`, return `c.ContactName`.`c` goes to `c.ContactName`

**Key points about Lambda Expressions:**

- Have no name
- Is declared at the place it is used
- Can’t be reused anywhere else
- The types of the parameter(s) and the return values are inferred from the context

[Back to Contents](#contents)

### Breakdown of Lambda Expressions

Let's consider the array:

`var nums = new List<int>{3,7,1,2,8,3,0,4,5};`

LINQ includes a method for counting the members of an` IEnumerable` such a `List` which returns the count of all items in `nums`:

```c#
int allCount = nums.Count();  // allCount is 9
```

What if we wanted the count of only the even numbers in the list?

We would write a code snippet like this

```c#
int countEven = 0;
foreach (var n in nums)
{
  if (n % 2 == 0) countEven++;
}
```

To make our code reusable, we could wrap the `IsEven` logic in a method:

```c#
int countEven = 0;
foreach (var n in nums)
{
  if (IsEven(n)) countEven++;
}
// countEven is 4

// elsewhere
public static bool IsEven(int n) 
{
 return n % 2 == 0;
}
```



#### LINQ `Count()` method

LINQ includes a method for counting the members of an` IEnumerable` such a `List` which returns the count of all items in `nums`:

```c#
int allCount = nums.Count();  // allCount is 9
```

An overload of `Count` return the count of items in `nums` for which the parameter `aMethod` returns true:

`nums.Count(someMethod); `

Internally Count iterates over the list and applies `someMethod` to each element n

What if we wanted the count of only the even numbers in the list?

**Notice that the parameter is a method, not a data type!**

```c#
int linqCount = nums.Count(IsEven);  // still 4
```

We can define and use whatever method we like for the argument, as long as it:

- Has a single parameter of the same type as the `IEnumerable` object it is called on
- returns a` bool`

because that is what the `Count` method is expecting. Another example is show below:

```c#
public static bool IsOdd(int n) 
{
	return n % 2 != 0;
}

var oddCount = nums.Count(IsOdd);

// oddCount is 5
```

**Another example using List of Objects:**

Let's say we have a `Person` class:

 

```c#
public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
	}
```

Now, in our `Main` method, let's create a list of `Person` type:



```c#
List<Person> people = new List<Person> {
	 new Person { Name = "Cathy", Age = 40},
	 new Person { Name = "Nish", Age = 55},
	 new Person { Name = "Lee", Age = 20}
};
```

Now, in the `Main` method, what we want to have a method which takes `Person` types as an object and returns a `bool` if the `Person` object dependent on their `Age` property being above or below 30:

```c#
static bool isYoung(Person p)
{
	return p.Age < 30;
}
```

We can use the `Count` method, which takes a method as a paramater:

```c#
var youngPeopleCount = people.Count(isYoung); //equals 1
```

[Back to Contents](#contents)

#### Anonymous Methods (delegate)

So far we have introduced the idea of methods as parameters to other methods

The LINQ library has lots of such methods:

` .Sum(method that return a number);`

`.Where(method that return bool);`

`.OrderBy(method that returns a key);`

However it is tedious to write a custom method for each query, especially if it may only be needed once. Instead, we could use an **anonymous** method in place. Below is an anonymous method. 

```c#
delegate (int n) { return n % 2 == 0; }
```

**It has a parameter and body but not name**

We can use an anonymous method as the `Count() `argument:

```c#
List<int> nums = new List<int> { 3, 7, 1, 2, 8, 3, 0, 4, 5 };

var evenDCount = 
		nums.Count(delegate (int n) {return n % 2 == 0});

```

But, Lambda expressions do the same thing with cleaner syntax:

```c#
var evenLCount = nums.Count(n => n % 2 == 0);
```

Translation: Count `n` when` (n % 2 == 0)` is true

**Don’t use anonymous methods, use Lambda expressions!!!!!!**

[Back to Contents](#contents)

### Using Lambda Expressions

Consider the `List` of `Person` type we created earlier:

```c#
List <Person> people = new List<Person> {

   new Person { Name = "Cathy", Age = 40},
   new Person { Name = "Nish", Age = 55},
   new Person { Name = "Lee", Age = 20}

};
```

Rather than having to pass a reference...

```C#
var peopleCount = people.Count();
var youngPeopleCount2 = people.Count(p => p.Age < 30);
var totalAge = people.Sum(p => p.Age);
var oldPeopleTotalAge = people.Sum(p => p.Age >= 30 ? p.Age : 0);


//peopleCount is 3
//youngPeopleCount2 is 1
//totalAge is 115
//oldPeopleTotal Age is 95

```

[Back to Contents](#contents)

### Keywords in Method format:

We can use either method or query syntax to query our `DbSet` . Below are examples of the same queries written in both method and query syntax.

##### WHERE

**Example  (Using `Northwind Dbset` to query customers from Berlin): **

```c#
//Query syntax
var custQuery1 =
    from c in db.Customers
    where c.City == "Berlin"
    select c;
//execute custQuery1
foreach (var item in custQuery1)
{
    Console.WriteLine(item.ContactName);
}
    
//Method syntax
var custQuery2 = db.Customers.Where(c => c.City == "Berlin");
//execute custQuery2
foreach (var item in custQuery1)
{
    Console.WriteLine(item.ContactName);
}
```

**Example 2 (using a list of `Person` type, to select`Person` objects who have age more than 25): **

```c#
List<Person> people = new List<Person> {
   new Person { Name = "Cathy", Age = 40},
   new Person { Name = "Nish", Age = 55},
   new Person { Name = "Lee", Age = 20}
			};
//Query syntax
var personQuery1 =
			 from p in people
			 where p.Age > 25
			 select p;
		//execute personQuery1
		foreach (var item in personQuery1)
		{
			Console.WriteLine(item.Name);
		}

//Method syntax
var personQuery2 = people.Where(x => x.Age > 25);

			//execute personQuery2
			foreach (var item in personQuery2)
			{
				Console.WriteLine(item.Name);
			}

```

##### GROUP BY

```c#
//Query syntax
using (var db = new NorthwindContext())
            {
                var orderProductsByUnitInStockQuery1 =
                 from p in db.Products
                 group p by p.SupplierId into newGroup
                 select new
                 {
                     SupplierID = newGroup.Key,
                     UnitsOnStock = newGroup.Sum(c => c.UnitsInStock)
                 };
    
    
				//Execute customersByCoutnry1
                foreach (var result in orderProductsByUnitInStockQuery1)
                {
                    Console.WriteLine($"{result}");
                }
            }

//Method Syntax
var orderProductsByUnitInStockQuery2 =
    db.Products.GroupBy(p => p.SupplierId).Select(newGroup => new
    {
        SupplierID = newGroup.Key,
        UnitsOnStock = newGroup.Sum(c => c.UnitsInStock)
    });

                //Execute orderProductsByUnitInStockQuery2
                foreach (var result in orderProductsByUnitInStockQuery2)
                {
                    Console.WriteLine($"{result}");
                }
```

##### ORDER BY

```c#
//Query syntax
var customerOrderedQuery1 =
                    from p in db.Products
                    orderby p.ReorderLevel 
                    orderby p.QuantityPerUnit descending
                    select new { p.QuantityPerUnit, p.ReorderLevel, p.ProductName };

foreach (var item in customerOrderedQuery1)
{
    Console.WriteLine($"{item.ProductName} || {item.QuantityPerUnit} ||{item.ReorderLevel}");
}

//method syntax
var customerOrderedQuery2 = db.Products.OrderBy(p => p.QuantityPerUnit).ThenByDescending(c => c.ReorderLevel);


//Execute customerOrderedQuery2
foreach (var item in customerOrderedQuery2)
{
    Console.WriteLine($"{item.ProductName} || {item.QuantityPerUnit} ||{item.ReorderLevel}" );
}
```

[Back to Contents](#contents)

### CRUD Operations using Method Syntax

We can perform CRUD operations using Method syntax.

#### CREATE

```c#
 using (var db = new NorthwindContext())
 {
     var newCustomerNish = new Customers()
     {
         CustomerId = "MAND",
         ContactName = "Nish Mandal",
         CompanyName = "ToysRUs"
     };

     db.Customers.Add(newCustomerNish);
     db.SaveChanges();
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

#### UPDATE

```c#
using (var db = new NorthwindContext())
{
		// obtain your selected customer
		var selectedCustomer = db.Customers.Where(c => c.CustomerId == "MAND").FirstOrDefault();
		// now update
		selectedCustomer.City = "Paris";
		// save back to database
		db.SaveChanges();

}
```

(NOTE: the `FirstorDefault()`  returns the **first** element of a sequence or a **default** value if element isn't there)

To do the same in SQL, we would write:

```sql
UPDATE Customers
SET City = 'Paris'
WHERE CustomerID = 'MAND'
```

#### READ

```c#
using (var db = new NorthwindContext())
{
        var readCustomerMANDQuery = db.Customers.Where(c => c.CustomerId == "MAND");
        //Alternatively:
        //var readCustomerMANDQuery = db.Customers.Where(c => c.CustomerId == "MAND").Select(c => c);

        foreach (var c in readCustomerMANDQuery)
        {
            Console.WriteLine(c);
        }
}
```

Alternatively, we could write:

```c#
var readCustomerMANDQuery = db.Customers.Where(c => c.CustomerId == "MAND").Select(c => c);
```

What does `c => c` mean? It means we will call the default `ToString()` method when we execute our query. We can specify the `property` , e.g. `ContactName` . So if we write `c => c.ContactName` instead in the above deferred query's `Select` method, the execute it using a `foreach` loop (as shown above), the console will output the `ContactName` , i.e. Nish Mandal.

#### DELETE

```c#
using (var db = new NorthwindContext())
{
	var selectedCustomer = db.Customers.Where(c => c.CustomerId == "MAND");

    foreach (var c in selectedCustomer)
    {
    	db.Customers.Remove(c);
    }

	db.SaveChanges();
}
```

To do this in SQL, we would write:

```c#
DELETE FROM Customers WHERE CustomerID = 'MAND';
```

In the above example, the first parameter returns the key (initial letter of `ContactName`), second the value(a Customers object), so we are returning lists of customers objects grouped by by first initial of `ContactName`, ordered by the group key.

[Back to Contents](#contents)

### The `=>` Operator

The `=>` token is supported in two forms: as the **lambda operator** and as a separator of a member name and the member implementation in an **expression body** definition.

#### Expression Body 

<u>Syntax:</u>

`Member => expression`

Where `Member` could be a method or read-only property 

```c#
public override string ToString() => $"{Name} is {Age}";
```

Is equivalent to: 

```c#
public override string ToString()

{ return $"{Name} is {Age}"; }
```

The `=>` operator cannot be overloaded.

[Back to Contents](#contents)

## Further Reading

1. Break down of Method Syntax: https://softchris.github.io/pages/dotnet-linq.html#references
2. Method syntax and aggregates: https://www.pluralsight.com/guides/grouping-aggregating-data-linq
3. More information about Lambda expressions: https://www.infoworld.com/article/3516071/how-to-use-lambda-expressions-in-csharp.html
4. https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/query-syntax-and-method-syntax-in-linq 
5. https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-operator 

