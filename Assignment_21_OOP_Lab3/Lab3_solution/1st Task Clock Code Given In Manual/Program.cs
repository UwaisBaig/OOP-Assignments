using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1st_Task_Clock_Code_Given_In_Manual
{
    public class clockType
    {
        public int hours;
        public int minutes;
        public int seconds;
        public clockType()
        {
            hours = 0;
            minutes = 0;
            seconds = 0;
        }
        public clockType(int h)
        {
            hours = h;
            minutes = 0;
            seconds = 0;
        }
        public clockType(int h, int m)
        {
            hours = h;
            minutes = m;
            seconds = 0;
        }
        public clockType(int h, int m, int s)
        {
            hours = h;
            minutes = m;
            seconds = s;
        }
        public void incrementSecond()
        {
            seconds++;
        }
        public void incrementhours()
        {
            hours++;
        }
        public void incrementminutes()
        {
            minutes++;
        }
        public void printTime()
        {
            Console.WriteLine(hours + " " + minutes + " " + seconds);
        }
        public bool isEqual(int h, int m, int s)
        {
            if (hours == h && minutes == m && seconds == s)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool isEqual(clockType temp)
        {
            if (hours == temp.hours && minutes == temp.minutes && seconds == temp.seconds)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            clockType empty_time = new clockType();
            Console.Write("Empty time: ");
            empty_time.printTime();

            clockType hour_time = new clockType(8);
            Console.Write("Hour time: ");
            hour_time.printTime();

            clockType minute_time = new clockType(8, 10);
            Console.Write("Minute time: ");
            minute_time.printTime();

            clockType full_time = new clockType(8, 10, 10);
            Console.Write("Full time: ");
            full_time.printTime();

            full_time.incrementSecond();
            Console.Write("Full time (Increment Second): ");
            full_time.printTime();

            full_time.incrementhours();
            Console.Write("Full time (Increment hours): ");
            full_time.printTime();

            full_time.incrementminutes();
            Console.Write("Full time (Increment Mintues): ");
            full_time.printTime();

            bool flag = full_time.isEqual(9, 11, 11);
            Console.WriteLine("Flag: " + flag);

            clockType cmp = new clockType(10, 12, 1);
            flag = full_time.isEqual(cmp);
            Console.WriteLine("Object Flag: " + flag);

            Console.ReadLine();
        }
    }
}