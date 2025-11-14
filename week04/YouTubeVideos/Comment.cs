using System;

class Comment
{
    private string _name;
    private string _text;


    public Comment(string name, string text) // constructor
    {
        _name = name;
        _text = text;

    }

    public void DisplayCommentInfo()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine($"Comment: {_text}");
        Console.WriteLine();


    }
}