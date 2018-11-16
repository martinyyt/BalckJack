using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Deck
    {
        private Stack<Card> cards;

        internal Stack<Card> Cards { get => cards; set => cards = value; }
        internal int CardCount { get => cards.Count; }

        public Deck()
        {
            var cards = new List<Card>();
            for (int face = 2; face < Enum.GetNames(typeof(Face)).Length + 2; face++)
            {
                for (int suit = 0; suit < Enum.GetNames(typeof(Suit)).Length; suit++)
                {
                    cards.Add(new Card((Face)face, (Suit)suit));
                }
            }
            Shuffle(cards);

            var cardsStack = new Stack<Card>();
            for (int i = 0; i < cards.Count; i++)
            {
                cardsStack.Push(cards[i]);
            }
            this.Cards = cardsStack;
        }
        static Random random = new Random();

        public Card Draw()
        {
            return this.Cards.Pop();
        }

        public void Draw(Player player)
        {
            player.Hand.Add(this.Draw());
        }

        public void Deal(Player playerOne, Player playerTwo)
        {
            playerOne.Hit(this);
            playerTwo.Hit(this);
            playerOne.Hit(this);
            playerTwo.Hit(this);
        }

        private static void Shuffle(List<Card> cards)
        {
            for (int i = 0; i < cards.Count * 2; i++)
            {
                int first = random.Next(0, 51);
                int second = random.Next(0, 51);
                var temp = cards[first];
                cards[first] = cards[second];
                cards[second] = temp;
            }
        }

        public override string ToString()
        {
            return string.Concat(this.Cards);
        }
    }
}
