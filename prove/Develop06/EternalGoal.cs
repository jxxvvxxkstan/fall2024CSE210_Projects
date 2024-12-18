public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        return _points;
    }

    public override bool IsComplete()
    {
        return false; // Eternal goals are never complete
    }

    public override string GetDetailsString()
    {
        return $"[ ] {_name} - {_description} ({_points} points each time)";
    }

    public override string GetStringRepresentation()
    {
        return $"{GetType().Name}|{_name}|{_description}|{_points}";
    }
}