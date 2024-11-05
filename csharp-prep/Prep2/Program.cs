using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string inputGrade = Console.ReadLine();
        int gradePercent = int.Parse(inputGrade);

        string letter = "";

        if (gradePercent >= 90)
        {
            letter = "A";
        }
        else if (gradePercent >= 80)
        {
            letter = "B";
        }
        else if (gradePercent >= 70)
        {
            letter = "C";
        }
        else if (gradePercent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        if (gradePercent < 90 && letter != "F")
        {
            int lastDigit = gradePercent % 10;
            if (lastDigit >= 7)
            {
                letter += "+";
            }
            else if (lastDigit < 3)
            {
                letter += "-";
            }
        }

        Console.WriteLine($"Your final grade is: {letter}.");
        
        if (gradePercent >= 70)
        {
            Console.WriteLine("Congratulations, you passed!");
        }
        else
        {
            Console.WriteLine("You failed the class. Better luck next time.");
        }
    }
}