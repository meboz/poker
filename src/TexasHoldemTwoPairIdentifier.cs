using System.Linq;

namespace poker
{
	public class TexasHoldemTwoPairIdentifier : ITexasHoldemHandIdentifier
	{
		public bool IsHandOfThisType(string hand)
		{
			var valueGroups = hand.Substring(0, 5).GroupBy(c => c);
			var suitGroups = hand.Substring(5, 5).GroupBy(c => c);

			//this is starting to get hairy, but its isolated and can be tested and refactored easily
			return valueGroups.Count() == 3 && suitGroups.Count() > 1 && valueGroups.Where(g => g.Count() == 2).Count() == 2;
		}

		public TexasHoldemHand IdentifiedHand
		{
			get { return TexasHoldemHand.TwoPair; }
		}
	}

	public class TexasHoldemOnePairIdentifier : ITexasHoldemHandIdentifier
	{
		public bool IsHandOfThisType(string hand)
		{
			var valueGroups = hand.Substring(0, 5).GroupBy(c => c);
			var suitGroups = hand.Substring(5, 5).GroupBy(c => c);

			//this is starting to get hairy, but its isolated and can be tested and refactored easily
			return valueGroups.Count() == 4 && suitGroups.Count() > 1 && valueGroups.Where(g => g.Count() == 2).Count() == 1;
		}

		public TexasHoldemHand IdentifiedHand
		{
			get { return TexasHoldemHand.OnePair; }
		}
	}

}