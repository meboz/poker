using System;
using System.Collections.Generic;
using System.Linq;

namespace poker
{
	public class Hand
	{
		public List<Card> Cards { get; set; }

		public virtual string Description
		{
			get
			{
				return Cards == null ? "" : string.Join(" ", Cards.Select(c => c.Description).ToArray());
			}
		}

		public virtual string ValuesThenSuitsDescription
		{
			get
			{
				if (Cards == null)
					return "";

				var orderedCards = Cards.OrderBy(c => c.Value);

				return string.Join("", orderedCards.Select(c => c.Description[0]).ToArray()) + string.Join("", orderedCards.Select(c => c.Description[1]).ToArray());
			}
		}

		public Hand()
		{
			Cards = new List<Card>();
		}

		public void AddCard(Card card)
		{
			if(card == null)
				throw new ArgumentNullException("card");
			
			if (Cards == null)
				Cards = new List<Card>();

			Cards.Add(card);
		}

		public virtual bool HasAllTheSameSuit
		{
			get
			{
				return Cards.GroupBy(c => c.Suit).Count() == 1;						
			}
		}
	}
}