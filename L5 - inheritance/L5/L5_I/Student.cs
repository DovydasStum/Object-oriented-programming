using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5_I
{
    public class Student : Member
    {
        public int ID { get; set; }
        public string Course { get; set; }

        public Student(string surname, string name, DateTime date,
                       string phone, int id, string course) :
                       base(surname, name, date, phone)
        {
            this.ID = id;
            this.Course = course;
        }

        /// <summary>
        /// Overrides data to string
        /// </summary>
        /// <returns>Line</returns>
        public override string ToString()
        {
            string line;
            line = string.Format(base.ToString() + "{0,5} | {1,6} | {2,10} |",
                                 ID, Course, "");
            return line;
        }

    }
}
