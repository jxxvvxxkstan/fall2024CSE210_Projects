using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("Eternal Quest");
            Console.WriteLine($"You have {_score} points.");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            Console.WriteLine(); 

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"Total Score: {_score}");
        Console.WriteLine(); 
    }

    private void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
        }
        else
        {
            Console.WriteLine("The goals are:");
            for (int i = 0; i < _goals.Count; i++)
            {
                var goal = _goals[i];
                string goalDetails = $"{i + 1}. {goal.GetDetailsString()}";
                Console.WriteLine(goalDetails);
            }
        }
        Console.WriteLine(); 
    }

    private void CreateGoal()
    {
        Console.WriteLine("Create New Goal");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string choice = Console.ReadLine();
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid choice. Goal not created.");
                break;
        }
        Console.WriteLine(); 
    }

    private void RecordEvent()
    {
        ListGoalDetails();
        Console.Write("Enter the number of the goal you accomplished: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _goals.Count)
        {
            index -= 1; // Adjust for zero-based index
            int points = _goals[index].RecordEvent();
            _score += points;
            Console.WriteLine($"Congratulations! You have earned {points} points!");
            Console.WriteLine($"You now have {_score} points!");

            // Display a congratulatory message with simple animation if a checklist goal is finished
            if (_goals[index] is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
            {
                Console.WriteLine("Congratulations on completing your checklist goal!");
                for (int i = 0; i < 5; i++)
                {
                    Console.Write(".");
                    System.Threading.Thread.Sleep(500);
                }
                Console.WriteLine(" Well done!");
            }
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
        Console.WriteLine(); 
    }

    private void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved.");
        Console.WriteLine(); 
    }

    private void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        if (File.Exists(filename))
        {
            _goals.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                if (!int.TryParse(reader.ReadLine(), out _score))
                {
                    Console.WriteLine("Invalid file format. Unable to load goals.");
                    return;
                }

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length < 4)
                    {
                        Console.WriteLine("Invalid file format. Unable to load goals.");
                        return;
                    }

                    string goalType = parts[0];
                    string name = parts[1];
                    string description = parts[2];
                    if (!int.TryParse(parts[3], out int points))
                    {
                        Console.WriteLine("Invalid file format. Unable to load goals.");
                        return;
                    }

                    switch (goalType)
                    {
                        case "SimpleGoal":
                            if (parts.Length != 5 || !bool.TryParse(parts[4], out bool isComplete))
                            {
                                Console.WriteLine("Invalid file format. Unable to load goals.");
                                return;
                            }
                            SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                            if (isComplete) simpleGoal.RecordEvent();
                            _goals.Add(simpleGoal);
                            break;
                        case "EternalGoal":
                            _goals.Add(new EternalGoal(name, description, points));
                            break;
                        case "ChecklistGoal":
                            if (parts.Length != 7 || !int.TryParse(parts[4], out int amountCompleted) || !int.TryParse(parts[5], out int target) || !int.TryParse(parts[6], out int bonus))
                            {
                                Console.WriteLine("Invalid file format. Unable to load goals.");
                                return;
                            }
                            ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
                            checklistGoal.SetAmountCompleted(amountCompleted);
                            _goals.Add(checklistGoal);
                            break;
                        default:
                            Console.WriteLine("Invalid file format. Unable to load goals.");
                            return;
                    }
                }
            }
            Console.WriteLine("Goals loaded.");
        }
        else
        {
            Console.WriteLine("No saved goals found.");
        }
        Console.WriteLine(); 
    }
}