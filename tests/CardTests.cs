using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SharpArch.Testing.NUnit;

namespace poker.tests
{
	[TestFixture]
	public class CardTests
	{
		[Test]
		public void a_card_has_a_suit()
		{
			var card = new Card(Suit.Spades, 2);
			card.Suit.ShouldEqual(Suit.Spades);
		}

		[TestCase(-1, ExpectedException = typeof(ArgumentOutOfRangeException))]
		[TestCase(0, ExpectedException = typeof(ArgumentOutOfRangeException))]
		[TestCase(1, ExpectedException = typeof(ArgumentOutOfRangeException))]
		[TestCase(2)]
		[TestCase(14)]
		public void a_cards_value_should_be_within_2_and_14(int inputValue)
		{
			var card = new Card(Suit.Spades, inputValue);
		}

		[Test]
		public void cards_are_the_same_if_their_value_and_suit_is_the_same()
		{
			var card1 = new Card(Suit.Spades, 2);
			var card2 = new Card(Suit.Spades, 2);

			card1.ShouldEqual(card2);
		}

		[Test]
		public void cards_are_different_if_their_suit_is_different()
		{
			var card1 = new Card(Suit.Spades, 2);
			var card2 = new Card(Suit.Hearts, 2);

			card1.ShouldNotEqual(card2);
		}

		[Test]
		public void cards_are_different_if_their_value_is_different()
		{
			var card1 = new Card(Suit.Spades, 2);
			var card2 = new Card(Suit.Spades, 3);

			card1.ShouldNotEqual(card2);
		}

		[TestCase(Suit.Hearts,2, "2H")]
		[TestCase(Suit.Spades,5, "5S")]
		[TestCase(Suit.Diamonds,10, "TD")]
		[TestCase(Suit.Clubs,6, "6C")]
		[TestCase(Suit.Clubs,11, "JC")]
		[TestCase(Suit.Clubs,12, "QC")]
		[TestCase(Suit.Clubs,14, "AC")]
		public void card_has_a_readable_description(Suit suit, int value, string expectedDescription)
		{
			var card = new Card(suit, value);
			card.Description.ShouldEqual(expectedDescription);
		}
	}
}
