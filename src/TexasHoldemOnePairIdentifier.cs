using System.Linq;

namespace poker
{
	public class TexasHoldemOnePairIdentifier : ITexasHoldemHandIdentifier
	{
		public bool IsHandOfThisType(Hand hand)
		{
			string hand1 = hand.ValuesThenSuitsDescription;
			var valueGroups = hand1.Substring(0, 5).GroupBy(c => c);
			var suitGroups = hand1.Substring(5, 5).GroupBy(c => c);

			//this is starting to get hairy, but its isolated and can be tested and refactored easily
			return valueGroups.Count() == 4 && suitGroups.Count() > 1 && valueGroups.Where(g => g.Count() == 2).Count() == 1;
		}

		public TexasHoldemHand IdentifiedHand
		{
			get { return TexasHoldemHand.OnePair; }
		}
	}
}