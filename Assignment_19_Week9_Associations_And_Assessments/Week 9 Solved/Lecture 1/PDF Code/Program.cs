using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Enemy
{
    public virtual void move()
    {
        Console.WriteLine("I move Generally");
    }
}

class VerticalEnemy : Enemy
{
    public VerticalEnemy()
    {
        Console.WriteLine("Vertical Enemy Created");
    }

    public override void move()
    {
        Console.WriteLine("I move Vertically");
    }
}

class HorizontalEnemy : Enemy
{
    public HorizontalEnemy()
    {
        Console.WriteLine("Horizontal Enemy Created");
    }

    public override void move()
    {
        Console.WriteLine("I move Horizontally");
    }
}

class DiagonalEnemy : Enemy
{
    public DiagonalEnemy()
    {
        Console.WriteLine("Diagonal Enemy Created");
    }

    public override void move()
    {
        Console.WriteLine("I move Diagonally");
    }
}

class Program
{
    static void Main()
    {
        List<Enemy> enemies = new List<Enemy>();
        enemies.Add(new VerticalEnemy());
        enemies.Add(new VerticalEnemy());
        enemies.Add(new HorizontalEnemy());
        enemies.Add(new HorizontalEnemy());
        enemies.Add(new DiagonalEnemy());
        enemies.Add(new DiagonalEnemy());
        Console.WriteLine("Press any key to move enemies, or press ESC to quit.");

        // Loop continues as long as the key pressed is NOT the Escape key
        while (Console.ReadKey().Key != ConsoleKey.Escape)
        {
            Console.WriteLine();
            foreach (Enemy v in enemies)
            {
                v.move();
            }
        }
    }
}