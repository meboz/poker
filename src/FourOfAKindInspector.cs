using System.Text.RegularExpressions;

namespace poker
{
	public class FourOfAKindInspector : ITexasHoldemHandInspector
	{
		public bool Inspect(string hand)
		{
			return new Regex("(2222|3333|4444|5555|6666|7777|8888|9999|TTTT|JJJJ|QQQQ|KKKK|AAAA)").IsMatch(hand);
		}
	}
}