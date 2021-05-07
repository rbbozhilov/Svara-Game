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


            //Deck deck = new Deck();

            //List<Card> cards = deck.Cards;

            //Player player = new Player("pesho");
            //player.AddCard(cards[2]);
            //player.AddCard(cards[1]);
            //player.AddCard(cards[13]);

            //Console.WriteLine(player.Score.Points);


            Writer writer = new Writer();
            Reader reader = new Reader();

            string a = reader.Read();

            Player player = new Player("gosho");
            Deck deck = new Deck();

            player.AddCard(deck.GetCard());
            player.AddCard(deck.GetCard());
            player.AddCard(deck.GetCard());

            player.ShowCards();

        }
    }
}
