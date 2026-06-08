using System;

namespace StudentInformationSystem
{
    class Student
    {
        public string Name;
        public int Age;
        public string Program;
        public double CGPA;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Name: Muhammad Uwais Baig
            // REG Number: 2025-CS-531

            Student[] students = new Student[5]; 
            int count = 0; 
            int choice = 0;

            do
            {
                
                Console.WriteLine("\n====== Student Information System =====");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View Students");
                Console.WriteLine("3. Search Student");
                Console.WriteLine("4. View High Achievers (CGPA > 3.5)");
                Console.WriteLine("5. Count Students by Program");
                Console.WriteLine("6. Generate Report");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                if (choice == 1) 
                {
                    if (count < 5)
                    {
                        students[count] = new Student();

                        Console.Write("Enter Name: ");
                        students[count].Name = Console.ReadLine();

                        Console.Write("Enter Age: ");
                        students[count].Age = int.Parse(Console.ReadLine());

                        Console.Write("Enter Program (e.g., BS CS): ");
                        students[count].Program = Console.ReadLine();

                        double cgpaInput;
                        do
                        {
                            Console.Write("Enter CGPA (0 to 4): ");
                            cgpaInput = double.Parse(Console.ReadLine());

                            if (cgpaInput < 0 || cgpaInput > 4)
                            {
                                Console.WriteLine("Invalid! CGPA must be between 0 and 4.");
                            }
                        } while (cgpaInput < 0 || cgpaInput > 4);

                        students[count].CGPA = cgpaInput;
                        count++;
                        Console.WriteLine("Student added successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Cannot add more students. Maximum of 5 reached.");
                    }
                }
                else if (choice == 2) 
                {
                    if (count == 0) { Console.WriteLine("No students to display."); }

                    for (int i = 0; i < count; i++)
                    {
                        Console.WriteLine("Name: " + students[i].Name + ", Age: " + students[i].Age +
                                          ", Program: " + students[i].Program + ", CGPA: " + students[i].CGPA);
                    }
                }
                else if (choice == 3) 
                {
                    Console.Write("Enter the name to search: ");
                    string searchName = Console.ReadLine();
                    bool found = false;

                    for (int i = 0; i < count; i++)
                    {
                        if (students[i].Name.ToLower() == searchName.ToLower())
                        {
                            Console.WriteLine("Found - Name: " + students[i].Name + ", Program: " + students[i].Program + ", CGPA: " + students[i].CGPA);
                            found = true;
                        }
                    }

                    if (found == false) { Console.WriteLine("Student not found."); }
                }
                else if (choice == 4) 
                {
                    Console.WriteLine("--- High Achievers ---");
                    for (int i = 0; i < count; i++)
                    {
                        if (students[i].CGPA > 3.5)
                        {
                            Console.WriteLine(students[i].Name + " (CGPA: " + students[i].CGPA + ")");
                        }
                    }
                }
                else if (choice == 5) 
                {
                  
                    Console.WriteLine("--- Student Count by Program ---");
                    for (int i = 0; i < count; i++)
                    {
                        bool alreadyCounted = false;
                        for (int j = 0; j < i; j++)
                        {
                            if (students[i].Program == students[j].Program)
                            {
                                alreadyCounted = true;
                            }
                        }

                        if (alreadyCounted == false)
                        {
                            int programCount = 0;
                            for (int k = 0; k < count; k++)
                            {
                                if (students[i].Program == students[k].Program)
                                {
                                    programCount++;
                                }
                            }
                            Console.WriteLine(students[i].Program + ": " + programCount);
                        }
                    }
                }
                else if (choice == 6) 
                {
                    if (count > 0)
                    {
                        double sum = 0;
                        double highest = students[0].CGPA;
                        double lowest = students[0].CGPA;

                        for (int i = 0; i < count; i++)
                        {
                            sum = sum + students[i].CGPA;

                            if (students[i].CGPA > highest) { highest = students[i].CGPA; }
                            if (students[i].CGPA < lowest) { lowest = students[i].CGPA; }
                        }

                        double average = sum / count;

                        Console.WriteLine("\n--- Simple Report ---");
                        Console.WriteLine("Total students: " + count);
                        Console.WriteLine("Average CGPA: " + average);
                        Console.WriteLine("Highest CGPA: " + highest);
                        Console.WriteLine("Lowest CGPA: " + lowest);
                    }
                    else
                    {
                        Console.WriteLine("No students available to generate a report.");
                    }
                }

            } while (choice != 7);
        }
    }
}
