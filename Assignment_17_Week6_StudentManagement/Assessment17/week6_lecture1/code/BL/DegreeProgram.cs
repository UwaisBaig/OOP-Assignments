using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.BL
{
    public class DegreeProgram
    {
        public string degreeName;
        public float degreeDuration;
        public int seats;
        public List<Subject> subjects = new List<Subject>();
        public DegreeProgram(string name, float duration, int seats)
        {
            this.degreeName = name;
            this.degreeDuration = duration;
            this.seats = seats;
        }
        public int calculateCreditHours()
        {
            int count = 0;
            foreach (var s in subjects)
            {
                count += s.creditHours;
            }
            return count;
        }
        public bool addSubject(Subject s)
        {
            if (calculateCreditHours() + s.creditHours <= 20)
            {
                subjects.Add(s);
                return true;
            }
            return false;
        }
        public bool isSubjectExists(string code)
        {
            foreach (var s in subjects)
            {
                if (s.code == code)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
