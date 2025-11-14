using System;
using System.Collections.Generic;
using System.Text;

public class Scripture
{
    private Reference _reference; // the book/ch/v reference
    private List<Word> _words; // array to split the words into 
    private Random _random;

    public Scripture(Reference reference, string text) // constructor of a scripture object: ref + text
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        List<string> tokens = SplitIntoWords(text); // separate words into array, ie "tokens"
        for (int index = 0; index < tokens.Count; index++)
        {
            Word word = new Word(tokens[index]);
            _words.Add(word);
        }
    }

    public string GetDisplayText()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(_reference.GetDisplayText()); //get reference text
        builder.Append('\n');

        for (int index = 0; index < _words.Count; index++)
        {
            if (index > 0)
            {
                builder.Append(' '); // add space before each word
            }
            builder.Append(_words[index].GetDisplayText()); //add the word
        }

        return builder.ToString();
    }

    public void HideRandomWords(int numberToHide)
    {
        List<int> candidateIndices = new List<int>(); // will store non-hidden word index numbers
        for (int index = 0; index < _words.Count; index++)
        {
            Word word = _words[index]; //get the word
            if (word.IsHidden() == false) //check properties
            {
                candidateIndices.Add(index); // add idx as potential word to hide
            }
        }

        if (candidateIndices.Count == 0)
        {
            return;
        }

        int countToHide = numberToHide;
        if (countToHide > candidateIndices.Count)
        {
            countToHide = candidateIndices.Count;
        }

        Shuffle(candidateIndices); // randomize the indexes

        for (int i = 0; i < countToHide; i++)
        {
            int wordIndex = candidateIndices[i];
            _words[wordIndex].Hide(); // hide the first X indexes in the shuffled list
        }
    }

    public bool IsCompletelyHidden()
    {
        for (int index = 0; index < _words.Count; index++)
        {
            Word word = _words[index];
            if (word.IsHidden() == false)
            {
                return false;
            }
        }
        return true;
    }

    private List<string> SplitIntoWords(string text)
    {
        List<string> parts = new List<string>(); // array to hold each word

        // split the string where ever there is a space, tab, line break
        string[] rawParts = text.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        for (int index = 0; index < rawParts.Length; index++)
        {
            parts.Add(rawParts[index]);
        }

        return parts;
    }

    private void Shuffle(List<int> list) //note: copied this function, ai said it was a "best practice" method of randomizing
    {
        for (int index = list.Count - 1; index > 0; index--)
        {
            int randomIndex = _random.Next(index + 1);
            int temp = list[index];
            list[index] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
