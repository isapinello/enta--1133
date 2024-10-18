using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitanExplorer
{
    public class Player
    {
        public int HP { get; private set; } = 100;
        public List<Weapon> Inventory { get; } // List to store available weapons
        private Weapon _currentWeapon; // Currently equipped weapon

        public Player()
        {
            HP = 100;
            Inventory = new List<Weapon>
            {
                new Weapon("Pickaxe", 20), // d20
                new Weapon("Machete", 25),  // d25
                new Weapon("Flamethrower", 30)   // d30
            };
            _currentWeapon = Inventory[0]; // Default to the first weapon
        }

        public int RollDice()
        {
            Random rand = new Random();
            return rand.Next(1, _currentWeapon.DiceSides + 1); // Roll based on current weapon
        }

        public void TakeDamage(int damage)
        {
            HP -= damage;
            if (HP < 0) HP = 0;
        }

        // The ChooseWeapon() method allows the player to pick a weapon from the inventory
        public void ChooseWeapon()
        {
            Console.WriteLine("Choose your weapon:");
            for (int i = 0; i < Inventory.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {Inventory[i].Name} (d{Inventory[i].DiceSides})");
            }

            int choice;
            while (true)
            {
                Console.Write("Enter the number of your choice: ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice <= Inventory.Count)
                {
                    _currentWeapon = Inventory[choice - 1]; // Set the chosen weapon
                    Console.WriteLine($"You have selected: {_currentWeapon.Name}");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
        }
    }
}
