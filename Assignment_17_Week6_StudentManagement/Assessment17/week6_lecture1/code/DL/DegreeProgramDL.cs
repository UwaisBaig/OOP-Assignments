using code.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.DL
{
    public class DegreeProgramDL
    {
        public static List<DegreeProgram> programList = new List<DegreeProgram>();

        public static void addIntoDegreeList(DegreeProgram d)
        {
            programList.Add(d);
        }

        public static DegreeProgram isDegreeExists(string name)
        {
            foreach (var d in programList)
            {
                if (d.degreeName == name)
                {
                    return d;
                }
            }
            return null;
        }

        public static void storeIntoFile(string path, DegreeProgram d)
        {
            StreamWriter f = new StreamWriter(path, true);
            string subData = "";

            foreach (var s in d.subjects)
            {
                subData += s.code + ";" + s.type + ";" + s.creditHours + ";" + s.subjectFees + "-";
            }

            f.WriteLine(d.degreeName + "," + d.degreeDuration + "," + d.seats + "," + subData);
            f.Flush();
            f.Close();
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
                    DegreeProgram d = new DegreeProgram(splitted[0], float.Parse(splitted[1]), int.Parse(splitted[2]));

                    if (splitted.Length > 3 && !string.IsNullOrEmpty(splitted[3]))
                    {
                        string[] subjects = splitted[3].Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string sub in subjects)
                        {
                            string[] subDetails = sub.Split(';');
                            d.addSubject(new Subject(subDetails[0], subDetails[1], int.Parse(subDetails[2]), int.Parse(subDetails[3])));
                        }
                    }
                    addIntoDegreeList(d);
                }
                f.Close();
            }
        }
    }
}
