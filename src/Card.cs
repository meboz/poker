using System;
using System.Collections.Generic;
using poker.tests;

namespace poker
{
	public class Card
	{
		public Suit Suit { get; set; }
		public int Value { get; set; }
		public Card(Suit suit, int value)
		{
			if(value < 2 || value > 14)
				throw new ArgumentOutOfRangeException("value should be between 0 and 13");

			Suit = suit;
			Value = value;
		}

		public virtual string Description
		{
			get
			{
				var royalMap = new Dictionary<int, string>()
				               	{
									{10,"T"},
									{11,"J"},
									{12,"Q"},
									{13,"K"},
									{14, "A"}
				               	};

				if(Value > 9)
					return royalMap[Value] + Suit.ToString()[0];

				return Value.ToString() + Suit.ToString()[0];
			}
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