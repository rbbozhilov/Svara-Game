using Microsoft.Extensions.DependencyInjection;
using Svara_Game.Contracts;
using Svara_Game.DI;
using Svara_Game.Models;
using Svara_Game.Models.Repository;
using Svara_Game.Models.SvaraWinner;
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
        private Winner winner;

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

            while (true)
            {


                Table table = new Table();
                this.deck.StirringDeck();


                AddingPlayersOnTable();

                var playersOnTable = AddCardsToPlayers();

                int counter = 0;
                int counterForBets = 0;

                while (true)
                {

                    if (counter >= playersOnTable.Count)
                    {
                        counter = 0;
                    }

                    this.writer.WriteLine($"Player : {playersOnTable[counter].Name}");
                    this.writer.WriteLine("Are you ready for check your cards and points ?/nPress 1 if you are: ");
                    int showCardsChoice = int.Parse(this.reader.Read());

                    if(showCardsChoice == 1)
                    {
                        playersOnTable[counter].ShowCards();
                        this.writer.WriteLine($"{playersOnTable[counter].Score.Points}");
                    }

                    var choice = playersOnTable[counter].Choice.Options();

                    if (choice == 1)
                    {
                        this.writer.Write("How much you will bet ? : ");
                        int currentBet = int.Parse(this.reader.Read());
                        playersOnTable[counter].Bet += currentBet;
                        table.UpBet(currentBet);
                    }

                    if (choice == 2 && counterForBets == 0)
                    {
                        playersOnTable.Remove(playersOnTable[counter]);
                    }

                    if (choice == 2)
                    {
                        playersOnTable[counter].PayBet = true;
                    }


                    if (choice == 3)
                    {
                        int drinks = playersOnTable[counter].Bet;
                        playersOnTable.Remove(playersOnTable[counter]);
                        this.writer.WriteLine($"You must drink : {drinks}");

                    }

                    if (playersOnTable.Count == 1)
                    {
                        this.writer.WriteLine($"Winner of this game is {playersOnTable[0].Name}");

                        if (playersOnTable[0].Choice.ShowingCardsOption() == 1)
                        {

                            playersOnTable[0].ShowCards();

                        }
                        Environment.Exit(0);
                    }

                    int counterOfPayPlayers = 0;
                    foreach(var player in playersOnTable)
                    {

                        if(player.PayBet)
                        {
                            counterOfPayPlayers++;
                        }

                    }

                    if(counterOfPayPlayers == playersOnTable.Count || counterOfPayPlayers == playersOnTable.Count-1)
                    {
                        break;
                    }

                    counter++;
                    counterForBets++;
                }

                winner = new Winner(playersOnTable);
                var winners = winner.GetWinner();

                if (winners.Count == 1)
                {

                    this.writer.WriteLine($"Winner of this game is {winners[0].Name}");
                    break;

                }
                else
                {
                    // TODO WHEN IS SVARA
                    this.deck = new Deck();

                }



            }
        }


        private void AddingPlayersOnTable()
        {


            //TODO EXCEPTION FOR MAX PLAYERS

            this.writer.Write("How much players will play ?: ");
            int numberOfPlayer = int.Parse(this.reader.Read());

            for (int i = 0; i < numberOfPlayer; i++)
            {

                this.writer.Write("Input your Name: ");
                string name = this.reader.Read();

                Player currentPlayer = new Player(name);
                this.players.AddPlayer(currentPlayer);


            }


        }

        private List<Player> AddCardsToPlayers()
        {
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

            return currentPlayers;
        }


        private void ShowingCards()
        {

        }


    }
}
