using System;
using System.Collections.Generic;

namespace StudentGradeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Student Grade Calculator\n");

            Console.Write("Enter your name: ");
            string studentName = Console.ReadLine();

            int numSubjects;
            do
            {
                Console.Write("Enter the number of subjects you have taken: ");
            } while (!int.TryParse(Console.ReadLine(), out numSubjects) || numSubjects <= 0);

            Dictionary<string, double> grades = new Dictionary<string, double>();
            for (int i = 0; i < numSubjects; i++)
            {
                Console.Write($"Enter the name of subject {i + 1}: ");
                string subjectName = Console.ReadLine();

                double grade;
                Console.Write($"Enter the grade obtained for {subjectName}: ");
                grade = double.Parse(Console.ReadLine());
                grades.Add(subjectName, grade);
            }

            double averageGrade = CalculateAverageGrade(grades);

            Console.WriteLine("\n-------- Report Card --------");
            Console.WriteLine($"Student Name: {studentName}");

            Console.WriteLine("\nSubject Grades:");
            foreach (var subjectGrade in grades)
            {
                Console.WriteLine($"{subjectGrade.Key}: {subjectGrade.Value}");
            }

            Console.WriteLine($"\nAverage Grade: {averageGrade:F2}");

            Console.ReadLine();
        }

        static double CalculateAverageGrade(Dictionary<string, double> grades)
        {
            if (grades.Count == 0)
            {
                return 0;
            }

            double totalGrade = 0;
            foreach (var grade in grades.Values)
            {
                totalGrade += grade;
            }

            return totalGrade / grades.Count;
        }
    }
}
