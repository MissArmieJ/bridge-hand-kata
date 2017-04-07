using System.Linq;

namespace BridgeHandKata
{
    public class BridgeHand 
    {
        private readonly string _hand;

        public BridgeHand(string hand)
        {
            _hand = hand;
        }

        public int CalculatePoints()
        {
            return SumCards(_hand);
        }

        public int CalculatePointsBy(Suit suit)
        {
            return SumCards(suit.GetHand(_hand));
        }

        public int HowManyCardsIn(Suit suit)
        {
            return CountCards(suit.GetHand(_hand));
        }

        public string SuggestedOpeningBid()
        {
            var points = CalculatePoints();
            var suit = CalculateStrongestLongestSuit();

            OpeningBidStrategy openingBid = new OpeningBidStrategy(points, suit);

            return openingBid.SuggestedBid();
        }

        public Suit CalculateStrongestLongestSuit()
        {
            //(1) strongest = most points 
            var mostPoints = DeckOfCards.Suits().Max(CalculatePointsBy);
            var suitsMostsPoints = DeckOfCards.Suits().Where(c => CalculatePointsBy(c) == mostPoints).ToList();

            //(2) longest  = most cards
            var mostCards = suitsMostsPoints.Max(HowManyCardsIn);
            var suit = suitsMostsPoints.First(s => HowManyCardsIn(s) == mostCards);

            return suit;
        }
        private static int SumCards(string hand)
        {
            return PointCard.Cards().Sum(kvp => hand.Count(c => c == kvp.Rank) * kvp.Points);
        }

        private static int CountCards(string hand)
        {
            return hand.Trim().Length;
        }

    }
}