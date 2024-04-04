using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.IO;

namespace L2
{
    /// <summary>
    /// Main class to process program
    /// </summary>
    public partial class Web2 : System.Web.UI.Page
    {
        const string inputA = @"App_Data/U10a1.txt";
        const string inputB = @"App_Data/U10b.txt";
        const string output = @"App_Data/R3.txt";

        // Makes results text not visible
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
            Label7.Visible = false;
            Label10.Visible = false;
            Label11.Visible = false;
            Label12.Visible = false;
        }

        // Shows results when the button is clicked
        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;
            Label7.Visible = false;
            Label10.Visible = false;
            Label12.Visible = false;

            // Saving data files directory
            if (FileUpload1.HasFile && FileUpload2.HasFile)
            {
                string fileName1 = Server.HtmlEncode(FileUpload1.FileName);
                string extension1 = Path.GetExtension(fileName1);

                string fileName2 = Server.HtmlEncode(FileUpload2.FileName);
                string extension2 = Path.GetExtension(fileName2);

                if (extension1.Equals(".txt") && extension2.Equals(".txt"))
                {
                    FileUpload1.SaveAs(Server.MapPath(inputA));
                    FileUpload2.SaveAs(Server.MapPath(inputB));
                }
            }

            // Saving primary data to the linked lists
            WorkersList Workers = InOutUtils.ReadWorkers(Server.MapPath(inputA));
            PartsList Parts = InOutUtils.ReadParts(Server.MapPath(inputB));
            //------------------------------------------------------------------

            // Preparing new results text file
            if (File.Exists(Server.MapPath(output)))
            {
                File.Delete(Server.MapPath(output));
            }

            // Primary data printing to file and to website
            Table1.Rows.Add(TaskUtils.CreateRowWorkers(Table1, "<b>Data</b>",
                                    "<b>Pavardė</b>", "<b>Vardas</b>",
                                    "<b>Detalės kodas</b>",
                                    "<b>Pagamintų detalių kiekis</b>"));
            InOutUtils.PrintWorkersDataTxt(Server.MapPath(output), Workers);
            InOutUtils.PrintWorkersData(Workers, Table1);

            Table2.Rows.Add(TaskUtils.CreateRowParts(Table2, "<b>Kodas</b>",
                                    "<b>Pavadinimas</b>", "<b>Įkainis</b>"));
            InOutUtils.PrintPartsDataTxt(Server.MapPath(output), Parts);
            InOutUtils.PrintPartsData(Parts, Table2);
            //------------------------------------------------------------------

            // New list without repetitions and counted values
            WorkersList WorkersCopy = Workers.Copy();
            WorkersList NewList = TaskUtils.FormattedList(WorkersCopy, Parts);

            // Table3 for the most money earned worker / workers
            WorkersList MostEarned = TaskUtils.AllMostEarned(WorkersCopy);
            MostEarned.Sort();
            Table3.Rows.Add(TaskUtils.CreateRowWorkers(Table3, "<b>Pavardė</b>",
                                       "<b>Vardas</b>", "<b>Dienų kiekis</b>",
                                       "<b>Pagamintų detalių kiekis</b>",
                                       "<b>Uždirbta suma</b>"));
            InOutUtils.PrintMostEarnedTxt(Server.MapPath(output), MostEarned);
            InOutUtils.PrintMostEarned(MostEarned, Table3);
            //------------------------------------------------------------------

            // Table4 for the list of workers who made only one type parts
            WorkersList OneType = TaskUtils.DifferentPartsList(Workers, NewList);
            if (OneType.WorkersCount() > 0)
            {
                Label7.Visible = true; // table header
                Table4.Rows.Add(TaskUtils.CreateRowWorkers(Table4,
                                "<b>Pavardė</b>", "<b>Vardas</b>",
                                "<b>Pagamintų detalių kiekis</b>",
                                "<b>Uždirbta suma</b>"));
                OneType.Sort();
                InOutUtils.PrintOneTypeTxt(Server.MapPath(output), OneType,
                       "Darbuotojai, gaminę tik vienos rūšies detales:");
                InOutUtils.PrintOneType(OneType, Table4);
            }
            else
            {
                Label12.Visible = false; // writes fault
                File.AppendAllText(Server.MapPath(output), "Darbuotojų, gaminusių" +
                                   " tik vieno tipo detales, nėra.");
            }
            // ------------------------------------------------------------------

            // Table5 for the new list made by S and K values
            WorkersList SelectedList = TaskUtils.NewListBy_S_K(NewList, Parts,
                                                              TextBox1, TextBox2);
            if (SelectedList.WorkersCount() > 0)
            {
                SelectedList.Sort();
                Table5.Rows.Add(TaskUtils.CreateRowWorkers(Table5,
                                "<b>Pavardė</b>", "<b>Vardas</b>",
                                "<b>Pagamintų vienetų kiekis</b>",
                                "<b>Uždirbta suma</b>"));
                InOutUtils.PrintOneTypeTxt(Server.MapPath(output), SelectedList,
                "Naujas duomenų rinkinys, kai pagamintų vienetų skaičius > S" +
                " ir įkainis < K:");
                Label10.Visible = true; // table header
                InOutUtils.PrintSelected(SelectedList, Table5);
            }
            else
            {
                Label11.Visible = true; // writes fault
                File.AppendAllText(Server.MapPath(output), "Darbuotojų pagal " +
                                   "pasirinktus kriterijus nėra.");
            }

        }
    }

}