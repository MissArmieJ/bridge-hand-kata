using NUnit.Framework;

namespace BridgeHandKata.Test
{
    [TestFixture]
    public class BridgeHandTests
    {
        [Test]
        public void TestAHandWithNoPoints()
        {
            var hand = "S:????, H:???, D:??, C:????";
            BridgeHand bridgeHand = new BridgeHand(hand);

            int points = bridgeHand.GetPoints();

            Assert.That(points, Is.EqualTo(0));

        }

        [TestCase("S:J???, H:???, D:??, C:????", 1)]
        [TestCase("S:J???, H:J??, D:??, C:????", 2)]
        [TestCase("S:J???, H:J??, D:J?, C:????", 3)]
        [TestCase("S:J???, H:J??, D:J?, C:J???", 4)]
        public void TestAHandWithOnlyJacks(string hand, int expectedPoints)
        {
            BridgeHand bridgeHand = new BridgeHand(hand);

            int points = bridgeHand.GetPoints();

            Assert.That(points, Is.EqualTo(expectedPoints));

        }

        [TestCase("S:????, H:Q??, D:??, C:????", 2)]
        [TestCase("S:Q???, H:Q??, D:??, C:????", 4)]
        [TestCase("S:Q???, H:Q??, D:Q?, C:????", 6)]
        [TestCase("S:Q???, H:Q??, D:Q?, C:Q???", 8)]
        public void TestAHandWithOnlyQueens(string hand, int expectedPoints)
        {
            BridgeHand bridgeHand = new BridgeHand(hand);

            int points = bridgeHand.GetPoints();

            Assert.That(points, Is.EqualTo(expectedPoints));

        }

        [TestCase("S:J???, H:Q??, D:??, C:????", 3)]
        [TestCase("S:Q???, H:Q??, D:J?, C:????", 5)]
        [TestCase("S:Q???, H:J??, D:J?, C:????", 4)]
        [TestCase("S:QJ??, H:QJ?, D:??, C:????", 6)]
        public void TestAHandWithJacksAndQueens(string hand, int expectedPoints)
        {
            BridgeHand bridgeHand = new BridgeHand(hand);

            int points = bridgeHand.GetPoints();

            Assert.That(points, Is.EqualTo(expectedPoints));

        }

        [TestCase("S:K???, H:???, D:??, C:????", 3)]
        [TestCase("S:J???, H:Q??, D:K?, C:????", 6)]
        public void TestAHandWithKings(string hand, int expectedPoints)
        {
            BridgeHand bridgeHand = new BridgeHand(hand);

            int points = bridgeHand.GetPoints();

            Assert.That(points, Is.EqualTo(expectedPoints));

        }

        [TestCase("S:AKQJ, H:???, D:??, C:????", 10)]
        [TestCase("S:J???, H:Q??, D:K?, C:AK??", 13)]
        [TestCase("S:AKQJ, H:AKQ, D:AKQ, C:AKQ", 37)]
        public void TestAHandWithMixOfAcesKingsQueensJacks(string hand, int expectedPoints)
        {
            BridgeHand bridgeHand = new BridgeHand(hand);

            int points = bridgeHand.GetPoints();

            Assert.That(points, Is.EqualTo(expectedPoints));
        }

        [TestCase("S:J???, H:???, D:??, C:????", 1)]
        [TestCase("S:Q???, H:???, D:??, C:????", 2)]
        [TestCase("S:QJ??, H:???, D:??, C:????", 3)]
        [TestCase("S:A???, H:???, D:??, C:????", 4)]
        public void TestAHandWithPointsBySpadesSuit(string hand, int expectedPoints)
        {
            BridgeHand bridgeHand = new BridgeHand(hand);

            Suit spades = Suit.Spades;
            int points = bridgeHand.GetPointsBy(spades);

            Assert.That(points, Is.EqualTo(expectedPoints));
        }

        [TestCase("S:J???, H:J??, D:??, C:????", 1)]
        [TestCase("S:Q???, H:Q??, D:??, C:????", 2)]
        [TestCase("S:QJ??, H:K??, D:??, C:????", 3)]
        [TestCase("S:A???, H:A??, D:??, C:????", 4)]
        public void TestAHandWithPointsByHeartsSuit(string hand, int expectedPoints)
        {
            BridgeHand bridgeHand = new BridgeHand(hand);

            Suit hearts = Suit.Hearts;
            int points = bridgeHand.GetPointsBy(hearts);

            Assert.That(points, Is.EqualTo(expectedPoints));
        }

        [TestCase("S:J???, H:J??, D:J?, C:????", 1)]
        [TestCase("S:Q???, H:Q??, D:Q?, C:????", 2)]
        [TestCase("S:QJ??, H:K??, D:K?, C:????", 3)]
        [TestCase("S:A???, H:A??, D:A?, C:????", 4)]
        public void TestAHandWithPointsByDiamondsSuit(string hand, int expectedPoints)
        {
            BridgeHand bridgeHand = new BridgeHand(hand);

            Suit diamonds = Suit.Diamonds;
            int points = bridgeHand.GetPointsBy(diamonds);

            Assert.That(points, Is.EqualTo(expectedPoints));
        }

        [TestCase("S:J???, H:J??, D:J?, C:J???", 1)]
        [TestCase("S:Q???, H:Q??, D:Q?, C:Q???", 2)]
        [TestCase("S:QJ??, H:K??, D:K?, C:K???", 3)]
        [TestCase("S:A???, H:A??, D:A?, C:A???", 4)]
        public void TestAHandWithPointsByClubsSuit(string hand, int expectedPoints)
        {
            BridgeHand bridgeHand = new BridgeHand(hand);

            Suit clubs = Suit.Clubs;
            int points = bridgeHand.GetPointsBy(clubs);

            Assert.That(points, Is.EqualTo(expectedPoints));
        }

        [TestCase("S:A???, H:???, D:??, C:????", "S")]
        [TestCase("S:??, H:A?????, D:??, C:???", "H")]
        public void TestAHandForItsStrongestSuit(string hand, string suitLetter)
        {
            BridgeHand bridgeHand = new BridgeHand(hand);

            Suit strongestSuit = bridgeHand.GetBestSuit();

            Assert.That(strongestSuit.ToLetter(), Is.EqualTo(suitLetter));
        }

        [TestCase("S:A???, H:???, D:??, C:????", "S")]
        [TestCase("S:??, H:A?????, D:??, C:???", "H")]
        [TestCase("S:K, H:K??, D:K????, C:K???", "D")]
        [TestCase("S:A???, H:A??, D:A?, C:A???", "S")]
        public void TestAHandForItsStrongestAndLongestSuit(string hand, string suitLetter)
        {
            BridgeHand bridgeHand = new BridgeHand(hand);

            Suit strongestSuit = bridgeHand.GetBestSuit();

            Assert.That(strongestSuit.ToLetter(), Is.EqualTo(suitLetter));
        }
    }
}

