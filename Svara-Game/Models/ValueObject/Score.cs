using System;
using System.Collections.Generic;
using System.Text;

namespace Svara_Game.Models.ValueObject
{
    public class Score
    {
        private readonly List<Card> cards;
        public Score(List<Card> cards)
        {
            this.cards = cards;
        }


        public int Points => MakeScore();

        private int MakeScore()
        {

            Card firstCard = this.cards[0];
            Card secondCard = this.cards[1];
            Card thirdCard = this.cards[2];
            int sum = 0;

            if (firstCard.Name == secondCard.Name && secondCard.Name == thirdCard.Name)
            {

                if (firstCard.Name == "7")
                {
                    return 33;
                }


                return firstCard.Points + secondCard.Points + thirdCard.Points;
            }


            if ((firstCard.Name == "7" && firstCard.Type == "Spatia" && secondCard.Type == thirdCard.Type) || (secondCard.Name == "7" && secondCard.Type == "Spatia" && firstCard.Type == thirdCard.Type) || (thirdCard.Type == "Spatia" && thirdCard.Name == "7" && firstCard.Type == secondCard.Type))
            {
                return firstCard.Points + secondCard.Points + thirdCard.Points;
            }

            if ((firstCard.Name == "7" && firstCard.Type == "Spatia" && secondCard.Name == thirdCard.Name) || (secondCard.Name == "7" && secondCard.Type == "Spatia" && firstCard.Name == thirdCard.Name) || (thirdCard.Name == "7" && thirdCard.Type == "Spatia" && firstCard.Name == secondCard.Name))
            {
                return firstCard.Points + secondCard.Points + thirdCard.Points;
            }



            if ((firstCard.Name == "Aso" && secondCard.Name == "Aso") || (secondCard.Name == "Aso" && thirdCard.Name == "Aso") || (firstCard.Name == "Aso" && thirdCard.Name == "Aso"))
            {
                return 22;
            }

            if ((firstCard.Name == "7" && secondCard.Name == "7") || (secondCard.Name == "7" && thirdCard.Name == "7") || (firstCard.Name == "7" && thirdCard.Name == "7"))
            {
                return 23;
            }


            if (firstCard.Type == secondCard.Type && secondCard.Type == thirdCard.Type)
            {
                sum = firstCard.Points + secondCard.Points + thirdCard.Points;
            }
            else if (firstCard.Type == secondCard.Type && thirdCard.Type != secondCard.Type)
            {
                sum = firstCard.Points + secondCard.Points;
            }
            else if (firstCard.Type == thirdCard.Type && firstCard.Type != secondCard.Type)
            {
                sum = firstCard.Points + thirdCard.Points;
            }
            else if (secondCard.Type == thirdCard.Type && thirdCard.Type != firstCard.Type)
            {
                sum = secondCard.Points + thirdCard.Points;
            }
            else
            {
                sum = BiggestNumber();
            }


            return sum;
        }

        private int BiggestNumber()
        {

            int sum = 0;
            Card firstCard = this.cards[0];
            Card secondCard = this.cards[1];
            Card thirdCard = this.cards[2];

            if (firstCard.Name == "7" && firstCard.Type == "Spatia")
            {
                if (secondCard.Points >= thirdCard.Points)
                {
                    return firstCard.Points + secondCard.Points;
                }
                else
                {
                    return firstCard.Points + thirdCard.Points;
                }
            }
            else if (secondCard.Name == "7" && secondCard.Type == "Spatia")
            {
                if (firstCard.Points >= thirdCard.Points)
                {
                    return firstCard.Points + secondCard.Points;
                }
                else
                {
                    return secondCard.Points + thirdCard.Points;
                }
            }
            else if (thirdCard.Name == "7" && thirdCard.Type == "Spatia")
            {
                if (secondCard.Points >= firstCard.Points)
                {
                    return secondCard.Points + thirdCard.Points;
                }
                else
                {
                    return firstCard.Points + thirdCard.Points;
                }
            }

            if (firstCard.Points > secondCard.Points && thirdCard.Points < firstCard.Points)
            {
                sum = firstCard.Points;
            }
            else if (thirdCard.Points > firstCard.Points && thirdCard.Points > secondCard.Points)
            {
                sum = thirdCard.Points;
            }
            else
            {
                sum = secondCard.Points;
            }
            return sum;
        }


    }
}
