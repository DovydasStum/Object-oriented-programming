using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace L5
{
    /// <summary>
    /// A class for primary data reading and results printing
    /// </summary>
    public class InOutUtils
    {
        /// <summary>
        /// Reads all subscribers data
        /// </summary>
        /// <param name = "fileName" > Name of all input files</param>
        /// <returns>Formatted list</returns>
        public static List<Subscriber> ReadSubscribers(string fileName)
        {
            List<Subscriber> AllSubscribers = new List<Subscriber>();
            foreach (string file in Directory.GetFiles(fileName, "*.txt"))
            {
                string[] Lines = File.ReadAllLines(file);
                DateTime date = new DateTime();
                try
                {
                    date = DateTime.Parse(Lines[0]);
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Method {0}, Message " +
                                        "{1}, Source {2}", ex.TargetSite,
                                        ex.Message, ex.Source));
                }
                string person = Lines[1];
                string address = Lines[2];
                int start = new int();
                int length = new int();
                try
                {
                    start = int.Parse(Lines[3]);
                    length = int.Parse(Lines[4]);
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Method {0}, Message " +
                                        "{1}, Source {2}", ex.TargetSite,
                                        ex.Message, ex.Source));
                }
                string code = Lines[5];
                int count = new int();
                try
                {
                    count = int.Parse(Lines[6]);
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Method {0}, Message " +
                                        "{1}, Source {2}", ex.TargetSite,
                                        ex.Message, ex.Source));
                }
                Subscriber sub = new Subscriber(date, person, address, start,
                                                length, code, count);
                AllSubscribers.Add(sub);
            }
            return AllSubscribers;
        }

        /// <summary>
        /// Reads the file with data about publications
        /// </summary>
        /// <param name="fileName">Name of file</param>
        /// <returns>Formatted list of publications</returns>
        public static List<Publication> ReadPublications(string fileName)
        {
            List<Publication> Publications = new List<Publication>();
            string[] Lines = File.ReadAllLines(fileName);
            foreach (string line in Lines)
            {
                string[] values = line.Split(';');
                string code = values[0];
                string name = values[1];
                string pName = values[2];
                double price = new double();
                try
                {
                    price = double.Parse(values[3]);
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Method {0}, Message " +
                                        "{1}, Source {2}", ex.TargetSite,
                                        ex.Message, ex.Source));
                }
                Publication pub = new Publication(code, name, pName, price);
                Publications.Add(pub);
            }
            return Publications;
        }

        /// <summary>
        /// Prints subscribers to txt file
        /// </summary>
        /// <param name="Sub">All subscribers</param>
        /// <param name="fileName">Output file name</param>
        public static void PrintSubscribersTxt(List<Subscriber> Sub,
                                                string fileName)
        {
            string dashes = new string('-', 166);
            using (var fr = File.AppendText(fileName))
            {
                fr.WriteLine(dashes);
                fr.WriteLine(string.Format("| {0,-20} | {1,-25} | {2,-20} |" +
                             " {3,-20} | {4,-25} | {5,-15} | {6,-20} |", "Data",
                             "Asmuo", "Adresas", "Prenumeratos pradžia",
                             "Prenumeratos trukmė", "Leidinio kodas", "Leidinių kiekis"));
                fr.WriteLine(dashes);
                for (int i = 0; i < Sub.Count(); i++)
                {
                    fr.WriteLine(Sub[i].ToString());
                }
                fr.WriteLine(dashes);
                fr.WriteLine();
            }
        }

        /// <summary>
        /// Prints publications data to txt file
        /// </summary>
        /// <param name="Pub">List of publications</param>
        /// <param name="fileName">Output file</param>
        public static void PrintPublicationsTxt(List<Publication> Pub,
                                                string fileName)
        {
            string dashes = new string('-', 93);
            using (var fr = File.AppendText(fileName))
            {
                fr.WriteLine(dashes);
                fr.WriteLine(string.Format("| {0,-20} | {1,-20} | {2,-20} | {3,-20} |",
                             "Kodas", "Pavadinimas", "Leidėjas", "Kaina"));
                fr.WriteLine(dashes);
                for (int i = 0; i < Pub.Count(); i++)
                {
                    fr.WriteLine(Pub[i].ToString());
                }
                fr.WriteLine(dashes);
                fr.WriteLine();
            }
        }

        /// <summary>
        /// Prints subcribers data to the web
        /// </summary>
        /// <param name="table">Table to print</param>
        /// <param name="List">List of subscribers</param>
        public static void PrintSubscribersWeb (Table table, List<Subscriber> List)
        {

            table.Rows.Add(TaskUtils.FormatRowCells(table, "Įvedimo data", "Asmuo",
                "Adresas", "Prenumeratos pradžia", "Prenumeratos ilgis",
                "Leidinio kodas", "Leidinių kiekis"));
            for (int i = 0; i < List.Count(); i++)
            {
                Subscriber sub = List[i];
                table.Rows.Add(TaskUtils.FormatRowCells(table, sub.Date.ToShortDateString(),
                    sub.Person, sub.Address, sub.StartMonth.ToString(), 
                    sub.SubscriptionLength.ToString(), sub.Code, 
                    sub.PublicationsCount.ToString()));
            }
        }

        /// <summary>
        /// Prints publications data to the web
        /// </summary>
        /// <param name="table">Table to print</param>
        /// <param name="List">List of publications</param>
        public static void PrintPublicationsWeb(Table table, List<Publication> List)
        {
            table.Rows.Add(TaskUtils.FormatRowCells(table, "Leidinio kodas",
                "Leidinio pavadinimas", "Leidėjo pavadinimas", "Mėnesio kaina"));
            for (int i = 0; i < List.Count(); i++)
            {
                Publication pub = List[i];
                table.Rows.Add(TaskUtils.FormatRowCells(table, pub.Code,
                    pub.Name, pub.PublisherName, pub.Price.ToString()));
            }
        }

        /// <summary>
        /// Prints publishers data
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <param name="pub">Publications list</param>
        public static void PrintPublishersTxt (string fileName, List<Publisher> Labels,
                                               List<Publication> AllPub,
                                               List<Subscriber> AllSub, int month)
        {
            string dashes = new string('-', 38);
            using (var fr = File.AppendText(fileName))
            {               
                for (int i = 0; i < Labels.Count(); i++)
                {
                    fr.WriteLine(dashes);
                    fr.WriteLine(string.Format("| {0,-20} | {1,-11} |", "Leidėjas",
                                 "Bendra suma"));
                    fr.WriteLine(dashes);
                    Publisher label = Labels[i];
                    fr.WriteLine(label.ToString());
                    fr.WriteLine(dashes);
                    fr.WriteLine(string.Format("| {0,-20} | {1,-11} |", 
                                 "Leidiniai", "Gauta suma"));
                    fr.WriteLine(dashes);
                    for (int j = 0; j < label.AllPublicationsCodes.Count(); j++)
                    {
                        double price = TaskUtils.PriceOfOnePublication(AllPub, AllSub, 
                                    label.AllPublicationsCodes[j], label.Name, month);
                        fr.WriteLine(string.Format("| {0,-20} | {1,11} |", 
                                     label.AllPublicationsCodes[i], price));
                    }
                    fr.WriteLine(dashes);
                    fr.WriteLine();
                }
            }
        }

        /// <summary>
        /// Prints labels with their data to the web
        /// </summary>
        /// <param name="Labels">List  of labels</param>
        /// <param name="table">Table to print</param>
        public static void PrintPublishersWeb (List<Publisher> Labels, 
                                               List<Publication> AllPub,
                                               List<Subscriber> AllSub,
                                               Table table, int month)
        {
            for (int i = 0; i < Labels.Count(); i++)
            {
                table.Rows.Add(TaskUtils.FormatRowCells(table, "Leidėjas", "Bendra suma"));
                Publisher label = Labels[i];
                table.Rows.Add(TaskUtils.FormatRowCells(table, label.Name,
                               label.TotalPrice.ToString()));
                table.Rows.Add(TaskUtils.FormatRowCells(table, "Leidiniai", "Gauta suma"));
                for (int j = 0; j < label.AllPublicationsCodes.Count(); j++)
                {
                    double price = TaskUtils.PriceOfOnePublication(AllPub, AllSub, 
                                   label.AllPublicationsCodes[j], label.Name, month);
                    table.Rows.Add(TaskUtils.FormatRowCells(table, 
                                   label.AllPublicationsCodes[j], price.ToString()));
                }
            }
        }

    }
}