using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab_I3
{
    class InOutUtils
    {
        /// <summary>
        /// Reads primary data
        /// </summary>
        /// <param name="fileName">Name of "csv" file</param>
        /// <returns>List of students</returns>
        public static StudentsRegister ReadStudents(string fileName)
        {
            StudentsRegister AllStudents = new StudentsRegister();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            AllStudents.Year = int.Parse(Lines[0]);
            for (int i = 1; i < Lines.Count(); i++)
            {
                string line = Lines[i];
                string[] Values = line.Split(';');
                string surname = Values[0];
                string name = Values[1];
                DateTime date = DateTime.Parse(Values[2]);
                int id = int.Parse(Values[3]);
                int course = int.Parse(Values[4]);
                string phone = Values[5];
                string mark = Values[6];
                Student student = new Student(surname, name, date, id,
                                              course, phone, mark);
                if (!AllStudents.Contains(student))
                {
                    AllStudents.Add(student);
                }
            }
            return AllStudents;
        }

        /// <summary>
        /// Prints primary data to screen
        /// </summary>
        /// <param name="Students">List of students</param>
        public static void PrintStudents(StudentsRegister AllStudents,
                                         string title)
        {
            Console.WriteLine("Duomenų metai: {0}", AllStudents.Year);
            Console.WriteLine(title);
            Console.WriteLine(new string('-', 86));
            Console.WriteLine("| {0,-11} | {1,-12} | {2,-11} | {3,-5} |" +
                              " {4,-6} | {5,-11} | {6,-8} |", "Pavardė",
                              "Vardas", "Gimimo data", "ID", "Kursas",
                              "Tel. nr.", "Požymis");
            Console.WriteLine(new string('-', 86));
            for (int i = 0; i < AllStudents.Count(); i++)
            {
                Student student = AllStudents.Get(i);
                Console.WriteLine(AllStudents.Get(i).ToString());
            }
            Console.WriteLine(new string('-', 86));
        }

        /// <summary>
        /// Prints primary data to "txt" file
        /// </summary>
        /// <param name="fileNameTxt">Name of "txt" file</param>
        /// <param name="Students">List of students</param>
        public static void PrintStudentsToTxt(string fileNameTxt,
                                              StudentsRegister AllStudents,
                                              string header)
        {
            string[] Lines = new string[AllStudents.Count() + 6];
            Lines[0] = String.Format(header);
            Lines[1] = String.Format("Duomenų metai: {0}", AllStudents.Year);
            Lines[2] = String.Format(new string('-', 86));
            Lines[3] = String.Format("| {0,-11} | {1,-12} | {2,-11} | {3,-5} |" +
                                     " {4,-6} | {5,-11} | {6,-8} | ", "Pavardė",
                                     "Vardas", "Gimimo data", "ID", "Kursas",
                                     "Tel. nr.", "Požymis");
            Lines[4] = String.Format(new string('-', 86));
            for (int i = 0; i < AllStudents.Count(); i++)
            {
                Student student = AllStudents.Get(i);
                Lines[i + 5] = String.Format(AllStudents.Get(i).ToString());
            }
            Lines[AllStudents.Count() + 5] = String.Format(new string('-', 86));
            File.AppendAllLines(fileNameTxt, Lines, Encoding.UTF8);
        }

        /// <summary>
        /// Prints a list of students who left organisation
        /// </summary>
        /// <param name="Removed">List of students who left</param>
        public static void PrintRemoved(StudentsContainer Removed, 
                                       string title)
        {
            Console.WriteLine(title);
            Console.WriteLine(new string('-', 86));
            Console.WriteLine("| {0,-11} | {1,-12} | {2,-11} | {3,-5} |" +
                              " {4,-6} | {5,-11} | {6,-8} |", "Pavardė",
                              "Vardas", "Gimimo data", "ID", "Kursas",
                              "Tel. nr.", "Požymis");
            Console.WriteLine(new string('-', 86));
            for (int i = 0; i < Removed.Count; i++)
            {
                Console.WriteLine(Removed.Get(i).ToString());
            }
            Console.WriteLine(new string('-', 86));
        }

        /// <summary>
        /// Header for data printing
        /// </summary>
        public static void Header()
        {
            Console.WriteLine(new string('-', 86));
            Console.WriteLine("| {0,-11} | {1,-12} | {2,-11} | {3,-5} |" +
                              " {4,-6} | {5,-11} | {6,-8} |", "Pavardė",
                              "Vardas", "Gimimo data", "ID", "Kursas",
                              "Tel. nr.", "Požymis");
            Console.WriteLine(new string('-', 86));
        }

        /// <summary>
        /// Prints a list of the oldest students
        /// </summary>
        /// <param name="Oldest">List of oldest students</param>
        public static void PrintOldest(StudentsContainer Oldest)
        {
            for (int i = 0; i < Oldest.Count; i++)
            {
                Console.WriteLine(Oldest.Get(i).ToString());
            }
        }

        /// <summary>
        /// Prints students to CSV file
        /// </summary>
        /// <param name = "fileNameCSV" > Name of "csv" file</param>
        /// <param name = "LeftFirst" > List of filterred students</param>
        public static void PrintToCSVFile(string fileNameCSV, 
                                          StudentsContainer LeftFirst)
        {
            string[] Lines = new string[LeftFirst.Count + 1];
            Lines[0] = String.Format("{0};{1};{2};{3};{4};{5};{6}",
                                     "Pavardė", "Vardas", "Gimimo data",
                                     "ID", "Kursas", "Tel. nr.", "Požymis");
            for (int i = 0; i < LeftFirst.Count; i++)
            {
                Lines[i + 1] = String.Format("{0};{1};{2};{3};{4};{5};{6}",
                               LeftFirst.Get(i).Surname, LeftFirst.Get(i).Name,
                               LeftFirst.Get(i).Date.ToShortDateString(),
                               LeftFirst.Get(i).ID, LeftFirst.Get(i).Course,
                               LeftFirst.Get(i).Phone, LeftFirst.Get(i).Mark);
            }
            File.WriteAllLines(fileNameCSV, Lines, Encoding.UTF8);
        }
    }
}
