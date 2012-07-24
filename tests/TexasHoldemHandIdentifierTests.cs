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
			handIdentifier.Identify("33344SSSSS");
		}

		[Test]
		public void hand_should_be_identified_as_highcard_if_not_matching_identifiers()
		{
			var handIdentifier = new TexasHoldemHandIdentifier();
			handIdentifier.HandIndentifiers = new List<ITexasHoldemHandIdentifier>();

			var identifiedHand = handIdentifier.Identify("33344SSSSS");
			identifiedHand.ShouldEqual(TexasHoldemHand.HighCard);
		}

		[Test]
		public void should_not_inspect_other_identifiers_if_identifier_is_matched()
		{
			var handDescription = "33344SSSSS";
			var identifier1 = MockRepository.GenerateMock<ITexasHoldemHandIdentifier>();
			var identifier2 = MockRepository.GenerateMock<ITexasHoldemHandIdentifier>();

			identifier1.Expect(x => x.IsHandOfThisType(handDescription)).Return(true);
			identifier1.Expect(x => x.IdentifiedHand).Return(TexasHoldemHand.FourOfAKind);

			var handIdentifier = new TexasHoldemHandIdentifier();
			handIdentifier.HandIndentifiers = new List<ITexasHoldemHandIdentifier>()
			                                  	{
			                                  		identifier1,
			                                  		identifier2
			                                  	};


			var identifiedHand =  handIdentifier.Identify(handDescription);
			
			identifier2.AssertWasNotCalled(i => i.IsHandOfThisType(handDescription));
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

			var handDescription = "33344SSSSS";

			handIdentifier.Identify(handDescription);

			identifier1.AssertWasCalled(i => i.IsHandOfThisType(handDescription));
			identifier2.AssertWasCalled(i => i.IsHandOfThisType(handDescription));
		}

		[Test]
		[ExpectedArgumentNullException("handDescription")]
		public void should_not_attempt_to_idetify_a_null_hand()
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