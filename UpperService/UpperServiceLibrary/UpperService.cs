using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;

namespace UpperServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class UpperService : IUpperService
    {
        public string Capitalize(string str)
        {
            return str = Regex.Replace(str, @"(^\w)|(\s\w)", m => m.Value.ToUpper());
        }

        public string CountOfSymbols(string str)
        {
            return str.Length.ToString();
        }

        public string FirstLetterOfSentenceToUpper(string str)
        {
            //string dot = ".";
            //int indexOfDot = str.IndexOf(dot);
            //return str.Substring(0, indexOfDot + 1) + char.ToUpper(str[indexOfDot + 1]) + str.Substring(indexOfDot + 2);

            bool IsNewSentense = true;
            var result = new StringBuilder(str.Length);
            for (int i = 0; i < str.Length; i++)
            {
                if (IsNewSentense && char.IsLetter(str[i]))
                {
                    result.Append(char.ToUpper(str[i]));
                    IsNewSentense = false;
                }
                else
                    result.Append(str[i]);

                if (str[i] == '!' || str[i] == '?' || str[i] == '.')
                {
                    IsNewSentense = true;
                }
            }

            return result.ToString();
        }

        public string Lower(string str)
        {
            return str.ToLower();
        }

        public string Refactor(string str, string before, string after)
        {
            return str.Replace(before, after);
        }

        public string Remove(string str, string word)
        {
            string removed = str.Replace(word, "");
            removed = Regex.Replace(removed, @"^\s", "");
            return removed = Regex.Replace(removed, @"\s+", " ");
        }

        public string SpaceAfterPunctuationMark(string str)
        {
            bool IsNewSentense = false;
            var result = new StringBuilder(str.Length);
            for (int i = 0; i < str.Length; i++)
            {
                if (IsNewSentense && char.IsLetter(str[i]))
                {
                    if (!char.IsWhiteSpace(str[i - 1]))
                    {
                        result.Append(' ');
                    }

                    //result.Append(char.ToUpper(str[i])); - The first letter of sentence goes toupper
                    result.Append(str[i]);
                    IsNewSentense = false;
                }
                else
                    result.Append(str[i]);

                if (str[i] == '!' || str[i] == '?' || str[i] == '.')
                {
                    IsNewSentense = true;
                }
            }

            return result.ToString();
        }

        public string Upper(string str)
        {
            return str.ToUpper();
        }
    }
}
