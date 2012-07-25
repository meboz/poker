using System.Text.RegularExpressions;

namespace poker
{
	public class TexasHoldemStraightFlushIdentifier : ITexasHoldemHandIdentifier
	{
		public bool IsHandOfThisType(Hand hand)
		{
			return new Regex("(2345A|23456|34567|45678|56789|6789T|789TJ|89TJQ|9TJQK)(DDDDD|SSSSS|CCCCC|HHHHH)").IsMatch(hand.ValuesThenSuitsDescription);
		}


		public TexasHoldemHand IdentifiedHand
		{
			get { return TexasHoldemHand.StraightFlush;  }
		}
	}
}