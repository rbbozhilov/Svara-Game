using Svara_Game.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Svara_Game.Models.Repository
{
   public class PlayerRepository
    {

        private List<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }


        public IReadOnlyCollection<IPlayer> Players => this.players.AsReadOnly();


        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            players.Remove(player);
        }

        public IReadOnlyCollection<IPlayer> GetPlayers()
        {
            return this.Players;
        }

    }
}
