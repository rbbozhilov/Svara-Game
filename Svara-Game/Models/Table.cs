using Svara_Game.Contracts;
using Svara_Game.Models.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Svara_Game.Models
{
    public class Table : ITable
    {

        private readonly List<Player> players;
      

        public Table(List<Player> players)
        {
            this.players = players;
        }


        public int Bet { get; private set; }


        public void UpBet(int number)
        {
            this.Bet += number;
        }


  


    }
}
