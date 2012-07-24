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

		[Test]
		[ExpectedException(typeof(NeedToRefillTheShoeException))]
		public void should_throw_if_deck_doesnt_have_enough_cards()
		{
			var deck = new DeckOfCards();
			var hand = deck.DealHand(80);
		}

		[Test]
		public void should_get_the_right_number_of_cards_youve_requested()
		{
			var deck = new DeckOfCards();
			var hand = deck.DealHand(5);

			hand.Cards.Count.ShouldEqual(5);
		}

		[Test]
		public void should_remove_cards_from_deck_after_hand_is_dealt()
		{
			var deck = new DeckOfCards();
			var hand = deck.DealHand(5);

			deck.Cards.Count.ShouldEqual(47);

			var anotherHand = deck.DealHand(5);

			deck.Cards.Count.ShouldEqual(42);
		}

		[Test]
		public void range_of_values_in_hand_should_be_greater_than_number_of_cards()
		{
			var deck = new DeckOfCards();
			var hand = deck.DealHand(5);

			
		}
	}
}