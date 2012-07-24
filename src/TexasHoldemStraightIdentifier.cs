using System.Text.RegularExpressions;

namespace poker
{
	public class TexasHoldemStraightIdentifier : ITexasHoldemHandIdentifier
	{
		public bool IsHandOfThisType(string hand)
		{
			var straightFlushIdentifier = new TexasHoldemStraightFlushIdentifier();
			if (straightFlushIdentifier.IsHandOfThisType(hand))
				return false;
			return new Regex("(A2345|23456|34567|45678|56789|6789T|789TJ|89TJQ|9TJQK)").IsMatch(hand);
		}

		public TexasHoldemHand IdentifiedHand
		{
			get { return TexasHoldemHand.Straight; }
		}
	}
}