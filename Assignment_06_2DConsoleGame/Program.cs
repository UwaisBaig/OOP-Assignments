using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_2D_xy_17_March_Assignment_2
{
    class GameObject
    {
        public char symbol;
        public int x, y;
        public ConsoleColor color;
        public GameObject(char s, int xPos, int yPos, ConsoleColor c)
        {
            symbol = s;
            x = xPos;
            y = yPos;
            color = c;
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(symbol);
            Console.ResetColor();
        }

        public void Erase()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
        }
    }
    class Program
    {
        static int width = 50;
        static int height = 20;
        static void DrawBoundaries()
        {
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write('#');
                Console.SetCursorPosition(i, height - 1);
                Console.Write('#');
            }
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write('#');
                Console.SetCursorPosition(width - 1, i);
                Console.Write('#');
            }
            Console.ResetColor();
        }
        static void Main(string[] args)
        {
            Console.SetCursorPosition(0, height + 1);
            Console.WriteLine("Press 'Escape' to Exit the game.");
            Console.CursorVisible = false;
            Console.Clear();
            DrawBoundaries();
            GameObject player = new GameObject('P', 25, 10, ConsoleColor.Cyan);
            GameObject[] enemies =
            {
                new GameObject('E', 5, 5, ConsoleColor.Red),
                new GameObject('E', 40, 15, ConsoleColor.Red),
                new GameObject('E', 10, 15, ConsoleColor.Red)
            };

            Random rand = new Random();
            while (true)
            {
                player.Draw();
                if (Console.KeyAvailable)
                {
                    var keyInfo = Console.ReadKey(true);
                    var key = keyInfo.Key;
                    if (key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        Console.WriteLine("Game Exited.....!");
                        Environment.Exit(0);
                    }
                    player.Erase();
                    if (key == ConsoleKey.UpArrow && player.y > 1)
                        player.y--;
                    if (key == ConsoleKey.DownArrow && player.y < height - 2)
                        player.y++;
                    if (key == ConsoleKey.LeftArrow && player.x > 1)
                        player.x--;
                    if (key == ConsoleKey.RightArrow && player.x < width - 2)
                        player.x++;
                }
                for (int i = 0; i < enemies.Length; i++)
                {
                    enemies[i].Erase();
                    int dir = rand.Next(0, 4);
                    if (dir == 0 && enemies[i].y > 1)
                        enemies[i].y--;
                    else if (dir == 1 && enemies[i].y < height - 2)
                        enemies[i].y++;
                    else if (dir == 2 && enemies[i].x > 1)
                        enemies[i].x--;
                    else if (dir == 3 && enemies[i].x < width - 2)
                        enemies[i].x++;

                    enemies[i].Draw();
                }

                Thread.Sleep(100);
            }
        }
    }
}