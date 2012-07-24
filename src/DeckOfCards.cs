using System;
using System.Collections.Generic;
using poker.tests;
using System.Linq;

namespace poker
{
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

		public Hand DealHand(int i)
		{
			var hand = new Hand();
			
			if(Cards.Count < i)
				throw new NeedToRefillTheShoeException();

			for (var j = 0; j < i; j++)
			{
				var cardIndexToPick = new Random().Next(0, Cards.Count);
				hand.AddCard(Cards.ElementAt(cardIndexToPick));
				Cards.RemoveAt(cardIndexToPick);
			}

			return hand;
		}
	}
}