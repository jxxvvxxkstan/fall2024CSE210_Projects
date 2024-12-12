public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Box Breathing Activity", "This activity will help you relax by guiding you through a box breathing technique. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();
        int secondsPassed = 0;
        while (secondsPassed + 16 <= _duration) // Each cycle now takes 16 seconds (4+4+4+4)
        {
            Console.WriteLine("Breathe in...");
            ShowCountDown(4);
            Console.WriteLine("Hold...");
            ShowCountDown(4);
            Console.WriteLine("Breathe out...");
            ShowCountDown(4);
            Console.WriteLine("Hold...");
            ShowCountDown(4);
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
                ShowCountDown(remainingSeconds - 4);
            }
            else if (remainingSeconds <= 12)
            {
                Console.WriteLine("Breathe in...");
                ShowCountDown(4);
                Console.WriteLine("Hold...");
                ShowCountDown(4);
                Console.WriteLine("Breathe out...");
                ShowCountDown(remainingSeconds - 8);
            }
            else
            {
                Console.WriteLine("Breathe in...");
                ShowCountDown(4);
                Console.WriteLine("Hold...");
                ShowCountDown(4);
                Console.WriteLine("Breathe out...");
                ShowCountDown(4);
                Console.WriteLine("Hold...");
                ShowCountDown(remainingSeconds - 12);
            }
        }

        DisplayEndingMessage();
    }
}