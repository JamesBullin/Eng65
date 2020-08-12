using System;
using System.Diagnostics;

namespace Lab_10_DataTypes_Part2
{
	class Program
	{
		
		static void Main(string[] args)
		{

			
			




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
	public enum Suit
		{
			HEARTS, CLUBS, DIAMONDS, SPADES
		}

	}

	
}
