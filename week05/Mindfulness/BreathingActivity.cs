using System;

class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by guiding you through slow breathing. Focus on your breath.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in... ");
            Console.WriteLine();

            ShowCountdown(4);
            Console.WriteLine();

            if (DateTime.Now >= endTime)
            {
                break;
            }

            Console.Write("Breathe out... ");
            Console.WriteLine();

            ShowCountdown(4);
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}
