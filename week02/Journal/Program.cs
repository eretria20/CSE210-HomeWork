// CREATIVITY:I structure 10 prompts to defeat "Writer's block for the user. And added a new metrics are Location and Mood, which will help the user reflect on their current state and environment
// 1. Location: ("Where are you right now?") Where the user is when writing the journal entry
// 2. Mood:("How are you feeling) How the user is feeling when writing the journal entry
using System;

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        
        string userChoice = "";

        Console.WriteLine("Welcome to the Journal Program!");

        // The application control loop
        while (userChoice != "5")
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            
            userChoice = Console.ReadLine();

            if (userChoice == "1")
            {
                Entry newEntry = new Entry();
                
             // Creative questions
                Console.Write("Where are you right now? ");
                newEntry._location = Console.ReadLine();
                
                Console.Write("How are you feeling? ");
                newEntry._mood = Console.ReadLine();

                newEntry._promptText = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"\nPrompt: {newEntry._promptText}");
                
                Console.Write("Your response > ");
                newEntry._entryText = Console.ReadLine();
                
                newEntry._date = DateTime.Now.ToShortDateString();

                theJournal.AddEntry(newEntry);
            }
            else if (userChoice == "2")
            {
                Console.WriteLine("\n--- Journal Entries ---");
                theJournal.DisplayAll();
            }
            else if (userChoice == "3")
            {
                Console.Write("\nWhat is the filename? ");
                string filename = Console.ReadLine();
                theJournal.LoadFromFile(filename);
                Console.WriteLine("Journal loaded successfully!");
            }
            else if (userChoice == "4")
            {
                Console.Write("\nWhat is the filename? ");
                string filename = Console.ReadLine();
                theJournal.SaveToFile(filename);
                Console.WriteLine("Journal saved successfully!");
            }
        }
        Console.WriteLine("\nGoodbye!");
    }
}
    