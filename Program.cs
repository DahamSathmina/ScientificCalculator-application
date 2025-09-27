using System;
using System.Collections.Generic;
using System.Linq;

class ScientificCalculator
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Scientific Console Calculator ===");

        bool running = true;

        while (running)
        {
            Console.WriteLine("\nSelect an operation:");
            Console.WriteLine("1. Add (+)");
            Console.WriteLine("2. Subtract (-)");
            Console.WriteLine("3. Multiply (*)");
            Console.WriteLine("4. Divide (/)");
            Console.WriteLine("5. Modulus (%)");
            Console.WriteLine("6. Power (^)");
            Console.WriteLine("7. Square Root (√)");
            Console.WriteLine("8. Factorial (!)");
            Console.WriteLine("9. Sin (degrees)");
            Console.WriteLine("10. Cos (degrees)");
            Console.WriteLine("11. Tan (degrees)");
            Console.WriteLine("12. Log (base 10)");
            Console.WriteLine("13. Ln (natural log)");
            Console.WriteLine("14. e^x");
            Console.WriteLine("15. Abs");
            Console.WriteLine("16. Exit");

            Console.Write("Enter choice (1-16): ");
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int choice) || choice < 1 || choice > 16)
            {
                Console.WriteLine("Invalid choice! Please enter a number between 1 and 16.");
                continue;
            }

            if (choice == 16)
            {
                Console.WriteLine("Exiting... Goodbye!");
                running = false;
                continue;
            }

            // Multi-number operations (1-6, 8-15)
            if ((choice >= 1 && choice <= 6) || (choice >= 8 && choice <= 15))
            {
                Console.WriteLine("Enter numbers separated by spaces:");
                string? numbersInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(numbersInput))
                {
                    Console.WriteLine("No numbers entered. Try again.");
                    continue;
                }

                string[] parts = numbersInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                List<double> numbers = new List<double>();

                foreach (var part in parts)
                {
                    if (double.TryParse(part, out double n))
                        numbers.Add(n);
                    else
                    {
                        Console.WriteLine($"Invalid number: {part}");
                        numbers.Clear();
                        break;
                    }
                }

                if (numbers.Count == 0) continue;

                double result = 0;

                switch (choice)
                {
                    case 1: // Add
                        result = numbers.Sum();
                        Console.WriteLine($"Result: {string.Join(" + ", numbers)} = {result}");
                        break;

                    case 2: // Subtract
                        result = numbers[0];
                        for (int i = 1; i < numbers.Count; i++)
                            result -= numbers[i];
                        Console.WriteLine($"Result: {string.Join(" - ", numbers)} = {result}");
                        break;

                    case 3: // Multiply
                        result = 1;
                        foreach (var n in numbers) result *= n;
                        Console.WriteLine($"Result: {string.Join(" * ", numbers)} = {result}");
                        break;

                    case 4: // Divide
                        result = numbers[0];
                        for (int i = 1; i < numbers.Count; i++)
                        {
                            if (numbers[i] == 0)
                            {
                                Console.WriteLine("Error: Division by zero!");
                                result = double.NaN;
                                break;
                            }
                            result /= numbers[i];
                        }
                        Console.WriteLine($"Result: {string.Join(" / ", numbers)} = {result}");
                        break;

                    case 5: // Modulus
                        result = numbers[0];
                        for (int i = 1; i < numbers.Count; i++)
                            result %= numbers[i];
                        Console.WriteLine($"Result: {string.Join(" % ", numbers)} = {result}");
                        break;

                    case 6: // Power
                        result = numbers[0];
                        for (int i = 1; i < numbers.Count; i++)
                            result = Math.Pow(result, numbers[i]);
                        Console.WriteLine($"Result: {string.Join(" ^ ", numbers)} = {result}");
                        break;

                    case 8: // Factorial
                        Console.WriteLine("Results:");
                        foreach (var n in numbers)
                        {
                            if (n < 0 || n != Math.Floor(n))
                                Console.WriteLine($"Factorial of {n} undefined (must be non-negative integer)!");
                            else
                            {
                                long factorial = 1;
                                for (int i = 1; i <= (int)n; i++)
                                    factorial *= i;
                                Console.WriteLine($"{n}! = {factorial}");
                            }
                        }
                        break;

                    case 9: // Sin
                        Console.WriteLine("Results:");
                        foreach (var n in numbers)
                            Console.WriteLine($"sin({n}°) = {Math.Sin(n * Math.PI / 180)}");
                        break;

                    case 10: // Cos
                        Console.WriteLine("Results:");
                        foreach (var n in numbers)
                            Console.WriteLine($"cos({n}°) = {Math.Cos(n * Math.PI / 180)}");
                        break;

                    case 11: // Tan
                        Console.WriteLine("Results:");
                        foreach (var n in numbers)
                            Console.WriteLine($"tan({n}°) = {Math.Tan(n * Math.PI / 180)}");
                        break;

                    case 12: // Log
                        Console.WriteLine("Results:");
                        foreach (var n in numbers)
                        {
                            if (n <= 0) Console.WriteLine($"log({n}) undefined!");
                            else Console.WriteLine($"log({n}) = {Math.Log10(n)}");
                        }
                        break;

                    case 13: // Ln
                        Console.WriteLine("Results:");
                        foreach (var n in numbers)
                        {
                            if (n <= 0) Console.WriteLine($"ln({n}) undefined!");
                            else Console.WriteLine($"ln({n}) = {Math.Log(n)}");
                        }
                        break;

                    case 14: // e^x
                        Console.WriteLine("Results:");
                        foreach (var n in numbers)
                            Console.WriteLine($"e^{n} = {Math.Exp(n)}");
                        break;

                    case 15: // Abs
                        Console.WriteLine("Results:");
                        foreach (var n in numbers)
                            Console.WriteLine($"abs({n}) = {Math.Abs(n)}");
                        break;
                }
            }
            else // Single-number operations (still only sqrt)
            {
                Console.Write("Enter a number: ");
                if (!double.TryParse(Console.ReadLine(), out double num1))
                {
                    Console.WriteLine("Invalid number. Try again.");
                    continue;
                }

                if (choice == 7) // Square Root
                {
                    if (num1 < 0)
                        Console.WriteLine("Error: Cannot calculate square root of a negative number!");
                    else
                        Console.WriteLine($"√{num1} = {Math.Sqrt(num1)}");
                }
            }
        }
    }
}


