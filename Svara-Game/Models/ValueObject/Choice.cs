using Svara_Game.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Svara_Game.Models.ValueObject
{
    public class Choice
    {

        private IReader reader;
        private IWriter writer;

        public Choice(IReader reader,IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }


        public int Options()
        {

            writer.WriteLine("Click 1 for up bet");
            writer.WriteLine("Click 2 for Pay bet");
            writer.WriteLine("Click 3 for Exit");
            int choice = int.Parse(reader.Read());


            return choice;
        }

    }
}
