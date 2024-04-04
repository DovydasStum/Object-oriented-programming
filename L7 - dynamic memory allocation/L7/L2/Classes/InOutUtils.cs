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
        public static WorkersList ReadWorkers(string FileName)
        {
            WorkersList temp = new WorkersList();
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

                temp.SetFifo(worker);
            }
            return temp;
        }

        /// <summary>
        /// Reads the file with parts information
        /// </summary>
        /// <param name="FileName">Name of file</param>
        /// <returns>List of parts</returns>
        public static PartsList ReadParts(string FileName)
        {
            PartsList temp = new PartsList();
            string[] lines = File.ReadAllLines(FileName);
            foreach (string line in lines)
            {
                string[] parts = line.Split(' ');
                string code = parts[0];
                string name = parts[1];
                double price = Convert.ToDouble(parts[2]);
                Part part = new Part(code, name, price);

                temp.SetFifo(part);
            }
            return temp;
        }

        /// <summary>
        /// Prints the workers data to the file
        /// </summary>
        /// <param name="FileName">Name of output file</param>
        /// <param name="workers">Workers list</param>
        public static void PrintWorkersDataTxt(string FileName,
     WorkersList workers)
        {
            string line = new string('-', 87);
            using (var fr = File.AppendText(FileName))
            {
                fr.WriteLine("Darbuotojai:");
                fr.WriteLine(line);
                fr.WriteLine(String.Format("| {0, -15} | {1, -20} | {2, -20} |" +
                             " {3, -8} | {4, -8} |", "Data", "Pavardė", "Vardas",
                             "Kodas", "Kiekis"));
                fr.WriteLine(line);
                for (workers.Begin(); workers.Contains(); workers.Next())
                {
                    fr.WriteLine(workers.Data());
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
        public static void PrintWorkersData(WorkersList workers, Table Table1)
        {
            for (workers.Begin(); workers.Contains(); workers.Next())
            {
                Worker worker = workers.Data();
                Table1.Rows.Add(TaskUtils.CreateRowWorkers(Table1,
                                worker.Date.ToShortDateString(),
                                worker.Surname, worker.Name, worker.Code,
                                worker.PartsCount.ToString()));
            }
        }

        /// <summary>
        /// Prints parts data to the file
        /// </summary>
        /// <param name="FileName">Name of output file</param>
        /// <param name="parts">List of parts</param>
        public static void PrintPartsDataTxt(string FileName, PartsList parts)
        {
            string line = new string('-', 47);
            using (var fr = File.AppendText(FileName))
            {
                fr.WriteLine("Detalės:");
                fr.WriteLine(line);
                fr.WriteLine(String.Format("| {0, -8} | {1, -20} | {2, -9} |",
                             "Kodas", "Pavadinimas", "Įkainis"));
                fr.WriteLine(line);
                for (parts.Begin(); parts.Contains(); parts.Next())
                {
                    fr.WriteLine(parts.Data());
                }
                fr.WriteLine(line);
                fr.WriteLine();
            }
        }

        /// <summary>
        /// Prints primary parts data 
        /// </summary>
        /// <param name="parts">List of parts</param>
        /// <param name="Table2">Table to print</param>
        public static void PrintPartsData(PartsList parts, Table Table2)
        {
            for (parts.Begin(); parts.Contains(); parts.Next())
            {
                Part part = parts.Data();
                Table2.Rows.Add(TaskUtils.CreateRowParts(Table2, part.Code,
                                part.Name, part.Price.ToString()));
            }
        }

        /// <summary>
        /// Writes most earned workers to file
        /// </summary>
        /// <param name="FileName">Name of output file</param>
        /// <param name="workers">List of workers</param>
        public static void PrintMostEarnedTxt(string FileName,
                                              WorkersList workers)
        {
            string line = new string('-', 87);
            using (var fr = File.AppendText(FileName))
            {
                fr.WriteLine("Daugiausiai uždirbę darbuotojai:");
                fr.WriteLine(line);
                fr.WriteLine(String.Format("| {0, -15} | {1, -20} | {2, -20} |" +
                             " {3, -8} | {4, -8} |", "Data", "Pavardė", "Vardas",
                             "Kodas", "Kiekis"));
                fr.WriteLine(line);
                for (workers.Begin(); workers.Contains(); workers.Next())
                {
                    fr.WriteLine(workers.Data());
                }
                fr.WriteLine(line);
                fr.WriteLine();
            }
        }

        /// <summary>
        /// Prints all workers who earned the most
        /// </summary>
        /// <param name="most">List of workers</param>
        /// <param name="Table3">Table to print</param>
        public static void PrintMostEarned(WorkersList most, Table Table3)
        {
            for (most.Begin(); most.Contains(); most.Next())
            {
                Worker worker = most.Data();
                Table3.Rows.Add(TaskUtils.CreateRowWorkers(Table3, worker.Surname,
                                worker.Name, worker.Days.ToString(),
                                worker.AllPartsCount.ToString(),
                                worker.EarnedSum.ToString()));
            }
        }

        /// <summary>
        /// Prints workers who made only one type parts to file
        /// </summary>
        /// <param name="FileName">Output file</param>
        /// <param name="workers">Workers list</param>
        public static void PrintOneTypeTxt(string FileName, WorkersList workers,
                                           string header)
        {
            string line = new string('-', 87);
            using (var fr = File.AppendText(FileName))
            {
                fr.WriteLine(header);
                fr.WriteLine(line);
                fr.WriteLine(String.Format("| {0, -15} | {1, -20} | {2, -20} |" +
                             " {3, -8} | {4, -8} |", "Data", "Pavardė", "Vardas",
                             "Kodas", "Kiekis"));
                fr.WriteLine(line);
                for (workers.Begin(); workers.Contains(); workers.Next())
                {
                    fr.WriteLine(workers.Data());
                }
                fr.WriteLine(line);
                fr.WriteLine();
            }
        }

        /// <summary>
        /// Prints table of workers who made only one type parts
        /// </summary>
        /// <param name="workers">List of workers</param>
        /// <param name="Table4">Table to print</param>
        public static void PrintOneType(WorkersList workers, Table Table4)
        {
            for (workers.Begin(); workers.Contains(); workers.Next())
            {
                Worker worker = workers.Data();
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
        public static void PrintSelected(WorkersList newList, Table Table5)
        {
            for (newList.Begin(); newList.Contains(); newList.Next())
            {
                Worker worker = newList.Data();
                Table5.Rows.Add(TaskUtils.CreateRowWorkers(Table5,
                                    worker.Surname, worker.Name,
                                    worker.AllPartsCount.ToString(),
                                    worker.EarnedSum.ToString()));
            }
        }


    }
}