using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

class DegreeProgramUI
{
    public static DegreeProgram takeInputForDegree()
    {
        string degreeName;
        float degreeDuration;
        int seats;
        Console.Write("Enter Degree Name: ");
        degreeName = Console.ReadLine();
        Console.Write("Enter Degree Duration: ");
        degreeDuration = float.Parse(Console.ReadLine());
        Console.Write("Enter Seats for Degree: ");
        seats = int.Parse(Console.ReadLine());

        DegreeProgram degProg = new DegreeProgram(degreeName, degreeDuration, seats);
        Console.Write("Enter How many Subjects to Enter: ");
        int count = int.Parse(Console.ReadLine());

        for (int x = 0; x < count; x++)
        {
            Subject sub = SubjectUI.takeInputForSubject();
            if (degProg.AddSubject(sub))
            {
                if (!(SubjectDL.subjectList.Contains(sub)))
                {
                    SubjectDL.addSubjectIntoList(sub);
                    SubjectDL.storeIntoFile("subject.txt", sub);
                }
                Console.WriteLine("Subject Added");
            }
            else
            {
                Console.WriteLine("Subject Not Added");
                Console.WriteLine("20 credit hour limit exceeded");
            }
        }
        return degProg;
    }

    public static void viewDegreePrograms()
    {
        foreach (DegreeProgram dp in DegreeProgramDL.programList)
        {
            Console.WriteLine(dp.degreeName);
        }
    }
}