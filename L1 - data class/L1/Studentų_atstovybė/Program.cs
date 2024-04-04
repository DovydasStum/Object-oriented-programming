using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Studentų_atstovybė
{
    class Program // class for main program
    {
        static void Main(string[] args)
        {
            // Primary data reading and printing
            List<Person> allPeople = InOutUtils.ReadPeople("Students2.csv");
            InOutUtils.PrintPeopleToScreen(allPeople);
            string fileName1 = "Data.txt";
            InOutUtils.PrintPeopleToTxtFile(fileName1, allPeople);

            // Task 1
            List<Person> OldestPeopleList = TaskUtils.OldestPeople(allPeople);
            InOutUtils.PrintOldestPeople(OldestPeopleList);

            // Task 2
            List<int> FilterredDiff = TaskUtils.FilterDifferentCourse(allPeople);
            List<int> MostStudents = TaskUtils.EditFilteredDiff(allPeople, FilterredDiff);
            InOutUtils.PrintMostStudents(MostStudents);
            InOutUtils.PrintHighestAmount(allPeople);

            // Task 3
            List<Person> FilterCourse = TaskUtils.FilterCourse(allPeople);
            string fileName = "Senbuviai.csv";
            InOutUtils.PrintToCSVFile(fileName, FilterCourse);
        }
    }
}
