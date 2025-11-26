using System;
using System.Collections.Generic;

class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>();
    private List<string> _questions = new List<string>();

    public ReflectionActivity()
        : base(
            "Reflection Activity",
            "This activity will help you think about times in your life when you have shown strength and kindness.")
    {
        _prompts.Add("Think of a time when you helped someone who was sad.");
        _prompts.Add("Think of a time when you did something that was hard for you.");
        _prompts.Add("Think of a time when you forgave someone.");
        _prompts.Add("Think of a time when you chose the right even when it was hard.");

        _questions.Add("Why was this experience important to you?");
        _questions.Add("What did you learn about yourself?");
        _questions.Add("How did you feel during this experience?");
        _questions.Add("How can you remember this experience in the future?");
        _questions.Add("What would you say to someone else about this experience?");
    }

    public void Run()
    {
        DisplayStartingMessage();

        Random random = new Random();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();

        string prompt = _prompts[random.Next(_prompts.Count)];
        Console.WriteLine("--- " + prompt + " ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on the following questions:");
        Console.WriteLine("Press enter to begin.");
        Console.ReadLine();

        // Ask questions one by one until time is done
        while (DateTime.Now < endTime)
        {
            string question = _questions[random.Next(_questions.Count)];
            Console.WriteLine();
            Console.WriteLine("> " + question);
            ShowSpinner(5);
        }

        DisplayEndingMessage();
    }
}
