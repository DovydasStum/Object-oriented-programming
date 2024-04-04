using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class TaskUtils : System.Web.UI.Page
    {
        /// <summary>
        /// Counts the animals and their area
        /// </summary>
        /// <param name="lines">number of lines</param>
        /// <param name="rows">number of rows</param>
        /// <param name="letters">array of letters</param>
        /// <param name="allAreas">array of areas</param>
        /// <param name="counter">number of animals</param>
        public static void CountAndArea(int lines, int rows, char[,] letters,
                                         out List<int> allAreas, out int counter)
        {
            counter = 0; // counts animals       
            allAreas = new List<int>();

            for (int i = 0; i <= lines; i++)
            {
                for (int j = 0; j <= rows; j++)
                {
                    int uCounter = 0; // counts the 'u' letters
                    if (letters[i, j] == 'u')
                    {
                        uCounter = LetterU(uCounter, i, j, letters, lines, rows);
                        allAreas.Add(uCounter * 5); // counts the area 
                        counter++;
                    }                      
                }                
            }
        }

        /// <summary>
        /// Counts the 'u' letters of one animal
        /// </summary>
        /// <param name="sum">quantity of 'u' letters</param>
        /// <param name="line">line index</param>
        /// <param name="row">row index</param>
        /// <param name="letters">all letters scheme</param>
        /// <param name="allLines">all lines quantity</param>
        /// <param name="allRows">all rows quantity</param>
        /// <returns>'u' letters quantity</returns>
        public static int LetterU(int sum, int line, int row, char[,] letters,
                                   int allLines, int allRows)
        {
            int uCounter = sum;
            // search for the 'u' in the right
            if (letters[line, row++] == 'u' && row++ < allRows)
            {
                uCounter++;
                LetterU(uCounter, line, row++, letters, allLines, allRows);
            }
            // search for the 'u' lower
            if (letters[line++, row] == 'u' && line++ < allLines)
            {
                uCounter++;
                LetterU(uCounter, line++, row, letters, allLines, allRows);
            }
            // search for the 'u' in the left
            if (letters[line, row--] == 'u' && row > 0)
            {
                uCounter++;
                LetterU(uCounter, line, row--, letters, allLines, allRows);
            }
            // search for the 'u' in the upper
            if (letters[line--, row] == 'u' && line > 0)
            {
                uCounter++;
                LetterU(uCounter, line--, row, letters, allLines, allRows);
            }
            return uCounter;
        }


        /// <summary>
        /// Sorts the areas in a decreasing order
        /// </summary>
        /// <param name="allAreas">array of all areas</param>
        public static void Sort(List<int> allAreas)
        {
            int temp = 0;
            int minInd;
            for (int i = 0; i < allAreas.Count() - 1; i++)
            {
                minInd = i;
                for (int j = i + 1; j < allAreas.Count(); j++)
                {
                    if (allAreas[j] > allAreas[minInd])
                    {
                        minInd = j;
                    }
                    temp = allAreas[i];
                    allAreas[i] = allAreas[minInd];
                    allAreas[minInd] = temp;
                }
            }
        }

    }
}
