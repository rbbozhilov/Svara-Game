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
        private Score score;
        private Choice choice;
        private ServiceProvider provider;
        private IWriter writer;
        public Player(string name)
        {
            this.Name = name;
            this.cards = new List<Card>();
            this.score = new Score(this.cards);
            this.provider = Container.ConfigureServices();
            this.choice = provider.GetRequiredService<Choice>();
            this.writer = provider.GetRequiredService<IWriter>();
        }

        public string Name { get; }

        public int Choice => choice.Options();

        public Score Score => this.score;


        public IReadOnlyCollection<Card> Cards => this.cards.AsReadOnly();


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
