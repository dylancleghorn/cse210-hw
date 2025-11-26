using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>();

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you think about good things in your life by listing them.")
    {
        _prompts.Add("Who are people that you appreciate?");
        _prompts.Add("What are some of your strengths?");
        _prompts.Add("What are things that made you smile recently?");
        _prompts.Add("What are some spiritual experiences you remember?");
    }

    public void Run()
    {
        DisplayStartingMessage();

        Random random = new Random();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();

        string prompt = _prompts[random.Next(_prompts.Count)];
        Console.WriteLine("--- " + prompt + " ---");
        Console.WriteLine();

        Console.WriteLine("You may begin in:");
        ShowCountdown(5);
        Console.WriteLine();

        List<string> answers = new List<string>();

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            if (response != "")
            {
                answers.Add(response);
            }
        }

        Console.WriteLine();
        Console.WriteLine("You listed " + answers.Count + " items.");
        DisplayEndingMessage();
    }
}
