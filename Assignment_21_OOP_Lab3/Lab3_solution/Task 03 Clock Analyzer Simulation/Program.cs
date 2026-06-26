using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03_Clock_Analyzer_Simulation
{
    public class ClockType
    {
        public int Hours;
        public int Minutes;
        public int Seconds;
        public ClockType(int h, int m, int s)
        {
            Hours = h;
            Minutes = m;
            Seconds = s;
        }
        public void PrintTime()
        {
            Console.WriteLine($"{Hours:D2}:{Minutes:D2}:{Seconds:D2}");
        }
        public int CalculateElapsedSeconds()
        {
            return (Hours * 3600) + (Minutes * 60) + Seconds;
        }
        public int CalculateRemainingSeconds()
        {
            int totalSecondsInDay = 86400;
            return totalSecondsInDay - CalculateElapsedSeconds();
        }
        public int CalculateDifference(ClockType otherClock)
        {
            int myTime = this.CalculateElapsedSeconds();
            int otherTime = otherClock.CalculateElapsedSeconds();
            return Math.Abs(myTime - otherTime);
        }
    }
    public class ClockUI
    {
        public static int GetValidTime(string prompt, int maxLimit)
        {
            Console.Write(prompt);
            int top = Console.CursorTop;
            int left = Console.CursorLeft;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int value) && value >= 0 && value <= maxLimit)
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
            Console.WriteLine("=== SETUP YOUR CLOCKS ===\n");
            Console.WriteLine("--- Enter Time for Clock 1 ---");
            int h1 = ClockUI.GetValidTime("Hours (0-23): ", 23);
            int m1 = ClockUI.GetValidTime("Minutes (0-59): ", 59);
            int s1 = ClockUI.GetValidTime("Seconds (0-59): ", 59);
            ClockType clock1 = new ClockType(h1, m1, s1);
            Console.WriteLine("\n--- Enter Time for Clock 2 ---");
            int h2 = ClockUI.GetValidTime("Hours (0-23): ", 23);
            int m2 = ClockUI.GetValidTime("Minutes (0-59): ", 59);
            int s2 = ClockUI.GetValidTime("Seconds (0-59): ", 59);

            ClockType clock2 = new ClockType(h2, m2, s2);
            Console.WriteLine("\n--- Enter Time for Clock 3 ---");
            int h3 = ClockUI.GetValidTime("Hours (0-23): ", 23);
            int m3 = ClockUI.GetValidTime("Minutes (0-59): ", 59);
            int s3 = ClockUI.GetValidTime("Seconds (0-59): ", 59);
            ClockType clock3 = new ClockType(h3, m3, s3);

            Console.Clear();
            Console.WriteLine("--- CLOCK ANALYZER STARTED ---\n");

            Console.Write("Clock 1 -> ");
            clock1.PrintTime();
            Console.WriteLine($"Elapsed Seconds: {clock1.CalculateElapsedSeconds()}");
            Console.WriteLine($"Remaining Seconds: {clock1.CalculateRemainingSeconds()}\n");

            Console.Write("Clock 2 -> ");
            clock2.PrintTime();
            Console.WriteLine($"Difference with Clock 1: {clock2.CalculateDifference(clock1)} seconds\n");

            Console.Write("Clock 3 -> ");
            clock3.PrintTime();
            Console.WriteLine($"Remaining Seconds: {clock3.CalculateRemainingSeconds()}\n");

            Console.WriteLine("--- ANALYSIS COMPLETE ---");

            Console.ReadLine();
        }
    }
}