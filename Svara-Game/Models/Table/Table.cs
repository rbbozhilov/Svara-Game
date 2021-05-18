using Svara_Game.Contracts;
using Svara_Game.Models.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Svara_Game.Models
{
    public class Table : ITable
    {

        public Table()
        {
            this.FullBet = 0;
        }


        public int FullBet { get; private set; }


        public void UpBet(int number)
        {
            this.FullBet += number;
        }

     
    }
}
