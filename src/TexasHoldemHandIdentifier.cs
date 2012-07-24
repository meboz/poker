using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace poker
{
	public enum TexasHoldemHand
	{
		RoyalFlush,
		StraightFlush,
		FourOfAKind,
		FullHouse,
		ThreeOfAKind,
		HighCard
	}

	public class TexasHoldemHandIdentifier
	{
		public virtual TexasHoldemHand Identify(string handDescription)
		{
			var identifiedHand = TexasHoldemHand.HighCard;

			if(handDescription == null)
				throw new ArgumentNullException("handDescription");
			
			if(handDescription.Length != 10)
				throw new Exception(string.Format("Not a valid texas holdem hand. Expected 5 cards but got [{0}]", handDescription));

			var handPredicates = new Dictionary<TexasHoldemHand, Func<string, bool>>()
			                	{
									{TexasHoldemHand.RoyalFlush, (hand) =>
									                             	{
									                             		return new Regex("(TJQKA)(DDDDD|SSSSS|CCCCC|HHHHH)").IsMatch(hand);
									                             	}},
									{TexasHoldemHand.StraightFlush, (hand) =>
									                             	{
									                             		return new Regex("(23456|34567|45678|56789|6789T|789TJ|89TJQ|9TJQK)(DDDDD|SSSSS|CCCCC|HHHHH)").IsMatch(hand);
									                             	}},
									{TexasHoldemHand.FourOfAKind, (hand) =>
									                             	{
																		return new Regex("(2222|3333|4444|5555|6666|7777|8888|9999|TTTT|JJJJ|QQQQ|KKKK|AAAA)").IsMatch(hand);
									                             	}},
									
									{TexasHoldemHand.FullHouse, (hand) =>
									                            	{
									                            		var groups = hand.Substring(0,5).GroupBy(c => c);
									                            		return groups.Count() == 2;
									                             	}},

			                	};

			foreach (var predicate in handPredicates)
			{
				if(predicate.Value.Invoke(handDescription))
				{
					identifiedHand = predicate.Key;
					break;
				}

			}

			return identifiedHand;
		}
	}
}