using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numberList = new List<int>();

        int num = -1;
        while (num != 0)
        {
            Console.Write("Enter an integer (enter 0 to quit): ");

            string answer = Console.ReadLine();
            num = int.Parse(answer);

            if (num != 0)
            {
                numberList.Add(num);
            }
        }

        int sum = 0;
        foreach (int number in numberList)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        float average = ((float)sum) / numberList.Count;
        Console.WriteLine($"The average is: {average}");

        int max = numberList[0];

        foreach (int n in numberList)
        {
            if (n > max)
            {

                max = n;
            }
        }

        Console.WriteLine($"The max is: {max}");
    }
}