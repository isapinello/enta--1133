using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3_IsabelaAmorim
{
    internal class GameManager
    {
        public bool sixSidedDiceUsed = false; //setting these as false so that the program can check later if a dice has already been used
        public bool eightSidedDiceUsed = false;
        public bool twelveSidedDiceUsed = false;
        public bool twentySidedDiceUsed = false;

        public int playerScore = 0;
        public int cpuScore = 0;

        IntroOutro anyMessage = new IntroOutro();

        private bool AllDiceUsed() //Checking if all the die has been used, if so it will go to the end of the game later on
        {
            return sixSidedDiceUsed && eightSidedDiceUsed && twelveSidedDiceUsed && twentySidedDiceUsed;
        }

        internal void PlayGame()
        {
            anyMessage.Welcome();

            Console.WriteLine("Would you like to play? \n Type 1 for yes and 2 for no:");
            string message = Console.ReadLine();

            if (message == "1")
            {
                Console.WriteLine("Let's begin then!");
                Player playerInstance = new Player();
                playerInstance.PlayerCreation();

                Console.WriteLine("\n Do you know how to play? \n 1 for yes and 2 for no. Only type 1 or 2.");
                string message2 = Console.ReadLine();

                if (message2 == "1")
                {
                    Console.WriteLine("Let's play then!");
                    Round1();
                }
                else if (message2 == "2")
                {
                    Console.WriteLine("You'll play a game against the computer. Each of the players shall choose a dice with either 6 sides, 8 sides, 12 sides or 20 sides.");
                    Console.WriteLine("The Human will always start");
                    Console.WriteLine("When you choose your dice, you shall roll it against the computer that also chose the same dice");
                    Console.WriteLine("Whoever has the higher number wins and gains the score of the dice's number of sides");
                    Console.WriteLine("(In case of a tie, both receive the same score)");
                    Console.WriteLine("You'll then play again, but now you can't choose the same dice as before");
                    Console.WriteLine("The game goes on until the die ends, revealing the winner and its score.");
                    Console.WriteLine("\n Let's play then!");
                    Round1();
                }
                else
                {
                    Console.WriteLine("I said only 1 or 2!!");
                    PlayGame();
                }
            }
            
            else if (message == "2")
            {
                Console.WriteLine("Oh... Okay:(");
            }
            
            else
            {
                Console.WriteLine("Please type only 1 or 2");
                PlayGame();
            }
        }

        private void Round1()
        {
            Console.WriteLine("\n--- This is the first round ---");
            Roller();
            if (!AllDiceUsed())
            {
                Round2();
            }
            else
            {
                EndGame();
            }
        }

        private void Round2()
        {
            Console.WriteLine("\n--- This is the second round ---");
            Roller();
            if (!AllDiceUsed())
            {
                Round3();
            }
            else
            {
                EndGame();
            }
        }

        private void Round3()
        {
            Console.WriteLine("\n--- This is the third round ---");
            Roller();
            if (!AllDiceUsed())
            {
                Round4();
            }
            else
            {
                EndGame();
            }
        }

        private void Round4()
        {
            Console.WriteLine("\n--- This is the fourth round ---");
            Roller();
            if (!AllDiceUsed())
            {
                EndGame();
            }
            else
            {
                EndGame();
            }
        }

        private void EndGame()
        {
            Console.WriteLine("\nYou used all of the dice! Let's see who won...");
            if (cpuScore > playerScore)
            {
                Console.WriteLine("\nThe computer has more points");
                Console.WriteLine("\nMuahaha, the machine always wins!!");
            }
            else if (cpuScore < playerScore)
            {
                Console.WriteLine("\nThe Human has more points!");
                Console.WriteLine("\nDamn you Human! You won because of pure luck! >:(");
            }
            else
            {
                Console.WriteLine("\nOh crap! A tie!");
            }

            anyMessage.Goodbye();
        }

        public void Roller()
        {
            DieRoller dieRollerInstance = new DieRoller();

            Console.WriteLine("Which die will you choose? Type the number of sides (6, 8, 12, or 20):");
            string messagedice1 = Console.ReadLine();

            int sides = 0; //this int goes back to the DieRoller to "assemble" the sides choice into the randomizer
            bool validChoice = false; //put this "extra" validation because it wasn't working without it

            if (messagedice1 == "6" && !sixSidedDiceUsed)
            {
                sides = 6;
                sixSidedDiceUsed = true;
                validChoice = true;
            }
            else if (messagedice1 == "8" && !eightSidedDiceUsed)
            {
                sides = 8;
                eightSidedDiceUsed = true;
                validChoice = true;
            }
            else if (messagedice1 == "12" && !twelveSidedDiceUsed)
            {
                sides = 12;
                twelveSidedDiceUsed = true;
                validChoice = true;
            }
            else if (messagedice1 == "20" && !twentySidedDiceUsed)
            {
                sides = 20;
                twentySidedDiceUsed = true;
                validChoice = true;
            }
            else
            {
                Console.WriteLine("Invalid choice or the die has already been used. Please choose another.");
                Roller(); // Call Roller again if the choice was invalid
                return; // Searched that this method avoids further execution
            }

            // Rolls the die and update scores
            int userRoll;
            int cpuRoll;
            dieRollerInstance.Roll(sides, out userRoll, out cpuRoll);
            UpdateScores(userRoll, cpuRoll, sides);
        }

        private void UpdateScores(int userRoll, int cpuRoll, int sides)
        {
            if (userRoll > cpuRoll)
            {
                Console.WriteLine("You won this round!");
                playerScore += sides; // Add to player's score
            }
            else if (userRoll < cpuRoll)
            {
                Console.WriteLine("The computer won this round!");
                cpuScore += sides; // Add to CPU's score
            }
            else
            {
                Console.WriteLine("It's a tie for this round...");
                playerScore += sides; // Both receive the same score
                cpuScore += sides;
            }
        }
    }
}
