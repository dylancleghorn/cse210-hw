// Enhancement: added csv functionality

using System;

public class Program
{
    private static Journal _journal = new Journal();
    private static PromptGenerator _promptGenerator = new PromptGenerator();

    public static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            ShowMenu();
            Console.Write("Choose an option (1-5): ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry();
                    break;
                case "2":
                    _journal.DisplayAllEntries();
                    break;
                case "3":
                    SaveJournal();
                    break;
                case "4":
                    LoadJournal();
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Hasta la vista, baby!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose between 1-5.\n");
                    break;
            }
        }
    }

    private static void ShowMenu()
    {
        Console.WriteLine("Journal Menu");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Save the journal to a file");
        Console.WriteLine("4. Load the journal from a file");
        Console.WriteLine("5. Quit");
        Console.WriteLine();
    }

    private static void WriteNewEntry()
    {
        string prompt = _promptGenerator.GetRandomPrompt();
        Console.WriteLine("Prompt: " + prompt);
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(response))
        {
            Console.WriteLine("Empty response. Entry not added.\n");
            return;
        }

        DateTime currentTime = DateTime.Now;
        string dateText = currentTime.ToShortDateString();

        Entry newEntry = new Entry(dateText, prompt, response);
        _journal.AddEntry(newEntry);

        Console.WriteLine("Entry recorded!\n");
    }

    private static void SaveJournal()
    {
        Console.Write("Enter filename to save (just the name, no extension): ");
        string fileName = Console.ReadLine();

        // If the user presses Enter with no input, handle it
        if (string.IsNullOrWhiteSpace(fileName))
        {
            Console.WriteLine("Save canceled (no filename entered).\n");
            return;
        }

        //  ensure .csv extension 
        if (!fileName.EndsWith(".csv"))
        {
            fileName += ".csv";
        }

        _journal.SaveToFile(fileName);
    }


    private static void LoadJournal()
    {
        Console.Write("Enter filename to load: ");
        string fileName = Console.ReadLine();
        _journal.LoadFromFile(fileName);
    }
}
