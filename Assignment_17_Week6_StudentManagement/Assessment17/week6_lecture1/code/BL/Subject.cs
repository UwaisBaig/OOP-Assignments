using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.BL
{
    public class Subject
    {
        public string code;
        public string type;
        public int creditHours;
        public int subjectFees;

        public Subject(string code, string type, int ch, int fees)
        {
            this.code = code;
            this.type = type;
            this.creditHours = ch;
            this.subjectFees = fees;
        }
    }
}
