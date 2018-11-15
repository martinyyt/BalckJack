using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class PlayGame
    {
        static Player playerOne = new Player("Player");
        static Player dealer = new Player("Dealer"); // the dealer will hit untill 16!!!
        static Deck deck = new Deck();
        static bool playerStay = false;
        static bool dealerStay = false;

        static void PlayOneTurn()
        {
            deck.Deal(playerOne, dealer);
            do
            {
                Console.WriteLine("Dealer has: {0}", dealer.ShowHiddenHand());
                Console.WriteLine("{0} you have: {1}", playerOne.Name, playerOne.ShowHand());
                Console.WriteLine("1-Hit / 2-Stay");
                int choice = 0;
                if (!playerStay)
                {
                    do
                    {
                        if (!int.TryParse(Console.ReadLine(), out choice))
                        {
                            Console.WriteLine("Choose 1 or 2");
                        }
                        else if (choice != 1 && choice != 2)
                        {
                            Console.WriteLine("Choose 1 or 2");
                        }
                        if (choice == 2)
                        {
                            playerStay = true;
                        }
                    } while (choice != 1 && choice != 2); // choose if you hit or stay
                }
                if (!playerStay)
                {
                    playerOne.Hit(deck);
                }
                if (playerOne.GetHandWeigth() > 21)
                {
                    playerStay = true;
                }
                if (dealer.GetHandWeigth() < 17)
                {
                    dealer.Hit(deck);
                }
                else
                {
                    dealerStay = true;
                }
            } while (!dealerStay && !playerStay);

            Console.WriteLine("Dealer has: {0} / score: {1}", dealer.ShowHand(), dealer.GetHandWeigth());
            Console.WriteLine("{0} you have: {1} / score: {2}", playerOne.Name, playerOne.ShowHand(), playerOne.GetHandWeigth());
            if (playerOne.GetHandWeigth() > 21)
            {
                if (playerOne.GetHandWeigth() < dealer.GetHandWeigth())
                {
                    Console.WriteLine("You won"); //cash                    
                }
                else if (playerOne.GetHandWeigth() == dealer.GetHandWeigth())
                {
                    Console.WriteLine("It's a draw"); //cash
                }
                else if (playerOne.GetHandWeigth() > dealer.GetHandWeigth())
                {
                    Console.WriteLine("You lost"); //cash
                }
            } //if hand above 21
            else if (dealer.GetHandWeigth() > 21)
            {
                Console.WriteLine("You won");
            }
            else
            {
                if (playerOne.GetHandWeigth() > dealer.GetHandWeigth())
                {
                    Console.WriteLine("You won"); //cash                    
                }
                else if (playerOne.GetHandWeigth() == dealer.GetHandWeigth())
                {
                    Console.WriteLine("It's a draw"); //cash
                }
                else if (playerOne.GetHandWeigth() < dealer.GetHandWeigth())
                {
                    Console.WriteLine("You lost"); //cash
                }
            }
        }

        static void Main(string[] args)
        {
            PlayOneTurn();
        }
    }
}
