using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_01_Game_Character_Clone_Battle
{
    public class Character
    {
        public string Name;
        public int Health;
        public int Attack;

        public Character(string name, int health, int attack)
        {
            Name = name;
            Health = health;
            Attack = attack;
        }
        public Character(Character otherCharacter)
        {
            Name = "Clone " + otherCharacter.Name;
            Health = otherCharacter.Health;
            Attack = otherCharacter.Attack;
        }

        public void AttackTarget(Character target)
        {
            target.Health -= this.Attack;
            if (target.Health < 0)
            {
                target.Health = 0;
            }
            Console.WriteLine($"{this.Name} attacks {target.Name} -> {target.Name} Health: {target.Health}");
        }
    }
    public class GameUI
    {
        public static string GetValidName(string prompt)
        {
            Console.Write(prompt);
            int top = Console.CursorTop;
            int left = Console.CursorLeft;
            while (true)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input) && input.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                {
                    return input;
                }
                Console.SetCursorPosition(left, top);
                Console.Write(new string(' ', Console.WindowWidth - left));
                Console.SetCursorPosition(left, top);
            }
        }
        public static int GetValidStat(string prompt)
        {
            Console.Write(prompt);
            int top = Console.CursorTop;
            int left = Console.CursorLeft;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int value) && value > 0)
                {
                    return value;
                }
                Console.SetCursorPosition(left, top);
                Console.Write(new string(' ', Console.WindowWidth - left));
                Console.SetCursorPosition(left, top);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SETUP YOUR FIGHTERS ===\n");

            Console.WriteLine("--- Fighter 1 ---");
            string n1 = GameUI.GetValidName("Enter Fighter 1 Name: ");
            int h1 = GameUI.GetValidStat("Enter Health (e.g., 100): ");
            int a1 = GameUI.GetValidStat("Enter Attack Power (e.g., 30): ");
            Character p1 = new Character(n1, h1, a1);

            Console.WriteLine("\n--- Fighter 2 ---");
            string n2 = GameUI.GetValidName("Enter Fighter 2 Name: ");
            int h2 = GameUI.GetValidStat("Enter Health (e.g., 120): ");
            int a2 = GameUI.GetValidStat("Enter Attack Power (e.g., 20): ");
            Character p2 = new Character(n2, h2, a2);

            Console.Clear();
            Console.WriteLine("--- BATTLE STARTED ---\n");

            int round = 1;
            Console.WriteLine($"Round {round}");

            p1.AttackTarget(p2);
            if (p2.Health > 0)
            {
                p2.AttackTarget(p1);
            }
            if (p1.Health > 0 && p2.Health > 0)
            {
                Character cloneP1 = new Character(p1);
                Console.WriteLine($"\n>> {cloneP1.Name} joins the battle! <<\n");
                while (p2.Health > 0 && cloneP1.Health > 0)
                {
                    round++;
                    Console.WriteLine($"\nRound {round}");
                    cloneP1.AttackTarget(p2);

                    if (p2.Health > 0)
                    {
                        p2.AttackTarget(cloneP1);
                    }
                }
                Console.WriteLine("\n=======================");
                if (p2.Health <= 0)
                {
                    Console.WriteLine($"{p2.Name} has been defeated!");
                    Console.WriteLine($"Winner: {p1.Name} & {cloneP1.Name}");
                }
                else
                {
                    Console.WriteLine($"{cloneP1.Name} has been defeated!");
                    Console.WriteLine($"Winner: {p2.Name}");
                }
            }
            else
            {
                Console.WriteLine("\n=======================");
                if (p2.Health <= 0)
                {
                    Console.WriteLine($"{p2.Name} has been defeated in Round 1!");
                    Console.WriteLine($"Winner: {p1.Name}");
                }
                else
                {
                    Console.WriteLine($"{p1.Name} has been defeated in Round 1!");
                    Console.WriteLine($"Winner: {p2.Name}");
                }
            }

            Console.ReadLine();
        }
    }
}