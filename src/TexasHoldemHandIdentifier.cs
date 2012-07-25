using System;
using System.Collections.Generic;

namespace poker
{
	public class TexasHoldemHandIdentifier
	{
		public virtual List<ITexasHoldemHandIdentifier> HandIndentifiers { get; set; }

		public TexasHoldemHandIdentifier()
		{
			HandIndentifiers = new List<ITexasHoldemHandIdentifier>()
			                   	{
			                   		new TexasHoldemRoyalFlushIdentifier(),
			                   		new TexasHoldemStraightFlushIdentifier(),
			                   		new TexasHoldemFourOfAKindIdentifier(),
			                   		new TexasHoldemFullHouseIdentifier(),
			                   		new TexasHoldemFlushIdentifier(),
			                   		new TexasHoldemStraightIdentifier(),
			                   		new TexasHoldemThreeOfAKindIdentifier(),
			                   		new TexasHoldemTwoPairIdentifier(),
			                   		new TexasHoldemOnePairIdentifier(),
			                   	};
		}
		public virtual TexasHoldemHand Identify(Hand hand)
		{

			if(hand == null)
				throw new ArgumentNullException("hand");

			if (HandIndentifiers == null)
				throw new ArgumentNullException("HandIdentifiers");

			if(hand.Cards.Count != 5)
				throw new Exception(string.Format("Not a valid texas holdem hand. Expected 5 cards but got {0}", hand.Cards.Count));

			
			var identifiedHand = TexasHoldemHand.HighCard;

			foreach (var identifier in HandIndentifiers)
			{
				if (identifier.IsHandOfThisType(hand))
				{
					identifiedHand = identifier.IdentifiedHand;
					break;
				}
			}
			return identifiedHand;
		}
	}
}