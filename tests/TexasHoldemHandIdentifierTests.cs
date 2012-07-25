using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SharpArch.Testing.NUnit;
using System.Linq;

namespace poker.tests
{
	[TestFixture]
	public class TexasHoldemHandIdentifierTests
	{
		private Hand _validHand;

		[SetUp]
		public void setup()
		{
			_validHand = new Hand();
			_validHand.AddCard(new Card(Suit.Hearts, 10));
			_validHand.AddCard(new Card(Suit.Hearts, 6));
			_validHand.AddCard(new Card(Suit.Diamonds, 3));
			_validHand.AddCard(new Card(Suit.Spades, 14));
			_validHand.AddCard(new Card(Suit.Clubs, 2));
		}
		[Test]
		public void should_have_a_default_list_of_identifiers_in_rank_order()
		{
			var identifier = new TexasHoldemHandIdentifier();

			identifier.HandIndentifiers.Count.ShouldEqual(9);
			identifier.HandIndentifiers.ElementAt(0).ShouldBeOfType(typeof(TexasHoldemRoyalFlushIdentifier));
			identifier.HandIndentifiers.ElementAt(1).ShouldBeOfType(typeof(TexasHoldemStraightFlushIdentifier));
			identifier.HandIndentifiers.ElementAt(2).ShouldBeOfType(typeof(TexasHoldemFourOfAKindIdentifier));
			identifier.HandIndentifiers.ElementAt(3).ShouldBeOfType(typeof(TexasHoldemFullHouseIdentifier));
			identifier.HandIndentifiers.ElementAt(4).ShouldBeOfType(typeof(TexasHoldemFlushIdentifier));
			identifier.HandIndentifiers.ElementAt(5).ShouldBeOfType(typeof(TexasHoldemStraightIdentifier));
			identifier.HandIndentifiers.ElementAt(6).ShouldBeOfType(typeof(TexasHoldemThreeOfAKindIdentifier));
			identifier.HandIndentifiers.ElementAt(7).ShouldBeOfType(typeof(TexasHoldemTwoPairIdentifier));
			identifier.HandIndentifiers.ElementAt(8).ShouldBeOfType(typeof(TexasHoldemOnePairIdentifier));

		}
		[Test]
		[ExpectedArgumentNullException("HandIdentifiers")]
		public void should_require_hand_identifier_to_be_non_null_to_do_work()
		{
			var handIdentifier = new TexasHoldemHandIdentifier();
			handIdentifier.HandIndentifiers = null;
			handIdentifier.Identify(new Hand());
		}

		[Test]
		public void hand_should_be_identified_as_highcard_if_not_matching_identifiers()
		{
			var handIdentifier = new TexasHoldemHandIdentifier();
			handIdentifier.HandIndentifiers = new List<ITexasHoldemHandIdentifier>();

			var identifiedHand = handIdentifier.Identify(_validHand);
			identifiedHand.ShouldEqual(TexasHoldemHand.HighCard);
		}

		[Test]
		public void should_not_inspect_other_identifiers_if_identifier_is_matched()
		{
			var identifier1 = MockRepository.GenerateMock<ITexasHoldemHandIdentifier>();
			var identifier2 = MockRepository.GenerateMock<ITexasHoldemHandIdentifier>();

			identifier1.Expect(x => x.IsHandOfThisType(_validHand)).Return(true);
			identifier1.Expect(x => x.IdentifiedHand).Return(TexasHoldemHand.FourOfAKind);

			var handIdentifier = new TexasHoldemHandIdentifier();
			handIdentifier.HandIndentifiers = new List<ITexasHoldemHandIdentifier>()
			                                  	{
			                                  		identifier1,
			                                  		identifier2
			                                  	};


			var identifiedHand =  handIdentifier.Identify(_validHand);
			
			identifier2.AssertWasNotCalled(i => i.IsHandOfThisType(_validHand));
			identifiedHand.ShouldEqual(TexasHoldemHand.FourOfAKind);

		}

		[Test]
		public void should_iterate_each_provided_hand_inspector_and_return_hand_type_if_matched()
		{
			var identifier1 = MockRepository.GenerateMock<ITexasHoldemHandIdentifier>();
			var identifier2 = MockRepository.GenerateMock<ITexasHoldemHandIdentifier>();

			var handIdentifier = new TexasHoldemHandIdentifier();
			handIdentifier.HandIndentifiers = new List<ITexasHoldemHandIdentifier>()
			                                  	{
			                                  		identifier1,
			                                  		identifier2
			                                  	};


			handIdentifier.Identify(_validHand);

			identifier1.AssertWasCalled(i => i.IsHandOfThisType(_validHand));
			identifier2.AssertWasCalled(i => i.IsHandOfThisType(_validHand));
		}

		[Test]
		[ExpectedArgumentNullException("hand")]
		public void should_not_attempt_to_idetify_a_null_hand()
		{
			var handIdentifier = new TexasHoldemHandIdentifier();
			handIdentifier.Identify(null);
		}

		[Test]
		[ExpectedException(typeof(Exception),ExpectedMessage = "Not a valid texas holdem hand. Expected 5 cards but got 4")]
		public void should_pass_the_identifier_a_valid_hand(string handDescription)
		{
			var handIdentifier = new TexasHoldemHandIdentifier();
			_validHand.Cards.RemoveAt(1);
			handIdentifier.Identify(_validHand);
		}
	}
}