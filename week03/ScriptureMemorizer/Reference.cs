namespace ScriptureMemorizer
{
    public class Reference
    {
        private string _book;
        private int _chapter;
        private int _verse;
        private int? _endVerse; // ? allows null; not all references have more than 1 verse 

        public Reference(string book, int chapter, int startVerse, int? endVerse = null)
        {
            _book = book;
            _chapter = chapter;
            _verse = startVerse;
            _endVerse = endVerse;
        }

        public string GetDisplayText()
        {
            if (_endVerse.HasValue)
            {
                return _book + " " + _chapter + ":" + _verse + "-" + _endVerse.Value;
            }
            else
            {
                return _book + " " + _chapter + ":" + _verse;
            }
        }
    }
}
