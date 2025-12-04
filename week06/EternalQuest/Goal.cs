namespace EternalQuest
{
    abstract class Goal
    {
        private string _shortName;
        private string _description;
        private int _points;

        public string ShortName
        {
            get { return _shortName; }
        }

        public string Description
        {
            get { return _description; }
        }

        public int Points
        {
            get { return _points; }
        }

        public Goal(string shortName, string description, int points)
        {
            _shortName = shortName;
            _description = description;
            _points = points;
        }

        public abstract int RecordEvent();

        public abstract bool IsComplete();

        public virtual string GetDetailsString()
        {
            string status = IsComplete() ? "X" : " ";
            return $"[{status}] {ShortName} ({Description})";
        }

        public abstract string GetStringRepresentation();
    }
}
