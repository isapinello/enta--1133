using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3_IsabelaAmorim
{
    public class Player
    {
        public void PlayerCreation()
        {
            Console.WriteLine("Hey, What's your name then?");

            string message1 = Console.ReadLine();

            Console.WriteLine("Hello " + message1);
        }
    }
}
