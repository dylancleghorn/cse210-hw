using System.Text;

namespace ScriptureMemorizer
{
    public class Word
    {
        private string _text; // the word itself
        private bool _isHidden; // used to flag if the word is already hidden

        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

        public void Hide()
        {
            _isHidden = true;
        }

        public bool IsHidden()
        {
            return _isHidden;
        }

        public string GetDisplayText()
        {
            if (_isHidden == false)
            {
                return _text; // if not hidden, return regular text
            }

            // if hidden, return underscores
            StringBuilder builder = new StringBuilder(_text.Length);
            for (int index = 0; index < _text.Length; index++) // for each letter
            {
                char ch = _text[index];
                if (char.IsLetter(ch)) //this function makes it easy
                {
                    builder.Append('_');
                }
                else
                {
                    builder.Append(ch); // return punctuation instead of underscore
                }
            }
            return builder.ToString();
        }
    }
}
