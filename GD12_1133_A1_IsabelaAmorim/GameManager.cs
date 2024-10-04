using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3_IsabelaAmorim
{
    internal class GameManager
    {
        public bool sixSidedDiceUsed = false;
        public bool eightSidedDiceUsed = false;
        public bool twelveSidedDiceUsed = false;
        public bool twentySidedDiceUsed = false;
        public bool specialDiceUsed = false;
        public int maxNumberRounds = 5;
        public bool isCpuGame = false;
        public Player player1;
        public Player player2;
        public List<int> cpuUsedDice = new List<int>(); //List to keep track of used dice by CPU

        DiceManager diceManager = new DiceManager();
        IntroOutro anyMessage = new IntroOutro();

        private bool AllDiceUsed()
        {
            return diceManager.AllDiceUsed();
        }

        internal void Rules()
        {
            string[] ruleBook = new string[24];
            ruleBook[0] = "   _____________________________________________________________";
            ruleBook[1] = " / \\                                                            \\";
            ruleBook[2] = "|   |                       ~Rules Scroll~                       |";
            ruleBook[3] = "|   |                                                            |";
            ruleBook[4] = " \\__| You'll play a game against the computer.                   |";
            ruleBook[5] = "    | Each of the players shall choose a dice with either        |";
            ruleBook[6] = "    | 6 sides, 8 sides, 12 sides, 20 sides or a *Special Dice*.  |";
            ruleBook[7] = "    | The *Special Dice* is a dice with 999 sides                |";
            ruleBook[8] = "    | that you can use as a wild card.                           |";
            ruleBook[9] = "    | When you choose your dice,                                 |";
            ruleBook[10] = "    | you will roll it against the computer or against a friend  |";
            ruleBook[11] = "    | (They are Player 2), that will also choose another dice    |";
            ruleBook[12] = "    | (it's not necessaraly the same as yours).                  |";
            ruleBook[13] = "    | Player 1 will go first!                                    |";
            ruleBook[14] = "    | Whoever has the higher victories wins and gains            |";
            ruleBook[15] = "    | One point for each game that they won                      |";
            ruleBook[16] = "    | (In case of a tie, both receive one point)                 |";
            ruleBook[17] = "    | You'll then play again,                                    |";
            ruleBook[18] = "    | but now you can't choose the same dice as before           |";
            ruleBook[19] = "    | The game goes on until the die ends,                       |";
            ruleBook[20] = "    | revealing the winner and its score.                        |";
            ruleBook[21] = "    |   _________________________________________________________|___";
            ruleBook[22] = "    |  /                                                            /";
            ruleBook[23] = "    \\_/____________________________________________________________/ Art made by \"dc\" on https://www.asciiart.eu/art-and-design/borders";
            
            for (int i = 0; i < ruleBook.Length; i++)
            {
                Console.WriteLine(ruleBook[i]);
            }
        }
        internal void PlayGame()
        {
            anyMessage.Welcome();

            Console.WriteLine(" Would you like to play? \nType 1 for yes and 2 for no:");
            string message = Console.ReadLine();

            if (message == "1")
            {
                Console.WriteLine("\nLet's begin then!");

                // Player 1 setup
                player1 = new Player();
                Console.WriteLine("\nPlayer 1:");
                player1.SetName();

                // Determine if the game is against the CPU or another player
                Console.WriteLine("\nDo you want Player 2 to be a friend or the Computer? \n Press 1 for CPU and 2 for another player:");
                string opponentChoice = Console.ReadLine();

                if (opponentChoice == "2")
                {
                    isCpuGame = false; //Blocks the CPU random rolls and makes the player 2 have to set its rolls manually

                    //Player 2 setup for human opponent
                    player2 = new Player();
                    Console.WriteLine("\nPlayer 2:");
                    player2.SetName();
                }
                else
                {
                    isCpuGame = true;

                    //Player 2 setup for CPU opponent
                    player2 = new Player { Name = "CPU" };
                }

                Console.WriteLine("\nDo you know how to play? \n Press 1 to see the rules or any other key to go directly into gameplay.");
                string message2 = Console.ReadLine();

                if (message2 == "1")
                {
                    Rules();
                    Console.WriteLine("\n---Let's play then!---");
                }

                if (!AllDiceUsed())
                {
                    for (int i = 0; i < maxNumberRounds; i++)
                    {
                        Console.WriteLine("\n---This is round " + (i + 1) + "---");
                        Roller();
                    }
                    EndGame();
                }
                else
                {
                    EndGame();
                }
            }
            else if (message == "2")
            {
                Console.WriteLine(" Oh... Okay :(");
            }
            else
            {
                Console.WriteLine(" Type only 1 or 2!");
                PlayGame();
            }
        }
        public void Roller()
        {
            DieRoller dieRollerInstance = new DieRoller();

            //Player 1 chooses their dice
            Console.WriteLine($" {player1.Name}, it's your turn. Choose your dice.");
            int player1Dice = diceManager.SelectDice();
            int player2Dice;

            if (isCpuGame)
            {
                // CPU randomly selects a dice, ensuring it hasn't been used before
                Random random = new Random();
                int[] possibleDice = { 6, 8, 12, 20, 999 }; //Keep track of it in an array

                do
                {
                    player2Dice = possibleDice[random.Next(possibleDice.Length)];
                }
                while (cpuUsedDice.Contains(player2Dice));

                cpuUsedDice.Add(player2Dice); //Add the selected dice to the used list
                Console.WriteLine($" The computer chose a {player2Dice}-sided dice.");
            }
            else
            {
                //Player 2 (human) chooses their dice independently
                Console.WriteLine($" {player2.Name}, it's your turn. Choose your dice.");
                player2Dice = diceManager.SelectDice2();
            }

            // Rolls the dice
            int player1Roll = dieRollerInstance.RollDice(player1Dice);
            int player2Roll = dieRollerInstance.RollDice(player2Dice);

            // Output the rolls
            Console.WriteLine($"\n {player1.Name} rolled a {player1Roll} with the {player1Dice}-sided dice.");
            Console.WriteLine($" {(isCpuGame ? "CPU" : player2.Name)} rolled a {player2Roll} with the {player2Dice}-sided dice.");

            UpdateScores(player1Roll, player2Roll);
        }

        private void UpdateScores(int player1Roll, int player2Roll)
        {
            if (player1Roll > player2Roll)
            {
                Console.WriteLine($"\n {player1.Name} wins this round!");
                player1.Score += 1;
            }
            else if (player1Roll < player2Roll)
            {
                Console.WriteLine($"\n {player2.Name} wins this round!");
                player2.Score += 1;
            }
            else
            {
                Console.WriteLine("\n It's a tie this round!");
                player1.Score += 1;
                player2.Score += 1;
            }
        }
        private void EndGame()
        {
            Console.WriteLine("\n You used all of the dice! Let's see who won...");
            if (player1.Score > player2.Score)
            {
                Console.WriteLine($" {player1.Name} wins!");
            }
            else if (player1.Score < player2.Score)
            {
                Console.WriteLine($" {player2.Name} wins!");
            }
            else
            {
                Console.WriteLine(" Oh crap, it's a tie!");
            }

            anyMessage.Goodbye();
            Console.WriteLine("\nDo you want to play again?\n Type 1 for yes and any other key  for no");
            string playAgain = Console.ReadLine();

            if (playAgain == "1")
            {
                ResetGame();
                PlayGame();
            }
        }
        private void ResetGame()
        {
            // Reset scores
            player1.Score = 0;
            player2.Score = 0;

            // Clear used dice list
            cpuUsedDice.Clear();

            // Reset dice usage flags
            sixSidedDiceUsed = false;
            eightSidedDiceUsed = false;
            twelveSidedDiceUsed = false;
            twentySidedDiceUsed = false;
            specialDiceUsed = false;

            // Reset dice usage in DiceManager
            diceManager.ResetDiceUsage();
        }
    }
}
