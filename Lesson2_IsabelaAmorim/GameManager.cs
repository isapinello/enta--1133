using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2_IsabelaAmorim
{
    internal class GameManager
    {
        public void PlayGame()
        {
            Console.WriteLine("Welcome to The Die Game"); //Welcome message

            DieRoller dieRollerInstance;

            dieRollerInstance = new DieRoller();

            Console.Write("A Game about rolling a dice with ");
            Console.Write(dieRollerInstance.numberOfSides);
            Console.Write(" sides.");

            dieRollerInstance.RollDice(); //connecting to the DieRoller class
        }
      
    }
}
