using NUnit.Framework;

namespace BridgeHandKata.Test
{
    [TestFixture]
    public class BridgeGameTest
    {
        const string PlayersHandsN12S8E1W20 =
            "N(S:AJ??, H:K??, D:QJ, C:J???); " +
            "S(S:????, H:???, D:??, C:AKJ?); " +
            "E(S:????, H:J??, D:??, C:????); " +
            "W(S:KQ??, H:AQ?, D:AK, C:Q???); ";

        [TestCase("N(S:J???, H:???, D:??, C:????);", 1)]
        [TestCase("N(S:J???, H:J??, D:??, C:????);", 2)]
        public void TestAGameForPlayerNorthsPoints(string playersHand, int expectedPoints)
        {
            BridgeGame game = new BridgeGame(playersHand);

            int points = game.GetPointsFor(Player.North);

            Assert.That(points, Is.EqualTo(expectedPoints));
        }

        [TestCase("N(S:J???, H:???, D:??, C:????); S(S:QJ??, H:???, D:??, C:????);", 1, 3)]
        [TestCase("N(S:J???, H:J??, D:J?, C:????); S(S:QJ??, H:???, D:??, C:J???);", 3, 4)]
        public void TestAGameForPlayersNorthsAndSouthsPoints(string playersHand, int northsExpectedPoints, int southsExpectedPoints)
        {
            BridgeGame game = new BridgeGame(playersHand);

            int northsPoints = game.GetPointsFor(Player.North);
            int southsPoints = game.GetPointsFor(Player.South);

            Assert.That(northsPoints, Is.EqualTo(northsExpectedPoints));
            Assert.That(southsPoints, Is.EqualTo(southsExpectedPoints));
        }

        [Test]
        public void TestAGameForAll4PlayersPoints()
        {
            BridgeGame game = new BridgeGame(PlayersHandsN12S8E1W20);

            int northsPoints = game.GetPointsFor(Player.North);
            int southsPoints = game.GetPointsFor(Player.South);
            int eastPoints = game.GetPointsFor(Player.East);
            int westPoints = game.GetPointsFor(Player.West);

            Assert.That(northsPoints, Is.EqualTo(12));
            Assert.That(southsPoints, Is.EqualTo(8));
            Assert.That(eastPoints, Is.EqualTo(1));
            Assert.That(westPoints, Is.EqualTo(20));
        }
    }
}
