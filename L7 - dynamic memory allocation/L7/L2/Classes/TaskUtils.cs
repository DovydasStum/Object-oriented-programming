using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace L2
{
    /// <summary>
    /// A class for calculations
    /// </summary>
    public static class TaskUtils
    {
        /// <summary>
        /// Creates a row for the workers table
        /// </summary>
        /// <param name="Table1">Table of workers</param>
        /// <param name="cell1">First cell</param>
        /// <param name="cell2">Second cell</param>
        /// <param name="cell3">Third cell</param>
        /// <param name="cell4">Fourth cell</param>
        /// <param name="cell5">Fifth cell</param>
        /// <returns>Row</returns>
        public static TableRow CreateRowWorkers(Table Table1, string cell1,
                      string cell2, string cell3, string cell4, string cell5)
        {
            TableRow row = new TableRow();
            TableCell cellOne = new TableCell();
            cellOne.Text = cell1;
            row.Cells.Add(cellOne);

            TableCell cellTwo = new TableCell();
            cellTwo.Text = cell2;
            row.Cells.Add(cellTwo);

            TableCell cellThree = new TableCell();
            cellThree.Text = cell3;
            row.Cells.Add(cellThree);

            TableCell cellFour = new TableCell();
            cellFour.Text = cell4;
            row.Cells.Add(cellFour);

            TableCell cellFive = new TableCell();
            cellFive.Text = cell5;
            row.Cells.Add(cellFive);

            return row;
        }

        /// <summary>
        /// Creates a row for the workers table
        /// </summary>
        /// <param name="Table1">Table of workers</param>
        /// <param name="cell1">First cell</param>
        /// <param name="cell2">Second cell</param>
        /// <param name="cell3">Third cell</param>
        /// <param name="cell4">Fourth cell</param>
        /// <returns>Row</returns>
        public static TableRow CreateRowWorkers(Table Table1, string cell1,
                                  string cell2, string cell3, string cell4)
        {
            TableRow row = new TableRow();
            TableCell cellOne = new TableCell();
            cellOne.Text = cell1;
            row.Cells.Add(cellOne);

            TableCell cellTwo = new TableCell();
            cellTwo.Text = cell2;
            row.Cells.Add(cellTwo);

            TableCell cellThree = new TableCell();
            cellThree.Text = cell3;
            row.Cells.Add(cellThree);

            TableCell cellFour = new TableCell();
            cellFour.Text = cell4;
            row.Cells.Add(cellFour);

            return row;
        }

        /// <summary>
        /// Creates a row for parts table
        /// </summary>
        /// <param name="Table2">Table of parts</param>
        /// <param name="cell1">First cell</param>
        /// <param name="cell2">Second cell</param>
        /// <param name="cell3">Third cell</param>
        /// <returns>Row</returns>
        public static TableRow CreateRowParts(Table Table2, string cell1,
                                              string cell2, string cell3)
        {
            TableRow row = new TableRow();
            TableCell cellOne = new TableCell();
            cellOne.Text = cell1;
            row.Cells.Add(cellOne);

            TableCell cellTwo = new TableCell();
            cellTwo.Text = cell2;
            row.Cells.Add(cellTwo);

            TableCell cellThree = new TableCell();
            cellThree.Text = cell3;
            row.Cells.Add(cellThree);

            return row;
        }

        /// <summary>
        /// Finds the highest sum
        /// </summary>
        /// <param name="Workers">Workers list</param>
        /// <returns>Highest sum</returns>
        private static double MostEarned(WorkersList Workers)
        {
            double maxSum = 0.00;
            for (Workers.Begin(); Workers.Contains(); Workers.Next())
            {
                if (Workers.Data().EarnedSum > maxSum)
                {
                    maxSum = Workers.Data().EarnedSum;
                }
            }
            return maxSum;
        }

        /// <summary>
        /// Finds all workers who earned the most
        /// </summary>
        /// <param name="Workers">List of workers</param>
        /// <returns>New list</returns>
        public static WorkersList AllMostEarned(WorkersList Workers)
        {
            WorkersList TempL = new WorkersList();
            double maxSum = MostEarned(Workers);
            for (Workers.Begin(); Workers.Contains(); Workers.Next())
            {
                if (Workers.Data().EarnedSum == maxSum)
                {
                    TempL.SetFifo(Workers.Data());
                }
            }
            return TempL;
        }

        /// <summary>
        /// Makes a list without repetition and counts workers values
        /// </summary>
        /// <param name="List">List of workers</param>
        /// <param name="Parts">List of parts</param>
        /// <returns>Workers list without repetition</returns>
        public static WorkersList FormattedList(WorkersList List,
                                                PartsList Parts)
        {
            WorkersList NewList = new WorkersList();
            for (List.Begin(); List.Contains(); List.Next())
            {
                if (!NewList.Contains(List.Data()))
                {
                    List.Data().AllPartsCount = List.Data().PartsCount;
                    for (Parts.Begin(); Parts.Contains(); Parts.Next())
                    {
                        if (List.Data().Code == Parts.Data().Code)
                        {
                            List.Data().EarnedSum = List.Data().PartsCount *
                                                    Parts.Data().Price;
                        }
                    }
                    NewList.SetFifo(List.Data());
                }

                else // if the list already contains the worker,
                     // change it's values
                {
                    for (NewList.Begin(); NewList.Contains(); NewList.Next())
                    {
                        if (NewList.Data().CompareTo(List.Data()) == 0)
                        {
                            for (Parts.Begin(); Parts.Contains(); Parts.Next())
                            {
                                if (List.Data().Code == Parts.Data().Code)
                                {
                                    NewList.Data().EarnedSum +=
                                    List.Data().PartsCount * Parts.Data().Price;
                                }
                            }
                            if (NewList.Data().Date != List.Data().Date)
                            {
                                NewList.Data().Days++;
                            }
                            NewList.Data().AllPartsCount +=
                                List.Data().PartsCount;
                        }
                    }
                }
            }
            return NewList;
        }

        /// <summary>
        /// Counts the quantity of different parts
        /// </summary>
        /// <param name="Workers">List of workers</param>
        /// <param name="worker">Worker</param>
        private static int DifferentPartsCount(WorkersList Workers,
                                               Worker worker)
        {
            int count = 1;
            for (Workers.Begin(); Workers.Contains(); Workers.Next())
            {
                if (Workers.Data().CompareTo(worker) == 0 &&
                    Workers.Data().Code != worker.Code)
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Makes a list of workers who made only one part type
        /// </summary>
        /// <param name="Workers">Primary workers list</param>
        /// <param name="Sorted">Formated workers list </param>
        /// <returns>New list</returns>
        public static WorkersList DifferentPartsList(WorkersList Workers,
                                                     WorkersList Sorted)
        {
            WorkersList TempL = new WorkersList();
            for (Sorted.Begin(); Sorted.Contains(); Sorted.Next())
            {
                if (DifferentPartsCount(Workers, Sorted.Data()) == 1)
                {
                    TempL.SetFifo(Sorted.Data());
                }
            }
            return TempL;
        }

        /// <summary>
        /// Creates a list of workers by requirements
        /// </summary>
        /// <param name="Workers">list of workers</param>
        /// <param name="Parts">list of parts</param>
        /// <param name="t1">textbox for S value</param>
        /// <param name="t2">textbox for K value</param>
        /// <returns>new list</returns>
        public static WorkersList NewListBy_S_K(WorkersList Workers,
                                                PartsList Parts,
                                                TextBox t1, TextBox t2)
        {
            WorkersList TempL = new WorkersList();
            int S = Convert.ToInt32(t1.Text);
            double K = Convert.ToDouble(t2.Text);

            for (Workers.Begin(); Workers.Contains(); Workers.Next())
            {
                for (Parts.Begin(); Parts.Contains(); Parts.Next())
                {
                    if (Workers.Data().AllPartsCount > S &&
                        Parts.Data().Price < K
                        && Workers.Data().Code == Parts.Data().Code)
                    {
                        TempL.SetFifo(Workers.Data());
                    }
                }
            }
            return TempL;
        }
    }

}