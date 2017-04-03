using System.Collections.Generic;
using NUnit.Framework;

namespace BridgeHandKata.Test
{
    [TestFixture]
    public class OpeningBidStrategyShould
    {
        public static IEnumerable<TestCaseData> SuggestedBidCaseData
        {
            get
            {
                yield return new TestCaseData(11, Suit.Spades, "PASS");
                yield return new TestCaseData(13, Suit.Clubs, "1C");
                yield return new TestCaseData(20, Suit.Diamonds, "2D");
                yield return new TestCaseData(25, Suit.Hearts, "3NT");
            }
        }
        [TestCaseSource(nameof(SuggestedBidCaseData))]
        public void suggest_bid(int points, Suit suit, string bid)
        {
            var openingBidStrategy = new OpeningBidStrategy(points, suit);

            Assert.That(openingBidStrategy.SuggestedBid(), Is.EqualTo(bid));
        }

    }
}
