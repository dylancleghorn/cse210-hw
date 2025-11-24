using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a base "Assignment" object
        Assignment a1 = new Assignment("Dylan Cleghorn", "Algebra");
        Console.WriteLine(a1.GetSummary());
        Console.WriteLine();

        // Now create the derived class assignments
        MathAssignment a2 = new MathAssignment("Ingrid Cleghorn", "Calculus", "10", "1-20");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());
        Console.WriteLine();


        WritingAssignment a3 = new WritingAssignment("Elijah Cleghorn", "Numbers", "The Number Two");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
        Console.WriteLine();

    }
}