using System;

namespace poker.tests
{
	public class Card
	{
		public Suit Suit { get; set; }
		public int Value { get; set; }
		public Card(Suit suit, int value)
		{
			if(value < 0 || value > 13)
				throw new ArgumentOutOfRangeException("value should be between 0 and 13");

			Suit = suit;
			Value = value;
		}

	}
}