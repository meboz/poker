using System.Text.RegularExpressions;

namespace poker
{
	public class TexasHoldemRoyalFlushIdentifier : ITexasHoldemHandIdentifier
	{
		public bool IsHandOfThisType(string hand)
		{
			return new Regex("(TJQKA)(DDDDD|SSSSS|CCCCC|HHHHH)").IsMatch(hand);
		}

		public TexasHoldemHand IdentifiedHand
		{
			get { return TexasHoldemHand.RoyalFlush; }
		}
	}
}