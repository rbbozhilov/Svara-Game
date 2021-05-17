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


            //Engine engine = new Engine();

            //engine.Play();

            Player player = new Player("tisho");

            Deck deck = new Deck();

            player.AddCard(deck.GetCard());
            player.AddCard(deck.GetCard());
            player.AddCard(deck.GetCard());
            player.ShowCards();
            int choice = player.Choice.Options();
        }
    }
}
