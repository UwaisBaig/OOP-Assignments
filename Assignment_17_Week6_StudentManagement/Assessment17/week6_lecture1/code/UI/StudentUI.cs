using code.BL;
using code.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.UI
{
    public class STudentUI
    {
        public static string GetValidName(string prompt)
        {
            Console.Write(prompt);
            int top = Console.CursorTop;
            int left = Console.CursorLeft;
            while (true)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input) && input.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                {
                    return input;
                }
                Console.SetCursorPosition(left, top);
                Console.Write(new string(' ', Console.WindowWidth - left));
                Console.SetCursorPosition(left, top);
            }
        }

        public static string GetValidAlphaNumeric(string prompt)
        {
            Console.Write(prompt);
            int top = Console.CursorTop;
            int left = Console.CursorLeft;
            while (true)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input) && input.All(char.IsLetterOrDigit))
                {
                    return input;
                }
                Console.SetCursorPosition(left, top);
                Console.Write(new string(' ', Console.WindowWidth - left));
                Console.SetCursorPosition(left, top);
            }
        }

        public static int GetValidInt(string prompt)
        {
            Console.Write(prompt);
            int top = Console.CursorTop;
            int left = Console.CursorLeft;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int value) && value >= 0) return value;
                Console.SetCursorPosition(left, top);
                Console.Write(new string(' ', Console.WindowWidth - left));
                Console.SetCursorPosition(left, top);
            }
        }

        public static double GetValidDouble(string prompt)
        {
            Console.Write(prompt);
            int top = Console.CursorTop;
            int left = Console.CursorLeft;
            while (true)
            {
                string input = Console.ReadLine();
                if (double.TryParse(input, out double value) && value >= 0) return value;
                Console.SetCursorPosition(left, top);
                Console.Write(new string(' ', Console.WindowWidth - left));
                Console.SetCursorPosition(left, top);
            }
        }
    }

    public class DegreeProgramUI
    {
        public static DegreeProgram takeInputForDegree()
        {
            string name = STudentUI.GetValidName("Enter Degree Name: ");
            double dur = STudentUI.GetValidDouble("Enter Degree Duration: ");
            int seats = STudentUI.GetValidInt("Enter Seats for Degree: ");
            DegreeProgram deg = new DegreeProgram(name, (float)dur, seats);

            int count = STudentUI.GetValidInt("Enter How many Subjects to Enter: ");
            for (int i = 0; i < count; i++)
            {
                string c = STudentUI.GetValidAlphaNumeric("Enter Subject Code: ");
                string t = STudentUI.GetValidName("Enter Subject Type: ");
                int ch = STudentUI.GetValidInt("Enter Subject Credit Hours: ");
                int f = STudentUI.GetValidInt("Enter Subject Fees: ");
                Console.WriteLine("Degree Program Successfully Added...!");
                if (!deg.addSubject(new Subject(c, t, ch, f)))
                {
                    Console.WriteLine("Error: 20 Credit Hour Limit Exceeded for this Degree!");
                }
            }
            return deg;
        }
    }
    public class StudentUI
    {
        public static Student takeInput()
        {
            string name = STudentUI.GetValidName("Enter Student Name: ");
            int age = STudentUI.GetValidInt("Enter Student Age: ");
            double fsc = STudentUI.GetValidDouble("Enter Student FSc Marks (out of 1100): ");
            double ecat = STudentUI.GetValidDouble("Enter Student Ecat Marks (out of 400): ");

            Student s = new Student(name, age, fsc, ecat);
            s.calculateMerit();

            Console.WriteLine("Available Degree Programs:");
            foreach (var d in DegreeProgramDL.programList) Console.WriteLine(":- " + d.degreeName);

            int c = STudentUI.GetValidInt("Enter how many preferences: ");
            for (int i = 0; i < c; i++)
            {
                Console.Write($"Enter Preference {i + 1}: ");
                int top = Console.CursorTop;
                int left = Console.CursorLeft;

                while (true)
                {
                    string dName = Console.ReadLine();
                    var deg = DegreeProgramDL.isDegreeExists(dName);

                    if (deg != null && !s.preferences.Contains(deg))
                    {
                        s.preferences.Add(deg);
                        Console.WriteLine("Student Added Successfully...!");
                        break;
                    }

                    Console.SetCursorPosition(left, top);
                    Console.Write(new string(' ', Console.WindowWidth - left));
                    Console.SetCursorPosition(left, top);
                }
            }
            return s;
        }
    }
}
