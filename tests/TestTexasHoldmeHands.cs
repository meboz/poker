using System;
using NUnit.Framework;
using SharpArch.Testing.NUnit;

namespace poker.tests
{
	[TestFixture]
	public class TestTexasHoldmeHands
	{
		[TestCase("TJQKASSSSS",TexasHoldemHand.RoyalFlush)]
		[TestCase("56789SSSSS",TexasHoldemHand.StraightFlush)]
		[TestCase("44447SSSSS",TexasHoldemHand.FourOfAKind)]
		[TestCase("4TTTTDDDDD",TexasHoldemHand.FourOfAKind)]
		[TestCase("44TTTDDDDD",TexasHoldemHand.FullHouse)]
		[TestCase("444TTDDDDD",TexasHoldemHand.FullHouse)]
		public void can_test_for_royal_flush(string handDescription, TexasHoldemHand texasHoldemHandType)
		{
			var handIdentifier = new TexasHoldemHandIdentifier();
			var handType = handIdentifier.Identify(handDescription);
			handType.ShouldEqual(texasHoldemHandType);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void should_pass_a_non_null_hand()
		{
			var handIdentifier = new TexasHoldemHandIdentifier();
			handIdentifier.Identify(null);
		}

		[TestCase("",ExpectedException = typeof(Exception))]
		[TestCase("3 3 3",ExpectedException = typeof(Exception))]
		[TestCase("3h4h5h",ExpectedException = typeof(Exception))]
		[TestCase("3h 4h 5h",ExpectedException = typeof(Exception))]
		public void should_pass_the_identifier_a_valid_hand(string handDescription)
		{
			var handIdentifier = new TexasHoldemHandIdentifier();
			handIdentifier.Identify(handDescription);
		}
	}
}