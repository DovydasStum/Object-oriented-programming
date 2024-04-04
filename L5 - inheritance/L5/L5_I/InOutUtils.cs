using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace L5_I
{
    class InOutUtils
    {
        /// <summary>
        /// Reads primary data
        /// </summary>
        /// <param name="fileName">Name of "csv" file</param>
        /// <returns>List of members</returns>
        public static MembersRegister ReadMembers(string fileName)
        {
            MembersRegister AllMembers = new MembersRegister();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            AllMembers.Year = int.Parse(Lines[0]);
            for (int i = 1; i < Lines.Count(); i++)
            {
                string line = Lines[i];
                string[] Values = line.Split(';');
                string surname = Values[0];
                string name = Values[1];
                DateTime date = DateTime.Parse(Values[2]);
                string phone = Values[3];
                switch (Values.Count())
                {
                    case 6:
                        int id = int.Parse(Values[4]);
                        string course = Values[5];
                        Student student = new Student(surname, name, date,
                                          phone, id, course);
                        AllMembers.Add(student);
                        break;
                    case 5:
                        string workPlace = Values[4];
                        Graduate graduate = new Graduate(surname, name,
                                            date, phone, workPlace);
                        AllMembers.Add(graduate);
                        break;
                    default: break;       
                }
            }
            return AllMembers;
        }

        /// <summary>
        /// Prints members
        /// </summary>
        /// <param name="AllMembers">all members</param>
        /// <param name="title">table title</param>
        public static void PrintMembers(MembersRegister AllMembers,
                                         string title)
        {
            Console.WriteLine("Duomenų metai: {0}", AllMembers.Year);
            Console.WriteLine(title);
            Header();
            for (int i = 0; i < AllMembers.Count(); i++)
            {
                Member member = AllMembers.Get(i);
                Console.WriteLine(member.ToString());
            }
            Console.WriteLine(new string('-', 89));
        }

        /// <summary>
        /// Prints primary data to "txt" file
        /// </summary>
        /// <param name="fileNameTxt">name of file</param>
        /// <param name="AllMembers">list of members</param>
        /// <param name="header">table header</param>
        public static void PrintMembersToTxt(string fileNameTxt,
                                              MembersRegister AllMembers,
                                              string header)
        {
            string[] Lines = new string[AllMembers.Count() + 6];
            Lines[0] = String.Format(header);
            Lines[1] = String.Format("Duomenų metai: {0}", AllMembers.Year);
            Lines[2] = String.Format(new string('-', 89));
            Lines[3] = String.Format("| {0,-12} | {1,-12} | {2,-11} | " +
                              " {3,-11} | {4,-4} | {5,-3} | {6,-10} |",
                              "Pavardė", "Vardas", "Gimimo data",
                              "Tel. nr.", "ID", "Kursas", "Darbovietė");
            Lines[4] = String.Format(new string('-', 89));
            for (int i = 0; i < AllMembers.Count(); i++)
            {
                Member member = AllMembers.Get(i);
                Lines[i + 5] = String.Format(AllMembers.Get(i).ToString());
            }
            Lines[AllMembers.Count() + 5] = String.Format(new string('-', 89));
            File.AppendAllLines(fileNameTxt, Lines, Encoding.UTF8);
        }

        /// <summary>
        /// Header for data printing
        /// </summary>
        public static void Header()
        {
            Console.WriteLine(new string('-', 89));
            Console.WriteLine("| {0,-12} | {1,-12} | {2,-12} | " +
                              " {3,-10} | {4,-4} | {5,-3} | {6,-10} |",
                              "Pavardė", "Vardas", "Gimimo data",
                              "Tel. nr.", "ID", "Kursas", "Darbovietė");
            Console.WriteLine(new string('-', 89));
        }

        /// <summary>
        /// Prints a list of the oldest students
        /// </summary>
        /// <param name="Oldest">List of oldest members</param>
        public static void PrintOldest(MembersContainer Oldest)
        {
            for (int i = 0; i < Oldest.Count; i++)
            {
                Member member = Oldest.Get(i);
                int age = DateTime.Now.Year - member.Date.Year;
                if (DateTime.Now.DayOfYear < member.Date.DayOfYear)
                {
                    age--;
                }
                Console.WriteLine($"{member.Name} {member.Surname}," +
                                  $" amžius: {age}");
            }
        }

        /// <summary>
        /// Prints members
        /// </summary>
        /// <param name="members">members</param>
        public static void PrintWorkMembers(MembersContainer members)
        {
            for (int i = 0; i < members.Count; i++)
            {
                Console.WriteLine(members.Get(i).ToString());
            }
            Console.WriteLine(new string('-', 89));
        }

        /// <summary>
        /// Prints data to "csv" file
        /// </summary>
        /// <param name="fileNameCSV">name of file</param>
        /// <param name="members">members</param>
        public static void Print_CSV(string fileNameCSV,
                                     MembersContainer members)
        {
            string[] Lines = new string[members.Count + 1];
            Lines[0] = String.Format("{0};{1};{2};{3};{4};{5};{6}",
                              "Pavardė", "Vardas", "Gimimo data",
                              "Tel. nr.", "ID", "Kursas", "Darbovietė");
            for (int i = 0; i < members.Count; i++)
            {
                Member member = members.Get(i);
                if (member is Student)
                {
                    Student student = member as Student;
                    Lines[i + 1] = String.Format("{0};{1};{2};{3};{4};{5}",
                               student.Surname, student.Name,
                               student.Date.ToShortDateString(),
                               student.Phone, student.ID, student.Course);
                }
                else if (member is Graduate)
                {
                    Graduate graduate = member as Graduate;
                    Lines[i + 1] = String.Format("{0};{1};{2};{3};{4};{5};{6}",
                               graduate.Surname, graduate.Name,
                               graduate.Date.ToShortDateString(),
                               graduate.Phone, "", "", graduate.WorkPlace);
                }
            }
            File.WriteAllLines(fileNameCSV, Lines, Encoding.UTF8);
        }

    }
}
