using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Player
    {
        private string name;
        private List<Card> hand;
        private int cash;

        internal int Cash { get => cash; set => cash = value; }
        internal string Name { get => name; set => name = value; }
        internal List<Card> Hand { get => hand; set => hand = value; }

        internal Player(string name)
        {
            this.Name = name;
            this.Hand = new List<Card>();
            this.Cash = 2000;
        }

        internal void Hit(Deck deck)
        {
            this.Hand.Add(deck.Draw());
        }

        internal int GetHandWeigth() // get this working with the Aces!!!
        {
            int weigth = 0;
            foreach (var card in this.Hand)
            {
                weigth += card.Weigth;
            }
            return weigth;
        }

        internal string ShowHand()
        {
            return string.Concat(this.Hand);
        }

        internal string ShowHiddenHand()
        {
            List<string> hiddenHand = new List<string>();
            for (int i = 0; i < this.Hand.Count; i++)
            {
                if (i==0)
                {
                    hiddenHand.Add(this.Hand[i].ToString());
                }
                else
                {
                    hiddenHand.Add("{hidden card}");
                }
            }
            return string.Concat(hiddenHand);
        }

        public override string ToString()
        {
            return string.Format("{0} has {1} / {2} cash", Name, string.Concat(Hand), Cash);
        }
    }
}
