using System;

namespace Lab_07_Loops
{
	class Program
	{
		static void Main(string[] args)
		{
			//for (int i = 1; i <= 10; i++)
			//{
			//	Console.WriteLine(i);
			//}

			//int[] myArray = { 10, 20, 30 };

			//for (int i = 2; i <= 0; i--)
			//{
			//	Console.WriteLine(myArray[i]);
			//}

			//int counter = 0;

			//while (counter < 10)
			//{
			//	Console.WriteLine(counter * 10);
			//	break;
			//}

			//int counter = 10;

			//while (counter < 10)
			//{
			//	Console.WriteLine(counter);
			//	counter++;
			//}

			//for (int i = 0; i < 10; i++)
			//{
			//	Console.WriteLine(i);

			//	if (i == 5)
			//	{
			//		break;
			//	}			
			//}

			int counter = 0;

			while (counter < 10)
			{
				counter++;
				Console.WriteLine(counter);

				if (counter < 4) continue;
				Console.WriteLine(counter * 4);

			}


		}
	}
}
