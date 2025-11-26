// Create addition: Wim Hof breathing method option

using System;

class Program
{
    static void Main(string[] args)
    {
        string choice = "";

        while (choice != "5")
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("-------------------");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Wim Hof Breathing Activity");
            Console.WriteLine("5. Quit");
            Console.WriteLine();
            Console.Write("Choose an option: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity act = new BreathingActivity();
                act.Run();
            }
            else if (choice == "2")
            {
                ReflectionActivity act = new ReflectionActivity();
                act.Run();
            }
            else if (choice == "3")
            {
                ListingActivity act = new ListingActivity();
                act.Run();
            }
            else if (choice == "4")
            {
                WimHofBreathingActivity act = new WimHofBreathingActivity();
                act.Run();
            }
            else if (choice == "5")
            {
                Console.WriteLine("Goodbye!");
                Console.WriteLine("Press enter to exit.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("That was not a valid option.");
                Console.WriteLine("Press enter to try again.");
                Console.ReadLine();
            }
        }
    }
}
