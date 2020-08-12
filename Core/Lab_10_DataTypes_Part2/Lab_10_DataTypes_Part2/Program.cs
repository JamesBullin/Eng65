using System;
using System.Diagnostics;

namespace Lab_10_DataTypes_Part2
{
		class Program
	{

		static void Main(string[] args)
		{


			////new date object mapped to midnight, 1 january 0001
			//var d = new DateTime();
			//var d1 = DateTime.Today;
			////now
			//var d2 = DateTime.Now;

			////literal date

			//var d3 = new DateTime(2020, 7, 12, 10, 5, 18);

			///add month and days
			//d = d.AddDays(1);
			//d = d.AddMonths(1);

			////formatting dates

			//var output = DateTime.Now.ToString("dd-MM-yyyy");
			//var output2 = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

			//Console.WriteLine(output);
			//Console.WriteLine(output2);

			//var date = new DateTime(1989, 11, 02);

			//var date2 = date.ToString("yyyy/dd/MMM");


			////1 hour timespan
			//var timespan = new TimeSpan(1, 0, 0);
			////add this to time right now
			//var date = DateTime.Now + timespan;
			////add one tick to our date!
			//var tick = new TimeSpan(1);
			//date = date + tick;

			//var s = new Stopwatch();

			//s.Start();
			//int total = 0;

			//for (int i = 0; i < Int32.MaxValue; i++)
			//{
			//	total += i;
			//}

			//s.Stop();

			//Console.WriteLine(s.Elapsed);
			//Console.WriteLine(s.ElapsedMilliseconds);
			//Console.WriteLine(s.ElapsedTicks);

			//Suit theSuit = Suit.HEARTS;

			////Console.WriteLine(theSuit);

			////Suits(theSuit);

			//int intSuit = (int)theSuit;

			//Suit aSuit = (Suit)1;

			//Console.WriteLine($"Sunday as a number is {(int)DayOfWeek.Sunday}");

			//bool? hasPassed = true;
			//if (hasPassed.HasValue)
			//{
			//	Console.WriteLine("Congrats");
			//}

			//hasPassed = null;

			//if (hasPassed.HasValue)
			//{
			//	Console.WriteLine("Congrats");
			//}

			//Console.WriteLine("hasPassed is null");

			//int totalCost = 0;
			//int price = 1;
			//int? items = 0;

			//if (items.HasValue)
			//{
			//	totalCost = items.Value * price;
			//	Console.WriteLine("item has value");
			//}

			//Console.WriteLine(totalCost);

			//int? nullableScore = null;
			//int score = nullableScore ?? -9999;
			//int score1 = nullableScore.GetValueOrDefault(-1);
			//int score2 = nullableScore.GetValueOrDefault();

			//int dozen = 12;

			//dozen = 11; 

			//dynamic item = 100;

			//Console.WriteLine($"adding 10 to {item} gives you {item + 10}");

			//item = "Nish";

			//Console.WriteLine($"adding 10 to {item} gives you {item + 10}");

			//var rollTheDice = new Random();
			//Console.WriteLine(rollTheDice.Next(1, 6));
			//Console.WriteLine(rollTheDice.Next(1, 6));
			//Console.WriteLine(rollTheDice.Next(1, 6));

			var rngUnseeded = new Random();
			var rngSeeded = new Random(42);
			var rngSeeded1 = new Random(42);

			var between1And10noSeed = rngUnseeded.Next(1, 11);
			var between1And10Seeded = rngSeeded.Next(1, 11);
			var between1And10Seeded1 = rngSeeded.Next(1, 11);

			Console.WriteLine(between1And10noSeed);
			Console.WriteLine(between1And10Seeded);
			Console.WriteLine(between1And10Seeded1);
		}

		public enum Suit
		{
			HEARTS, CLUBS, DIAMONDS, SPADES
		}

		public static void Suits(Suit suit)
		{
			switch (suit)
			{
				case (Suit.HEARTS):
					Console.WriteLine("Heart");
					break;
				case (Suit.CLUBS):
					Console.WriteLine("Club");
					break;
				case (Suit.DIAMONDS):
					Console.WriteLine("Diamond");
					break;
				case (Suit.SPADES):
					Console.WriteLine("Spade");
					break;
			}

		}

	}
}

