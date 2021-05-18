using Microsoft.Extensions.DependencyInjection;
using Svara_Game.Contracts;
using Svara_Game.DI;
using Svara_Game.Models.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Svara_Game.Models
{
    public class Player : IPlayer
    {

        private readonly List<Card> cards;
        private ServiceProvider provider;
        private IWriter writer;
        private Choice choice;
        private Score score;
      

        public Player(string name)
        {
            this.Name = name;
            this.cards = new List<Card>();
            this.provider = Container.ConfigureServices();
            this.writer = provider.GetRequiredService<IWriter>();
            this.choice = provider.GetRequiredService<Choice>();
            this.score = new Score(this.cards);
        }

        public string Name { get; }
        public int Bet { get; set; }
        public bool PayBet { get; set; }

        public Choice Choice => this.choice;
        public Score Score => this.score;

        public IReadOnlyCollection<Card> Cards => this.cards.AsReadOnly();

        public bool Winner { get; set; }

        public void AddCard(Card card)
        {
            this.cards.Add(card);
        }


        public void ShowCards()
        {

            foreach (var card in this.Cards)
            {
                this.writer.WriteLine(card.ToString());
            }


        }

     


    }
}
