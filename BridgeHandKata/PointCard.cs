using System.Collections.Generic;

namespace BridgeHandKata
{
    internal class PointCard
    {
        public static List<PointCard> Cards()
        {
            return new List<PointCard>
            {
                Ace,
                King,
                Queen,
                Jack,
            };
        }

        public static PointCard Ace = new PointCard('A', 4);
        public static PointCard King = new PointCard('K', 3);
        public static PointCard Queen = new PointCard('Q', 2);
        public static PointCard Jack = new PointCard('J', 1);

        public readonly char Rank;
        public readonly int Points;

        private PointCard(char rank, int points)
        {
            Rank = rank;
            Points = points;
        }
    }
}