using System;
using System.Net.Mail;

namespace Lab_05_Selection_app
{
	public class Program
	{
		static void Main(string[] args)
		{
			//string result = Grade(65);

			//Console.WriteLine(result);

			//var result = Priority(2);
			//Console.WriteLine(result);
			int mark = 70;

			int stars = mark > 60 ? 3 : 1;

		}

		public static string PassFailTernary(int mark)
		{
			//if(condition) ? then do this: otherwise do this
			
			
			return mark >= 40 ? "Pass" : "Fail";
		}
		public static string Priority(int level)
		{
			string priority = "Code ";

			switch (level)
			{
				case 3:
					priority = priority + "Red";
					break;
				case 2:
				case 1:
					priority = priority + "Amber";
					break;
				case 0:
					priority = priority + "Green";
					break;
				default:
					priority = "Error";
					break;
			}

			return priority; 
		}

		public static string PassFail(int mark)
		{
			var grade = "Fail";

			if (mark >= 40)
			{
				grade = "Pass";
			}

			return grade;
		}


		public static string Grade(int mark)
		{
			var grade = "";

			if (mark >= 40)
			{
				grade = "Pass";
				if (mark >= 75)
				{
					grade += " with Distinction";
				}
				else if (mark >= 60)
				{
					grade += " with Merit";
				}
			}

			else
			{
				grade = "Fail";
			}
			return grade;
		}

	}
}
