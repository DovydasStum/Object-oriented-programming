using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace I2
{
    class InOutUtils
    {
        /// <summary>
        /// Reads primary data
        /// </summary>
        /// <param name="fileName">Name of "csv" file</param>
        /// <returns>List of students</returns>
        public static StudentsRegister ReadStudents (string fileName)
        {
            StudentsRegister Students = new StudentsRegister();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            Students.Year = int.Parse(Lines[0]);
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
                if (!Students.Contains(student))
                {
                    Students.Add(student);
                }
            }
            return Students;
        }

        /// <summary>
        /// Prints primary data to screen
        /// </summary>
        /// <param name="Students">List of students</param>
        public static void PrintRegisterStudents (StudentsRegister Students)
        {
            Console.WriteLine("Duomenų metai: {0}", Students.Year);
            Console.WriteLine(new string ('-', 86));
            Console.WriteLine("| {0,-11} | {1,-12} | {2,-11} | {3,-5} | {4,-6}" +
                              " | {5,-11} | {6,-8} |", "Pavardė", "Vardas",
                              "Gimimo data", "ID", "Kursas", "Tel. nr.", "Požymis");
            Console.WriteLine(new string('-', 86));
            for (int i = 0; i < Students.Count(); i++)
            {
                Student student = Students.Get(i);
                Console.WriteLine(Students.Get(i).ToString()); 
            }
            Console.WriteLine(new string ('-', 86));
        }

        /// <summary>
        /// Prints  primary data to "txt" file
        /// </summary>
        /// <param name="fileNameTxt">Name of "txt" file</param>
        /// <param name="Students">List of students</param>
        public static void PrintRegisterToTxt(string fileNameTxt, StudentsRegister Students,
                                              string header)
        {
            string[] Lines = new string[Students.Count() + 6];
            Lines[0] = String.Format(header);
            Lines[1] = String.Format("Duomenų metai: {0}", Students.Year);
            Lines[2] = String.Format(new string('-', 86));
            Lines[3] = String.Format("| {0,-11} | {1,-12} | {2,-11} | {3,-5} |" +
                                     " {4,-6} | {5,-11} | {6,-8} | ", "Pavardė",
                                     "Vardas", "Gimimo data", "ID", "Kursas",
                                     "Tel. nr.", "Požymis");
            Lines[4] = String.Format(new string('-', 86));
            for (int i = 0; i < Students.Count(); i++)
            {
                Student student = Students.Get(i);
                Lines[i + 5] = String.Format(Students.Get(i).ToString());
            }
            Lines[Students.Count() + 5] = String.Format(new string('-', 86));
            File.AppendAllLines(fileNameTxt, Lines, Encoding.UTF8);
        }

        /// <summary>
        /// Prints a list of students who left organisation
        /// </summary>
        /// <param name="Removed">List of students who left</param>
        public static void PrintRemoved(List<Student> Removed)
        {
            Console.WriteLine(new string('-', 86));
            Console.WriteLine("| {0,-11} | {1,-12} | {2,-11} | {3,-5} | {4,-6} |" +
                              " {5,-11} | {6,-8} |", "Pavardė", "Vardas",
                              "Gimimo data", "ID", "Kursas", "Tel. nr.", "Požymis");
            Console.WriteLine(new string('-', 86));
            foreach (Student student in Removed)
            {
                Console.WriteLine(student.ToString());
            }
          Console.WriteLine(new string('-', 86));
            
        }

        /// <summary>
        /// Prints a list of the oldest students
        /// </summary>
        /// <param name="Oldest">List of oldest students</param>
        public static void PrintOldest(List<Student> Oldest)
        {
            foreach (Student student in Oldest)
            {
                Console.WriteLine(student.ToString());
            }
        }

        /// <summary>
        /// Prints students who were at the organisation both years
        /// </summary>
        /// <param name="fileNameCSV">Name of "csv" file</param>
        /// <param name="Filter">List of filterred students</param>
        public static void PrintToCSVFile (string fileNameCSV, List<Student> Filter)
        {
            string[] Lines = new string[Filter.Count + 1];
            Lines[0] = String.Format("{0};{1};{2};{3};{4};{5};{6}","Pavardė", "Vardas", 
                                     "Gimimo data", "ID", "Kursas", "Tel. nr.", "Požymis");
            for (int i = 0; i < Filter.Count; i++)
            {
                Lines[i + 1] = String.Format("{0};{1};{2};{3};{4};{5};{6}", Filter[i].Surname,
                                            Filter[i].Name, Filter[i].Date.ToShortDateString(), 
                                            Filter[i].ID, Filter[i].Course,
                                            Filter[i].Phone, Filter[i].Mark);
            }
            File.WriteAllLines(fileNameCSV, Lines, Encoding.UTF8);
        }

        /// <summary>
        /// Header for data printing
        /// </summary>
        public static void Header()
        {
            Console.WriteLine(new string('-', 86));
            Console.WriteLine("| {0,-11} | {1,-12} | {2,-11} | {3,-5} | {4,-6} |" +
                              " {5,-11} | {6,-8} |", "Pavardė", "Vardas", "Gimimo data",
                              "ID", "Kursas", "Tel. nr.", "Požymis");
            Console.WriteLine(new string('-', 86));
        }
    }
}
