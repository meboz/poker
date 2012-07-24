using System;
using System.Collections.Generic;
using System.Linq;
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
		[TestCase(1)]
		[TestCase(0)]
		[TestCase(13)]
		public void a_cards_value_should_be_within_0_and_13(int inputValue)
		{
			var card = new Card(Suit.Spades, inputValue);
		}
	}
}
