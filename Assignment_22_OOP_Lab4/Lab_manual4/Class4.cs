using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_manuak_4__23_4_26_
{
    internal class Class4
    {
        // --- Classes ---
        class Subject
        {
            public string Code;
            public string Type;
            public int CreditHours;
            public double Fee;

            public Subject(string code, string type, int creditHours, double fee)
            {
                Code = code;
                Type = type;
                CreditHours = creditHours;
                Fee = fee;
            }
        }

        class DegreeProgram
        {
            public string Title;
            public int Duration;
            public int Seats;
            public List<Subject> Subjects;

            public DegreeProgram(string title, int duration, int seats)
            {
                Title = title;
                Duration = duration;
                Seats = seats;
                Subjects = new List<Subject>();
            }

            public bool AddSubject(Subject s)
            {
                int totalCH = Subjects.Sum(sub => sub.CreditHours) + s.CreditHours;
                if (totalCH <= 20)
                {
                    Subjects.Add(s);
                    return true;
                }
                return false;
            }
        }

        class Student
        {
            public string Name;
            public int Age;
            public double FscMarks;
            public double EcatMarks;
            public double Merit;
            public List<DegreeProgram> Preferences;
            public DegreeProgram EnrolledProgram;
            public List<Subject> RegisteredSubjects;

            public Student(string name, int age, double fsc, double ecat)
            {
                Name = name;
                Age = age;
                FscMarks = fsc;
                EcatMarks = ecat;
                Preferences = new List<DegreeProgram>();
                RegisteredSubjects = new List<Subject>();
                CalculateMerit();
            }

            public void CalculateMerit()
            {
                // Merit: 60% FSc + 40% ECAT (assuming out of 1100 and 400 respectively)
                Merit = ((FscMarks / 1100) * 60) + ((EcatMarks / 400) * 40);
            }

            public bool RegisterSubject(Subject s)
            {
                int totalCH = RegisteredSubjects.Sum(sub => sub.CreditHours) + s.CreditHours;
                if (totalCH <= 9)
                {
                    RegisteredSubjects.Add(s);
                    return true;
                }
                return false;
            }

            public double CalculateFee()
            {
                return RegisteredSubjects.Sum(s => s.Fee);
            }
        }

        // --- Driver Program ---
        class Program
        {
            static List<Student> students = new List<Student>();
            static List<DegreeProgram> programs = new List<DegreeProgram>();

            static void Main(string[] args)
            {
                while (true)
                {
                    Console.WriteLine("\n***********************");
                    Console.WriteLine("         UAMS          ");
                    Console.WriteLine("***********************");
                    Console.WriteLine("1. Add Student");
                    Console.WriteLine("2. Add Degree Program");
                    Console.WriteLine("3. Generate Merit");
                    Console.WriteLine("4. View Registered Students");
                    Console.WriteLine("5. View Students of a Specific Program");
                    Console.WriteLine("6. Register Subjects for a Specific Student");
                    Console.WriteLine("7. Calculate Fees for all Registered Students");
                    Console.WriteLine("8. Exit");
                    Console.Write("Enter Option: ");

                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1": AddStudent(); break;
                        case "2": AddDegreeProgram(); break;
                        case "3": GenerateMerit(); break;
                        case "4": ViewRegisteredStudents(); break;
                        case "5": ViewStudentsOfProgram(); break;
                        case "6": RegisterSubjects(); break;
                        case "7": CalculateFees(); break;
                        case "8": return;
                        default: Console.WriteLine("Invalid option."); break;
                    }
                }
            }

            static void AddDegreeProgram()
            {
                Console.Write("Enter Degree Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Degree Duration: ");
                int duration = int.Parse(Console.ReadLine());
                Console.Write("Enter Seats for Degree: ");
                int seats = int.Parse(Console.ReadLine());

                DegreeProgram dp = new DegreeProgram(name, duration, seats);

                Console.Write("Enter How many Subjects to Enter: ");
                int subCount = int.Parse(Console.ReadLine());

                for (int i = 0; i < subCount; i++)
                {
                    Console.Write("Enter Subject Code: ");
                    string code = Console.ReadLine();
                    Console.Write("Enter Subject Type: ");
                    string type = Console.ReadLine();
                    Console.Write("Enter Subject Credit Hours: ");
                    int ch = int.Parse(Console.ReadLine());
                    Console.Write("Enter Subject Fees: ");
                    double fee = double.Parse(Console.ReadLine());

                    if (!dp.AddSubject(new Subject(code, type, ch, fee)))
                    {
                        Console.WriteLine("Limit exceeded! A program cannot have more than 20 credit hours.");
                    }
                }
                programs.Add(dp);
                Console.WriteLine("Press any key to Continue...");
                Console.ReadKey();
            }

            static void AddStudent()
            {
                Console.Write("Enter Student Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Student Age: ");
                int age = int.Parse(Console.ReadLine());
                Console.Write("Enter Student FSc Marks: ");
                double fsc = double.Parse(Console.ReadLine());
                Console.Write("Enter Student Ecat Marks: ");
                double ecat = double.Parse(Console.ReadLine());

                Student s = new Student(name, age, fsc, ecat);

                Console.WriteLine("Available Degree Programs:");
                foreach (var p in programs) Console.WriteLine(p.Title);

                Console.Write("Enter how many preferences to Enter: ");
                int prefCount = int.Parse(Console.ReadLine());

                for (int i = 0; i < prefCount; i++)
                {
                    Console.Write($"Enter Preference {i + 1}: ");
                    string prefName = Console.ReadLine();
                    var p = programs.FirstOrDefault(prog => prog.Title.Equals(prefName, StringComparison.OrdinalIgnoreCase));
                    if (p != null) s.Preferences.Add(p);
                    else Console.WriteLine("Program not found.");
                }

                students.Add(s);
                Console.WriteLine("Press any key to Continue...");
                Console.ReadKey();
            }

            static void GenerateMerit()
            {
                var sortedStudents = students.OrderByDescending(s => s.Merit).ToList();

                foreach (var student in sortedStudents)
                {
                    if (student.EnrolledProgram == null)
                    {
                        foreach (var pref in student.Preferences)
                        {
                            if (pref.Seats > 0)
                            {
                                student.EnrolledProgram = pref;
                                pref.Seats--;
                                Console.WriteLine($"{student.Name} got Admission in {pref.Title}");
                                break;
                            }
                        }
                        if (student.EnrolledProgram == null)
                        {
                            Console.WriteLine($"{student.Name} did not get Admission");
                        }
                    }
                }
                Console.WriteLine("Press any key to Continue...");
                Console.ReadKey();
            }

            static void ViewRegisteredStudents()
            {
                Console.WriteLine($"{"Name",-10} {"FSC",-10} {"Ecat",-10} {"Age",-10}");
                foreach (var s in students.Where(st => st.EnrolledProgram != null))
                {
                    Console.WriteLine($"{s.Name,-10} {s.FscMarks,-10} {s.EcatMarks,-10} {s.Age,-10}");
                }
                Console.WriteLine("Press any key to Continue...");
                Console.ReadKey();
            }

            static void ViewStudentsOfProgram()
            {
                Console.Write("Enter Degree Name: ");
                string degreeName = Console.ReadLine();

                Console.WriteLine($"{"Name",-10} {"FSC",-10} {"Ecat",-10} {"Age",-10}");
                foreach (var s in students.Where(st => st.EnrolledProgram != null && st.EnrolledProgram.Title.Equals(degreeName, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine($"{s.Name,-10} {s.FscMarks,-10} {s.EcatMarks,-10} {s.Age,-10}");
                }
                Console.WriteLine("Press any key to Continue...");
                Console.ReadKey();
            }

            static void RegisterSubjects()
            {
                Console.Write("Enter Student Name: ");
                string name = Console.ReadLine();
                var student = students.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

                if (student != null && student.EnrolledProgram != null)
                {
                    Console.WriteLine("Available Subjects in Enrolled Program:");
                    foreach (var sub in student.EnrolledProgram.Subjects)
                    {
                        Console.WriteLine($"{sub.Code} - {sub.Type} ({sub.CreditHours} CH)");
                    }

                    Console.Write("Enter Subject Code to Register: ");
                    string code = Console.ReadLine();
                    var subject = student.EnrolledProgram.Subjects.FirstOrDefault(s => s.Code.Equals(code, StringComparison.OrdinalIgnoreCase));

                    if (subject != null)
                    {
                        if (student.RegisterSubject(subject))
                            Console.WriteLine("Subject registered successfully.");
                        else
                            Console.WriteLine("Cannot register. Credit hour limit (9 CH) exceeded.");
                    }
                    else Console.WriteLine("Subject not found in the program.");
                }
                else
                {
                    Console.WriteLine("Student not found or not enrolled in any program.");
                }
                Console.WriteLine("Press any key to Continue...");
                Console.ReadKey();
            }

            static void CalculateFees()
            {
                Console.WriteLine("Fee Generation for Registered Students:");
                foreach (var student in students.Where(s => s.EnrolledProgram != null))
                {
                    Console.WriteLine($"{student.Name} (Program: {student.EnrolledProgram.Title}) - Total Fee: {student.CalculateFee()}");
                }
                Console.WriteLine("Press any key to Continue...");
                Console.ReadKey();
            }
        }
    }
}

