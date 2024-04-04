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
        private static double MostEarned(LinkList<Worker> Workers)
        {
            double maxSum = 0.00;
            
            foreach (Worker worker in Workers)
            {
                if (worker.EarnedSum > maxSum)
                {
                    maxSum = worker.EarnedSum;
                }
            }
            return maxSum;
        }

        /// <summary>
        /// Finds all workers who earned the most
        /// </summary>
        /// <param name="Workers">List of workers</param>
        /// <returns>New list</returns>
        public static LinkList<Worker> AllMostEarned(LinkList<Worker> Workers)
        {
            LinkList<Worker> TempL = new LinkList<Worker>();
            double maxSum = MostEarned(Workers);
            
            foreach (Worker worker in Workers)
            {
                if (worker.EarnedSum == maxSum)
                {
                    TempL.SetLifo(worker);
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
        public static LinkList<Worker> FormattedList(LinkList<Worker> List,
                                                 LinkList<Part> Parts)
        {
            LinkList<Worker> NewList = new LinkList<Worker>();
            foreach (Worker worker in List)
            {
                if (!NewList.Contains(worker))
                {
                    FormatNotContains(worker, Parts);
                    NewList.SetLifo(worker);
                }

                else // if the list already contains the worker,
                     // change it's values
                {
                    foreach (Worker workerNew in NewList)
                    {
                        if (workerNew.CompareTo(worker) == 0)
                        {                           
                            FormatContains(workerNew, Parts, worker);
                        }
                    }
                }
            }
            return NewList;
        }

        /// <summary>
        /// Counts the values of worker
        /// </summary>
        /// <param name="worker">Worker</param>
        /// <param name="PartsList">List of parts</param>
        private static void FormatNotContains(Worker worker,
                                              LinkList<Part> PartsList)
        {
            worker.AllPartsCount = worker.PartsCount;
            foreach (Part part in PartsList)
            {
                if (worker.Code == part.Code)
                {
                    worker.EarnedSum = worker.PartsCount * part.Price;
                }
            }
        }

        /// <summary>
        /// Counts the values of worker
        /// </summary>
        /// <param name="newListWorker">Worker of the new formatted list</param>
        /// <param name="Parts">List of parts</param>
        /// <param name="worker">Worker of the primary list</param>
        private static void FormatContains(Worker newListWorker,
                                           LinkList<Part> Parts, Worker worker)
        {
            foreach (Part part in Parts)
            {
                if (worker.Code == part.Code)
                {
                    newListWorker.EarnedSum +=
                    worker.PartsCount * part.Price;
                }
            }

            if (newListWorker.Date != worker.Date)
            {
                newListWorker.Days++;
            }
            newListWorker.AllPartsCount += worker.PartsCount;
        }


        /// <summary>
        /// Counts the quantity of different parts
        /// </summary>
        /// <param name="Workers">List of workers</param>
        /// <param name="worker">Worker</param>
        private static int DifferentPartsCount(LinkList<Worker> Workers,
                                               Worker worker)
        {
            int count = 1;          
            foreach (Worker worker1 in Workers)
            {
                if (worker1.CompareTo(worker) == 0 &&
                    worker1.Code != worker.Code)
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
        public static LinkList<Worker> DifferentPartsList(LinkList<Worker> Workers,
                                                          LinkList<Worker> Sorted)
        {
            LinkList<Worker> TempL = new LinkList<Worker>();           
            foreach (Worker worker1 in Sorted)
            {
                if (DifferentPartsCount(Workers, worker1) == 1)
                {
                    TempL.SetLifo(worker1);
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
        public static LinkList<Worker> NewListBy_S_K(LinkList<Worker> Workers,
                                                     LinkList<Part> Parts,
                                                     TextBox t1, TextBox t2)
        {
            LinkList<Worker> TempL = new LinkList<Worker>();
            int S = Convert.ToInt32(t1.Text);
            double K = Convert.ToDouble(t2.Text);
            
            foreach (Worker worker in Workers)
            {
                foreach (Part part in Parts)
                {
                    if (worker.AllPartsCount > S && part.Price < K &&
                        worker.Code == part.Code)
                    {
                        TempL.SetLifo(worker);
                    }
                }
            }
            return TempL;
        }
    }

}