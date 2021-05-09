using Svara_Game.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Svara_Game.Models
{
    public class Reader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
