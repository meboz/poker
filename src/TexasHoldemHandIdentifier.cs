using System;
using System.Collections.Generic;

namespace poker
{
	public class TexasHoldemHandIdentifier
	{
		public virtual TexasHoldemHand Identify(string handDescription)
		{
			var identifiedHand = TexasHoldemHand.HighCard;

			if(handDescription == null)
				throw new ArgumentNullException("handDescription");
			
			if(handDescription.Length != 10)
				throw new Exception(string.Format("Not a valid texas holdem hand. Expected 5 cards but got [{0}]", handDescription));

			var handPredicates = new Dictionary<TexasHoldemHand, ITexasHoldemHandInspector>()
			                	{
									{TexasHoldemHand.RoyalFlush, new RoyalFlushInspector()},
									{TexasHoldemHand.StraightFlush, new StraightFlushInspector()},
									{TexasHoldemHand.FourOfAKind, new FourOfAKindInspector()},
									{TexasHoldemHand.FullHouse, new FullHouseInspector()},
									{TexasHoldemHand.Flush, new FlushInspector()},

			                	};

			foreach (var predicate in handPredicates)
			{
				if(predicate.Value.Inspect(handDescription))
				{
					identifiedHand = predicate.Key;
					break;
				}
			}

			return identifiedHand;
		}
	}
}