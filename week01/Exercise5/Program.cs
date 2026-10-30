using System;

class Program
{
    static void Main(string[] args)
    {
        // 1. Call the welcome message function
        DisplayWelcome();

        // 2. Ask for the username and save the returned string
        string userName = PromptUserName();

        // 3. Ask for the user's favorite number and save the number
        int userNumber = PromptUserNumber();

        // 4. Pass both the name and the squared number to display the final result
        DisplayResult(userName, SquareNumber(userNumber));
    }

    // Displays the welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // Asks for user's name and returns it (as a string)
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    // Asks for user's favorite number and returns it (as an integer)
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    // Accepts an integer as a parameter and returns that number squared
    static int SquareNumber(int number)
    {
         return number * number;
        
    }

    // Square a given number
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}