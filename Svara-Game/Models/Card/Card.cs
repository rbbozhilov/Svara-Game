using Svara_Game.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Svara_Game.Models
{
    public class Card : ICard
    {

        public Card(string name,string type,int points)
        {
            this.Name = name;
            this.Type = type;
            this.Points = points;
        }

        public string Name { get; }

        public string Type { get; }

        public int Points { get; }

        public override string ToString()
        {
            return $"Card : Name: {this.Name} -> Type: {this.Type} -> Points: {this.Points}";
        }

    }
}
