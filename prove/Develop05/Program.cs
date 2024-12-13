class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear(); // Clear the console at the start of each iteration
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Box Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");

            int choice = int.Parse(Console.ReadLine());
            if (choice == 4)
            {
                break;
            }

            Activity activity = choice switch
            {
                1 => new BreathingActivity(),
                2 => new ReflectingActivity(),
                3 => new ListingActivity(),
                _ => null
            };

            activity?.Run();

            // Clear the console after each activity
            Console.Clear();
        }
    }
}