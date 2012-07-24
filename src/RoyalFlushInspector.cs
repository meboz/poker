using System.Text.RegularExpressions;

namespace poker
{
	public class RoyalFlushInspector : ITexasHoldemHandInspector
	{
		public bool Inspect(string hand)
		{
			return new Regex("(TJQKA)(DDDDD|SSSSS|CCCCC|HHHHH)").IsMatch(hand);
		}
	}
}