using System;

namespace Lab_6_task2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var repository = new Repository<int>();
                repository.Add(1);
                repository.Add(2);
                repository.Add(3);

                var result = repository.Find(x => x > 1);

                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}