using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace L4_Individuali
{
    class InOut
    {
        /// <summary>
        /// Prints list of longest words in both files
        /// </summary>
        /// <param name="input1">first data file</param>
        /// <param name="input2">second data file</param>
        /// <param name="output">output file</param>
        /// <param name="punct">punctuation symbols</param>
        /// <param name="ListBoth">list of longest words</param>
        /// <param name="List1">first file longest words</param>
        /// <param name="List2">seconds file longest words</param>
        /// <param name="title">results title</param>
        public static void PrintLongest (string input1, string input2,
                                         string output, char[] punct,
                                         List<string> ListBoth,
                                         List<string> List1, string[] lines1,
                                         string[] lines2, List<string> List2,
                                         string title)
        {
            string dashes = new string('-', 50);
            using (var writer = File.AppendText(output))
            {
                writer.WriteLine(title);
                writer.WriteLine("*P1 – pasikartojimų sk. pirmame faile," +
                                 " P2 – antrame.");
                writer.WriteLine(dashes);
                writer.WriteLine("| {0,-3} | {1,-16} | {2,-5} | {3,-5} |" +
                                 " {4,-5} |", "Nr.", "Žodis", "Ilgis",
                                 "P1", "P2");
                writer.WriteLine(dashes);

                int length = ListBoth.Count;
                if (ListBoth.Count > 10)
                {
                    length = 10;
                }

                for (int i = 0; i < length; i++)
                {
                    int rep1 = TaskUtils.Repetition(punct, ListBoth[i], lines1);
                    int rep2 = TaskUtils.Repetition(punct, ListBoth[i], lines2);
                    writer.WriteLine("| {0,3} | {1,-16} | {2,5} | {3,5} | {4,5} |",
                                i + 1, ListBoth[i], ListBoth[i].Length, rep1, rep2);
                }
                writer.WriteLine(dashes);
            }       
        }
    }
}
