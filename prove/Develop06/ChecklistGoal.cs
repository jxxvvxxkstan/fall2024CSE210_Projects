public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public void SetAmountCompleted(int amountCompleted)
    {
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
            if (_amountCompleted == _target)
            {
                DisplayCongratulatoryAnimation();
                return _points + _bonus;
            }
            return _points;
        }
        return 0;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {_name} - {_description} ({_points} points, Completed {_amountCompleted}/{_target} times, Bonus: {_bonus} points)";
    }

    public override string GetStringRepresentation()
    {
        return $"{GetType().Name}\n{_name}\n{_description}\n{_points}\n{_amountCompleted}\n{_target}\n{_bonus}";
    }

    private void DisplayCongratulatoryAnimation()
    {
        Console.Clear();
        Console.WriteLine("Congratulations!");
        string message = "You have completed your checklist goal!";
        for (int i = 0; i < message.Length; i++)
        {
            Console.Write(message[i]);
            System.Threading.Thread.Sleep(100); // Simulate typing effect
        }
        Console.WriteLine();
        System.Threading.Thread.Sleep(1000); // Pause for a moment
        Console.Clear();
    }
}