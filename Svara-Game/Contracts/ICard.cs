using System;
using System.Collections.Generic;
using System.Text;

namespace Svara_Game.Contracts
{
    public interface ICard
    {

        public string Name { get; }
        public string Type { get;  }
        public int Points { get; }

    }
}
