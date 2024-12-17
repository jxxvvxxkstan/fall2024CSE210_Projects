using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts;

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public override void Run()
    {
        DisplayStartingMessage();
        Random rand = new Random();
        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);
        ShowSpinner(5);

        Console.WriteLine("Start listing items:");
        List<string> items = new List<string>();
        int secondsPassed = 5;
        while (secondsPassed < _duration)
        {
            if (Console.KeyAvailable)
            {
                items.Add(Console.ReadLine());
                secondsPassed += 2; // Approximate time spent for each entry
            }
            else
            {
                Thread.Sleep(1000);
                secondsPassed++;
            }
        }
        Console.WriteLine($"You listed {items.Count} items.");
        DisplayEndingMessage();
    }
}