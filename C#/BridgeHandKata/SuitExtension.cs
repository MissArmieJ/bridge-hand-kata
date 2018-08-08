using System;

namespace BridgeHandKata
{
    public static class SuitExtension
    {
        public static string GetHand(this Suit suit, string hand)
        {
            var suitLetter = suit.ToLetter();
            var suitHandStart = hand.IndexOf(suitLetter, StringComparison.Ordinal) + 2;
            var suitHandEnd = (hand.IndexOf(',', suitHandStart) > 0) ? hand.IndexOf(',', suitHandStart) : hand.Length;
            var suitHand = hand.Substring(suitHandStart, suitHandEnd - suitHandStart);
            return suitHand;
        }
    }
}