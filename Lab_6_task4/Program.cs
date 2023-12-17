using System;

namespace Lab_6_task4
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var scheduler = new TaskScheduler<string, int>();
                TaskExecution<string> execution = task => Console.WriteLine($"Executing task: {task}");

                while (true)
                {
                    Console.WriteLine("Enter a task and its priority (or 'execute' to execute the highest priority task):");
                    var input = Console.ReadLine();

                    if (input == "execute")
                    {
                        scheduler.ExecuteNext(execution);
                    }
                    else
                    {
                        var parts = input.Split(' ');
                        if (parts.Length != 2)
                        {
                            Console.WriteLine("Invalid input. Please enter a task and its priority.");
                            continue;
                        }

                        var task = parts[0];
                        if (!int.TryParse(parts[1], out var priority))
                        {
                            Console.WriteLine("Invalid priority. Please enter a number.");
                            continue;
                        }

                        scheduler.AddTask(task, priority);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}