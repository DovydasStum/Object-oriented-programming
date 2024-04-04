using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_I3
{
    class TaskUtils
    {
        /// <summary>
        /// Makes a list of students who left organisation
        /// </summary>
        /// <param name="AllStudents">Current students</param>
        /// <param name="OlderStudents">Previous year students</param>
        /// <returns>List of students who left organisation</returns>
        public static StudentsContainer Removed(StudentsRegister AllStudents,
                                                StudentsRegister OlderStudents)
        {
            StudentsContainer Removed = new StudentsContainer();
            for (int i = 0; i < OlderStudents.Count(); i++)
            {
                if (!AllStudents.Contains(OlderStudents.Get(i)))
                {
                    Removed.Add(OlderStudents.Get(i));
                }
            }
            return Removed;
        }

        /// <summary>
        /// Makes the list of current year oldest students
        /// </summary>
        /// <param name="AllStudents">List of current year students</param>
        /// <param name="OldestDate">Birth date of the oldest student</param>
        /// <returns>List of oldest students</returns>
        public static StudentsContainer Oldest1(StudentsRegister AllStudents,
                                                DateTime OldestDate)
        {
            StudentsContainer Oldest = new StudentsContainer();
            for (int i = 0; i < AllStudents.Count(); i++)
            {
                if (AllStudents.Get(i) == OldestDate)
                {
                    Oldest.Add(AllStudents.Get(i));
                }
            }
            return Oldest;
        }

        /// <summary>
        /// Makes the list of previous year oldest students
        /// </summary>
        /// <param name="OlderStudents">List of previous year students</param>
        /// <param name="OldestDate">Birth date of the oldest student</param>
        /// <returns>List of oldest students</returns>
        public static StudentsContainer Oldest2(StudentsRegister OlderStudents,
                                                DateTime OldestDate)
        {
            StudentsContainer Oldest = new StudentsContainer();
            for (int i = 0; i < OlderStudents.Count(); i++)
            {
                if (OlderStudents.Get(i).Date == OldestDate)
                {
                    Oldest.Add(OlderStudents.Get(i));
                }
            }
            return Oldest;
        }

        /// <summary>
        /// Finds the oldest student
        /// </summary>
        /// <returns>Oldest student</returns>
        public static Student FindOldestStudent(StudentsRegister Students)
        {
            Student oldest = Students.Get(0);
            for (int i = 0; i < Students.Count(); i++)
            {
                if (Students.Get(i).Date < oldest.Date)
                {
                    oldest = Students.Get(i);
                }
            }
            return oldest;
        }

        /// <summary>
        /// Creates a list of students who were at the organisation both years
        /// </summary>
        /// <param name="OlderStudents">List of previous year students</param>
        /// <param name="Students">List of present year students</param>
        /// <returns>List of students who were at the organisation both years</returns>
        public static StudentsContainer BothYears(StudentsRegister OlderStudents,
                                                  StudentsRegister Students)
        {
            StudentsContainer Filter = new StudentsContainer();
            for (int i = 0; i < Students.Count(); i++)
            {
                for (int j = 0; j < OlderStudents.Count(); j++)
                {
                    if (Students.Get(i).Equals(OlderStudents.Get(j)))
                    {
                        Filter.Add(Students.Get(i));
                    }
                }
            }
            return Filter;
        }
    }
}
