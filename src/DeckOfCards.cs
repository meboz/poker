using System;
using System.Collections.Generic;
using poker.tests;

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
	}
}