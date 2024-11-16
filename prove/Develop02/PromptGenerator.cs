using System;
using System.Collections.Generic;

public class PromptGenerator
{
    // List of prompts for journal entries 
    public List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is the first thing you will do today?",
        "What is the last thought you remember before you go to sleep?",
        "What did you dream about last night?",
        "What is the first thought that comes to your mind when you wake up?",
        "How did your dream end last night?",
        "What do you think about the weather today?",
        "What are your plans for the next hour?",
        "Are there any tasks/projects you need to do today? If so, is there any way you can get started on those tasks/projects early in the morning before other distractions arise",
        "What are your plans for the rest of the day?",
        "How can you improve today?",
        "If money were no object, what would be on your bucket list?",
        "What is on your mind right now?",
        "What was the last thing someone told you they were doing?",
        "What do you want to do that you have not done yet this year?",
        "Who was the first person to mind when you woke up this morning?",
        "What are you most grateful for today?",
        "What are you looking forward to today?",
        "What would it be and why if you could change one thing about yourself?",
        "How did you feel yesterday?",
        "Who do you love more than anything else in this world, and why do they mean so much to you?",
        "What does your ideal day look like?",
        "What would you like to accomplish today?",
        "What did you learn from yesterday?",
        "How are you feeling right now?",
        "What are you passionate about right now? Why is this important to you?",
        "What do you need to be happy today?",
        "Do you regret yesterday or have plans for today that you know will make tomorrow better than today (or worse)? If so, what are they?",
        "What can you do to make today better than yesterday?",
        "What was the best part of your day yesterday and why?",
        "What worries you most in the world right now?",
        "What is your greatest strength? Your weakness?",
        "List three things you love about yourself",
        "Make a list of all the things that are stressing you out right now, and then write down how you can turn them into something positive.",
        "Make a list of all the things that make you feel at peace.",
        "Write down 3 things that happened yesterday that you are grateful for.",
        "Write down 5 things that make you feel good today YOU",
        "What do you want to accomplish today? (What big things do you want to do?)",
        "What will help you achieve your dream life?",
        "What three things could go wrong today, and how would they affect your life?",
        "Who made a difference in your life yesterday (in whatever way)? How did they make a difference?",
        "Where would it be and why if you could go anywhere in the world?",
        "What is one favorite thing that always makes you smile, no matter what is happening in life?",
        "What would it be and why if you could change one thing in the world?",
        "Who do you want to connect with today?",
        "Who do you want to avoid today (if anyone)?",
        "What are you planning for your next vacation?",
        "What is your favorite way to start the day?",
        "What is your favorite part of the day? And why?",
        "How was your week in general: good, bad, or just okay? And why?",
        "If today were a vacation, what would it be called and why?"
    };

    // Get a random prompt from the list
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}