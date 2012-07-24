using System.Linq;

namespace poker
{
	public class TexasHoldemFlushIdentifier : ITexasHoldemHandIdentifier
	{
		public bool IsHandOfThisType(string hand)
		{
			var groups = hand.Substring(5, 5).GroupBy(c => c);
			return groups.Count() == 1;
		}

		public TexasHoldemHand IdentifiedHand
		{
			get { return TexasHoldemHand.Flush; }
		}
	}
}