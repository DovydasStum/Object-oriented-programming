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
    public partial class Web : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Result labels and tables
            Label2.Visible = false;
            Table1.Visible = false;
            Label3.Visible = false;
            Table2.Visible = false;
            Label4.Visible = false;
            TextBox1.Visible = false;
            Button2.Visible = false;
            Label6.Visible = false;
            Table3.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Preparing new output files
            if (File.Exists(Server.MapPath("App_Data/Tarpiniai.bin")))
                File.Delete(Server.MapPath("App_Data/Tarpiniai.bin"));
            if (File.Exists(Server.MapPath("App_Data/Tarpiniai2.bin")))
                File.Delete(Server.MapPath("App_Data/Tarpiniai2.bin"));
            if (File.Exists(Server.MapPath("App_Data/Results.txt")))
                File.Delete(Server.MapPath("App_Data/Results.txt"));

            // Data and results files locations
            string inputFiles = Server.MapPath(@"App_Data/Subscribers1");
            string inputFilesPub = Server.MapPath(@"App_Data/Publications.txt");
            string output = Server.MapPath(@"App_Data/Results.txt");

            // Primary data reading and printing to txt file and website
            List<Subscriber> AllSubscribers = new List<Subscriber>();
            List<Publication> Publications = new List<Publication>();
            try
            {
                Publications = InOutUtils.ReadPublications(inputFilesPub);
                AllSubscribers = InOutUtils.ReadSubscribers(inputFiles);
            }
            catch (Exception ex)
            {
                TextBox2.Text += string.Format("Neteisingi duomenys.\n" +
                    "Plačiau:\n" + ex.Message + "\n");
                Label2.Visible = false;
                Table1.Visible = false;
                Label3.Visible = false;
                Table2.Visible = false;
                Label4.Visible = false;
                TextBox1.Visible = false;
                Button2.Visible = false;
            }

            BinaryFormatter format = new BinaryFormatter();
            FileStream file;
            file = new FileStream(Server.MapPath("App_Data/Tarpiniai.bin"),
                FileMode.OpenOrCreate, FileAccess.Write);
            format.Serialize(file, AllSubscribers);
            file.Close();
            FileStream file2;
            file2 = new FileStream(Server.MapPath("App_Data/Tarpiniai2.bin"),
                FileMode.OpenOrCreate, FileAccess.Write);
            format.Serialize(file2, Publications);
            file2.Close();

            Label2.Visible = true;
            Table1.Visible = true;
            Label3.Visible = true;
            Table2.Visible = true;
            Label4.Visible = true;
            TextBox1.Visible = true;
            Button2.Visible = true;

            File.AppendAllText(output, "Pradiniai duomenys:\n\nPrenumeratoriai:\n");
            InOutUtils.PrintSubscribersTxt(AllSubscribers, output);
            InOutUtils.PrintSubscribersWeb(Table1, AllSubscribers);

            File.AppendAllText(output, "Leidiniai:\n");
            InOutUtils.PrintPublicationsTxt(Publications, output);
            InOutUtils.PrintPublicationsWeb(Table2, Publications);
            //--------------------------------------------------------------
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // Result labels and tables
            Label2.Visible = true;
            Table1.Visible = true;
            Label3.Visible = true;
            Table2.Visible = true;
            Label4.Visible = true;
            TextBox1.Visible = true;
            Button2.Visible = true;
            Label6.Visible = false;
            Table3.Visible = false;
            string output = Server.MapPath(@"App_Data/Results.txt");

            BinaryFormatter format = new BinaryFormatter();
            FileStream file;
            List<Subscriber> AllSubscribers = new List<Subscriber>();
            file = new FileStream(Server.MapPath("App_Data/Tarpiniai.bin"),
                FileMode.Open, FileAccess.Read);
            AllSubscribers = (List<Subscriber>)format.Deserialize(file);
            file.Close();

            FileStream file2;
            List<Publication> Publications = new List<Publication>();
            file2 = new FileStream(Server.MapPath("App_Data/Tarpiniai2.bin"),
                FileMode.Open, FileAccess.Read);
            Publications = (List<Publication>)format.Deserialize(file2);
            file2.Close();

            InOutUtils.PrintSubscribersWeb(Table1, AllSubscribers);
            InOutUtils.PrintPublicationsWeb(Table2, Publications);
            //--------------------------------------------------------------

            // User input 
            int monthToCount = new int();
            try
            {
                monthToCount = int.Parse(TextBox1.Text);
                Label6.Visible = true;
                Table3.Visible = true;
            }
            catch (Exception ex)
            {
                TextBox2.Text += string.Format("Neteisingi duomenys.\n" +
                    "Plačiau:\n" + ex.Message + "\n");
                Label6.Visible = false;
                Table3.Visible = false;
            }
            
            // Main task
            File.AppendAllText(output, "Rezultatai:\n\n");
            TaskUtils.FormatLabelsData(Table3, output, Publications, 
                                    AllSubscribers, monthToCount);
            //--------------------------------------------------------------
        }
    }
}