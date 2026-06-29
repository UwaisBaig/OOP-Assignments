using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge___1_points_x_y
{
    class Program
    {
        static void Main()
        {
            int choice;
            MyLine line = null;

            do
            {
                Console.WriteLine("\n--- Line Management Menu ---");
                Console.WriteLine("1. Make a Line");
                Console.WriteLine("2. Update the begin point");
                Console.WriteLine("3. Update the end point");
                Console.WriteLine("4. Show the begin point");
                Console.WriteLine("5. Show the end point");
                Console.WriteLine("6. Get the Length of the line");
                Console.WriteLine("7. Get the Gradient of the Line");
                Console.WriteLine("8. Find the distance of begin point from zero coordinates");
                Console.WriteLine("9. Find the distance of end point from zero coordinates");
                Console.WriteLine("10. Exit");
                Console.Write("Enter choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice)) continue;

                if (line == null && choice >= 2 && choice <= 9)
                {
                    Console.WriteLine("Please create a line first (Option 1).");
                    continue;
                }

                if (choice == 1)
                {
                    Console.Write("Enter begin point x: ");
                    int bx = int.Parse(Console.ReadLine());
                    Console.Write("Enter begin point y: ");
                    int by = int.Parse(Console.ReadLine());

                    Console.Write("Enter end point x: ");
                    int ex = int.Parse(Console.ReadLine());
                    Console.Write("Enter end point y: ");
                    int ey = int.Parse(Console.ReadLine());

                    line = new MyLine(new MyPoint(bx, by), new MyPoint(ex, ey));
                    Console.WriteLine("Line created!");
                }
                else if (choice == 2)
                {
                    Console.Write("Enter new begin point x: ");
                    int x = int.Parse(Console.ReadLine());
                    Console.Write("Enter new begin point y: ");
                    int y = int.Parse(Console.ReadLine());

                    line.getBegin().setXY(x, y);
                    Console.WriteLine("Begin point updated!");
                }
                else if (choice == 3)
                {
                    Console.Write("Enter new end point x: ");
                    int x = int.Parse(Console.ReadLine());
                    Console.Write("Enter new end point y: ");
                    int y = int.Parse(Console.ReadLine());

                    line.getEnd().setXY(x, y);
                    Console.WriteLine("End point updated!");
                }
                else if (choice == 4)
                {
                    Console.WriteLine($"Begin point: ({line.getBegin().getX()}, {line.getBegin().getY()})");
                }
                else if (choice == 5)
                {
                    Console.WriteLine($"End point: ({line.getEnd().getX()}, {line.getEnd().getY()})");
                }
                else if (choice == 6)
                {
                    Console.WriteLine($"Length of line: {line.getLength():F2}");
                }
                else if (choice == 7)
                {
                    Console.WriteLine($"Gradient of line: {line.getGradient():F2}");
                }
                else if (choice == 8)
                {
                    Console.WriteLine($"Distance of begin from origin: {line.getBegin().distanceFromZero():F2}");
                }
                else if (choice == 9)
                {
                    Console.WriteLine($"Distance of end from origin: {line.getEnd().distanceFromZero():F2}");
                }

            } while (choice != 10);
        }
    }
}