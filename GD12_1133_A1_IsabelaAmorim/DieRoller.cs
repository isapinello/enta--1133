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
        public int RollDice(int sides)
        {
            Random randomNumberMaker = new Random();
            int roll = randomNumberMaker.Next(1, sides + 1); // Generate a roll based on the number of sides
            return roll; // Return the roll value
        }
    }
}
