using Svara_Game.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Svara_Game.Contracts
{
    public interface IDeck
    {

        public List<Card> Cards { get; }

        List<Card> StirringDeck();


    }
}
