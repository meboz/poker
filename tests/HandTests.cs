using System;
using NUnit.Framework;
using SharpArch.Testing.NUnit;

namespace poker.tests
{
	[TestFixture]
	public class HandTests
	{
		[Test]
		public void new_hand_should_have_empty_set_of_cards()
		{
			var hand = new Hand();
			hand.Cards.ShouldNotBeNull();
		}

		[Test]
		public void should_add_card_to_hand()
		{
			var hand = new Hand();
			hand.AddCard(new Card(Suit.Spades, 1));

			hand.Cards.Count.ShouldEqual(1);
		}

		[Test]
		public void should_not_fail_if_card_is_added_when_cards_a_null()
		{
			var hand = new Hand();
			hand.Cards = null;

			hand.AddCard(new Card(Suit.Spades, 1));

			hand.Cards.Count.ShouldEqual(1);

		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void should_provide_a_card_when_adding_to_hand()
		{
			var hand = new Hand();
			hand.AddCard(null);
		}
	}
}