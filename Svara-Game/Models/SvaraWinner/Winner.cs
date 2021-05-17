using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Svara_Game.Models.SvaraWinner
{
    public class Winner : IWinner
    {

        private List<Player> players;

        public Winner()
        {
            this.players = new List<Player>();
        }

        public List<Player> GetWinner()
        {

            //int maxscore = 0;

            //foreach (var player in this.players)
            //{
            //    int currentscore = player.score.points;

            //    if (currentscore > maxscore)
            //    {
            //        maxscore = currentscore;
            //    }
            //}

            //return this.players.where(x => x.score.points == maxscore).tolist();
            return null;
        }

    }
}
