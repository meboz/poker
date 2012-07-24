using System.Text.RegularExpressions;

namespace poker
{
	public class StraightFlushInspector : ITexasHoldemHandInspector
	{
		public bool Inspect(string hand)
		{
			return new Regex("(23456|34567|45678|56789|6789T|789TJ|89TJQ|9TJQK)(DDDDD|SSSSS|CCCCC|HHHHH)").IsMatch(hand);
		}
	}
}