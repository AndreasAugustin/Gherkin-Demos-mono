using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csharp
{
    class Soundex
    {
        private const int MAX_CODE_LENGTH = 4;
        private Dictionary<char, string> encodingsMap { get; } = new Dictionary<char, string> {
            {'b', "1"},
            {'f', "1"},
            {'p', "1"},
            {'v', "1"},

            {'c', "2"},
            {'g', "2"},
            {'j', "2"},
            {'k', "2"},
            {'q', "2"},
            {'s', "2"},
            {'x', "2"},
            {'z', "2"},
            
            {'d', "3"},
            {'t', "3"},
            
            {'l', "4"},
       
            {'m', "5"},
            {'n', "5"},
            
            {'r', "6"},
        };
        private const string NOT_A_DIGIT = "*";

        public string Encode(string word)
        {
            return ZeroPad(UpperFront(Head(word))
                + Tail(EncodedDigits(word)));
        }

        internal string EncodedDigit(char letter)
        {
            return encodingsMap.ContainsKey(Lower(letter)) ?
                encodingsMap[Lower(letter)]
                : NOT_A_DIGIT; 
        }

        private char Lower(char character)
        {
            return char.ToLower(character);
        }

        private string UpperFront(string word)
        {
            return word.Substring(0, 1).ToUpper();
        }

        private string Head(string word)
        {
            return word.Substring(0, 1);
        }

        private string Tail(string word)
        {
            return word.Substring(1);
        }

        private string EncodedDigits(string word)
        {
            return string.IsNullOrEmpty(word) ?
                NOT_A_DIGIT 
                : EncodeTail(EncodeHead(word), word).ToString();
        }

        private StringBuilder EncodeHead(string word)
        {
            return new StringBuilder(EncodedDigit(word.FirstOrDefault()));
        }

        private StringBuilder EncodeTail(StringBuilder encoding, string word)
        {
            foreach(var letter in Tail(word))
            {
                if (IsComplete(encoding))
                {
                    break;
                }
                EncodeLetter(encoding, letter);
            }
            return encoding;
        }

        private void EncodeLetter(StringBuilder encoding, char letter)
        {
            var digit = EncodedDigit(letter);
            if (!digit.Equals(NOT_A_DIGIT) &&
                    !digit.Equals(LastDigit(encoding.ToString())))
            {
                encoding.Append(digit);
            }
        }

        private string LastDigit(string encoding)
        {
            return string.IsNullOrEmpty(encoding)?
                NOT_A_DIGIT
                : encoding.Substring(encoding.Length - 1);
        }

        private bool IsComplete(StringBuilder encoding)
        {
            return encoding.Length == MAX_CODE_LENGTH;
        }

        private string ZeroPad(string word)
        {
            var zerosNeeded = MAX_CODE_LENGTH - word.Length;

            var builder = new StringBuilder(word);

            for (var i = 0; i < zerosNeeded; i++)
            {
                builder.Append("0");
            }

            return builder.ToString();
        }

    }
}
