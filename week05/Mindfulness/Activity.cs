using System;
using System.Collections.Generic;
using System.Threading;

class Activity
{
    // Kept simple on purpose, like a student design.
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the " + _name + ".");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        Console.Write("How long, in seconds, would you like your session? ");
        string input = Console.ReadLine();
        _duration = int.Parse(input); // no try/catch to keep it beginner level

        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        Console.WriteLine();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine("You have completed " + _duration + " seconds of the " + _name + ".");
        ShowSpinner(3);
        Console.WriteLine();
    }

    protected void ShowSpinner(int seconds)
    {
        // Simple spinner, like they show in the course
        List<string> frames = new List<string>();
        frames.Add("|");
        frames.Add("/");
        frames.Add("-");
        frames.Add("\\");

        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int index = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(frames[index]);
            Thread.Sleep(300);
            Console.Write("\b \b");

            index = index + 1;
            if (index >= frames.Count)
            {
                index = 0;
            }
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);

            // Clear the number by overwriting with spaces
            Console.Write("\r" + new string(' ', 20) + "\r");
        }
    }

}
