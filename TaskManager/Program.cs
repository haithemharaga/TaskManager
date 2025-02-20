﻿using System;
using System.Collections.Generic;
using System.IO;

namespace TaskManager
{
    class Program
    {
        static List<TaskItem> tasks = new List<TaskItem>();
        static string filePath = "tasks.txt";

        static void Main(string[] args)
        {
            LoadTasks();

            while (true)
            {
                Console.WriteLine("\nTask Manager");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Mark Task as Completed");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        ViewTasks();
                        break;
                    case "3":
                        MarkTaskCompleted();
                        break;
                    case "4":
                        SaveTasks();
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        static void AddTask()
        {
            Console.Write("Enter task description: ");
            string description = Console.ReadLine();
            tasks.Add(new TaskItem(description));
            Console.WriteLine("Task added.");
        }

        static void ViewTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
                return;
            }

            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }

        static void MarkTaskCompleted()
        {
            ViewTasks();
            Console.Write("Enter the task number to mark as completed: ");
            if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
            {
                tasks[taskNumber - 1].IsCompleted = true;
                Console.WriteLine("Task marked as completed.");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }
        }

        static void LoadTasks()
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 2)
                    {
                        tasks.Add(new TaskItem(parts[0]) { IsCompleted = bool.Parse(parts[1]) });
                    }
                }
            }
        }

        static void SaveTasks()
        {
            List<string> lines = new List<string>();
            foreach (var task in tasks)
            {
                lines.Add($"{task.Description}|{task.IsCompleted}");
            }
            File.WriteAllLines(filePath, lines);
            Console.WriteLine("Tasks saved.");
        }
    }
}