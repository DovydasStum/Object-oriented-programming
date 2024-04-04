using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace L4
{
    public partial class Web : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Results labels and tables
            Label2.Visible = false; 
            Label3.Visible = false;
            Label4.Visible = false;
            Label6.Visible = false; 
            Table1.Visible = false;
            Table2.Visible = false;
            Table3.Visible = false;
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            // Data and results files locations
            string inputFiles = Server.MapPath(@"App_Data/Duom/");
            string TxtResultsFile = Server.MapPath(@"App_Data/Results.txt");
            string output_OnePlace = Server.MapPath(@"App_Data/Tikten.csv");
            string output_Expensive = Server.MapPath(@"App_Data/Brangus.csv");

            if (File.Exists(Server.MapPath("App_Data/Results.txt")))
                File.Delete(Server.MapPath("App_Data/Results.txt"));
            if (File.Exists(Server.MapPath("App_Data/Tikten.csv")))
                File.Delete(Server.MapPath("App_Data/Tikten.csv"));
            if (File.Exists(Server.MapPath("App_Data/Brangus.csv")))
                File.Delete(Server.MapPath("App_Data/Brangus.csv"));
            if (File.Exists(Server.MapPath("App_Data/Tarpiniai.bin")))
                File.Delete(Server.MapPath("App_Data/Tarpiniai.bin"));

            Label2.Visible = true;
            Table1.Visible = true;
            Label3.Visible = true;
            Table2.Visible = true;
            //--------------------------------------------------------------

            // Primary data reading and printing to txt file and to website
            List<DeviceRegister> AllShops = new List<DeviceRegister>();
            try
            {
                AllShops = InOutUtils.Read(inputFiles);
            }
            catch (Exception ex)
            {
                TextBox1.Text += string.Format("Neteisingi duomenys.\n" +
                    "Plačiau:\n" + ex.Message + "\n");
                Label2.Visible = false;
                Table1.Visible = false;
                Label3.Visible = false;
                Table2.Visible = false;
            }

            InOutUtils.PrintAllTXT(TxtResultsFile, "Pradiniai duomenys:\n\n",
                                   AllShops);

            BinaryFormatter format = new BinaryFormatter();
            FileStream file;
            file = new FileStream(Server.MapPath("App_Data/Tarpiniai.bin"),
                FileMode.OpenOrCreate, FileAccess.Write);
            format.Serialize(file, AllShops);
            file.Close();

            InOutUtils.PrintToWeb(Table1, AllShops, TextBox1);
            //--------------------------------------------------------------

            // Task 1 – Siemens devices
            File.AppendAllText(TxtResultsFile, "Skirtingi Siemens prietaisai:\n\n");
            TaskUtils.SiemensDevices(AllShops, TxtResultsFile, Table2);

            // Task 2 – the cheapest fridges with atleast 80L capacity
            File.AppendAllText(TxtResultsFile, "Pigiausių šaldytuvų " +
                "(bent 80L talpos) sąrašas:\n");
            List<Device> FridgesAll = TaskUtils.CheapestFridges(Table3, AllShops, 
                                                            TxtResultsFile);
            if (FridgesAll.Count() > 0)
            {
                Label4.Visible = true;
                Table3.Visible = true;
                TaskUtils.SortByPrice(FridgesAll);
                List<Device> Fridges10 = TaskUtils.Formatted10(FridgesAll);
                InOutUtils.PrintCheapestFridgesTXT(TxtResultsFile, Fridges10);
                InOutUtils.PrintCheapestFridgesWeb(Table3, Fridges10);
            }
            else
            {
                File.AppendAllText(TxtResultsFile, "Duomenų nėra.\n\n");
                Label6.Visible = true;
            }

            // Task 3 – devices only in one shop
            File.AppendAllText(TxtResultsFile, "Įrenginių, kuriuos galima " +
                "įsigyti tik vienoje parduotuvėje, sąrašas:\n");
            List<Device> ListOnePlace = TaskUtils.DevicesOnePlaceOnly(AllShops);
            if (ListOnePlace.Count() > 0)
            {
                InOutUtils.PrintListTXT(ListOnePlace, TxtResultsFile);
                InOutUtils.PrintListCSV(ListOnePlace, output_OnePlace);
            }
            else
            {
                File.AppendAllText(TxtResultsFile, "Duomenų nėra.\n\n");
            }

            // Task 4 – expensive devices
            File.AppendAllText(TxtResultsFile, "Brangių įrenginių sąrašas:\n");
            List<Device> ExpensiveDevices = TaskUtils.Expensive(AllShops);

            if (ExpensiveDevices.Count() > 0)
            {
                TaskUtils.Sort(ExpensiveDevices);
                InOutUtils.PrintListTXT(ExpensiveDevices, TxtResultsFile);
                InOutUtils.PrintListCSV(ExpensiveDevices, output_Expensive);
            }
            else
            {
                File.AppendAllText(TxtResultsFile, "Duomenų nėra.\n\n");
            }

        }
    }
}