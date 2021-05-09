using Svara_Game.Models;
using Svara_Game.Models.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Svara_Game.Contracts
{
    public interface IPlayer
    {

        public string Name { get; }
        public Score Score { get; }
        public IReadOnlyCollection<Card> Cards { get; } 

    }
}
