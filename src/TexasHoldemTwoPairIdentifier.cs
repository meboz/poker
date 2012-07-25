using System.Linq;

namespace poker
{
	public class TexasHoldemTwoPairIdentifier : ITexasHoldemHandIdentifier
	{
		public bool IsHandOfThisType(Hand hand)
		{
			if (hand.HasAllTheSameSuit)
				return false;
			
			return hand.NumberOfPairs == 2;
		}

		public TexasHoldemHand IdentifiedHand
		{
			get { return TexasHoldemHand.TwoPair; }
		}
	}
}