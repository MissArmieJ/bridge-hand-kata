namespace BridgeHandKata
{
    public class Suit
    {
        private readonly string _suitLetter;

        public static Suit Spades = new Suit("S");
        public static Suit Hearts = new Suit("H");
        public static Suit Diamonds = new Suit("D");
        public static Suit Clubs = new Suit("C");

        private Suit(string suitLetter)
        {
            _suitLetter = suitLetter;
        }

        public string ToLetter()
        {
            return _suitLetter;
        }
    }
}