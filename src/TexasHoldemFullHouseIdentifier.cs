using System.Linq;

namespace poker
{
	public class TexasHoldemFullHouseIdentifier : ITexasHoldemHandIdentifier
	{
		public bool IsHandOfThisType(Hand hand)
		{
			var desc = hand.ValuesThenSuitsDescription;
			var groups = desc.Substring(0, 5).GroupBy(c => c);
			return groups.Count() == 2;
		}


		public TexasHoldemHand IdentifiedHand
		{
			get { return TexasHoldemHand.FullHouse; }
		}
	}
}