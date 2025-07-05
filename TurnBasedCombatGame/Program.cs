using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beginners.TurnBasedCombatGame
{
    public class TurnBasedCombat
    {
        public static void Main()
        {
            int playerHealth = 40;
            int enemyHealth = 20;
            

            while (playerHealth > 0 && enemyHealth > 0)
            {

                Console.WriteLine("--Player turn--");
                Console.WriteLine("Enter 'a' for attacking or 'h' for healing");
                string input = Console.ReadLine().ToLower();
                if (input == "a")
                {
                    Console.WriteLine("you attacked the enemy");
                    enemyHealth -= 10;
                    Console.WriteLine($"player health :{playerHealth}--Enemy health :{enemyHealth}");

                }
                else if (input == "h")
                {
                    Console.WriteLine("you used the heal item");
                    playerHealth += 5;
                    Console.WriteLine($"player health :{playerHealth}--Enemy health :{enemyHealth}");
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter 'a' or 'h'");
                }
                if (enemyHealth > 0)
                {
                    Console.WriteLine("--Enemy turn--");
                    int enemyChoiceAtk = new Random().Next(0, 10);
                    playerHealth -= enemyChoiceAtk;
                    Console.WriteLine($"Enemy attacked you for {enemyChoiceAtk} damage");
                    Console.WriteLine($"player health :{playerHealth}--Enemy health :{enemyHealth}");
                }
                if (playerHealth <= 0)
                {
                    Console.WriteLine("You have been defeated by the enemy!");
                    Environment.Exit(0);
                }
                else if (enemyHealth <= 0)
                {
                    Console.WriteLine("You have defeated the enemy!");
                    Environment.Exit(0);
                }

            }
        }

    }
}
