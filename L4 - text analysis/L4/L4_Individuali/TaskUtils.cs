using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace L4_Individuali
{
    class TaskUtils
    {
        /// <summary>
        /// Finds the longest word of the file
        /// </summary>
        /// <param name="punctuation">punctuation symbols</param>
        /// <param name="CFa1">output file</param>
        /// <param name="longest">longet word</param>
        /// <param name="maxLength">longest length</param>
        /// <param name="lines">primary data</param>
        public static void LongestInFile(char[] punctuation, out string longest,
                                         string input, out int maxLength,
                                         out string[] lines)
        {
            lines = File.ReadAllLines(input, Encoding.UTF8);
            longest = "";
            maxLength = 0;
            foreach (string line in lines)
            {
                if (line.Length > 0)
                {
                    if (LongestWord(line, punctuation).Length > maxLength)
                    {
                        longest = LongestWord(line, punctuation);
                        maxLength = LongestWord(line, punctuation).Length;
                    }
                }
            }
        }

        /// <summary>
        /// Finds the longest word of the line
        /// </summary>
        /// <param name="line">one line</param>
        /// <param name="punctuation">punctuation symbols</param>
        /// <returns>longest word</returns>
        private static string LongestWord(string line, char[] punctuation)
        {
            string[] parts = line.Split(punctuation,
                StringSplitOptions.RemoveEmptyEntries);
            string longestWord = "";
            foreach (string word in parts)
            {
                if (word.Length > longestWord.Length)
                {
                    longestWord = word;
                }
            }
            return longestWord;
        }

        /// <summary>
        /// Finds the longest word by length
        /// </summary>
        /// <param name="punctuation">punctuation symbols</param>
        /// <param name="maxLength">longest length</param>
        /// <param name="lines">primary data</param>
        /// <returns>longest word</returns>
        public static string LongestOthers(char[] punctuation,
                                            int maxLength, 
                                            string[] lines)
        {
            string longest = "";
            foreach (string line in lines)
            {
                string[] parts = line.Split(punctuation,
                StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in parts)
                {
                    if (word.Length == maxLength)
                    {
                        longest = word;
                    }
                }
            }
            return longest;
        }

        /// <summary>
        /// Finds the longest words by decreasing length
        /// </summary>
        /// <param name="punctuation">punctuation symbols</param>
        /// <param name="longest">longest word</param>
        /// <param name="maxLength">longest length</param>
        /// <param name="lines">primary data</param>
        /// <returns>list of longest words</returns>
        public static List<string> LongestWords(char[] punctuation,
                                                string longest, 
                                                int maxLength,
                                                string[] lines)
        {
            List<string> longestWords = new List<string>();
            int counter = 0;
            while (counter < 10 && maxLength > 0)
            {
                foreach (string line in lines)
                {                   
                    string[] parts = line.Split(punctuation,
                    StringSplitOptions.RemoveEmptyEntries);
                    foreach (string word in parts)
                    {
                        if (word == longest && !longestWords.Contains(word)
                            || word.Length == longest.Length && 
                            !longestWords.Contains(word))
                        {
                            longestWords.Add(word);
                            counter++;
                        }                       
                    }
                }
                maxLength--;
                longest = LongestOthers(punctuation, maxLength, lines);
            }
            return longestWords;
        }

        /// <summary>
        /// Makes a list of longest words of both files
        /// </summary>
        /// <param name="List1">first list of longest words</param>
        /// <param name="List2">second list of longest words</param>
        /// <returns>formatted list of two lists</returns>
        public static List<string> BothFilesLongest (List<string> List1,
                                                     List<string> List2)            
        {
            List<string> NewList = new List<string>();
            for (int i = 0; i < List1.Count; i++)
            {
                if (List2.Contains(List1[i]) &&
                    !NewList.Contains(List1[i]))
                {
                    NewList.Add(List1[i]);
                }
            }
            return NewList;
        }

        /// <summary>
        /// Makes a list of the first file longest words
        /// </summary>
        /// <param name="List1">first list of longest words</param>
        /// <param name="List2">second list of longest words</param>
        /// <returns>list of longest words in only one file</returns>
        public static List<string> OneLongest(List<string> List1,
                                              List<string> List2)
        {
            List<string> NewList = new List<string>();
            for (int i = 0; i < List1.Count; i++)
            {
                if (!List2.Contains(List1[i]) &&
                    !NewList.Contains(List1[i]))
                {
                    NewList.Add(List1[i]);
                }
            }
            return NewList;
        }

        /// <summary>
        /// Counts the repetition of word
        /// </summary>
        /// <param name="List">list of longest words</param>
        /// <param name="punct">punctuation symbols</param>
        /// <param name="longestWord">longest word</param>
        /// <param name="lines">primary data</param>
        /// <returns>repetition of word</returns>
        public static int Repetition (char[] punct, 
                                      string longestWord,
                                      string[] lines)
        {
            int counter = 0;
            foreach (string line in lines)
            {
                string[] parts = line.Split(punct,
                StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in parts)
                {
                    if (word == longestWord)
                    {
                        counter++;
                    }
                }
            }
            return counter;            
        }

        /// <summary>
        /// Sorts results by word length
        /// </summary>
        /// <param name="ListBoth">list of longest words</param>
        public static void Sort(List<string> ListBoth)
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < ListBoth.Count - 1; i++)
                {
                    string first = ListBoth[i];
                    string second = ListBoth[i + 1];
                    if (first.Length < second.Length)
                    {
                        ListBoth[i] = second;
                        ListBoth[i + 1] = first;
                        flag = true;
                    }
                }
            }
        }
    }
}
