using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using CodeFromNorthwindModel;
using CodeFromNorthwindBusiness;
using NUnit.Framework;

public class Tests
{
	[SetUp]

	public void Setup()
	{
		using (var db = new NorthwindContext())
		{
			Assert.Pass();
		}
	}

	[Test]
	public void CustomerAddedToDatabaseTest()
	{
		using (var db = new NorthwindContext())
		{
			Assert.Pass();
		}
	}

	public void CustomerAddedTODatabaseCorrectDetails()
	{
		using (var db = new NorthwindContext())
		{
			Assert.Pass();
		}
	}

	[Test]
	public void UpdateTest()
	{
		using (var db = new NorthwindContext())
		{
			Assert.Pass();
		}
	}
	[Test]
	public void DeleteTest()
	{
		using (var db = new NorthwindContext())
		{
			Assert.Pass();
		}
	}
}