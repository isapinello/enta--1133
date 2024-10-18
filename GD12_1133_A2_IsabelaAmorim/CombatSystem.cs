using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TitanExplorer.Decomposer;

namespace TitanExplorer
{
    internal class CombatSystem
    {
        private Player _player;
        private List<Decomposer> _enemies; // List to hold multiple enemies

        public CombatSystem(Player player)
        {
            _player = player;
            _enemies = GetRandomEnemies(); // Get a random set of enemies when combat starts
        }

        // Method to randomly select multiple enemies
        private List<Decomposer> GetRandomEnemies()
        {
            Random rand = new Random();
            int enemyCount = rand.Next(1, 4); // Randomly choose 1 to 3 enemies
            var enemies = new List<Decomposer>();

            for (int i = 0; i < enemyCount; i++)
            {
                enemies.Add(GetRandomEnemy());
            }

            return enemies;
        }

        // Method to randomly select an enemy
        private Decomposer GetRandomEnemy()
        {
            Random rand = new Random();
            int enemyType = rand.Next(1, 4);

            return enemyType switch
            {
                1 => new Decomposer.SmallLarvae(),
                2 => new Decomposer.RoundWorm(),
                3 => new Decomposer.BoneCrusher(),
                _ => new Decomposer.SmallLarvae() // Fallback in case something goes wrong
            };
        }

        public void StartCombat()
        {
            Console.WriteLine($"You encounter {_enemies.Count} enemies!");

            foreach (var enemy in _enemies)
            {
                Console.WriteLine($"A {enemy.Name} appears!");
                Console.WriteLine(enemy.Description);
                Console.WriteLine(enemy.Art);
            }

            _player.ChooseWeapon(); // Player selects weapon

            while (_player.HP > 0 && _enemies.Any(e => e.HP > 0))
            {
                foreach (var enemy in _enemies)
                {
                    if (enemy.HP <= 0) continue; // Skip defeated enemies

                    int playerRoll = _player.RollDice();
                    int enemyRoll = enemy.RollDice();
                    Console.WriteLine($"You rolled: {playerRoll}, {enemy.Name} rolled: {enemyRoll}");

                    if (playerRoll > enemyRoll)
                    {
                        int damage = playerRoll - enemyRoll;
                        enemy.TakeDamage(damage);
                        Console.WriteLine($"You dealt {damage} damage to {enemy.Name}! {enemy.Name} HP: {enemy.HP}");
                    }
                    else if (enemyRoll > playerRoll)
                    {
                        int damage = enemyRoll - playerRoll;
                        _player.TakeDamage(damage);
                        Console.WriteLine($"{enemy.Name} dealt {damage} damage to you! Your HP: {_player.HP}");
                    }
                    else
                    {
                        Console.WriteLine("It's a tie! No one takes damage.");
                    }

                    if (_player.HP <= 0)
                    {
                        Console.WriteLine("You have been defeated!");
                        return;
                    }

                    if (enemy.HP <= 0)
                    {
                        Console.WriteLine($"You have defeated the {enemy.Name}!");
                    }
                }
            }

            Console.WriteLine("Combat has ended.");
        }
    }

}
