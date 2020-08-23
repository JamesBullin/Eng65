# SQL with C#

1. [Setting up the Northwind Database for use in Visual Studio](#setting-up-the-northwind-database-for-use-in-visual studio)

2. [Connecting a Visual Studio application to a SQL Server Database](#connecting-a-visual-studio-application-to-a-sql-server-database)

3. [The using statement](#the-using-statement)

4. [Our first SQL query - SELECT](#our-first-sql-query---select)

5. [CRUD Operations](#crud-operations)

   a.[Create and Insert](#create-and-insert)

   b. [Update](#update)

   c. [Delete](#delete)

6. [Stored Procedures](#stored-procedures)

7. [Conclusion](#conclusion)

8. [Entity Framework](#entity-framework)

9. [Further Reading](#Further-Reading)

### Setting up the Northwind Database for use in Visual Studio 

1. VISUAL STUDIO 

Microsoft’s Visual Studio can be used as a development environment for SQL Server, Azure SQL Database and Azure SQL Data Warehouse. 

If you do not already have Visual Studio installed, download the it from https://visualstudio.microsoft.com/vs/features/ssdt/ . 

When prompted, select 

- the free version (**VS Community 2019**) 

- the **Data storage and processing** workload (under **Other Toolsets**). Select the optional **SQL Server Data Tools** 

If you already have Visual Studio but not the SQL Server Data Tools, you can modify your installation using **Visual Studio Installer**.

2. **CREATE THE NORTHWIND DATABASE** 

2.1 DOWNLOAD THE SCRIPT 

You can find a script to download the Northwind Database at https://github.com/microsoft/sql-server-samples/tree/master/samples/databases/northwind-pubs 

Click on the ‘instnwnd.sql‘ link and click ‘Download’ which opens up a web page with all the SQL code to create a new Northwind Database. It is very long! 

Copy and save the code: 

- Hit Control-A then Control-C to select it all and copy. 
- Open up a new Notepad file than hit Control-V to paste the code into it. 
- Then save the Notepad file (Control-S) as InstallNorthwind.sql.   You can save this file anywhere, it doesn’t need to be within a Visual Studio project. 

2.2 – INSTALL THE DATABASE 

- Launch Visual Studio 2019. (don’t create a project, choose the bottom link to simply open Visual Studio) 
- Select the menu option View => SQL Server Object Explorer => right click on LocalDb and choose 'New Query'.  
- Now select File => Open => File, browse to your InstallNorthwind.sql file and select it. 

Click the 'Execute' button (open green arrow, shortcut CTRL + SHIFT + E) to run the script.  This installs the Northwind database. 

If you are asked for the name of the SQL Server, select (localdb)MSSQLLocalDB and Windows Login. 

[back to contents](#lessons)

### Connecting a Visual Studio application to a SQL Server Database

1. Create a new Console App (.NET Core) project.
2. Add the NuGet package: `System.Data.SqlClient`. This allows us to talk to SQL!
3. Add `using System.Data.sqlClient`
4. Click on the Northwind Database in SQL Server Explorer. Run a query to test that your are connected.
5. Go to properties (ensure you are still clicked onto the Northwind Database). Copy the 'connection string'. It should look like this: `Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False`
6. We are now going to  add a Customer class to use our data which we read, and test our connection. Your connection string should go after data source=:

```c#
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace CSharpSQL
{
	public class Program
	{
		static void Main(string[] args)
		{
            var Customers = new List<Customer>();
            using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;"))
            {
                //Testing our connection is open
                connection.Open();
                Console.WriteLine(connection.State);
            }
        }

	}
	
	public class Customer
	{
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string City { get; set; }

        public string GetFullName()
        { 
            return $"{ContactTitle} - {ContactName}"; 
        }

}
```

6. This should run and validate that the connection status is `Open`.

The project code accesses the Customers table of Northwind database and performs Create (insert), Read (select), Update, and Delete operations. 

First look at the `Customer class`. It contains:

1. A default constructor

   `public Customer() {}`

2. Properties corresponding to the Customers database table

   ```C#
   public string CustomerId { get; set; }
   public string CompanyName { get; set; }
   ```

   

3. A method that uses some of the properties

   ```c#
   public string GetFullName()
   { 
               return $"{ContactTitle} - {ContactName}"; 
   }
   ```

[back to contents](#lessons)

### The `using` statement

Notice the using statement:

```c#
using (var connection = new SqlConnection()){
  // use connection
}
```

The scope of connection is limited to the using block.

When connection goes out of scope at the end of the block, its Dispose() method is called which (for a `SqlConnection` object) closes the connection to the database.

`using` can only be used with classes that implement the `IDisposable` interface which declares a single method, `Dispose()`

[back to contents](#lessons)

### Our first SQL query - SELECT

Add this within the using block, after the connection is opened:

```c#
using (var command = new SqlCommand("select * from customers", connection))
{
	

    //SQL reader Provides a way of reading a forward-only stream of rows from a SQL Server database. 
	SqlDataReader sqlReader = command.ExecuteReader();
	//List where we will add customer objects to
	List<Customer> customers = new List<Customer>();

    // loop while the reader has more data to read
    while (sqlReader.Read())
    {

        //creating variables for customer
        var customerID = sqlReader["CustomerID"].ToString();
        var contactName = sqlReader["ContactName"].ToString();
        var companyName = sqlReader["CompanyName"].ToString();
        var city = sqlReader["City"].ToString();
        var contactTitle = sqlReader["ContactTitle"].ToString();

        //new customer object
        var customer = new Customer() { ContactTitle = contactTitle, CustomerID = customerID, ContactName = contactName, City = city, CompanyName = companyName };

        customers.Add(customer);    
    }

 		// iterate over and output all customers
        foreach (var c in customers)
        {
           Console.WriteLine($"Customer {c.GetFullName()} has ID {c.CustomerID} and lives in {c.City}");
        }
    				//Close connection
                    sqlReader.Close(); 
 }
```
`sqlReader`Provides a way of reading a forward-only stream of rows from a SQL Server database. This class cannot be inherited.



[back to contents](#lessons)

### CRUD Operations

In computer programming, **create**, **read** (aka retrieve), **update**, and **delete** (***CRUD***) are the four basic functions of persistent storage.

#### Create and Insert

To perform a Select (Read) operation we:

- Created a `SqlCommand` command from a string and a `SqlConnection `object 
- Executed the command using `command.ExecuteReader();`

For the other operations which update the database, we:

- Create a `SqlCommand` command from a string and a `SqlConnection` object 
- Executed the command using `command.ExecuteNonQuery();`

For the next examples we will first create a Customer object:

```C#
 public class Program
    {
        static void Main(string[] args)
        {
            using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;"))
            {
                connection.Open();
                Console.WriteLine(connection.State);

   
                    var newCustomer = new Customer()
                    {
                        CustomerID = "MAND",
                        ContactName = "Nish Mandal",
                        City = "Birmingham",
                        CompanyName = "ToysRUs"
                    };               
             }
        }

     }
```

We can now insert this customer into the database:

```C#
 public class Program
    {
        static void Main(string[] args)
        {
            using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;"))
            {
                connection.Open();
                Console.WriteLine(connection.State);

   
                    var newCustomer = new Customer()
                    {
                        CustomerID = "MAND",
                        ContactName = "Nish Mandal",
                        City = "Birmingham",
                        CompanyName = "ToysRUs"
                    };



                    string sqlString = $"INSERT INTO CUSTOMERS(CustomerID, ContactName, CompanyName, City) VALUES   ('{newCustomer.CustomerID}', '{newCustomer.ContactName}', '{newCustomer.CompanyName}', '{newCustomer.City}')";
                    // execute insert SQL command
                    using (var command2 = new SqlCommand(sqlString, connection))
                    {
                        int affected = command2.ExecuteNonQuery();
                    }
                
               connection.Close()
             }
     }
```

Now, if we query the SQL database, we will find that the `newCustomer` has been added to the customer database:

```sql
SELECT * FROM Customers WHERE CustomerID = 'MAND';
```

[back to contents](#lessons)



#### Update

We can also update information about Nish Mandal. Let's change their city from Birmingham to London:

```c#
public class Program
{
    static void Main(string[] args)
    {
        using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;"))
        {
            connection.Open();
            Console.WriteLine(connection.State);

             var newCustomer = new Customer()
                {
                    CustomerID = "MAND",
                    ContactName = "Nish Mandal",
                    City = "Birmingham",
                    CompanyName = "ToysRUs"
                };

            string sqlUpdateString = $"UPDATE CUSTOMERS SET City = 'Berlin' WHERE CustomerID='{newCustomer.CustomerID} '";

            using (var command2 = new SqlCommand(sqlUpdateString, connection))
            {
                int affected = command2.ExecuteNonQuery();
            }
            
             connection.Close()
        }
    }
 }
```

Now, if we query the SQL database... 

```sql
SELECT * FROM Customers WHERE CustomerID = 'MAND';
```

...we will find that Nish Mandal's City is now Berlin

[back to contents](#lessons)

####  Delete

Now, let's delete Nish Mandal from the Northwind Database!

```c#
public class Program
    {
        static void Main(string[] args)
        {
            using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;"))
            {
                connection.Open();
                Console.WriteLine(connection.State);

                var newCustomer = new Customer()
                {
                    CustomerID = "MAND",
                    ContactName = "Nish Mandal",
                    City = "Birmingham",
                    CompanyName = "ToysRUs"
                };

            string sqlDeleteString = $"DELETE FROM CUSTOMERS WHERE CustomerId = '{newCustomer.CustomerID}'";

            using (var command2 = new SqlCommand(sqlDeleteString, connection))
            {
                // if success this should equal 1
                int affected = command2.ExecuteNonQuery();
            }

        }
    }
 }
```

[back to contents](#lessons)

## Stored Procedures

Stored procedures allow variable values to be passed into the database 

First we must write the stored procedure in the database:

- Go to View, SQL Server Object Explorer. 
- Expand the Northwind Database and the `Programmability -> Stored Procedures` folder
- Double click to inspect existing `Stored Procedures`.
- Right click on `Stored Procedures` folder and choose `Add New Stored Procedure`
- Paste the following procedure: 

```sql
CREATE PROCEDURE [dbo].[UpdateCustomer]
		@ID nchar(5),
		@NewName nvarchar(40)
AS
		UPDATE Customers
		SET ContactName = @NewName 
		WHERE CustomerID = @ID
RETURN 0
```

- Press the `Update` button and then `Update Database`
- The stored procedure is now in the database
- Break down of stored procedure:

![Stored Procedure Parts](https://www.essentialsql.com/wp-content/uploads/2015/01/Stored-Procedure1.png?ezimgfmt=rs:600x270/rscb3/ng:webp/ngcb3)

- We can now use this stored procedure in our C# program to add a customer:

```c#
 public class Program
    {
        static void Main(string[] args)
        {
            using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;"))
            {
                connection.Open();
                Console.WriteLine(connection.State);

            var newCustomer = new Customer()
            {
                CustomerID = "MAND",
                ContactName = "Nish Mandal",
                City = "Birmingham",
                CompanyName = "ToysRUs"
            };
			
             //
            using (var updateCustomerCommand = new SqlCommand("UpdateCustomer", connection))
            {
                // Using System.Data;
                updateCustomerCommand.CommandType = CommandType.StoredProcedure;
                // add parameters
                updateCustomerCommand.Parameters.AddWithValue("ID", newCustomer.CustomerID);
                updateCustomerCommand.Parameters.AddWithValue("NewName", "Nish Mandal Updated Name");
                // run the update
                int affected = updateCustomerCommand.ExecuteNonQuery();
            }

        }
    }
 }
```

[back to contents](#lessons)

## Conclusion

We now know how to access and update a database from our C# code using standard SQL

There is a lot more we could do

- Could you translate your SQL queries to a C# program?

What are the disadvantages of doing it this way?

- Lots of boilerplate code
- Visual Studio doesn’t help with the SQL string syntax (it is just a string)

[back to contents](#lessons)

## Entity Framework

Fortunately .NET provides Entity Framework

- “Entity Framework is an object-relational mapper (O/RM) that enables .NET developers to work with a database using .NET objects.
- It eliminates the need for most of the data-access code that developers usually need to write.

Entity Framework 6 runs in .NET Framework

- “Entity Framework 6 (EF6) is a tried and tested object-relational mapper (O/RM) for .NET with many years of feature development and stabilization”

The newest version, Entity Framework Core, runs in .NET Core

- “Entity Framework (EF) Core is a lightweight, extensible, [open source](https://github.com/aspnet/EntityFrameworkCore) and cross-platform version of the popular Entity Framework data access technology.”

You may still encounter the traditional SQL methods we have covered today in legacy code

[back to contents](#lessons)

## Further Reading:

1. https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-statement 

2. https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql/index?view=netframework-4.8 
3. https://docs.microsoft.com/en-us/ef/core