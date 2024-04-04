using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I2
{
    class Student // class for student
    {
        public string Surname {get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int ID { get; set; }
        public int Course { get; set; }
        public string Phone { get; set; }
        public string Mark { get; set; }

        public Student (string surname, string name, DateTime date, int id, int course, string phone, string mark)
        {
            this.Surname = surname;
            this.Name = name;
            this.Date = date;
            this.ID = id;
            this.Course = course;
            this.Phone = phone;
            this.Mark = mark;
        }

        /// <summary>
        /// Overrides data to string
        /// </summary>
        /// <returns>Line</returns>
        public override string ToString()
        {
            string line;
            line = string.Format("| {0,-11} | {1,-12} | {2,11} | {3,5} | {4,6} | {5,11} | {6,-8} |",
                                  Surname, Name, Date.ToShortDateString(), ID, Course, Phone, Mark);
            return line;
        }

        /// <summary>
        /// Compares two student's properties
        /// </summary>
        /// <param name="student">student</param>
        /// <returns>ID of student</returns>
        public override bool Equals(object student)
        {
            return this.ID == ((Student)student).ID;
        }

        /// <summary>
        /// Gets hash code of student
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }

        /// <summary>
        /// Checks if students birth date is the same as the oldest's student's
        /// </summary>
        /// <param name="StudentsRegister">Register of students</param>
        /// <param name="OldestDate">Birth date of the oldest student</param>
        /// <returns>true if date is equal to the oldest's student's date</returns>
        public static bool operator ==(Student StudentsRegister, DateTime OldestDate)
        {
            return StudentsRegister.Date == OldestDate;
        }
        public static bool operator !=(Student StudentsRegister, DateTime OldestDate)
        {
            return StudentsRegister.Date == OldestDate;
        }
    }
}
