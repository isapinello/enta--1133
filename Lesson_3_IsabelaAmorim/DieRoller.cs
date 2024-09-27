using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3_IsabelaAmorim
{
    internal class DieRoller
    {
        public void Roll(int sides, out int userRoll, out int cpuRoll) //riting this way so that the GameManager can access the userRoll
                                                                       //and the cpuRoll
        {
            Random randomNumberMaker = new Random();

            userRoll = randomNumberMaker.Next(1, sides + 1);//this way the game can keep track of both the user and the cpu's scores and also
                                                            //the randomized rolls
            Console.WriteLine($"You rolled a {userRoll}");

            cpuRoll = randomNumberMaker.Next(1, sides + 1);
            Console.WriteLine($"The computer rolled a {cpuRoll}");
        }
    }
}
