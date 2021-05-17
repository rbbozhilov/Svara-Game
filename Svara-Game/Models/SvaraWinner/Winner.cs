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

            int maxScore = 0;

            foreach (var player in this.players)
            {
                int currentScore = player.Score.Points;

                if (currentScore > maxScore)
                {
                    maxScore = currentScore;
                }
            }

            return this.players.Where(x => x.Score.Points == maxScore).ToList();

        }

    }
}
