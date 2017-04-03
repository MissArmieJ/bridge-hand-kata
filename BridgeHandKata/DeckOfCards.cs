using System.Collections.Generic;

namespace BridgeHandKata
{
    public static class DeckOfCards
    {
        public static List<Suit> Suits()
        {
            return new List<Suit>
            {
                Suit.Spades,
                Suit.Hearts,
                Suit.Diamonds,
                Suit.Clubs
            };
        }

        
    }
}