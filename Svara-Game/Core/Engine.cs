using Microsoft.Extensions.DependencyInjection;
using Svara_Game.Contracts;
using Svara_Game.DI;
using Svara_Game.Models;
using Svara_Game.Models.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Svara_Game.Core
{
    public class Engine : IEngine
    {

        private PlayerRepository players;
        private IWriter writer;
        private IReader reader;
        private ServiceProvider provider;
        private Deck deck;

        public Engine()
        {

            this.players = new PlayerRepository();
            this.provider = Container.ConfigureServices();
            this.writer = provider.GetRequiredService<IWriter>();
            this.reader = provider.GetRequiredService<IReader>();
            this.deck = new Deck();

        }

        public void Play()
        {

            this.deck.StirringDeck();
            this.writer.WriteLine("How much players will play ?: ");
            int numberOfPlayer = int.Parse(this.reader.Read());

            //TODO EXCEPTION FOR MAX PLAYERS

            for (int i = 0; i < numberOfPlayer; i++)
            {

                this.writer.WriteLine("Input your Name: ");
                string name = this.reader.Read();

                Player currentPlayer = new Player(name);
                this.players.AddPlayer(currentPlayer);


            }

            List<Player> currentPlayers = this.players.GetPlayers();
            int counter = 0;

            for (int i = 0; i < currentPlayers.Count * 3; i++)
            {

                if (counter == currentPlayers.Count)
                {
                    counter = 0;
                }

                currentPlayers[counter].AddCard(this.deck.GetCard());
                counter++;
            }

        }
    }
}
