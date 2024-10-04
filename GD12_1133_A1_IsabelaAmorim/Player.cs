using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3_IsabelaAmorim
{
    public class Player //For all types of players (Player 1 AND 2)
    {
        public string Name { get; set; } //Can either get or set name without repeating the code
        public int Score { get; set; } = 0; //Same thing with the score

        public void SetName()
        {
            Console.WriteLine("\n What's your name?:");
            Name = Console.ReadLine();
        }
    }
}
