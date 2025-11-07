using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAllEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Your journal is empty.\n");
            return;
        }

        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry.GetDisplayText());
        }
    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            //add headers
            outputFile.WriteLine("\"Date\",\"Prompt\",\"Response\"");
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.GetSaveCsv());
            }
        }

        Console.WriteLine($"Journal saved to \"{fileName}\".\n");
    }

    public void LoadFromFile(string fileName)
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.\n");
            return;
        }

        string[] lines = File.ReadAllLines(fileName);
        _entries.Clear();

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            if (string.IsNullOrWhiteSpace(line)) continue;

            // skip header if present
            if (i == 0 && line.StartsWith("\"Date\",\"Prompt\",\"Response\""))
            {
                continue;
            }

            Entry entry = Entry.FromCsvLine(line);
            _entries.Add(entry);
        }

        Console.WriteLine($"Loaded {_entries.Count} entr{(_entries.Count == 1 ? "y" : "ies")} from \"{fileName}\".\n");
    }
}
