using System;
using System.Collections.Generic;
using System.Linq;
class ScientificCalculator
{
    static void Main()
    {
        Console.WriteLine("\n==== Scientific Console XCalculator ====");
        bool running = true;
        List<string> history = new List<string>();
        double lastResult = 0; // store last result

        // Helper function to simplify numbers
        string Simplify(double value) => value % 1 == 0 ? ((long)value).ToString() : Math.Round(value, 6).ToString();

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
            Console.WriteLine("16. View History");
            Console.WriteLine("17. Clear History");
            Console.WriteLine("18. Exit");

            Console.Write("Enter choice (1-18): ");
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 18)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid choice! Enter 1-18.");
                Console.ResetColor();
                continue;
            }
            if (choice == 18)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Exiting... Goodbye!");
                Console.ResetColor();
                break;
            }

            if (choice == 16)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n=== Calculation History ===");
                if (history.Count == 0) Console.WriteLine("No calculations yet.");
                else history.ForEach(h => Console.WriteLine(h));
                Console.ResetColor();
                continue;
            }

            if (choice == 17)
            {
                history.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("History cleared!");
                Console.ResetColor();
                continue;
            }

            // Multi-number operations or single-number
            if ((choice >= 1 && choice <= 6) || (choice >= 8 && choice <= 15))
            {
                List<double> numbers = new List<double>();
                Console.WriteLine("Enter numbers one by one (type 'done' to finish). Press Enter to use last result:");

                while (true)
                {
                    Console.Write("Number: ");
                    string? input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input)) // default last result
                    {
                        numbers.Add(lastResult);
                        break;
                    }

                    if (input.Trim().ToLower() == "done") break;

                    if (double.TryParse(input, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out double n))
                        numbers.Add(n);
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid number. Try again.");
                        Console.ResetColor();
                    }
                }

                if (numbers.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("No numbers entered. Returning to menu.");
                    Console.ResetColor();
                    continue;
                }

                string calculationText = "";
                double result = 0;

                switch (choice)
                {
                    case 1: result = numbers.Sum(); 
                        calculationText = $"{string.Join(" + ", numbers.Select(Simplify))} = {Simplify(result)}"; 
                        break;
                    
                    case 2: result = numbers[0]; 
                        for (int i = 1; i < numbers.Count; i++) result -= numbers[i]; 
                        calculationText = $"{string.Join(" - ", numbers.Select(Simplify))} = {Simplify(result)}"; 
                        break;
                    
                    case 3: result = 1; 
                        foreach (var n in numbers) result *= n; calculationText = $"{string.Join(" * ", numbers.Select(Simplify))} = {Simplify(result)}"; 
                        break;
                    
                    case 4:
                        result = numbers[0];
                        bool divideByZero = false;
                        for (int i = 1; i < numbers.Count; i++)
                        {
                            if (numbers[i] == 0) { Console.ForegroundColor = ConsoleColor.Red; 
                                Console.WriteLine("Error: Division by zero!"); 
                                Console.ResetColor(); 
                                divideByZero = true; 
                                break; 
                            }
                            result /= numbers[i];
                        }
                        calculationText = divideByZero ? "Division by zero error" : $"{string.Join(" / ", numbers.Select(Simplify))} = {Simplify(result)}";
                        break;

                    case 5: result = numbers[0]; for (int i = 1; i < numbers.Count; i++) 
                            result %= numbers[i]; 
                        calculationText = $"{string.Join(" % ", numbers.Select(Simplify))} = {Simplify(result)}"; 
                        break;
                    
                    case 6: result = numbers[0]; for (int i = 1; i < numbers.Count; i++) 
                            result = Math.Pow(result, numbers[i]); 
                        calculationText = $"{string.Join(" ^ ", numbers.Select(Simplify))} = {Simplify(result)}"; 
                        break;

                    case 8: // Factorial
                        Console.WriteLine("Results:");
                        foreach (var n in numbers)
                        {
                            if (n < 0 || n != Math.Floor(n)) { 
                                Console.ForegroundColor = ConsoleColor.Red; 
                                Console.WriteLine($"Factorial of {n} undefined!"); 
                                Console.ResetColor(); 
                                history.Add($"Factorial of {n} undefined"); }
                            else { long factorial = 1; 
                                for (int i = 1; i <= (int)n; i++) factorial *= i; 
                                Console.ForegroundColor = ConsoleColor.Green; 
                                Console.WriteLine($"{n}! = {factorial}"); 
                                Console.ResetColor(); 
                                history.Add($"{n}! = {factorial}"); 
                                lastResult = factorial; 
                            }
                        }
                        continue;

                    case 9: foreach (var n in numbers) { result = Math.Sin(n * Math.PI / 180); 
                            Console.ForegroundColor = ConsoleColor.Green; 
                            Console.WriteLine($"sin({Simplify(n)}°) = {Simplify(result)}"); 
                            Console.ResetColor(); 
                            history.Add($"sin({Simplify(n)}°) = {Simplify(result)}"); 
                            lastResult = result; 
                        } continue;
                   
                    case 10: foreach (var n in numbers) { result = Math.Cos(n * Math.PI / 180); 
                            Console.ForegroundColor = ConsoleColor.Green; 
                            Console.WriteLine($"cos({Simplify(n)}°) = {Simplify(result)}"); 
                            Console.ResetColor(); 
                            history.Add($"cos({Simplify(n)}°) = {Simplify(result)}"); 
                            lastResult = result; 
                        } continue;
                   
                    case 11: foreach (var n in numbers) { result = Math.Tan(n * Math.PI / 180); 
                            Console.ForegroundColor = ConsoleColor.Green; 
                            Console.WriteLine($"tan({Simplify(n)}°) = {Simplify(result)}"); 
                            Console.ResetColor(); 
                            history.Add($"tan({Simplify(n)}°) = {Simplify(result)}"); 
                            lastResult = result; 
                        } continue;
                   
                    case 12: foreach (var n in numbers) { if (n <= 0) { 
                                Console.ForegroundColor = ConsoleColor.Red; 
                                Console.WriteLine($"log({n}) undefined!"); 
                                Console.ResetColor(); 
                                history.Add($"log({n}) undefined"); 
                            } else { result = Math.Log10(n); 
                                Console.ForegroundColor = ConsoleColor.Green; 
                                Console.WriteLine($"log({Simplify(n)}) = {Simplify(result)}"); 
                                Console.ResetColor(); 
                                history.Add($"log({Simplify(n)}) = {Simplify(result)}"); 
                                lastResult = result; 
                            } } continue;
                    
                    case 13: foreach (var n in numbers) { if (n <= 0) { 
                                Console.ForegroundColor = ConsoleColor.Red; 
                                Console.WriteLine($"ln({n}) undefined!"); 
                                Console.ResetColor(); history.Add($"ln({n}) undefined"); 
                            } else { result = Math.Log(n); 
                                Console.ForegroundColor = ConsoleColor.Green; 
                                Console.WriteLine($"ln({Simplify(n)}) = {Simplify(result)}"); 
                                Console.ResetColor(); 
                                history.Add($"ln({Simplify(n)}) = {Simplify(result)}"); 
                                lastResult = result; 
                            } } continue;
                   
                    case 14: foreach (var n in numbers) { result = Math.Exp(n); 
                            Console.ForegroundColor = ConsoleColor.Green; 
                            Console.WriteLine($"e^{Simplify(n)} = {Simplify(result)}"); 
                            Console.ResetColor(); 
                            history.Add($"e^{Simplify(n)} = {Simplify(result)}"); 
                            lastResult = result; 
                        } continue;

                    case 15: foreach (var n in numbers) { result = Math.Abs(n); 
                            Console.ForegroundColor = ConsoleColor.Green; 
                            Console.WriteLine($"abs({Simplify(n)}) = {Simplify(result)}"); 
                            Console.ResetColor(); 
                            history.Add($"abs({Simplify(n)}) = {Simplify(result)}"); 
                            lastResult = result; 
                        } continue;
                }

                if (!string.IsNullOrEmpty(calculationText))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Result: {calculationText}");
                    Console.ResetColor();
                    history.Add(calculationText);
                    lastResult = result;
                }
            }
            else // Single-number operation (Square Root)
            {
                Console.Write($"Enter a number (Press Enter to use last result {Simplify(lastResult)}): ");
                string? input = Console.ReadLine();
                double num1 = string.IsNullOrWhiteSpace(input) ? lastResult : double.Parse(input);

                if (choice == 7)
                {
                    if (num1 < 0) { 
                        Console.ForegroundColor = ConsoleColor.Red; 
                        Console.WriteLine("Error: Cannot calculate square root of a negative number!"); 
                        Console.ResetColor(); 
                    }
                    else { double sqrtResult = Math.Sqrt(num1); 
                        Console.ForegroundColor = ConsoleColor.Green; 
                        Console.WriteLine($"√{Simplify(num1)} = {Simplify(sqrtResult)}"); 
                        Console.ResetColor(); 
                        history.Add($"√{Simplify(num1)} = {Simplify(sqrtResult)}"); 
                        lastResult = sqrtResult; 
                    }
                }
            }
        }
    }
}






