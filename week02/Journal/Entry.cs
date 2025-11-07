public class Entry
{
    private string _date;
    private string _prompt;
    private string _response;

    public Entry(string date, string prompt, string response)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
    }

    public string GetDisplayText()
    {
        return $"Date: {_date}\nPrompt: {_prompt}\nResponse: {_response}\n";
    }

    private static string CsvEscape(string value)
    {
        if (value == null) return "";
        // keep file to one line per entry
        value = value.Replace("\r\n", "\\n").Replace("\n", "\\n");
        // escape quotes by doubling them
        value = value.Replace("\"", "\"\"");
        // wrap every field in quotes
        return $"\"{value}\"";
    }

    private static string CsvUnescape(string value)
    {
        if (string.IsNullOrEmpty(value)) return "";
        // remove outer quotes if present
        if (value.Length >= 2 && value.StartsWith("\"") && value.EndsWith("\""))
        {
            value = value.Substring(1, value.Length - 2);
        }
        // unescape doubled quotes
        value = value.Replace("\"\"", "\"");
        // restore line breaks placeholder
        value = value.Replace("\\n", "\n");
        return value;
    }

    public string GetSaveCsv()
    {
        // "date","prompt","response"
        return string.Join(",", new string[]
        {
            CsvEscape(_date),
            CsvEscape(_prompt),
            CsvEscape(_response)
        });
    }

    public static Entry FromCsvLine(string line)
    {
        // iterate and split on commas that are NOT inside quotes
        var parts = new System.Collections.Generic.List<string>();
        bool inQuotes = false;
        int start = 0;
        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];
            if (c == '"')
            {
                // toggle inQuotes unless this is an escaped quote ("")
                bool isEscaped = (i + 1 < line.Length && line[i + 1] == '"');
                if (isEscaped)
                {
                    i++; // skip the second quote
                }
                else
                {
                    inQuotes = !inQuotes;
                }
            }
            else if (c == ',' && !inQuotes)
            {
                parts.Add(line.Substring(start, i - start));
                start = i + 1;
            }
        }
        // add last piece
        parts.Add(line.Substring(start));

        if (parts.Count != 3)
        {
            return new Entry("Unknown", "Corrupted Entry", line);
        }

        string date = CsvUnescape(parts[0]);
        string prompt = CsvUnescape(parts[1]);
        string response = CsvUnescape(parts[2]);
        return new Entry(date, prompt, response);
    }
}
