using System.Linq;

namespace poker
{
	public class TexasHoldemOnePairIdentifier : ITexasHoldemHandIdentifier
	{
		public bool IsHandOfThisType(Hand hand)
		{
			if (hand.HasAllTheSameSuit)
				return false;

			return hand.NumberOfPairs == 1;
		}

		public TexasHoldemHand IdentifiedHand
		{
			get { return TexasHoldemHand.OnePair; }
		}
	}
}