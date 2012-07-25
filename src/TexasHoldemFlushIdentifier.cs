using System.Linq;

namespace poker
{
	public class TexasHoldemFlushIdentifier : ITexasHoldemHandIdentifier
	{

		public bool IsHandOfThisType(Hand hand)
		{
			var royalFlushIdentifier = new TexasHoldemRoyalFlushIdentifier();
			if (royalFlushIdentifier.IsHandOfThisType(hand))
				return false;

			var fourOfAKindIdentifier = new TexasHoldemFourOfAKindIdentifier();
			if (fourOfAKindIdentifier.IsHandOfThisType(hand))
				return false;

			return hand.HasAllTheSameSuit;
		}

		public TexasHoldemHand IdentifiedHand
		{
			get { return TexasHoldemHand.Flush; }
		}
	}
}