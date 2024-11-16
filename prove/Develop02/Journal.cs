using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    // List to store journal entries
    public List<Entry> _entries = new List<Entry>();

    // Add a new entry to the journal
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    // Display all entries in the journal
    public void DisplayAll()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    // Save the journal entries to a file in JSON format
    public void SaveToFile(string file)
    {
        string json = JsonSerializer.Serialize(_entries, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(file, json);
    }

    // Load journal entries from a file in JSON format 
    public void LoadFromFile(string file)
    {
        if (File.Exists(file))
        {
            string json = File.ReadAllText(file);
            _entries = JsonSerializer.Deserialize<List<Entry>>(json);
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}