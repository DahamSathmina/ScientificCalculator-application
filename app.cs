using System;

public class MethodDemo
{
    public static void Main(string[] args)
    {
        GreetUser("Bob");
        int sum = AddNumbers(5, 7);
        Console.WriteLine($"Sum: {sum}");
    }

    // Method with no return value and one parameter
    public static void GreetUser(string userName)
    {
        Console.WriteLine($"Hello, {userName}!");
    }

    // Method with a return value and two parameters
    public static int AddNumbers(int num1, int num2)
    {
        return num1 + num2;
    }
}