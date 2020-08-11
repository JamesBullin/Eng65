using NUnit.Framework;
using Lab_05_Selection_app;

namespace Lab_05_Selection_Tests
{
	public class Tests
	{
		//[SetUp]
		//public void Setup()
		//{
		//}

		[TestCase(40)]
		[TestCase(41)]
		[TestCase(50)]
		[TestCase(100)]
		public void PassTest(int x)
		{
			var results = Program.PassFail(x);
			Assert.AreEqual("Pass", results);
		}

		[TestCase(39)]
		[TestCase(30)]
		[TestCase(0)]
		[TestCase(15)]
		public void FailTest(int x)
		{
			var results = Program.PassFail(x);
			Assert.AreEqual("Fail", results);
		}

		[TestCase(100)]
		[TestCase(75)]

		public void Mark75AndPverPassesWithDistinction(int mark)
		{
			var result = Program.Grade(mark);
			Assert.AreEqual("Pass with Distinction", result);
		}


		[TestCase(74)]
		[TestCase(60)]

		public void Mark75AndPverPassesWithMerit(int mark)
		{
			var result = Program.Grade(mark);
			Assert.AreEqual("Pass with Merit", result);
		}

		[TestCase(3, "Code Red")]
		[TestCase(2, "Code Amber")]
		[TestCase(1, "Code Amber")]
		[TestCase(0, "Code Green")]
		[TestCase(7, "Error")]


		public void PriorityTest(int level, string expected)
		{
			var result = Program.Priority(level);
			Assert.AreEqual(expected, result);
		}
	}
}