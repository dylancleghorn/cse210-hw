using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string grade = Console.ReadLine();

        double gradeDouble = double.Parse(grade);

        int gradeInt = (int)Math.Round(gradeDouble);

        string letter = "";

        if (gradeInt >= 90)
        {
            letter = "A";
        }
        else if (gradeInt >= 80)
        {
            letter = "B";
        }
        else if (gradeInt >= 70)
        {
            letter = "C";
        }
        else if (gradeInt >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is: {letter}");

        if (gradeInt >= 70)
        {
            Console.WriteLine("Yay! You passed!!");
        }
        else
        {
            Console.WriteLine("Not so great...");
        }
    }
}