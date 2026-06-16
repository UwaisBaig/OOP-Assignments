using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.BL
{
    public class Student
    {
        public string name;
        public int age;
        public double fscMarks;
        public double ecatMarks;
        public double merit;

        public List<DegreeProgram> preferences = new List<DegreeProgram>();
        public List<Subject> regSubject = new List<Subject>();
        public DegreeProgram adDegree = null;

        public Student(string name, int age, double fsc, double ecat)
        {
            this.name = name;
            this.age = age;
            this.fscMarks = fsc;
            this.ecatMarks = ecat;
        }

        public void calculateMerit()
        {
            this.merit = (((fscMarks / 1100.0) * 0.45) + ((ecatMarks / 400.0) * 0.55)) * 100;
        }

        public int getRegCredits()
        {
            int count = 0;
            foreach (var s in regSubject)
            {
                count += s.creditHours;
            }
            return count;
        }

        public bool regStudentSubject(Subject s)
        {
            if (adDegree != null && adDegree.isSubjectExists(s.code) && getRegCredits() + s.creditHours <= 9)
            {
                regSubject.Add(s);
                return true;
            }
            return false;
        }

        public double calculateFee()
        {
            double total = 0;
            foreach (var s in regSubject)
            {
                total += s.subjectFees;
            }
            return total;
        }
    }
}
