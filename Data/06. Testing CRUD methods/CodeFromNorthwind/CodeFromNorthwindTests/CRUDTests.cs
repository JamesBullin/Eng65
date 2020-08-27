using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using CodeFromNorthwindModel;
using CodeFromNorthwindBusiness;
using NUnit.Framework;

namespace NorthwindTests
{
	public class Tests
	{
		CRUDManager _crudManager = new CRUDManager();

		[SetUp]

		public void Setup()
		{
			using (var db = new NorthwindContext())
			{


			}
		}


		[Test]
		public void CustomerAddedTest()
		{
			using (var db = new NorthwindContext())
			{

				Assert.AreEqual("", "1");

			}
		}

		[Test]
		public void CustomerAddedDetailsCorrectTest()
		{
			using (var db = new NorthwindContext())
			{

				Assert.AreEqual("", "1");

			}
		}


		[Test]
		public void UpdateTest()
		{
			using (var db = new NorthwindContext())
			{

				Assert.AreEqual("", "1");

			}
		}

		[Test]
		public void UpdateSeveralDetailsTest()
		{
			using (var db = new NorthwindContext())
			{
				Assert.AreEqual("", "1"); //test the update method which takes 5 parameters

			}
		}

		[Test]
		public void RemoveTest()
		{
			using (var db = new NorthwindContext())
			{

				Assert.AreEqual("", "1");


			}
		}
	}
}