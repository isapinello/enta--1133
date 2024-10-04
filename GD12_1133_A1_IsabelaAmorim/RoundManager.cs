using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3_IsabelaAmorim
{
    internal class RoundManager
    {

        public int roundCounter = 0;
        public int maxAmountOfRounds = 3;

        public void ContinuePlay()
        {
            roundCounter += 1;
            Console.WriteLine("This is round " + roundCounter);
            
            if (roundCounter >= maxAmountOfRounds) // if max number of rounds is reached, finish game (probably with outro)
            {
                Console.WriteLine("Yay game finished now");
            }

            else if (roundCounter < maxAmountOfRounds) // if max number of rounds is not reached, just continue playing.
            {
                GameManager rollAgain = new GameManager();
                rollAgain.Roller();
            }
            
        }

    }
}
