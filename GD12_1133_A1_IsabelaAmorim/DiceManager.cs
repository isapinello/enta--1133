using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3_IsabelaAmorim
{
    internal class DiceManager //Created another class outside the Game Manager because it was getting too confusing
    {
        //Used an array to track used dice
        private bool[] diceUsed = new bool[5]; // 5 die:6-sided, 8-sided, 12-sided, 20-sided, 999-sided (special)
        private bool[] diceUsed2 = new bool[5];

        private int[] diceSides = { 6, 8, 12, 20, 999 };

        public bool AllDiceUsed()
        {
            //Checks if all dice have been used
            foreach (bool used in diceUsed) //Used foreach since I used a bool collection of multiple die
            {
                if (!used)
                {
                    return false; //Return false if no dice used
                }
            }
            return true; //Return bool true if all dice were used, leading to the SelectDice()
        }
        public bool AllDiceUsed2() //Created 2 so that the Player 2 (Human) also has this restriction
        {
            foreach (bool used in diceUsed2) 
            {
                if (!used)
                {
                    return false; 
                }
            }
            return true; 
        }

        public int SelectDice()
        {
            while (true) //loop so that it doesn't have to keep calling the SelectDice() over and over again
            {
                Console.WriteLine(" Choose a dice (6, 8, 12, 20, or 00 for the special 999-sided dice):");
                string input = Console.ReadLine();

                int index = -1; //-1 since the index starts at 0

                //Determine which dice will be chosen based on the boolean
                if (input == "6") index = 0;
                else if (input == "8") index = 1;
                else if (input == "12") index = 2;
                else if (input == "20") index = 3;
                else if (input == "00") index = 4;

                //Checks if the input is valid and the dice wasn't used
                if (index != -1 && !diceUsed[index])
                {
                    diceUsed[index] = true; //Mark the dice as used
                    return diceSides[index]; //Return the number of sides "updating" the index as well
                }
                else
                {
                    Console.WriteLine("Invalid choice or dice already used. Please try again.");
                }
            }
        }
        public int SelectDice2() //Also for Player 2 (Human)
        {
            while (true) 
            {
                Console.WriteLine(" Choose a dice (6, 8, 12, 20, or 00 for the special 999-sided dice):");
                string input = Console.ReadLine();

                int index = -1;

                if (input == "6") index = 0;
                else if (input == "8") index = 1;
                else if (input == "12") index = 2;
                else if (input == "20") index = 3;
                else if (input == "00") index = 4;

                if (index != -1 && !diceUsed2[index])
                {
                    diceUsed2[index] = true; //Mark the dice as used
                    return diceSides[index]; //Return the number of sides "updating" the index as well
                }
                else
                {
                    Console.WriteLine(" Invalid choice or dice already used. Please try again.");
                }
            }
        }
        public void ResetDiceUsage()
        {
            // Reset all dice usage flags
            for (int i = 0; i < diceUsed.Length; i++)
            {
                diceUsed[i] = false;
            }

            for (int i = 0; i < diceUsed2.Length; i++)
            {
                diceUsed2[i] = false;
            }
        }
    }
}
