using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L4_Individuali
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFd1 = "Knyga1_2.txt";
            const string CFd2 = "Knyga2_2.txt";
            const string CFa1 = "Rodikliai.txt";

            char[] punctuation = { ' ', '.', ',', '!', '?',
                                  ':', ';', '(', ')', '\t' };
            string longest;  // longest word in a file
            int maxLength;   // length of the longest word
            string[] lines1; // first file data
            string[] lines2; // second file data

            // Task 1
            // Reads files and finds the longest words of each file
            TaskUtils.LongestInFile(punctuation, out longest, CFd1, out maxLength,
                                    out lines1);
            List<string> LongestWords1 = TaskUtils.LongestWords(punctuation,
                                         longest, maxLength, lines1);

            TaskUtils.LongestInFile(punctuation, out longest,  CFd2, out maxLength,
                                    out lines2);
            List<string> LongestWords2 = TaskUtils.LongestWords(punctuation,
                                         longest, maxLength, lines2);

            // Longest words of both files
            List<string> BothLongest = TaskUtils.BothFilesLongest(LongestWords1,
                                                                  LongestWords2);
            TaskUtils.Sort(BothLongest);
            string title2 = "Rikiuoti ilgiausi žodžiai, esantys " +
                            "abejuose failuose";
            if (BothLongest.Count() > 0)
            {
                InOut.PrintLongest(CFd1, CFd2, CFa1, punctuation, BothLongest, 
                                   LongestWords1, lines1,lines2, LongestWords2,
                                   title2);
            }
            
            // Task 2
            // longest words only in the first file
            List<string> OneFileLongest = TaskUtils.OneLongest(LongestWords1,
                                                               LongestWords2);
            TaskUtils.Sort(OneFileLongest);
            title2 = "Rikiuoti ilgiausi žodžiai, esantys tik pirmame faile";
            if (OneFileLongest.Count() > 0)
            {
                InOut.PrintLongest(CFd1, CFd2, CFa1, punctuation, OneFileLongest,
                                   LongestWords1, lines1, lines2, LongestWords2,
                                   title2);
            }
            
        }
    }
}
