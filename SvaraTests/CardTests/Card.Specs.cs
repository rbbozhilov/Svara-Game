using Svara_Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SvaraTests.CardTests
{
    public class CardSpecs
    {

        [Fact]
        public void CreatingInstance_ShouldBeCorrect()
        {

            //Arrange

            var expectedName = "10";
            var expectedType = "Karo";
            var expectedPoints = 10;

            //Act

            var card = new Card(expectedName, expectedType, expectedPoints);

            //Assert

            Assert.Equal(expectedName, card.Name);
            Assert.Equal(expectedType, card.Type);
            Assert.Equal(expectedPoints, card.Points);

        }

        [Fact]
        public void TryingMethodToString()
        {
            //Arrange

            var expectedName = "10";
            var expectedType = "Karo";
            var expectedPoints = 10;
            var expectedString = $"Card : Name: {expectedName} -> Type: {expectedType} -> Points: {expectedPoints}";

            //Act

            var actualString = new Card(expectedName, expectedType, expectedPoints).ToString();

            //Assert

            Assert.Equal(expectedString, actualString);

        }


    }
}
