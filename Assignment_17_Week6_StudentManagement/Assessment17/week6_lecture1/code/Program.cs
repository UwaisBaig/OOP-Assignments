using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using code.BL;
using code.DL;
using code.UI;

namespace code
{
    public class Program
    {
        static void Main(string[] args)
        {
            string sPath = "students.txt", dPath = "degrees.txt";

            DegreeProgramDL.readFromFile(dPath);
            StudentDL.readFromFile(sPath);

            int option = 0;
            while (option != 8)
            {
                Console.Clear();
                Console.WriteLine("=====================================");
                Console.WriteLine("             UAMS SYSTEM             ");
                Console.WriteLine("=====================================");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Degree Program");
                Console.WriteLine("3. Generate Merit");
                Console.WriteLine("4. View Registered Students");
                Console.WriteLine("5. View Students of Specific Program");
                Console.WriteLine("6. Register Subjects for Student");
                Console.WriteLine("7. Calculate Fees");
                Console.WriteLine("8. Exit");
                Console.WriteLine("=====================================");

                option = STudentUI.GetValidInt("Enter Option: ");

                if (option == 1)
                {
                    Console.Clear();
                    if (DegreeProgramDL.programList.Count > 0)
                    {
                        Student s = StudentUI.takeInput();
                        StudentDL.addIntoStudentList(s);
                        StudentDL.storeIntoFile(sPath, s);
                    }
                    else
                    {
                        Console.WriteLine("Add at least one Degree Program first!");
                    }
                }
                else if (option == 2)
                {
                    Console.Clear();
                    DegreeProgram d = DegreeProgramUI.takeInputForDegree();
                    DegreeProgramDL.addIntoDegreeList(d);
                    DegreeProgramDL.storeIntoFile(dPath, d);
                }
                else if (option == 3)
                {
                    Console.Clear();
                    StudentDL.giveAdmission();
                    foreach (var s in StudentDL.studentList)
                    {
                        if (s.adDegree != null)
                            Console.WriteLine($"{s.name} got Admission in {s.adDegree.degreeName}");
                        else
                            Console.WriteLine($"{s.name} did not get Admission (Merit/Seats full)");
                    }
                }
                else if (option == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Name\tFSC\tEcat\tAge");
                    foreach (var s in StudentDL.studentList)
                    {
                        if (s.adDegree != null)
                            Console.WriteLine($"{s.name}\t{s.fscMarks}\t{s.ecatMarks}\t{s.age}");
                    }
                }
                else if (option == 5)
                {
                    Console.Clear();
                    if (DegreeProgramDL.programList.Count > 0)
                    {
                        Console.WriteLine("Available Degree Programs:");
                        foreach (var d in DegreeProgramDL.programList)
                            Console.WriteLine("- " + d.degreeName);

                        Console.Write("Enter Degree Name: ");
                        int top = Console.CursorTop;
                        int left = Console.CursorLeft;
                        string dName = "";
                        while (true)
                        {
                            dName = Console.ReadLine();
                            if (DegreeProgramDL.isDegreeExists(dName) != null) break;

                            Console.SetCursorPosition(left, top);
                            Console.Write(new string(' ', Console.WindowWidth - left));
                            Console.SetCursorPosition(left, top);
                        }

                        Console.WriteLine($"\nStudents enrolled in {dName}:");
                        bool found = false;
                        foreach (var s in StudentDL.studentList)
                        {
                            if (s.adDegree != null && s.adDegree.degreeName == dName)
                            {
                                Console.WriteLine(s.name);
                                found = true;
                            }
                        }
                        if (!found) Console.WriteLine("No students enrolled in this program yet.");
                    }
                    else
                    {
                        Console.WriteLine("No Degree Programs available!");
                    }
                }
                else if (option == 6)
                {
                    Console.Clear();
                    string name = STudentUI.GetValidName("Enter Student Name: ");
                    bool studentFound = false;

                    foreach (var s in StudentDL.studentList)
                    {
                        if (s.name == name && s.adDegree != null)
                        {
                            studentFound = true;
                            Console.WriteLine("Available Subjects for " + s.adDegree.degreeName + ":");
                            foreach (var sub in s.adDegree.subjects)
                            {
                                Console.WriteLine($"Code:{sub.code} - Type:{sub.type} (Credit Hours:{sub.creditHours} CH)");
                            }

                            Console.Write("Enter Subject Code to Register: ");
                            int top = Console.CursorTop;
                            int left = Console.CursorLeft;
                            while (true)
                            {
                                string sc = Console.ReadLine();
                                Subject targetSub = null;
                                foreach (var sub in s.adDegree.subjects)
                                {
                                    if (sub.code == sc)
                                    {
                                        targetSub = sub;
                                        break;
                                    }
                                }

                                if (targetSub != null)
                                {
                                    if (s.regStudentSubject(targetSub))
                                    {
                                        Console.WriteLine("Subject Registered Successfully!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error: Max 9 CH limit reached or subject already registered!");
                                    }
                                    break;
                                }
                                Console.SetCursorPosition(left, top);
                                Console.Write(new string(' ', Console.WindowWidth - left));
                                Console.SetCursorPosition(left, top);
                            }
                        }
                    }

                    if (!studentFound)
                    {
                        Console.WriteLine("Student not found or hasn't been assigned a degree yet!");
                    }
                }
                else if (option == 7)
                {
                    Console.Clear();
                    foreach (var s in StudentDL.studentList)
                    {
                        if (s.adDegree != null)
                            Console.WriteLine($"{s.name} Total Fees: {s.calculateFee()}");
                    }
                }

                if (option != 8)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }
    }
}
