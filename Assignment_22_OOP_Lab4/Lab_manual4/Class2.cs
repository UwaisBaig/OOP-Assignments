using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_manuak_4__23_4_26_
{
    internal class Class2
    {
        class product
        {
            public string name;
            public int price;

            public float calculateTax()
            {
                return price * 0.1f;
            }
        }
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
