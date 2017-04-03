namespace BridgeHandKata
{
    public class Player
    {
        private readonly string _playerLetter;

        public static Player North = new Player("N");
        public static Player South = new Player("S");
        public static Player East = new Player("E");
        public static Player West = new Player("W");

        private Player(string playerLetter)
        {
            _playerLetter = playerLetter;
        }

        public string ToLetter()
        {
            return _playerLetter;
        }
    }
}