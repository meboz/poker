using System.Linq;
using System.Text.RegularExpressions;

namespace poker
{
	public class TexasHoldemThreeOfAKindIdentifier : ITexasHoldemHandIdentifier
	{
		public bool IsHandOfThisType(Hand hand)
		{
			return hand.HasTriples && hand.NumberOfPairs == 0 && !hand.HasAllTheSameSuit;
		}

		public TexasHoldemHand IdentifiedHand
		{
			get { return TexasHoldemHand.ThreeOfAKind; }
		}
	}
}