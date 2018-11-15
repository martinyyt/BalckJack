using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    enum Face
    {
        Ace = 11, Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7,
        Eight = 8, Nine = 9, Ten = 10, Jack = 12, Qeen = 13, King = 14
    }
    enum Suit
    {
        Heart, Diamond, Spade, Club
    }
    class Card
    {
        private Face face;
        private Suit suit;
        private int weigth;
        private int altWeigth;

        public Card(Face face, Suit suit)
        {
            this.Face = face;
            this.Suit = suit;
            this.weigth = (int)face;
            if ((int)face > 11)
            {
                this.weigth = 10;
            }
            this.altWeigth = this.weigth;
            if ((int)face == 11)
            {
                this.altWeigth = 1;
            }
        }

        public int Weigth { get => weigth; }
        public int AltWeigth { get => altWeigth; }
        internal Face Face { get => face; set => face = value; }
        internal Suit Suit { get => suit; set => suit = value; }

        public override string ToString()
        {
            return string.Format("{{{0}/{1}}}", Face, Suit);
        }
    }
}
