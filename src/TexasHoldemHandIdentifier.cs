using System;
using System.Collections.Generic;

namespace poker
{
	public class TexasHoldemHandIdentifier
	{
		public virtual List<ITexasHoldemHandIdentifier> HandIndentifiers { get; set; }

		public virtual TexasHoldemHand Identify(string handDescription)
		{

			if(handDescription == null)
				throw new ArgumentNullException("handDescription");
			
			if(handDescription.Length != 10)
				throw new Exception(string.Format("Not a valid texas holdem hand. Expected 5 cards but got [{0}]", handDescription));

			if (HandIndentifiers == null)
				throw new ArgumentNullException("HandIdentifiers");

			var identifiedHand = IdentifyHand(handDescription);
			return identifiedHand;
		}

		public virtual TexasHoldemHand IdentifyHand(string handDescription)
		{
			var identifiedHand = TexasHoldemHand.HighCard;

			foreach (var identifier in HandIndentifiers)
			{
				if (identifier.IsHandOfThisType(handDescription))
				{
					identifiedHand = identifier.IdentifiedHand;
					break;
				}
			}

			return identifiedHand;
		}
	}
}