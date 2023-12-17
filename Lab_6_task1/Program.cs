using System;

namespace Lab_6_task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator<int> intCalculator = new Calculator<int>();
            Console.WriteLine($"Додавання: {intCalculator.PerformOperation(5, 3, intCalculator.Addition)}");
            Console.WriteLine($"Віднімання: {intCalculator.PerformOperation(5, 3, intCalculator.Subtraction)}");
            Console.WriteLine($"Множення: {intCalculator.PerformOperation(5, 3, intCalculator.Multiplication)}");
            Console.WriteLine($"Ділення: {intCalculator.PerformOperation(5, 3, intCalculator.Division)}");

            Calculator<double> doubleCalculator = new Calculator<double>();
            Console.WriteLine($"Додавання: {doubleCalculator.PerformOperation(5.0, 3.0, doubleCalculator.Addition)}");
            Console.WriteLine($"Віднімання: {doubleCalculator.PerformOperation(5.0, 3.0, doubleCalculator.Subtraction)}");
            Console.WriteLine($"Множення: {doubleCalculator.PerformOperation(5.0, 3.0, doubleCalculator.Multiplication)}");
            Console.WriteLine($"Ділення: {doubleCalculator.PerformOperation(5.0, 3.0, doubleCalculator.Division)}");
            
            try
            {
                Console.WriteLine(doubleCalculator.PerformOperation(5.0, 0.0, doubleCalculator.Division));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
    }
}