using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Svara_Game.Models.CardTests
{

    [TestFixture]
    public class CardTests
    {

        private Card testedCard = new Card("Pesho", "Karo", 10);


        [Test]
        public void TestConstructorShouldBeFine()
        {
           
            Assert.AreEqual("Pesho", testedCard.Name);
            Assert.AreEqual("Karo",testedCard.Type);
            Assert.AreEqual(10,testedCard.Points);
        }

        [Test]
        public void GetCorrectToString()
        {
            string expectedResult = $"Card : Name: Pesho -> Type: Karo -> Points: 10";

            Assert.AreEqual(expectedResult, testedCard.ToString());
        }

        [Test]
        public void WrongToStringReturn()
        {
            string expectedResult = $"Card : Name: Pesho1 -> Type: Karo -> Points: 10";

            Assert.AreNotEqual(expectedResult, testedCard.ToString());
        }


    }



}
