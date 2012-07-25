using System.Text.RegularExpressions;

namespace poker
{
	public class TexasHoldemFourOfAKindIdentifier : ITexasHoldemHandIdentifier
	{
		public bool IsHandOfThisType(Hand hand)
		{
			var desc = hand.ValuesThenSuitsDescription;
			return new Regex("(2222|3333|4444|5555|6666|7777|8888|9999|TTTT|JJJJ|QQQQ|KKKK|AAAA)").IsMatch(desc);
		}

		public TexasHoldemHand IdentifiedHand
		{
			get { return TexasHoldemHand.FourOfAKind; }
		}
	}
}