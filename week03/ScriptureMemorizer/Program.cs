using System;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            // create a list of scriptures
            ScriptureLibrary scriptureLibrary = new ScriptureLibrary();

            //populate the hardcoded verses into the list 
            scriptureLibrary.DefaultVerses();

            // request a random scripture
            Scripture selectedScripture = scriptureLibrary.GetRandomScripture();

            while (true)
            {
                Console.Clear();
                Console.WriteLine(selectedScripture.GetDisplayText()); //write scripture to console
                Console.WriteLine();
                Console.Write("Press Enter to hide words (or type 'quit' to end): ");

                string inputText = Console.ReadLine();

                inputText = inputText.Trim().ToLower();
                if (inputText == "quit")
                {
                    break;
                }

                // Hide a few random words each time
                selectedScripture.HideRandomWords(3);

                if (selectedScripture.IsCompletelyHidden())
                {
                    Console.Clear();
                    Console.WriteLine(selectedScripture.GetDisplayText());
                    Console.WriteLine();
                    Console.WriteLine("(All words are now hidden. Program ending.)");
                    break;
                }
            }
        }
    }
}
