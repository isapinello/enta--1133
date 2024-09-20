using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2_IsabelaAmorim
{
    internal class DieRoller
    {
        public int numberOfSides = 6;
        private int total = 0; //putting to "total" function outside of RollDice so we could use it for other purposes
        public void RollDice() //System to make the dice roll
        {
            Console.WriteLine("");
            Console.WriteLine("Minimum Roll:");
            Console.WriteLine(1);
            Console.WriteLine("Maximum Roll:");
            Console.WriteLine(numberOfSides);

            Random randomNumberMaker = new Random(); //Using built-in class "Random"

            total = randomNumberMaker.Next(1, numberOfSides + 1); //Used += so that the previous value is automatically added and inserted into the next "total"
            total += randomNumberMaker.Next(1, numberOfSides + 1);
            total += randomNumberMaker.Next(1, numberOfSides + 1);
            total += randomNumberMaker.Next(1, numberOfSides + 1);

 
            Console.WriteLine("The Total is = " + total);
        }
    }
}
