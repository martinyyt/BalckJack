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
        static int bet = 20;
        const string win = "won";
        const string lost = "lost";
        const string draw = "draw";

        static void EndTurn(string winner)
        {
            switch (winner)
            {
                case "won":
                    playerOne.Cash += bet;
                    Console.WriteLine("You won {0} credits", bet);
                    Console.WriteLine("You have {0} ", playerOne.Cash);
                    Console.WriteLine();
                    break;
                case "lost":
                    playerOne.Cash -= bet;
                    Console.WriteLine("You lost {0} credits", bet);
                    Console.WriteLine("You have {0} ", playerOne.Cash);
                    Console.WriteLine();
                    break;
                default:
                    Console.WriteLine("It's a draw");
                    Console.WriteLine("You have {0} ", playerOne.Cash);
                    Console.WriteLine();
                    break;
            }
        }

        static void PlayOneTurn()
        {
            deck.Deal(playerOne, dealer);
            do
            {
                int choice = 0;
                if (!playerOne.Stay)
                {
                    Console.WriteLine("Dealer has: {0}", dealer.ShowHiddenHand());
                    Console.WriteLine("{0} you have: {1}", playerOne.Name, playerOne.ShowHand());
                    Console.WriteLine("1-Hit / 2-Stay");
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
                            playerOne.Stay = true;
                        }
                    } while (choice != 1 && choice != 2); // choose if you hit or stay
                }
                if (!playerOne.Stay)
                {
                    playerOne.Hit(deck);
                }
                if (playerOne.GetHandWeigth() > 21)
                {
                    playerOne.Stay = true;
                }
                if (dealer.GetHandWeigth() < 17)
                {
                    dealer.Hit(deck);
                }
                else
                {
                    dealer.Stay = true;
                }
            } while (!dealer.Stay || !playerOne.Stay);

            Console.WriteLine("Dealer has: {0} / score: {1}", dealer.ShowHand(), dealer.GetHandWeigth());
            Console.WriteLine("{0} you have: {1} / score: {2}", playerOne.Name, playerOne.ShowHand(), playerOne.GetHandWeigth());
            if (playerOne.GetHandWeigth() > 21)
            {
                if (playerOne.GetHandWeigth() < dealer.GetHandWeigth()) //win
                {
                    EndTurn(win);
                }
                else if (playerOne.GetHandWeigth() == dealer.GetHandWeigth()) //draw
                {
                    EndTurn(draw);
                }
                else if (playerOne.GetHandWeigth() > dealer.GetHandWeigth()) //lost
                {
                    EndTurn(lost);
                }
            } //if hand above 21
            else if (dealer.GetHandWeigth() > 21) //win
            {
                EndTurn(win);
            }
            else
            {
                if (playerOne.GetHandWeigth() > dealer.GetHandWeigth()) //win
                {
                    EndTurn(win);
                }
                else if (playerOne.GetHandWeigth() == dealer.GetHandWeigth()) //draw
                {
                    EndTurn(draw);
                }
                else if (playerOne.GetHandWeigth() < dealer.GetHandWeigth()) //lost
                {
                    EndTurn(lost);
                }
            }
            dealer.ClearHand();
            playerOne.ClearHand();
            playerOne.Stay = false;
            dealer.Stay = false;
            deck = new Deck();
        }

        static void Main(string[] args)
        {
            bool play = true;
            do
            {
                Console.WriteLine("Please bet");
                do
                {
                    if (!int.TryParse(Console.ReadLine(), out bet) || bet < 1)
                    {
                        Console.WriteLine("Enter a valid bet greater than 0");
                    }
                } while (bet < 1);
                
                PlayOneTurn();

                Console.WriteLine("Do you want to stop playing?\n" +
                    "Press S to stop");
                string answer = Console.ReadLine();
                if (answer == "s" || answer == "S")
                {
                    play = false;
                }
                Console.WriteLine();
            } while (play);
        }
    }
}
