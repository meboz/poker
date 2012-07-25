using System.Text.RegularExpressions;

namespace poker
{
	public class TexasHoldemRoyalFlushIdentifier : ITexasHoldemHandIdentifier
	{
		public bool IsHandOfThisType(Hand hand)
		{
			string hand1 = hand.ValuesThenSuitsDescription;
			//check its not a straight flush
			var straighFlushIdentier = new TexasHoldemStraightFlushIdentifier();
			if (new Regex("(2345A|23456|34567|45678|56789|6789T|789TJ|89TJQ|9TJQK)(DDDDD|SSSSS|CCCCC|HHHHH)").IsMatch(hand1))
				return false;

			return new Regex("(TJQKA)(DDDDD|SSSSS|CCCCC|HHHHH)").IsMatch(hand1);
		}


		public TexasHoldemHand IdentifiedHand
		{
			get { return TexasHoldemHand.RoyalFlush; }
		}
	}
}