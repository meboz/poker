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

		public virtual Hand DealHand(int numberOfCardsToDeal)
		{
			var hand = new Hand();
			
			if(Cards.Count < numberOfCardsToDeal)
				throw new NeedToRefillTheShoeException();

			for (var i = 0; i < numberOfCardsToDeal; i++)
			{
				var randomCard = DealCard();
				hand.AddCard(randomCard);
			}

			return hand;
		}

		public virtual Card DealCard()
		{
			var randomCardNumberToPick = new Random().Next(0, Cards.Count);
			var card = Cards.ElementAt(randomCardNumberToPick);
			Cards.RemoveAt(randomCardNumberToPick);
			return card;
		}
	}
}