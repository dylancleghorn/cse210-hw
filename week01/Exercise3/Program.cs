using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int randomNumber = randomGenerator.Next(1, 101);

        int number = 0;

        while (number != randomNumber)
        {
            Console.Write("Guess a number: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out number))
            {
                if (randomNumber > number)
                {
                    Console.WriteLine("Higher");
                }
                else if (randomNumber < number)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("Bingo!");
                }

            }
            else
            {
                Console.WriteLine("Please enter an integer!");
            }
        }

    }
}