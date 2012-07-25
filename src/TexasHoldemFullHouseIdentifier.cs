using System.Linq;

namespace poker
{
	public class TexasHoldemFullHouseIdentifier : ITexasHoldemHandIdentifier
	{
		public bool IsHandOfThisType(Hand hand)
		{
			return hand.NumberOfPairs == 1 && hand.HasTriples;
		}


		public TexasHoldemHand IdentifiedHand
		{
			get { return TexasHoldemHand.FullHouse; }
		}
	}
}