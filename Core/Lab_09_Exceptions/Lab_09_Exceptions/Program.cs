using System;
using System.IO;

namespace Lab_09_Exceptions
{
	public class Program
	{
		private static string[] _theBeatles = new string[] { "John", "Paul", "George", "Ringo" };
	

		static void Main(string[] args)
		{
			try
			{
				AddBeatles(4, "Brian");
			}

			catch (ArgumentException e)
			{
				Console.WriteLine("Exception thrown: " + e.Message);
			}

		}

		public static void AddBeatles(int pos, string name)
		{
			if (pos < 0 || pos >= _theBeatles.Length)
			{
				throw new ArgumentException($"The Beatles do not have a position {pos}");
			}

			_theBeatles[pos] = name;


		}


	}
}
