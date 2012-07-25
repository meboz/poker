using System.Text.RegularExpressions;

namespace poker
{
	public class TexasHoldemRoyalFlushIdentifier : ITexasHoldemHandIdentifier
	{
		public bool IsHandOfThisType(string hand)
		{
			//check its not a straight flush
			var straighFlushIdentier = new TexasHoldemStraightFlushIdentifier();
			if (straighFlushIdentier.IsHandOfThisType(hand))
				return false;

			return new Regex("(TJQKA)(DDDDD|SSSSS|CCCCC|HHHHH)").IsMatch(hand);
		}


		public TexasHoldemHand IdentifiedHand
		{
			get { return TexasHoldemHand.RoyalFlush; }
		}
	}
}