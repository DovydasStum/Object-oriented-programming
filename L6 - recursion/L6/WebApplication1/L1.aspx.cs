using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class L1 : System.Web.UI.Page
    {
        private string input = @"App_Data/bb.txt";
        private string output = @"App_Data/R3.txt";
        char[,] letters = new char[500, 500];
        int lines, rows;
        List<int> allAreas;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Prints the primary data
            InOutUtils.PrintTableHeader(Table1);
            InOutUtils.FileRead((Server.MapPath(input)),
                                out lines, out rows, letters);
            InOutUtils.PrintTableData(Table1, lines, rows, letters);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {          
            int counter = 0;
            TaskUtils.CountAndArea(lines, rows, letters, out allAreas, out counter);
            TextBox1.Text = counter.ToString();
            TaskUtils.Sort(allAreas);
            InOutUtils.PrintAreas(Table2, allAreas);
            InOutUtils.PrintDataToTxt(lines, rows, letters, (Server.MapPath(output)),
                                      counter, allAreas);
        }

        
    }
}