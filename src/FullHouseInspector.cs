using System.Linq;

namespace poker
{
	public class FullHouseInspector : ITexasHoldemHandInspector
	{
		public bool Inspect(string hand)
		{
			var groups = hand.Substring(0, 5).GroupBy(c => c);
			return groups.Count() == 2;
		}
	}
}