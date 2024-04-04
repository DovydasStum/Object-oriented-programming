using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5_I
{
    class Program
    {
        static void Main(string[] args)
        {
            // Primary data reading and printing to the console
            MembersRegister members0 = InOutUtils.ReadMembers("1members0.csv");
            string title = "Dabartiniai studentų atstovybės nariai: ";
            InOutUtils.PrintMembers(members0, title);
            Console.WriteLine();

            MembersRegister members1 = InOutUtils.ReadMembers("1members1.csv");
            title = "Vienerių ankstesnių metų studentų atstovybės nariai: ";
            InOutUtils.PrintMembers(members1, title);
            Console.WriteLine();

            MembersRegister members2 = InOutUtils.ReadMembers("1members2.csv");
            title = "Dar vienerių ankstesnių metų studentų atstovybės nariai: ";
            InOutUtils.PrintMembers(members2, title);
            Console.WriteLine();

            // Primary data printing to "txt" file
            string fileNameTxt = "Data.txt";
            string header = "Dabartiniai studentų atstovybės nariai: ";
            InOutUtils.PrintMembersToTxt(fileNameTxt, members0, header);
            header = "Ankstesnių metų studentų atstovybės nariai: ";
            InOutUtils.PrintMembersToTxt(fileNameTxt, members1, header);
            header = "Dar vienerių ankstesnių metų studentų atstovybės nariai: ";
            InOutUtils.PrintMembersToTxt(fileNameTxt, members2, header);

            // Task 1
            Member FirstOldest = TaskUtils.FindOldestMember(members0);
            Member SecondOldest = TaskUtils.FindOldestMember(members1);
            Member ThirdOldest = TaskUtils.FindOldestMember(members2);
            DateTime OldestDate = SecondOldest.Date;
            if (FirstOldest.Date <= SecondOldest.Date &&
                FirstOldest.Date <= ThirdOldest.Date)
            {
                OldestDate = FirstOldest.Date;
            }
            else if (ThirdOldest.Date <= FirstOldest.Date &&
                     ThirdOldest.Date <= SecondOldest.Date)
            {
                OldestDate = ThirdOldest.Date;
            }
            MembersContainer Oldest1 = TaskUtils.OldestList(members0, OldestDate);
            MembersContainer Oldest2 = TaskUtils.OldestList(members1, OldestDate);
            MembersContainer Oldest3 = TaskUtils.OldestList(members2, OldestDate);
            Console.WriteLine("Vyriausias atstovybei priklausęs studentas arba studentai:");
            InOutUtils.PrintOldest(Oldest1);
            InOutUtils.PrintOldest(Oldest2);
            InOutUtils.PrintOldest(Oldest3);
            Console.WriteLine();

            // Task 2
            MembersContainer Work2Years1 = TaskUtils.Work2Years(members0, 
                                                                members1);
            MembersContainer Work2Years2 = TaskUtils.Work2Years(members1,
                                                                members2);
            MembersContainer Work2YearsBoth = TaskUtils.ListOfBoth(Work2Years1,
                                                                   Work2Years2);

            if (Work2YearsBoth.Count > 0)
            {
                Console.WriteLine("Nariai, dirbę bent 2 metus iš eilės: "); 
                InOutUtils.Header();                
                InOutUtils.PrintWorkMembers(Work2YearsBoth);
            }
            else
            {
                Console.WriteLine("Narių, dirbusių bent 2 metus iš eilės, nėra.");
            }

            // Task 3
            string workPlace = "ATEA";
            MembersContainer AteaWorkers = TaskUtils.Atea(members0, workPlace);
            if (AteaWorkers.Count > 0)
            {
                string csvFile1 = "Atea.csv";
                AteaWorkers.Sort(new ComparatorBySurnameAndName());
                InOutUtils.Print_CSV(csvFile1, AteaWorkers);
            }
            else
            {
                Console.WriteLine("Narių, dirbančių ATEA, nėra.");
            }

            // Task 4
            string csvFile2 = "Buvo.csv";
            MembersContainer FirstList = TaskUtils.ListOfMembers(members0,
                                                                 members1);
            MembersContainer SecondList = TaskUtils.ListOfMembers(members1,
                                                                  members2);
            MembersContainer AllMembers = TaskUtils.ListOfBoth(FirstList,
                                                               SecondList);
            InOutUtils.Print_CSV(csvFile2, AllMembers);
        }
    }
}
