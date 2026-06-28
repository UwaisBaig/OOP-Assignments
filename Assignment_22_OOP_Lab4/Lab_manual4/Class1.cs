using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_manuak_4__23_4_26_
{
    class Degree
    {
        public string degreeName;
        public int duration;

        public void showdegree()
        {
            Console.WriteLine("Degree" + degreeName);
            Console.WriteLine("Degree" + duration + "years");
        }
    }

    class student
    {
        public string name;
        public float CGPA;
        public Degree deg;

        public void showStudent()
        {
            Console.WriteLine("Name" + name);
            Console.WriteLine("CGPA" + CGPA);
            deg.showdegree();
        }
    }
    internal class Class1
    {
        static void Main(string[] args)
        {
            Degree d = new Degree();
            d.degreeName = "BSCS";
            d.duration = 4;

            student s = new student();
            s.name = "ALi";
            s.CGPA = 3.5f;
            s.deg = d;

            s.showStudent();
        }
    }
}