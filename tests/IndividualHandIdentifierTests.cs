using System;
using NUnit.Framework;
using SharpArch.Testing.NUnit;

namespace poker.tests
{
	[TestFixture]
	public class IndividualHandIdentifierTests
	{
		[TestCase("TJQKASSSSS",typeof(TexasHoldemRoyalFlushIdentifier),true, TexasHoldemHand.RoyalFlush)]
		[TestCase("TJQKASSSSS",typeof(TexasHoldemFlushIdentifier),false, TexasHoldemHand.Flush)]
		[TestCase("TJQKASSSSS",typeof(TexasHoldemStraightFlushIdentifier),false, TexasHoldemHand.StraightFlush)]
		[TestCase("56789SSSSS",typeof(TexasHoldemStraightFlushIdentifier),true, TexasHoldemHand.StraightFlush)]
		[TestCase("56789SSSSS",typeof(TexasHoldemRoyalFlushIdentifier),false, TexasHoldemHand.RoyalFlush)]
		[TestCase("44447SSSSS",typeof(TexasHoldemFourOfAKindIdentifier),true, TexasHoldemHand.FourOfAKind)]
		[TestCase("4TTTTDDDDD",typeof(TexasHoldemFourOfAKindIdentifier),true, TexasHoldemHand.FourOfAKind)]
		[TestCase("44TTTDDDDD",typeof(TexasHoldemFullHouseIdentifier),true, TexasHoldemHand.FullHouse)]
		[TestCase("444TTDDDDD",typeof(TexasHoldemFullHouseIdentifier),true, TexasHoldemHand.FullHouse)]
		[TestCase("445TTDDDDD",typeof(TexasHoldemFlushIdentifier),true, TexasHoldemHand.Flush)]
		public void should_be_able_to_identify_if_hand_satifies_the_condition(string hand, Type identifierType, bool isSatified, TexasHoldemHand identifiedType)
		{
			var handIdentifier = (ITexasHoldemHandIdentifier)Activator.CreateInstance(identifierType);
			
			handIdentifier.IsHandOfThisType(hand).ShouldEqual(isSatified);
			handIdentifier.IdentifiedHand.ShouldEqual(identifiedType);
		}
	}
}