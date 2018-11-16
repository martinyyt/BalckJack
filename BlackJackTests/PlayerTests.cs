using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlackJack;
using System.Collections.Generic;


namespace BlackJackTests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void GetHandWeigthTest()
        {
            // Arrange
            Player player = new Player("player");
            player.Hand = new List<Card> { new Card(Face.Ace, Suit.Club), new Card(Face.King, Suit.Club),
                new Card(Face.Ace, Suit.Diamond), new Card(Face.Seven, Suit.Club) };

            // Act
            int result = player.GetHandWeigth();

            // Assert
            Assert.AreEqual(19, result);

        }
        [TestMethod]
        public void GetHandWeigthTest2()
        {
            // Arrange
            Player player = new Player("player");
            player.Hand = new List<Card> { new Card(Face.Ace, Suit.Club), new Card(Face.Two, Suit.Club),
                new Card(Face.Ace, Suit.Diamond), new Card(Face.Seven, Suit.Club) };

            // Act
            int result = player.GetHandWeigth();

            // Assert
            Assert.AreEqual(21, result);

        }
        [TestMethod]
        public void GetHandWeigthTest3()
        {
            // Arrange
            Player player = new Player("player");
            player.Hand = new List<Card> { new Card(Face.Ace, Suit.Club), new Card(Face.Ace, Suit.Club),
                new Card(Face.Ace, Suit.Diamond), new Card(Face.Seven, Suit.Club), new Card(Face.Ten, Suit.Club)  };

            // Act
            int result = player.GetHandWeigth();

            // Assert
            Assert.AreEqual(20, result);

        }
    }
}