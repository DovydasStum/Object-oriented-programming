using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;

namespace WebApplication1
{
    public class InOutUtils : System.Web.UI.Page
    {
        /// <summary>
        /// Prints the header of Table1 (primary data)
        /// </summary>
        /// <param name="Table1">name of table for primary data</param>
        public static void PrintTableHeader(Table Table1)
        {
            TableRow row = new TableRow();
            TableCell linesCount = new TableCell();
            linesCount.Text = "<b>Eilučių kiekis</b>";
            row.Cells.Add(linesCount);

            TableCell rowsCount = new TableCell();
            rowsCount.Text = "<b>Stulpelių kiekis</b>";
            row.Cells.Add(rowsCount);

            TableCell area = new TableCell();
            area.Text = "<b>Urvų schema</b>";
            row.Cells.Add(area);
            Table1.Rows.Add(row);
        }

        /// <summary>
        /// Reads the file and returns values
        /// </summary>
        /// <param name="fileName">name of txt file</param>
        /// <param name="lines">number of lines</param>
        /// <param name="rows">number of rows</param>
        /// <param name="letters">array of letters</param>
        public static void FileRead(string fileName, out int lines, 
                                    out int rows, char[,] letters)
        {
            string[] allLines = File.ReadAllLines(fileName);
            string firstLine = File.ReadAllLines(fileName).First();
            char[] punct = { ' ' };
            string[] parts = firstLine.Split(punct,
                StringSplitOptions.RemoveEmptyEntries);
            lines = Convert.ToInt32(parts[0]);
            rows = Convert.ToInt32(parts[1]);

            for (int i = 1; i <= lines; i++)
            {
                string line = allLines[i];
                for (int j = 0; j < rows; j++)
                {
                    char[] ch = line.ToCharArray();
                    letters[i, j] = ch[j];
                }
            }
        }

        /// <summary>
        /// Prints the primary data
        /// </summary>
        /// <param name="Table1">name of table for primary data</param>
        /// <param name="lines">number of lines</param>
        /// <param name="rows">number of rows</param>
        /// <param name="area">array of letters</param>
        public static void PrintTableData(Table Table1, int lines, 
                                          int rows, char[,] area)
        {
            TableRow row = new TableRow();
            TableCell lines1 = new TableCell();
            lines1.Text = lines.ToString();
            row.Cells.Add(lines1);

            TableCell rows1 = new TableCell();
            rows1.Text = rows.ToString();
            row.Cells.Add(rows1);

            TableCell area1 = new TableCell();
            for (int i = 0; i < lines + 1; i++)
            {
                string temp = "";
                for (int j = 0; j < rows; j++)
                {
                    temp = temp + area[i, j];   
                }
                area1.Text = (area1.Text + "\n" + temp).ToString();
            }
            row.Cells.Add(area1);
            Table1.Rows.Add(row);
        }

        /// <summary>
        /// Writes data to txt file
        /// </summary>
        /// <param name="lines">number of lines</param>
        /// <param name="rows">number of rows</param>
        /// <param name="letters">array of letters</param>
        /// <param name="output">name of output file</param>
        public static void PrintDataToTxt (int lines, int rows, char[,] letters,
                                           string output, int counter, List<int> allAreas)
        {
            string[] allLines = new string[lines + 12];
            allLines[0] = String.Format("Eilučių | stulpelių kiekis");
            allLines[1] = String.Format(new string('-', 28));
            allLines[2] = String.Format("{0, 7} | {1, 16} ", lines, rows);
            allLines[3] = String.Format(new string('-', 28));
            allLines[4] = String.Format("Urvų schema: ");
            for (int i = 0; i < lines + 1; i++)
            {
                string temp = "";
                for (int j = 0; j < rows; j++)
                {
                    temp = temp + letters[i, j];
                }
                allLines[i + 5] = String.Format(temp.ToString());
            }
            allLines[lines + 6] = String.Format(new string('-', 28));
            allLines[lines + 7] = String.Format("Rezultatai: ");
            allLines[lines + 8] = String.Format(new string('-', 28));
            allLines[lines + 9] = String.Format($"Kurmių kiekis: {counter.ToString()}");
            allLines[lines + 10] = String.Format("Urvų dydžiai: ");
            for (int i = 0; i < allAreas.Count(); i++)
            {
                allLines[lines + 11] = String.Format(allAreas[i].ToString());
            }
            File.AppendAllLines(output, allLines, Encoding.UTF8);
        }

        /// <summary>
        /// Prints the all areas
        /// </summary>
        /// <param name="Table2">name of table</param>
        /// <param name="allAreas">array of all areas</param>
        public static void PrintAreas (Table Table2, List<int> allAreas)
        {
            for (int i = 0; i < allAreas.Count(); i++)
            {
                TableRow row = new TableRow();
                TableCell lines1 = new TableCell();
                lines1.Text = allAreas[i].ToString();
                row.Cells.Add(lines1);
                Table2.Rows.Add(row);
            }
        }
    }
}