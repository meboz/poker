using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SharpArch.Testing.NUnit;

namespace poker.tests
{
	[TestFixture]
	public class TexasHoldemHandIdentifierTests
	{
		//var handPredicates = new Dictionary<TexasHoldemHand, ITexasHoldemHandIdentifier>()
		//                    {
		//                        {TexasHoldemHand.RoyalFlush, new RoyalFlushInspector()},
		//                        {TexasHoldemHand.StraightFlush, new TexasHoldemStraightFlushIdentifier()},
		//                        {TexasHoldemHand.FourOfAKind, new FourOfAKindInspector()},
		//                        {TexasHoldemHand.FullHouse, new FullHouseInspector()},
		//                        {TexasHoldemHand.Flush, new FlushInspector()},
		//                    };


		//these tests should move to individual hand identifier tests
		[TestCase("TJQKASSSSS",TexasHoldemHand.RoyalFlush)]
		[TestCase("56789SSSSS",TexasHoldemHand.StraightFlush)]
		[TestCase("44447SSSSS",TexasHoldemHand.FourOfAKind)]
		[TestCase("4TTTTDDDDD",TexasHoldemHand.FourOfAKind)]
		[TestCase("44TTTDDDDD",TexasHoldemHand.FullHouse)]
		[TestCase("444TTDDDDD",TexasHoldemHand.FullHouse)]
		[TestCase("445TTDDDDD",TexasHoldemHand.Flush)]
		[Ignore]
		public void can_identify_hands(string handDescription, TexasHoldemHand texasHoldemHandType)
		{
			//TODO: move these theses to be individual hand identifier tests
			var handIdentifier = new TexasHoldemHandIdentifier();
			var handType = handIdentifier.Identify(handDescription);
			handType.ShouldEqual(texasHoldemHandType);
		}

		[Test]
		[ExpectedArgumentNullException("HandIdentifiers")]
		public void should_require_hand_identifier_to_be_non_null_to_do_work()
		{
			var handIdentifier = new TexasHoldemHandIdentifier();
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