using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentų_atstovybė
{
    class TaskUtils // class for calculations
    {
        /// <summary>
        /// Finds the oldest person
        /// </summary>
        /// <param name="People">List of all people</param>
        /// <returns>Age of oldest person</returns>
        public static Person FindOldestPerson(List<Person> People)
        {
            Person oldest = People[0];
            for (int i = 1; i < People.Count; i++)
            {
                if (DateTime.Compare(People[i].Date, oldest.Date) < 0)
                {
                    oldest = People[i];
                }
            }
            return oldest;
        }

        /// <summary>
        /// Finds the oldest people
        /// </summary>
        /// <param name="People">List of all people</param>
        /// <returns>List of oldest people </returns>
        public static List<Person> OldestPeople(List<Person> People)
        {
            List<Person> OldestPeopleList = new List<Person>();
            Person oldest = People[0];
            for (int i = 1; i < People.Count; i++)
            {
                if (DateTime.Compare(People[i].Date, oldest.Date) < 0)
                {
                    oldest = People[i];
                }
            }

            for (int i = 0; i < People.Count; i++)
            {
                if (People[i].Date == oldest.Date)
                {
                    OldestPeopleList.Add(People[i]);
                }
            }
            return OldestPeopleList;
        }

        /// <summary>
        /// Finds the highest amount of students in a course
        /// </summary>
        /// <param name="People">List of all people</param>
        /// <returns>Highest amount</returns>
        public static int CounterMax(List<Person> People)
        {
            int course1 = 0;
            int course2 = 0;
            int course3 = 0;
            int course4 = 0;

            foreach (Person person in People)
            {
               if (person.Course.Equals(1))
               {
                  course1++;
               }
               if (person.Course.Equals(2))
               {
                  course2++;
               }
               if (person.Course.Equals(3))
               {
                  course3++;
               }
               if (person.Course.Equals(4))
               {
                  course4++;
               }
            }

            int max = course1;
            if (course2 > max) max = course2;
            if (course3 > max) max = course3;
            if (course4 > max) max = course4;

            return max;
        }
        
        /// <summary>
        /// Makes list of courses without repetition
        /// </summary>
        /// <param name="People">List of all people</param>
        /// <returns>List of different courses only</returns>
        public static List<int> FilterDifferentCourse(List<Person> People)
        {
            List<int> FilterredDiff = new List<int>();
            foreach (Person person in People)
            {
                int number = person.Course;
                if (!FilterredDiff.Contains(number))
                {
                    FilterredDiff.Add(number);
                }
            }
            return FilterredDiff;
        }
 
        /// <summary>
        /// Makes list of courses which contain the most students
        /// </summary>
        /// <param name="People">List of al people</param>
        /// <param name="FilterredDiff">List of different courses</param>
        /// <returns>List of courses</returns>
        public static List<int> EditFilteredDiff (List<Person> People, List<int> FilterredDiff)
        {
            List<int> MostStudents = new List<int>();          
            for (int i = 0; i < FilterredDiff.Count; i++)
            {
                int count = 0;
                for (int j = 0; j < People.Count; j++)
                {
                    if (FilterredDiff[i] == People[j].Course)
                    {
                        count++;
                    }
                }
                if (count == TaskUtils.CounterMax(People))
                {
                    MostStudents.Add(FilterredDiff[i]);
                } 
            }
            return MostStudents;
        }

        /// <summary>
        /// Sorts second and higher course students
        /// </summary>
        /// <param name="People">All people</param>
        /// <returns>List of second and higher course students</returns>
        public static List<Person> FilterCourse(List<Person> People)
        {
            List<Person> Filtered = new List<Person>();
            foreach (Person person in People)
            {
                if (person.Course > 1)
                {
                    Filtered.Add(person);
                }
            }
            return Filtered;
        }
    }
}
