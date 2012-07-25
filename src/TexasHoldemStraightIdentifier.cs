using System.Text.RegularExpressions;

namespace poker
{
	public class TexasHoldemStraightIdentifier : ITexasHoldemHandIdentifier
	{
		public bool IsHandOfThisType(Hand hand)
		{
			string hand1 = hand.ValuesThenSuitsDescription;
			var straightFlushIdentifier = new TexasHoldemStraightFlushIdentifier();
			if (straightFlushIdentifier.IsHandOfThisType(hand))
				return false;
			return new Regex("(2345A|23456|34567|45678|56789|6789T|789TJ|89TJQ|9TJQK)").IsMatch(hand1);
		}

		public TexasHoldemHand IdentifiedHand
		{
			get { return TexasHoldemHand.Straight; }
		}
	}
}