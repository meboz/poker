using System.Linq;
using NUnit.Framework;
using SharpArch.Testing.NUnit;

namespace poker.tests
{
	[TestFixture]
	public class DeckTests
	{
		[Test]
		public void should_have_52_cards()
		{
			var deck = new DeckOfCards();
			deck.Cards.Count().ShouldEqual(52);

			deck.Cards[0].Suit.ShouldEqual(Suit.Hearts);
			deck.Cards[13].Suit.ShouldEqual(Suit.Diamonds);
			deck.Cards[26].Suit.ShouldEqual(Suit.Clubs);
			deck.Cards[39].Suit.ShouldEqual(Suit.Spades);
		}
	}
}