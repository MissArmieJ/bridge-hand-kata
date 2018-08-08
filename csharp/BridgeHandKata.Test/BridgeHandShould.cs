using NUnit.Framework;

namespace BridgeHandKata.Test
{
    [TestFixture]
    public class BridgeHandShould
    {
        [Test]
        public void calculate_hand_with_no_points()
        {
            var hand = "S:????, H:???, D:??, C:????";
            BridgeHand bridgeHand = new BridgeHand(hand);

            int points = bridgeHand.CalculatePoints();

            Assert.That(points, Is.EqualTo(0));

        }

        [TestCase("S:J???, H:???, D:??, C:????", 1)]
        [TestCase("S:J???, H:J??, D:??, C:????", 2)]
        [TestCase("S:J???, H:J??, D:J?, C:????", 3)]
        [TestCase("S:J???, H:J??, D:J?, C:J???", 4)]
        public void calculate_hand_with_only_jacks(string hand, int expectedPoints)
        {
            BridgeHand bridgeHand = new BridgeHand(hand);

            int points = bridgeHand.CalculatePoints();

            Assert.That(points, Is.EqualTo(expectedPoints));

        }

        [TestCase("S:????, H:Q??, D:??, C:????", 2)]
        [TestCase("S:Q???, H:Q??, D:??, C:????", 4)]
        [TestCase("S:Q???, H:Q??, D:Q?, C:????", 6)]
        [TestCase("S:Q???, H:Q??, D:Q?, C:Q???", 8)]
        public void calculate_hand_with_only_queens(string hand, int expectedPoints)
        {
            BridgeHand bridgeHand = new BridgeHand(hand);

            int points = bridgeHand.CalculatePoints();

            Assert.That(points, Is.EqualTo(expectedPoints));

        }

        [TestCase("S:J???, H:Q??, D:??, C:????", 3)]
        [TestCase("S:Q???, H:Q??, D:J?, C:????", 5)]
        [TestCase("S:Q???, H:J??, D:J?, C:????", 4)]
        [TestCase("S:QJ??, H:QJ?, D:??, C:????", 6)]
        public void calculate_hand_with_jacks_and_queens(string hand, int expectedPoints)
        {
            BridgeHand bridgeHand = new BridgeHand(hand);

            int points = bridgeHand.CalculatePoints();

            Assert.That(points, Is.EqualTo(expectedPoints));

        }

        [TestCase("S:K???, H:???, D:??, C:????", 3)]
        [TestCase("S:J???, H:Q??, D:K?, C:????", 6)]
        public void calculate_hand_with_kings(string hand, int expectedPoints)
        {
            BridgeHand bridgeHand = new BridgeHand(hand);

            int points = bridgeHand.CalculatePoints();

            Assert.That(points, Is.EqualTo(expectedPoints));

        }

        [TestCase("S:AKQJ, H:???, D:??, C:????", 10)]
        [TestCase("S:J???, H:Q??, D:K?, C:AK??", 13)]
        [TestCase("S:AKQJ, H:AKQ, D:AKQ, C:AKQ", 37)]
        public void calculate_hand_with_mix_of_aces_kings_queens_jacks(string hand, int expectedPoints)
        {
            BridgeHand bridgeHand = new BridgeHand(hand);

            int points = bridgeHand.CalculatePoints();

            Assert.That(points, Is.EqualTo(expectedPoints));
        }

        [TestCase("S:J???, H:???, D:??, C:????", 1)]
        [TestCase("S:Q???, H:???, D:??, C:????", 2)]
        [TestCase("S:QJ??, H:???, D:??, C:????", 3)]
        [TestCase("S:A???, H:???, D:??, C:????", 4)]
        public void calculate_points_by_suit_of_spades(string hand, int expectedPoints)
        {
            BridgeHand bridgeHand = new BridgeHand(hand);

            Suit spades = Suit.Spades;
            int points = bridgeHand.CalculatePointsBy(spades);

            Assert.That(points, Is.EqualTo(expectedPoints));
        }

        [TestCase("S:J???, H:J??, D:??, C:????", 1)]
        [TestCase("S:Q???, H:Q??, D:??, C:????", 2)]
        [TestCase("S:QJ??, H:K??, D:??, C:????", 3)]
        [TestCase("S:A???, H:A??, D:??, C:????", 4)]
        public void calculate_points_by_suit_of_hearts(string hand, int expectedPoints)
        {
            BridgeHand bridgeHand = new BridgeHand(hand);

            Suit hearts = Suit.Hearts;
            int points = bridgeHand.CalculatePointsBy(hearts);

            Assert.That(points, Is.EqualTo(expectedPoints));
        }

        [TestCase("S:J???, H:J??, D:J?, C:????", 1)]
        [TestCase("S:Q???, H:Q??, D:Q?, C:????", 2)]
        [TestCase("S:QJ??, H:K??, D:K?, C:????", 3)]
        [TestCase("S:A???, H:A??, D:A?, C:????", 4)]
        public void calculate_points_by_suit_of_diamonds(string hand, int expectedPoints)
        {
            BridgeHand bridgeHand = new BridgeHand(hand);

            Suit diamonds = Suit.Diamonds;
            int points = bridgeHand.CalculatePointsBy(diamonds);

            Assert.That(points, Is.EqualTo(expectedPoints));
        }

        [TestCase("S:J???, H:J??, D:J?, C:J???", 1)]
        [TestCase("S:Q???, H:Q??, D:Q?, C:Q???", 2)]
        [TestCase("S:QJ??, H:K??, D:K?, C:K???", 3)]
        [TestCase("S:A???, H:A??, D:A?, C:A???", 4)]
        public void calculate_points_by_suit_of_clubs(string hand, int expectedPoints)
        {
            BridgeHand bridgeHand = new BridgeHand(hand);

            Suit clubs = Suit.Clubs;
            int points = bridgeHand.CalculatePointsBy(clubs);

            Assert.That(points, Is.EqualTo(expectedPoints));
        }

        [TestCase("S:A???, H:???, D:??, C:????", "S")]
        [TestCase("S:??, H:A?????, D:??, C:???", "H")]
        public void calculate_strongest_suit(string hand, string suitLetter)
        {
            BridgeHand bridgeHand = new BridgeHand(hand);

            Suit strongestSuit = bridgeHand.CalculateStrongestLongestSuit();

            Assert.That(strongestSuit.ToLetter(), Is.EqualTo(suitLetter));
        }

        [TestCase("S:A???, H:???, D:??, C:????", "S")]
        [TestCase("S:??, H:A?????, D:??, C:???", "H")]
        [TestCase("S:K, H:K??, D:K????, C:K???", "D")]
        [TestCase("S:A???, H:A??, D:A?, C:A???", "S")]
        public void calculate_strongest_and_longest_suit(string hand, string suitLetter)
        {
            BridgeHand bridgeHand = new BridgeHand(hand);

            Suit strongestSuit = bridgeHand.CalculateStrongestLongestSuit();

            Assert.That(strongestSuit.ToLetter(), Is.EqualTo(suitLetter));
        }

        [TestCase("S:A???, H:A??, D:AJ, C:A???", "1D")]
        [TestCase("S:A?, H:AKQJ??, D:??, C:AJ?", "2H")]
        [TestCase("S:K, H:K??, D:K????, C:????", "PASS")]
        [TestCase("S:A???, H:A??, D:AK, C:AKQJ", "3NT")]
        public void suggest_opening_bid(string hand, string expectedBid)
        {
            BridgeHand bridgeHand = new BridgeHand(hand);

            var bid = bridgeHand.SuggestedOpeningBid();

            Assert.That(bid, Is.EqualTo(expectedBid));
        }
    }
}

