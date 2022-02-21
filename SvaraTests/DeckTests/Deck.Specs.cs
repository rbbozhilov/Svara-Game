using Svara_Game.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace SvaraTests.DeckTests
{
    public class DeckSpecs
    {


        [Fact]
        public void CreatingInstance_ShouldBeCorrect()
        {
            //Arrange

            var deck = new Deck();
            var index = 0;

            var expectedCards = new List<Card>()
            {
                new Card("7","Karo",7),
                new Card("7","Pika",7),
                new Card("7","Spatia",11),
                new Card("7","Kupa",7),
                new Card("8","Karo",8),
                new Card("8","Pika",8),
                new Card("8","Spatia",8),
                new Card("8","Kupa",8),
                new Card("9","Karo",9),
                new Card("9","Pika",9),
                new Card("9","Spatia",9),
                new Card("9","Kupa",9),
                new Card("10","Karo",10),
                new Card("10","Pika",10),
                new Card("10","Spatia",10),
                new Card("10","Kupa",10),
                new Card("Aso","Karo",11),
                new Card("Aso","Pika",11),
                new Card("Aso","Spatia",11),
                new Card("Aso","Kupa",11),
                new Card("Dama","Karo",10),
                new Card("Dama","Pika",10),
                new Card("Dama","Spatia",10),
                new Card("Dama","Kupa",10),
                new Card("Pop","Karo",10),
                new Card("Pop","Pika",10),
                new Card("Pop","Spatia",10),
                new Card("Pop","Kupa",10),
                new Card("Vale","Karo",10),
                new Card("Vale","Pika",10),
                new Card("Vale","Spatia",10),
                new Card("Vale","Kupa",10),
            };

            //Assert

            foreach (var card in deck.Cards)
            {
                Assert.Equal(expectedCards[index].Name, card.Name);
                Assert.Equal(expectedCards[index].Type, card.Type);
                Assert.Equal(expectedCards[index].Points, card.Points);
                index++;
            }

        }



        [Fact]
        public void GettingCard_ShouldReturnOneCard()
        {
            //Arrange

            var deck = new Deck();
            var expectedCard = new Card("7", "Karo", 7);

            //Act

            var actualCard = deck.GetCard();

            //Assert

            Assert.Equal(expectedCard.Name, actualCard.Name);
            Assert.Equal(expectedCard.Type, actualCard.Type);
            Assert.Equal(expectedCard.Points, actualCard.Points);



        }
     
    }

}
