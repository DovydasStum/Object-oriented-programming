using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace L5
{
    /// <summary>
    /// A class for calculations
    /// </summary>
    public class TaskUtils
    {
        /// <summary>
        /// Formats row with separate cells
        /// </summary>
        /// <param name="table">Table</param>
        /// <param name="cell1">First cell</param>
        /// <param name="cell2">Second cell</param>
        /// <param name="cell3">Third cell</param>
        /// <returns>formatted row with cells</returns>
        public static TableRow FormatRowCells(Table table, string cell1,
            string cell2, string cell3, string cell4, string cell5,
            string cell6, string cell7)
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

            TableCell cellSix = new TableCell();
            cellSix.Text = cell6;
            row.Cells.Add(cellSix);

            TableCell cellSeven = new TableCell();
            cellSeven.Text = cell7;
            row.Cells.Add(cellSeven);

            return row;
        }

        /// <summary>
        /// Formats row with separate cells
        /// </summary>
        /// <param name="table">Table</param>
        /// <param name="cell1">First cell</param>
        /// <param name="cell2">Second cell</param>
        /// <param name="cell3">Third cell</param>
        /// <returns>formatted row with cells</returns>
        public static TableRow FormatRowCells(Table table, string cell1,
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
        /// Formats row with separate cells
        /// </summary>
        /// <param name="table">Table</param>
        /// <param name="cell1">First cell</param>
        /// <param name="cell2">Second cell</param>
        /// <returns>formatted row with cells</returns>
        public static TableRow FormatRowCells(Table table, string cell1,
            string cell2)
        {
            TableRow row = new TableRow();

            TableCell cellOne = new TableCell();
            cellOne.Text = cell1;
            row.Cells.Add(cellOne);

            TableCell cellTwo = new TableCell();
            cellTwo.Text = cell2;
            row.Cells.Add(cellTwo);

            return row;
        }

        /// <summary>
        /// Makes a list of labels
        /// </summary>
        /// <param name="Pub">List of publications</param>
        /// <returns>Formatted list</returns>
        private static List<string> Labels (List<Publication> Pub)
        {
            List<string> Labels = new List<string>();
            List<string> AllLabels = (from pub in Pub
                         orderby pub.PublisherName
                         select pub.PublisherName).ToList<string>();
            foreach (string label in AllLabels)
            {
                if (!Labels.Contains(label))
                {
                    Labels.Add(label);
                }
            }
            return Labels;
        }

        /// <summary>
        /// Counts data about labels
        /// </summary>
        /// <param name="table">Table to print</param>
        /// <param name="fileName">Output file</param>
        /// <param name="Pub">List of publications</param>
        /// <param name="Sub">List of subscribers</param>
        /// <param name="monthToCount">Month to count incomes</param>
        public static void FormatLabelsData (Table table, string fileName,
                                            List<Publication> Pub,
                                            List<Subscriber> Sub,
                                            int monthToCount)
        {
            // Formats a list of labels only
            List<string> LabelsOnly = Labels(Pub);
            List<Publisher> LabelsPub = AllLabelsPublications(LabelsOnly, Pub);
            // Total incomes
            IncomesOfAllLabels(Pub, Sub, LabelsPub, monthToCount);
            // Sort
            List<Publisher> SortedLabels = (from la in LabelsPub orderby la.TotalPrice,
                                            la.Name select la).ToList<Publisher>();
            // Prints all the results to txt file and website
            InOutUtils.PrintPublishersTxt(fileName, SortedLabels, Pub, Sub, monthToCount);
            InOutUtils.PrintPublishersWeb(SortedLabels, Pub, Sub, table, monthToCount);
        }

        /// <summary>
        /// Counts incomes of all labels
        /// </summary>
        /// <param name="Pub">List of publications</param>
        /// <param name="Sub">List of subscribers</param>
        /// <param name="Labels">List of labels</param>
        /// <param name="monthToCount">Month to count incomes</param>
        private static void IncomesOfAllLabels (List<Publication> Pub, 
                                         List<Subscriber> Sub,
                                         List<Publisher> Labels,
                                         int monthToCount)
        {
            foreach (Publisher label in Labels)
            {
                foreach (string code in label.AllPublicationsCodes)
                {
                    double price = FindPrice(code, Pub, label.Name);
                    label.TotalPrice += IncomesOfOneLabelPub(Sub, Labels, monthToCount, 
                                                             code, price);
                }
            }
        }

        /// <summary>
        /// Counts the incomes of one label's publication
        /// </summary>
        /// <param name="Sub">List of subscribers</param>
        /// <param name="publishers">List of publishers</param>
        /// <param name="monthToCount">Month to count incomes</param>
        /// <param name="code">Code of publication</param>
        /// <param name="price">Price of publication</param>
        /// <returns>Total income</returns>
        private static double IncomesOfOneLabelPub (List<Subscriber> Sub, 
                                                    List<Publisher> publishers,
                                                    int monthToCount, string code,
                                                    double price)
        {
            double priceFinal = 0.00;
            List<Subscriber> temp2 = new List<Subscriber>();
            foreach (Subscriber sub1 in Sub)
            {
                var temp = from su in Sub where su.Code == code orderby 
                           su.Code select su;
                temp2 = (from te in temp where monthToCount >= te.StartMonth
                         && monthToCount <= (te.StartMonth + te.SubscriptionLength)
                         select te).ToList<Subscriber>();
            }
            foreach (Subscriber sub in temp2)
            {
                priceFinal += sub.PublicationsCount * price;
            }
            return priceFinal;
        }

        /// <summary>
        /// Finds a price of one publication by code and label
        /// </summary>
        /// <param name="code">Code</param>
        /// <param name="Pub">List of publications</param>
        /// <param name="label">Label</param>
        /// <returns>Price</returns>
        private static double FindPrice (string code, List<Publication> Pub, 
                                         string label)
        {
            double price = 0.00;
            foreach (Publication pu in Pub)
            {
                if (pu.Code == code && pu.PublisherName == label)
                {
                    price = pu.Price;
                }
            }
            return price;
        }

        /// <summary>
        /// Makes a list of publishers with their publications
        /// </summary>
        /// <param name="Labels">All labels</param>
        /// <param name="Pub">All publications</param>
        /// <returns>List</returns>
        private static List<Publisher> AllLabelsPublications(List<string> Labels,
                                                            List<Publication> Pub)
        {
            List<Publisher> Publishers = new List<Publisher>();
            foreach (string label in Labels)
            {
                List<string> publications = OneLabelPublications(label, Pub);
                Publisher publisher = new Publisher(label, publications);
                Publishers.Add(publisher);
            }
            return Publishers;
        }

        /// <summary>
        /// Makes a list of all publications codes of one label
        /// </summary>
        /// <param name="label">One label</param>
        /// <param name="Pub">List of publications</param>
        /// <returns>List</returns>
        private static List<string> OneLabelPublications (string label,
                                                          List<Publication> Pub)
        {
            List<string> PublicationsOfOne = new List<string>();
            foreach (Publication pubT in Pub)
            {
                if (pubT.PublisherName == label)
                {
                    PublicationsOfOne.Add(pubT.Code);
                }
            }
            return PublicationsOfOne;
        }
        /// <summary>
        /// Counts the price of one publication
        /// </summary>
        /// <param name="AllPub">List of publications</param>
        /// <param name="AllSub">List of subscribers</param>
        /// <param name="code">Code of publication</param>
        /// <param name="labelName">Label name</param>
        /// <returns>Price</returns>
        public static double PriceOfOnePublication (List<Publication> AllPub,
                                                    List<Subscriber> AllSub,
                                                    string code, string labelName,
                                                    int monthToCount)
        {
            double price = 0.00;
            List<double> priceTemp = (from pu in AllPub
                                      where pu.Code == code &&
                                      pu.PublisherName == labelName
                                      select pu.Price).ToList();

            List<Subscriber> subByCode = (from su in AllSub where su.Code == code &&
                                          monthToCount >= su.StartMonth
                         && monthToCount <= (su.StartMonth + su.SubscriptionLength)
                                          select su).ToList();
            foreach (Subscriber sub1 in subByCode)
            {
                price += sub1.PublicationsCount * priceTemp[0];
            }
            return price;
        }       

    }
}