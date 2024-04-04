using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Studentų_atstovybė
{
    class InOutUtils // Class for file reading and data printing
    {
        /// <summary>
        /// File reading
        /// </summary>
        /// <param name="fileName">Name of file</param>
        /// <returns>List of all people</returns>
        public static List<Person> ReadPeople(string fileName)
        {
            List<Person> People = new List<Person>();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                string surname = Values[0];
                string name = Values[1];
                DateTime date = DateTime.Parse(Values[2]);
                int number = int.Parse(Values[3]);
                int course = int.Parse(Values[4]);
                string phone = Values[5];
                string mark = Values[6];

                Person person = new Person(surname, name, date, number, course, phone, mark);
                People.Add(person);
            }
            return People;
        }

        /// <summary>
        /// Prints all primary data to the screen
        /// </summary>
        /// <param name="People">All people</param>
        public static void PrintPeopleToScreen(List<Person> People)
        {
            Console.WriteLine("Užduoties nr: {0}", 134%24+1);
            Console.WriteLine("Studentų atstovybės nariai: ");
            Console.WriteLine(new string('-', 92));
            Console.WriteLine("| {0,-10} | {1,-12} | {2,-11} | {3,12} | {4,-6} | {5,-11} | {6,-8} |",
            "Pavardė", "Vardas", "Gimimo data", "Stud. p. nr.", "Kursas", "Tel. nr.", "Požymis");
            Console.WriteLine(new string('-', 92));
            foreach (Person person in People)
            {
                Console.WriteLine("| {0,-10} | {1,-12} | {2,11} | {3,12} | {4,6} | {5,11} | {6,-8} |",
                person.Surname, person.Name, person.Date.ToShortDateString(), person.Number, person.Course,
                person.Phone, person.Mark);
            }
            Console.WriteLine(new string('-', 92));
            Console.WriteLine("");
        }

        /// <summary>
        /// Prints all primary data to ".txt" file
        /// </summary>
        /// <param name="fileName1">Name of ".txt" file</param>
        /// <param name="People">All people</param>
        public static void PrintPeopleToTxtFile(string fileName1, List<Person> People)
        {
            string[] lines = new string[People.Count + 5];
            lines[0] = String.Format("Studentų atstovybės nariai: ");
            lines[1] = String.Format(new string('-', 92));
            lines[2] = String.Format("| {0,-10} | {1,-12} | {2,-11} | {3,12} | {4,-6} | {5,-11} | {6,-8} |",
            "Pavardė", "Vardas", "Gimimo data", "Stud. p. nr.", "Kursas", "Tel. nr.", "Požymis");
            lines[3] = String.Format(new string('-', 92));

            for (int i = 0; i < People.Count; i++)
            {
                lines[i + 4] = String.Format("| {0,-10} | {1,-12} | {2,11} | {3,12} | {4,6} | {5,11}" +
                " | {6,-8} |", People[i].Surname, People[i].Name, People[i].Date.ToShortDateString(),
                People[i].Number, People[i].Course, People[i].Phone, People[i].Mark);
            }
            lines[People.Count + 4] = String.Format(new string('-', 92));
            File.WriteAllLines(fileName1, lines, Encoding.UTF8);
        }

        /// <summary>
        /// Prints oldest person or people
        /// </summary>
        /// <param name="People">List of people</param>
        /// <param name="OldestPeople">List of oldest people</param>
        public static void PrintOldestPeople(List<Person> OldestPeople)
        {
            Console.WriteLine("Vyriausias studentų atstovybės narys arba nariai: ");
            Console.WriteLine(new string('-', 38));
            Console.WriteLine("| {0,-10} | {1,-12} | {2,-4} |",
            "Vardas", "Pavardė", "Amžius");
            Console.WriteLine(new string('-', 38));
            foreach (Person person in OldestPeople)
            {
                Console.WriteLine("| {0,-10} | {1,-12} | {2,6} |",
                person.Name, person.Surname, person.CalculateAge());
            }
            Console.WriteLine(new string('-', 38));
            Console.WriteLine("");
        }

        /// <summary>
        /// Prints numbers of course which contain the most students
        /// </summary>
        /// <param name="MostStudents">List of courses</param>
        public static void PrintMostStudents (List<int> MostStudents)
        {
            Console.WriteLine("Daugiausiai studentų yra iš šių kursų:");
            for (int i = 0; i < MostStudents.Count; i++)
            {
                Console.WriteLine(MostStudents[i]);
            }
        }

        /// <summary>
        /// Prints the highest amount of students in a course
        /// </summary>
        /// <param name="People">All people</param>
        public static void PrintHighestAmount (List<Person> People)
        {
            Console.WriteLine("Studentų šiuose kursuose kiekis: {0}", TaskUtils.CounterMax(People));
            Console.WriteLine();
        }

        /// <summary>
        /// Prints second and higher course students to ".csv" file
        /// </summary>
        /// <param name="fileName">Name of file</param>
        /// <param name="People">All people</param>
        public static void PrintToCSVFile(string fileName, List<Person> People)
        {
            string[] lines = new string[People.Count + 1];
            lines[0] = String.Format("{0};{1};{2};{3};{4};{5};{6}", "Pavardė", "Vardas", "Gimimo data",
            "Stud. p. nr.", "Kursas", "Tel. nr.", "Požymis");
            for (int i = 0; i < People.Count; i++)
            {
                lines[i + 1] = String.Format("{0};{1};{2};{3};{4};{5};{6}", People[i].Surname, People[i].Name, 
                People[i].Date.ToShortDateString(), People[i].Number, People[i].Course, People[i].Phone, People[i].Mark);
            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }
    }
}
