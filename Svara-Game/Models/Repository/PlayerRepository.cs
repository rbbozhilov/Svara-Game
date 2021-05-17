using Svara_Game.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Svara_Game.Models.Repository
{
   public class PlayerRepository
    {

        private List<Player> players;

        public PlayerRepository()
        {
            this.players = new List<Player>();
        }


        public List<Player> Players => this.players;


        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            players.Remove(player);
        }

        public List<Player> GetPlayers()
        {
            return this.Players;
        }

    }
}
