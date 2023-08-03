using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

public enum TaskCategory
{
    Personal,
    Work,
    Errands
    // Add more categories as needed
}

public class Task
{
    public string Name { get; set; }
    public string Description { get; set; }
    public TaskCategory Category { get; set; }
    public bool IsCompleted { get; set; }
}

public class TaskManager
{
    private List<Task> tasks = new List<Task>();
    private readonly string filePath = "tasks.csv";

    public async Task LoadTasksAsync()
    {
        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string[] taskData = await reader.ReadLineAsync().ConfigureAwait(false);
                    Task task = new Task
                    {
                        Name = taskData[0],
                        Description = taskData[1],
                        Category = (TaskCategory)Enum.Parse(typeof(TaskCategory), taskData[2]),
                        IsCompleted = bool.Parse(taskData[3])
                    };
                    tasks.Add(task);
                }
            }
        }
    }

    public async Task SaveTasksAsync()
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (Task task in tasks)
            {
                await writer.WriteLineAsync($"{task.Name},{task.Description},{task.Category},{task.IsCompleted}").ConfigureAwait(false);
            }
        }
    }

    public void AddTask(Task task)
    {
        tasks.Add(task);
    }

    public List<Task> GetTasksByCategory(TaskCategory category)
    {
        return tasks.Where(task => task.Category == category).ToList();
    }

    public void DisplayTasks(List<Task> taskList)
    {
        foreach (Task task in taskList)
        {
            Console.WriteLine($"Name: {task.Name}");
            Console.WriteLine($"Description: {task.Description}");
            Console.WriteLine($"Category: {task.Category}");
            Console.WriteLine($"Completed: {task.IsCompleted}");
            Console.WriteLine();
        }
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        TaskManager taskManager = new TaskManager();
        await taskManager.LoadTasksAsync();

        while (true)
        {
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks by Category");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Description: ");
                    string description = Console.ReadLine();
                    Console.Write("Category (Personal, Work, Errands): ");
                    TaskCategory category = (TaskCategory)Enum.Parse(typeof(TaskCategory), Console.ReadLine());
                    Task newTask = new Task
                    {
                        Name = name,
                        Description = description,
                        Category = category,
                        IsCompleted = false
                    };
                    taskManager.AddTask(newTask);
                    await taskManager.SaveTasksAsync();
                    break;
                case "2":
                    Console.WriteLine("Select Category (Personal, Work, Errands): ");
                    TaskCategory selectedCategory = (TaskCategory)Enum.Parse(typeof(TaskCategory), Console.ReadLine());
                    List<Task> tasksByCategory = taskManager.GetTasksByCategory(selectedCategory);
                    taskManager.DisplayTasks(tasksByCategory);
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
cv 