// MY CREATIVITY: I Added the following to the Scripture Memorizer program:
// 1. Loads a library of scriptures from an external "scriptures.txt" file, allowing for a variety of scriptures to be memorized.
// 2. Added a "hint" command that reveals one randomly chosen hidden word using Word.Show().
// 3. Preserves punctuation marks (commas, periods, semicolons) when hiding words, so they remain visible in the displayed text.

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> library = LoadScriptures("scriptures.txt");
        Random random = new Random();
        Scripture scripture = library[random.Next(library.Count)];

        string userInput = "";

        while (userInput.ToLower() != "quit" && !scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress enter to continue, type 'hint' for a clue, or type 'quit' to finish:");

            userInput = Console.ReadLine().Trim();
            
// Handle user input for hint or hiding words
            if (userInput.ToLower() == "hint")
            {
                scripture.RevealRandomWord();
            }
            else if (userInput.ToLower() != "quit")
            {
                scripture.HideRandomWords(3);
            }
        }

        if (scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nAll words hidden! Congratulations! You have memorized the scripture!");
        }
    }
// Load scriptures from a text file
    static List<Scripture> LoadScriptures(string filePath)
    {
        List<Scripture> scriptures = new List<Scripture>();

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
// Split the line into parts and create Scripture objects
                string[] parts = line.Split('|');
                if (parts.Length == 4)
                {
                    Reference reference = new Reference(parts[0], int.Parse(parts[1]), int.Parse(parts[2]));
                    scriptures.Add(new Scripture(reference, parts[3]));
                }
                else if (parts.Length == 5)
                {
                    Reference reference = new Reference(parts[0], int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]));
                    scriptures.Add(new Scripture(reference, parts[4]));
                }
            }
        }

        if (scriptures.Count == 0)
        {
            Reference fallbackRef = new Reference("Proverbs", 3, 5, 6);
            scriptures.Add(new Scripture(fallbackRef, "Trust in the Lord with all thine heart and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."));
        }

        return scriptures;
    }
}