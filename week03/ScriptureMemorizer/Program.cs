// enhancement: added multiple scriptures to the library, and select 1 at random

using System;

class Program
{
    static void Main(string[] args)
    {
        // create an empty scripture library object
        ScriptureLibrary scriptureLibrary = new ScriptureLibrary();

        //populate the hardcoded verses into the library private list 
        scriptureLibrary.DefaultVerses();

        // return a random scripture from the library list
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

            // Hide random words
            selectedScripture.HideRandomWords(3); // 3 = three words will be hidden each time

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
