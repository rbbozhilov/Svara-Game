using Microsoft.Extensions.DependencyInjection;
using Svara_Game.Contracts;
using Svara_Game.Core;
using Svara_Game.Data;
using Svara_Game.DI;
using Svara_Game.Models;
using Svara_Game.Models.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Svara_Game
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            Engine engine = new Engine();

            engine.Play();

            var db = new SvaraDbContext();

            ServiceProvider provider = Container.ConfigureServices();
            IWriter writer = provider.GetRequiredService<IWriter>();
            IReader reader = provider.GetRequiredService<IReader>();

            writer.WriteLine("Do you want to see all players win/loses ?/nPress 1: -> ");
            int choice = int.Parse(reader.Read());

            if (choice == 1)
            {
                var players = db.Users.Select(x => new { Name = x.Name, Wins = x.Wins, Date = x.OnDate }).ToList();


                foreach (var player in players)
                {
                    writer.WriteLine(player.ToString());
                }

            }
            

        }
    }
}
