using System;
using System.Collections.Generic;

namespace BridgeHandKata
{
    public class BridgeGame
    {
        readonly Dictionary<Player, BridgeHand> _playersBridgeHands = new Dictionary<Player, BridgeHand>();

        public static List<Player> Players()
        {
            return new List<Player>
            {
                Player.North,
                Player.South,
                Player.East,
                Player.West
            };
        }

        public BridgeGame(string playersHands)
        {
            foreach (var player in Players())
            {
                var playerHand = GetPlayerHand(player, playersHands);
                var bridgeHand = new BridgeHand(playerHand);
                _playersBridgeHands.Add(player, bridgeHand);
            }
        }

        public int GetPointsFor(Player player)
        {
            return _playersBridgeHands[player].CalculatePoints();
        }

        
        private string GetPlayerHand(Player player, string playersHands)
        {
            //Format i.e. "N(S:J???, H:???, D:??, C:????); S(S:QJ??, H:???, D:??, C:????); E(S:AK??, H:???, D:??, C:????); W(S:QJ??, H:K??, D:??, C:????); ";
            var playerLetter = player.ToLetter();
            var playerHandStart = playersHands.IndexOf(playerLetter+"(", StringComparison.Ordinal) + 2;
            var playerHandEnd = playersHands.IndexOf(')', playerHandStart) ;
            var playerHand = playersHands.Substring(playerHandStart, playerHandEnd - playerHandStart);

            return playerHand;
        }

    }
}