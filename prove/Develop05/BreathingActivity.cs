public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Box Breathing Activity", "This activity will help you relax by guiding you through a box breathing technique. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();
        int secondsPassed = 0;
        while (secondsPassed + 16 <= _duration)
        {
            Console.WriteLine("Breathe in...");
            ShowCountDown(4);
            Console.WriteLine("Hold...");
            ShowInterval(4);
            Console.WriteLine("Breathe out...");
            ShowCountDown(4);
            Console.WriteLine("Hold...");
            ShowInterval(4);
            secondsPassed += 16; // Each cycle takes 16 seconds
        }

        // Handle remaining seconds if any
        int remainingSeconds = _duration - secondsPassed;
        if (remainingSeconds > 0)
        {
            if (remainingSeconds <= 4)
            {
                Console.WriteLine("Breathe in...");
                ShowCountDown(remainingSeconds);
            }
            else if (remainingSeconds <= 8)
            {
                Console.WriteLine("Breathe in...");
                ShowCountDown(4);
                Console.WriteLine("Hold...");
                ShowInterval(remainingSeconds - 4);
            }
            else if (remainingSeconds <= 12)
            {
                Console.WriteLine("Breathe in...");
                ShowCountDown(4);
                Console.WriteLine("Hold...");
                ShowInterval(4);
                Console.WriteLine("Breathe out...");
                ShowCountDown(remainingSeconds - 8);
            }
            else
            {
                Console.WriteLine("Breathe in...");
                ShowCountDown(4);
                Console.WriteLine("Hold...");
                ShowInterval(4);
                Console.WriteLine("Breathe out...");
                ShowCountDown(4);
                Console.WriteLine("Hold...");
                ShowInterval(remainingSeconds - 12);
            }
        }

        DisplayEndingMessage();
    }

    private void ShowInterval(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.Write("\b \b"); // Clear the last dot character
        Console.WriteLine();
    }
}