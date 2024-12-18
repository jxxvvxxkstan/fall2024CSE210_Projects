using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2024, 12, 18), 30, 3.5),
            new Cycling(new DateTime(2024, 12, 18), 60, 20.0),
            new Swimming(new DateTime(2024, 12, 18), 45, 40)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}