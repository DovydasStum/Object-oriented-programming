using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.IO;
using System.Text;
using System.Web.UI.WebControls;

namespace L2
{
    /// <summary>
    /// A class for reading and printing data
    /// </summary>
    public static class InOutUtils
    {
        /// <summary>
        /// Reads the file with workers information
        /// </summary>
        /// <param name="FileName">Name of file</param>
        /// <returns>List of workers</returns>
        public static LinkList<Worker> ReadWorkers(string FileName)
        {
            LinkList<Worker> temp = new LinkList<Worker>();
            string[] lines = File.ReadAllLines(FileName);
            foreach (string line in lines)
            {
                string[] parts = line.Split(' ');
                var cultureInfo = new CultureInfo("lt-LT");
                DateTime date = DateTime.Parse(parts[0], cultureInfo);
                string surname = parts[1];
                string name = parts[2];
                string code = parts[3];
                int count = Convert.ToInt32(parts[4]);
                Worker worker = new Worker(date, surname, name, code, count);

                temp.SetLifo(worker);
            }
            return temp;
        }

        /// <summary>
        /// Reads the file with parts information
        /// </summary>
        /// <param name="FileName">Name of file</param>
        /// <returns>List of parts</returns>
        public static LinkList<Part> ReadParts(string FileName)
        {
            LinkList<Part> temp = new LinkList<Part>();
            string[] lines = File.ReadAllLines(FileName);
            foreach (string line in lines)
            {
                string[] parts = line.Split(' ');
                string code = parts[0];
                string name = parts[1];
                double price = Convert.ToDouble(parts[2]);
                Part part = new Part(code, name, price);

                temp.SetLifo(part);
            }
            return temp;
        }

        /// <summary>
        /// Prints the workers data to the file
        /// </summary>
        /// <param name="FileName">Name of output file</param>
        /// <param name="workers">Workers list</param>
        public static void PrintDataTxt<type>(string FileName, IEnumerable<type> workers,
                                              string header, string rowsNames, int dashes)
            where type : IComparable<type>, IEquatable<type>
        {
            string line = new string('-', dashes);
            using (var fr = File.AppendText(FileName))
            {
                fr.WriteLine(header);
                fr.WriteLine(line);
                fr.WriteLine(rowsNames);
                fr.WriteLine(line);
                foreach (type worker in workers)
                {
                    fr.WriteLine(worker.ToString());
                }
                fr.WriteLine(line);
                fr.WriteLine();
            }
        }

        /// <summary>
        /// Prints primary workers data 
        /// </summary>
        /// <param name="workers">List of workers</param>
        /// <param name="Table1">Table to print</param>
        public static void PrintWorkersData(LinkList<Worker> workers, Table Table1)
        {
            foreach (Worker worker in workers)
            {
                Table1.Rows.Add(TaskUtils.CreateRowWorkers(Table1,
                                worker.Date.ToShortDateString(),
                                worker.Surname, worker.Name, worker.Code,
                                worker.PartsCount.ToString()));
            }
        }
       
        /// <summary>
        /// Prints primary parts data 
        /// </summary>
        /// <param name="parts">List of parts</param>
        /// <param name="Table2">Table to print</param>
        public static void PrintPartsData(LinkList<Part> parts, Table Table2)
        {
            foreach (Part part in parts)
            {
                Table2.Rows.Add(TaskUtils.CreateRowParts(Table2, part.Code,
                                part.Name, part.Price.ToString()));
            }
        }

        /// <summary>
        /// Prints all workers who earned the most
        /// </summary>
        /// <param name="most">List of workers</param>
        /// <param name="Table3">Table to print</param>
        public static void PrintMostEarned(LinkList<Worker> most, Table Table3)
        {
            foreach (Worker worker in most)
            {
                Table3.Rows.Add(TaskUtils.CreateRowWorkers(Table3, worker.Surname,
                                worker.Name, worker.Days.ToString(),
                                worker.AllPartsCount.ToString(),
                                worker.EarnedSum.ToString()));
            }
        }

        /// <summary>
        /// Prints table of workers who made only one type parts
        /// </summary>
        /// <param name="workers">List of workers</param>
        /// <param name="Table4">Table to print</param>
        public static void PrintOneType(LinkList<Worker> workers, Table Table4)
        {
            foreach (Worker worker in workers)
            {
                Table4.Rows.Add(TaskUtils.CreateRowWorkers(Table4,
                                worker.Surname, worker.Name,
                                worker.AllPartsCount.ToString(),
                                worker.EarnedSum.ToString()));
            }
        }

        /// <summary>
        /// Prints table of workers selected by S and K values
        /// </summary>
        /// <param name="newList">List of workers</param>
        /// <param name="Table5">Table to print</param>
        public static void PrintSelected(LinkList<Worker> newList, Table Table5)
        {
            foreach (Worker worker in newList)
            {
                Table5.Rows.Add(TaskUtils.CreateRowWorkers(Table5,
                                    worker.Surname, worker.Name,
                                    worker.AllPartsCount.ToString(),
                                    worker.EarnedSum.ToString()));
            }
        }
    }
}