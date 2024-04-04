using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_I3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Primary data reading and printing to the console
            StudentsRegister AllStudents = InOutUtils.ReadStudents("StudentsPresent.csv");
            string title = "Dabartiniai studentų atstovybės nariai: ";
            InOutUtils.PrintStudents(AllStudents, title);
            Console.WriteLine();

            StudentsRegister OlderStudents = InOutUtils.ReadStudents("StudentsPrevious.csv");
            title = "Ankstesnių metų studentų atstovybės nariai: ";
            InOutUtils.PrintStudents(OlderStudents, title);
            Console.WriteLine();

            // Primary data printing to "txt" file
            string fileNameTxt = "Data.txt";
            string header = "Dabartiniai studentų atstovybės nariai: ";
            InOutUtils.PrintStudentsToTxt(fileNameTxt, AllStudents, header);
            header = "Ankstesnių metų studentų atstovybės nariai: ";
            InOutUtils.PrintStudentsToTxt(fileNameTxt, OlderStudents, header);

            // Task 1
            Student FirstOldest = TaskUtils.FindOldestStudent(AllStudents);
            Student SecondOldest = TaskUtils.FindOldestStudent(OlderStudents);
            DateTime OldestDate = SecondOldest.Date;
            if (FirstOldest.Date < SecondOldest.Date)
            {
                OldestDate = FirstOldest.Date;
            }
            StudentsContainer Oldest1 = TaskUtils.Oldest1(AllStudents, OldestDate);
            StudentsContainer Oldest2 = TaskUtils.Oldest2(OlderStudents, OldestDate);
            Console.WriteLine("Vyriausias atstovybei priklausęs studentas arba studentai:");
            InOutUtils.Header();
            InOutUtils.PrintOldest(Oldest1);
            InOutUtils.PrintOldest(Oldest2);
            Console.WriteLine(new string('-', 86));
            Console.WriteLine();

            // Task 2
            StudentsContainer Removed = TaskUtils.Removed(AllStudents, OlderStudents);
            title = "Studentai, atstovybę palikę antraisiais metais:";
            InOutUtils.PrintRemoved(Removed, title);

            // Task 3
            string fileNameCSV = "PalikoPirmi.csv";
            if (Removed.Count > 0)
            {
                InOutUtils.PrintToCSVFile(fileNameCSV, Removed);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Studentų, palikusių atstovybę pirmaisiais metais, nėra.");
            }

            // Task 4
            fileNameCSV = "Seniai.csv";
            StudentsContainer Both = TaskUtils.BothYears(OlderStudents, AllStudents);
            if (Both.Count > 0)
            {
                Both.Sort();
                InOutUtils.PrintToCSVFile(fileNameCSV, Both);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Studentų, atstovybei priklausiusių abejais metais, nėra.");
            }
        }
    }
}
