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
		[TestCase(14, ExpectedException = typeof(ArgumentOutOfRangeException))]
		[TestCase(0, ExpectedException = typeof(ArgumentOutOfRangeException))]
		[TestCase(1)]
		[TestCase(13)]
		public void a_cards_value_should_be_within_1_and_13(int inputValue)
		{
			var card = new Card(Suit.Spades, inputValue);
		}

		[Test]
		public void cards_are_the_same_if_their_value_and_suit_is_the_same()
		{
			var card1 = new Card(Suit.Spades, 1);
			var card2 = new Card(Suit.Spades, 1);

			card1.ShouldEqual(card2);
		}

		[Test]
		public void cards_are_different_if_their_suit_is_different()
		{
			var card1 = new Card(Suit.Spades, 1);
			var card2 = new Card(Suit.Hearts, 1);

			card1.ShouldNotEqual(card2);
		}

		[Test]
		public void cards_are_different_if_their_value_is_different()
		{
			var card1 = new Card(Suit.Spades, 1);
			var card2 = new Card(Suit.Spades, 2);

			card1.ShouldNotEqual(card2);
		}

	}
}
