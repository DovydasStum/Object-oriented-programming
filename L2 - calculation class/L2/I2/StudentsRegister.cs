using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I2
{
    class StudentsRegister // class for students list tasks
    {
        private List<Student> AllStudents;
        public int Year { get; set; } // Information about data year

        /// <summary>
        /// Makes list for students
        /// </summary>
        public StudentsRegister()
        {
            AllStudents = new List<Student>();
        }

        /// <summary>
        /// Adds student to the list
        /// </summary>
        /// <param name="Students">List of students</param>
        public StudentsRegister(List<Student> Students)
        {
            AllStudents = new List<Student>();
            foreach (Student student in Students)
            {
                this.AllStudents.Add(student);
            }
        }

        /// <summary>
        /// Adds student to the list
        /// </summary>
        /// <param name="Students">List of students</param>
        public void Add(Student student)
        {
            AllStudents.Add(student);
        }

        /// <summary>
        /// Checks if the student exists in the list
        /// </summary>
        /// <param name="student">One student</param>
        /// <returns>True or false</returns>
        public bool Contains(Student student)
        {
            return AllStudents.Contains(student);
        }

        /// <summary>
        /// Counts students in the list
        /// </summary>
        /// <returns>Number of students</returns>
        public int Count()
        {
            return AllStudents.Count();
        }

        /// <summary>
        /// Returns student by its index
        /// </summary>
        /// <param name="index">Index of student</param>
        /// <returns>Student by index</returns>
        public Student Get(int index)
        {
            return AllStudents[index];
        }

        /// <summary>
        /// Counts students in the list
        /// </summary>
        /// <returns>Number of students</returns>
        public int StudentsCount()
        {
            return this.AllStudents.Count();
        }

        /// <summary>
        /// Finds student by its ID
        /// </summary>
        /// <param name="ID">Student's ID</param>
        /// <returns>Student or null</returns>
        private Student FindByID(int ID)
        {
            foreach (Student student in this.AllStudents)
            {
                if (student.ID == ID)
                {
                    return student;
                }
            }
            return null;
        }

        /// <summary>
        /// Makes list of students who left organisation second year
        /// </summary>
        /// <param name="OlderStudents">List of students from previous year</param>
        /// <param name="Students">List of present year students</param>
        /// <returns>List of students who left the organisation</returns>
        public static List<Student> Removed(StudentsRegister OlderStudents, StudentsRegister Students)
        {
             List<Student> RemovedList = new List<Student>();
             for (int i = 0; i < OlderStudents.Count(); i++)
             {
                 if (!Students.Contains(OlderStudents.Get(i)))
                 {
                     RemovedList.Add(OlderStudents.Get(i));
                 }
             }
             return RemovedList;
        }

        /// <summary>
        /// Finds the oldest student
        /// </summary>
        /// <returns>oldest student</returns>
        public Student FindOldestStudent()
        {
            Student oldest = AllStudents[0];
            for (int i = 1; i < AllStudents.Count(); i++)
            {
                if (DateTime.Compare(AllStudents[i].Date, oldest.Date) < 0)
                {
                    oldest = AllStudents[i];
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
        public static List<Student> BothYears(StudentsRegister OlderStudents, StudentsRegister Students)
        {
            List<Student> Filter = new List<Student>();
            for (int i = 0; i < Students.Count(); i++)
            {
                for (int j = 0; j < OlderStudents.Count(); j++)
                {
                    if (Students.Get(i).Equals(OlderStudents.Get(j)))
                    {
                        Filter.Add(OlderStudents.Get(j));
                    }
                }
            }
            return Filter;
        }

        /// <summary>
        /// Makes the list of oldest students
        /// </summary>
        /// <param name="Students">List of present year students</param>
        /// <param name="OldestDate">Birth date of the oldest student</param>
        /// <returns>List of oldest students</returns>
        public static List<Student> Oldest1(StudentsRegister Students, DateTime OldestDate)
        {
             List<Student> Oldest = new List<Student>();
             for (int i = 0; i < Students.Count(); i++)
             {
                 if (Students.Get(i) == OldestDate)
                 {
                     Oldest.Add(Students.Get(i));
                 }
             }
             return Oldest;
        }

        /// <summary>
        /// Makes the list of oldest students
        /// </summary>
        /// <param name="OlderStudents">List of previous year students</param>
        /// <param name="OldestDate">Birth date of the oldest student</param>
        /// <returns>List of oldest students</returns>
        public static List<Student> Oldest2(StudentsRegister OlderStudents, DateTime OldestDate)
        {
            List<Student> Oldest = new List<Student>();
            for (int i = 0; i < OlderStudents.Count(); i++)
            {
                if (OlderStudents.Get(i) == OldestDate)
                {
                    Oldest.Add(OlderStudents.Get(i));
                }
            }
            return Oldest;
        }
    }
}
