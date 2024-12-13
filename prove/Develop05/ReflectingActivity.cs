using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity() : base("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public override void Run()
    {
        DisplayStartingMessage();
        Random rand = new Random();

        int promptsToShow = Math.Min(3, _duration / 10); // Show up to 3 prompts, adjusting for the duration
        for (int i = 0; i < promptsToShow; i++)
        {
            Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);
            ShowSpinner(5);

            int secondsPassed = 5;
            while (secondsPassed < (_duration / promptsToShow))
            {
                Console.WriteLine(_questions[rand.Next(_questions.Count)]);
                ShowSpinner(5);
                secondsPassed += 5;
            }
        }

        DisplayEndingMessage();
    }
}