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
	}
}