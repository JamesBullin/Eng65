# Entity Framework Core: Model First approach and migrations

## Prerequisites

1. Complete "Testing CRUD Operations" Lesson

   


## Contents

1. [Approaches to using EF](#Approaches-to-using-EF)
2. [Create a blogging database](#Create-a-blogging-database)
3. [What have we made](#what-have-we-made)
4. [EF Migrations](ef-migrations)
5. [Updating Database-first code]()
6. [Exercise](#exercise)
7. [Further Reading](#further-reading)



## Approaches to using EF

Remember the purpose of Entity Framework is to “enable .NET developers to work with a database using .NET objects.”

.NET objects – the classes in C# code

Database – the tables

We can either

- Start with a database and create classes (the data model) to match it 
- Start with a data model and generate a database from it

Which is best? Depends on whether your database or your object model is the “source of truth”

In this session we will use the model first approach

Using EF Migrations, which enables you to update the database structure as the model changes



![](https://www.entityframeworktutorial.net/images/efcore/ef-core-migration.png)

## Create a blogging database

First, in SQL Server Object Explorer, create a new database called Blogging 

Follow the directions in

https://docs.microsoft.com/en-us/ef/core/get-started/index?tabs=visual-studio  “Getting Started with EF Core”

Under the “Create a new project” heading, click on the “Visual Studio” tab

Use the NuGet Package manager to install the following packages:

- `Microsoft.EntityFrameworkCore`
- `Microsoft.EntityFrameworkCore.SqlServer`

**DO NOT install `Microsoft.EntityFrameworkCore.Sqlite`**

When copying `Model.cs`, replace `UseSqlite` with `UseSqlServer` in the line:

`protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=Blogging;")`



Note:  `MSBuildProjectDirectory`is the absolute path of the directory where the project file is located, for example *C:\MyCompany\MyProduct*.

## What have we made?

Database:

- Examine the tables

Migrations:

- Look at `InitialCreate.cs` and `InitialCreateDesigner.cs`

Conventions:

- A class named Student will create the database table Students by adding an 's' on the end
- The primary key of a class will be “`Id`” or `ClassNameId` (eg “`StudentId”`)
- Autoincremented by default
- Use the annotation `[NotMapped]` on a property to prevent it from being mapped to the database e.g.:

```c#
public class Contact
{
    public int ContactId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; } 
    public AuditLog AuditLog { get; set; }
}
[NotMapped]
public class AuditLog
{
    public int EntityId { get; set; }
    public int UserId { get; set; }
    public DateTime Modified { get; set; }
}
```

- One-to-many is the default relationship

**Remember: As per the above figure, EF Core API builds the EF Core model from the domain (entity) classes and EF Core migrations will create or update the database schema based on the EF Core model. Whenever you change the domain classes, you need to run migration to keep the database schema up to date.**

## EF Migrations

Code-based migration is useful when you want more control on the migration. When you add, remove, or change entity classes or change your `DbContext` class, the next time you run the application it automatically deletes your existing database, creates a new one that matches the model, and seeds it with test data.



A tool for synchronising the database with the code model when it is updated:

- Add or delete columns, add or drop tables, change relationships

See https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/index?tabs=dotnet-core-cli 

Saves any data currently present in the database

Can customise how the data is migrated

**Or drop and re-create the database**

https://docs.microsoft.com/en-us/ef/core/managing-schemas/ensure-created 

Safe and straightforward if you don’t want to keep existing data



If we look at our migrations in the migration folder well find `partial classes` which are named after what we typed after the`Add-migration` command (i.e. migration name) in the PMC. These classes inherit from the Migration Class. Note these methods in this class. The `up` method is called when migrating “up” the database – *forward* in time – while the `down` method is called when migrating “down” the database – or, *back* in time. In other words, **the `up` method is a set of directions for running a migration, while the `down` method is a set of instructions for reverting a migration**.

## Updating Database-first code?

If you start from a database and generate your code model from it, you may later need to update the database schema

- For example to add more table columns, or another table.

Once you have updated the database, you need to update the code model: 

- To do this simply scaffold the affected tables (for example Customers and Orders) again:
- `Scaffold-DbContext 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False' -Tables Customers, Orders –force`

The keyword `-force` forces the existing code model for these tables to be updated - the existing code WILL BE DELETED.

## Keywords

The following table lists important migration commands in EF Core.

| PMC Command                      | Usage                                                        |
| -------------------------------- | ------------------------------------------------------------ |
| `add-migration <migration name>` | Creates a migration by adding a migration snapshot.          |
| `Scaffold-DbContext`             | Scaffolds a `DbContext` and entity type classes for a specified database. |
| `Remove-migration`               | Removes the last migration snapshot.                         |
| `Update-database`                | Updates the database schema based on the last migration snapshot. |
| `Script-migration`               | Generates a SQL script using all the migration snapshots.    |



## Exercise

Add some extra code to the Main method to:

- Add breakpoints in the code and examine the contents of the database tables
- Add more Blogs
- Add more Posts to the each blog
- Search for a different blog
- When a blog is found, write out url and the Content of each post to console
- Experiment with different queries
- Add more properties to the class(es)
- Add a new class
- Migrate the database to match

## Further Reading

1. Add or delete columns, add or drop tables, change relationships: https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/index?tabs=dotnet-core-cli 
2. Drop or recreate database: https://docs.microsoft.com/en-us/ef/core/managing-schemas/ensure-created 
3. Another walkthrough: https://www.entityframeworktutorial.net/efcore/entity-framework-core-migration.aspx