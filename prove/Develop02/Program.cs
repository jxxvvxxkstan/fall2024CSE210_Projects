using System;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        // Create instances of Journal and PromptGenerator 
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        // Display the Welcome message once
        Console.WriteLine("");
        Console.WriteLine("Welcome to the Journal Program!");

        // Main loop to handle user input
        while (running)
        {
            // Display menu options
            Console.WriteLine("Please select one of the following choices");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();

            // Handle user choice
            switch (choice)
            {
                case "1":
                    // Write a new journal entry
                    WriteNewEntry(journal, promptGenerator);
                    break;
                case "2":
                    // Display all journal entries
                    journal.DisplayAll();
                    break;
                case "3":
                    // Load journal entries from a file
                    LoadJournal(journal);
                    break;
                case "4":
                    // Save journal entries to a file
                    SaveJournal(journal);
                    break;
                case "5":
                    // Exit the program
                    running = false;
                    break;
                default:
                    // Handle invalid input
                    Console.WriteLine("");
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }
    
    static void WriteNewEntry(Journal journal, PromptGenerator promptGenerator)
    {
        // Get a random prompt and display it
        string prompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine(prompt);
        Console.Write("> "); 
        string entryText = Console.ReadLine();

        // Create a new journal entry
        Entry newEntry = new Entry
        {
            _date = DateTime.Now.ToString("yyyy/MM/dd"),
            _promptText = prompt,
            _entryText = entryText
        };

        // Add the entry to the journal
        journal.AddEntry(newEntry);
        Console.WriteLine("");
        Console.WriteLine("Entry added!");
    }

    static void LoadJournal(Journal journal)
    {
        Console.Write("Enter the filename: ");
        string filename = Console.ReadLine();

        // Check if the filename ends with ".json" and append if necessary
        if (!filename.EndsWith(".json"))
        {
            filename += ".json";
        }
        
        // Check if the file exists before attempting to load it
        if (File.Exists(filename))
        {
            // Load the journal from the file
            journal.LoadFromFile(filename);
            Console.WriteLine("");
            Console.WriteLine("Journal loaded!");
        }
        else
        {
            // Handle file not found
            Console.WriteLine("");
            Console.WriteLine($"File '{filename}' not found. Check the spell or if the file exists.");
        }
    }

    static void SaveJournal(Journal journal)
    {
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();

        // Check if the filename ends with ".json" and append if necessary
        if (!filename.EndsWith(".json"))
        {
            filename += ".json";
        }

        // Save the journal to the file
        journal.SaveToFile(filename);
        Console.WriteLine("");
        Console.WriteLine("Journal saved!");
    }    
}