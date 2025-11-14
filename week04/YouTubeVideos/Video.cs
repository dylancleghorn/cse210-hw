using System;

class Video
{
    private string _title;
    private string _author;
    private int _length;
    private List<Comment>? _comments; // ? allows null; not all references have more than 1 verse 

    public Video(string title, string author, int length, List<Comment>? comments = null) // constructor
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = comments ?? new List<Comment>();

    }

    public void AddComment(string name, string text)
    {
        Comment comment = new Comment(name, text);
        _comments.Add(comment);
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine("#################");
        Console.WriteLine("##### VIDEO #####");
        Console.WriteLine("#################");
        Console.WriteLine();

        Console.WriteLine($"Video: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length (seconds): {_length}");
        Console.WriteLine();

        Console.WriteLine("----------------");
        Console.WriteLine("--- COMMENTS ---");
        Console.WriteLine("----------------");
        Console.WriteLine();

        foreach (Comment comment in _comments)
        {
            comment.DisplayCommentInfo();
        }

    }
}