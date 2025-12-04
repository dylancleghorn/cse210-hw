using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    class GoalManager
    {
        private List<Goal> _goals = new List<Goal>();
        private int _score = 0;

        public void Start()
        {
            string choice = "";

            while (choice != "6")
            {
                Console.Clear();
                Console.WriteLine($"You have {_score} points.");
                Console.WriteLine();
                Console.WriteLine("Menu Options:");
                Console.WriteLine("  1. Create New Goal");
                Console.WriteLine("  2. List Goals");
                Console.WriteLine("  3. Record Event");
                Console.WriteLine("  4. Save Goals");
                Console.WriteLine("  5. Load Goals");
                Console.WriteLine("  6. Quit");
                Console.Write("Select a choice from the menu: ");
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    CreateGoal();
                }
                else if (choice == "2")
                {
                    ListGoalDetails();
                    Pause();
                }
                else if (choice == "3")
                {
                    RecordEvent();
                    Pause();
                }
                else if (choice == "4")
                {
                    SaveGoals();
                    Pause();
                }
                else if (choice == "5")
                {
                    LoadGoals();
                    Pause();
                }
                else if (choice == "6")
                {
                    Console.WriteLine("Goodbye.");
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                    Pause();
                }
            }
        }

        private void Pause()
        {
            Console.WriteLine();
            Console.Write("Press Enter to continue...");
            Console.ReadLine();
        }

        private void ListGoalNames()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals yet.");
            }
            else
            {
                for (int i = 0; i < _goals.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_goals[i].ShortName}");
                }
            }
        }

        private void ListGoalDetails()
        {
            Console.WriteLine();
            Console.WriteLine("Goals:");

            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals yet.");
            }
            else
            {
                for (int i = 0; i < _goals.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
                }
            }
        }

        private void CreateGoal()
        {
            Console.Clear();
            Console.WriteLine("The types of Goals are:");
            Console.WriteLine("  1. Simple Goal");
            Console.WriteLine("  2. Eternal Goal");
            Console.WriteLine("  3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");
            string typeChoice = Console.ReadLine();

            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();

            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();

            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine());

            if (typeChoice == "1")
            {
                SimpleGoal goal = new SimpleGoal(name, description, points);
                _goals.Add(goal);
            }
            else if (typeChoice == "2")
            {
                EternalGoal goal = new EternalGoal(name, description, points);
                _goals.Add(goal);
            }
            else if (typeChoice == "3")
            {
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());

                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());

                ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus);
                _goals.Add(goal);
            }
            else
            {
                Console.WriteLine("Invalid type. Goal not created.");
            }
        }

        private void RecordEvent()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("You do not have any goals yet.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Which goal did you accomplish?");
            ListGoalNames();
            Console.Write("Enter the number of the goal: ");

            int index = int.Parse(Console.ReadLine());
            if (index < 1 || index > _goals.Count)
            {
                Console.WriteLine("Invalid goal number.");
                return;
            }

            Goal selectedGoal = _goals[index - 1];
            int points = selectedGoal.RecordEvent();
            _score += points;

            if (points > 0)
            {
                Console.WriteLine($"You earned {points} points!");
            }
            else
            {
                Console.WriteLine("No points earned.");
            }

            Console.WriteLine($"You now have {_score} points.");
        }

        private void SaveGoals()
        {
            Console.Write("What is the filename for the goal file? ");
            string fileName = Console.ReadLine();

            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                outputFile.WriteLine(_score);

                foreach (Goal g in _goals)
                {
                    outputFile.WriteLine(g.GetStringRepresentation());
                }
            }

            Console.WriteLine("Goals saved.");
        }

        private void LoadGoals()
        {
            Console.Write("What is the filename for the goal file? ");
            string fileName = Console.ReadLine();

            if (!File.Exists(fileName))
            {
                Console.WriteLine("That file does not exist.");
                return;
            }

            string[] lines = File.ReadAllLines(fileName);

            _goals.Clear();

            if (lines.Length == 0)
            {
                Console.WriteLine("File was empty.");
                return;
            }

            _score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split('|');

                string goalType = parts[0];

                if (goalType == "SimpleGoal")
                {
                    string name = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);
                    bool isComplete = bool.Parse(parts[4]);

                    SimpleGoal g = new SimpleGoal(name, description, points, isComplete);
                    _goals.Add(g);
                }
                else if (goalType == "EternalGoal")
                {
                    string name = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);

                    EternalGoal g = new EternalGoal(name, description, points);
                    _goals.Add(g);
                }
                else if (goalType == "ChecklistGoal")
                {
                    string name = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);
                    int amountCompleted = int.Parse(parts[4]);
                    int target = int.Parse(parts[5]);
                    int bonus = int.Parse(parts[6]);

                    ChecklistGoal g = new ChecklistGoal(name, description, points, target, bonus, amountCompleted);
                    _goals.Add(g);
                }
            }

            Console.WriteLine("Goals loaded.");
        }
    }
}
