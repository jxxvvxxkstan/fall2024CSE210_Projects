using System;

public class Entry
{
    //Properties for the entry date, prompt, and text
    public string _date { get; set; }
    public string _promptText { get; set; }
    public string _entryText { get; set; }

    //Display the entry
    public void Display()
    {
        Console.Write($"Date: {_date} - ");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"{_entryText}");
        Console.WriteLine(); 
    }
}