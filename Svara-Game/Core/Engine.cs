using Microsoft.Extensions.DependencyInjection;
using Svara_Game.Contracts;
using Svara_Game.Data;
using Svara_Game.Data.Entities;
using Svara_Game.DI;
using Svara_Game.Models;
using Svara_Game.Models.Repository;
using Svara_Game.Models.SvaraWinner;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private Table table;
        private Winner winner;
        private bool inSvara;
        private SvaraDbContext db;

        public Engine()
        {

            this.players = new PlayerRepository();
            this.provider = Container.ConfigureServices();
            this.writer = provider.GetRequiredService<IWriter>();
            this.reader = provider.GetRequiredService<IReader>();
            this.deck = new Deck();
            this.table = new Table();
            this.inSvara = false;
            this.db = new SvaraDbContext();
            

        }

        public void Play()
        {

            CreatingDataBase();

            while (true)
            {

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

                    if (showCardsChoice == 1)
                    {
                        playersOnTable[counter].ShowCards();

                    }

                    var choice = playersOnTable[counter].Choice.Options();

                    if (choice == 1)
                    {
                        this.writer.Write("How much you will bet ? : ");
                        int currentBet = int.Parse(this.reader.Read());
                        playersOnTable[counter].Bet += currentBet;
                        this.table.UpBet(currentBet);
                        Console.Clear();
                    }

                    //if (choice == 2 && counterForBets == 0)
                    //{
                    //    playersOnTable.Remove(playersOnTable[counter]);
                    //    counter--;
                    //}

                    if (choice == 2)
                    {
                        playersOnTable[counter].PayBet = true;
                        Console.Clear();
                    }


                    if (choice == 3)
                    {
                        int drinks = playersOnTable[counter].Bet;
                        string name = playersOnTable[counter].Name;
                        playersOnTable.Remove(playersOnTable[counter]);
                        counter--;
                        Console.Clear();
                        this.writer.WriteLine($"{name} must drink : {drinks}");

                    }

                    if (playersOnTable.Count == 1)
                    {
                        this.writer.WriteLine($"Winner of this game is {playersOnTable[0].Name}");

                        ShowingCards(playersOnTable[0]);
                        this.writer.WriteLine($"Full bet is -> {this.table.FullBet}");

                        UpWinOfUser(playersOnTable[0]);

                        Environment.Exit(0);
                    }

                    int counterOfPayPlayers = 0;

                    foreach (var player in playersOnTable)
                    {

                        if (player.PayBet)
                        {
                            counterOfPayPlayers++;
                        }

                    }

                    if (counterOfPayPlayers == playersOnTable.Count || counterOfPayPlayers == playersOnTable.Count - 1)
                    {
                        break;
                    }

                    counter++;
                    counterForBets++;
                }

                winner = new Winner(playersOnTable);
                List<Player> winners = winner.GetWinner().ToList();
                Player theWinner = winners[0];


                if (winners.Count == 1)
                {

                    this.writer.WriteLine($"Winner of this game is {theWinner.Name}");

                    ShowingCards(theWinner);

                    this.writer.WriteLine($"Full bet is -> {this.table.FullBet}");
                    UpWinOfUser(theWinner);

                    break;

                }
                else
                {
                    
                    //TODO... When is svara
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
                AddPlayerInDataBase(name);
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


        private void ShowingCards(Player player)
        {
            if (player.Choice.ShowingCardsOption() == 1)
            {
                player.ShowCards();
            }
        }

        private void CreatingDataBase()
        {
            db.Database.EnsureCreated();
        }

        private void AddPlayerInDataBase(string name)
        {

            var player = db.Users.FirstOrDefault(x => x.Name == name);


            if(player == null)
            {
                User currentUser = new User() { Name = name };
                db.Users.Add(currentUser);
            }

            db.SaveChanges();

        }

        private void UpWinOfUser(Player player)
        {

            var userWin = db.Users.FirstOrDefault(x => x.Name == player.Name);
            userWin.OnDate = DateTime.UtcNow;
            userWin.Wins++;
            
            db.SaveChanges();

        }

    }
}
