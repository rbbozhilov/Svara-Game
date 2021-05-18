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

        public int GetInSvara()
        {
            this.writer.WriteLine("Click 1 for drink and join in svara.");
            this.writer.WriteLine("Click 2 for quit and drink what you bet.");
            this.writer.Write("Your choice: ");
            int choice = int.Parse(reader.Read());

            return choice;
        }

        public int Options()
        {
            this.writer.WriteLine("Click 1 for up bet");
            this.writer.WriteLine("Click 2 for pay bet");
            this.writer.WriteLine("Click 3 for quit");
            int choice = int.Parse(reader.Read());

            return choice;
        }

       public int ShowingCardsOption()
        {

            this.writer.WriteLine("Press 1 for showing cards");
            this.writer.WriteLine("Press 2 for NOT showing cards");
            int choice = int.Parse(this.reader.Read());
            return choice;
        }

    }
}
