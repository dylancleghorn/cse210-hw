using System;
using System.Threading;

class WimHofBreathingActivity : Activity
{
    public WimHofBreathingActivity()
        : base(
            "Wim Hof Breathing Activity",
            "This activity does simple Wim Hof style breathing: deep fast breaths and then a breath hold.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int round = 1;

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.WriteLine("=== Round " + round + " ===");
            Console.WriteLine("Take 30 deep breaths (in and out). Follow the cues.");
            Console.WriteLine();

            for (int i = 1; i <= 30; i++)
            {
                if (DateTime.Now >= endTime)
                {
                    break;
                }

                Console.Write("Breath " + i + " in... ");
                Thread.Sleep(1250);
                Console.Write(" out... ");
                Thread.Sleep(1250);
                Console.WriteLine();
            }

            if (DateTime.Now >= endTime)
            {
                break;
            }

            Console.WriteLine();
            Console.WriteLine("Now hold without taking a breath...");

            int holdTime = 90;

            for (int i = holdTime; i > 0; i--)
            {
                string text = "Holding: " + i + "   ";
                Console.Write(text);
                Thread.Sleep(1000);

                // Move back to start and erase what was printed
                Console.Write("\r" + new string(' ', text.Length) + "\r");
            }

            Console.WriteLine();
            Console.WriteLine("Breathe in and hold for 15 seconds.");
            ShowCountdown(15);
            Console.WriteLine("Gently breathe out and relax.");
            ShowCountdown(5);

            round = round + 1;
        }

        DisplayEndingMessage();
    }
}
