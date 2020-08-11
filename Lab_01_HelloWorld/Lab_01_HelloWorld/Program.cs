using System;

namespace Lab_01_HelloWorld
{
	class Program
	{
	
		
		static void Main(string[] args)
		{
			Console.WriteLine("hello, command line demo");

			foreach (var item in args)
			{
				Console.WriteLine(item);
			}
		}
	}

}
