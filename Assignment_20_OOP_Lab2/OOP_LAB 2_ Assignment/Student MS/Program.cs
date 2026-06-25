
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_MS_task
{
    using System;

    class Student
    {
        public string Name;
        public double Marks;
        public Student(string n, double m)
        {
            Name = n;
            Marks = m;
        }
    }
    class Program
    {        
        static Student[] studentList = new Student[10];
        static int studentCount = 0;
        static void Main(string[] args)
        {                
            Console.Clear();
            string choice = "";
            while (choice != "5")
            {
                Console.WriteLine("\n--- Student Management System ---");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Show Students");
                Console.WriteLine("3. Calculate Aggregate");
                Console.WriteLine("4. Top Student");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                choice = Console.ReadLine();
                if (choice == "1")
                {
                    AddStudent();
                }
                else if (choice == "2")
                {
                    ShowStudents();
                }
                else if (choice == "3")
                {
                    CalculateAggregate();
                }
                else if (choice == "4")
                {
                    TopStudent();
                }
            }
        }

        static void AddStudent()
        {
            Console.Clear();
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Marks: ");
            double marks = Convert.ToDouble(Console.ReadLine());
            studentList[studentCount] = new Student(name, marks);
            studentCount++;
            Console.WriteLine("Student Added Successfully!");
        }
        static void ShowStudents()
        {
            Console.Clear();
            for (int i = 0; i < studentCount; i++)
            {
                Console.WriteLine("Name: " + studentList[i].Name + " | Marks: " + studentList[i].Marks);
            }
        }
        static void CalculateAggregate()
        {
            Console.Clear();
            double totalMarks = 0;
            for (int i = 0; i < studentCount; i++)
            {
                totalMarks = totalMarks + studentList[i].Marks;
            }
            double average = totalMarks / studentCount;
            Console.WriteLine("Aggregate (Average) Marks: " + average);
        }
        static void TopStudent()
        {
            Console.Clear();
            if (studentCount > 0)
            {
                Student top = studentList[0];
                for (int i = 1; i < studentCount; i++)
                {
                    if (studentList[i].Marks > top.Marks)
                    {
                        top = studentList[i];
                    }
                }
                Console.WriteLine("Top Student: " + top.Name + " with " + top.Marks + " marks.");
            }
        }
    }
}
