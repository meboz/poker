using System.Collections.Generic;

namespace poker
{
	public class SimpleTexasHoldemGame
	{
		private TexasHoldemHandIdentifier _identifier;
		//kept this private so we cant card count!!!
		private DeckOfCards _deckOfCards { get; set; }

		public SimpleTexasHoldemGame()
		{
			_deckOfCards = new DeckOfCards();
			_identifier = new TexasHoldemHandIdentifier();
		}

		public virtual Hand DealHand()
		{
			try
			{
				var hand = _deckOfCards.DealHand(5);
				return hand;
			}
			catch (NeedToRefillTheShoeException)
			{
				_deckOfCards = new DeckOfCards();
				return _deckOfCards.DealHand(5);
			}

		}

		public virtual TexasHoldemHand IdentifyHand(Hand hand)
		{
			return _identifier.Identify(hand.ValuesThenSuitsDescription);
		}
	}
}