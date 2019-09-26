using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liar_s_dice
{
    class Program
    {
        static int[] myPlayerHand = new int[5];
        static int[] myEnemyHand = new int[5];
        static int myPlayerDiceAmount = 0;
        static int myPlayerDice = 0;
        static int tempCorrectDices = 0;
        static bool tempRunning = true;
        static bool tempCorrectInput = false;

        static void Main(string[] args)
        {
            do
            {
                TheHoleGame();

            } while (tempRunning == true);
        }

        static void TheHoleGame()
        {
            while (tempCorrectInput == false)
            {
                Console.WriteLine("Welcome my friend, My name is Davy Jones, have ye come to challange me?!");
                Console.WriteLine("If ye be brave or fool enough to face a pirates curse.");
                Console.WriteLine("(Yes = 1, No = 2)");
                Console.WriteLine("Then press ENTER to proceed...");

                int tempValueChallange = Convert.ToInt32(Console.ReadLine());

                //checks if player choose option 1 or 2
                if (tempValueChallange == 1 || tempValueChallange == 2)
                {
                    tempCorrectInput = true;

                    //if player choose option 1 then the player plays agian
                    if (tempValueChallange == 1)
                    {
                        Console.Clear();
                        Hands();
                        Game();
                        End();
                    }

                    //if player choose option 2 then the game quits
                    else
                    {
                        Environment.Exit(0);
                    }
                }

                //if player dosen't chooses either of the options then the player trys agian until player does
                else
                {
                    Console.Clear();
                    Console.WriteLine("Davy Jones: Grrr, ye must type either 1 or 2!");
                }
            }
        
            Console.ReadLine();
            Console.Clear();
        }

        static void Hands()
        {
            GenerateHands();

            //shows the players hand
            Console.WriteLine("---------------------------");
            Console.WriteLine("Your hand...");

            PrintHand();

            Console.WriteLine("---------------------------");

            tempCorrectInput = false;

            //player guesses what dice numbers the enemy has
            while (tempCorrectInput == false)
            {
                Console.WriteLine("Davy Jones: Which dice value would ye like to guess on son?");

                int.TryParse(Console.ReadLine(), out myPlayerDice);

                //player choose a number between 1 and 6
                if (myPlayerDice > 0 && myPlayerDice < 7)
                {
                    tempCorrectInput = true;
                }
                //if the player didn't choose a number between 1 and 6 then the player need to try agian until the player chooses a number between 1 and 6
                else
                {
                    Console.WriteLine("Davy Jones: Come on choose any number between 1-6 haven't ye played before, fool!");
                }
            }
            Console.Clear();
        }

        static void Game()
        {
            tempCorrectInput = false;

            //Player choose how many dices of the value the player choose before
            while (tempCorrectInput == false)
            {
                Console.WriteLine("Davy Jones: How many dices with the value " + myPlayerDice + " do ye think there are?");

                int.TryParse(Console.ReadLine(), out myPlayerDiceAmount);

                //if player choose a number between 1 and 10
                if (myPlayerDiceAmount > 0 && myPlayerDiceAmount < 11)
                {
                    tempCorrectInput = true;
                }

                //if the player didn't choose a number between 1 and 10 then the player need to try again until the player chooses a number between 1 and 10
                else
                {
                    Console.WriteLine("Ye should type a number between 1-10");
                }
            }

            tempCorrectInput = false;

            //checks if the pkayers anwser is right
            for (int i = 0; i < myPlayerHand.Length; i++)
            {
                if (myPlayerHand[i] == myPlayerDice)
                {
                    tempCorrectDices++;
                }
            }

            //checks if the players anwser is right
            for (int i = 0; i < myEnemyHand.Length; i++)
            {
                if (myEnemyHand[i] == myPlayerDice)
                {
                    tempCorrectDices++;
                }
            }

            Console.Clear();
        }

        static void End()
        {
            //shows player if he won
            if (tempCorrectDices == myPlayerDiceAmount)
            {
                Console.WriteLine("Davy Jones: Beginners luck! ");
                Console.WriteLine("(You guessed correctly that there we're " + myPlayerDiceAmount + " dices with the value " + myPlayerDice + ". There were " + tempCorrectDices + ".)");
                Console.WriteLine("Press ENTER to proceed...");
                Console.ReadLine();
                Console.Clear();
            }

            //shows player if he lost
            else
            {
                Console.WriteLine("Davy Jones: That was wrong. Ha! Ha! Ha! Ha!, One hundred years before the mast. Ye will serve!. ");
                Console.WriteLine("(You guessed that there we're " + myPlayerDiceAmount + " dices with the value " + myPlayerDice + ". There were " + tempCorrectDices + ".)");
                Console.WriteLine("Press ENTER to proceed...");
                Console.ReadLine();
                Console.Clear();
            }

            //asks player if he want to play again
            while (tempCorrectInput == false)
            {
                Console.WriteLine("Davy Jones: Do you want to challange me agian?(Yes = 1, No = 2)");
                Console.WriteLine("Then press ENTER to proceed...");

                int tempValueChallangeAgain = Convert.ToInt32(Console.ReadLine());

                //checks if player choose option 1 or 2
                if (tempValueChallangeAgain == 1 || tempValueChallangeAgain == 2)
                {
                    tempCorrectInput = true;

                    //if player choose option 1 then the player plays agian
                    if (tempValueChallangeAgain == 1)
                    {
                        Console.Clear();
                        tempCorrectDices = 0;
                    }

                    //if player choose option 2 then the game quits
                    else
                    {
                        Environment.Exit(0);
                    }
                }

                //if player dosen't chooses either of the options then the player trys agian until player does
                else
                {
                    Console.WriteLine("Davy Jones: Grrr, ye must type either 1 or 2!");
                }
            }
        }

        static void GenerateHands()
        {
            //generate players dices(hand))
            myPlayerHand = GenerateHandValue(myPlayerHand);

            //generate enemys dices(hand)
            myEnemyHand = GenerateHandValue(myEnemyHand);
        }

        //prints players hands
        static void PrintHand()
        {
            for (int i = 0; i < myPlayerHand.Length; i++)
            {
                Console.WriteLine(myPlayerHand[i]);
            }
        }
        
        //generate player and enemys dices
        static int[] GenerateHandValue(int[] anArray)
        {
            Random rNG = new Random();

            for (int i = 0; i < anArray.Length; i++)
            {
                anArray[i] = rNG.Next(1, 6);
            }

            return anArray;
        }
    }
}

