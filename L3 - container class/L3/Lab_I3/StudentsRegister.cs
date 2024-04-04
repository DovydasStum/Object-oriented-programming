using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_I3
{
    class StudentsRegister
    {
        private StudentsContainer AllStudents;
        public int Year { get; set; }
        public StudentsRegister()
        {
            AllStudents = new StudentsContainer();
        }

        public StudentsRegister(StudentsContainer Students)
        {
            Students = new StudentsContainer();
            for (int i = 0; i < Students.Count; i++)
            {
                this.AllStudents.Add(Students.Get(i));
            }
        }

        /// <summary>
        /// Checks if element already exists
        /// </summary>
        /// <param name="student">student</param>
        /// <returns>true or false</returns>
        public bool Contains(Student student)
        {
            return AllStudents.Contains(student);
        }

        /// <summary>
        /// Adds element
        /// </summary>
        /// <param name="student">element</param>
        public void Add(Student student)
        {
            AllStudents.Add(student);
        }

        /// <summary>
        /// Counts all elements
        /// </summary>
        /// <returns>quantity</returns>
        public int Count()
        {
            return this.AllStudents.Count;
        }

        /// <summary>
        /// Returns student by its index
        /// </summary>
        /// <param name="index">Index of student</param>
        /// <returns>Student by index</returns>
        public Student Get(int index)
        {
            return AllStudents.Get(index);
        }

        /// <summary>
        /// Counts students in the list
        /// </summary>
        /// <returns>Number of students</returns>
        public int StudentsCount()
        {
            return this.AllStudents.Count;
        }


    }
}
