namespace BridgeHandKata
{
    public class OpeningBidStrategy
    {
        private const string Pass = "PASS";
        private const string One = "1";
        private const string Two = "2";
        private const string ThreeNoTrump = "3NT";

        private readonly int _points;
        private readonly Suit _suit;

        public OpeningBidStrategy(int points, Suit suit)
        {
            this._points = points;
            this._suit = suit;
        }

        public string SuggestedBid()
        {
            if (NotEnoughPointsToBid())
            {
                return Pass;
            }

            return TooManyPointsForA1Or2SuitedBid() ? ThreeNoTrump : LowSuitedBid();
        }

        private string LowSuitedBid()
        {
            return LowBidNumber() + _suit.ToLetter();
        }

        private string LowBidNumber()
        {
            return _points > 18 ? Two : One;
        }

        private bool TooManyPointsForA1Or2SuitedBid()
        {
            return _points >= 25;
        }

        private bool NotEnoughPointsToBid()
        {
            return _points < 12;
        }
    }
}