using System;

namespace Lab_04_Methods_testing_lib
{
	public class TripleCalc
	{
		public static int Calc(int a, int b, int c, out int sum)
		{
			sum = a + b + c;
			return a * b * c;
		}

	}
}
