using Svara_Game.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Svara_Game.Models
{
    public class Deck : IDeck
    {

        private List<Card> cards;

        public Deck()
        {
            this.cards = new List<Card>()
            {
                new Card("7","Karo",7),
                new Card("7","Pika",7),
                new Card("7","Spatia",11),
                new Card("7","Kupa",7),
                new Card("8","Karo",8),
                new Card("8","Pika",8),
                new Card("8","Spatia",8),
                new Card("8","Kupa",8),
                new Card("9","Karo",9),
                new Card("9","Pika",9),
                new Card("9","Spatia",9),
                new Card("9","Kupa",9),
                new Card("10","Karo",10),
                new Card("10","Pika",10),
                new Card("10","Spatia",10),
                new Card("10","Kupa",10),
                new Card("Aso","Karo",11),
                new Card("Aso","Pika",11),
                new Card("Aso","Spatia",11),
                new Card("Aso","Kupa",11),
                new Card("Dama","Karo",10),
                new Card("Dama","Pika",10),
                new Card("Dama","Spatia",10),
                new Card("Dama","Kupa",10),
                new Card("Pop","Karo",10),
                new Card("Pop","Pika",10),
                new Card("Pop","Spatia",10),
                new Card("Pop","Kupa",10),
                new Card("Vale","Karo",10),
                new Card("Vale","Pika",10),
                new Card("Vale","Spatia",10),
                new Card("Vale","Kupa",10),
            };
            
        }


        public List<Card> Cards => cards;

        public List<Card> StirringDeck()
        {

            Random rng = new Random();

            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
                return this.cards;
        }

        public Card GetCard()
        {

            Card currentCard = this.cards[0];
            this.cards.Remove(currentCard);

            return currentCard;

        }
     
    }
}
