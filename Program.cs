using System;

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

            double num1 = 0, num2 = 0;

            // Operations that require only one number
            if (choice >= 7 && choice <= 15)
            {
                Console.Write("Enter a number: ");
                if (!double.TryParse(Console.ReadLine(), out num1))
                {
                    Console.WriteLine("Invalid number. Try again.");
                    continue;
                }
            }
            else // Two-number operations
            {
                Console.Write("Enter the first number: ");
                if (!double.TryParse(Console.ReadLine(), out num1))
                {
                    Console.WriteLine("Invalid number. Try again.");
                    continue;
                }

                Console.Write("Enter the second number: ");
                if (!double.TryParse(Console.ReadLine(), out num2))
                {
                    Console.WriteLine("Invalid number. Try again.");
                    continue;
                }
            }

            double result = 0;

            switch (choice)
            {
                case 1:
                    result = num1 + num2;
                    Console.WriteLine($"Result: {num1} + {num2} = {result}");
                    break;

                case 2:
                    result = num1 - num2;
                    Console.WriteLine($"Result: {num1} - {num2} = {result}");
                    break;

                case 3:
                    result = num1 * num2;
                    Console.WriteLine($"Result: {num1} * {num2} = {result}");
                    break;

                case 4:
                    if (num2 == 0)
                        Console.WriteLine("Error: Division by zero!");
                    else
                    {
                        result = num1 / num2;
                        Console.WriteLine($"Result: {num1} / {num2} = {result}");
                    }
                    break;

                case 5:
                    result = num1 % num2;
                    Console.WriteLine($"Result: {num1} % {num2} = {result}");
                    break;

                case 6:
                    result = Math.Pow(num1, num2);
                    Console.WriteLine($"Result: {num1}^{num2} = {result}");
                    break;

                case 7:
                    if (num1 < 0)
                        Console.WriteLine("Error: Cannot calculate square root of a negative number!");
                    else
                    {
                        result = Math.Sqrt(num1);
                        Console.WriteLine($"Result: √{num1} = {result}");
                    }
                    break;

                case 8:
                    if (num1 < 0 || num1 != Math.Floor(num1))
                        Console.WriteLine("Error: Factorial only works for non-negative integers.");
                    else
                    {
                        long factorial = 1;
                        for (int i = 1; i <= (int)num1; i++)
                            factorial *= i;
                        Console.WriteLine($"Result: {num1}! = {factorial}");
                    }
                    break;

                case 9:
                    result = Math.Sin(num1 * Math.PI / 180);
                    Console.WriteLine($"sin({num1}°) = {result}");
                    break;

                case 10:
                    result = Math.Cos(num1 * Math.PI / 180);
                    Console.WriteLine($"cos({num1}°) = {result}");
                    break;

                case 11:
                    result = Math.Tan(num1 * Math.PI / 180);
                    Console.WriteLine($"tan({num1}°) = {result}");
                    break;

                case 12:
                    if (num1 <= 0)
                        Console.WriteLine("Error: Log undefined for numbers ≤ 0!");
                    else
                    {
                        result = Math.Log10(num1);
                        Console.WriteLine($"log({num1}) = {result}");
                    }
                    break;

                case 13:
                    if (num1 <= 0)
                        Console.WriteLine("Error: Ln undefined for numbers ≤ 0!");
                    else
                    {
                        result = Math.Log(num1);
                        Console.WriteLine($"ln({num1}) = {result}");
                    }
                    break;

                case 14:
                    result = Math.Exp(num1);
                    Console.WriteLine($"e^{num1} = {result}");
                    break;

                case 15:
                    result = Math.Abs(num1);
                    Console.WriteLine($"abs({num1}) = {result}");
                    break;
            }
        }
    }
}
