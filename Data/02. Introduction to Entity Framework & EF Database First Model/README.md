# Entity Framework Introduction & EF Database First Model

1. [Introduction to Entity Framework](#introduction-to-entity-framework)
2. [Setting up EF (Database First)](#setting-up-ef-(database-first))
3. [Introduction to CRUD operations using LINQ](Introduction-to-CRUD-operations-using-LINQ)
4. [`using`Statement](#using-statement)
5. [Summary](#Summary)
6. [Exercise](#Exercise)
7. [Further Reading](#Further-Reading)

# Introduction to Entity Framework

Entity Framework is an object-relational mapper (O/RM) that enables .NET developers to work with a database using .NET objects. 

It eliminates the need for most of the data-access code that developers usually need to write.

Entity Framework 6 runs in .NET Framework

“Entity Framework 6 (EF6) is a tried and tested object-relational mapper (O/RM) for .NET with many years of feature development and stabilization”

The newest version, Entity Framework Core, runs in .NET Core

“Entity Framework (EF) Core is a lightweight, extensible, [open source](https://github.com/aspnet/EntityFrameworkCore) and cross-platform version of the popular Entity Framework data access technology.” (https://docs.microsoft.com/en-us/ef/ )

Maps C# objects to relational database tables 

Can use same C# code with different database engines which use different flavours of SQL

- Microsoft SQL Server
- SQLite
- PostgreSQL
- MySQL
- Oracle DB…

Uses LINQ for queries

- Language-Integrated Query 
- Can also be used to query other data sources: Collections, JSON, XML etc
- Unlike SQL strings, get full Visual Studio and debugging support

Remember the purpose of Entity Framework is to “enable .NET developers to work with a database using NET objects.”
NET objects – the classes in C# code
Database – the tables
We can either

- Start with a database and create classes (the data model) to match it 
- Start with a data model and generate a database from it
- Which is best? Depends on whether your database or your object model is the “source of truth”
  In this session we will use the database first approach.





## Setting up EF (Database First)

We will be Reverse Engineering – creating a model from an existing database. This is also known as Scaffolding

- In this session we will reverse engineer the Northwind database.
- Create a new .NET Core C# Console Application project/solution
- Open the Northwind database in SQL Server Object Explorer

Create a new project and call it `CodeFromNorthwindModel`. Call the solution `CodeFromNorthwind`

Use the NuGet package manager to add to the project dependencies:

- `Microsoft.EntityFrameworkCore`
- `Microsoft.EntityFrameworkCore.SqlServer`
- `Microsoft.EntityFrameworkCore.Tools`

```
NOTE: Microsoft.EntityFrameworkCore.Tools allow use to use these commonly used commands:

`Add-Migration`
`Drop-Database`
`Get-DbContext`
`Scaffold-DbContext`
`Script-Migrations`
`Update-Database`
```



Make a copy of the connection string to the Northwind database:

`'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False'`

Open Package Manager Console (`Tools -> Nuget Package Manager -> Package Manager Console`) and type the line below:

`Scaffold-DbContext 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False' Microsoft.EntityFrameworkCore.SqlServer`

By default you will scaffold all the tables. To specify just the Customers and Orders tables, end with "-Tables Customers, Orders".

`Scaffold-Dbcontext` Generates code for a `DbContext` and entity types for a database. In order for `Scaffold-DbContext` to generate an entity type, the database table must have a primary key.

The connection string contains the information that the provider need to know to be able to establish a connection to the database or the data file.

### Examine the generated code

You should see one class file per table. **Create a new class diagram to illustrate all the relationships!!**

![ERD of Northwind](https://yintingchou.com/posts/2017-09-01-learning-microsoft-sql-server/ERD.png)

Each class (for example, Orders) contains:

- A Public property representing the primary key  `public int OrderId { get; set; }`

- A Public property corresponding to each table column `public DateTime? OrderDate { get; set; }`

- Public properties referencing another class/table, and the foreign key

  - N to 1 association

  - `public virtual Customers Customer { get; set; }`
  - `public string CustomerId { get; set; }`

- Public properties which are collections of another table class

  - 1 to N association

  - `public virtual ICollection<OrderDetails> OrderDetails { get; set; }`

  )

**Example class file – Categories – you should see one class per table:**

```c#
public partial class Categories

{

 public Categories()

  {

 		Products = new HashSet<Products>();

  }

  public int CategoryId { get; set; }
  public string CategoryName { get; set; }
  public string Description { get; set; }
  public byte[] Picture { get; set; }

  public virtual ICollection<Products> Products { get; set;}

}
```

### Partial Classes

The generated classes have the keyword `partial`

```c#
 namespace CodeFromNorthwindModel {

  {       public partial class Customers

 { …
```

This allows you to write more code for the same class elsewhere, as long as:

- It also has the keyword `partial`
- It has the same namespace and name
- This means you can leave this generated code as is
- Put any additions in another file (create a new folder in your project and name is `ClassCustomisation` and add a new `.cs` file called `CustomersCust.cs`. Now, add the code below)

```c#
namespace CodeFromNorthwindModel
{

		public partial class Customers
		{
			public override string ToString()
			{
				return $"{CustomerId} - {ContactName} - {City}";
			}
		}
}
```

(Note:  Remember to ensure the `namespace` is the same as the other partial classes.)

### `DBContext` File

Open up `NorthwindContext.cs`

- `NorthwindContext` is a subclass of `DbContext`
- Used to query the database

And group together changes that are saved to the database as a unit

- Has several public properties e.g.:
- `public virtual DbSet<Customer> Customers { get; set; }`

A `DbSet` contains all the entities of a given type that can be queried from the database

Overrides two `DbContext` methods:

- `OnConfiguring` – defines the connection options
- `OnModelCreating` – defines the database table

Other `DbContext` methods include:

| Method           | Usage                                                        |
| ---------------- | ------------------------------------------------------------ |
| Add              | Adds a new entity to `DbContext` with Added state and starts tracking it. This new entity data will be inserted into the database when SaveChanges() is called. |
| AddAsync         | Asynchronous method for adding a new entity to `DbContext` with Added state and starts tracking it. This new entity data will be inserted into the database when SaveChangesAsync() is called. |
| AddRange         | Adds a collection of new entities to `DbContext` with Added state and starts tracking it. This new entity data will be inserted into the database when SaveChanges() is called. |
| AddRangeAsync    | Asynchronous method for adding a collection of new entities which will be saved on SaveChangesAsync(). |
| Attach           | Attaches a new or existing entity to `DbContext` with Unchanged state and starts tracking it. |
| AttachRange      | Attaches a collection of new or existing entities to `DbContext` with Unchanged state and starts tracking it. |
| Entry            | Gets an `EntityEntry` for the given entity. The entry provides access to change tracking information and operations for the entity. |
| Find             | Finds an entity with the given primary key values.           |
| FindAsync        | Asynchronous method for finding an entity with the given primary key values. |
| Remove           | Sets Deleted state to the specified entity which will delete the data when SaveChanges() is called. |
| RemoveRange      | Sets Deleted state to a collection of entities which will delete the data in a single DB round trip when SaveChanges() is called. |
| SaveChanges      | Execute INSERT, UPDATE or DELETE command to the database for the entities with Added, Modified or Deleted state. |
| SaveChangesAsync | Asynchronous method of SaveChanges()                         |
| Set              | Creates a `DbSet<TEntity>` that can be used to query and save instances of TEntity. |
| Update           | Attaches disconnected entity with Modified state and start tracking it. The data will be saved when SaveChanges() is called. |
| UpdateRange      | Attaches a collection of disconnected entities with Modified state and start tracking it. The data will be saved when SaveChagnes() is called. |
| OnConfiguring    | Override this method to configure the database (and other options) to be used for this context. This method is called for each instance of the context that is created. |
| OnModelCreating  | Override this method to further configure the model that was discovered by convention from the entity types exposed in `DbSet<TEntity>` properties on your derived context. |

Logically, a `DBContext` maps to a specific database that has a schema that the` DBContext` understands. And on that DBContext class, you can create properties that are type `DbSet<T>`.  Note: The connection string let's our `DBContext` knows which server to go to and which database to query.

![](https://www.entityframeworktutorial.net/images/EF6/dbcontext.png)





### `Dbset` Class

The `DbSet` class represents an entity set that can be used for **create**, **read**, **update**, and **delete** operations.

The context class (derived from `DbContext`) must include the `DbSet` type properties for the entities which map to database tables and views.

The following table lists important methods of the `DbSet` class:

| Method Name          | Return Type                          | Description                                                  |
| -------------------- | ------------------------------------ | ------------------------------------------------------------ |
| Add                  | Added entity type                    | Adds the given entity to the context with the Added state. When the changes are saved, the entities in the Added states are inserted into the database. After the changes are saved, the object state changes to Unchanged.  Example: dbcontext.Students.Add(studentEntity) |
| AsNoTracking<Entity> | DBQuery<Entity>                      | Returns a new query where the entities returned will not be cached in the DbContext. (Inherited from DbQuery.)  **Entities returned as AsNoTracking will not be tracked by DBContext. This will be a significant performance boost for read-only entities.**   Example: var studentList = dbcontext.Students.AsNoTracking<Student>().ToList<Student>(); |
| Attach(Entity)       | Entity which was passed as parameter | Attaches the given entity to the context in the Unchanged state  Example: dbcontext.Students.Attach(studentEntity); |
| Create               | Entity                               | Creates a new instance of an entity for the type of this set. This instance is not added or attached to the set. The instance returned will be a proxy if the underlying context is configured to create proxies and the entity type meets the requirements for creating a proxy.  Example: var newStudentEntity = dbcontext.Students.Create(); |
| Find(int)            | Entity type                          | Uses the primary key value to find an entity tracked by the context. If the entity is not in the context, then a query will be executed and evaluated against the data in the data source, and null is returned if the entity is not found in the context or in the data source. Note that the Find also returns entities that have been added to the context but have not yet been saved to the database.  Example: Student studEntity = dbcontext.Students.Find(1); |
| Include              | DBQuery                              | Returns the included non-generic LINQ to Entities query against a DbContext. (Inherited from DbQuery)  Example: var studentList = dbcontext.Students.Include("StudentAddress").ToList<Student>(); var studentList = dbcontext.Students.Include(s => s.StudentAddress).ToList<Student>(); |
| Remove               | Removed entity                       | Marks the given entity as Deleted. When the changes are saved, the entity is deleted from the database. The entity must exist in the context in some other state before this method is called.  Example: dbcontext.Students.Remove(studentEntity); |
| SqlQuery             | DBSqlQuery                           | Creates a raw SQL query that will return entities in this set. By default, the entities returned are tracked by the context; this can be changed by calling AsNoTracking on theDbSqlQuery<TEntity> returned from this method.  Example: var studentEntity = dbcontext.Students.SqlQuery("select * from student where studentid = 1").FirstOrDefault<Student>(); |

Visit MSND for more information on [DbSet](https://msdn.microsoft.com/en-us/library/system.data.entity.dbset(v=vs.113).aspx).

### `Program.cs` file

Open up `Program.cs`

Add using `System.Linq;`

Add this to the top of the Main method, and comment out the rest of the Main method code

```c#
 static void Main(string[] args)

 {
  using (var db = new NorthwindContext())

      {
       	Console.WriteLine(db.ContextId);
      }

}
```

Run the program - a connection code should be output: 15596622-31dd-489e-a385-86add2c4ce1b:0

We are now going to use CRUD operations!



Now add the code on the below (within the using block) to implement CRUD operations

## Introduction to CRUD operations using LINQ

We will cover LINQ in more detail in the next lesson, but, for now, let's see what CRUD operations we can use.

Firstly, create a new project, `Console App (.Net Core)`, called `CodeFromNorthwindBusiness`. Right click the project and ensure it references the `CodeFromNorthwindModel`. Rename the `Program.cs` file to `CRUDManager.cs`. The class in this file should be called `CRUDManager`. The file should look like below (Note the `using` statements):

```c#
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
            Console.WriteLine("Hello World");
        }
	}
}
```



### Read

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
### Create

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

### Update

Below, we are using a lambda method syntax to update the customer, Nish Mandal (we will cover lambda expressions in the next lesson)

```c#
static void Main(string[] args)
		{

		using (var db = new NorthwindContext())
		{
			// obtain your selected customer
			var selectedCustomer = db.Customers.Where(c => c.CustomerId == "BLOG").FirstOrDefault();
			// now update
			selectedCustomer.City = "Paris";
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

### Delete

Below, we are using a lambda method syntax to delete the customer, Nish Mandal (we will cover lambda expressions in the next lesson)

```c#
	static void Main(string[] args)
	{
		using (var db = new NorthwindContext())
		{
			// select customer
			var selectedCustomer = db.Customers.Where(c => c.CustomerId == "MAND").FirstOrDefault();

			// remove customer from local DbContext copy of database
			db.Customers.Remove(selectedCustomer);

			// update database
			db.SaveChanges();
		}
	}
```

# `Using `Statement

The lifetime of the context begins when the instance is created and ends when the instance is either disposed or garbage-collected. Use `using` if you want all the resources that the context controls to be disposed at the end of the block. When you use `using`**, the compiler automatically creates a try/finally block and calls dispose in the `finally`block.

Put simply:

The C# `using` statement defines a boundary for the object outside of which, the object is automatically destroyed. The using statement in C# is exited when the end of the `using` statement block or the execution exits the `using`statement block indirectly, for example - an exception is thrown.

# Summary

We have gone through what the EF is, how to create code from a database, and perform CRUD operations using EF.

We also touched upon using LINQ and Lambda expressions. We will go through these in the next lesson

# Exercise:

Trainees to use the EF Database First Model on the database they created during SQL week.

# Further Reading

1. https://docs.microsoft.com/en-us/ef/core/managing-schemas/scaffolding?tabs=vs 

2. https://docs.microsoft.com/en-us/ef/core/querying/related-data

3. https://www.learnentityframeworkcore.com/lazy-loading 

4. https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/join-clause