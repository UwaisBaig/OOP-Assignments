using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

class SubjectUI
{
    public static Subject takeInputForSubject()
    {
        string code;
        string type;
        int creditHours;
        int subjectFees;
        Console.Write("Enter Subject Code: ");
        code = Console.ReadLine();
        Console.Write("Enter Subject Type: ");
        type = Console.ReadLine();
        Console.Write("Enter Subject Credit Hours: ");
        creditHours = int.Parse(Console.ReadLine());
        Console.Write("Enter Subject Fees: ");
        subjectFees = int.Parse(Console.ReadLine());
        Subject sub = new Subject(code, type, creditHours, subjectFees);
        return sub;
    }

    public static void viewSubjects(Student s)
    {
        if (s.regDegree != null)
        {
            Console.WriteLine("Sub Code\tSub Type");
            foreach (Subject sub in s.regDegree.subjects)
            {
                Console.WriteLine(sub.code + "\t\t" + sub.type);
            }
        }
    }

    public static void registerSubjects(Student s)
    {
        Console.WriteLine("Enter how many subjects you want to register");
        int count = int.Parse(Console.ReadLine());
        for (int x = 0; x < count; x++)
        {
            Console.WriteLine("Enter the subject Code");
            string code = Console.ReadLine();
            bool Flag = false;
            foreach (Subject sub in s.regDegree.subjects)
            {
                if (code == sub.code && !(s.regSubject.Contains(sub)))
                {
                    if (s.regStudentSubject(sub))
                    {
                        Flag = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("A student cannot have more than 9 CH or Wrong Subject");
                        Flag = true;
                        break;
                    }
                }
            }
            if (Flag == false)
            {
                Console.WriteLine("Enter Valid Course");
            }
        }
    }
}