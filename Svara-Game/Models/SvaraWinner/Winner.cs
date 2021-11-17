using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Svara_Game.Models.SvaraWinner
{
    public class Winner : IWinner
    {

        private IReadOnlyCollection<Player> players;

        public Winner(IReadOnlyCollection<Player> players)
        {
            this.players = players;
        }

        public IReadOnlyCollection<Player> GetWinner()
        {

            int maxscore = 0;

            foreach (var player in this.players)
            {
                int currentscore = player.Score.Points;

                if (currentscore > maxscore)
                {
                    maxscore = currentscore;
                }
            }

            return this.players.Where(x => x.Score.Points == maxscore).ToList();
           
        }

    }
}
