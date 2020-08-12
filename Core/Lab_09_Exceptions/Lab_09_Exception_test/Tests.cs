using NUnit.Framework;
using Lab_09_Exceptions;
using System;


namespace Lab_09_Exception_test

{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[TestCase(-1)]
		[TestCase(4)]

		public void WhenAnIllegalPositionIsSpecifiedAnExceptionIsThrown(int pos)
		{
			var ex = Assert.Throws<ArgumentException>(() => Program.AddBeatles(pos, "George"));
			Assert.AreEqual($"The B have a position {pos}", ex.Message, "Exception message not correct");
		}

	}
}