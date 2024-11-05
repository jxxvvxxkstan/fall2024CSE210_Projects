using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        int userNumber = -1;
        while (userNumber != 0)
        {
            Console.Write("Enter a number: ");
            string userInput = Console.ReadLine();
            userNumber = int.Parse(userInput);
            
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        // Find sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        // Find average
        float average = ((float)sum) / numbers.Count;

        // Find max
        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        // Find smallest positive number
        int smallestPositive = int.MaxValue;
        foreach (int number in numbers)
        {
            if (number > 0 && number < smallestPositive)
            {
                smallestPositive = number;
            }
        }

        // Sort numbers
        numbers.Sort();

        // Output results
        Console.WriteLine($"The Sum is: {sum}");
        Console.WriteLine($"The Average is: {average}");
        Console.WriteLine($"The Max is: {max}");
        if (smallestPositive != int.MaxValue)
        {
            Console.WriteLine($"The Smallest Positive Number is: {smallestPositive}");
        }
        else
        {
            Console.WriteLine("There are no positive numbers in the list.");
        }

        Console.WriteLine("The Sorted List is: ");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}