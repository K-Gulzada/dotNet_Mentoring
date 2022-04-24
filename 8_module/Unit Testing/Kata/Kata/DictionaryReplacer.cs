using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata
{
    public class DictionaryReplacer
    {
        public string ReplaceWordsCorrespondingValue(string str, Dictionary<string, string> dict)
        {
            var result = string.Empty;

            if (str == null || dict == null)
            {
                throw new ArgumentNullException();
            }

            if (dict.Count != 0)
            {
                string[] words = str.Split(' ');

                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i].Contains("$"))
                    {
                        words[i] = words[i].Replace("$", "");
                        if (dict.ContainsKey(words[i]))
                        {
                            words[i] = dict[words[i]];
                        }
                    }
                }

                for (int i = 0; i < words.Length; i++)
                {
                    result += words[i];
                    result += " ";
                }
            }

            return result.TrimEnd();
        }
    }
}
