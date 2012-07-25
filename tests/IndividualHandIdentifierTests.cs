using System;
using System.Collections.Generic;
using NUnit.Framework;
using SharpArch.Testing.NUnit;
using System.Linq;

namespace poker.tests
{
	[TestFixture]
	public class IndividualHandIdentifierTests
	{
		[TestCase("TJQKASSSSS", typeof(TexasHoldemRoyalFlushIdentifier), true, TexasHoldemHand.RoyalFlush)]
		[TestCase("TJQKASSSSS", typeof(TexasHoldemFlushIdentifier), false, TexasHoldemHand.RoyalFlush)]
		[TestCase("TJQKASSSSS", typeof(TexasHoldemStraightFlushIdentifier), false, TexasHoldemHand.RoyalFlush)]
		[TestCase("TJQKASSSSS", typeof(TexasHoldemStraightIdentifier), false, TexasHoldemHand.RoyalFlush)]
		[TestCase("56789SSSSS", typeof(TexasHoldemStraightFlushIdentifier), true, TexasHoldemHand.StraightFlush)]
		[TestCase("56789SSSSS", typeof(TexasHoldemRoyalFlushIdentifier), false, TexasHoldemHand.StraightFlush)]
		[TestCase("44447SSSSS", typeof(TexasHoldemFourOfAKindIdentifier), true, TexasHoldemHand.FourOfAKind)]
		[TestCase("4TTTTDDDDD", typeof(TexasHoldemFourOfAKindIdentifier), true, TexasHoldemHand.FourOfAKind)]
		[TestCase("44TTTDDDDD", typeof(TexasHoldemFullHouseIdentifier), true, TexasHoldemHand.FullHouse)]
		[TestCase("444TTDDDDD", typeof(TexasHoldemFullHouseIdentifier), true, TexasHoldemHand.FullHouse)]
		[TestCase("445TTDDDDD", typeof(TexasHoldemFlushIdentifier), true, TexasHoldemHand.Flush)]
		[TestCase("34567DDDDS", typeof(TexasHoldemStraightIdentifier), true, TexasHoldemHand.Straight)]
		[TestCase("45678DDDDD", typeof(TexasHoldemStraightIdentifier), false, TexasHoldemHand.StraightFlush)]
		[TestCase("A2345CCCCC",typeof(TexasHoldemStraightIdentifier),false, TexasHoldemHand.StraightFlush)]
		[TestCase("A2345CCCCC", typeof(TexasHoldemStraightFlushIdentifier), true, TexasHoldemHand.StraightFlush)]
		[TestCase("222A4CCCCC", typeof(TexasHoldemThreeOfAKindIdentifier), false, TexasHoldemHand.Flush)]
		[TestCase("222A4CCCCS", typeof(TexasHoldemThreeOfAKindIdentifier), true, TexasHoldemHand.ThreeOfAKind)]
		[TestCase("24555CCCCS", typeof(TexasHoldemThreeOfAKindIdentifier), true, TexasHoldemHand.ThreeOfAKind)]
		[TestCase("22335CCCCS", typeof(TexasHoldemTwoPairIdentifier), true, TexasHoldemHand.TwoPair)]
		[TestCase("23355CCCCS", typeof(TexasHoldemTwoPairIdentifier), true, TexasHoldemHand.TwoPair)]
		[TestCase("23355CCCCC", typeof(TexasHoldemTwoPairIdentifier), false, TexasHoldemHand.Flush)]
		[TestCase("22346CCCSS", typeof(TexasHoldemOnePairIdentifier), true, TexasHoldemHand.OnePair)]
		[TestCase("378TTCCCSS", typeof(TexasHoldemOnePairIdentifier), true, TexasHoldemHand.OnePair)]
		public void should_be_able_to_identify_if_hand_satifies_the_condition(string handDescription, Type identifierType, bool isSatified, TexasHoldemHand expectedHand)
		{
			var handIdentifier = (ITexasHoldemHandIdentifier)Activator.CreateInstance(identifierType);
			var hand = GenerateHandFromDescription(handDescription);
			handIdentifier.IsHandOfThisType(hand).ShouldEqual(isSatified);
			
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

		[Test]
		public void can_reverse_engineer_a_hand()
		{
			var hand = GenerateHandFromDescription("2223TSSCCD");
			hand.Cards.Count.ShouldEqual(5);
			
			hand.Cards.ElementAt(0).Suit.ShouldEqual(Suit.Spades);
			hand.Cards.ElementAt(0).Value.ShouldEqual(2);
			
			hand.Cards.ElementAt(4).Suit.ShouldEqual(Suit.Diamonds);
			hand.Cards.ElementAt(4).Value.ShouldEqual(10);
		}

		private Hand GenerateHandFromDescription(string handDescription)
		{
			var hand = new Hand();
			var values = handDescription.Substring(0, 5);
			var suits = handDescription.Substring(5, 5);

			var valueMap = new Dictionary<string, string>()
			               	{
			               		{"A", "14"},
			               		{"K", "13"},
			               		{"Q", "12"},
			               		{"J", "11"},
			               		{"T", "10"}
			               	};

			for(var i = 0;i < 5;i++)
			{
				var suit = Enum.GetNames(typeof (Suit)).Single(n => n[0] == suits[i]);
				var value = values[i].ToString();

				if(valueMap.ContainsKey(value))
					value = valueMap[value];

				var card = new Card((Suit) Enum.Parse(typeof (Suit), suit), int.Parse(value));
				hand.AddCard(card);
			}

			return hand;
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