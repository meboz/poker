namespace poker
{
	public interface ITexasHoldemHandIdentifier
	{
		bool IsHandOfThisType(Hand hand);
		TexasHoldemHand IdentifiedHand { get; }
	}
}