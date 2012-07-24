using System;
using System.Collections.Generic;
using poker.tests;
using System.Linq;

namespace poker
{
	public class NeedToRefillTheShowException : Exception
	{
		
	}

	public class DeckOfCards
	{
		public List<Card> Cards { get; set; }

		public DeckOfCards()
		{
			Cards = new List<Card>();

			foreach (var value in Enum.GetValues(typeof(Suit)))
			{
				for (var i = 1; i < 14; i++)
					Cards.Add(new Card((Suit)value, i));
			}
			
		}

		public Card[] DealHand(int i)
		{
			var hand = new List<Card>();
			if(Cards.Count < i)
				throw new NeedToRefillTheShowException();


			for (var j = 0; j < i; j++)
			{
				var cardIndexToPick = new Random().Next(0, Cards.Count);
				hand.Add(Cards.ElementAt(cardIndexToPick));
				Cards.RemoveAt(cardIndexToPick);
			}

			return hand.ToArray();
		}
	}
}