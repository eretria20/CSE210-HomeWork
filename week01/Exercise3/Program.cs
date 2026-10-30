using System;

class Program
{
    static void Main(string[] args)
    {
        // Keep track of the user if they want to play again
        string playAgain = "yes";

        while (playAgain.ToLower() == "yes")
        {
            // For Parts 1 and 2, where the user specified the number
            // Console.Write("What is the magic number? ");
            // int magicNumber = int.Parse(Console.ReadLine());

            // For Part 3, where we use a random number
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = -1;
            int guessCount = 0;

            // We could also use a do-while loop here...
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (magicNumber > guess)
                {
                    Console.WriteLine("Higher");
                }
                else if (magicNumber < guess)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            // Identify how many guesses they made
            Console.WriteLine($"It took you {guessCount} guesses.");

            // Ask the user if they want to play again
            Console.Write("Do you want to play again (yes/no)? ");
            playAgain = Console.ReadLine();
            Console.WriteLine();
        }

        Console.WriteLine("Thank you for playing!");
    }
}
        
    

    



    
        
    
