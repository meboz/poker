using System.Text.RegularExpressions;

namespace poker
{
	public class TexasHoldemStraightFlushIdentifier : ITexasHoldemHandIdentifier
	{
		public bool IsHandOfThisType(string hand)
		{
			return new Regex("(A2345|23456|34567|45678|56789|6789T|789TJ|89TJQ|9TJQK)(DDDDD|SSSSS|CCCCC|HHHHH)").IsMatch(hand);
		}


		public TexasHoldemHand IdentifiedHand
		{
			get { return TexasHoldemHand.StraightFlush;  }
		}
	}
}