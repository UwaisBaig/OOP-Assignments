using code.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.DL
{
    public class StudentDL
    {
        public static List<Student> studentList = new List<Student>();

        public static void addIntoStudentList(Student s) { studentList.Add(s); }

        public static void giveAdmission()
        {
            List<Student> sortedList = studentList.OrderByDescending(o => o.merit).ToList();
            foreach (var s in sortedList)
            {
                foreach (var pref in s.preferences)
                {
                    if (pref.seats > 0 && s.adDegree == null)
                    {
                        s.adDegree = pref;
                        pref.seats--;
                        break;
                    }
                }
            }
        }
        public static void storeIntoFile(string path, Student s)
        {
            StreamWriter f = new StreamWriter(path, true);
            string pref = "";
            foreach (var d in s.preferences) pref += d.degreeName + ";";
            f.WriteLine(s.name + "," + s.age + "," + s.fscMarks + "," + s.ecatMarks + "," + pref);
            f.Flush(); f.Close();
        }
        public static void readFromFile(string path)
        {
            if (File.Exists(path))
            {
                StreamReader f = new StreamReader(path);
                string record;
                while ((record = f.ReadLine()) != null)
                {
                    string[] splitted = record.Split(',');
                    Student s = new Student(splitted[0], int.Parse(splitted[1]), double.Parse(splitted[2]), double.Parse(splitted[3]));
                    s.calculateMerit();
                    if (splitted.Length > 4 && !string.IsNullOrEmpty(splitted[4]))
                    {
                        string[] prefs = splitted[4].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string p in prefs)
                        {
                            DegreeProgram d = DegreeProgramDL.isDegreeExists(p);
                            if (d != null) s.preferences.Add(d);
                        }
                    }
                    addIntoStudentList(s);
                }
                f.Close();
            }
        }
    }
}
