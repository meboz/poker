using System.Linq;
using System.Text.RegularExpressions;

namespace poker
{
	public class TexasHoldemThreeOfAKindIdentifier : ITexasHoldemHandIdentifier
	{
		public bool IsHandOfThisType(Hand hand)
		{
			string hand1 = hand.ValuesThenSuitsDescription;
			var valueGroups = hand1.Substring(0, 5).GroupBy(c => c);
			var suitGroups = hand1.Substring(5, 5).GroupBy(c => c);
			
			return valueGroups.Count() == 3 && suitGroups.Count() > 1 && valueGroups.Max(g => g.Count()) == 3;
		}

		public TexasHoldemHand IdentifiedHand
		{
			get { return TexasHoldemHand.ThreeOfAKind; }
		}
	}
}