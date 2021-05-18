using Svara_Game.Core;
using Svara_Game.DI;
using Svara_Game.Models;
using Svara_Game.Models.ValueObject;
using System;
using System.Collections.Generic;

namespace Svara_Game
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            Engine engine = new Engine();

            engine.Play();

            
        }
    }
}
