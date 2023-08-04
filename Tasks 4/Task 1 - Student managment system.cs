using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int RollNumber { get; }
    public string Grade { get; set; }

    public Student(string name, int age, int rollNumber, string grade)
    {
        Name = name;
        Age = age;
        RollNumber = rollNumber;
        Grade = grade;
    }
}

class StudentList<T> where T : Student
{
    private List<T> students = new List<T>();

    public void AddStudent(T student)
    {
        students.Add(student);
    }

    public T GetStudentById(int rollNumber)
    {
        return students.FirstOrDefault(s => s.RollNumber == rollNumber);
    }

    public IEnumerable<T> SearchStudentsByName(string name)
    {
        return students.Where(s => s.Name.ToLower().Contains(name.ToLower()));
    }

    public void DisplayAllStudents()
    {
        foreach (var student in students)
        {
            Console.WriteLine("Name: " + student.Name " , Age: " + student.Age + ", Roll Number: " + student.RollNumber + ",  Grade: " + student.Grade);
        }
    }

    public void SerializeToJson(string filePath)
    {
        var json = JsonConvert.SerializeObject(students);
        File.WriteAllText(filePath, json);
    }

    public void DeserializeFromJson(string filePath)
    {
        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            students = JsonConvert.DeserializeObject<List<T>>(json);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var studentList = new StudentList<Student>();

        // Adding students
        studentList.AddStudent(new Student("John Doe", 18, 1001, "A"));
        studentList.AddStudent(new Student("Jane Smith", 19, 1002, "B"));
        // Add more students here...

        // Searching and displaying students
        Console.WriteLine("Searching for students by name:");
        var searchResults = studentList.SearchStudentsByName("John");
        foreach (var student in searchResults)
        {
            Console.WriteLine("Name: " + student.Name " , Age: " + student.Age + ", Roll Number: " + student.RollNumber + ",  Grade: " + student.Grade);
        }

        // Serializing and deserializing
        studentList.SerializeToJson("students.json");
        studentList.DeserializeFromJson("students.json");

        Console.ReadLine();
    }
}
