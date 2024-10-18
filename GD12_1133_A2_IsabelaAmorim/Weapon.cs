using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitanExplorer
{
    public class Weapon
    {
        public string Name { get; }
        public int DiceSides { get; }

        public Weapon(string name, int diceSides)
        {
            Name = name;
            DiceSides = diceSides;
        }
    }
}
