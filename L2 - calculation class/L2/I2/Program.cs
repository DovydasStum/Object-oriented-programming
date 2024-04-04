using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace I2
{
    class Program // class for main program
    {
        static void Main(string[] args)
        {
            // Primary data reading and printing to the console
            StudentsRegister register = InOutUtils.ReadStudents("StudentsPresent2.csv");
            Console.WriteLine("Dabartiniai studentų atstovybės nariai: ");
            InOutUtils.PrintRegisterStudents(register);
            Console.WriteLine();

            StudentsRegister olderRegister = InOutUtils.ReadStudents("StudentsPrevious2.csv");
            Console.WriteLine("Ankstesnių metų studentų atstovybės nariai: ");
            InOutUtils.PrintRegisterStudents(olderRegister);
            Console.WriteLine();

            // Primary data printing to "txt" file
            string fileNameTxt = "Data.txt";
            string header = "Dabartiniai studentų atstovybės nariai: ";
            InOutUtils.PrintRegisterToTxt(fileNameTxt, register, header);
            header = "Praėjusių metų studentų atstovybės nariai: ";
            InOutUtils.PrintRegisterToTxt(fileNameTxt, olderRegister, header);

            // Task 1
            List<Student> Removed = StudentsRegister.Removed(olderRegister, register);
            Console.WriteLine("Studentai, atstovybę palikę antraisiais metais:");
            InOutUtils.PrintRemoved(Removed);
            Console.WriteLine();

            // Task 2
            Student FirstOldest = register.FindOldestStudent();
            Student SecondOldest = olderRegister.FindOldestStudent();
            DateTime OldestDate = SecondOldest.Date;
            if (FirstOldest.Date < SecondOldest.Date)
            {
                OldestDate = FirstOldest.Date;
            }
            List<Student> Oldest1 = StudentsRegister.Oldest1(register, OldestDate);
            List<Student> Oldest2 = StudentsRegister.Oldest2(olderRegister, OldestDate);
            Console.WriteLine("Vyriausias atstovybei priklausęs studentas arba studentai: ");
            InOutUtils.Header();
            InOutUtils.PrintOldest(Oldest1);
            InOutUtils.PrintOldest(Oldest2);
            Console.WriteLine(new string('-', 86));

            // Task 3
            List<Student> Filter = StudentsRegister.BothYears(olderRegister, register);
            string fileNameCSV = "Seniai.csv";
            if (Filter.Count > 0)
            {
                InOutUtils.PrintToCSVFile(fileNameCSV, Filter);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Studentų, vis dar esančių atstovybėje, nebėra.");
            }
        }
    }
}
