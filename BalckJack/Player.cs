using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Player
    {
        private string name;
        private List<Card> hand;
        private int cash;

        public int Cash { get => cash; set => cash = value; }
        public string Name { get => name; set => name = value; }
        public List<Card> Hand { get => hand; set => hand = value; }

        public Player(string name)
        {
            this.Name = name;
            this.Hand = new List<Card>();
            this.Cash = 2000;
        }

        public void Hit(Deck deck)
        {
            this.Hand.Add(deck.Draw());
        }

        public int GetHandWeigth() // get this working with the Aces!!!
        {
            int weigth = 0;
            foreach (var card in this.Hand)
            {
                weigth += card.Weigth;
            }
            if (weigth>21)
            {
                int aceCount = 0;
                for (int i = 0; i < this.Hand.Count; i++)
                {
                    if (this.Hand[i].AltWeigth==1)
                    {
                        aceCount++;
                    }
                }
                for (int i = 1; i <= aceCount; i++)
                {
                    weigth -= 10;
                    if (weigth<22)
                    {
                        return weigth;
                    }
                }
            }
            return weigth;
        }

        public void DrawSpecificCard()
        {

        }

        public string ShowHand()
        {
            return string.Concat(this.Hand);
        }

        public string ShowHiddenHand()
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
