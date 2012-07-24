using System;
using NUnit.Framework;
using SharpArch.Testing.NUnit;

namespace poker.tests
{
	[TestFixture]
	public class SimpleTexasHoldemGamesTests
	{
		[Test]
		[Explicit("Run this test explicitly and have a look at the console output")]
		public void output_some_dealt_hands_and_their_identified_texas_holdem_types()
		{
			var game = new SimpleTexasHoldemGame();

			for(var i = 1; i <= 100;i++)
			{
				var hand = game.DealHand();
				var message = string.Format("Hand {0}: {1} - {2} ({3})", i, hand.Description, game.IdentifyHand(hand),hand.ValuesThenSuitsDescription);
				Console.WriteLine(message);
			}

			Assert.Fail("Show the output in the resharper console");
		}

		[Test]
		[Explicit("This test will rarely break, but it can, it's more of a sanity check on randomness")]
		public void should_get_a_royal_flush_at_some_point()
		{
			var hasRoyalFlush = false;
			var game = new SimpleTexasHoldemGame();

			for (var i = 1; i <= 1000; i++)
			{
				var hand = game.DealHand();
				hasRoyalFlush = game.IdentifyHand(hand) == TexasHoldemHand.RoyalFlush;


				if (hasRoyalFlush)
					break;
			}

			hasRoyalFlush.ShouldEqual(true);
		}
	}
}