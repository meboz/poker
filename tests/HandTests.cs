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
			hand.AddCard(new Card(Suit.Spades, 14));

			hand.Cards.Count.ShouldEqual(1);
		}

		[Test]
		public void should_not_fail_if_card_is_added_when_cards_a_null()
		{
			var hand = new Hand();
			hand.Cards = null;

			hand.AddCard(new Card(Suit.Spades, 14));

			hand.Cards.Count.ShouldEqual(1);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void should_provide_a_card_when_adding_to_hand()
		{
			var hand = new Hand();
			hand.AddCard(null);
		}

		[Test]
		public void should_have_a_description_in_value_order()
		{
			var hand = new Hand();
			hand.AddCard(new Card(Suit.Clubs, 3));
			hand.AddCard(new Card(Suit.Spades, 5));
			hand.AddCard(new Card(Suit.Diamonds, 14));
			hand.AddCard(new Card(Suit.Clubs, 10));

			hand.Description.ShouldEqual("3C 5S AD TC");
			hand.ValuesThenSuitsDescription.ShouldEqual("35TACSCD");
		}


		[Test]
		public void empty_hand_should_have_empty_description()
		{
			var hand = new Hand();
			hand.Description.ShouldEqual("");
			hand.ValuesThenSuitsDescription.ShouldEqual("");
			hand.Cards = null;
			hand.Description.ShouldEqual("");
			hand.ValuesThenSuitsDescription.ShouldEqual("");
		}
	}
}