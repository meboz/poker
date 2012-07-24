using System;
using NUnit.Framework;
using SharpArch.Testing.NUnit;

namespace poker.tests
{
	[TestFixture]
	public class IndividualHandIdentifierTests
	{
		[TestCase("TJQKASSSSS",typeof(TexasHoldemRoyalFlushIdentifier),true, TexasHoldemHand.RoyalFlush)]
		[TestCase("TJQKASSSSS",typeof(TexasHoldemFlushIdentifier),false, TexasHoldemHand.RoyalFlush)]
		[TestCase("TJQKASSSSS",typeof(TexasHoldemStraightFlushIdentifier),false, TexasHoldemHand.RoyalFlush)]
		[TestCase("TJQKASSSSS",typeof(TexasHoldemStraightIdentifier),false, TexasHoldemHand.RoyalFlush)]
		[TestCase("56789SSSSS",typeof(TexasHoldemStraightFlushIdentifier),true, TexasHoldemHand.StraightFlush)]
		[TestCase("56789SSSSS",typeof(TexasHoldemRoyalFlushIdentifier),false, TexasHoldemHand.StraightFlush)]
		[TestCase("44447SSSSS",typeof(TexasHoldemFourOfAKindIdentifier),true, TexasHoldemHand.FourOfAKind)]
		[TestCase("4TTTTDDDDD",typeof(TexasHoldemFourOfAKindIdentifier),true, TexasHoldemHand.FourOfAKind)]
		[TestCase("44TTTDDDDD",typeof(TexasHoldemFullHouseIdentifier),true, TexasHoldemHand.FullHouse)]
		[TestCase("444TTDDDDD",typeof(TexasHoldemFullHouseIdentifier),true, TexasHoldemHand.FullHouse)]
		[TestCase("445TTDDDDD",typeof(TexasHoldemFlushIdentifier),true, TexasHoldemHand.Flush)]
		[TestCase("34567DDDDS",typeof(TexasHoldemStraightIdentifier),true, TexasHoldemHand.Straight)]
		[TestCase("45678DDDDD",typeof(TexasHoldemStraightIdentifier),false, TexasHoldemHand.StraightFlush)]
		[TestCase("A2345CCCCC",typeof(TexasHoldemStraightIdentifier),false, TexasHoldemHand.StraightFlush)]
		[TestCase("A2345CCCCC",typeof(TexasHoldemStraightFlushIdentifier),true, TexasHoldemHand.StraightFlush)]
		[TestCase("222A4CCCCC",typeof(TexasHoldemThreeOfAKindIdentifier),false, TexasHoldemHand.Flush)]
		[TestCase("222A4CCCCS",typeof(TexasHoldemThreeOfAKindIdentifier),true, TexasHoldemHand.ThreeOfAKind)]
		[TestCase("24555CCCCS",typeof(TexasHoldemThreeOfAKindIdentifier),true, TexasHoldemHand.ThreeOfAKind)]
		[TestCase("22335CCCCS",typeof(TexasHoldemTwoPairIdentifier),true, TexasHoldemHand.TwoPair)]
		[TestCase("23355CCCCS",typeof(TexasHoldemTwoPairIdentifier),true, TexasHoldemHand.TwoPair)]
		[TestCase("23355CCCCC",typeof(TexasHoldemTwoPairIdentifier),false, TexasHoldemHand.Flush)]
		[TestCase("22346CCCSS",typeof(TexasHoldemOnePairIdentifier),true, TexasHoldemHand.OnePair)]
		[TestCase("378TTCCCSS",typeof(TexasHoldemOnePairIdentifier),true, TexasHoldemHand.OnePair)]
		public void should_be_able_to_identify_if_hand_satifies_the_condition(string hand, Type identifierType, bool isSatified, TexasHoldemHand expectedHand)
		{
			var handIdentifier = (ITexasHoldemHandIdentifier)Activator.CreateInstance(identifierType);
			
			handIdentifier.IsHandOfThisType(hand).ShouldEqual(isSatified);
			
			//what is the hand?
			var texasHoldemIdentifier = new TexasHoldemHandIdentifier();
			var identifiedHand = TexasHoldemHand.HighCard;

			foreach (var identifier in texasHoldemIdentifier.HandIndentifiers)
			{
				if (identifier.IsHandOfThisType(hand))
				{
					identifiedHand = identifier.IdentifiedHand;
					break;
				}
			}

			identifiedHand.ShouldEqual(expectedHand);
		}

		[TestCase(typeof(TexasHoldemRoyalFlushIdentifier), TexasHoldemHand.RoyalFlush)]
		[TestCase(typeof(TexasHoldemFlushIdentifier), TexasHoldemHand.Flush)]
		[TestCase(typeof(TexasHoldemFourOfAKindIdentifier), TexasHoldemHand.FourOfAKind)]
		[TestCase(typeof(TexasHoldemFullHouseIdentifier), TexasHoldemHand.FullHouse)]
		[TestCase(typeof(TexasHoldemStraightIdentifier), TexasHoldemHand.Straight)]
		[TestCase(typeof(TexasHoldemThreeOfAKindIdentifier), TexasHoldemHand.ThreeOfAKind)]
		public void identifiers_should_return_the_correct_hand_type(Type identifier, TexasHoldemHand identifiedHand)
		{
			var handIdentifier = (ITexasHoldemHandIdentifier)Activator.CreateInstance(identifier);
			handIdentifier.IdentifiedHand.ShouldEqual(identifiedHand);
		}
	}
}