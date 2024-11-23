using System;

class Program
{
    static void Main(string[] args)
    {
        // Example scripture
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        Scripture scripture = new Scripture(reference, "Trust in the Lord with all thine heart and lean not unto thine own understanding");

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3); // Hide 3 random words

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("All words are hidden.");

                while (true)
                {
                    Console.WriteLine("Type 'r' to start revealing words or 'quit' to exit.");
                    string revealInput = Console.ReadLine();

                    if (revealInput.ToLower() == "quit")
                    {
                        return;
                    }
                    else if (revealInput.ToLower() == "r")
                    {
                        scripture.RevealWords(3); // Reveal 3 random words

                        if (!scripture.IsCompletelyHidden())
                        {
                            Console.Clear();
                            Console.WriteLine(scripture.GetDisplayText());
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("All words have been revealed.");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please type 'reveal' or 'quit'.");
                    }
                }
                break;
            }
        }
    }
}