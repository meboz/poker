using System;
using poker.tests;

namespace poker
{
	public class Card
	{
		public Suit Suit { get; set; }
		public int Value { get; set; }
		public Card(Suit suit, int value)
		{
			if(value < 1 || value > 13)
				throw new ArgumentOutOfRangeException("value should be between 0 and 13");

			Suit = suit;
			Value = value;
		}


		public bool Equals(Card other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Equals(other.Suit, Suit) && other.Value == Value;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof (Card)) return false;
			return Equals((Card) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (Suit.GetHashCode()*397) ^ Value;
			}
		}
	}
}