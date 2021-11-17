using System;
using System.Collections.Generic;
using System.Text;

namespace Svara_Game.Models.SvaraWinner
{
    public interface IWinner
    {
        IReadOnlyCollection<Player> GetWinner();

    }
}
