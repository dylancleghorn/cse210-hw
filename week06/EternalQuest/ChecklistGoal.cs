namespace EternalQuest
{
    class ChecklistGoal : Goal
    {
        private int _amountCompleted;
        private int _target;
        private int _bonus;

        public ChecklistGoal(string shortName, string description, int points, int target, int bonus, int amountCompleted = 0)
            : base(shortName, description, points)
        {
            _target = target;
            _bonus = bonus;
            _amountCompleted = amountCompleted;
        }

        public override int RecordEvent()
        {
            _amountCompleted++;

            int pointsEarned = Points;

            if (_amountCompleted == _target)
            {
                pointsEarned += _bonus;
            }

            return pointsEarned;
        }

        public override bool IsComplete()
        {
            return _amountCompleted >= _target;
        }

        public override string GetDetailsString()
        {
            string status = IsComplete() ? "X" : " ";
            return $"[{status}] {ShortName} ({Description}) -- Completed {_amountCompleted}/{_target}";
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal|{ShortName}|{Description}|{Points}|{_amountCompleted}|{_target}|{_bonus}";
        }
    }
}
