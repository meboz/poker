namespace poker
{
	public interface ITexasHoldemHandIdentifier
	{
		bool IsHandOfThisType(string hand);
		TexasHoldemHand IdentifiedHand { get; }
	}
}